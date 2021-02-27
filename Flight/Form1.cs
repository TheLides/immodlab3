using System;
using FlightBack;
using System.Windows.Forms;

namespace Flight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Backend newBack = new Backend();

        int tick;
        double t;
        Point Coordinates;
        private void btStart_Click(object sender, EventArgs e)
        {
            newBack.GivingFunc((double)edAngle.Value, (double)edSpeed.Value, (double)edHeight.Value, (double)edWeight.Value, (double)edSquare.Value);
            
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, (double)edHeight.Value);

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            newBack.IncreaseT();
            newBack.IncreaseTick();
            label7.Text = newBack.tick.ToString();
            label8.Text = newBack.t.ToString();
            Coordinates = newBack.NextStep();

            chart1.Series[0].Points.AddXY(Coordinates.x, Coordinates.y);
            if (Coordinates.y <= 0) timer1.Stop();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
