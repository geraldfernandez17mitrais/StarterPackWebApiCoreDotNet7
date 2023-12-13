using AutoMapper;
using RefreshFW.Application.Dtos;
using RefreshFW.Application.Helpers;
using RefreshFW.Application.Interfaces;
using RefreshFW.Domain.Entities;
using RefreshFW.Domain.Interfaces;

namespace RefreshFW.Application.Handlers
{
    public class CustomerIndividuService : ICustomerIndividuService
    {
        private readonly ICustomerIndividuRepository _customerIndividuRepository;
        private readonly IMapper _mapper;

        public CustomerIndividuService(ICustomerIndividuRepository customerIndividuRepository, IMapper mapper)
        {
            _customerIndividuRepository = customerIndividuRepository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CustomerIndividuPostDto customerIndividuPostDto)
        {
            CustomerIndividu customerIndividu = _mapper.Map<CustomerIndividuPostDto, CustomerIndividu>(customerIndividuPostDto);

            // Add values:
            await _customerIndividuRepository.AddAsync(customerIndividu);

            return customerIndividu.Id;
        }

        public async Task DeleteAsync(int customerIndividuId)
        {
            // Check existing data:
            CustomerIndividu customerIndividuExisting = await _customerIndividuRepository.GetByIdAsync(customerIndividuId);

            if (customerIndividuExisting is null)
            {
                throw new Exception(ResponseCode.customerIndividuNotFound);
            }

            // delete from database:
            await _customerIndividuRepository.DeleteAsync(customerIndividuExisting);
        }

        public async Task<List<CustomerIndividuDto>> GetAllAsync()
        {
            List<CustomerIndividu> customerIndividus = await _customerIndividuRepository.GetAllAsync();
            List<CustomerIndividuDto> customerIndividuDtos = _mapper.Map<List<CustomerIndividu>, List<CustomerIndividuDto>>(customerIndividus);

            return customerIndividuDtos;
        }

        public async Task<CustomerIndividuDto> GetByIdAsync(int customerIndividuId)
        {
            CustomerIndividu customerIndividuExisting = await _customerIndividuRepository.GetByIdAsync(customerIndividuId);

            return _mapper.Map<CustomerIndividu, CustomerIndividuDto>(customerIndividuExisting);
        }

        public async Task UpdateAsync(CustomerIndividuPutDto customerIndividuPutDto)
        {
            CustomerIndividu customerIndividu = _mapper.Map<CustomerIndividuPutDto, CustomerIndividu>(customerIndividuPutDto);

            // Check existing data:
            CustomerIndividu customerIndividuExisting = await _customerIndividuRepository.GetByIdAsync(customerIndividu.Id);

            if (customerIndividuExisting is null)
            {
                throw new Exception(ResponseCode.customerIndividuNotFound);
            }

            // Update data in database:
            await _customerIndividuRepository.UpdateAsync(customerIndividu);
        }
    }
}