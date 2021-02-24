using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBack
{
    public class Backend
    {
        const double dt = 0.1;
        const double g = 9.81;
        const double C = 0.15;
        const double rho = 1.29;
        double t = 0;
        int tick = 0;
        double k, vx, vy, x, y;
        Point ans = new Point();

        static void Main(string[] args)
        {
        }
        public void GivingFunc(double a, double v0, double y0, double m, double S)
        {
            k = 0.5 * C * S * rho / m;
            vx = Speed(v0, func.cos, a);
            vy = Speed(v0, func.sin, a);
            ans.x = 0;
            ans.y = y0;
        }

        public Point NextStep()
        {
            vx = vx - k * vx * Math.Sqrt(vx * vx + vy * vy) * dt;
            vy = vy - (g + k * vy * Math.Sqrt(vx * vx + vy * vy)) * dt;

            ans.x = ans.x + vx * dt;
            ans.y = ans.y + vy * dt;
            return ans;
        }
        
        public double IncreaseT(double t)
        {
            t += dt;
            return t;
        }
        public int IncreaseTick(int tick)
        {
            tick++;
            return tick;
        }
        
        private double DegToRad(double a)
        {
            return a * Math.PI / 180;
        }

        private double Speed(double v0, func f, double a)
        {
            if (f == func.cos)
            {
                return v0 * Math.Cos(DegToRad(a));
            }
            else
            {
                return v0 * Math.Sin(DegToRad(a));
            }
        }

    }

    public enum func
    {
        cos,
        sin
    }
}
