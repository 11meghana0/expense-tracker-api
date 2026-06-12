using Microsoft.AspNetCore.Mvc;
using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        // Temporary in-memory list to store expenses
        private static List<Expense> expenses = new List<Expense>();

        // GET: api/expenses
        [HttpGet]
        public ActionResult<List<Expense>> GetAll()
        {
            return Ok(expenses);
        }   

        // POST: api/expenses
        [HttpPost]
        public ActionResult<Expense> Create(Expense expense)
        {
            expense.Id = expenses.Count + 1;
            expense.Date = DateTime.Now;
            expenses.Add(expense);
            return CreatedAtAction(nameof(GetAll), expense);
        }
    }
}