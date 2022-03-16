using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace ORM.PerformanceTest.Setup
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                    _sessionFactory = Fluently.Configure()
                                        .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                                        .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static IStatelessSession OpenStatelessSession()
        {
            return SessionFactory.OpenStatelessSession();
        }
    }
}
