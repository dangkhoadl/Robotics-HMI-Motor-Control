using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
namespace PID_CONTROL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khoa het cac Texbox va Button khi chua Connect cong COM
            txtKD.Enabled = false;
            txtKI.Enabled = false;
            txtKP.Enabled = false;
            PbStart.Enabled = false;
            Pbup.Enabled = false;
            Pbdown.Enabled = false;
            txtResult.Enabled = false;
            txtSpeed.Enabled = false;
            txtKD.Text = "";
            txtKI.Text = "";
            txtKP.Text = "";
            txtResult.Text = "";
            txtSpeed.Text = "";
        }

        private void PbConect_Click(object sender, EventArgs e)
        {
            if (Lbss.Text == "Disconnect")
            {
                COM.PortName = Cbcom.Text; //Chon cong COM ket voi voi VXL
                COM.Open();
                Lbss.Text = "Connect";
                PbConect.Text = "Disconnect";
                // Sau khi nhan Connect cho phep nhap du lieu de gui len VXL
                txtKD.Enabled = true;
                txtKI.Enabled = true;
                txtKP.Enabled = true;
                PbStart.Enabled = true;
                Pbup.Enabled = true;
                Pbdown.Enabled = true;
                txtResult.Enabled = true;
                txtSpeed.Enabled = true;
            }
            else
            {
                // Khi tat cong Ket noi ta set lai gia tri ban dau nhu khi Form Load
                COM.Close();
                Lbss.Text = "Disconnect";
                PbConect.Text = "Connect";
                txtKD.Enabled = false;
                txtKI.Enabled = false;
                txtKP.Enabled = false;
                PbStart.Enabled = false;
                Pbup.Enabled = false;
                Pbdown.Enabled = false;
                txtResult.Enabled = false;
                txtSpeed.Enabled = false;
                txtKD.Text = "";
                txtKI.Text = "";
                txtKP.Text = "";
                txtResult.Text = "";
                txtSpeed.Text = "";
            }

        }
        // Su dung Timer 1 de cap nhat ten cac cong COM khi dang ket noi
        int intlen = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            if (intlen != ports.Length)
            {
                intlen = ports.Length;
                Cbcom.Items.Clear();
                for (int j = 0; j < intlen; j++)
                {
                    Cbcom.Items.Add(ports[j]);
                }
                Cbcom.Text = ports[0];
            }
            timer1.Enabled = false;
        }
        string s;
        string s1, s2, s3, s4;
        
        private void PbStart_Click(object sender, EventArgs e)
        {
            int a, b, c,d;
            
            if ((txtKD.Text == "") | (txtKI.Text == "") | (txtKP.Text == "") | (txtSpeed.Text == ""))
                MessageBox.Show("Chua nhap cac he so");
            else
            {
                a = Convert.ToInt32(txtKD.Text);
                b = Convert.ToInt32(txtKI.Text);
                c = Convert.ToInt32(txtKP.Text);
                d = Convert.ToInt32(txtSpeed.Text);
                if ((a > 99) | (b > 99) | (c > 99))
                {
                    MessageBox.Show("Cac he so <100");
                }
                else
                {
                    if (PbStart.Text == "START")
                    {
                        PbStart.Text = "STOP";
                        // Xu ly cac he so KI KP KD truoc khi gui du lieu
                        if (txtKD.TextLength == 1) s1 = "0" + txtKD.Text;
                        if (txtKI.TextLength == 1) s2 = "0" + txtKI.Text;
                        if (txtKP.TextLength == 1) s3 = "0" + txtKP.Text;
                        if (txtSpeed.TextLength == 1) s4 = "00" + txtSpeed.Text;
                        if (txtSpeed.TextLength == 2) s4 = "0" + txtSpeed.Text;
                        txtKD.Enabled = false;
                        txtKI.Enabled = false;
                        txtKP.Enabled = false;
                        // Chuoi sau khi du lieu gom 9 bit: KI, KD, KP mỗi hệ số 2 bit, Van toc mong muon 3 bit
                        s = s1 + s2 + s3 + s4;
                        txtResult.Text = s;
                        COM.WriteLine(s);
                     }
                    else
                    {
                        PbStart.Text = "START";
                        txtKD.Enabled = true;
                        txtKI.Enabled = true;
                        txtKP.Enabled = true;
                        txtSpeed.Enabled = true;
                        // Muon dung Dong co ta chi viec gui 00000000
                        s = "000000000";
                        COM.WriteLine(s);

                    }
                }
            }
        }


        private delegate void Dldisplay(string Value);
        private void display(string Value)
        {
            if (txtResult.InvokeRequired )
            {
                Dldisplay sd = new Dldisplay(display);
                txtResult.Invoke(sd, new object[] { Value });
            }
            else
            {
               txtResult.Text = Value;
            }
            }
        string data;
        private void ONCOM(object sender, SerialDataReceivedEventArgs e)
        {
            // Vector ngat khi nhan du lieu
            if ((PbConect.Text == "Disconnect") )
            {
                data = (string)COM.ReadLine();
            }
            display(data);
            

        }

    

        private void Pbup_Click(object sender, EventArgs e)
        {
            double a;
            Double.TryParse(s4,out a);// Chuyen string sang so
            a = a + 1;// tang bien len 1 khi nhan nut UP
            s4=Convert.ToString(a);// Chuyen nguoc sang sang chuoi
            txtSpeed.Text = s4;
            // Xu ly chuoi truoc khi gui du lieu len VXL
            if (txtSpeed.TextLength == 1) s4 = "00" + txtSpeed.Text;
            if (txtSpeed.TextLength == 2) s4 = "0" + txtSpeed.Text;
            s = s1 + s2 + s3 + s4;
            COM.WriteLine(s);
          }

        private void Pbdown_Click(object sender, EventArgs e)
        {
            double a;
            Double.TryParse(s4, out a);// Chuyen string sang so
            a = a - 1;// giam bien len 1 khi nhan nut UP
            s4 = Convert.ToString(a);// Chuyen nguoc sang sang chuoi
            txtSpeed.Text = s4;
            // Xu ly chuoi truoc khi gui du lieu len VXL
            if (txtSpeed.TextLength == 1) s4 = "00" + txtSpeed.Text;
            if (txtSpeed.TextLength == 2) s4 = "0" + txtSpeed.Text;
            s = s1 + s2 + s3 + s4;
            COM.WriteLine(s);
        }
        }
}
