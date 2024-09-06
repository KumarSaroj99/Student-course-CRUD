﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using StudentCourceValidationFluent.Mappings;
using NHibernate.Tool.hbm2ddl;

namespace StudentCourceValidationFluent.Data
{
    public class NHibernateHelper
    {
        public static ISessionFactory _sessionFactory = null;

        public static ISession CreateSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentCourseDB;Integrated Security=True;Connect Timeout=30;Encrypt=False"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMap>())
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                    .BuildSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }
    }
}