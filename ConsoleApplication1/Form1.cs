using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Web;
using System.Net;
using System.Drawing.Printing;
using System.Diagnostics;
using ConsoleApplication2;
 

namespace ConsoleApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox7.Text = "/interface_receive_order.php";
            this.textBox1.Text = DataTransform.obj2Xml(typeof(Orders), OrderData.getOrders());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void create_order_Click_1(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox5.Text = "";
            this.textBox7.Text = "/interface_receive_order.php";
            this.textBox1.Text = DataTransform.obj2Xml(typeof(Orders), OrderData.getOrders());

            submit_btn.Click += new EventHandler(create_order);
        }

        private void update_order_Click(object sender, EventArgs e)
        {
            this.textBox7.Text = "/interface_modify_order.php";
            this.textBox1.Text = DataTransform.obj2Xml(typeof(Orders), OrderData.getOrders());

            this.textBox2.Text = "";
            this.textBox5.Text = "";
            submit_btn.Click += new EventHandler(create_order);
        }

        private void cancel_order_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            String t = time.ToString("yyyyMMddHH");
            this.textBox7.Text = "/interface_cancel_order.php";
            string xml = "<orders><order><order_serial_no>" + t +"</order_serial_no></order></orders>";
            this.textBox1.Text = DataTransform.xmlformat(xml);
            this.textBox2.Text = "";
            this.textBox5.Text = "";
            submit_btn.Click += new EventHandler(cancel_order);
        }

        private void reprint_order_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            String t = time.ToString("yyyyMMddHH");
            this.textBox7.Text = "/interface_cancel_order.php";
            string xml = "<orders><order><order_serial_no>" + t + "</order_serial_no></order></orders>";
            this.textBox1.Text = DataTransform.xmlformat(xml);
            this.textBox2.Text = "";
            this.textBox5.Text = "";
            submit_btn.Click += new EventHandler(reprint_order);
        }

        private void valid_order_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            String t = time.ToString("yyyyMMddHH");
            this.textBox7.Text = "/interface_cancel_order.php";
            string xml = "<orders><order><order_serial_no>" + t + "</order_serial_no></order></orders>";
            this.textBox1.Text = DataTransform.xmlformat(xml);
            this.textBox2.Text = "";
            this.textBox5.Text = "";
            submit_btn.Click += new EventHandler(valid_order);
        }


        private void search_order_Click(object sender, EventArgs e)
        {
            this.textBox7.Text = "/interface_order_info.php";
            DateTime time = DateTime.Now;
            String t = time.ToString("yyyyMMddHH");
            String xml = "<orders>"
		                     + "<order>"
		    	                    + "<order_serial_no>" + t +"</order_serial_no>"
                             + "</order>"
                              + "<order>"
                                    + "<mailno>2310000088543</mailno>"
                             + "</order>"
	                     + "</orders>";
            this.textBox1.Text = DataTransform.xmlformat(xml);
            this.textBox2.Text = "";
            this.textBox5.Text = "";
            submit_btn.Click += new EventHandler(search_order);
        }

        private void pdf_print_Click(object sender, EventArgs e)
        {
            this.textBox7.Text = "/interface_print_file.php";
            DateTime time = DateTime.Now;
            String t = time.ToString("yyyyMMddHH");
            String xml = "<orders>"
                              + "<order>"
                                    + "<mailno>2310000072162</mailno>"
                             + "</order>"
                         + "</orders>";
            this.textBox1.Text = DataTransform.xmlformat(xml);
            this.textBox2.Text = "";
            this.textBox5.Text = "";
            submit_btn.Click += new EventHandler(pdf_print_order);
        }



        private void submit_Click(object sender, EventArgs e)
        {
            
        }


        public void create_order(object sender, EventArgs e)
        {
            

            RequestVO requestVO = new RequestVO();
            requestVO.xmldata = this.textBox1.Text;
            requestVO.partnerid = this.textBox3.Text;
            requestVO.password = this.textBox4.Text;
            requestVO.version = "1.0";
            requestVO.request = "data";
            this.textBox2.Text = DataTransform.signData(requestVO);
            this.textBox5.Text = DataTransform.xmlformat(HttpClient.post(this.textBox6.Text + this.textBox7.Text, this.textBox2.Text));
        }

        public void create_order_mailno(object sender, EventArgs e)
        {
           /* RequestVO requestVO = new RequestVO();
            requestVO.xmldata = this.textBox1.Text;
            requestVO.partnerid = this.textBox3.Text;
            requestVO.password = this.textBox4.Text;
            requestVO.version = "1.0";
            requestVO.request = "data";
            this.textBox2.Text = DataTransform.signData(requestVO);
            this.textBox5.Text = DataTransform.xmlformat(HttpClient.post(this.textBox6.Text + this.textBox7.Text, this.textBox2.Text));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(this.textBox5.Text);
          
            XmlNode node =  doc.DocumentElement["response"]["pdf_info"];
            //打印数据可以从数据库直接获取，因为下订单的时候就已经返回了打印数据，这里只是为了测试
            */
            //打印的密文数据在下订单的时候会返回
            string printdata = "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";
            if (printdata == null || printdata == "") {
                MessageBox.Show("没有获取到打印数据");
                return;
            }
            string printurl = "http://localhost:9090/ydecx/service/mailpx/printDirect.pdf";
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("value", printdata);
            parameters.Add("tname", "mailtmp_s8");
            parameters.Add("docname", "mailpdfm1");
            HttpClient.post(printurl, parameters);

        }   

    

        public void cancel_order(object sender, EventArgs e)
        {
            RequestVO requestVO = new RequestVO();
            requestVO.xmldata = this.textBox1.Text;
            requestVO.partnerid = this.textBox3.Text;
            requestVO.password = this.textBox4.Text;
            requestVO.version = "1.0";
            requestVO.request = "cancel_order";
            this.textBox2.Text = DataTransform.signData(requestVO);
            this.textBox5.Text = DataTransform.xmlformat(HttpClient.post(this.textBox6.Text + this.textBox7.Text, this.textBox2.Text));
        }

        public void reprint_order(object sender, EventArgs e)
        {
            RequestVO requestVO = new RequestVO();
            requestVO.xmldata = this.textBox1.Text;
            requestVO.partnerid = this.textBox3.Text;
            requestVO.password = this.textBox4.Text;
            requestVO.version = "1.0";
            requestVO.request = "reprint_order";
            this.textBox2.Text = DataTransform.signData(requestVO);
            this.textBox5.Text = DataTransform.xmlformat(HttpClient.post(this.textBox6.Text + this.textBox7.Text, this.textBox2.Text));
        }

        public void valid_order(object sender, EventArgs e)
        {
            RequestVO requestVO = new RequestVO();
            requestVO.xmldata = this.textBox1.Text;
            requestVO.partnerid = this.textBox3.Text;
            requestVO.password = this.textBox4.Text;
            requestVO.version = "1.0";
            requestVO.request = "valid_order";
            this.textBox2.Text = DataTransform.signData(requestVO);
            this.textBox5.Text = DataTransform.xmlformat(HttpClient.post(this.textBox6.Text + this.textBox7.Text, this.textBox2.Text));
        }

        public void search_order(object sender, EventArgs e)
        {
            RequestVO requestVO = new RequestVO();
            requestVO.xmldata = this.textBox1.Text;
            requestVO.partnerid = this.textBox3.Text;
            requestVO.password = this.textBox4.Text;
            requestVO.version = "1.0";
            requestVO.request = "data";
            this.textBox2.Text = DataTransform.signData(requestVO);
            this.textBox5.Text = DataTransform.xmlformat(HttpClient.post(this.textBox6.Text + this.textBox7.Text, this.textBox2.Text));
        }


        public void pdf_print_order(object sender, EventArgs e)
        {
            RequestVO requestVO = new RequestVO();
            requestVO.xmldata = this.textBox1.Text;
            requestVO.partnerid = this.textBox3.Text;
            requestVO.password = this.textBox4.Text;
            requestVO.version = "1.0";
            requestVO.request = "data";
            this.textBox2.Text = DataTransform.signData(requestVO);

            try {
                HttpWebRequest request = WebRequest.Create(this.textBox6.Text + this.textBox7.Text) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] data = Encoding.UTF8.GetBytes(this.textBox2.Text.ToString());
                using (Stream s = request.GetRequestStream())
                {
                    s.Write(data, 0, data.Length);
                }
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;


                Stream stream = response.GetResponseStream();
                FileStream fs = new FileStream(@"C:\test.pdf", FileMode.Create);
                byte[] buffer = new byte[1024];
                int len = 0;
                while (true)
                {
                    len = stream.Read(buffer, 0, 1024);
                    if (len <= 0)
                    {
                        break;
                    }
                    fs.Write(buffer, 0, len);
                }
                stream.Close();
                fs.Close();

                this.textBox5.Text = "PDF文件创建成功, 保存路径为 C:\\test.pdf";
            } catch (Exception ex) {
                this.textBox5.Text = "PDF文件创建失败";
            }
       
        }

        /// <summary>
        /// 打印需要把gswin32c.exe,gsdll32.dll 放到同一路径下面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_2(object sender, EventArgs e)
        {

            this.textBox2.Text = "";
            this.textBox5.Text = "";
            this.textBox7.Text = "";
            this.textBox1.Text = "";

            DialogResult result1 = MessageBox.Show("打印前请先执行PDF打印查询接口，是否确认打印", "", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.No)
            {
                return;
            }

            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string pdfpath = @"C://test.pdf";
            PrintDocument fPrintDocument = new PrintDocument();
            string device = fPrintDocument.PrinterSettings.PrinterName;
            //模板有4*8， 4*6 两种，这里使用的是4*8.此地方最好采用配置设置打印的尺寸，避免后续修改模板大小后修改代码
            int width = 288; //打印的宽度： 英寸*72   //4*72 
            int height = 576; //高度
            try {
                System.Diagnostics.Process.Start(str + "//gswin32c.exe", "-dFIXEDMEDIA -dDEVICEWIDTHPOINTS=" + width +" -dDEVICEHEIGHTPOINTS="+ height +"  -dNoCancel -dNOPAUSE -dBATCH -q  -sDEVICE=mswinpr2  -sOutputFile=\"%printer%" + device + "\" \"" + pdfpath + "\"");
            } catch (Exception ex) {
            
            }
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox5.Text = "";
            this.textBox7.Text = "";
            this.textBox1.Text = "";

            DialogResult result1 = MessageBox.Show("打印前请先执行PDF打印查询接口，是否确认打印", "", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.No)
            {
                return;
            }

            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string pdfpath = @"C://test.pdf";
            PrintDocument fPrintDocument = new PrintDocument();
            string device = fPrintDocument.PrinterSettings.PrinterName;
            //模板有4*8， 4*6 两种，这里使用的是4*8.此地方最好采用配置设置打印的尺寸，避免后续修改模板大小后修改代码
            int width = 288; //打印的宽度： 英寸*72   //4*72 
            int height = 432; //高度
            try
            {
                System.Diagnostics.Process.Start(str + "//gswin32c.exe", "-dFIXEDMEDIA -dDEVICEWIDTHPOINTS=" + width +" -dDEVICEHEIGHTPOINTS="+ height +"  -dNoCancel -dNOPAUSE -dBATCH -q  -sDEVICE=mswinpr2  -sOutputFile=\"%printer%" + device + "\" \"" + pdfpath + "\" -c \"<</PageOffset [0 6]>> setpagedevice\"");
            }
            catch (Exception ex)
            {

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            this.textBox2.Text = "";
            this.textBox5.Text = "";
            this.textBox7.Text = "";
            this.textBox1.Text = "打印测试";

            submit_btn.Click += new EventHandler(create_order_mailno);
             
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox5.Text = "";
            this.textBox7.Text = "/interface_receive_order__mailno.php";
            this.textBox1.Text = DataTransform.obj2Xml(typeof(Orders), OrderData.getOrders());

            submit_btn.Click += new EventHandler(create_order);
        }

        
    }
}
 