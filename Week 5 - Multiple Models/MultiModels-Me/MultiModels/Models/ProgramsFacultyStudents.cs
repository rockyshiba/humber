using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiModels.Models
{
    public class ProgramsFacultyStudents
    {
        public List<Program> programs { get; set; }
        public List<Faculty> faculty { get; set; }
        public List<Student> students { get; set; }
    }
}