using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly object attachmentsPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                MailMessage mymail = new MailMessage();
                mymail.From = new System.Net.Mail.MailAddress("发送者邮箱");
                mymail.To.Add("接收者邮箱");
                mymail.Subject = "题目";
                mymail.Body = "内容";
                mymail.IsBodyHtml = true;
                SmtpClient smtpclient = new SmtpClient();
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpclient.Host = "smtp.发送者邮箱平台.com";
                smtpclient.Credentials = new System.Net.NetworkCredential("发送者邮箱", "发送者邮箱smtp密码");
                try
                {
                    smtpclient.Send(mymail);
                    Console.WriteLine("发送成功");


                }
                catch (Exception ex)
                {
                    Console.WriteLine("发送邮件失败.请检查是否为qq邮箱，并且没有被防护软件拦截");

                }
            }
        }
    }
} 

