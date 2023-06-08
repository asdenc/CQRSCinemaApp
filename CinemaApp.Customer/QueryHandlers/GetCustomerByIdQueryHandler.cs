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
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Models.Models.Customer>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerByIdQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Models.Models.Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomerById(query.Id);
        }
    }
}
