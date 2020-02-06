using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TalTechUniversity.Data;
using TalTechUniversity.Models;

namespace TalTechUniversity
{
    public class DetailsModel : PageModel
    {
        private readonly TalTechUniversity.Data.TalTechUniversityContext _context;

        public DetailsModel(TalTechUniversity.Data.TalTechUniversityContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses.AsNoTracking().Include(c => c.Department).FirstOrDefaultAsync(m => m.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
