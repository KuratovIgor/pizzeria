using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public static class Storage
    {
        private static List<int> _pizza = new List<int>();
        private static object _setStorageLocker = new object();
        private static object _getPizzaLocker = new object();

        public static int FreePlace { get; set; } = 3;
        public static int MaxCapacity { get; } = 3;

        public static void SetStorage(int order)
        {
            lock (_setStorageLocker)
            {
                int flag = 0;

                while (FreePlace == 0) {
                    if (flag == 0)
                    {
                        NotifyCooking.PizzaInWaiting(order);
                        flag = 1;
                    }
                }

                _pizza.Add(order);

                NotifyCooking.PizzaInStorage(order);

                FreePlace--;
            }
        }

        public static int GetPizzaFromStorage()
        {
            lock (_getPizzaLocker)
            {
                while (FreePlace == MaxCapacity) { }

                int order = _pizza[0];

                _pizza.RemoveAt(0);
                FreePlace++;

                NotifyCooking.PizzaAtCourier(order);

                return order;
            }
        }
    }
}
