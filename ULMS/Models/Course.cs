using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ULMS.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int MaxStudents { get; set; }
    }
}