using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCoursesWebApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string NameOfCourse { get; set; }
        public string TrainingProgram { get; set; }
        public string Description { get; set; }
        public string IntensityOfClasses { get; set; }
        public int GroupSize { get; set; }
        public int FreePlaces { get; set; }
        public int NumberOfHours { get; set; }
        public decimal Cost { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public Teacher Teacher { get; set; }
    }
}
