using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Net.Http;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /*static readonly HttpClient client = new HttpClient();

        static TcpClient tcpClient = new TcpClient();
        public static readonly byte[] ip = new byte[] { 10, 0, 0, 11 };

        static IPAddress ipAddress = new IPAddress(ip);
        IPEndPoint hostEndPoint = new IPEndPoint(ipAddress, 80);
        static Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        ASCIIEncoding asen = new ASCIIEncoding();*/

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//
        {
            controlBtn();
        }

        private string ip;
        private async void button1_Click(object sender, EventArgs e)
        {
            
            try
            {

                pictureBox1.Image = Properties.Resources.ledGreen;
                using (var client = new HttpClient())
                 {
                    HttpResponseMessage request = await client.GetAsync("http://"+ip+"//led1_on");
                    
                 }

                


            }
            catch
            {

            }
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Properties.Resources.ledRed;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage request = await client.GetAsync("http://"+ip+"//led1_off");
                   
                }
               
            }
            catch
            {

            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            try
            {
                pictureBox2.Image = Properties.Resources.ledGreen;

                using (var client = new HttpClient())
                {
                    HttpResponseMessage request = await client.GetAsync("http://"+ip+"//led2_on");
                    
                }
               
            }
            catch
            {

            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = Properties.Resources.ledRed;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage request = await client.GetAsync("http://"+ip+"//led2_off");
                    
                }
                
            }
            catch
            {

            }

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox3.Image = Properties.Resources.ledGreen;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage request = await client.GetAsync("http://"+ip+"//led3_on");
                   
                }
                
            }
            catch
            {

            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox3.Image = Properties.Resources.ledRed;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage request = await client.GetAsync("http://" + ip + "//led3_off");
                   
                }
                
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                ip = textBox1.Text;
                textBox1.Enabled = false;
                bt_cleanIP.Enabled = true;
                button7.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;

            }
            else
            {
                MessageBox.Show("Insira um IP");
            }
        }

        private async void bt_cleanIP_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Enabled = true;
                button7.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                bt_cleanIP.Enabled = false;
                pictureBox1.Image = Properties.Resources.ledRed;
                pictureBox2.Image = Properties.Resources.ledRed;
                pictureBox3.Image = Properties.Resources.ledRed;
                textBox1.Text = null;
                
                using (var client = new HttpClient())
                {
                    HttpResponseMessage request = await client.GetAsync("http://" + ip + "//leds_off");
                   
                }
                
               
            }
            catch
            {

            }

            ip = null;

        }

        private void controlBtn()
        {
            if(ip == null | ip == "")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                bt_cleanIP.Enabled = false;


            }
        }
    }
}
