using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Refactor
{
    public class OrderProcessor
    {
        private readonly ProductAppService _productService;
        private readonly NotificationAppService _notifierService;

        public OrderProcessor(ProductAppService productService, NotificationAppService notifier)
        {
            _productService = productService;
            _notifierService = notifier;
        }

        public void ProcessOrders(List<Order> orders)
        {
            foreach (var order in orders)
            {
                if(!order.HasSufficientInventory(_productService))
                continue;

                order.DecreaseStock(_productService);

                if (!order.ProcessPayment()) 
                continue;

                _notifierService.SendOrderConfirmation(order);
            }
        }
    }
}
