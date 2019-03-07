using System;
using System.Text;
using System.Web;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    class DataTransform
    {
        /// <summary>
        /// 组装主体内容
        /// </summary>
        /// <param name="requestVO"></param>
        /// <returns></returns>
        public static String signData(RequestVO requestVO)
        {
            String xmldata = Convert.ToBase64String(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(requestVO.xmldata));
            string validation = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(xmldata + requestVO.partnerid + requestVO.password, "MD5").ToLower();
            string signdata = "partnerid=" + requestVO.partnerid + "&version=" + requestVO.version + "&request=" + requestVO.request + "&xmldata=" + HttpUtility.UrlEncode(xmldata) + "&validation=" + validation;
            return signdata;
        }

        /// <summary>
        /// 内容数据转换XML
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String obj2Xml(Type type, Object obj)
        {
            XmlSerializer xml = new XmlSerializer(type);
            String xmldata = "";
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    xml.Serialize(stream, obj);
                    xmldata = Encoding.UTF8.GetString(stream.GetBuffer(), 0, (int)stream.Length);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return xmldata;
        }

        /// <summary>
        /// 内容清洗转换
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static string xmlformat(string xml) {
            try {

                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(xml);

                System.IO.StringWriter sw = new System.IO.StringWriter();
                using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(sw))
                {
                    writer.Indentation = 2;  // the Indentation
                    writer.Formatting = System.Xml.Formatting.Indented;
                    doc.WriteContentTo(writer);
                    writer.Close();
                }
                return sw.ToString();
            } catch (Exception ex) {
                return xml;
            }
            
        }
    }
}
