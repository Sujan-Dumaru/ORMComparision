using BenchmarkDotNet.Attributes;
using Dapper;
using ORM.PerformanceTest.Entity;
using ORM.PerformanceTest.Setup;
using System;
using System.Collections.Generic;

namespace ORM.PerformanceTest.Benchmarks
{
    public class BenchmarkDapper: BenchmarkBase
    {
        [GlobalSetup]
        public void Setup()
        {
            BaseSetup();
        }

        [Benchmark(Description = "Insert")]
        //use stored procedure
        public void InsertAsync()
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    foreach (var contractSupplementary in ContractSupplementaries)
                    {
                        contractSupplementary.SetId();
                        _connection.ExecuteScalar<int>(GetContractSupplementaryInsertQuery(),
                                        contractSupplementary, transaction);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }

        private string GetContractSupplementaryInsertQuery()
        {
            string insertQuery = @"
                                    INSERT INTO ContractSupplementary
                                    (Id,
                                     ContractGroupId,
                                     StartDate,
                                     EndDate,
                                     ChargeNum,
                                     Section,
                                     ItemCode,
                                     IToU,
                                     Band,
                                     Price,
                                     Units)
                            VALUES  (@Id,
                                     @ContractGroupId,
                                     @StartDate,
                                     @EndDate,
                                     @ChargeNum,
                                     @Section,
                                     @ItemCode,
                                     @IToU,
                                     @Band,
                                     @Price,
                                     @Units);
                                SELECT LAST_INSERT_ID();";
            return insertQuery;
        }

        [Benchmark(Description = "GetAll")]
        public List<ContractSupplementary> GetAllContractSupplementary()
        {
            var query = @"
                    SELECT * FROM contractsupplementary;
                ";

            try
            {
                var result = _connection.Query<ContractSupplementary>(query);

                return result.AsList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Benchmark(Description = "GetByContractGroupId")]
        public List<ContractSupplementary> GetContractSupplementaryByContractGroupId()
        {
            var contractGroupId = "00015757-86aa-443e-b4ac-ab06009aa757";

            var query = @"
                    SELECT * FROM contractsupplementary WHERE ContractGroupId = @contractGroupId;
                ";

            try
            {
                var result = _connection.Query<ContractSupplementary>(query, new { ContractGroupId = contractGroupId });

                return result.AsList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("message : {0}", ex.Message);
                throw;
            }
        }

        //[Benchmark(Description = "UpdateContractSupplementary")]
        //public async Task UpdateContractSupplementary()
        //{
        //    using (var transaction = _connection.BeginTransaction())
        //    {
        //        try
        //        {

        //            await _connection.ExecuteScalarAsync<int>(GetContractUpdateQuery(),
        //                             ContractSupplementaries, transaction);

        //            transaction.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            transaction.Rollback();
        //            throw;
        //        }

        //    }
        //}

        private string GetContractUpdateQuery()
        {
            return @"
                    Update contractsupplementary
                    SET
                        ContractGroupId = @ContractGroupId,
                        StartDate = @StartDate,
                        EndDate = @EndDate,
                        EndDate = @EndDate,
                        ChargeNum = @ChargeNum,
                        Section = @Section,
                        ItemCode = @ItemCode,
                        IToU = @IToU,
                        Band = @Band,
                        Price = Price,
                        Units = Units
                    WHERE Id=@Id";
        }

        [Benchmark(Description = "DeleteByContractGroupId")]
        public int DeleteByContractGroupId()
        {
            var contractGroupId = "00015757-86aa-443e-b4ac-ab06009aa757";

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    var commandResult = _connection.Execute(@"DELETE FROM contractsupplementary where ContractGroupId=@ContractGroupId", new { ContractGroupId = contractGroupId }, transaction);
                    transaction.Commit();

                    return commandResult;
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
