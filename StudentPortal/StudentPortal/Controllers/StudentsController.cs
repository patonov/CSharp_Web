using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StdentPortalDbContext dbContext;

        public StudentsController(StdentPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel addStudent)
        {
            var student = new Student
            {
                Name = addStudent.Name,
                Email = addStudent.Email,
                Phone = addStudent.Phone,
                Subscribed = addStudent.Subscribed,
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return View();
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
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student mockStudent)
        {
            var student = await dbContext.Students.FindAsync(mockStudent.Id);

            if (student is not null)
            { 
                student.Name = mockStudent.Name;
                student.Email = mockStudent.Email;
                student.Phone = mockStudent.Phone;
                student.Subscribed = mockStudent.Subscribed;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }
            
    }
}
