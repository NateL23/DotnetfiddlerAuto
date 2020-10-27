namespace DNFAutoFramework.Helpers
{
    using Excel;
    using System.Data;
    using System.IO;

    public class ExcelHelpers
    {
        public static DataTable ExcelToDataTable(string filename)
        {
            // open file and return as Stream
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            // createopenxmlreader via ExcelReader 
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            // set the first row as column name
            excelReader.IsFirstRowAsColumnNames = true;
            // return as DataSet
            DataSet result = excelReader.AsDataSet();
            // get all tables
            DataTableCollection table = result.Tables;
            // store in DataTable
            DataTable resultTable = table["Sheet1"];

            return resultTable;
        }
    }
}
