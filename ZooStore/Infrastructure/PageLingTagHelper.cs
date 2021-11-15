using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using ZooStore.Models.ViewModels;

namespace ZooStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLingTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;
        public PageLingTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        public bool PageClassesEnabled { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUlrValues { get; set; } = new();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder pageList = new("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder pageBlock = new("div");
                pageBlock.AddCssClass(PageClass);

                TagBuilder pageElement = new("div");
                pageElement.AddCssClass(PageClassNormal);

                TagBuilder aTag = new("a");
                PageUlrValues["page"] = i;
                aTag.Attributes["href"] = urlHelper.Action(PageAction, PageUlrValues);

                if (PageClassesEnabled && PageModel.CurrentPage == i)
                {
                    pageElement.AddCssClass(PageClassSelected);
                }

                pageElement.InnerHtml.Append(i.ToString());
                aTag.InnerHtml.AppendHtml(pageElement);
                pageBlock.InnerHtml.AppendHtml(aTag);
                pageList.InnerHtml.AppendHtml(pageBlock);
            }

            output.Content.AppendHtml(pageList.InnerHtml);
        }
    }
}
