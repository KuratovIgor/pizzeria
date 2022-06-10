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
        private List<int> _orders = new List<int>();
        private int _bagpackSize;
        private int _id;

        public Courier(int id, int bagpackSize)
        {
            _id = id;
            _bagpackSize = bagpackSize;
            _deliverThread = new Thread(Deliver);
        }

        public void Start()
        {
            _deliverThread.Start();
        }

        private void Deliver()
        {
            while (WorkList.PizzaOrders.Count != 0 || Storage.FreePlace != Storage.MaxCapacity)
            {
                for (int i = 0; i < _bagpackSize; i++)
                {
                    _orders.Add(Storage.GetPizzaFromStorage(_id));
                }

                foreach (int order in _orders)
                {
                    NotifyCooking.PizzaInDeliver(_id, order);
                }

                foreach (int order in _orders)
                {
                    Thread.Sleep(_deliverTime.Next(8000, 16000));
                    NotifyCooking.PizzaDelivered(_id, order);
                }
            }
        }
    }
}
