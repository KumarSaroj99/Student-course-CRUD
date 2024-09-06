using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCourceValidationFluent.Models
{
    public class Course
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        [Range(1, 5, ErrorMessage = "Duration should be between 1 and 5 years.")]
        public virtual int Duration { get; set; }

        public virtual Student Student { get; set; }  // One-to-One relationship
    }

}