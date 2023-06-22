using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace QuickSalesApp.Persistance.Utilities;

public static  class ExpressionParser
{
   
    public static Expression<Func<T, bool>> ParseExpression<T>(string expression)
    {
        var parameter = Expression.Parameter(typeof(T)); 
        var lambda = DynamicExpressionParser.ParseLambda(new[] { parameter }, typeof(bool), expression);
        return (Expression<Func<T, bool>>)lambda;
    }
}

