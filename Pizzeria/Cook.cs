using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pizzeria
{
    public class Cook
    {
        private Thread _cookingThread;
        private Random _cookingPizzaTime = new Random();
        private int _order;

        public Cook()
        {
            _cookingThread = new Thread(CookPizza);
        }

        public void Start()
        {
            _cookingThread.Start();
        }

        private void CookPizza()
        {
            while (WorkList.PizzaOrders.Count != 0)
            {
                TakeOrder();

                NotifyCooking.PizzaInProgress(_order);

                Thread.Sleep(_cookingPizzaTime.Next(1000, 5000));

                NotifyCooking.PizzaIsReady(_order);

                Storage.SetStorage(_order);

            }
        }

        private void TakeOrder()
        {
            _order = WorkList.GetOrder();
        }
    }
}
