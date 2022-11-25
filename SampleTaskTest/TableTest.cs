
using SampleTask.API.Data;
using SampleTask.Data;
using SampleTask.Table;

namespace SampleTaskTest
{
    [TestClass]
    public class TableTest
    {
        [TestMethod]
        public void ConsoleTable_AddData()
        {

            TableCell cell1 = new TableCell();
            cell1.Cotent = new List<string>() { "Test1.1", "Test1.2" };
            TableCell cell2 = new TableCell();
            cell2.Cotent = new List<string>() { "Test2.1", "Test2.2" };

            TableRow row1 = new TableRow();
            row1.Cells.Add(cell1);
            TableRow row2 = new TableRow();
            row2.Cells.Add(cell2);

            Table table = new();
            table.Rows.Add(row1);
            table.Rows.Add(row2);

            Assert.AreEqual(2, table.Rows.Count, "Table Rows not generated correctly");
            Assert.AreEqual(1, table.Rows[0].Cells.Count, "Table Cells not generated correctly");
            Assert.AreEqual(1, table.Rows[1].Cells.Count, "Table Cells not generated correctly");
            Assert.AreEqual("Test1.1", table.Rows[0].Cells[0].Cotent[0], "Table Cells Content not generated correctly");
            Assert.AreEqual("Test1.2", table.Rows[0].Cells[0].Cotent[1], "Table Cells Content not generated correctly");
            Assert.AreEqual("Test2.1", table.Rows[1].Cells[0].Cotent[0], "Table Cells Content not generated correctly");
            Assert.AreEqual("Test2.2", table.Rows[1].Cells[0].Cotent[1], "Table Cells Content not generated correctly");

            Assert.AreEqual(1, table.CellsPerRow, "Cells per row not counting correctly");
            Assert.AreEqual("Test1.1".Length, table.GetColumnWidth(0), "ColumnWidth not correct");


        }
    }
}