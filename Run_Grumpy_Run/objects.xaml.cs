using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Run_Grumpy_Run
{
	public partial class objects : UserControl
	{
        public int X { get; set; }
        public int Y { get; set; }
        public bool etat { get; set; }
        public string type { get; set; }


        public objects(int x, int y, string _type)
		{
			// Requis pour initialiser des variables
			InitializeComponent();

            this.X = x;
            this.Y = y;
            this.etat = false;
            this.type = _type;
            // source de l'image
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"images/objects/" + type + ".png", UriKind.Relative));
            brush.Stretch = Stretch.Uniform;
            rect.Fill = brush;
            
            this.Draw();
		}

        public void Draw()
        {
            Canvas.SetLeft(this, this.X);
            Canvas.SetTop(this, this.Y);
            if (this.etat)
            {
                this.Visibility = System.Windows.Visibility.Collapsed;
            }

        }
        public void MiseAJour(int x, int y)
        {
            if (((x - 32 == this.X) || (x + 32 == this.X) || (x == this.X))
                && ((y == this.Y) || (y + 32 == this.Y) || (y == this.Y))
                && (EtatClavier.ToucheEnfoncee(Key.E)))
            {
                this.etat = true;
            }
            this.Draw();
        }

	}
}