using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using ConsoleApplication2;


namespace ConsoleApplication1
{
    /// <summary>
    /// 假数据
    /// </summary>
    class OrderData
    {
        public static Orders getOrders()
        {
            DateTime time = DateTime.Now;
            String t = time.ToString("yyyyMMddHH");

            Orders orders = new Orders();
            List<Order> orderList = new List<Order>();
            //创建1个或多个订单
            for (int x = 0; x < 1; x++)
            {
                Order order = new Order();
                order.order_serial_no = t;
                order.khddh = t;
                Sender sender = new Sender();
                sender.name = "店小二";
                sender.company = "YUNDA";
                sender.city = "上海上海市青浦区";
                sender.address = "上海上海市青浦区盈港东路6679号[韵达总部]";
                sender.postcode = "221435";
                sender.mobile = "13800000000";
                sender.phone = "021-00000000";
                sender.branch = "";
                order.sender = sender;

                Receiver receiver = new Receiver();
                receiver.name = "店小二";
                receiver.company = "YUNDA";
                receiver.city = "上海上海市青浦区";
                receiver.address = "上海上海市青浦区盈港东路6679号[韵达总部]";
                receiver.postcode = "221435";
                receiver.mobile = "13800000000";
                receiver.phone = "021-00000000";
                receiver.branch = "";
                order.receiver = receiver;


                List<Item> itemList = new List<Item>();
                Items items = new Items();
                Item item = new Item();
                item.name = "condom";
                item.number = 100000000;
                item.remark = "请注意使用！";
                itemList.Add(item);
                items.item = itemList;

                //
                order.items = items;
                orderList.Add(order);

                orders.order = orderList;

            }
            return orders;
        }


    }

}
