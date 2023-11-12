using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversityy.Data;
using ContosoUniversityy.Model;
using ContosoUniversityy.Model.SchoolViewModels;

namespace ContosoUniversityy.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversityy.Data.SchoolContext _context;

        public IndexModel(ContosoUniversityy.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseViewModel> CourseVM { get; set; }

        public async Task OnGetAsync()
        {
            CourseVM = await _context.Course
            .Select(p => new CourseViewModel
            {
                CourseID = p.CourseID,
                Title = p.Title,
                Credits = p.Credits,
                DepartmentName = p.Department.Name
            }).ToListAsync();
        }

        //public IList<Course> Course { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    if (_context.Course != null)
        //    {
        //        Course = await _context.Course
        //        .Include(c => c.Department)
        //        .AsNoTracking()
        //        .ToListAsync();
        //    }
        //}
    }
}
