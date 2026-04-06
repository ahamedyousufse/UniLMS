using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ULMS.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
    }
}