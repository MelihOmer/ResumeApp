using Microsoft.AspNetCore.Razor.TagHelpers;
using ResumeApp.Core.Contracts.Services;

namespace ResumeApp.Web.TagHelpers
{
    [HtmlTargetElement("notSeenMessage")]
    public class NotSeenMessages : TagHelper
    {
        private readonly IContactService _contactService;

        public NotSeenMessages(IContactService contactService)
        {
            _contactService = contactService;
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            int count = _contactService.Where(x => x.Seen != true).Count();
            output.Content.SetHtmlContent(count.ToString());
            return base.ProcessAsync(context, output);
        }
    }
}
