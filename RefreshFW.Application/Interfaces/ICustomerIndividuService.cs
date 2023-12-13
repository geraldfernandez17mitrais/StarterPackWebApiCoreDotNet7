using RefreshFW.Application.Dtos;

namespace RefreshFW.Application.Interfaces
{
    public interface ICustomerIndividuService
    {
        Task<List<CustomerIndividuDto>> GetAllAsync();
        Task<CustomerIndividuDto> GetByIdAsync(int customerIndividuId);
        Task<int> AddAsync(CustomerIndividuPostDto customerIndividuPostDto);
        Task UpdateAsync(CustomerIndividuPutDto customerIndividuPutDto);
        Task DeleteAsync(int customerIndividuId);
    }
}