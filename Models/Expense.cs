namespace OpenExpense.Models
{
    public class Expense
    {
        private static readonly decimal taxRate = new decimal(0.15);
        public string CostCentre 
        {
            get;
        }
        public string Vendor 
        {
            get;
        }

        public string Description 
        {
            get;
        }

        public string Date 
        {
            get;
        }

        public decimal Total {
            get;
        }

        public string PaymentMethod 
        {
            get;
        }

        //Make expense object immutable, so it's thread safe. 
        public Expense(string costCentre, string vendor, string description, string date, decimal total, string paymentMethod) 
        {
            this.CostCentre = string.IsNullOrEmpty(costCentre) ? "UNKNOWN" : costCentre;
            this.Vendor = vendor;
            this.Description = description;
            this.Date = date;
            this.Total = total;
            this.PaymentMethod = paymentMethod;
        }

        //GST and total excluding GST are calculated properties based on total.
        public decimal GST 
        {
            get 
            {
                return Total / (1 + taxRate) * taxRate;
            }
        }

        public decimal TotalExcludingGST {
            get {
                return Total - GST;
            }
        }
    }
}