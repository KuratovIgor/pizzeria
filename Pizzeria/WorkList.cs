using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public static class WorkList
    {
        private static object _orderLocker = new object();

        public static List<int> PizzaOrders { get; set; } = new List<int>();

        public static int GetOrder()
        {
            lock (_orderLocker)
            {
                if (PizzaOrders.Count != 0)
                {
                    int order = PizzaOrders[0];
                    PizzaOrders.RemoveAt(0);

                    return order;
                }

                return 0;
            }
        }
    }
}
