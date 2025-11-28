using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Orders.Application.Features.CQRS.Commands.AdressCommands
{
    public class RemoveAdressCommand
    {
        public int Id { get; set; }

        public RemoveAdressCommand(int id)
        {
            Id = id;
        }
    }
}
