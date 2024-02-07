using Microsoft.AspNetCore.Razor.TagHelpers;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Entities;

namespace ResumeApp.Web.TagHelpers
{
    [HtmlTargetElement("socialMediaLink")]
    public class SocialMediaLink : TagHelper
    {
        public string socialMedia { get; set; }
        public string viewName { get; set; }
        public string Icon { get; set; }
        private readonly IResumeService _service;

        public SocialMediaLink(IResumeService service)
        {
            _service = service;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            Resume resume = await _service.GetById(1);
            var properties = typeof(Resume).GetProperties().Where(x => x.Name.ToLowerInvariant().Contains(socialMedia.ToLowerInvariant())).FirstOrDefault();
            string link = properties.GetValue(resume).ToString();

            output.TagName = "a";
            output.Attributes.SetAttribute("target", "_blank");
            output.Attributes.SetAttribute("href", link);
            output.Attributes.SetAttribute("class", "text-gradient");
            output.Content.SetContent(viewName);
            output.Content.SetHtmlContent(Icon);
        }
    }
}
