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
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace qlktxserver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Control.CheckForIllegalCrossThreadCalls = false;

            // Connect();
            //// chat minh1 = new chat();
            //// minh1.Connect();
            // Nhandulieu MINH = new Nhandulieu();
            // MINH.Connect();
        }
        IPEndPoint ipe;
        Socket client;
        TcpListener tcpListen;
        public void Connect()
        {
            ipe = new IPEndPoint(IPAddress.Any, 2017);
            tcpListen = new TcpListener(ipe);



            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    tcpListen.Start();
                    client = tcpListen.AcceptSocket();
                    Thread rec = new Thread(Recieve);
                    rec.IsBackground = true;
                    rec.Start(client);
                }

            });
            thread.IsBackground = true;
            thread.Start();


        }
        void Send(Socket client, DataTable a)
        {



            // byte[] data = Encoding.UTF8.GetBytes(textBox1.Text);
            client.Send(SerializeData(a));
            //  Addmessage(textBox1.Text);
        }
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }
        void Recieve(Object obj)
        {
            Socket client = obj as Socket;
            byte[] recv = new byte[1024000];
            client.Receive(recv);
            string s = Encoding.UTF8.GetString(recv);
            Addmessage(s);
        }
        void Addmessage(string Mess)
        {
            string query = "SELECT * FROM dbo.SINHVIEN WHERE MSSV=N'" + Mess + "'";
            DataProvider load = new DataProvider();

            DataTable result = load.ExecuteQuery(query);
            Send(client, result);
            client.Close();
            // richTextBox1.AppendText(Mess);
            // listView1.Items.Add(Mess);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
