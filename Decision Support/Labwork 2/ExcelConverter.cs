// Importing necessary libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

// Creating a namespace
namespace ExcelConverter
{
    // Defining an internal class
    internal class ExcelConverter
    {
        // Defining a public method that takes in a DataGridView and a file path and converts the data to an Excel file
        public void ConvertToExcel(DataGridView dataGrid, string filePath)
        {
            // Creating a new SpreadsheetDocument with the given file path and type
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook);
            // Adding a new WorkbookPart to the document
            WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
            // Adding a new WorksheetPart to the workbook
            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

            // Creating a new Workbook and setting the file version to "Microsoft Office Excel"
            Workbook workbook = new Workbook();
            FileVersion fileVersion = new FileVersion();
            fileVersion.ApplicationName = "Microsoft Office Excel";
            // Setting the worksheet to a new Worksheet with no data
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            // Getting the number of rows and columns in the DataGridView
            int rowCount = dataGrid.Rows.Count;
            int columnCount = dataGrid.Columns.Count;

            // Creating a new 2D string array to hold the data from the DataGridView
            string[,] data = new string[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    // Populating the data array with the values from the DataGridView
                    data[i, j] = dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }

            // Getting the SheetData of the worksheet
            SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
            for (int i = 0; i < rowCount; i++)
            {
                // Creating a new Row for each row in the data array
                Row row = new Row();
                for (int j = 0; j < columnCount; j++)
                {
                    // Creating a new Cell for each column in the data array
                    Cell cell = new Cell();
                    // Setting the data type of the cell to "String"
                    cell.DataType = CellValues.String;
                    // Setting the value of the cell to the corresponding value in the data array
                    cell.CellValue = new CellValue(data[i, j]);
                    // Appending the cell to the row
                    row.Append(cell);
                }
                // Appending the row to the SheetData
                sheetData.Append(row);
            }

            // Appending the file version and a new Sheet to the Workbook
            workbook.Append(fileVersion);
            workbook.Append(new Sheets(new Sheet() { Name = "Sheet1", SheetId = 1, Id = workbookPart.GetIdOfPart(worksheetPart) }));
            // Setting the Workbook of the WorkbookPart to the new Workbook
            spreadsheetDocument.WorkbookPart.Workbook = workbook;
            // Saving the Workbook and closing the SpreadsheetDocument
            spreadsheetDocument.WorkbookPart.Workbook.Save();
            spreadsheetDocument.Close();
        }
    }
}
