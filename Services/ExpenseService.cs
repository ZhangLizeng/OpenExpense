using OpenExpense.Models;
using OpenExpense.Exceptions;

namespace OpenExpense.Services 
{
    public class ExpenseService 
    {
        public static Expense Extract(string expenseText) 
        {
            string vendor = readTagInfo(expenseText, "vendor");
            string description = readTagInfo(expenseText, "description");
            string costCentre = readTagInfo(expenseText, "cost_centre");
            string date = readTagInfo(expenseText, "date");
            string totalString = readTagInfo(expenseText, "total");
            decimal total = decimal.Parse(totalString);
            string paymentMethod = readTagInfo(expenseText, "payment_method");
            
            return new Expense(costCentre, vendor, description, date, total, paymentMethod);
        }

        private static string readTagInfo(string input, string tag) {
            string openTag = "<" + tag + ">";
            string closeTag = "</" + tag + ">";

            int openTagIdx = input.IndexOf(openTag);
            int closeTagIdx = input.IndexOf(closeTag);

            if (openTagIdx == -1 && tag == "total")
            {
                throw new MissingTotalTagException();
            }

            if (openTagIdx == -1) {
                return string.Empty;
            }

            if (closeTagIdx < openTagIdx) 
            { 
                throw new TagNotClosingException(tag);
            }

            return input.Substring(openTagIdx + openTag.Length, closeTagIdx - openTagIdx - openTag.Length);
        }
    }
}