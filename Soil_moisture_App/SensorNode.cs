
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

namespace Soil_moisture_App
{
    public class SensorNode
    {
        public int pos_x, pos_y;
        public string name;
        public static int value = 0;

        public GroupBox gb;
        public Button btn;
        public ProgressBar pb;
        public Label lb;

        public SensorNode()
        {

        }

        public SensorNode(string n, int x, int y, int v)
        {
            name = n;
            pos_x = x;
            pos_y = y;
            value = v;
        }

        public void draw()
        {

            gb = new GroupBox();
            gb.Location = new System.Drawing.Point(pos_x, pos_y);
            gb.Size = new System.Drawing.Size(50, 50);
            gb.Name = "gb" + name;
            gb.Text = name;


            btn = new Button();
            btn.Location = new System.Drawing.Point(5, 10);
            btn.Name = "btn" + name;
            btn.Size = new System.Drawing.Size(40, 20);
            btn.TabIndex = 100;
            btn.Text = name;
            btn.UseVisualStyleBackColor = true;

            lb = new Label();
            lb.Name = "lb" + name;
            lb.Location = new System.Drawing.Point(2, 20);
            lb.Size = new System.Drawing.Size(46, 20);
            lb.Text = value.ToString() + " %";
            lb.Font = new System.Drawing.Font("Segoe Print", 10.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            pb = new ProgressBar();
            pb.Location = new System.Drawing.Point(0, 45);
            pb.Size = new System.Drawing.Size(50, 5);
            pb.Name = "pb" + name;

            pb.Value = value;


            //gb.Controls.Add(btn);
            gb.Controls.Add(lb);
            gb.Controls.Add(pb);
            gb.Refresh();
            Form1.ActiveForm.Controls.Add(gb);
            Form1.ActiveForm.Refresh();

            gb.Click += new System.EventHandler(this.gbClick);
        }

        public void changeValue(int v)
        {
            value = v;
            pb.Value = value;
            lb.Text = value.ToString() + " %";

            
        }

        public void gbClick(object sender, EventArgs e)
        {
            string s = sender.ToString();
            int i = Int16.Parse(s.Substring(38, 2));
            MessageBox.Show("You clicked on " + i.ToString());
        }
    }
}
