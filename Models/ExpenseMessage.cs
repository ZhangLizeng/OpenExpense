namespace OpenExpense.Models 
{
    public class ExpenseMessage 
    {
        public bool Success {get; set;}

        public Expense Expense {get; set;}

        public string ErrorMessage {get; set;}
    }
}