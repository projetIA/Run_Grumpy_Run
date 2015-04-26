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

        public MainPage()
        {
            InitializeComponent();

            //liste murs
            liste_fixe = new List<murs>();
            liste_fixe.Add(new murs(192, 32));
            liste_fixe.Add(new murs(288, 32));
            liste_fixe.Add(new murs(480, 32));
            liste_fixe.Add(new murs(576, 32));
            liste_fixe.Add(new murs(672, 32));
            for (int x = 32; x <= 128; x += 32 )
            {
                 liste_fixe.Add(new murs(x, 192));
            }
            for (int y = 96; y <= 192; y += 32)
            {
                liste_fixe.Add(new murs(192, y));
            }


            liste_ennemis = new List<Nurse>();
            
            Nurse nurse = new Nurse(416, 160);
            this.LayoutRoot.Children.Add(nurse);
            liste_ennemis.Add(nurse);

            Nurse  nurse1= new Nurse(292, 256);
            this.LayoutRoot.Children.Add(nurse1);
            liste_ennemis.Add(nurse1);

            Nurse nurse2 = new Nurse(448, 352);
            this.LayoutRoot.Children.Add(nurse2);
            liste_ennemis.Add(nurse2);
        }

        public bool Zone_OK(int _x, int _y, int _width, int _height)
        {

            // Test murs extérieurs
            if (_x < 32 || _x > this.LayoutRoot.ActualWidth - _width)
            {
                return false;
            }
            if (_y < 32 || _y > this.LayoutRoot.ActualHeight - _height)
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
            // Boucle de jeu
            x_player.MiseAJour(this);
            System.Threading.Thread.Sleep(20);
        }
    }
}
