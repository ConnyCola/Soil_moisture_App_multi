
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
        public int value = 0;
        public int min, max;
        public int rssi;
        public bool error; 
        

        public GroupBox gb;
        public Button btn;
        public ProgressBar pb;
        public Label lb;

        private readonly Form1 form;
        public SensorNode(Form1 form)
        {

        }

        public SensorNode(Form1 form, string n, int x, int y, int v)
        {
            this.form = form;
            name = n;
            pos_x = x;
            pos_y = y;
            value = v;
        }

        public void draw()
        {

            gb = new GroupBox();
            gb.Location = new System.Drawing.Point(pos_x, pos_y);
            gb.Size = new System.Drawing.Size(60, 50);
            gb.Name = "gb" + name;
            gb.Text = name;


            btn = new Button();
            btn.Location = new System.Drawing.Point(5, 10);
            btn.Name = "btn" + name;
            btn.Size = new System.Drawing.Size(50, 20);
            btn.TabIndex = 100;
            btn.Text = name;
            btn.UseVisualStyleBackColor = true;

            lb = new Label();
            lb.Name = "lb" + name;
            lb.Location = new System.Drawing.Point(2, 20);
            lb.Size = new System.Drawing.Size(56, 20);
            lb.Text = value.ToString() + " %";
            lb.Font = new System.Drawing.Font("Segoe Print", 10.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            pb = new ProgressBar();
            pb.Location = new System.Drawing.Point(0, 45);
            pb.Size = new System.Drawing.Size(60, 5);
            pb.Name = "pb" + name;

            pb.Value = value;


            //gb.Controls.Add(btn);
            gb.Controls.Add(lb);
            gb.Controls.Add(pb);
            //gb.Refresh();
            form.Controls.Add(gb);

            gb.Click += new System.EventHandler(this.gbClick);
            lb.Click += new System.EventHandler(this.lbClick);
        }

        public void changeValue(int v)
        {
            value = v;
            pb.Value = value;
            lb.Text = value.ToString() + " %";

            
        }

        public void gbClick(object sender, EventArgs e)
        {
            GroupBox gb_sender = sender as GroupBox;

            form.active_Node = Int16.Parse(gb_sender.Name.Substring(6, 2));

        }

        public void lbClick(object sender, EventArgs e)
        {
            Label lb_sender = sender as Label;
            form.active_Node = Int16.Parse(lb_sender.Name.Substring(6, 2));

        }
    }
}
