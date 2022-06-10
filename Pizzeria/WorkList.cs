using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pizzeria
{
    public static class WorkList
    {
        private static object _orderLocker = new object();

        public static List<int> PizzaOrders { get; set; } = new List<int>();

        public static void GenerateOrders(object countOrder)
        {
            Random rand = new Random();

            int i = 0;
            while(i < (int)countOrder)
            {
                int order = rand.Next(1, 30);

                if (!PizzaOrders.Contains(order))
                {
                    PizzaOrders.Add(order);
                    NotifyCooking.PizzaOrdered(order);

                    i++;
                }
            }
        }

        public static int GetOrder()
        {
            lock (_orderLocker)
            {
                while (PizzaOrders.Count == 0) { }

                int order = PizzaOrders[0];
                 PizzaOrders.RemoveAt(0);

                return order;
            }
        }
    }
}
