using Microsoft.AspNetCore.Mvc;
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
    }
}
