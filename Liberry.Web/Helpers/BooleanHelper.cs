using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Liberry.Web.Helpers
{
    public static class BooleanHelper
    {
        public static IHtmlString YesNoFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var value = (bool)metadata.Model;

            return MvcHtmlString.Create(value ? "Yes" : "No");
        }
    }
}