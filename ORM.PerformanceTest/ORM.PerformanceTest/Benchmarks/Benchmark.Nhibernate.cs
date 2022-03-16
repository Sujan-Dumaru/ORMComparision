using BenchmarkDotNet.Attributes;
using Dapper;
using NHibernate;
using NHibernate.Linq;
using ORM.PerformanceTest.Entity;
using ORM.PerformanceTest.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ORM.PerformanceTest.Benchmarks
{
    public class BenchmarkNhibernate : BenchmarkBase
    {
        private IStatelessSession _statelessSession;

        [GlobalSetup]
        public void Setup()
        {
            BaseSetup();

            _statelessSession = NHibernateHelper.OpenStatelessSession();

        }

        [Benchmark(Description = "InsertNhibernate")]
        public Task InsertContractSupplementary()
        {
            using (var transaction = _statelessSession.BeginTransaction())
            {
                foreach (var contractSupplementary in ContractSupplementaries)
                {

                    _statelessSession.Insert(contractSupplementary);
                }

                transaction.Commit();
            }
            return Task.CompletedTask;
        }

        [Benchmark(Description = "GetAll")]
        public Task<List<ContractSupplementary>> GetAllContractSupplementary()
        {
            var query = _statelessSession.Query<ContractSupplementary>();

            return query.ToListAsync();
        }

        [Benchmark(Description = "GetByContractGroupId")]
        public Task<List<ContractSupplementary>> GetContractSupplementaryByContractGroupId()
        {
            var contractGroupId = Guid.Parse("00015757-86aa-443e-b4ac-ab06009aa757");

            var query = _statelessSession.Query<ContractSupplementary>().Where(cs => cs.ContractGroupId == contractGroupId);

            return query.ToListAsync();
        }

        //[Benchmark(Description = "UpdateContractSupplementary")]
        //public void UpdateContractSupplementary()
        //{
        //    _statelessSession.Update(ContractSupplementaries);
        //}

        [Benchmark(Description = "DeleteByContractGroupId")]
        public Task<int> DeleteByContractGroupId()
        {
            using (var transaction = _statelessSession.BeginTransaction())
            {
                try
                {
                    var contractGroupId = Guid.Parse("00015757-86aa-443e-b4ac-ab06009aa757");

                    var result = _statelessSession.Query<ContractSupplementary>().Where(c => c.ContractGroupId == contractGroupId).DeleteAsync(CancellationToken.None);
                    transaction.Commit();

                    return result;

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }                
            }               
        }
    }
}
