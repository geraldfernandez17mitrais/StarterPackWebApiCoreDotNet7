using Microsoft.EntityFrameworkCore;
using RefreshFW.Domain.Entities;
using RefreshFW.Domain.Interfaces;

namespace RefreshFW.Persistance.Repositories
{
    public class CustomerIndividuRepository : ICustomerIndividuRepository
    {
        private readonly RefreshFrameWorkDBContext _context;

        public CustomerIndividuRepository(RefreshFrameWorkDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CustomerIndividu customerIndividu)
        {
            try
            {
                await _context.customer_individus.AddAsync(customerIndividu);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(CustomerIndividu customerIndividu)
        {
            try
            {
                _context.customer_individus.Remove(customerIndividu);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CustomerIndividu>> GetAllAsync()
        {
            try
            {
                return await _context.customer_individus.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomerIndividu> GetByIdAsync(int customerIndividuId)
        {
            try
            {
                return await _context.customer_individus.SingleOrDefaultAsync(c => c.Id == customerIndividuId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(CustomerIndividu customerIndividu)
        {
            try
            {
                CustomerIndividu customerIndividuExisting = _context.customer_individus.FirstOrDefault(c => c.Id == customerIndividu.Id);

                customerIndividuExisting.FullName = customerIndividu.FullName;
                customerIndividuExisting.IdentityNumber = customerIndividu.IdentityNumber;
                customerIndividuExisting.IsActive = customerIndividu.IsActive;

                _context.Entry(customerIndividuExisting).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}