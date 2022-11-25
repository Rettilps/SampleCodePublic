
using SampleTask.API.Data;
using SampleTask.Data;
using SampleTask.Table;

namespace SampleTaskTest
{
    [TestClass]
    public class ConsoleTableTest
    {
        [TestMethod]
        public void ConsoleTable_AddData()
        {
            ConsoleTable cTable = new();

            var row = new Row() {Name = "TestRow", Days = new List<Day>() { new Day() { Weekday = 0, ProductIds = new List<Productid>() { new Productid() { ProductId = 1 } } } } };            
            cTable.AddRowList(new List<Row>() { row });

            var prod = new Products() { AllergenIds = new List<string>() { "1"}, Name = "Test",ProductId = 1, Price = new Price() { Betrag = 1.2} };
            var pDict = new Dictionary<string, Products>();
            pDict.Add("1", prod);
            cTable.AddProductsDict(pDict);

            var allerg = new Allergens() { Id = "1",Label = "TestLabel"};
            var aDict = new Dictionary<string, Allergens>();
            aDict.Add("1", allerg);
            cTable.AddAllergenesDict(aDict);

            var test = new List<string>();
            test.Add(@"|KW 44  |Montag   |Dienstag|Mittwoch|Donnerstag|Freitag|");
            test.Add(@"--------------------------------------------------------");
            test.Add(@"|TestRow|Test     |");
            test.Add(@"|       |TestLabel|");
            test.Add(@"|       |1,2 EUR  |");
            test.Add(@"--------------------------------------------------------");

            Assert.AreEqual(test[0], cTable.GetStringOutput()[0], "ConsoleTable not generated correctly");
            Assert.AreEqual(test[1], cTable.GetStringOutput()[1], "ConsoleTable not generated correctly");
            Assert.AreEqual(test[2], cTable.GetStringOutput()[2], "ConsoleTable not generated correctly");
            Assert.AreEqual(test[3], cTable.GetStringOutput()[3], "ConsoleTable not generated correctly");
            Assert.AreEqual(test[4], cTable.GetStringOutput()[4], "ConsoleTable not generated correctly");
            Assert.AreEqual(test[5], cTable.GetStringOutput()[5], "ConsoleTable not generated correctly");

        }
    }
}