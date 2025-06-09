using System.Xml.Linq;

namespace WindowProgrammingProject
{
    internal class BillManager
    {
        public static List<Bill> Bills = new List<Bill>();

        public static int Total = Bills.Sum(x => x.Cost);
        static BillManager()
        {
            Load();
        }

        public static void Load()
        {
            try
            {
                string booksOutput = File.ReadAllText(@"./Bills.xml");
                XElement billsXElement = XElement.Parse(booksOutput);
                Bills = (from item in billsXElement.Descendants("bill")
                         select new Bill()
                         {
                             Name = item.Element("name").Value,
                             Cost = int.Parse(item.Element("cost").Value),
                             IsPaid = item.Element("isPayed").Value == "0" ? false : true,
                             DeadLine = DateTime.Parse(item.Element("DeadLine").Value),
                         }).ToList<Bill>();

            }
            catch (FileNotFoundException exception)
            {
                Save();
            }
        }
        public static void Save()
        {
            string billsOutput = "";
            billsOutput += "<bills>\n";
            foreach (var item in Bills)
            {
                billsOutput += "<bill>\n";
                billsOutput += "  <name>" + item.Name + "</name>\n";
                billsOutput += "  <cost>" + item.Cost + "</cost>\n";
                billsOutput += "  <isPayed>" + (item.IsPaid ? 1 : 0) + "</isPayed>\n";
                billsOutput += "  <DeadLine>" + item.DeadLine.ToLongDateString() + "</DeadLine>\n";
                billsOutput += "  <total>" + item.Total + "</total>\n";
                billsOutput += "</bill>\n";
            }
            billsOutput += "</bills>";

            File.WriteAllText(@"./Bills.xml", billsOutput);
        }
    }
}
