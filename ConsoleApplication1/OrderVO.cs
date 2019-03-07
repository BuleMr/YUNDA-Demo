using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace ConsoleApplication2
{
    /// <summary>
    /// 数据体
    /// </summary>
    public class Orders
    {
        [XmlElement("order")]
        public List<Order> order { get; set; }
    }

    /// <summary>
    /// 韵达取号订单信息
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 订单唯一序列号
        /// </summary>
        public string order_serial_no { get; set; }
        /// <summary>
        /// 大客户系统订单的订单号
        /// </summary>
        public string khddh { get; set; }
        /// <summary>
        /// 内部参考号，供大客户自己使用，可以是客户的客户编号
        /// </summary>
        public string nbckh { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string mailno { get; set; }
        /// <summary>
        /// 发件人
        /// </summary>
        [XmlElement("sender")]
        public Sender sender { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        [XmlElement("receiver")]
        public Receiver receiver { get; set; }
        /// <summary>
        /// 物品重量
        /// </summary>
        public long weight { get; set; }
        /// <summary>
        /// 尺寸，格式（长,宽,高）,单位cm
        /// </summary>
        public string size { get; set; }
        /// <summary>
        /// 货物金额
        /// </summary>
        public decimal value { get; set; }
        /// <summary>
        /// 商品集合
        /// </summary>
        [XmlElement("items")]
        public Items items { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 可以自定义显示信息1
        /// </summary>
        public string cus_area1 { get; set; }
        /// <summary>
        /// 可以自定义显示信息2
        /// </summary>
        public string cus_area2 { get; set; }

    }
    public class Sender
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string company { get; set; }
        /// <summary>
        /// 严格按照国家行政区划，省市区三级，逗号分隔。示例上海市,上海市,青浦区（cod订单必填）
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 需要将省市区划信息加上，例如：上海市,上海市,青浦区盈港东路7766号
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string postcode { get; set; }
        /// <summary>
        /// 固定电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 移动电话固定电话或移动电话至少填一项
        /// </summary>
        public string mobile { get; set; }

        public string branch { get; set; }
    }
    public class Receiver
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string company { get; set; }
        /// <summary>
        /// 严格按照国家行政区划，省市区三级，逗号分隔。示例上海市,上海市,青浦区（cod订单必填）
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 需要将省市区划信息加上，例如：上海市,上海市,青浦区盈港东路7766号
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string postcode { get; set; }
        /// <summary>
        /// 固定电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 移动电话固定电话或移动电话至少填一项
        /// </summary>
        public string mobile { get; set; }
        public string branch { get; set; }
    }
    /// <summary>
    /// 明细集合
    /// </summary>
    public class Items
    {
        [XmlElement("item")]
        public List<Item> item { get; set; }
    }
    /// <summary>
    /// 明细信息
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// 商品备注
        /// </summary>
        public string remark { get; set; }
    }
}
