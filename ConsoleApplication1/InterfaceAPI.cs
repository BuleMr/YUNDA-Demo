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
    class InterfaceAPI1
    {
        public static readonly String WEB_URL = "http://192.168.1.209/cus_order/order_interface/";
        public static readonly String PARTNER_ID = "YUNDA";
        public static readonly String PARTNER_PASSWD = "123456";
        public static readonly String VERSION = "1.0";

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public static String interface_receiver_order(String xmldata) {
             
            RequestVO requestVO = new RequestVO();
            requestVO.xmldata = xmldata;
            requestVO.request = "data";
            requestVO.version = VERSION;

            String postdata = DataTransform.signData(requestVO);

            return HttpClient.post(WEB_URL + "interface_receive_order.php", postdata);
           
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static String interface_modify_order(Orders orders) {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            XmlSerializer xml = new XmlSerializer(orders.GetType());
            String xmldata = "";
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    xml.Serialize(stream, orders);
                    xmldata = Encoding.UTF8.GetString(stream.GetBuffer(), 0, (int)stream.Length);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            xmldata = Convert.ToBase64String(System.Text.Encoding.GetEncoding("utf-8").GetBytes(xmldata));

            String urlCodeXmlData = HttpUtility.UrlEncode(xmldata);
            parameters.Add("xmldata", urlCodeXmlData);
            parameters.Add("version", VERSION);
            parameters.Add("request", "data");
            String md5Xmldata = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(xmldata + PARTNER_ID + PARTNER_PASSWD, "MD5").ToLower();
            parameters.Add("validation", md5Xmldata);
            parameters.Add("partnerid", PARTNER_ID);


            HttpWebResponse httpWebResponse = HttpClient.post(WEB_URL + "interface_receive_order.php", parameters);
            StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
            string outMessage = sr.ReadToEnd();
            sr.Close();
            return outMessage;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static String interface_cancel_order() {
            return null;
        }

  

        public static string interface_order_info() {
            return null;
        }

        public static string interface_print_file() {
            return null;
        }

    }
}
