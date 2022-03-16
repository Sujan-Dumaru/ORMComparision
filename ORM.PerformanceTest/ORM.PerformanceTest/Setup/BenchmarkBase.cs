using System;
using System.Collections.Generic;
using System.Configuration;
using BenchmarkDotNet.Attributes;
using MySql.Data.MySqlClient;
using Dapper;
using ORM.PerformanceTest.Entity;

namespace ORM.PerformanceTest.Setup
{
    [RankColumn]
    //[MinIterationCount(10)]
    //[MaxIterationCount(20)]
    [MemoryDiagnoser]
    //[MinColumn, MaxColumn]
    public abstract class BenchmarkBase
    {
        protected MySqlConnection _connection;

        public static ConnectionStringSettings ConnectionStringSettings { get; } = ConfigurationManager.ConnectionStrings["ApplicationServices"];
        public static string ConnectionString { get; } = ConnectionStringSettings.ConnectionString;

        public List<ContractSupplementary> ContractSupplementaries;

        public List<ContractSupplementary> UpdateContractSupplementaries;

        protected void BaseSetup()
        {
            //SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);

            SqlMapper.AddTypeHandler(new MySqlGuidTypeHandler());

            InitializeData();

            _connection = new MySqlConnection(ConnectionString);
            _connection.Open();
        }

        private void InitializeData()
        {
            var contractGroupId = Guid.Parse("00015757-86aa-443e-b4ac-ab06009aa757");
            ContractSupplementaries = new List<ContractSupplementary>();

            for (int i = 0; i < 1; i++)
            {
                var contractSupplementary = new ContractSupplementary(contractGroupId, new DateTime(2022, 01, 01), new DateTime(2022, 01, 30),
                110001, "Energy", "Energy", 1, 1, 10, "c/kWh");
                ContractSupplementaries.Add(contractSupplementary);
            }
        }
    }
}
