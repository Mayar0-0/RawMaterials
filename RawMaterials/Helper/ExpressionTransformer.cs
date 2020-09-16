using System;
using System.Linq.Expressions;

namespace RawMaterials.Helper
{
    public class ExpressionTransformer<TFrom, TTo> where TTo : TFrom
    {
        public class Visitor : ExpressionVisitor
        {
            private ParameterExpression _parameter;

            public Visitor(ParameterExpression parameter)
            {
                _parameter = parameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _parameter;
            }
        }

        public static Expression<Func<TTo, bool>> Tranform(Expression<Func<TFrom, bool>> expression)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TTo));
            Expression body = new Visitor(parameter).Visit(expression.Body);
            return Expression.Lambda<Func<TTo, bool>>(body, parameter);
        }
    }
}
