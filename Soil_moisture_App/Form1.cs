//#define DEMO

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;


namespace Soil_moisture_App
{

    public enum CMDs : byte
    {
        CMD_MOIS = (byte)'A',
        CMD_VOLT = (byte)'B',
        CMD_MIN = (byte)'C',
        CMD_MAX = (byte)'D',
        CMD_CALI = (byte)'E',
        CMD_DRY = (byte)'F',
        CMD_WET = (byte)'G',
        CMD_FIN = (byte)'H',
        CMD_TEST = (byte)'I',
        CMD_VERS = (byte)'J',
        CMD_RSSI = (byte)'K',
        CMD_ERROR = (byte)'Z'
    }


    public struct cmdStruct
    {
        public byte cmd;
        public int val1, val2;
    }

    public partial class Form1 : Form
    {
        public int MAX_NODES = 100;
        public int loop_delay_time;
        public SynchronizationContext mainThread;
        public System.IO.Ports.SerialPort sport;
        public CalibrationForm CaliForm;

        SensorNode[] Node;

        public volatile bool _backgroundPause = true;

        public string[] CMD_array = {
            "MOIS",
            "VOLT",
            "MIN ",
            "MAX ",
            "CALI",
            "DRY ",
            "WET ",
            "FIN ",
            "TEST",
            "VERS",
            "RSSI",
            "ERROR"
        };

        public struct cmdStruct
        {
            public int id;
            public byte cmd;
            public int val1;
            public int val2;
        } ;

        enum FormComModes : byte
        {   CaliStart,
            CaliDry,
            CaliWet,
            CaliFin,
            CaliError,
            CaliEnd
        };

        volatile int initFlag = 0;
        volatile bool wireless_Flag = false;

        public StringBuilder csv;
        public string filePath = "\\\\Mac\\Home\\Desktop\\log.csv";
        public bool logToFile_Flag = false;

        public Thread bgThread = null;

        public Form1()
        {
            InitializeComponent();
            disconBTN.Enabled = false;
            caliBTN.Enabled = false;
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
                comPort_comboBox.Items.Add(s);

            //debug code
            if (comPort_comboBox.Items.Contains("COM12"))
                comPort_comboBox.Text = "COM12";
            else
            { if (comPort_comboBox.Items.Count != 0)
                    comPort_comboBox.SelectedIndex = 0;
            }

            

            moisLab.Text = "--%";
            rssiLab.Text = "--";

            csv = new StringBuilder();

            mainThread = SynchronizationContext.Current;
            if (mainThread == null) mainThread = new SynchronizationContext();

        }


        public void serialport_connect(String port, int baudrate, Parity parity, int databits, StopBits stopbits)
        {
            if (port != "") { 
                sport = new System.IO.Ports.SerialPort(
                port, baudrate, parity, databits, stopbits);

                try
                {
                    sport.Open();
                    disconBTN.Enabled = true;
                    conBTN.Enabled = false;
                    caliBTN.Enabled = true;
                    txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "Connected\n");
                    sport.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);

                    // Create the thread object. This does not start the thread.
                    bgThread = new Thread(new ThreadStart(BackgroundThread));

                    bgThread.IsBackground = true;
                    bgThread.Start();
                    txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "Background Thread started and Paused\n");
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error"); }}

            
        }

        public void send_command(int id, byte cmd, byte val1, byte val2)
        {
            byte[] b = new byte[4];
            //TODO: change to Node ID

            b[0] = (byte)((id/10)+'0');
            b[1] = (byte)((id % 10) + '0');
            b[2] = cmd;
            b[3] = 0x0A; // '\n'

            if (wireless_Flag == true)
            {
                //send 4 chars!
                sport.Write(b, 0, 4);
            }
            else
            {
                //send only 1 char!
                sport.Write(b, 2, 1);
            }
            

            mainThread.Send((object state) =>
            {
                //txtReceiveBox.AppendText("[" + get_dtn() + "] " + "cmd: " + Convert.ToChar(cmd) + "  val1: " + val1.ToString() + "  val2: " + val2.ToString() + "\n");
            }, null);
        }

