using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using System;

namespace ExpCore.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class QueryStringConstraintAttribute : ActionMethodSelectorAttribute
    {
        private string _valueName;
        private bool _valuePresent;
        public QueryStringConstraintAttribute(string valueName, bool valuePresent)
        {
            this._valueName = valueName;
            this._valuePresent = valuePresent;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var value = routeContext.HttpContext.Request.Query[this._valueName];
            if (this._valuePresent)
            {
                return !StringValues.IsNullOrEmpty(value);
            }

            return StringValues.IsNullOrEmpty(value);
        }
    }
}
