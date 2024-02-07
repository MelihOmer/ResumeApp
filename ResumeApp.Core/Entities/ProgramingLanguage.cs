using ResumeApp.Core.Common;

namespace ResumeApp.Core.Entities
{
    public class ProgramingLanguage : BaseEntity
    {
        public string Name { get; set; }
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
