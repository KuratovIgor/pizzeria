using System;
using System.Collections.Generic;
using System.Threading;

namespace Pizzeria
{
    class Program
    {
        private static List<Cook> _cooks = new List<Cook>();
        private static List<Courier> _couriers = new List<Courier>();

        static void Main(string[] args)
        {
            NotifyCooking.Notify += ShowNotify;

            Thread.Sleep(1000);

            FillDatas();

            StartPizzeria();
        }

        private static void StartPizzeria()
        {
            Console.WriteLine("PIZZERIA OPENED!");
            Console.WriteLine("----------------");

            foreach (Courier courier in _couriers)
            {
                courier.Start();
            }

            foreach (Cook cook in _cooks)
            {
                cook.Start();
            }
        }

        private static void FillDatas()
        {
            Console.Write("Count orders: ");
            int orders = Convert.ToInt32(Console.ReadLine());

            Console.Write("Count cooks: ");
            int cooks = Convert.ToInt32(Console.ReadLine());

            Console.Write("Count couriers: ");
            int couriers = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            GenerateStartOrders(orders);
            GenerateCooks(cooks);
            GenerateCouriers(couriers);
        }

        private static void GenerateStartOrders(int orders)
        {
            for (int order = 1; order <= orders; order++)
            {
                WorkList.PizzaOrders.Add(order);
            }
        }

        private static void GenerateCooks(int cooks)
        {
            for (int cook = 1; cook <= cooks; cook++)
            {
                _cooks.Add(new Cook());
            }
        }

        private static void GenerateCouriers(int couriers)
        {
            for (int courier = 1; courier <= couriers; courier++)
            {
                _couriers.Add(new Courier());
            }
        }

        private static void ShowNotify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
