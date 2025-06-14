using System;

namespace PublicBillManager
{
    public class Bill
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string IsPaid { get; set; }
        public DateTime DeadLine { get; set; }
        public string BankName { get; set; }      
        public string AccountNumber { get; set; }

        public string Bank => $"{BankName}: {AccountNumber}";
    }
}

