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
    public class IndexModel : PageModel
    {
        private readonly TalTechUniversity.Data.TalTechUniversityContext _context;

        public IndexModel(TalTechUniversity.Data.TalTechUniversityContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
