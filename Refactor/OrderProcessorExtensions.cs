using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    public static class OrderProcessorExtensions
    {
        public static bool HasSufficientInventory(this Order order,ProductAppService productAppService)
        {
            foreach(var orderItem in order.OrderItems)
            {
                var product=productAppService.GetProduct(orderItem.ProductId);
                if (product == null || product.Quantity < orderItem.Quantity)
                {
                    Console.WriteLine("Out of stock"+ orderItem.ProductId);
                    return false;
                }
            }
            return true;

        }
        public static void DecreaseStock(this Order order,ProductAppService productAppService)
        {
            foreach (var orderItem in order.OrderItems)
            {
                var product = productAppService.GetProduct(orderItem.ProductId);
                if (product != null)
                {
                    product.Quantity -= orderItem.Quantity;
                }
            }
        }
        public static bool ProcessPayment(this Order order)
        {
            if (order.Total > order.Customer.Balance)
            {
                Console.WriteLine("Not suffiecient Balance" + order.CustomerId);
                return false;
            }
            else
            {
                order.Customer.Balance -= order.Total;
                return true;
            }
        }
    }
}
