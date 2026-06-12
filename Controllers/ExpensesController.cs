using Microsoft.AspNetCore.Mvc;
using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private static List<Expense> expenses = new List<Expense>();

        [HttpGet]
        public ActionResult<List<Expense>> GetAll()
        {
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public ActionResult<Expense> GetById(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpPost]
        public ActionResult<Expense> Create(Expense expense)
        {
            expense.Id = expenses.Count + 1;
            expense.Date = DateTime.Now;
            expenses.Add(expense);
            return CreatedAtAction(nameof(GetAll), expense);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            expenses.Remove(expense);
            return NoContent();
        }
    }
}