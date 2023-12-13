using System.ComponentModel.DataAnnotations;

namespace RefreshFW.Domain.Entities
{
    public class CustomerIndividu : AuditAble
    {
        [Key]
        public int Id { get; set; }

        [StringLength(90)]
        public required string FullName { get; set; }

        [StringLength(45)]
        public string? IdentityNumber { get; set; }

        public bool IsActive { get; set; }
    }
}