        public String get_dtn_time()
        {
            DateTime dt = DateTime.Now;
            //return dt.ToShortTimeString();
            return dt.ToLongTimeString();
        }

        public String get_dtn_date()
        {
            DateTime dt = DateTime.Now;
            return dt.ToShortDateString();
        }

        public void CaliFormCallback(byte m)
        {
            button1.Text = m.ToString();
            if (m == (byte)FormComModes.CaliStart)
            {
                send_command(active_Node, (byte)CMDs.CMD_CALI, 1, 0);
                Thread.Sleep(200);
                #if DEMO
                CaliForm.changeContext((byte)FormComModes.CaliDry);
                #endif
            }
            else if (m == (byte)FormComModes.CaliDry)
            {
                send_command(active_Node, (byte)CMDs.CMD_DRY, 1, 0);
                Thread.Sleep(200);
                #if DEMO
                CaliForm.changeContext((byte)FormComModes.CaliWet);
                #endif
            }
            else if (m == (byte)FormComModes.CaliWet)
            {
                send_command(active_Node, (byte)CMDs.CMD_WET, 1, 0);
                Thread.Sleep(200);
            }
            else if ((m == (byte)FormComModes.CaliFin) || (m == (byte)FormComModes.CaliError))
            {
                send_command(active_Node, (byte)CMDs.CMD_FIN, 1, 0);
                Thread.Sleep(1000);

                send_command(active_Node, (byte)CMDs.CMD_MIN, 0, 0);
                Thread.Sleep(300);

                send_command(active_Node, (byte)CMDs.CMD_MAX, 0, 0);

                Thread.Sleep(300);
                CaliForm.Close();

                
                _backgroundPause = false;

            }
            else if (m == (byte)FormComModes.CaliEnd)
            {
                _backgroundPause = false;
            }


        }

        private void saveToCSV(cmdStruct cmd){
            String newLine = string.Format("{0};{1};{2};{3};{4}", get_dtn_date() + " " + get_dtn_time(), cmd.id, CMD_array[Convert.ToByte(cmd.cmd) - 'A'], cmd.val1.ToString(), cmd.val2.ToString());
            csv.AppendLine(newLine);

            if (csv.Length > 2000)
            {
                File.AppendAllText(filePath, csv.ToString());
                csv.Remove(0, csv.Length);
            }
        }

        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String str = sport.ReadLine();

