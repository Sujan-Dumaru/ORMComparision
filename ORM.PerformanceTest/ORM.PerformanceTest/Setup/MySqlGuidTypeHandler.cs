﻿using Dapper;
using System;
using System.Data;

namespace ORM.PerformanceTest.Setup
{
    public class MySqlGuidTypeHandler : SqlMapper.TypeHandler<Guid>
    {
        public override void SetValue(IDbDataParameter parameter, Guid guid)
        {
            parameter.Value = guid.ToString();
        }

        public override Guid Parse(object value)
        {
            return new Guid((string)value);
        }
    }
}
