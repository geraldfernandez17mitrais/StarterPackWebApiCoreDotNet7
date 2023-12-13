using RefreshFW.Domain.Entities;

namespace RefreshFW.Domain.Interfaces
{
    public interface ICustomerIndividuRepository
    {
        public Task<List<CustomerIndividu>> GetAllAsync();
        public Task<CustomerIndividu> GetByIdAsync(int customerIndividuId);
        public Task AddAsync(CustomerIndividu customerIndividu);
        public Task UpdateAsync(CustomerIndividu customerIndividu);
        public Task DeleteAsync(CustomerIndividu customerIndividu);
    }
}