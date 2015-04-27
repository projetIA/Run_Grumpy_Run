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
    public partial class MainPage : UserControl
    {
        private List<murs> liste_fixe;
        private List<Nurse> liste_ennemis;
        public bool GameOver;

        public MainPage()
        {
            InitializeComponent();

            this.GameOver = false;

            //liste murs
            liste_fixe = new List<murs>();
            liste_fixe.Add(new murs(224, 32));
            liste_fixe.Add(new murs(320, 32));
            liste_fixe.Add(new murs(512, 32));
            liste_fixe.Add(new murs(608, 32));
            liste_fixe.Add(new murs(710, 32));

            for (int x = 32; x <= 160; x += 32 )
            {
                 liste_fixe.Add(new murs(x, 192));
            }
            for (int y = 96; y <= 192; y += 32)
            {
                liste_fixe.Add(new murs(224, y));
            }


            liste_ennemis = new List<Nurse>();
            
            Nurse nurse0 = new Nurse("Billy Bob",416, 160, this);
            this.LayoutRoot.Children.Add(nurse0);
            liste_ennemis.Add(nurse0);

            Nurse  nurse1= new Nurse("Marty", 292, 256, this);
            this.LayoutRoot.Children.Add(nurse1);
            liste_ennemis.Add(nurse1);

            Nurse nurse2 = new Nurse("Kathyusha", 448, 352, this);
            this.LayoutRoot.Children.Add(nurse2);
            liste_ennemis.Add(nurse2);
        }

        public bool Zone_OK(int _x, int _y, int _width, int _height)
        {

            // Test murs extérieurs
            if (_x < 32 || _x > this.LayoutRoot.ActualWidth - _width -32)
            {
                return false;
            }
            if (_y < 32 || _y > this.LayoutRoot.ActualHeight - _height -32)
            {
                return false;
            }
            // Test murs
            foreach (murs mur in liste_fixe)
            {
                if ((mur.x == _x) && (mur.y == _y))
                {
                    return false;
                }
            }

<<<<<<< HEAD
=======
            // test mobs
            foreach (Nurse nurse in liste_ennemis)
            {
                if( (nurse.X == _x) && (nurse.Y == _y) )
                {
                    return false;
                }
            }
>>>>>>> 785d7a8d721b63ea5a28674b4ce46d772ec2a7af
            // A rajouter plus tard
            // Tout est OK
            return true;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO : ajoutez ici l'implémentation du gestionnaire d'événements.
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            
            EtatClavier.Ecouter(this);
            x_player.cnvPere = this.LayoutRoot;
        }

        public void CompositionTarget_Rendering(object sender, EventArgs e)
        {

            if (this.GameOver == false)
            {

                x_player.MiseAJour(this);

                foreach (Nurse nurse in liste_ennemis)
                {
                    nurse.MiseAJour();

                    if ((nurse.X == x_player.X) && (nurse.Y == x_player.Y))
                    {
                        this.GameOver = true;
                    }
                }

                System.Threading.Thread.Sleep(20);
            }
            else
            {
                this.gameOver.Visibility = System.Windows.Visibility.Visible;
                x_player.Visibility = System.Windows.Visibility.Collapsed;

                foreach (Nurse nurse in liste_ennemis)
                {
                    nurse.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
        }
    }
}
