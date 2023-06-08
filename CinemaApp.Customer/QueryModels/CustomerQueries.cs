using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Customer.QueryModels
{
    public class CustomerQueries
    {
        public class GetCustomerByIdQuery : IRequest<Models.Models.Customer>
        {
            public int Id { get; set; }
        }
        public class GetAllCustomerQuery : IRequest<IEnumerable<Models.Models.Customer>>
        {

        }
    }
}
