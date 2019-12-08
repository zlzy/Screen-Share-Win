using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using GodSharp.Sockets;

namespace ScreenStreamer
{
    public partial class Form1 : Form
    {
        TcpClient[] m_socs;
        Thread[] m_threads;

        string[] m_ipAddresses;
        bool m_isRunning;
        public Form1()
        {
            InitializeComponent();
            m_socs = new TcpClient[4];
            m_threads = new Thread[4];
            m_ipAddresses = new string[4];
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (m_isRunning)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (m_threads[i] != null)
                        m_threads[i].Abort();
                }
                btn_start.Text = "Start";
                m_isRunning = false;
                EnableIPBox(true);
            }
            else
            {
                if (!ValidateIPAddress())
                    return;

                for (int i = 0; i < 4; i++)
                {
                    if (m_ipAddresses[i].Length > 0)
                        StartSend(i);
                }
                m_isRunning = true;
                btn_start.Text = "Stop";
                EnableIPBox(false);
            }
        }

        void EnableIPBox(bool enable)
        {
            txt_ip1.Enabled = enable;
            txt_ip2.Enabled = enable;
            txt_ip3.Enabled = enable;
            txt_ip4.Enabled = enable;
        }
        void StartSend(int idx)
        {
            m_threads[idx] = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    if (m_socs[idx] != null)
                    {
                        if (m_socs[idx].Running)
                        {
                            Bitmap bmp = CaptureImage(idx);
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                //ms.SetLength(2);
                                byte[] buf = new byte[ms.Length + 4];
                                buf[ms.Length] = 0x0d;
                                buf[ms.Length + 1] = 0x0a;
                                buf[ms.Length + 2] = 0x0d;
                                buf[ms.Length + 3] = 0x0a;
                                Console.WriteLine("Sent: {0}", buf.Length);
                                Buffer.BlockCopy(ms.GetBuffer(), 0, buf, 0, (int)ms.Length);
                                try
                                {
                                    int len = m_socs[idx].Connection.Send(buf);
                                    Console.WriteLine("sent len: {0}", len);
                                }
                                catch {
                                    m_socs[idx] = null;
                                }
                            }
                        }
                    }
                    else
                    {
                        m_socs[idx] = new TcpClient(m_ipAddresses[idx], 7788);
                        try
                        {
                            m_socs[idx].Start();
                            m_socs[idx].OnDisconnected = (c) => { m_socs[idx] = null; };
                            m_socs[idx].OnException = (c) => { m_socs[idx] = null; };
                            m_socs[idx].OnStopped = (c) => { m_socs[idx] = null; };
                        }
                        catch {
                            m_socs[idx] = null;
                            Thread.Sleep(3000);
                        }
                        
                    }
                    Thread.Sleep(40);
                }
            }));
            m_threads[idx].IsBackground = true;
            m_threads[idx].Start();
        }

        bool ValidateIPAddress() {
            for (int i = 0; i < 4; i++)
                m_ipAddresses[i] = "";
            if (txt_ip1.Text.Length > 0)
            {
                try
                {
                    IPAddress.Parse(txt_ip1.Text);
                    m_ipAddresses[0] = txt_ip1.Text;
                }
                catch
                {
                    MessageBox.Show("Please input correct ip address in top left");
                    return false;
                }
            }
            if (txt_ip2.Text.Length > 0)
            {
                try
                {
                    IPAddress.Parse(txt_ip2.Text);
                    m_ipAddresses[1] = txt_ip2.Text;
                }
                catch
                {
                    MessageBox.Show("Please input correct ip address in top right");
                    return false;
                }
            }
            if (txt_ip3.Text.Length > 0)
            {
                try
                {
                    IPAddress.Parse(txt_ip3.Text);
                    m_ipAddresses[2] = txt_ip3.Text;
                }
                catch
                {
                    MessageBox.Show("Please input correct ip address in bottom left");
                    return false;
                }
            }
            if (txt_ip4.Text.Length > 0)
            {
                try
                {
                    IPAddress.Parse(txt_ip4.Text);
                    m_ipAddresses[3] = txt_ip4.Text;
                }
                catch
                {
                    MessageBox.Show("Please input correct ip address in bottom right");
                    return false;
                }
            }
            return true;
        }
        public static Bitmap CaptureImage(int idx)
        {
            Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));
            Bitmap bitmap = new Bitmap(bounds.Width / 2, bounds.Height / 2);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                switch (idx)
                {
                    case 0:
                        g.CopyFromScreen(new Point(0, 0), Point.Empty, bounds.Size);
                        break;
                    case 1:
                        g.CopyFromScreen(new Point(bounds.Width / 2, 0), Point.Empty, bounds.Size);
                        break;
                    case 2:
                        g.CopyFromScreen(new Point(0, bounds.Height / 2), Point.Empty, bounds.Size);
                        break;
                    case 3:
                        g.CopyFromScreen(new Point(bounds.Width / 2, bounds.Height / 2), Point.Empty, bounds.Size);
                        break;
                }
                
            }
            return bitmap;
        }
    }
}
