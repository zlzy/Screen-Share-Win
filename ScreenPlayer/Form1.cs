using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ScreenPlayer
{
    public partial class Form1 : Form
    {
        byte[] m_buf;
        int m_len;
        byte[] m_tmpBuf;
        byte[] endFlagbuf;
        byte[] endFlag;
        public Form1()
        {
            InitializeComponent();
            m_buf = new byte[1024 * 1024 * 10];
            m_tmpBuf = new byte[1024 * 1024 * 10];
            endFlagbuf = new byte[4];
            endFlag = new byte[4];
            endFlag[0] = 0x0d;
            endFlag[1] = 0x0a;
            endFlag[2] = 0x0d;
            endFlag[3] = 0x0a;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;

            TcpListener l = new TcpListener(IPAddress.Any, 7788);
            l.Start();

            Thread t = new Thread(new ThreadStart(() => {
                while (true)
                {
                    Socket s = l.AcceptSocket();
                    Stream network = new NetworkStream(s);
                    network.BeginRead(m_tmpBuf, 0, m_tmpBuf.Length, ReceiveCallback, network);
                }
            }));
            t.IsBackground = true;
            t.Start();
        }

        void InvokeHelper(MethodInvoker invoker)
        {
            try
            {
                if (InvokeRequired)
                    Invoke(invoker);
                else
                    invoker.Invoke();
            }
            catch { }
        }

        void ReceiveCallback(IAsyncResult ar)
        {
            NetworkStream network = (NetworkStream)ar.AsyncState;
            int len = network.EndRead(ar);
            bool isend = false;
            int lackLen = 0;
            for (int i = 0; i < len - 3; i++)
            {
                Buffer.BlockCopy(m_tmpBuf, i, endFlagbuf, 0, 4);
                if (endFlag.SequenceEqual(endFlagbuf))
                {
                    isend = true;
                    lackLen = i;
                }
            }
            if (!isend)
            {
                Buffer.BlockCopy(m_tmpBuf, 0, m_buf, m_len, len);
                m_len += len;
            }
            else
            {
                Buffer.BlockCopy(m_tmpBuf, 0, m_buf, m_len, lackLen);
                m_len += lackLen;
                try
                {
                    MemoryStream ms = new MemoryStream(m_buf, 0, m_len);
                    Image img = Bitmap.FromStream(ms);
                    InvokeHelper(() =>
                    {
                        if (pbx_render.Image != null) pbx_render.Image.Dispose();
                        pbx_render.Image = img;
                    });
                }
                catch(Exception ex) { Console.WriteLine(ex.Message); }

                m_len = 0;
            }
            if (m_len > 1024 * 1024 * 5)
                m_len = 0;

            try { network.BeginRead(m_tmpBuf, 0, m_tmpBuf.Length, ReceiveCallback, network); }catch{}
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}


