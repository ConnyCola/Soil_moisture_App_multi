
//#define PANEL


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
        public int mois = 0;
        public int min, max;
        public int rssi;
        public bool error_rssi;
        public bool error_sensor;
        public int id;
        public int lastping_rssi = 10;
        public int lastping_sensor = 10;
        public int version;
        public int build;
        public bool active = false;

        //public int activeNode;
        

        public GroupBox gb;
        public Panel pl;
        public Button btn;
        public ProgressBar pb;
        public Label lb;

        private readonly Form1 form;
        public SensorNode(Form1 form)
        {

        }

        public SensorNode(Form1 form, int _id, string n, int x, int y, int v)
        {
            this.form = form;
            name = n;
            pos_x = x;
            pos_y = y;
            mois = v;
            id = _id;
            mois = 0;
            rssi = 0;
        }

        public void draw()
        {
#if PANEL
            pl = new Panel();
            pl.Location = new System.Drawing.Point(pos_x, pos_y);
            pl.Size = new System.Drawing.Size(60, 50);
            pl.Name = "pl" + name;
            pl.BackColor = System.Drawing.Color.LightGray;
#else
            gb = new GroupBox();
            gb.Location = new System.Drawing.Point(pos_x, pos_y);
            gb.Size = new System.Drawing.Size(60, 50);
            gb.Name = "gb" + name;
            gb.Text = name;
#endif

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
            lb.Text = mois.ToString() + " %";
            lb.Font = new System.Drawing.Font("Segoe Print", 10.162304F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            pb = new ProgressBar();
            pb.Location = new System.Drawing.Point(0, 45);
            pb.Size = new System.Drawing.Size(60, 5);
            pb.Name = "pb" + name;

            pb.Value = mois;



#if PANEL
            pl.Controls.Add(lb);
            pl.Controls.Add(pb);

            form.Controls.Add(pl);
            pl.Click += new System.EventHandler(this.gbClick);

#else
            gb.Controls.Add(lb);
            gb.Controls.Add(pb);


            form.Controls.Add(gb);
            gb.Click += new System.EventHandler(this.gbClick);
#endif
            ////gb.Refresh();
            

            lb.Click += new System.EventHandler(this.lbClick);
        }

        public void set_mois(int v)
        {
            mois = v;
            pb.Value = mois;
            lb.Text = mois.ToString() + " %";
#if PANEL
            if(id != form.active_Node)
                pl.BackColor = System.Drawing.Color.FromArgb(255-mois, 255-mois, 255);
#endif
        }

        public void set_rssi(int r)
        {
            rssi = r;
        }

        public void set_active(bool a)
        {
            active = a;
            if (active == true)
            {
                pb.Visible = true;
                lb.Visible = true;

#if PANEL
                pl.Visible = true;
                pl.Enabled = true;
#else
                gb.Visible = true;
                gb.Enabled = true;
#endif

            }
            else
            {
                pb.Visible = false;
                lb.Visible = false;
#if PANEL
                pl.Enabled = false;
#else
                gb.Enabled = false;
#endif
            }

        }

        public void highlight(bool b)
        {
            if (b)
            {
#if PANEL
                pl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                //pl.BackColor = System.Drawing.Color.LightBlue;
#else
                gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.916231F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
#endif
            }
            else
            {
#if PANEL
                //pl.BackColor = System.Drawing.Color.LightGray;
                pl.BorderStyle = System.Windows.Forms.BorderStyle.None;
#else
                gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.916231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
#endif
            }
        }

        public void redraw(){
            //TODO: doppelter check auf active_node
            if (id == form.active_Node)
                form.active_Node = id;
        }


        public void gbClick(object sender, EventArgs e)
        {
            //GroupBox gb_sender = sender as GroupBox;
            form.active_Node = id; //Int16.Parse(gb_sender.Name.Substring(6, 2));
        }

        public void lbClick(object sender, EventArgs e)
        {
            Label lb_sender = sender as Label;
            form.active_Node = id; //Int16.Parse(lb_sender.Name.Substring(6, 2));
        }
    }
}