            cmdStruct cmdBack = decodeReceivedCmd(str);
            if (cmdBack.id != -1)
            {
                mainThread.Send((object state) =>
                {
                    if (processReceivedCmd(cmdBack)){
                        txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "rec: cmd: " + CMD_array[Convert.ToByte(cmdBack.cmd) - 'A'] + "  val1: " + cmdBack.val1.ToString() + "  val2: " + cmdBack.val2.ToString() + "\n");

                        if (logToFile_Flag == true)
                            saveToCSV(cmdBack);
                  
                        //if(cmdBack.cmd == (byte)CMDs.CMD_RSSI)
                        //    txtReceiveBox.AppendText("[" + get_dtn() + "] " + "rec: cmd: " + str.ToString() + "\n");
                    }
                    else
                        txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "rec: cmd: " + str.ToString() + "\n");

                }, null);
            }


        }

        private cmdStruct decodeReceivedCmd(string str)
        {
            // Protocoll
            //   | ID | CMD | val1 |val2 | \n |
            //   | 2B | 1B  |  4B  | 4B  | 1B |
            //   9    11    12     16     20
            //   0    2     3      7      11

            cmdStruct cmdBack = new cmdStruct();

            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);

            if (wireless_Flag == true && bytes[0] != (byte)CMDs.CMD_VERS)
            {
                cmdBack.id = Int16.Parse(str.Substring(0, 2));
                cmdBack.cmd = bytes[2 * sizeof(char)];
                if (str.Length >= 7)
                    cmdBack.val1 = Int16.Parse(str.Substring(3, 4));
                //TODO: length is somehow 11 but no conntent
                if (str.Length >= 11)
                    cmdBack.val2 = Int16.Parse(str.Substring(7, 4));

                return cmdBack;
            }
            else
            {
                cmdBack.cmd = bytes[0];
                if (str.Length >= 5)
                    cmdBack.val1 = Int16.Parse(str.Substring(1, 4));
                if (str.Length >= 9)
                    cmdBack.val2 = Int16.Parse(str.Substring(5, 4));

                return cmdBack;
            }
            
        }

        private bool processReceivedCmd(cmdStruct c)
        {
            bool back = true;
            if (txtReceiveBox.TextLength >= 20000)
                txtReceiveBox.Text =  txtReceiveBox.Text.Substring(17000, 3000);
            switch (c.cmd)
            {
                case (byte)CMDs.CMD_MOIS:
                    /*
                    moisLab.Text = c.val1.ToString() + "%";
                    progressBar1.Value = c.val1;

                    // Timer for moist sensing / sensor connected?
                    pictureBox2.Visible = false;
                    timer2.Stop();
                    timer2.Start();
                    */
                    Node[c.id].set_mois(c.val1);
                    Node[c.id].redraw();

                    Node[c.id].lastping_sensor = 0;


                    break;
                case (byte)CMDs.CMD_VOLT:
                    break;
                case (byte)CMDs.CMD_MIN:
                    minMoisLab.Text = c.val1.ToString();
                    break;
                case (byte)CMDs.CMD_MAX:
                    maxMoisLab.Text = c.val1.ToString();
                    break;
                case (byte)CMDs.CMD_CALI:
                    if(c.val1 == 1)
                        CaliForm.changeContext((byte)FormComModes.CaliDry);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                case (byte)CMDs.CMD_DRY:
                    if ((c.val1 >= 0) && (c.val1 <= 1024))
                        CaliForm.changeContext((byte)FormComModes.CaliWet);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                case (byte)CMDs.CMD_WET:
                    if ((c.val1 >= 0) && (c.val1 <= 1024))
                        CaliForm.changeContext((byte)FormComModes.CaliFin);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                case (byte)CMDs.CMD_TEST:
                    moisLab.Text = c.val1.ToString();
                    txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "received TEST" + "\n");
                    _backgroundPause = false;
                    break;
                    /*
                case (byte)CMDs.CMD_FIN:
                    if ((byte)c.val1 == 1)
                        CaliForm.changeContext((byte)FormComModes.CaliFin);
                    else
                        CaliForm.changeContext((byte)FormComModes.CaliError);
                    break;
                     */
                case(byte)CMDs.CMD_VERS:
                    initFlag = 1;
                    txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "Software VERSION : " + c.val1.ToString() + "\n");
                    txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "         BUILD   : " + c.val2.ToString() + "\n");

                    versionLab.Text = "v" + Convert.ToString(c.val1/100) + "." + Convert.ToString(c.val1%100);
                    versionLab.Text += "  build:" + Convert.ToString(c.val2);

                    if (c.val2 >= 1000)
                    {  //Veriosn with Wireless if build no. > 1000
                        pictureBoxRssi.Visible = true;
                        wireless_Flag = true;
                    }

                    Node[c.id].set_active(true);


                    break;
                case(byte)CMDs.CMD_RSSI:
                    txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "received RSSI :" + c.val1.ToString() +"\n");

                    
                    Node[c.id].set_rssi(c.val1);
                    Node[c.id].lastping_rssi = 0;
                    Node[c.id].redraw();

                    /*
                    rssiLab.Text = "-" + c.val1.ToString();
                    rssiLab.Show();


                    progressBarRSSI.Minimum = 0;
                    progressBarRSSI.Maximum = 40;
                    if((c.val1 <= 120) && (c.val1 >= 80))
                        progressBarRSSI.Value = 120 - c.val1;

                    if (c.val1 <= 94)
                        pictureBox1.Image = Soil_moisture_App.Properties.Resources.wifi3;
                    else if(c.val1 <= 105) 
                        pictureBox1.Image = Soil_moisture_App.Properties.Resources.wifi_2;
                    else if(c.val1 <= 110)
                        pictureBox1.Image = Soil_moisture_App.Properties.Resources.wifi_1;
                    else
                        pictureBox1.Image = Soil_moisture_App.Properties.Resources.wifi_0;
                    */

                    //start timout timer

                    break;
                default:
                    back = false;
                    break;
            }
            return back;
        }




        private void conBTN_Click(object sender, EventArgs e)
        {
            String port = comPort_comboBox.Text;
            int baudrate = 9600;
            Parity parity = System.IO.Ports.Parity.None;
            int databits = 8;
            StopBits stopbits = System.IO.Ports.StopBits.One;
            
            serialport_connect(port, baudrate, parity, databits, stopbits);

            //check the Version to check for right Com Port
            int tout = 20;
            initFlag = 0;

            for (int i = 0; i < MAX_NODES; i++)
            {
                send_command(i, (byte)CMDs.CMD_VERS, 0, 0);
                Thread.Sleep(100);
                //send a second time in case of a wirless communication
                send_command(i, (byte)CMDs.CMD_VERS, 0, 0);
                trackBar1.Value = i;
                label7.Text = i.ToString();
            }
            /*
            send_command(active_Node, (byte)CMDs.CMD_VERS, 0, 0);
            Thread.Sleep(300);
            //send a second time in case of a wirless communication
            send_command(active_Node, (byte)CMDs.CMD_VERS, 0, 0);
            */

            /*

            Thread.Sleep(300);
            send_command(active_Node, (byte)CMDs.CMD_MIN, 0, 0);
            Thread.Sleep(300);
            send_command(active_Node, (byte)CMDs.CMD_MAX, 0, 0);
            Thread.Sleep(300);
            send_command(active_Node, (byte)CMDs.CMD_VERS, 0, 0);
            Thread.Sleep(300);
            
            send_command(active_Node, (byte)CMDs.CMD_MOIS, 0, 0);
             
             */
            timerErrorSensor.Start();
            timerErrorRssi.Start();

            Thread.Sleep(300);
            //Thread.Sleep(1000);

            while (initFlag != 1)
            {
                Thread.Sleep(100);
                tout--;
                if (tout == 0)
                {
                    disconBTN_Click(null, null);
                    MessageBox.Show("Wrong Com Port!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            _backgroundPause = false;


        }

        private void sendBTN_Click(object sender, EventArgs e)
        {
            String data = txtDataSendBox.Text;
            sport.Write(data);
            txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "Sent: " + data + "\n");
        }

        private void disconBTN_Click(object sender, EventArgs e)
        {
            _backgroundPause = true;

            if (bgThread != null)
                bgThread.Abort();

            Thread.Sleep(500);

            if (sport != null)
            {
                if (sport.IsOpen)
                {
                    while (sport.BytesToRead != 0 && sport.BytesToRead != 0) ;
                    sport.Close();

                    caliBTN.Enabled = false;
                    conBTN.Enabled = true;
                    txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "Disconnected\n");
                    disconBTN.Enabled = false;
                }
            }

            wireless_Flag = false;
            pictureBoxRssi.Visible = false;
        }

        private void caliBTN_Click(object sender, EventArgs e)
        {
            _backgroundPause = true;
            txtReceiveBox.AppendText("[" + get_dtn_time() + "] " + "Start Calibration!\n");
            CaliForm = new CalibrationForm(this);
            CaliForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Button btn = new Button();
            btn.Location = new System.Drawing.Point(100, 100);
            btn.Name = "dyn_BTN";
            btn.Size = new System.Drawing.Size(193, 61);
            btn.TabIndex = 100;
            btn.Text = "dyn_BTN";
            btn.UseVisualStyleBackColor = true;
            //btn.Click += new System.EventHandler(this.dyn_BTN_Click);
            this.Controls.Add(btn);
            Soil_moisture_App
            this.Refresh();
             */

            Node = new SensorNode[100];

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if ((i + j * 10) < MAX_NODES) {
                        Node[i+j*10] = new SensorNode(this, i+j*10, "Node" + j + i, i * 65 + 150, j*60 + 20, 100- (i+j*10));
                        Node[i+j*10].draw(); 
                    }

                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void BackgroundThread()
        {
            int runs = 0;
            while (true)
            {
                int scanedNode = 0;
                while (!_backgroundPause)
                {
                    scanedNode += 1;
                    if (scanedNode == MAX_NODES)
                        scanedNode = 0;

                    Thread.Sleep(loop_delay_time);
                    runs++;
                    mainThread.Send((object state) =>
                    {
                        //txtReceiveBox.AppendText("[" + get_dtn() + "] " + "background thread: working... " + runs + "\n");
                    
                    }, null);


                    if ((runs % 5 == 0) && (wireless_Flag == true)){
                        send_command(active_Node, (byte)CMDs.CMD_RSSI, 1, 0);
                        runs = 0;
                    }
                    else
                        send_command(active_Node, (byte)CMDs.CMD_MOIS, 1, 0);
                    
                    Thread.Sleep(loop_delay_time);
                    send_command(scanedNode, (byte)CMDs.CMD_MOIS, 1, 0);

                    Thread.Sleep(loop_delay_time);
                    send_command(scanedNode, (byte)CMDs.CMD_RSSI, 1, 0);
                    

                    mainThread.Send((object state) =>
                    {
                        trackBar1.Value = scanedNode;
                        label7.Text = scanedNode.ToString();
                    }, null);


                    //_backgroundPause = true;
                }
                Console.WriteLine("worker thread: terminating gracefully.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (_backgroundPause == true)
                _backgroundPause = false;
            else
                _backgroundPause = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            send_command(active_Node, (byte)CMDs.CMD_DRY, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            send_command(active_Node, (byte)CMDs.CMD_WET, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            send_command(active_Node, (byte)CMDs.CMD_MIN, 0, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            send_command(active_Node, (byte)CMDs.CMD_MAX, 0, 0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MessageBox.Show("Expert mode can manipulate and potentioly damage the Sensors.\nYou will use it at my own risk!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Form.ActiveForm.Width = 825;
            }
            ExpertMode(checkBox1.Checked);
        }

        private void ExpertMode(bool b)
        {
            button1.Visible = b;
            button2.Visible = b;
            button3.Visible = b;
            button4.Visible = b;
            button5.Visible = b;
            button6.Visible = b;

            label5.Visible = b;
            label6.Visible = b;
            label7.Visible = b;
            label8.Visible = b;

            trackBar1.Visible = b;
            trackBar2.Visible = b;

            txtReceiveBox.Visible = b;
            txtDataSendBox.Visible = b;

            sendBTN.Visible = b;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form frm = sender as Form;
            frm.Width = 161;
            frm.Width = 825;
            frm.Height = 780;

            loop_delay_time = trackBar2.Value;
            ExpertMode(false);
            pictureBoxRssi.Visible = false;
            pictureBoxErrorSensor.Visible = false;
            label8.Text = loop_delay_time.ToString();

            Node = new SensorNode[100];

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if ((i + j * 10) < MAX_NODES)
                    {
                        Node[i + j * 10] = new SensorNode(this, i + j * 10, "Node" + j + i, i * 65 + 150, j * 60 + 20, 100 - (i + j * 10));
                        Node[i + j * 10].draw();
                        Node[i + j * 10].set_active(false);
                    }

                }
            }

            //checkBox1.Checked = true;
        }

        private void Form1_FormClosing(object sender, FormClosedEventHandler e)
        {
        }

        private void comPort_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comPort_comboBox_DropDown(object sender, EventArgs e)
        {
            comPort_comboBox.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
                comPort_comboBox.Items.Add(s);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            disconBTN_Click(null, null);
        }

        private void timerErrorRssi_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < MAX_NODES; i++)
			{
			    Node[i].lastping_rssi += 1;

                if (Node[i].lastping_rssi >= 10)
                {
                    Node[i].error_rssi = true;
                    Node[i].set_active(false);
                    if (i == active_Node)
                        Node[i].redraw();
                }
                else if ((i == active_Node) && (Node[i].lastping_rssi >= 2))
                {
                    Node[i].error_rssi = true;
                    Node[i].set_active(false);
                    if (i == active_Node)
                        Node[i].redraw();
                }
                else
                {
                    Node[i].error_rssi = false;
                    Node[i].set_active(true);

                }

                
			}
            
            //pictureBox1.Image = Soil_moisture_App.Properties.Resources.wifi_err;
        }

        private void timerErrorSensor_Tick(object sender, EventArgs e)
        {
            if (_backgroundPause == false)
            {
                //pictureBox2.Visible = true;
                //moisLab.Text = "";

                for (int i = 0; i < MAX_NODES; i++)
                {
                    Node[i].lastping_sensor += 1;

                    //if (Node[i].lastping_sensor >= 2)
                    //    Node[i].error_sensor = true;
                    //else
                    //    Node[i].error_sensor = false;

                    if (Node[i].lastping_sensor >= 10)
                    {
                        Node[i].error_sensor = true;
                        if (i == active_Node)
                            Node[i].redraw();
                    }
                    else if ((i == active_Node) && (Node[i].lastping_sensor >= 2))
                    {
                        Node[i].error_sensor = false;
                        if (i == active_Node)
                            Node[i].redraw();
                    }
                    else
                    {
                        Node[i].error_sensor = false;
                    }

                }
            }

        }


        public int active_Node
        {
            get {   return Int16.Parse(groupBoxActiveNode.Text.Substring(4, 2)); }
            set {   moisLab.Text = Node[value].mois.ToString() + "%";
                int old_value = Int16.Parse(groupBoxActiveNode.Text.Substring(4, 2));

                if (value != old_value)
                {
                    Node[value].highlight(true);
                    Node[old_value].highlight(false);
                }


                // Mois ProgessBAR
                    progressBarActiveNode.Value = Node[value].mois;
                // GroupBox
                    groupBoxActiveNode.Text = Node[value].name;

                // RSSI
                    rssiLab.Text = "-" + Node[value].rssi.ToString();
                    rssiLab.Show();
                   
                    progressBarRSSI.Minimum = 0;
                    progressBarRSSI.Maximum = 40;
                    if((Node[value].rssi <= 120) && (Node[value].rssi >= 80))
                      progressBarRSSI.Value = 120 - Node[value].rssi;

                    if (Node[value].rssi <= 94)
                      pictureBoxRssi.Image = Soil_moisture_App.Properties.Resources.wifi3;
                    else if (Node[value].rssi <= 105) 
                      pictureBoxRssi.Image = Soil_moisture_App.Properties.Resources.wifi_2;
                    else if (Node[value].rssi <= 110)
                      pictureBoxRssi.Image = Soil_moisture_App.Properties.Resources.wifi_1;
                    else
                      pictureBoxRssi.Image = Soil_moisture_App.Properties.Resources.wifi_0;
                    
                // ERROR
                    if (Node[value].error_rssi == true)
                        pictureBoxRssi.Image = Soil_moisture_App.Properties.Resources.wifi_err;
                    if (Node[value].error_sensor == true)
                        pictureBoxErrorSensor.Visible = true;
                    else
                        pictureBoxErrorSensor.Visible = false;

                    

            }
            
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            loop_delay_time = trackBar2.Value;
            label8.Text = loop_delay_time.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timerErrorRssi.Stop();
            timerErrorSensor.Stop();
            //txtReceiveBox.AppendText(get_dtn_date());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.FileName = "log.csv";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                filePath = file;
                button8.Text = file;
                logToFile_Flag = true;
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }
    }
}