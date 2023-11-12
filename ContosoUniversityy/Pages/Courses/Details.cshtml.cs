using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversityy.Data;
using ContosoUniversityy.Model;

namespace ContosoUniversityy.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoUniversityy.Data.SchoolContext _context;

        public DetailsModel(ContosoUniversityy.Data.SchoolContext context)
        {
            _context = context;
        }

      public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            Course = await _context.Course
         .AsNoTracking()
         .Include(c => c.Department)
         .FirstOrDefaultAsync(m => m.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }
            else 
            {
                Course = Course;
            }
            return Page();
        }
    }
}
