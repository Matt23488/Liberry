using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Liberry.Web.Helpers
{
    public static class BootstrapHelper
    {
        public static IHtmlString BSPasswordFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, string>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var password = metadata.Model as string;

            var label = new TagBuilder("label");
            label.Attributes["for"] = html.IdFor(expression).ToHtmlString();
            label.SetInnerText(html.DisplayNameFor(expression).ToHtmlString());

            var input = new TagBuilder("input");
            input.Attributes["type"] = "password";
            input.Attributes["id"] = html.IdFor(expression).ToHtmlString();
            input.Attributes["name"] = html.NameFor(expression).ToHtmlString();
            input.AddCssClass("form-control");

            var container = GetFormGroup();
            container.InnerHtml = label.ToString() + input.ToString();

            return MvcHtmlString.Create(container.ToString());
        }

        private static TagBuilder GetFormGroup()
        {
            var tag = new TagBuilder("div");
            tag.AddCssClass("form-group");
            return tag;
        }
    }
}