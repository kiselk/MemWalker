using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
  using System.Drawing.Drawing2D;
 using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace memwalker

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Graphics screen;

        public int[,] visible = new int[10000,10000];

       
     

 
        public static SolidBrush solidColorBrush = new SolidBrush(Color.Black);
        public static Pen coloredPen = new Pen(solidColorBrush);

        
        // draw various shapes on Form
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          // references to object we will use
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }
        private Process tempProcess;

        public Process process
        {
            set
            {
                tempProcess = value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            
        }




        class ProcessMemoryReader
        {

            public ProcessMemoryReader()
            {
            }

            /// <summary>	
            /// Process from which to read		
            /// </summary>
            public Process ReadProcess
            {
                get
                {
                    return m_ReadProcess;
                }
                set
                {
                    m_ReadProcess = value;
                }
            }

            private Process m_ReadProcess = null;

            private IntPtr m_hProcess = IntPtr.Zero;

            public void OpenProcess()
            {
                //			m_hProcess = ProcessMemoryReaderApi.OpenProcess(ProcessMemoryReaderApi.PROCESS_VM_READ, 1, (uint)m_ReadProcess.Id);
                ProcessMemoryReaderApi.ProcessAccessType access;
                access = ProcessMemoryReaderApi.ProcessAccessType.PROCESS_VM_READ
                    | ProcessMemoryReaderApi.ProcessAccessType.PROCESS_VM_WRITE
                    | ProcessMemoryReaderApi.ProcessAccessType.PROCESS_VM_OPERATION;
                m_hProcess = ProcessMemoryReaderApi.OpenProcess((uint)access, 1, (uint)m_ReadProcess.Id);
            }

            public void CloseHandle()
            {
                try
                {
                    int iRetValue;
                    iRetValue = ProcessMemoryReaderApi.CloseHandle(m_hProcess);
                    if (iRetValue == 0)
                    {
                        throw new Exception("CloseHandle failed");
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }

            public byte[] ReadProcessMemory(IntPtr MemoryAddress, uint bytesToRead, out int bytesRead)
            {
                byte[] buffer = new byte[bytesToRead];

                IntPtr ptrBytesRead;
                ProcessMemoryReaderApi.ReadProcessMemory(m_hProcess, MemoryAddress, buffer, bytesToRead, out ptrBytesRead);

                bytesRead = ptrBytesRead.ToInt32();

                return buffer;
            }

            public void WriteProcessMemory(IntPtr MemoryAddress, byte[] bytesToWrite, out int bytesWritten)
            {
                IntPtr ptrBytesWritten;
                ProcessMemoryReaderApi.WriteProcessMemory(m_hProcess, MemoryAddress, bytesToWrite, (uint)bytesToWrite.Length, out ptrBytesWritten);

                bytesWritten = ptrBytesWritten.ToInt32();
            }


            /// <summary>
            /// ProcessMemoryReader is a class that enables direct reading a process memory
            /// </summary>
            class ProcessMemoryReaderApi
            {
                // constants information can be found in <winnt.h>
                [Flags]
                public enum ProcessAccessType
                {
                    PROCESS_TERMINATE = (0x0001),
                    PROCESS_CREATE_THREAD = (0x0002),
                    PROCESS_SET_SESSIONID = (0x0004),
                    PROCESS_VM_OPERATION = (0x0008),
                    PROCESS_VM_READ = (0x0010),
                    PROCESS_VM_WRITE = (0x0020),
                    PROCESS_DUP_HANDLE = (0x0040),
                    PROCESS_CREATE_PROCESS = (0x0080),
                    PROCESS_SET_QUOTA = (0x0100),
                    PROCESS_SET_INFORMATION = (0x0200),
                    PROCESS_QUERY_INFORMATION = (0x0400)
                }

                // function declarations are found in the MSDN and in <winbase.h> 

                //		HANDLE OpenProcess(
                //			DWORD dwDesiredAccess,  // access flag
                //			BOOL bInheritHandle,    // handle inheritance option
                //			DWORD dwProcessId       // process identifier
                //			);
                [DllImport("kernel32.dll")]
                public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

                //		BOOL CloseHandle(
                //			HANDLE hObject   // handle to object
                //			);
                [DllImport("kernel32.dll")]
                public static extern Int32 CloseHandle(IntPtr hObject);

                //		BOOL ReadProcessMemory(
                //			HANDLE hProcess,              // handle to the process
                //			LPCVOID lpBaseAddress,        // base of memory area
                //			LPVOID lpBuffer,              // data buffer
                //			SIZE_T nSize,                 // number of bytes to read
                //			SIZE_T * lpNumberOfBytesRead  // number of bytes read
                //			);
                [DllImport("kernel32.dll")]
                public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

                //		BOOL WriteProcessMemory(
                //			HANDLE hProcess,                // handle to process
                //			LPVOID lpBaseAddress,           // base of memory area
                //			LPCVOID lpBuffer,               // data buffer
                //			SIZE_T nSize,                   // count of bytes to write
                //			SIZE_T * lpNumberOfBytesWritten // count of bytes written
                //			);
                [DllImport("kernel32.dll")]
                public static extern Int32 WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesWritten);


            }
        }
        
        public uint startadd = 0;
        public uint endadd = 0;
        public int zoom = 4;
       // public int accuracy = 3;
        public int pid=5088;
        public bool ctrl_down = false;
        public string pname="";
        public int gWidth = 1024;
        public int gHeight = 512;
        public void evt_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int delta = e.Delta / 120;
            if (ctrl_down)
            {
                accuracy -= delta;

                if (accuracy > zoom) accuracy = zoom ;
                if (accuracy < 1) accuracy = 1;
            }
            else
            {
                zoom -= delta;
                if (zoom < 1) zoom = 1;
                if (accuracy > zoom) accuracy = zoom;
                if (accuracy < 1) accuracy = 1;
            }

            DrawScreen();
        }
 public int accuracy = 1;
        public void DrawScreen()
        {
            
          //  
               // screen.Clear(Color.Black); 
            if (screen != null)
            {// end method DrawShapesForm_Paint


                //Start and End addresses to be scaned.
                screen.Dispose();
                screen = null;
                GC.Collect();
                screen = this.CreateGraphics();


                
                IntPtr lastAddress;
                int ReadStackSize = ClientRectangle.Width * ClientRectangle.Height*zoom*zoom;
                endadd = startadd + (uint)ReadStackSize;
                //New thread object to run the scan in
                Thread thread;
                //Check if the thread is already defined or not.

                //process = Process.GetProcessById(2956);
                ProcessMemoryReader reader;
                reader = new ProcessMemoryReader();
                reader.ReadProcess = Process.GetProcessById(pid);
                reader.OpenProcess();
               
                if (zoom < 1) zoom = 1;
                int bytesReadSize;
                
                
                SolidBrush solidColorBrush = new SolidBrush(Color.Red);
                Pen coloredPen = new Pen(solidColorBrush);
                Bitmap tempbitmap=new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                Graphics g = Graphics.FromImage(tempbitmap);
               
                g.FillRectangle(Brushes.Black, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
                g.Save();
               
 byte[] array;
                uint zoom_accuracy=(uint)((float)(zoom)/(float)(accuracy));
 //uint zoom_accuracy = (uint)((float)(zoom) / (float)(accuracy));
               uint bytes_per_height_byte_line = (uint)(ClientRectangle.Height) * (uint)(zoom);
                uint bytes_per_height_pixel_line = (uint)(ClientRectangle.Height) * (uint)(zoom*zoom);
                for (int i = 0; i < ClientRectangle.Width; i++)
                {
                    array = reader.ReadProcessMemory((IntPtr)(startadd + bytes_per_height_pixel_line * i), (uint)(bytes_per_height_byte_line * accuracy), out bytesReadSize);
                    for (int j = 0; j < ClientRectangle.Height; j++)
                    {
                        //coloredPen.Color = Color.FromArgb(0, array[i * (ClientRectangle.Height - 1) + j], 0);
                        //screen.DrawLine(coloredPen,  i,j, i, j+1);

                        try
                        {
                            uint colorsum = 0;
                            bool bad = false;


                            for (int xz = 0; xz < accuracy ; xz++)
                                for (int yz = 0; yz < accuracy; yz++)
                                {

                                    colorsum += array[(uint)(j*zoom + xz* zoom*accuracy + yz * accuracy)];

                                   // colorsum += array[(uint)(j * zoom * xz + yz)];



                                }





                            //tempbitmap.SetPixel(i, j, Color.FromArgb(0, array[i * (ClientRectangle.Height - 1) + j], 0));
                            
                            //if (colorsum != 0)
                            //{
                                colorsum = (uint)((long)colorsum /( accuracy * accuracy));
                            //colorsum = (uint)((long)(colorsum) / (long)(accuracy * accuracy)); 
                            //if (tempbitmap.GetPixel(i, j).G != colorsum)
                                tempbitmap.SetPixel(i, j, Color.FromArgb(0, (int)colorsum, 0));

                          //  }


                        }
                        catch { }
                        //graphicsObject.
                    }
                }
                screen.DrawImageUnscaled(tempbitmap, 0, 0);
                Font printFont = new Font("Courier", 10);
                PointF point = new PointF(0,0);

                string l_zeroes = "";
                string tail = startadd.ToString("X2");
                for (int i=0;i<8-tail.Length;i++)
                    l_zeroes+='0';

                screen.DrawString(" Name: " + pname.ToString(), printFont, Brushes.White, 0.0f, 0.0f);
                screen.DrawString("  PID: " + pid.ToString(), printFont, Brushes.White, 0.0f, 10.0f);
                screen.DrawString("Start: 0x"+l_zeroes + tail, printFont, Brushes.White, 0.0f, 20.0f);
                 l_zeroes = "";
                 tail = endadd.ToString("X2");
                for (int i = 0; i < 8 - tail.Length; i++)
                    l_zeroes += '0';
                screen.DrawString("  End: 0x" + l_zeroes + tail, printFont, Brushes.White, 0.0f, 30.0f);
                int bytes_num= (int)(endadd-startadd);


                screen.DrawString("Bytes: " + bytes_num.ToString("n0"), printFont, Brushes.White, 0.0f, 40.0f);
                screen.DrawString(" Zoom: x" + zoom.ToString(), printFont, Brushes.White, 0.0f, 50.0f);
                screen.DrawString(" Step: " + accuracy.ToString(), printFont, Brushes.White, 0.0f, 60.0f);
                g.Dispose();
            }

           // screen.Dispose();
            GC.Collect();


        }


        private void Form1_Shown(object sender, System.EventArgs e)
        {
            uint bytesToRead = endadd - startadd;// ReadStackSize;
            uint pixels = (uint)(ClientRectangle.Width * ClientRectangle.Height);
            //zoom = (int)Math.Ceiling(Math.Sqrt(Math.Ceiling(((float)(bytesToRead - 1) / (float)(pixels)))));
            Width = gWidth;
            Height = gHeight;
            screen = null;
            screen = this.CreateGraphics();
            DrawScreen();
         

        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F5) DrawScreen();
            if (e.KeyCode == Keys.Left) {
                uint temp = (uint)(ClientRectangle.Width * ClientRectangle.Height * zoom * zoom);
                if (temp < startadd) { startadd -= temp; endadd -= temp; }
                else { endadd -= temp - startadd; startadd=0; }
                DrawScreen();
            }
            if (e.KeyCode == Keys.Right) {
                uint temp = (uint)(ClientRectangle.Width * ClientRectangle.Height * zoom * zoom);
                if ((temp +endadd)<0xFFFFFFFF) { startadd += temp; endadd += temp; }
                else { startadd += temp -(0xFFFFFFFF-endadd); endadd = 0; }
                DrawScreen();
            }
            if (e.KeyCode == Keys.Up) { startadd -= 0x10000000; DrawScreen(); }
            if (e.KeyCode == Keys.Down) { startadd += 0x10000000; DrawScreen(); }
            if (e.KeyCode == Keys.Home) { zoom=zoom-1; if (zoom < 1) zoom = 1; DrawScreen(); }
            if (e.KeyCode == Keys.End) { zoom=zoom+1; DrawScreen(); }
            if (e.KeyCode == Keys.ControlKey) { ctrl_down = true; }
            
        }

        private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) { ctrl_down = false; }
        }

        private void timer2_Tick(object sender, System.EventArgs e)
        {
            timer2.Interval = (accuracy) * 500;
            DrawScreen();
        }
        public bool is_dragging=false;
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //timer2.Stop();
            is_dragging = true;
            x = Cursor.Position.X;
            x_old = x;
        }

        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //timer2.Start();
            is_dragging = false;
        }
        public int x_old;
        public int x;
        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(is_dragging == true)
            {
                x = Cursor.Position.X;
                if ((x_old - x) < 0)
                {
                    startadd -= (uint)(1 * ClientRectangle.Height) * (uint)(zoom * zoom);
                    endadd -= (uint)(1 * ClientRectangle.Height) * (uint)(zoom * zoom);
                
                }
                else
                {
                    startadd += (uint)(32 * ClientRectangle.Height) * (uint)(zoom * zoom);
                    endadd += (uint)(32 * ClientRectangle.Height) * (uint)(zoom * zoom);
                }
                if (startadd < 0) startadd = 0;
            x_old=x;
            //DrawScreen();
            }
        
        }
    } // end class DrawShapesForm
}