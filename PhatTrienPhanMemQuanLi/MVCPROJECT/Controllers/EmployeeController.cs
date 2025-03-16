using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPROJECT.Data;
using MVCPROJECT.Models;
using System.Text.Encodings.Web;
namespace MVCPROJECT.Controllers
{
 public class EmployeeController : Controller
    { 
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Employee = await _context.Employee.ToListAsync();
            return View(Employee);
        }
        public IActionResult Create()
        {
            return View();
        }
[HttpPost]
[ValidateAntiForgeryToken]

public async Task<IActionResult> Create([Bind("PersonId,FullName,Adress")] Employee employee)
{
    if (ModelState.IsValid)
    {
        _context.Add(employee);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(employee);
}
public async Task<IActionResult> Edit(string id)
{
    if (id == null || _context.Employee == null)
    {
        return NotFound();
    }

    var employee = await _context.Employee.FindAsync(id);
    if (employee == null)
    {
        return NotFound();
    }
    return View(employee);
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(string id, [Bind("EmployeeId,Fullname,Address,Age")]Employee employee)
{
    if (id != employee.EmployeeId )
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonExists(employee.EmployeeId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }
    return View(employee);
}

        private bool EmployeeEmployeeExists(string id)
{
    return (_context.Employee?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
}
public async Task<IActionResult> Delete(string id)
{
    if (id == null || _context.Employee == null)
    {
        return NotFound();
    }

    var Employee = await _context.Employee
          .FirstOrDefaultAsync(x => x.EmployeeId == id);
    if (Employee == null)
    {
        return NotFound();
    }

    return View(employee);
    }
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]

public async Task<IActionResult> DeleteConfirmed(string id)
{
    if (_context.Person == null)
    {
        return Problem("Entity set 'ApplicationDbContext.Person' is null.");
    }
    var person = await _context.Person.FindAsync(id);
    if (person  != null)
    {
        _context.Person.Remove(person);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

    }

}