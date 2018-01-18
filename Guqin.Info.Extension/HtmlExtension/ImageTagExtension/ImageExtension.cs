using Common.Static.Extension.UtilityExtesion;
using System.Collections.Generic;

namespace System.Web.Mvc.Html
{
    public static class ImageExtension 
    {
        public static MvcHtmlString Image(this HtmlHelper helper, String name, String path, Object htmlAttributes)
        {
            return Image(helper, name, path, htmlAttributes.ToDictionary());
        }

        public static MvcHtmlString Image(this HtmlHelper helper, String name, String path, IDictionary<String, Object> htmlAttributes)
        {
            List<HtmlExtentionAttribute> attrs = new List<HtmlExtentionAttribute>();
            attrs.Add(ExtensionBase.CreateHtmlExtensionAttribute("src", "..\\" + path));
            attrs.Add(ExtensionBase.CreateHtmlExtensionAttribute("name", name));
            return ExtensionBase.CreateMvcString(ExtensionBase.CreatTagBuilder("img", htmlAttributes, attrs));
        }
    }
}