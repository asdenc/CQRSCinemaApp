namespace CinemaApp.Customer.Contract
{
    public interface ICustomerService
    {
        Task<IEnumerable<CinemaApp.Models.Models.Customer>> GetCustomerList();
        Task<CinemaApp.Models.Models.Customer> GetCustomerById(int id);
        Task<CinemaApp.Models.Models.Customer> CreateCustomer(CinemaApp.Models.Models.Customer customer);
        Task<int> UpdateCustomer(CinemaApp.Models.Models.Customer customer);
        Task<int> DeleteCustomer(CinemaApp.Models.Models.Customer customer);
    }
}
