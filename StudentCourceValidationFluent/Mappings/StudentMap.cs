using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCourceValidationFluent.Mappings
{
    using System.Net;
    using FluentNHibernate.Mapping;
    using StudentCourceValidationFluent.Models;

    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Age);
            HasOne(u => u.Course).Cascade.All().PropertyRef(u => u.Student).Constrained();  // Specify reverse relationship
        }
        
    }

}