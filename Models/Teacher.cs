using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageCoursesWebApp.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string MiddleName { get; set; }
        public string CoursesName {get;set;}
    }
}