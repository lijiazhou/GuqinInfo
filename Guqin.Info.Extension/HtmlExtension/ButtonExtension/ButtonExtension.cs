using System.Collections.Generic;
using Common.Static.Extension.UtilityExtesion;

namespace System.Web.Mvc.Html
{
    public static class ButtonExtension
    {
        static MvcHtmlString CreateButton(String name, String type, Object value, IDictionary<String, Object> htmlAttributes)
        {
            List<HtmlExtentionAttribute> attrs = new List<HtmlExtentionAttribute>();
            attrs.Add(ExtensionBase.CreateHtmlExtensionAttribute("name", name));
            attrs.Add(ExtensionBase.CreateHtmlExtensionAttribute("type", type));
            return ExtensionBase.CreateMvcString(
                ExtensionBase.CreatTagBuilder(
                    "Button", 
                    htmlAttributes, 
                    attrs, 
                    value));
        }

        public static MvcHtmlString InputButton(this HtmlHelper helper, String name, Object value, Object htmlAttributes)
        {
            return InputButton(helper, name, value, htmlAttributes.ToDictionary());
        }

        public static MvcHtmlString InputButton(this HtmlHelper helper, String name, Object value, IDictionary<String, Object> htmlAttributes)
        {
            return CreateButton(name, "button", value, htmlAttributes);
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper helper, String name, Object value, Object htmlAttributes)
        {
            return SubmitButton(helper, name, value, htmlAttributes.ToDictionary());
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper helper, String name, Object value, IDictionary<String, Object> htmlAttributes)
        {
            return CreateButton(name, "submit", value, htmlAttributes);
        }
    }
}
