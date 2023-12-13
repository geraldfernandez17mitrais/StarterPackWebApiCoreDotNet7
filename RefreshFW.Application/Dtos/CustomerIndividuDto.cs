namespace RefreshFW.Application.Dtos
{
    public class CustomerIndividuDto
    {
        public int Id { get; set; }

        public required string FullName { get; set; }

        public string? IdentityNumber { get; set; }

        public bool IsActive { get; set; }
    }
}