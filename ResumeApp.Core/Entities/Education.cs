using ResumeApp.Core.Common;

namespace ResumeApp.Core.Entities
{
    public class Education : BaseEntity
    {
        public string SchoolName { get; set; }
        public string Branch { get; set; }
        public string About { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Continue { get; set; }
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
