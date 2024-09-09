using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCourceValidationFluent.Mappings
{
    using System.Net;
    using FluentNHibernate.Mapping;
    using StudentCourceValidationFluent.Models;

    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Courses");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Duration);
            References(a => a.Student).Column("student_id").Unique().Cascade.None();  // Foreign key to Student
        }
    }
    

}