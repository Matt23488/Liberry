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

        public static IHtmlString BSTextBoxFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, string>> expression)
        {
            var formGroup = HtmlTags.Div.Class("form-group").Append(
                                HtmlTags.Label.Class("col-sm-2").Class("control-label").Append(html.DisplayNameFor(expression).ToHtmlString())).Append(
                                HtmlTags.Div.Class("col-sm-10").Append(
                                    HtmlTag.Parse(html.TextBoxFor(expression).ToHtmlString()).Class("form-control")
                                )
                            );

            return formGroup.ToHtml();
        }

        public static MvcForm BSBeginHorizontalForm(this HtmlHelper html, string action = null, string controller = null, FormMethod method = FormMethod.Post)
            => html.BeginForm(action, controller, method, new { @class = "form-horizontal" });
    }
}