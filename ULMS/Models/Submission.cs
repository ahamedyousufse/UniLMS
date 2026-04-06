using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ULMS.Models
{
    public class Submission
    {
        public int SubmissionId { get; set; }
        public int AssignmentId { get; set; }
        public string StudentId { get; set; }
        public string FilePath { get; set; }
        public int Grade { get; set; }
        public string Feedback { get; set; }
    }
}