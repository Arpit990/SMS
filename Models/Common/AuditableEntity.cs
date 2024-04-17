using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SpeakerManagementSystem.Models.Common
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }

    public class AuditableEntity : IAuditableEntity
    {
        [ValidateNever]
        public DateTime CreatedDate { get; set; }
        [ValidateNever]
        public string CreatedBy { get; set; }
        [ValidateNever]
        public DateTime ModifiedDate { get; set; }
        [ValidateNever]
        public string ModifiedBy { get; set; }
    }

}
