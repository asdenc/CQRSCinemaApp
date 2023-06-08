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
    public  class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly ICustomerService _customerService;

        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<int> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomerById(command.Id);
            return await _customerService.DeleteCustomer(customer);

        }
    }
}
