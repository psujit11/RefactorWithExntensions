using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    public class NotificationAppService
    {
        public void SendOrderConfirmation(Order order)
        {
            Console.WriteLine("sending Order confirmation to"+ order.Customer.Email);
        }
    }
}
