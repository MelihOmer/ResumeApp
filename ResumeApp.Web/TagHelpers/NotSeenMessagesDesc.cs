using Microsoft.AspNetCore.Razor.TagHelpers;
using ResumeApp.Core.Contracts.Services;

namespace ResumeApp.Web.TagHelpers
{
    public class NotSeenMessagesDesc : TagHelper
    {
        private readonly IContactService _contactService;

        public NotSeenMessagesDesc(IContactService contactService)
        {
            _contactService = contactService;
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            return base.ProcessAsync(context, output);
        }
    }
}
