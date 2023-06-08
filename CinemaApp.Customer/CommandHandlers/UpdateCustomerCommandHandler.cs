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
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {

            var customer = await _customerService.GetCustomerById(command.Id);

            customer.FName = command.FName;
            customer.LName = command.LName;
            customer.DateOfBirth = command.DateOfBirth;

            return await _customerService.UpdateCustomer(customer);

        }
    }
}
