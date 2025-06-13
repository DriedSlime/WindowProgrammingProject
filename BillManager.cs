using System.Xml.Linq;

namespace WindowProgrammingProject
{
    public class BillManager
    {
        public static List<Bill> Bills = new List<Bill>();
        
        static BillManager()
        {
            try
            {
                Load();
            }
            catch (Exception ex)
            {
                Bills = new List<Bill>(); // 예외 발생 시 빈 리스트로 대체
            }
        }

        public static void Load()
        {
            try
            {
                string billsOutput = File.ReadAllText(@"./Bills.xml");
                XElement billsXElement = XElement.Parse(billsOutput);
                Bills = (from item in billsXElement.Descendants("bill")
                         select new Bill()
                         {
                             Name = item.Element("name").Value,
                             Cost = int.Parse(item.Element("cost").Value),
                             IsPaid = item.Element("isPaid").Value,
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
                billsOutput += "  <isPaid>" + item.IsPaid + "</isPaid>\n";
                billsOutput += "  <DeadLine>" + item.DeadLine.ToLongDateString() + "</DeadLine>\n";
                billsOutput += "</bill>\n";
            }
            billsOutput += "</bills>";

            File.WriteAllText(@"./Bills.xml", billsOutput);
        }
    }
}
