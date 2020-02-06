using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TalTechUniversity.Data;
using TalTechUniversity.Models;
using TalTechUniversity.Pages.Courses;

namespace TalTechUniversity
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly TalTechUniversity.Data.TalTechUniversityContext _context;

        public CreateModel(TalTechUniversity.Data.TalTechUniversityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCourse = new Course();
            if (await TryUpdateModelAsync<Course>(emptyCourse,"course", s => s.CourseID, s => s.DepartmentID, s => s.Title, s => s.Credits))
            {
                _context.Courses.Add(emptyCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateDepartmentsDropDownList(_context, emptyCourse.DepartmentID);
            return Page();
        }
    }
}
