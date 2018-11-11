using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenExpense.Models;
using Microsoft.AspNetCore.Mvc;
using OpenExpense.Services;

namespace OpenExpense.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        // POST api/expense
        [HttpPost]
        public ExpenseMessage Post([FromForm] string expenseText)
        {
            ExpenseMessage expenseMessage = new ExpenseMessage();
            Expense expense = null;
            try 
            {
                expense = ExpenseService.Extract(expenseText);
                expenseMessage.Success = true;
            } 
            catch (Exception e) 
            {
                expenseMessage.ErrorMessage = e.Message;
                expenseMessage.Success = false;
            }
            expenseMessage.Expense = expense;
            return expenseMessage;
        }
    }
}
