using Beesys.Wasp.Workflow;
using BeeSys.Wasp.Communicator;
using BeeSys.Wasp.KernelController;
using BeeSys.Wasp3D.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BeeSys.Wasp3D.Utility
{
    /// <summary>
    /// Class to handle the UDT Data
    /// </summary>
    public class UDTHandler
    {
        #region Class Variables
         XDocument _xdColumnInfo = null;
        string UDTID = "";
        string UDTName = "";
        /// <summary>
        /// Class to handle the CRUD operation within KC 
        /// </summary>
        private UDTDataManagerHelper m_UDTDataManagerHelper;
        object lockobject = new object();
        Thread m_objthProcess;
        bool m_bKillThread;
        Queue<UdtArgs> m_objQueue = new Queue<UdtArgs>();
        ManualResetEvent m_objMnulRstEvnt = new ManualResetEvent(false);

        private DataSet _dataset;
        #endregion

        #region Properties
        public DataSet DataSet { get { return _dataset; } set { _dataset = value; } }
        #endregion

        #region Events
        public event Action<UdtArgs> OnResponse; 
        #endregion




        /// <summary>
        /// Initialize UDT
        /// </summary>
        /// <param name="udt"></param>
        public UDTHandler(string udt)
        {
            UDTName = udt;
        }
        /// <summary>
        /// Add data into table
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dataColumn"></param>
        /// <param name="parentId"></param>
        /// <param name="data"></param>
        public void Add(string tableName, string dataColumn, int parentId, Dictionary<string, object> data)
        {             
            AddRow(tableName, dataColumn, parentId, data);
        }
        /// <summary>
        /// Get acutual table name by which we can add, update and delete operation.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="xdColumnInfo"></param>
        /// <returns></returns>
        private string GetActualTableName(string tableName, XDocument xdColumnInfo)
        {
            string sActualTableName = tableName;
            try
            {
                if (xdColumnInfo != null)
                {
                    //Select those element which attribute name is tablename and get acutal table name.
                    XElement xeTable = xdColumnInfo.XPathSelectElement("//tables/table[@name='" + tableName + "']");
                    if (xeTable != null && xeTable.Attribute("tid") != null)
                    {
                        sActualTableName = xeTable.Attribute("tid").Value;
                    }
                }
                return sActualTableName;
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex);
            }
            return sActualTableName;
        }
        /// <summary>
        /// Delete Data from table
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="data"></param>
        public void Remove(string tableName, Dictionary<string, object> data)
        {
             
            string column = data.FirstOrDefault().Key;
            object columnValue = data.FirstOrDefault().Value;
            var dtRows = _dataset.Tables[tableName].Select(column + "= '" + columnValue.ToString() + "'");
            if (dtRows != null && dtRows.Length > 0)
            {
                _Delete(dtRows[0]);
                _dataset.Tables[tableName].Rows.Remove(dtRows[0]);
            }
        }
       
        /// <summary>
        /// Load Data from UDt
        /// </summary>
        /// <returns></returns>
        internal DataSet LoadData()
        {
            _dataset = GetDataSet();
            return _dataset;
        }

        public UDTDataManagerHelper UDTDataManagerHelper
        {
            get { return m_UDTDataManagerHelper; }
            set
            {
                if (m_UDTDataManagerHelper != null)
                {
                    m_UDTDataManagerHelper.m_evtUdtResponse -= M_UDTDataManagerHelper_m_evtUdtResponse;
                }
                m_UDTDataManagerHelper = value;
                if (m_UDTDataManagerHelper != null)
                {
                    m_UDTDataManagerHelper.m_evtUdtResponse += M_UDTDataManagerHelper_m_evtUdtResponse;
                    if (m_objthProcess == null)
                    {
                        m_objthProcess = new Thread(new ThreadStart(ReadQueueData));
                        m_objthProcess.Start();
                    }
                }
            }
        }

        /// <summary>
        /// Method is used to connect with KC
        /// </summary>
        public void ConnectWithKC()
        {
            CRemoteHelper objRemoteHelper = null;
            UDTDataManagerHelper objUDTEnumDataManagerHelper = null;
            //as per change in KCURL for  enterprise, check with disconnected URL first as RemoteHelper must be connected by Application.
            //if getting empty EndpointAddress, then check connection for  CRemoteHelper
            bool bCheckForConnection = false;
            ServiceUrl objServiceUrl = CRemoteHelper.GetDisconnectedUrl("UDTManager");
            if (string.IsNullOrEmpty(objServiceUrl.sEndpointAddress))
                bCheckForConnection = true;

            ServiceUrl objServiceUrlDataMgr = CRemoteHelper.GetDisconnectedUrl("UDTDataManager");
            if (!bCheckForConnection)
            {
                if (string.IsNullOrEmpty(objServiceUrlDataMgr.sEndpointAddress))
                    bCheckForConnection = true;
            }

            string sRemoteURL = string.Empty;
            if (bCheckForConnection)
            {
                sRemoteURL = GetServiceURL();
                int iResponsePortNumber = 20001;
                try
                {
                    if (ConfigurationManager.AppSettings["responseportnumber"] != null)
                    {
                        string sResPortNum = ConfigurationManager.AppSettings["responseportnumber"].ToString();
                        bool bValid = int.TryParse(sResPortNum, out iResponsePortNumber);
                    }
                }
                catch { }

                objRemoteHelper = new CRemoteHelper(sRemoteURL, "UDTUpdate", iResponsePortNumber);
                objRemoteHelper.InitRemoteHelper();

                Thread.Sleep(1000);

                //get the kc service url from common config
                ConnectionInfo objConnectioninfo = objRemoteHelper.CheckConnection();
                //ConnectionInfo objConnectioninfo = CRemoteHelper.RemoteHelper.CheckConnection();
                if (objConnectioninfo.status == Status.Connected)
                {
                    objServiceUrl = CRemoteHelper.GetDisconnectedUrl("UDTManager");
                    objServiceUrlDataMgr = CRemoteHelper.GetDisconnectedUrl("UDTDataManager");
                }
            }
            if (!string.IsNullOrEmpty(objServiceUrlDataMgr.sEndpointAddress))
                objUDTEnumDataManagerHelper = new UDTDataManagerHelper(objServiceUrlDataMgr.sEndpointAddress);
            UDTDataManagerHelper = objUDTEnumDataManagerHelper;
        }
        /// <summary>
        /// get the service url
        /// </summary>
        /// <returns></returns>
        string GetServiceURL()
        {
            string serviceurl = "";
            try
            {
                string sFilePath = Path.Combine(Environment.GetEnvironmentVariable("WaspCommon", EnvironmentVariableTarget.Machine) + "CommonConfig.config");
                if (File.Exists(sFilePath))
                {
                    XDocument xdData = XDocument.Load(sFilePath);
                    if (xdData != null)
                    {
                        //if (!ControlHandler.IsLocalKCConnected)
                        {
                            XElement xeKCConnection = xdData.XPathSelectElement("//add[@key='REMOTEMANAGERURL']");
                            if (xeKCConnection != null)
                            {
                                if (xeKCConnection.Attribute("value") != null && xeKCConnection.Attribute("value").Value != null)
                                    serviceurl = xeKCConnection.Attribute("value").Value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex);
            }//end(catch)
            return serviceurl;
        }

        /// <summary>
        /// get the data set by udt id or udt name
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            DataSet dataSet = new DataSet("UDT");
            if (UDTDataManagerHelper != null)
            {

                DataConnectRespArgs objDataConnectRespArgs = UDTDataManagerHelper.LoadUdt(UDTDataManagerHelper.Sessionid, UDTName);
                if (objDataConnectRespArgs != null)
                {

                    UDTID = objDataConnectRespArgs.Udtid ;
                    LoadUDTDataSet(objDataConnectRespArgs, dataSet);
                }
            }
            return dataSet;
        }

        /// <summary>
        /// Load Dataset from UDT xml
        /// </summary>
        /// <param name="objDataConnectRespArgs"></param>
        /// <param name="dataSet"></param>
        private void LoadUDTDataSet(DataConnectRespArgs objDataConnectRespArgs, DataSet dataSet)
        {
            
            if (dataSet != null)
            {
                if (!string.IsNullOrEmpty(objDataConnectRespArgs.Schema))
                {
                    using (XmlReader reader = XmlReader.Create(new StringReader(objDataConnectRespArgs.Schema)))
                    {
                        dataSet.ReadXmlSchema(reader);
                    }

                    if (!string.IsNullOrEmpty(objDataConnectRespArgs.Data))
                    {
                        using (TextReader srData = new StringReader(objDataConnectRespArgs.Data))
                        {
                            try
                            {
                                dataSet.ReadXml(srData, XmlReadMode.Auto);

                                //dsReturn.ReadXml(srData);
                            }
                            catch
                            {
                                srData.Close();
                            }
                            dataSet.EnforceConstraints = false;
                            srData.Close();
                        }

                    }

                    if (objDataConnectRespArgs != null && !string.IsNullOrEmpty(objDataConnectRespArgs.ColumnInfo))
                    {
                        _xdColumnInfo = XDocument.Parse(objDataConnectRespArgs.ColumnInfo);
                       
                    }
                    foreach (DataTable dt in dataSet.Tables)
                    {
                        string sTableName = dt.TableName;
                        dt.TableName = GetTableName(dt.TableName);
                    }
                }
            }
        }
        /// <summary>
        /// Get table name
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="xdColumnInfo"></param>
        /// <returns></returns>
        public  string GetTableName(string tableName )
        {
            string strTableName = tableName;
            try
            {
                if (_xdColumnInfo != null)
                {
                    XElement xeTable = _xdColumnInfo.XPathSelectElement("//tables/table[@tid='" + tableName + "']");
                    if (xeTable != null && xeTable.Attribute("name") != null)
                    {
                        strTableName = xeTable.Attribute("name").Value;
                    }
                }
            }
            catch
            {
            }
            return strTableName;
        }


        /// <summary>
        /// conver object array into string array
        /// </summary>
        /// <param name="objArr"></param>
        /// <returns></returns>
        private static string[] ConvertToString(object[] objArr)
        {
            string[] arrString = null;
            try
            {
                arrString = new string[objArr.Length];
                for (int i = 0; i < objArr.Length; i++)
                {
                    arrString[i] = objArr[i].ToString();
                    //arrString.Add(objArr[i].ToString());
                }
                return arrString;
            }
            finally
            {
                arrString = null;
            }
        }

        /// <summary>
        /// update the data into KC
        /// </summary>
        /// <param name="row"></param>
        public void UpdateRow(DataRow row)
        {
            _Update(row);
        }
        /// <summary>
        /// Add data in a row in UDT.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dataColoumn"></param>
        /// <param name="parentId"></param>
        /// <param name="dicColValue"></param>
        public void AddRow(string tableName, string dataColoumn, int parentId, Dictionary<string, object> dicColValue)
        {
            if (_dataset.Tables.Contains(tableName))
            {
                string parentColumnName = "";

                if (_dataset.Tables[tableName].ParentRelations.Count > 0)
                {
                    parentColumnName = _dataset.Tables[tableName].ParentRelations[0].ParentColumns[0].ColumnName;

                }
                var rows = _dataset.Tables[tableName].Rows.Cast<DataRow>().Where(item => item[parentColumnName].ToString() == parentId.ToString()).ToList();

                //If row count is 1 and found data is empty then we will update the row otherwise we will call add
                if (rows.Count == 1)
                {
                    string sData = rows[0][dataColoumn].ToString();

                    if (string.IsNullOrEmpty(sData))
                    {
                        DataRow udtRow = rows[0];
                        UpdateDataInUDTRow(udtRow, dicColValue);
                        _Update(udtRow);
                    }
                    else
                    {
                        DataRow udtRow = _dataset.Tables[tableName].NewRow();
                        if (_dataset.Tables[tableName].ParentRelations.Count > 0)
                        {

                            udtRow[parentColumnName] = parentId;
                        }

                        UpdateDataInUDTRow(udtRow, dicColValue);
                        _Add(udtRow);
                        _dataset.Tables[tableName].Rows.Add(udtRow);
                    }

                }
                else
                {
                    DataRow udtRow = _dataset.Tables[tableName].NewRow();

                    if (_dataset.Tables[tableName].ParentRelations.Count > 0)
                    {
                        udtRow[parentColumnName] = parentId;
                    }
                    UpdateDataInUDTRow(udtRow, dicColValue);
                    _Add(udtRow);
                    _dataset.Tables[tableName].Rows.Add(udtRow);
                }
            }

        }
        /// <summary>
        /// Update data row with given data in UDT
        /// </summary>
        /// <param name="udtRow"></param>
        /// <param name="dicColValue"></param>
        private void UpdateDataInUDTRow(DataRow udtRow, Dictionary<string, object> dicColValue)
        {
            foreach (var item in dicColValue)
            {
                udtRow[item.Key] = item.Value;
            }
        }
        /// <summary>
        /// Add data in KC
        /// </summary>
        /// <param name="drRow"></param>
        private void _Add(DataRow drRow)
        {
            AddRowRespArgs objAddRowRespArgs = new AddRowRespArgs();
            UdtArgs objUdtArgs = new UdtArgs();
            UdtParams objUdtParams = new UdtParams();
            objUdtArgs.Udtid = UDTID;
            objAddRowRespArgs.Data = ConvertToString(drRow.ItemArray);
            objAddRowRespArgs.PrimaryKeys = null;
            objAddRowRespArgs.TableName = GetActualTableName(drRow.Table.TableName, _xdColumnInfo);
            objUdtParams.AddRowParams = objAddRowRespArgs;
            objUdtArgs.ActionParams = new UdtParams[1];
            objUdtArgs.ActionParams[0] = objUdtParams;
            if (UDTDataManagerHelper != null)
                UDTDataManagerHelper.AddRow(objUdtArgs);
        }
        

        /// <summary>
        /// update single data into KC
        /// </summary>
        /// <param name="drRow"></param>
        private void _Update(DataRow drRow)
        {
            UdtArgs objUdtArgs = new UdtArgs();
            UdtParams objUdtParams = new UdtParams();
            UpdateRowRespArgs objUpdateRowRespArgs = new UpdateRowRespArgs();
            objUdtArgs.Udtid = UDTID;
            objUpdateRowRespArgs.Data = ConvertToString(drRow.ItemArray);
            objUpdateRowRespArgs.TableName = GetActualTableName(drRow.Table.TableName, _xdColumnInfo);   
            objUdtParams.UpdateRowParams = objUpdateRowRespArgs;
            objUdtArgs.ActionParams = new UdtParams[1];
            objUdtArgs.ActionParams[0] = objUdtParams;
            if (UDTDataManagerHelper != null)
                UDTDataManagerHelper.UpdateRow(objUdtArgs);
        }

        /// <summary>
        /// Delete data from KC UDT
        /// </summary>
        /// <param name="drRemove"></param>
        private void _Delete(DataRow drRemove)
        {
            UdtArgs objUdtArgs = new UdtArgs();
            UdtParams objUdtParams = new UdtParams();
            DeleteRowRespArgs objDeleteRowRespArgs = new DeleteRowRespArgs();
            objUdtArgs.Udtid = UDTID;
            objDeleteRowRespArgs.PrimaryKey = ConvertToString(drRemove.ItemArray);
            objDeleteRowRespArgs.TableName = GetActualTableName(drRemove.Table.TableName,_xdColumnInfo);
            objUdtParams.DeleteRowParams = objDeleteRowRespArgs;
            objUdtArgs.ActionParams = new UdtParams[1];

            objUdtArgs.ActionParams[0] = objUdtParams;

            if (UDTDataManagerHelper != null)
                UDTDataManagerHelper.DeleteRow(objUdtArgs);
        }

        /// <summary>
        /// Delete multiple rows
        /// </summary>
        /// <param name="drRows"></param>
        private void _Delete(DataRow[] drRows)
        {
            UdtArgs objUdtArgs = new UdtArgs();

            objUdtArgs.ActionParams = new UdtParams[drRows.Length];
            for (int iLoop = 0; iLoop < drRows.Length; iLoop++)
            {
                DataRow drRow = drRows[iLoop];
                UdtParams objUdtParams = new UdtParams();

                DeleteRowRespArgs objDeleteRowRespArgs = new DeleteRowRespArgs();
                objUdtArgs.Udtid = UDTID;
                objDeleteRowRespArgs.PrimaryKey = ConvertToString(drRow.ItemArray);
                objDeleteRowRespArgs.TableName = GetActualTableName(drRow.Table.TableName, _xdColumnInfo);
                objUdtParams.DeleteRowParams = objDeleteRowRespArgs;
                objUdtArgs.ActionParams[iLoop] = objUdtParams;
            }
            if (UDTDataManagerHelper != null)
                UDTDataManagerHelper.DeleteRow(objUdtArgs);
        }
        /// <summary>
        /// this method is used to process udt response
        /// </summary>
        private void ReadQueueData()
        {
            try
            {
                for (; ; )
                {
                    UdtArgs objCUdtResponseArgs = null;
                    try
                    {
                        if (m_bKillThread)
                            break;
                        int count = 0;
                        lock (m_objQueue)
                        {
                            count = m_objQueue.Count;
                        }
                        if (count == 0)
                        {
                            m_objMnulRstEvnt.Reset();
                            m_objMnulRstEvnt.WaitOne(1000);
                        }

                        if (m_bKillThread)
                            break;

                        lock (m_objQueue)
                        {
                            count = m_objQueue.Count;
                        }


                        objCUdtResponseArgs = null;
                        if (m_bKillThread)
                            break;

                        //Process the dequeue from m_objQueue and apply Reader Writer Lock on m_objQueue
                        lock (m_objQueue)
                        {
                            if (count > 0)
                                objCUdtResponseArgs = m_objQueue.Dequeue();
                        }

                        if (m_bKillThread)
                            break;

                        if (objCUdtResponseArgs != null)
                        {
                            InternalUdtResponse(objCUdtResponseArgs);
                        }

                        if (m_bKillThread)
                            break;

                    }
                    catch (Exception exTemp)
                    {
                        WriteLog(exTemp);
                    }
                    finally
                    {

                        objCUdtResponseArgs = null;

                    }
                }//end (for(;;))

            }//end (try)          
            catch (ThreadAbortException exTh)
            {
                WriteLog(exTh);
            }
            catch (Exception ex)
            {
                WriteLog(ex);

            }//end (catch(ExternalException ex){throw new CComExceptionHandler(ex);} catch)
            finally
            {

                if (m_objQueue != null)
                    m_objQueue.Clear();

            }//end (finally)

        }//end (ReadStatusData)      

        /// <summary>
        /// This method is used to handle udt response like add roe,update row ,delete row etc
        /// </summary>
        /// <param name="obj"></param>
        internal void InternalUdtResponse(UdtArgs obj)
        {

            string sID = string.Empty;
            string sName = string.Empty;
            try
            {
                if (obj != null && string.Compare(obj.Udtid, UDTID, true) == 0)
                {

                    _dataset = GetDataSet();
                    switch (obj.Action.ToLower())
                    {

                        case "updaterow": // use this case when row is updated in udt                           
                        case "addrow":
                        case "deleterow":
                            if (OnResponse != null)
                            {
                                OnResponse(obj);
                            }
                            break;

                    }


                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        /// <summary>
        /// udt response event on the basis of action
        /// </summary>
        /// <param name="obj"></param>
        private void M_UDTDataManagerHelper_m_evtUdtResponse(UdtArgs obj)
        {
            try
            {
                if (string.Compare(obj.Udtid, UDTID, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    lock (m_objQueue)
                    {
                        try
                        {
                            //Process the enqueue from m_objQueue and apply Reader Writer Lock on m_objQueue
                            m_objQueue.Enqueue(obj);
                        }
                        catch (Exception ex)
                        {
                            WriteLog(ex);
                        }
                    }
                    m_objMnulRstEvnt.Set();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        private static void WriteLog(Exception ex)
        {
            LogWriter.WriteLog(ex);
        }
        /// <summary>
        /// release the resources
        /// </summary>
        public void Shutdown()
        {
            m_bKillThread = true;

            if (m_objMnulRstEvnt != null)
            {
                m_objMnulRstEvnt.Set();
                m_objMnulRstEvnt.Dispose();
                m_objMnulRstEvnt = null;
            }


            if (m_UDTDataManagerHelper != null)
            {
                m_UDTDataManagerHelper.Dispose();
                m_UDTDataManagerHelper = null;

            }
            

            if (m_objQueue != null)
            {
                m_objQueue.Clear();
                m_objQueue = null;
            }
            if (_dataset != null)
            {
                _dataset.Clear();
                _dataset = null;
            }
            CRemoteHelper.AppClosing();
        }
    }
    internal class LogWriter
    {
        internal static void WriteLog(Exception ex)
        {
            //Write Log here
        }
    }
}

