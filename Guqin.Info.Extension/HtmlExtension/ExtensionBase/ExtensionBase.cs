using System.Collections.Generic;

namespace System.Web.Mvc.Html
{
    static class ExtensionBase
    {
        public static MvcHtmlString CreateMvcString(TagBuilder tag)
        {
            return MvcHtmlString.Create(tag.ToString());
        }

        public static TagBuilder CreatTagBuilder(String tagName, IDictionary<String, Object> htmlAttributes, List<HtmlExtentionAttribute> extendAttrs, Object innerText)
        {
            TagBuilder tag = new TagBuilder(tagName);
            extendAttrs.ForEach(x => tag.Attributes.Add(x.AttributeName, x.AttributeValue));
            tag.MergeAttributes(htmlAttributes);

            if (innerText != null)
            {
                String content = innerText.GetType() == 
                    typeof(MvcHtmlString) ? 
                    (innerText as MvcHtmlString).ToHtmlString() : 
                    innerText.ToString();
                tag.SetInnerText(content);
            }

            return tag;
        }

        public static TagBuilder CreatTagBuilder(String tagName, IDictionary<String, Object> htmlAttributes, List<HtmlExtentionAttribute> extendAttrs)
        {
            return CreatTagBuilder(tagName, htmlAttributes, extendAttrs, null);
        }

        public static HtmlExtentionAttribute CreateHtmlExtensionAttribute(String name, Object value)
        {
            return new HtmlExtentionAttribute()
            {
                AttributeName = name,
                AttributeValue = value.ToString()
            };
        }
    }
}
