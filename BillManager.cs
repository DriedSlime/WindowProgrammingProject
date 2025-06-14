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
                Bills = new List<Bill>(); // 예외 발생 시 빈 리스트 생성
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
                             Name = item.Element("name")?.Value ?? "",
                             Cost = int.Parse(item.Element("cost")?.Value ?? "0"),
                             IsPaid = item.Element("isPaid")?.Value ?? "미지불",
                             DeadLine = DateTime.Parse(item.Element("DeadLine")?.Value ?? DateTime.Now.ToString()),
                             BankName = item.Element("bankName")?.Value ?? "",
                             AccountNumber = item.Element("accountNumber")?.Value ?? ""
                         }).ToList();
            }
            catch (FileNotFoundException)
            {
                Save();     // 파일 없으면 기본값 저장
            }
        }
        public static void Save()
        {
            var billsXElement = new XElement("bills",
                Bills.Select(bill => new XElement("bill",
                    new XElement("name", bill.Name),
                    new XElement("cost", bill.Cost),
                    new XElement("isPaid", bill.IsPaid),
                    new XElement("DeadLine", bill.DeadLine.ToString("yyyy-MM-dd")),
                    new XElement("bankName", bill.BankName),
                    new XElement("accountNumber", bill.AccountNumber)
                ))
            );

            File.WriteAllText(@"./Bills.xml", billsXElement.ToString());
        }
    }
}
