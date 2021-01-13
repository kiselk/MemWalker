using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace memwalker
{
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent();
        }


        Process[] tempProcesses;
        int[] IDsList;
   
        

        private void WriteTheList()
        {
            comboBox1.Items.Clear();
            tempProcesses = Process.GetProcesses();
            IDsList = new int[tempProcesses.Length];
            int i = 0;
            foreach (Process pro in tempProcesses)
            {
                if (pro.MainWindowTitle != "")
                {
                    comboBox1.Items.Add(pro.ProcessName + " - (" + pro.MainWindowTitle + ")");
                    IDsList[i] = pro.Id;
                    i++;
                }
                else
                {
                    comboBox1.Items.Add(pro.ProcessName);
                    IDsList[i] = pro.Id;
                    i++;
                }
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            WriteTheList();
        }

        private void Control_Load(object sender, EventArgs e)
        {
            WriteTheList();
        }
        public uint start = 0;
        public uint end = 0;
        private void calcAddr()
        {
            try
            {
               
                if (eStAddr.Text.Contains("x"))
                {
                    start = Convert.ToUInt32(eStAddr.Text.ToString().Substring(2, 8), 16);
                }
                else
                {
                    start = Convert.ToUInt32(eStAddr.Text.ToString(), 16);
                }

               
            }
            catch { MessageBox.Show("Invalid Start Address"); }

            try
            {
               
                if (eEndAddr.Text.Contains("x"))
                {
                    end = Convert.ToUInt32(eEndAddr.Text.ToString().Substring(2, 8), 16);
                }
                else
                {
                    end = Convert.ToUInt32(eEndAddr.Text.ToString(), 16);
                }

                
            }
            catch { MessageBox.Show("Invalid End Address"); }

        }
        public void bFly_Click(object sender, EventArgs e)
        {
            Form1 viewWindow = new Form1();
            viewWindow.pid = Convert.ToInt32(ePID.Text);
            viewWindow.pname = comboBox1.SelectedItem.ToString();
            calcAddr();
            calcZoom();

                viewWindow.startadd = start;    
           

                viewWindow.endadd = end;
                viewWindow.zoom = tZoom.Value;
                viewWindow.accuracy = tAccuracy.Value;
          
            viewWindow.Show();
            
        }

        public void writeProcessValues()
        {
            ePID.Text = IDsList[comboBox1.SelectedIndex].ToString();
            Process notepads;

            int processMem;
            notepads = Process.GetProcessById(Convert.ToInt32(IDsList[comboBox1.SelectedIndex]));
            processMem = notepads.PrivateMemorySize;


            eStAddr.Text = "0x00000000";
             string l_zeroes = "";
                string tail = processMem.ToString("X2");
                for (int i=0;i<8-tail.Length;i++)
                    l_zeroes+='0';
            eEndAddr.Text = "0x" + l_zeroes.ToString() + processMem.ToString("X2");

            
        }
        public void calcZoom()
        {
              int gAccuracy = 1;
         int gZoom = 1;
         int gWidth = 1024;
         int gHeight = 512;

         uint bytesToRead = end - start;// ReadStackSize;
         uint pixels = (uint)(gWidth * gHeight);
         int zoom = (int)Math.Ceiling(Math.Sqrt(Math.Ceiling(((float)(bytesToRead - 1) / (float)(pixels)))));

         int accuracy = 1;
         if (zoom < 1) zoom = 1;

            tZoom.Maximum = zoom; 
            tZoom.Value = zoom;
            tZoom.TickFrequency = zoom / 16;
            tAccuracy.Maximum = accuracy;
            tAccuracy.Value = accuracy;
            tAccuracy.TickFrequency = accuracy / 16;


         //int ReadStackSize = ClientRectangle.Width * ClientRectangle.Height * zoom * zoom;
         //endadd = startadd + (uint)ReadStackSize;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            writeProcessValues();
        }

        private void eStAddr_TextChanged(object sender, EventArgs e)
        {
            calcZoom();
        }

        private void eEndAddr_TextChanged(object sender, EventArgs e)
        {
            calcZoom();
        }
    }
}
