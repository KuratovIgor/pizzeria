using System;
using System.Collections.Generic;
using System.Threading;
using System.Text.Json;
using System.IO;

namespace Pizzeria
{
    class Program
    {
        private static Employees _employees = new Employees();
        private static List<Cook> _cooks = new List<Cook>();
        private static List<Courier> _couriers = new List<Courier>();

        static void Main(string[] args)
        {
            NotifyCooking.Notify += ShowNotify;

            Thread.Sleep(1000);

            GenerateEmployees();

            StartPizzeria();
        }

        private static void GenerateEmployees()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "../../../employees.json");
            var json = File.ReadAllText(path);

            _employees = Newtonsoft.Json.JsonConvert.DeserializeObject<Employees>(json);

            GenerateCooks();
            GenerateCouriers();
        }

        private static void StartPizzeria()
        {
            Console.WriteLine("PIZZERIA OPENED!");
            Console.WriteLine("----------------");

            Random randTimeOrder = new Random();
            Random countOrder = new Random();

            TimerCallback tm = new TimerCallback(WorkList.GenerateOrders);
            Timer timer = new Timer(tm, 1, 0, randTimeOrder.Next(2000, 4000));


            foreach (Courier courier in _couriers)
            {
                courier.Start();
            }

            foreach (Cook cook in _cooks)
            {
                cook.Start();
            }

            Console.ReadLine();
        }

        private static void GenerateCooks()
        {
            for (int cook = 1; cook <= _employees.cooks; cook++)
            {
                _cooks.Add(new Cook());
            }
        }

        private static void GenerateCouriers()
        {
            foreach (CourierJson courier in _employees.couriers)
            {
                _couriers.Add(new Courier(courier.id, courier.bagpack_size));
            }
        }

        private static void ShowNotify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
