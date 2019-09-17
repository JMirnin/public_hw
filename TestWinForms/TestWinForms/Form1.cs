using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace TestWinForms
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (BackColor == System.Drawing.Color.Red)
            {
                BackColor = System.Drawing.Color.Black;
            }
            else
            {
                BackColor = System.Drawing.Color.Red;
            }

            string pliv = GetPliv();
            if (pliv == "")
            {
                return;
            }

            var postData = "LOGIN_redirect=1&login=" + Login.Text + "&lreseted=1&pass=" + Password.Text + "&preseted=0&pliv=" + pliv + "&x=" + GetRandom(50, 130) + "&y=" + GetRandom(10, 40);
            var data = Encoding.GetEncoding("windows-1251").GetBytes(postData);

            const String CorrectAuthText = "Готовность армии:";

            var cookies = new CookieContainer();
            cookies = http_POST("https://www.heroeswm.ru/login.php", data, cookies);

            var responseString = http_GET("https://www.heroeswm.ru/home.php", cookies);

        

            if (responseString.Contains(CorrectAuthText))
            {
                MessageBox.Show("Авторизованы!");
            }
            else
            {
                MessageBox.Show("Не удалось авторизоваться!" + "\n" + responseString);
            }

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private string GetPliv()
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead("https://www.heroeswm.ru/");
            StreamReader reader = new StreamReader(data);
            string str = reader.ReadToEnd();

            reader.Close();

            int i = str.IndexOf("pliv value=");
            if ( i > -1)
            {
                str = str.Substring(i + 11);
                str = str.Substring(0, str.IndexOf("></td>"));
                return str;
            }
            else
            {

                DialogResult result = MessageBox.Show("pliv не найден! Продолжить авторизацию со случайным значением?", "Опасносте!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    return GetRandom(10000, 14000);
                }
                else
                    return "";
            }

        }

        private string GetRandom( int from, int to)
        {
            Random rnd = new Random();
            int value = rnd.Next(from, to);
            return Convert.ToString(value);
        }

        private string http_GET(string url, CookieContainer cookies)
        {

               HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
               req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:17.0) Gecko/20100101 Firefox/17.0";
               req.CookieContainer = cookies;
               req.Headers.Add("DNT", "1");
               req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
               HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
               var responseString = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding("windows-1251")).ReadToEnd();
               resp.Close();

            return responseString;

        }

        private CookieContainer http_POST(string url, byte[] data, CookieContainer cookies)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.CookieContainer = cookies;

            request.Host = "www.heroeswm.ru";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:69.0) Gecko/20100101 Firefox/69.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.KeepAlive = true;
            request.Referer = "https://www.heroeswm.ru/";
            request.Headers.Add("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("DNT", "1");
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.AllowAutoRedirect = true;

            var stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("windows-1251")).ReadToEnd();
            response.Close();

            return request.CookieContainer;
        }
    }
}