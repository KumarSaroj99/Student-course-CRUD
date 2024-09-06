using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCourceValidationFluent.Mappings
{
    using FluentNHibernate.Mapping;
    using StudentCourceValidationFluent.Models;

    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Courses");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Duration).Not.Nullable();
            References(a => a.Student).Column("student_id").Unique().Cascade.None();  // Foreign key to Student
        }
    }

}