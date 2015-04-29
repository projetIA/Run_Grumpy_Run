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
	public partial class player : UserControl
	{
        //position du perso
        public int X { get; set; }
        public int Y { get; set; }

        public int image = 1;

        public DateTime horloge;

        public Canvas cnvPere { get; set; }

		public player()
		{
			// Requis pour initialiser des variables
			InitializeComponent();
            //init de la position
            this.X = 64;
            this.Y = 32;

            this.horloge = DateTime.Now;
		}

		private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            // Affichage au bon endroit
            Canvas.SetLeft(this, this.X);
            Canvas.SetTop(this, this.Y);
        }

        public void Draw()
        {
            Canvas.SetLeft(this, this.X);
            Canvas.SetTop(this, this.Y);

        }

        public void MiseAJour(MainPage mp)
        {
            if (DateTime.Now > horloge.AddMilliseconds(190))
            {
                horloge = DateTime.Now;
                int new_x = this.X;
                int new_y = this.Y;

                // Déplacement haut / bas
                if (EtatClavier.ToucheEnfoncee(Key.Z))
                {
                    new_y -= 32;
                }
                if (EtatClavier.ToucheEnfoncee(Key.S))
                {
                    new_y += 32;
                }
                // Déplacement gauche / droite
                if (EtatClavier.ToucheEnfoncee(Key.D))
                {
                    new_x += 32;
                }
                if (EtatClavier.ToucheEnfoncee(Key.Q))
                {
                    new_x -= 32;
                }
                // Vérification du déplacement
                if (mp.Zone_OK(new_x, new_y, (int)this.rect.Width, (int)this.rect.Height))
                {
                    this.X = new_x;
                    this.Y = new_y;

                }
                if (EtatClavier.ToucheEnfoncee(Key.Z))
                {
                    ImageBrush brush = new ImageBrush();
                    brush.ImageSource = new BitmapImage(new Uri(@"images/player/grumpy_back" + image + ".png", UriKind.Relative));
                    rect.Fill = brush;
                }
                if (EtatClavier.ToucheEnfoncee(Key.S))
                {
                    ImageBrush brush = new ImageBrush();
                    brush.ImageSource = new BitmapImage(new Uri(@"images/player/grumpy" + image + ".png", UriKind.Relative));
                    rect.Fill = brush;
                }
                // Déplacement gauche / droite
                if (EtatClavier.ToucheEnfoncee(Key.D))
                {
                    ImageBrush brush = new ImageBrush();
                    brush.ImageSource = new BitmapImage(new Uri(@"images/player/grumpy_right" + image + ".png", UriKind.Relative));
                    rect.Fill = brush;
                }
                if (EtatClavier.ToucheEnfoncee(Key.Q))
                {
                    ImageBrush brush = new ImageBrush();
                    brush.ImageSource = new BitmapImage(new Uri(@"images/player/grumpy_left" + image + ".png", UriKind.Relative));
                    rect.Fill = brush;
                }

                image += 1;
                if (image > 3)
                {
                    image = 1;
                }

                // Affichage à la nouvelle position
                this.Draw();
            }
        }
	}
}