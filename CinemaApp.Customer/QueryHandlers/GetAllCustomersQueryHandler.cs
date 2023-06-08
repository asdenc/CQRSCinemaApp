using CinemaApp.Customer.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Customer.QueryModels.CustomerQueries;

namespace CinemaApp.Customer.QueryHandlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<Models.Models.Customer>>
    {
        private readonly ICustomerService _customerService;

        public GetAllCustomersQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IEnumerable<Models.Models.Customer>> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomerList();
        }
    }
}
