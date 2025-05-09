using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Controllers
{
    [Route("Students")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Add");
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            var viewModel = new UpdateStudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                Subscribed = student.Subscribed
            };

            return View(viewModel);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(UpdateStudentViewModel viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if (student == null)
                return NotFound();

            student.Name = viewModel.Name;
            student.Email = viewModel.Email;
            student.Phone = viewModel.Phone;
            student.Subscribed = viewModel.Subscribed;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }
    }
}
