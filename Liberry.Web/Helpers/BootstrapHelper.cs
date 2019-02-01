using HtmlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

            var formGroup = HtmlTags.Div.Class("input-group");
            
            //var label = HtmlTags.Span.Class("input-group-addon").Append(metadata.DisplayName);
            var label = HtmlTags.Span.Class("input-group-addon").Append(HtmlTags.I.Class("glyphicon").Class("glyphicon-lock"));
            var input = HtmlTag.Parse(html.PasswordFor(expression)).Class("form-control");
            
            if (!html.ViewData.ModelState.IsValidField(metadata.PropertyName))
            {
                formGroup.Class("has-error");
            }
            
            return formGroup.Append(label).Append(input).ToHtml();
        }

        public static IHtmlString BSValidationMessageFor<TModel, TProp>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProp>> expression)
            => HtmlTag.Parse(html.ValidationMessageFor(expression)).Class("text-danger").ToHtml(TagRenderMode.Normal);
    }
}