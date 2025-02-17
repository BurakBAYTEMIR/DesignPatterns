﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    /// <summary>
    /// Bir isteği, istekle ilgili tüm bilgileri içeren bağımsız bir nesneye dönüştürür. 
    /// Bu dönüşüm, istekleri yöntem bağımsız değişkenleri olarak iletmenize, 
    /// bir isteğin yürütülmesini geciktirmenize veya kuyruğa almanıza ve geri alınamayan işlemleri desteklemenize olanak tanır.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockController stockController = new StockController();

            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);

            stockController.PlaceOrders();

            Console.ReadLine();

        }
    }

    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stock : {0}, {1} bought!", _name, _quantity);
        }

        public void Sell()
        {
            Console.WriteLine("Stock : {0}, {1} sold!", _name, _quantity);
        }
    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        private StockManager _stockmanager;
        public BuyStock(StockManager stockmanager)
        {
            _stockmanager = stockmanager;
        }
        public void Execute()
        {
            _stockmanager.Buy();
        }
    }

    class SellStock : IOrder
    {
        private StockManager _stockmanager;
        public SellStock(StockManager stockmanager)
        {
            _stockmanager = stockmanager;
        }
        public void Execute()
        {
            _stockmanager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();
        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }

            _orders.Clear();
        }
    }
}
