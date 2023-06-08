using CinemaApp.Customer.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Customer.CommandModels.CustomerCommands;

namespace CinemaApp.Customer.CommandHandlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Models.Models.Customer>
    {
        private readonly ICustomerService _customerService;

        public CreateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<Models.Models.Customer> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Models.Models.Customer()
            {
                FName = command.FName,
                LName = command.LName,
                DateOfBirth = command.DateOfBirth,
            };

            return await _customerService.CreateCustomer(customer);
        }
    }
}
