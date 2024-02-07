using Microsoft.AspNetCore.Mvc.Rendering;
using ResumeApp.Core.Dtos.ExperienceDtos;

namespace ResumeApp.Web.Models
{
    public class ExperienceAddModel
    {
        public ExperienceAddDto ExperienceAddDto{ get; set; }
        public SelectList ResumeList { get; set; }
    }
}
