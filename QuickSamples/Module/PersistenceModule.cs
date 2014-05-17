using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.Reflection;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg.Db;
namespace QuickSamples.Module
{
    public class PersistenceModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterInstance<ISessionFactory>(CreateSessionFactory()).SingleInstance();

            builder.Register(p => new QuickFramework.NHibenateRepository.Impl
               .NHibernateUnitOfWork(p.Resolve<ISessionFactory>()))
               .As<QuickFramework.UnitOfWork.IUnitOfWork>();

            builder.RegisterGeneric(typeof(QuickFramework.NHibenateRepository.NHibernateRepository<>))
                   .As(typeof(QuickFramework.Repository.IRepository<>));


            builder.RegisterGeneric(typeof(QuickFramework.Caching.MongoDBCacheRepository.MongoDBCacheRepository<,>))
                   .As(typeof(QuickFramework.Caching.ICacheRepository<,>))
                      .WithParameters(
                          new NamedParameter[]{
                          new NamedParameter("connectionstr","mongodb://localhost"),
                          new NamedParameter("databasename","Test"),
                          new NamedParameter("collectionname","UserDTO")
                              });
        }

        private ISessionFactory CreateSessionFactory(bool createdb=false)
        {

            
            Configuration cfg = Fluently.Configure()

                   .Database(MsSqlConfiguration.MsSql2008
                   .ShowSql().AdoNetBatchSize(60)
                   .UseOuterJoin()
                    .ConnectionString(p => p.Server("127.0.0.1")
                       .Database("user").Username("sa").Password("123456")
                   )).Mappings((map) =>
                   {
                       // map.FluentMappings.AddFromAssemblyOf<TestBase>().ExportTo("d:\\path");
                       map.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()).ExportTo("d:\\path"); ;
                       // map.AutoMappings.Add(mapModel).ExportTo("d:\\path");

                   }).ExposeConfiguration(BuildSchema).BuildConfiguration();

            cfg.AddProperties(new Dictionary<string, string>() { 
               { NHibernate.Cfg.Environment.CurrentSessionContextClass,typeof(NHibernate.Context.CallSessionContext ).AssemblyQualifiedName},
               { NHibernate.Cfg.Environment.GenerateStatistics,"true" },
                { NHibernate.Cfg.Environment.UseSecondLevelCache,"true" },
                { NHibernate.Cfg.Environment.UseQueryCache,"true" },
               {NHibernate.Cfg.Environment.CacheProvider,typeof(NHibernate.Cache.HashtableCacheProvider).AssemblyQualifiedName}

             });


            return cfg.BuildSessionFactory(); ;
        }



        private void BuildSchema(Configuration config)
        {
             
             new SchemaExport(config)
                .Create(true, false);
        }



    }
}
