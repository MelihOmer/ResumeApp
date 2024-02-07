using ResumeApp.Core.Common;

namespace ResumeApp.Core.Entities
{
    public class Project: BaseEntity
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectPath { get; set; }
        public string Guid { get; set; }
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
