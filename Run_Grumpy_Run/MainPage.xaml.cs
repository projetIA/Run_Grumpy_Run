using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Run_Grumpy_Run
{
    public partial class MainPage : UserControl
    {
        private List<murs> liste_fixe;
        private List<Nurse> liste_ennemis;
        private List<objects> liste_objects;
        public int GameOver;
        public int[,] map { get; set; }

        public MainPage()
        {
            InitializeComponent();

            this.GameOver = 0;

            //liste murs
            liste_fixe = new List<murs>();
            liste_ennemis = new List<Nurse>();
            liste_objects = new List<objects>();

            this.map = new int[,] { {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, 
                                    {1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,0,0,0,1,0,0,0,3,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1,1,0,1,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,7,1,1,1},
                                    {1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,3,0,0,0,1},
                                    {1,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,3,0,0,0,1},
                                    {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0,1}, 
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,1}, 
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,1}, 
                                    {1,0,0,1,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1}, 
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,1,1,1,1,1,0,1}, 
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,1,1,0,1,1,0,0,0,0,0,3,0,0,0,1},
                                    {1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,1,1,1,1,1,1,1},
                                    {1,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,1},
                                    {1,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,1,1,0,1,1,5,1,1,1,1,0,0,0,6,0,0,1},
                                    {1,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                                    {1,0,0,0,0,0,0,1,4,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                                    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1} };
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 45; j++)
                {
                    if (map[i, j] == 1)
                    {
                        liste_fixe.Add(new murs(j * 32, i * 32));
                    }
                    else if (map[i, j] == 3)
                    {
                        Nurse nurse = new Nurse(j * 32, i * 32, this);
                        this.LayoutRoot.Children.Add(nurse);
                        liste_ennemis.Add(nurse);
                    }
                    else if (map[i, j] == 4)
                    {
                        objects cle = new objects(j * 32, i * 32, "cle");
                        this.LayoutRoot.Children.Add(cle);
                        liste_objects.Add(cle);
                    }
                    else if (map[i, j] == 5)
                    {
                        objects porte = new objects(j * 32, i * 32, "door");
                        this.LayoutRoot.Children.Add(porte);
                        liste_objects.Add(porte);
                    }
                    else if (map[i, j] == 6)
                    {
                        objects R2D2 = new objects(j * 32, i * 32, "R2D2");
                        this.LayoutRoot.Children.Add(R2D2);
                        liste_objects.Add(R2D2);
                    }
                    else if (map[i, j] == 7)
                    {
                        objects Ronflex = new objects(j * 32, i * 32, "Ronflex");
                        this.LayoutRoot.Children.Add(Ronflex);
                        liste_objects.Add(Ronflex);
                    }
                }
            }
        }

        public bool Zone_OK(int _x, int _y, int _width, int _height)
        {
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
            foreach (objects objects in liste_objects)
            {
                if ((objects.X == _x) && (objects.Y == _y) && !(objects.etat))
                {
                    return false;
                }
            }
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

            if (this.GameOver == 0)
            {
                //mise a jour du joueur
                x_player.MiseAJour(this);

                //mise à jour objects
                foreach (objects objects in liste_objects)
                {
                    objects.MiseAJour(x_player.X , x_player.Y);
                    // clé trouvé on enlève les portes
                    if (objects.type == "cle" && objects.etat)
                    {
                        this.door.Visibility = System.Windows.Visibility.Collapsed;
                        this.door2.Visibility = System.Windows.Visibility.Collapsed;
                        foreach (objects liste in liste_objects)
                        {
                            if (liste.type == "door")
                            {
                                liste.etat = true;
                            }
                        }
                    }
                    // R2 trouvé on enlève Ronflex
                    if (objects.type == "R2D2" && objects.etat)
                    {
                        foreach (objects liste in liste_objects)
                        {
                            if (liste.type == "Ronflex")
                            {
                                liste.etat = true;
                            }
                        }
                    }
                }

                foreach (Nurse nurse in liste_ennemis)
                {

                    Random rand = new Random();
                    System.Threading.Thread.Sleep(rand.Next(20));

                    // mise a jour des nurses
                    System.Threading.Thread.Sleep(1);

                    nurse.MiseAJour();

                    // Detection d'une collision entre le joueur et une infirmiere, provoque la game over;
                    if ((nurse.X == x_player.X) && (nurse.Y == x_player.Y))
                    {
                        // Allez, encore une autre partie
                        this.GameOver = 1;
                    }
                }

                // arrivé a une positiotn, le joueur a gagné
                if ((x_player.X == 1376) && (x_player.Y == 64 ))
                {
                    // Gagné
                    this.GameOver = 2;
                }
                System.Threading.Thread.Sleep(20);

            }
            else if (this.GameOver == 1)
            {
                this.gameOver.Visibility = System.Windows.Visibility.Visible;
                x_player.Visibility = System.Windows.Visibility.Collapsed;

                foreach (Nurse nurse in liste_ennemis)
                {
                    nurse.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            else
            {
                this.win.Visibility = System.Windows.Visibility.Visible;
                x_player.Visibility = System.Windows.Visibility.Collapsed;

                foreach (Nurse nurse in liste_ennemis)
                {
                    nurse.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
        }

        private void _try_Click(object sender, RoutedEventArgs e)
        {
            //this.DataContext.
        }
    }
}
