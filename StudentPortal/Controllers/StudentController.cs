using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
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

            return RedirectToAction("Add"); // Or RedirectToAction("Index") if you have a list view
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
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

        [HttpPost]
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

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]
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
