using SpeakerManagementSystem.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeakerManagementSystem.Models
{
    [Table("Organization")]
    public class Organization : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
