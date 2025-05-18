using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using MVCPROJECT.Data;
using MVCPROJECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCPROJECT.Models.Process;
using MVCPROJECT.Models.Entities;

namespace MVCPROJECT.Controllers
{
    public class PersonController : Controller
    { 
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();
        public PersonController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Person = await _context.Person.ToListAsync();
            return View(Person);
        }
        public IActionResult Create()
        {
            return View();
        }
[HttpPost]
[ValidateAntiForgeryToken]

public async Task<IActionResult> Create([Bind("PersonId,FullName,Adress")] Person person)
{
    if (ModelState.IsValid)
    {
        _context.Add(person);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(person);
}
public async Task<IActionResult> Edit(string id)
{
    if (id == null || _context.Person == null)
    {
        return NotFound();
    }

    var person = await _context.Person.FindAsync(id);
    if (person == null)
    {
        return NotFound();
    }
    return View(person);
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(string id, [Bind("PersonId,Fullname,Address")]Person person)
{
    if (id != person.PersonId )
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(person);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonExists(person.PersonId))
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
    return View(person);
}

        private bool PersonExists(string id)
{
    return (_context.Person?.Any(e => e.PersonId == id)).GetValueOrDefault();
}
public async Task<IActionResult> Delete(string id)
{
    if (id == null || _context.Person == null)
    {
        return NotFound();
    }

    var person = await _context.Person
          .FirstOrDefaultAsync(x => x.PersonId == id);
    if (person == null)
    {
        return NotFound();
    }

    return View(person);
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
public async Task<IActionResult>Upload()
{
    return View();
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult>Upload(IFormFile file)
{
    if(file!=null)
    {
        string fileExtension = Path.GetExtension(file.FileName);
        if (fileExtension !=".xls" && fileExtension !=".xlsx")
        {
            ModelState.AddModelError("", "Please choose excel file to upload!");
        }
        else
        {
            var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var fileLocation = new FileInfo(filePath).ToString();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await stream.CopyToAsync(stream);
                var dt = _excelProcess.ExcelToDataTable(fileLocation);
                for (int i =0; i < dt.Rows.Count; i++)
                {
                    var ps = new Person();
                    ps.PersonId = dt.Rows[i][0].ToString();
                    ps.FullName = dt.Rows[i][1].ToString();
                    ps.Address = dt.Rows[i][2].ToString();

                    _context.Add(ps);                    
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }
    return View();
}
    }
}
