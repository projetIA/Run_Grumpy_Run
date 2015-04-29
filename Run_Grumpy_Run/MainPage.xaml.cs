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
        private int[,] map { get; set; }

        public MainPage()
        {
            InitializeComponent();

            this.GameOver = false;

            //liste murs
            liste_fixe = new List<murs>();

            this.map = new int[,] { {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, 
                                    {1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1,1,0,1,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,0,1,1,1},
                                    {1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0,1}, 
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,1}, 
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,1}, 
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1}, 
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,1,1,1,1,1,0,1}, 
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,1,1,0,1,1,0,0,0,0,0,0,0,0,0,1},
                                    {1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,1,1,1,1,1,1,1},
                                    {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,1,1,0,1,1,0,1,1,1,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                                    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1} };
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 44; j++)
                {
                    if (map[i, j] == 1)
                    {
                        liste_fixe.Add(new murs(j * 32, i * 32));
                    }
                }
            }


            liste_ennemis = new List<Nurse>();
            
            Nurse nurse0 = new Nurse("Billy Bob",416, 160, this);
            this.LayoutRoot.Children.Add(nurse0);
            liste_ennemis.Add(nurse0);

            Nurse  nurse1= new Nurse("Marty", 320, 256, this);
            this.LayoutRoot.Children.Add(nurse1);
            liste_ennemis.Add(nurse1);

            Nurse nurse2 = new Nurse("Kathyusha", 448, 352, this);
            this.LayoutRoot.Children.Add(nurse2);
            liste_ennemis.Add(nurse2);

            Nurse nurse3 = new Nurse("Blabla", 640, 256, this);
            this.LayoutRoot.Children.Add(nurse3);
            liste_ennemis.Add(nurse3);
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

            // test mobs
            foreach (Nurse nurse in liste_ennemis)
            {
                if( (nurse.X == _x) && (nurse.Y == _y) )
                {
                    return false;
                }
            }

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
            this.DebugBox.Text = x_player.image.ToString();
            if (this.GameOver == false)
            {

                x_player.MiseAJour(this);

                foreach (Nurse nurse in liste_ennemis)
                {
                    Random rand = new Random();
                    System.Threading.Thread.Sleep(rand.Next(20));
                    nurse.MiseAJour();

                    if ((nurse.X == x_player.X) && (nurse.Y == x_player.Y))
                    {
                        this.GameOver = true;
                    }
                }

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
