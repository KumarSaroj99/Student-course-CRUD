using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCourceValidationFluent.Models
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        [Range(18, 30, ErrorMessage = "Age must be between 18 and 30.")]
        public virtual int Age { get; set; }

        public virtual Course Course { get; set; }  // One-to-One relationship
    }

}