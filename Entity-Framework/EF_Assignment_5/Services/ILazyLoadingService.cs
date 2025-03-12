using EF_Assignment_5.Models.DTOs;

namespace EF_Assignment_5.Services
{
    public interface ILazyLoadingService
    {
        List<CustomerDTO> GetCustomersWithOrders();
        List<CustomerDTO> GetHighValueCustomers();
    }
}
