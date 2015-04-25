using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Run_Grumpy_Run
{
    public partial class Nurse : UserControl
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Nurse(int x, int y)
        {
            InitializeComponent();

            this.X = x;
            this.Y = y;
            this.Draw();
        }

        public void Draw()
        {
            Canvas.SetLeft(this, this.X);
            Canvas.SetTop(this, this.Y);
        }
    }
}
