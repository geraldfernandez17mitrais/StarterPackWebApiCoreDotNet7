using System.ComponentModel.DataAnnotations;

namespace RefreshFW.Domain.Entities
{
    public class AuditAble
    {
        public DateTime CreatedDate { get; set; }

        [StringLength(45)]
        public required string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        [StringLength(45)]
        public required string ModifiedBy { get; set; }
    }
}