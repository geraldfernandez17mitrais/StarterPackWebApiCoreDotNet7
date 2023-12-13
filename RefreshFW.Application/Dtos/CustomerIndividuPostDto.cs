namespace RefreshFW.Application.Dtos
{
    public class CustomerIndividuPostDto
    {
        public required string FullName { get; set; }

        public string? IdentityNumber { get; set; }

        public bool IsActive { get; set; }
    }
}