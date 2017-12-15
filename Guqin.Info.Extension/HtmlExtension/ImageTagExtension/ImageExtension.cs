using Common.Static.Extension.UtilityExtesion;
using System.Collections.Generic;
using System.Linq;

namespace System.Web.Mvc
{
    public static class ImageExtension
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string name, string path, object htmlAttributes)
        {
            return Image(helper, name, path, htmlAttributes.ToDictionary());
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string name, string path, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("name", name);
            path = "..\\" + path;
            img.Attributes.Add("src", path);
            img.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(img.ToString());
        }
    }
}