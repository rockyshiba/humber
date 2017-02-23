using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeMidterm.Models
{
    public class ProgramFaculty
    {
        public Program program { get; set; }
        public List<Faculty> faculties { get; set; }
    }
}