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

namespace LR_2
{
	internal class ZaPiska
	{
		public void SaveToExcel(DataGridView dataGridView, string filePath)
		{
			// Создаем новый документ Excel
			SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook);

			// Добавляем лист в документ
			WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
			WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
			Workbook workbook = new Workbook();
			FileVersion fileVersion = new FileVersion();
			fileVersion.ApplicationName = "Microsoft Office Excel";
			worksheetPart.Worksheet = new Worksheet(new SheetData());

			// Получаем данные из DataGridView
			int rowCount = dataGridView.Rows.Count;
			int columnCount = dataGridView.Columns.Count;
			string[,] data = new string[rowCount, columnCount];
			for (int i = 0; i < rowCount; i++)
			{
				for (int j = 0; j < columnCount; j++)
				{
					data[i, j] = dataGridView.Rows[i].Cells[j].Value.ToString();
				}
			}

			// Заполняем лист данными
			SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
			for (int i = 0; i < rowCount; i++)
			{
				Row row = new Row();
				for (int j = 0; j < columnCount; j++)
				{
					Cell cell = new Cell();
					cell.DataType = CellValues.String;
					cell.CellValue = new CellValue(data[i, j]);
					row.AppendChild(cell);
				}
				sheetData.AppendChild(row);
			}

			// Сохраняем документ
			workbook.Append(fileVersion);
			workbook.Append(new Sheets(new Sheet() { Name = "Sheet1", SheetId = 1, Id = workbookPart.GetIdOfPart(worksheetPart) }));
			spreadsheetDocument.WorkbookPart.Workbook = workbook;
			spreadsheetDocument.WorkbookPart.Workbook.Save();
			spreadsheetDocument.Close();
		}

		internal void SaveToExcel(DataGridView dataGridView, DataGridView dataGridView1, string v)
		{
			throw new NotImplementedException();
		}
	}
}
