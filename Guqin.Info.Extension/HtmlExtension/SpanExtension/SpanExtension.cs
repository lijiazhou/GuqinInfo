using Common.Static.Extension.UtilityExtesion;
using System.Collections.Generic;

namespace System.Web.Mvc.Html
{
    public static class SpanExtension
    {
        public static MvcHtmlString Span(this HtmlHelper helper, String name, Object value, IDictionary<String, Object> htmlAttributes)
        {
            List<HtmlExtentionAttribute> attrs = new List<HtmlExtentionAttribute>();
            attrs.Add(ExtensionBase.CreateHtmlExtensionAttribute("name", name));
            return ExtensionBase.CreateMvcString(
                ExtensionBase.CreatTagBuilder(
                    "span",
                    htmlAttributes,
                    attrs,
                    value));
        }

        public static MvcHtmlString Span(this HtmlHelper helper, String name, Object value, Object htmlAttributes)
        {
            return Span(helper, name, value, htmlAttributes.ToDictionary());
        }

        public static MvcHtmlString Span(this HtmlHelper helper, String name, IDictionary<String, Object> htmlAttributes)
        {
            return Span(helper, name, null, htmlAttributes);
        }

        public static MvcHtmlString Span(this HtmlHelper helper, String name, Object htmlAttributes)
        {
            return Span(helper, name, null, htmlAttributes.ToDictionary());
        }
    }
}
