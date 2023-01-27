# UDT Sample App
### UDT Sample App is a winform application through which we can add, delete and upate data in UDT.


- First of all, you need to import udt (**SampleUDT.udt**) in UDT.
- SampleUDT contains two table -> Category Table and Data Table.Category Table and Data Table both has two field :
    - Text 
    - Details

## Category Table (Parent Table)

| Text | Details |
| ------ | ------ |
|  Sports     |   Sports  Details    |
|  Weather      |  Weather  Details    |


## Data Table (Child Table)

| Text | Details |
| ------ | ------ |
|  CWG winners: A host of unlikely Indian sports hero     |         |
|  Delhi to get moderate rainfall today   |       |

## Run SampleUDT app : 
- Run your SampleUDT app.
- Before add, delete and update, first you need to click **Connect with KC** button. So that you can fetch data from **Category table** as well as Data table.
- Select Category comboBox where you can select Category and after selecting category, Text name and Details will be display in Name textbox and detais textbox respectively.
- Using Add, delete and Update button, you can perform operation on parent Table.
- Similarly, open Data tab, here you can see **Data table** data which is associated with it's parent.
- in Data table, using Add,Delete and update button, you can perform operation on Data table.

## Code Description : 

  - Created a **UDTHandler** class which is responsible to add, delete and update operation in UDT.
  - **UDTHandler(string udt)** constructor takes one parameter which will be the name of UDT.
  - When you click **Connect with KC** button then we will pass UDT name or UDT Id to UDTHandler Constructor. So that it could fetch data from SampleUDT.

  ```
  if (_serviceUDTHandler == null)
    {
        _serviceUDTHandler = new UDTHandler(@".\SampleUDT");
          OR
         //_serviceUDTHandler = new UDTHandler("CC2E882C-B402-40FB-881A-CA251FE9CF01");

        _serviceUDTHandler.ConnectWithKC();
        _serviceUDTHandler.LoadData();
     }
```
- To Load data from UDT, call LoadData() method by which you can get the dataset by udt id or udt name.Dataset contains all information about parent table and child table.


- To add data in UDT, call method _Add()
  ```
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
    ```

- To Update data in UDt, call UpdateRow() method which will call _Update() method. It will update data row by taking actual table name .
  ```
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
    ```

- To Delete single Data from UDT, call _Delete() method.
  ```
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
    ```
- To Delete multiple rows from UDT
 ```private void _Delete(DataRow[] drRows)
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
```
- To get actual table name call GetActualTableName()



