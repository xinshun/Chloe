﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chloe.DbExpressions;
using Chloe.InternalExtensions;

namespace Chloe.PostgreSQL.MethodHandlers
{
    class NextValueForSequence_Handler : IMethodHandler
    {
        public bool CanProcess(DbMethodCallExpression exp)
        {
            if (exp.Method.DeclaringType != UtilConstants.TypeOfSql)
                return false;

            return true;
        }
        public void Process(DbMethodCallExpression exp, SqlGenerator generator)
        {
            string sequenceName = (string)exp.Arguments[0].Evaluate();
            generator.SqlBuilder.Append("nextval");
            generator.SqlBuilder.Append("(");
            generator.QuoteName(sequenceName);
            generator.SqlBuilder.Append(")");
        }
    }
}
