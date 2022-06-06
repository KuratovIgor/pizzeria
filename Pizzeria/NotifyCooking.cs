using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria
{
    public static class NotifyCooking
    {
        public delegate void ShowMessage(string message);
        public static event ShowMessage Notify;

        public static void PizzaInProgress(int orderNumber)
        {
            Notify?.Invoke($"Pizza {orderNumber}: Progress");
        }

        public static void PizzaIsReady(int orderNumber)
        {
            Notify?.Invoke($"Pizza {orderNumber}: Ready");
        }

        public static void PizzaInStorage(int orderNumber)
        {
            Notify?.Invoke($"Pizza {orderNumber}: In storage");
        }

        public static void PizzaInWaiting(int orderNumber)
        {
            Notify?.Invoke($"Pizza {orderNumber}: Waiting free place");
        }

        public static void PizzaAtCourier(int orderNumber)
        {
            Notify?.Invoke($"Pizza {orderNumber}: In deliver");
        }

        public static void PizzaDelivered(int orderNumber)
        {
            Notify?.Invoke($"Pizza {orderNumber}: Is delivered");
        }
    }
}
