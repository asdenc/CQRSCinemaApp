using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Customer.CommandModels
{
    public class CustomerCommands
    {
        public class CreateCustomerCommand : IRequest<Models.Models.Customer>
        {
            public string FName { get; set; }
            public string LName { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
        public class UpdateCustomerCommand : IRequest<int>
        {
            public int Id { get; set; }
            public string FName { get; set; }
            public string LName { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
        public class DeleteCustomerCommand : IRequest<int>
        {
            public int Id { get; set; }
        }
    }
}
