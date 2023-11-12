using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversityy.Data;
using ContosoUniversityy.Model;
using ContosoUniversityy.Model.SchoolViewModel;

namespace ContosoUniversityy.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversityy.Data.SchoolContext _context;

        public CreateModel(ContosoUniversityy.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        [BindProperty]
        public StudentVM StudentVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }


        //[BindProperty]
        //public Student Student { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{

        //    var emptyStudent = new Student();

        //    if (await TryUpdateModelAsync<Student>(
        //        emptyStudent,
        //        "student",   // Prefix for form value.
        //        s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
        //    {
        //        _context.Students.Add(emptyStudent);
        //        await _context.SaveChangesAsync();
        //        return RedirectToPage("./Index");
        //    }

        //    return Page();

        ////    if (!ModelState.IsValid)
        ////    {
        ////        return Page();
        ////    }

        ////    _context.Students.Add(Student);
        ////    await _context.SaveChangesAsync();

        ////    return RedirectToPage("./Index");
        //}
    }
}
