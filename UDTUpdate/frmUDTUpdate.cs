using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Beesys.Wasp.Workflow;
using System.Configuration;
using System.IO;
using System.Collections;
using BeeSys.Wasp.Communicator;

namespace UDTUpdate
{
    public partial class frmUDTUpdate : Form
    {

        #region Class variables

        #region Constant variables

        const string m_sUrl = "net.tcp://{0}:{1}/TcpBinding/WcfTcpLink";

        #endregion

        private ShotBox m_objShotBox = null;
        private Link m_objLink = null;
        private LinkManager m_objLinkManager = null;
        private string m_sServerIp = string.Empty;
        //server ip used to connect shot box
        private string m_sShotBoxServerIp = string.Empty;
        private string kcurl;
        private string m_sLinkType = string.Empty;
        private string m_sPort = string.Empty;
        bool m_bIsPause = false;
        private FileInfo m_objFileInfo = null;
        private int m_appPort;
        private string m_appName = string.Empty;

      


     

        public frmUDTUpdate()
        {
            InitializeComponent();
           
        }

       
        #endregion


        /// <summary>
        /// fires when engine is connected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void objLink_OnEngineConnected(object sender, EngineArgs e)
        {
            btnConnect.BackColor = Color.DarkGreen;
        }

        /// <summary>
        /// used to connect with the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            IPlayoutServerX playoutServer = null;

            try
            {
                if (cmbxServers.SelectedItem != null && cmbxServers.SelectedItem is IPlayoutServerX)
                    playoutServer = cmbxServers.SelectedItem as IPlayoutServerX;

                if (playoutServer != null && (Equals(m_objShotBox, null)))
                {
                    m_sServerIp = ((IPlayoutServer)playoutServer).GetUrl(m_sLinkType.ToLower());
                    //Get server ip for shotbox
                    m_sShotBoxServerIp = playoutServer.GetPrepareUrl(m_sLinkType.ToLower());
                    if (string.IsNullOrEmpty(m_sServerIp))
                        m_sServerIp = playoutServer.GetPrepareUrl(m_sLinkType.ToLower());
                    //m_objLink.Connect(m_sServerIp, (playoutServer as CPlayoutServer).ChannelName);
                    m_objLink.Connect(m_sServerIp, (playoutServer as CPlayoutServer).ChannelName);
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("connecting", ex.Message);
            }
        }
        /// <summary>
        /// used for preparing the scenegraph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadScene_Click_1(object sender, EventArgs e)
        {
            string sXml = string.Empty;
            string sShotBoxID = null;
            bool isTicker;
            try
            {
                #region sceneone

                
                    sXml = Util.getSGFromWSL(txtSceneName.Text);
                    if (!string.IsNullOrEmpty(sXml))
                    {
                    if (m_objShotBox != null)
                        m_objShotBox.DeleteSg();
                        m_objShotBox = m_objLink.GetShotBox(sXml, out sShotBoxID, out isTicker) as ShotBox;
                        if (!Equals(m_objShotBox, null))
                        {
                            m_objShotBox.SetEngineUrl(m_sShotBoxServerIp);
                            if (m_objShotBox is IAddinInfo)
                            {
                                FileInfo fileinfo = new FileInfo(txtSceneName.Text);
                                // S.No.			: -	1
                                (m_objShotBox as IAddinInfo).Init(new InstanceInfo() { Type = "wspx", InstanceId = fileinfo.FullName, TemplateId = fileinfo.FullName, ThemeId = "default" });
                        
                            }
                            m_objShotBox.OnShotBoxStatus += new EventHandler<SHOTBOXARGS>(m_objShotBox_OnShotBoxStatus);
                            m_objShotBox.Prepare(m_sShotBoxServerIp, 0, RENDERMODE.PROGRAM);
                            m_objShotBox.SceneCue();

                        }
                    }
                
                #endregion


              
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("error in preparing the scenegraph", ex.Message);
            }

        }

        

