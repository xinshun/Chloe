﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chloe.DbExpressions;

namespace Chloe.SqlServer.MethodHandlers
{
    class Trim_Handler : IMethodHandler
    {
        public bool CanProcess(DbMethodCallExpression exp)
        {
            if (exp.Method != UtilConstants.MethodInfo_String_Trim)
                return false;

            return true;
        }
        public void Process(DbMethodCallExpression exp, SqlGenerator generator)
        {
            generator.SqlBuilder.Append("RTRIM(LTRIM(");
            exp.Object.Accept(generator);
            generator.SqlBuilder.Append("))");
        }
    }
}
