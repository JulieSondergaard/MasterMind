using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MasterMind
{
    public class GameManager
    {
        Ball ball = new Ball();
        Pin pin = new Pin();

        public void SetColor(Brush color)
        {
            ball.Color = color;
            Debug.WriteLine(color);          
        }
        public Brush GetColor()
        {
            Debug.WriteLine(ball.Color);
            return ball.Color;         
        }

        public void SetPinColor(string color)
        {
            pin.Color = color;
        }

        public string GetPinColor()
        {
            return pin.Color;
        }
    }
}