        /// <summary>
        /// this event fires when scenegraph is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_objShotBox_OnShotBoxStatus(object sender, SHOTBOXARGS e)
        {
            if (Equals(e.SHOTBOXRESPONSE, SHOTBOXMSG.PREPARED))
            {
                btnPlay.BackColor = Color.DarkGreen;
                btnProgram.BackColor = Color.DarkGreen;
            }
        }
        /// <summary>
        /// used to selecting the scenegraph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        /// <summary>
        /// used to play the scenegraph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!Equals(m_objShotBox, null))
                {
                    btnPlay.BackColor = Color.DarkGray;
                    if (!m_bIsPause)
                    {
                        m_objShotBox.Play(true, true);
                    }
                    else
                        m_objShotBox.Play(false, false);
                    m_bIsPause = false;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("error in playing the scenegraph", ex.Message);
            }
        }
        /// <summary>
        /// used to pause the scenegraph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!Equals(m_objShotBox, null))
                {
                    btnPause.BackColor = Color.DarkGray;
                    m_objShotBox.Pause();
                    m_bIsPause = true;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("error in pausing the scenegraph", ex.Message);
            }
        }
        /// <summary>
        /// used to stop the scenegraph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!Equals(m_objShotBox, null))
                {
                    btnStop.BackColor = Color.DarkGray;
                    m_objShotBox.Stop();
                    m_bIsPause = false;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("error in stoping the scenegraph", ex.Message);
            }

        }
        /// <summary>
        /// used to taking the scenegraph on air
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnAir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!Equals(m_objShotBox, null))
                {
                    m_objShotBox.SetRender(true);
                    btnOnAir.BackColor = Color.DarkGray;
                    btnOffAir.BackColor = Color.DarkGreen;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("error in taking the scenegraph on air", ex.Message);
            }
        }
        /// <summary>
        /// used to taking the scenegraph off air
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOffAir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!Equals(m_objShotBox, null))
                {
                    m_objShotBox.SetRender(false);
                    btnOnAir.BackColor = Color.DarkGreen;
                    btnOffAir.BackColor = Color.DarkGray;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("error in taking the scenegraph off air", ex.Message);
            }

        }

        /// <summary>
        /// used to setting the mode as program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnProgram_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!Equals(m_objShotBox, null))
                {
                    m_objShotBox.SetMode(RENDERMODE.PROGRAM);
                    btnProgram.BackColor = Color.DarkGray;
                    btnPreview.BackColor = Color.DarkGreen;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("error in setting the mode:program", ex.Message);
            }
        }
        /// <summary>
        /// used to setting the mode as preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!Equals(m_objShotBox, null))
                {
                    m_objShotBox.SetMode(RENDERMODE.PREVIEW);
                    btnPreview.BackColor = Color.DarkGray;
                    btnProgram.BackColor = Color.DarkGreen;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("error in setting the mode:preview", ex.Message);
            }
        }
        /// <summary>
        /// used to update the scenegraph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        /// <summary>
        /// used to getting the link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUDTUpdate_Load(object sender, EventArgs e)
        {
            string sLinkID = string.Empty;
            try
            {
                m_sPort = ConfigurationManager.AppSettings["port"].ToString();
                m_sLinkType = ConfigurationManager.AppSettings["linktype"].ToString();
                kcurl = ConfigurationManager.AppSettings["REMOTEMANAGERURL"].ToString();
                m_appName = ConfigurationManager.AppSettings["appName"].ToString();
                m_appPort = Convert.ToInt32(ConfigurationManager.AppSettings["appPort"]);

                BeeSys.Wasp.Communicator.CRemoteHelper cRemoteHelper = new BeeSys.Wasp.Communicator.CRemoteHelper(kcurl, m_appName, m_appPort);
                cRemoteHelper.InitRemoteHelper();

                ctrlUdtUpdate.LoadUDT();

                m_objLinkManager = new LinkManager(kcurl);
                if (!Equals(m_objLinkManager, null))
                {
                    if (string.Compare(m_sLinkType, "TCP", StringComparison.OrdinalIgnoreCase) == 0)
                        m_objLink = m_objLinkManager.GetLink(LINKTYPE.TCP, out sLinkID);
                    if (string.Compare(m_sLinkType, "NAMEDPIPE", StringComparison.OrdinalIgnoreCase) == 0)
                        m_objLink = m_objLinkManager.GetLink(LINKTYPE.NAMEDPIPE, out sLinkID);
                }
                if (!Equals(m_objLink, null))
                {
                    m_objLink.OnEngineConnected += new EventHandler<EngineArgs>(objLink_OnEngineConnected);
                }
                this.FormClosing += new FormClosingEventHandler(frmUDTUpdate_FormClosing);
                Init();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("loading", ex.Message);
            }
        }
        private void Init()
        {
            try
            {
                RefreshServersList();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex);
            }
        }
        void frmUDTUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (!Equals(m_objShotBox, null))
                {
                    //Removing the loaded scene from server
                    m_objShotBox.DeleteSg();
                }
                if (!Equals(m_objLink, null))
                {
                    //Remove the old scenes which were in use a long time ago.                   
                    DeleteUnusedSG();

                    //Disconnect and Remove the communication channel with all Engines connected using this link.
                    m_objLink.DisconnectAll();
                }

                ctrlUdtUpdate.ShutDown();

                // Environment.Exit(0) use because Exe stuck in task manager on closing the app
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog("error in form closing", ex.Message);
            }
        }
        /// <summary>
        /// Remove the old scenes which were in use a long time ago.        
        /// </summary>
        private void DeleteUnusedSG()
        {
            try
            {
                //Generally removes scenes which are unused and were last in use 60 seconds ago.
                //This can be configured in ChannelInfo.xml.
                //<timer del_unused_duration = "60" />
                //present in \\WASP3D\Common\HostedAssemblies\LinkCommandManager
                m_objLink.RemoveUnusedSG(m_sServerIp);

            }
            catch(Exception ex)
            {
                LogWriter.WriteLog("error in DeleteUnusedSG", ex.Message);
            }
        }
        /// <summary>
        /// Refresh list of sting servers
        /// </summary>
        private void RefreshServersList()
        {
            try
            {
                //Gets the list of engines i.e, Sting servers available on KC
                List<CPlayoutServer> lstmodules = Util.GetActiveServers();

                cmbxServers.DataSource = null;
                cmbxServers.DataSource = lstmodules;
                cmbxServers.DisplayMember = "EngineName";
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex);
            }
            finally
            {

            }
        }

        private void ctrlUdtUpdate1_Load(object sender, EventArgs e)
        {

        }
    }
}
