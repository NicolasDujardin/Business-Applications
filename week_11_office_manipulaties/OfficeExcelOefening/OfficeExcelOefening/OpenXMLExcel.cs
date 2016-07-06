using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXMLDemo
{
    public static class OpenXMLExcel
    {
        #region extention methods
        public static WorksheetPart XLPart(this Sheet wsheet, WorkbookPart wbPart)
        {
            return (WorksheetPart)(wbPart.GetPartById(wsheet.Id));
        }
        public static int XLSharedStringId(this Cell theCell)
        {
            string value = theCell.InnerText;
            if (theCell.DataType != null)
            {
                if (theCell.DataType.Value == CellValues.SharedString)
                {
                    int id = int.Parse(value);
                    return id;
                }
            }
            return -1;
        }
        #endregion


        #region GetAllSheets
        public static Sheets XLGetAllWorksheets(string fileName)  //inspired by: https://msdn.microsoft.com/EN-US/library/office/jj618414.aspx
        {
            Sheets theSheets = null;

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {
                theSheets = XLGetAllWorksheets(document);
            }
            return theSheets;
        }

        public static Sheets XLGetAllWorksheets(SpreadsheetDocument document)
        {
            return document?.WorkbookPart?.Workbook?.Sheets;
        }
        #endregion
        #region getSheet
        public static Sheet XLGetSheet(string fileName, string name)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {
                return XLGetSheet(document, name);
            }
        }
        public static Sheet XLGetSheet(SpreadsheetDocument document, string name)
        {
            Sheets sheets = document?.WorkbookPart?.Workbook?.Sheets;
            Sheet sh = sheets.Elements<Sheet>().Where(s => s.Name.Value.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return sh;
        }
        #endregion
        #region getcellvalues
        public static string XLGetCellValue(string fileName, string sheetName, string columnName, uint rowIndex)  //inspired by: https://msdn.microsoft.com/EN-US/library/office/hh298534.aspx
        {
            string value = null;
            // Open the spreadsheet document for read-only access.
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {

                value = XLGetCellValue(document, sheetName, columnName, rowIndex);
            }
            return value;
        }
        public static string XLGetCellValue(SpreadsheetDocument document, string sheetName, string columnName, uint rowIndex)
        {
            Cell cell = XLGetCell(document, sheetName, columnName, rowIndex);
            string value = null;
            if (cell != null) value = XLInterpretedCellValue(document, cell);
            return value;
        }
        public static Cell XLGetCell(SpreadsheetDocument document, string sheetName, string columnName, uint rowIndex)
        {
            Sheet theSheet = XLGetSheet(document, sheetName);
            // Throw an exception if there is no sheet.
            if (theSheet == null) throw new ArgumentException("sheetName");
            return XLGetCell(document, theSheet, columnName, rowIndex);
        }
        public static Cell XLGetCell(SpreadsheetDocument document, Sheet theSheet, string columnName, uint rowIndex)
        {
            WorkbookPart wbPart = document.WorkbookPart;
            // Retrieve a reference to the worksheet part.
            WorksheetPart wsPart = theSheet.XLPart(wbPart);

            // Use its Worksheet property to get a reference to the cell 
            // whose address matches the address you supplied.
            string addressName = columnName + rowIndex;
            Cell theCell = wsPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference == addressName).FirstOrDefault();
            return theCell;
        }
        public static string XLInterpretedCellValue(SpreadsheetDocument document, Cell theCell)
        {
            WorkbookPart wbPart = document.WorkbookPart;
            string value = theCell.InnerText;
            // If the cell represents an integer number, you are done. 
            // For dates, this code returns the serialized value that 
            // represents the date. The code handles strings and 
            // Booleans individually. For shared strings, the code 
            // looks up the corresponding value in the shared string 
            // table. For Booleans, the code converts the value into 
            // the words TRUE or FALSE.
            if (theCell.DataType != null)
            {
                switch (theCell.DataType.Value)
                {
                    case CellValues.SharedString:

                        // For shared strings, look up the value in the
                        // shared strings table.
                        var stringTable =
                            wbPart.GetPartsOfType<SharedStringTablePart>()
                            .FirstOrDefault();

                        // If the shared string table is missing, something 
                        // is wrong. Return the index that is in
                        // the cell. Otherwise, look up the correct text in 
                        // the table.
                        if (stringTable != null)
                        {
                            value =
                                stringTable.SharedStringTable
                                .ElementAt(int.Parse(value)).InnerText;
                        }
                        break;
                    case CellValues.Boolean:
                        switch (value)
                        {
                            case "0":
                                value = "FALSE";
                                break;
                            default:
                                value = "TRUE";
                                break;
                        }
                        break;
                }
            }
            return value;
        }
        #endregion

        #region delete text from cell
        // Given a document, a worksheet name, a column name, and a one-based row index,
        // deletes the text from the cell at the specified column and row on the specified worksheet.
        public static void XLDeleteTextFromCell(string docName, string sheetName, string colName, uint rowIndex)
        {
            // Open the document for editing.
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(docName, true))
            {
                XLDeleteTextFromCell(document, sheetName, colName, rowIndex);
            }
        }
        private static void XLDeleteTextFromCell(SpreadsheetDocument document, string sheetName, string colName, uint rowIndex)
        {
            Sheet sheet = OpenXMLExcel.XLGetSheet(document, sheetName);
            Cell cell = OpenXMLExcel.XLGetCell(document, sheet, colName, rowIndex);
            if (cell == null) return; //cell does not exist, can't be deleted

            cell.Remove();
            sheet.XLPart(document.WorkbookPart).Worksheet.Save();
            OpenXMLExcel.XLRemoveSharedStringItemIfNotReferenced(cell.XLSharedStringId(), document);
        }


        #region RemoveSharedStringItemIfNotReferenced
        // Given a shared string ID and a SpreadsheetDocument, verifies that other cells in the document no longer 
        // reference the specified SharedStringItem and removes the item.
        public static void XLRemoveSharedStringItemIfNotReferenced(int shareStringId, SpreadsheetDocument document)
        {
            if (shareStringId < 0) return;
            bool isStringReferenced = XLIsSharedStringReferenced(shareStringId, document);

            // Other cells in the document do not reference the item. Remove the item.
            if (!isStringReferenced) DeleteSharedStringById(shareStringId, document);

        }

        private static void DeleteSharedStringById(int shareStringId, SpreadsheetDocument document)
        {
            SharedStringTablePart shareStringTablePart = document.WorkbookPart.SharedStringTablePart;
            if (shareStringTablePart == null) return;
            SharedStringItem item = shareStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(shareStringId);
            if (null == item) return;
            item.Remove();

            // Refresh all the shared string references.
            foreach (var part in document.WorkbookPart.GetPartsOfType<WorksheetPart>())
            {
                Worksheet worksheet = part.Worksheet;
                foreach (var cell in worksheet.GetFirstChild<SheetData>().Descendants<Cell>())
                {
                    if (cell.DataType != null &&
                        cell.DataType.Value == CellValues.SharedString)
                    {
                        int itemIndex = int.Parse(cell.CellValue.Text);
                        if (itemIndex > shareStringId)
                        {
                            cell.CellValue.Text = (itemIndex - 1).ToString();
                        }
                    }
                }
                worksheet.Save();
            }

            document.WorkbookPart.SharedStringTablePart.SharedStringTable.Save();
        }

        private static bool XLIsSharedStringReferenced(int shareStringId, SpreadsheetDocument document)
        {
            foreach (var part in document.WorkbookPart.GetPartsOfType<WorksheetPart>())
            {
                Worksheet worksheet = part.Worksheet;
                foreach (var cell in worksheet.GetFirstChild<SheetData>().Descendants<Cell>())
                {
                    // Verify if other cells in the document reference the item.
                    if (cell.DataType != null &&
                        cell.DataType.Value == CellValues.SharedString &&
                        cell.CellValue.Text == shareStringId.ToString())
                    {
                        // Other cells in the document still reference the item. Do not remove the item.
                        return true;
                    }
                }
            }
            //if we reach this spot, then no cell in any worksheet uses this value
            return false;
        }
        #endregion
        #endregion

        #region put text in cell

        public static void XLInsertText(string docName, string sheetName, string columnName, uint rowIndex, string text)
        {
            // Open the document for editing.
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                // Insert the text into the SharedStringTablePart if needed
                int index = OpenXMLExcel.XLInsertSharedStringItem(text, spreadSheet);

                WorksheetPart worksheetPart = null;
                worksheetPart = GetOrInsertWorkSheetPart(sheetName, spreadSheet);

                // Insert cell A1 into the new worksheet.
                Cell cell = XLGetOrInsertCellInWorksheet(columnName, rowIndex, worksheetPart);

                // Set the value of cell A1.
                cell.CellValue = new CellValue(index.ToString());
                cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);

                // Save the new worksheet.
                worksheetPart.Worksheet.Save();
            }
        }

        private static WorksheetPart GetOrInsertWorkSheetPart(string sheetName, SpreadsheetDocument spreadSheet)
        {
            WorksheetPart worksheetPart;
            Sheet sh = OpenXMLExcel.XLGetSheet(spreadSheet, sheetName);
            if (null == sh)
            {
                // Insert a new worksheet.
                worksheetPart = XLInsertWorksheet(spreadSheet.WorkbookPart);
            }
            else
            {
                worksheetPart = (WorksheetPart)(spreadSheet.WorkbookPart.GetPartById(sh.Id));
            }

            return worksheetPart;
        }
        // Given a WorkbookPart, inserts a new worksheet.
        private static WorksheetPart XLInsertWorksheet(WorkbookPart workbookPart)
        {
            // Add a new worksheet part to the workbook.
            WorksheetPart newWorksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            newWorksheetPart.Worksheet = new Worksheet(new SheetData());
            newWorksheetPart.Worksheet.Save();

            Sheets sheets = workbookPart.Workbook.GetFirstChild<Sheets>();
            string relationshipId = workbookPart.GetIdOfPart(newWorksheetPart);

            // Get a unique ID for the new sheet.
            uint sheetId = 1;
            if (sheets.Elements<Sheet>().Count() > 0)
            {
                sheetId = sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
            }

            string sheetName = "Sheet" + sheetId;

            // Append the new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet() { Id = relationshipId, SheetId = sheetId, Name = sheetName };
            sheets.Append(sheet);
            workbookPart.Workbook.Save();

            return newWorksheetPart;
        }

        // Given a column name, a row index, and a WorksheetPart, inserts a cell into the worksheet. 
        // If the cell already exists, returns it. 
        private static Cell XLGetOrInsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                //new row
                row = new Row() { RowIndex = rowIndex };
                Row nextRow = null;
                foreach (Row r in sheetData.Elements<Row>())
                {
                    if (r.RowIndex > rowIndex)
                    {
                        nextRow = r;
                        break;
                    }
                }
                if (null == nextRow)
                    sheetData.Append(row);
                else
                    sheetData.InsertBefore<Row>(row, nextRow);
            }

            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                worksheet.Save();
                return newCell;
            }
        }
        #endregion

        // Given text and a SharedStringTablePart, creates a SharedStringItem with the specified text 
        // and inserts it into the SharedStringTablePart. If the item already exists, returns its index.
        public static int XLInsertSharedStringItem(string text, SpreadsheetDocument spreadSheet)
        {
            // Get the SharedStringTablePart. If it does not exist, create a new one.
            SharedStringTablePart shareStringPart;
            if (spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
            {
                shareStringPart = spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
            }
            else
            {
                shareStringPart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
            }
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }

    }
}
