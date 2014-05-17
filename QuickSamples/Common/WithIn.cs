using NHibernate;
using QuickFramework.Ioc;
using QuickFramework.Repository;
using QuickSamples.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.Common
{
    public static class WithIn
    {
 

        public static void Change<T>(Action<QuickFramework.Repository.IRepository<T>> action) where T:QuickFramework.DomainBase.AggregateRoot
        {
            var repository= ObjectFactory.GetService<IRepository<T>>();
            action(repository);
            repository.Context.Commit();
            repository.Context.Dispose();
        }




        public static void UnitOfWork(ISessionFactory sessionfactory, Action<QuickFramework.NHibenateRepository.INHibernateUnitOfWork> unitofworkaction)
        {
            using (QuickFramework.NHibenateRepository.INHibernateUnitOfWork unitofwork = new QuickFramework.NHibenateRepository.Impl.NHibernateUnitOfWork(sessionfactory))
            {
                unitofworkaction(unitofwork);
                unitofwork.Commit();
            }
        }

        public static void GetQuery(ISessionFactory sessionfactory, Action<QuickFramework.NHibenateRepository.INHibernateUnitOfWork> unitofworkaction)
        {
            using (QuickFramework.NHibenateRepository.INHibernateUnitOfWork unitofwork = new QuickFramework.NHibenateRepository.Impl.NHibernateUnitOfWork(sessionfactory))
            {
                unitofworkaction(unitofwork);

            }
        }
    }
}
