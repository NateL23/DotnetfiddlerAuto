namespace DNFAutoFramework.Helpers
{
    using ExcelDataReader;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;

    public class ExcelHelpers
    {
        private static readonly List<DataCollection> _dataCol = new List<DataCollection>();
        
        public static void PopulateInCollection(string fileName)
        // iterate through rows and columns of excel table and store in DataTable
        {
            DataTable table = ExcelToDataTable(fileName);

            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection dTable = new DataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    _dataCol.Add(dTable);
                }
            }
        }

        public static DataTable ExcelToDataTable(string filename)
        {
            // open file and return as Stream
            using(var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                using(var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    // get all tables
                    DataTableCollection table = result.Tables;
                    // store in DataTable
                    DataTable resultTable = table["Sheet1"];

                    return resultTable;
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                // retrieve data DataCollection using LINQ to reduce iteration counts
                string data = (from colData in _dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }

    public class DataCollection
    // get value by row number and column name
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}
