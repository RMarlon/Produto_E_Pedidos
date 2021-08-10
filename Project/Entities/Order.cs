using System;
using System.Text;
using System.Globalization;
using Project.Entities.Enums;
using System.Collections.Generic;

namespace Project.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItem order)
        {
            Items.Add(order);
        }
        public void RemoveItem(OrderItem order)
        {
            Items.Remove(order);
        }
        public double Total()
        {
            double sum = 0.0;
            foreach(OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order Status: " + Status);
            sb.AppendLine("Order Client: " + Client);
            sb.AppendLine("Order Item:");
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total Price: $" + Total().ToString("Fe", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
