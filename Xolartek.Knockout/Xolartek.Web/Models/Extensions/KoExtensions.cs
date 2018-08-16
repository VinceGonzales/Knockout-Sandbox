using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Xolartek.Web.Extensions
{
    /// <summary>
    /// Knockout extensions which internally use their respective HtmlHelper equivalents.
    /// An optional dataBindAttributes parameter can be used for custom Knockout bindings.
    /// By default, the value/checked binding is applied.
    /// This can be turned off by setting addDefaultBinding to false (e.g. when using Knockout custom binding handlers).
    /// Allows for easy integration between Knockout and jQuery validation through property data annotations.
    /// https://www.rightpoint.com/thought/2015/01/05/htmlhelper-extensions-to-knockout-web-applications
    /// </summary>
    public static class KoExtensions
    {
        #region KoCheckBoxFor
        /// <summary>
        /// Knockout CheckBoxFor.
        /// </summary>
        public static MvcHtmlString KoCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes = null, object dataBindAttributes = null, bool addDefaultBinding = true)
        {
            return htmlHelper.KoCheckBoxFor(expression,
                htmlAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                dataBindAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(dataBindAttributes),
                addDefaultBinding);
        }

        /// <summary>
        /// Knockout CheckBoxFor internal.
        /// </summary>
        private static MvcHtmlString KoCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes, IDictionary<string, object> dataBindAttributes, bool addDefaultBinding)
        {
            var propName = htmlHelper.NameFor(expression);
            htmlAttributes.AddDataBindAttributeFor(ControlType.CheckBox, propName, dataBindAttributes, addDefaultBinding);
            return htmlHelper.CheckBoxFor(expression, htmlAttributes);
        }
        #endregion

        #region KoDropDownFor
        /// <summary>
        /// Knockout DropDownListFor.
        /// </summary>
        public static MvcHtmlString KoDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, Object htmlAttributes = null, object dataBindAttributes = null, bool addDefaultBinding = true)
        {
            return htmlHelper.KoDropDownListFor(expression,
                selectList,
                htmlAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                dataBindAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(dataBindAttributes),
                addDefaultBinding);
        }
        
        /// <summary>
        /// Knockout DropDownListFor internal.
        /// </summary>
        private static MvcHtmlString KoDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes, IDictionary<string, object> dataBindAttributes, bool addDefaultBinding)
        {
            var propName = htmlHelper.NameFor(expression);
            htmlAttributes.AddDataBindAttributeFor(ControlType.DropDown, propName, dataBindAttributes, addDefaultBinding);
            return htmlHelper.DropDownListFor(expression, selectList, htmlAttributes);
        }

        /// <summary>
        /// Knockout DropDownListFor with option label.
        /// </summary>
        public static MvcHtmlString KoDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, Object htmlAttributes = null, object dataBindAttributes = null)
        {
            return htmlHelper.KoDropDownListFor(expression,
                selectList,
                optionLabel,
                htmlAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                dataBindAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(dataBindAttributes));
        }

        /// <summary>
        /// Knockout DropDownListFor internal with option label.
        /// </summary>
        private static MvcHtmlString KoDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes, IDictionary<string, object> dataBindAttributes)
        {
            var propName = htmlHelper.NameFor(expression);
            htmlAttributes.AddDataBindAttributeFor(ControlType.DropDown, propName, dataBindAttributes, true);
            return htmlHelper.DropDownListFor(expression, selectList, optionLabel, htmlAttributes);
        }
        #endregion

        #region KoRadioButtonFor
        /// <summary>
        /// Knockout RadioButtonFor.
        /// </summary>
        public static MvcHtmlString KoRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes = null, object dataBindAttributes = null, bool addDefaultBinding = true)
        {
            return htmlHelper.KoRadioButtonFor(expression,
                value,
                htmlAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                dataBindAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(dataBindAttributes),
                addDefaultBinding);
        }

        /// <summary>
        /// Knockout RadioButtonFor internal.
        /// </summary>
        private static MvcHtmlString KoRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, IDictionary<string, object> htmlAttributes, IDictionary<string, object> dataBindAttributes, bool addDefaultBinding)
        {
            var propName = htmlHelper.NameFor(expression);
            htmlAttributes.AddDataBindAttributeFor(ControlType.Radio, propName, dataBindAttributes, addDefaultBinding);
            return htmlHelper.RadioButtonFor(expression, value, htmlAttributes);
        }
        #endregion

        #region KoTextAreaFor
        /// <summary>
        /// Knockout TextAreaFor.
        /// </summary>
        public static MvcHtmlString KoTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows = 0, int columns = 0, object htmlAttributes = null, object dataBindAttributes = null, bool addDefaultBinding = true)
        {
            return htmlHelper.KoTextAreaFor(expression,
                    rows,
                    columns,
                    htmlAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                    dataBindAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(dataBindAttributes),
                    addDefaultBinding);
        }

        /// <summary>
        /// Knockout TextAreaFor internal.
        /// </summary>
        private static MvcHtmlString KoTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, IDictionary<string, object> htmlAttributes, IDictionary<string, object> dataBindAttributes, bool addDefaultBinding)
        {
            var propName = htmlHelper.NameFor(expression);
            htmlAttributes.AddDataBindAttributeFor(ControlType.TextArea, propName, dataBindAttributes, addDefaultBinding);
            return htmlHelper.TextAreaFor(expression, rows, columns, htmlAttributes);
        }
        #endregion

        #region KoTextBoxFor
        /// <summary>
        /// Knockout TextBoxFor.
        /// </summary>
        public static MvcHtmlString KoTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null, object dataBindAttributes = null, bool addDefaultBinding = true)
        {
            return htmlHelper.KoTextBoxFor(expression,
                htmlAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                dataBindAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(dataBindAttributes),
                addDefaultBinding);
        }

        /// <summary>
        /// Knockout TextBoxFor internal.
        /// </summary>
        private static MvcHtmlString KoTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes, IDictionary<string, object> dataBindAttributes, bool addDefaultBinding)
        {
            var propName = htmlHelper.NameFor(expression);
            htmlAttributes.AddDataBindAttributeFor(ControlType.TextBox, propName, dataBindAttributes, addDefaultBinding);
            return htmlHelper.TextBoxFor(expression, htmlAttributes);
        }

        /// <summary>
        /// Knockout TextBoxFor with format.
        /// </summary>
        public static MvcHtmlString KoTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes = null, object dataBindAttributes = null, bool addDefaultBinding = true)
        {
            return htmlHelper.KoTextBoxFor(expression,
                format,
                htmlAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                dataBindAttributes == null ? new RouteValueDictionary() : HtmlHelper.AnonymousObjectToHtmlAttributes(dataBindAttributes),
                addDefaultBinding);
        }

        /// <summary>
        /// Knockout TextBoxFor with format internal.
        /// </summary>
        private static MvcHtmlString KoTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, IDictionary<string, object> htmlAttributes, IDictionary<string, object> dataBindAttributes, bool addDefaultBinding)
        {
            var propName = htmlHelper.NameFor(expression);
            htmlAttributes.AddDataBindAttributeFor(ControlType.TextBox, propName, dataBindAttributes, addDefaultBinding);
            return htmlHelper.TextBoxFor(expression, format, htmlAttributes);
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Avoids using the HtmlFieldPrefix when getting the NameFor an expression.
        /// Also, grabs only the furthest descended property (x => x.Address.City will return City).
        /// </summary>
        private static MvcHtmlString NameFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            if (!string.IsNullOrWhiteSpace(name))
            {
                var nameSplit = name.Split('.');
                name = nameSplit[nameSplit.Length - 1];
            }
            return MvcHtmlString.Create(html.AttributeEncode(name));
        }

        /// <summary>
        /// Adds the value/checked Knockout binding and any custom bindings to the htmlAttributes dictionary under key 'data-bind'.
        /// </summary>
        private static void AddDataBindAttributeFor(this IDictionary<string, object> htmlAttributes, ControlType controlType, MvcHtmlString propName, IDictionary<string, object> dataBindAttributes, bool addDefaultBinding)
        {
            var dataBindValue = new StringBuilder();

            if (addDefaultBinding)
            {
                switch (controlType)
                {
                    case ControlType.CheckBox:
                    case ControlType.Radio:
                        {
                            dataBindValue.Append("checked: " + propName);
                            break;
                        }
                    case ControlType.DropDown:
                    case ControlType.TextArea:
                    case ControlType.TextBox:
                        {
                            dataBindValue.Append("value: " + propName);
                            break;
                        }
                }
            }

            foreach (var attr in dataBindAttributes)
            {
                dataBindValue.Append(dataBindValue.Length > 0
                    ? string.Format(", {0}: {1}", attr.Key, attr.Value)
                    : string.Format("{0}: {1}", attr.Key, attr.Value));
            }

            htmlAttributes["data-bind"] = dataBindValue.ToString();
        }
        #endregion
    }

    /// <summary>
    /// Used with the Knockout extension methods.
    /// Represents the different control types supported through Knockout extensions.
    /// </summary>
    public enum ControlType
    {
        /// <summary>
        /// CheckBox control type
        /// </summary>
        CheckBox,

        /// <summary>
        /// DropDownList control type
        /// </summary>
        DropDown,

        /// <summary>
        /// Radio control type
        /// </summary>
        Radio,

        /// <summary>
        /// TextArea control type
        /// </summary>
        TextArea,

        /// <summary>
        /// TextBox control type
        /// </summary>
        TextBox
    }
}