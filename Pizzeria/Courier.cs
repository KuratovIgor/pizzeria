using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pizzeria
{
    public class Courier
    {
        private Thread _deliverThread;
        private Random _deliverTime = new Random();
        private int _order;

        public Courier()
        {
            _deliverThread = new Thread(Deliver);
        }

        public void Start()
        {
            _deliverThread.Start();
        }

        private void Deliver(object orderNumber)
        {
            while (WorkList.PizzaOrders.Count != 0 || Storage.FreePlace != Storage.MaxCapacity)
            {
                _order = Storage.GetPizzaFromStorage();

                Thread.Sleep(_deliverTime.Next(5000, 10000));

                NotifyCooking.PizzaDelivered(_order);
            }
        }
    }
}
