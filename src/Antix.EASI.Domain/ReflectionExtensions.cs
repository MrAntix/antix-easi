using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Antix.EASI.Domain
{
    public static class ReflectionExtensions
    {
        public static TChild Get<TParent, TChild>(
            this Expression<Func<TParent, TChild>> exp,
            TParent parent)
        {
            return exp.Compile()(parent);
        }

        public static void Set<TParent, TChild>(
            this Expression<Func<TParent, TChild>> exp,
            TParent parent, TChild child)
        {
            var memberExp = (MemberExpression) exp.Body;
            var propertyInfo = (PropertyInfo) memberExp.Member;

            propertyInfo.SetValue(parent, child);
        }
    }
}