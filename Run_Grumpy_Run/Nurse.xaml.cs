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

        public MainPage MP {get;set;}
        public DateTime horloge;
        
        public enum Direction { droite, haut, bas, gauche };
        public Direction direction { get; set; }
        public int count { get; set; }

        public Direction[] Deplacements { get; set; }


        public Nurse(int x, int y, MainPage mp)
        {
            InitializeComponent();

            this.horloge = DateTime.Now;
            this.MP = mp;
            this.X = x;
            this.Y = y;

            this.ChangeDirection();

            this.Draw();
        }

        public void Draw()
        {
            Canvas.SetLeft(this, this.X);
            Canvas.SetTop(this, this.Y);
        }

        public void MiseAJour()
        {
            if (DateTime.Now > horloge.AddMilliseconds(200))
            {
                this.Detection();
                //this.Deplacement();
                this.Draw();
            }
        }

        public void Deplacement()
        {
            horloge = DateTime.Now;
            int newX = this.X;
            int newY = this.Y;

            this.ChangeDirection();
            
            switch (this.direction)
            {
                case Direction.gauche:
                    newX -= 32;
                    break;
                case Direction.droite:
                    newX += 32;
                    break;
                case Direction.haut:
                    newY -= 32;
                    break;
                case Direction.bas:
                    newY += 32;
                    break;
            }

            // Vérification du déplacement
            if (MP.Zone_OK(newX, newY, 32, 32))
            {
                this.X = newX;
                this.Y = newY;
            }
            else
            {
                // Si le mob est coincé, une nouvelle direction est générée aleatoirement.
                this.ChangeDirection();
            }
        }

        public void ChangeDirection()
        {
            Random rand = new Random();
            int d = rand.Next(5);

            // Déplacement 
            if (d == 3 || d == 4)
            {
                switch (this.direction)
                {
                    case Direction.haut:
                        this.direction = (d == 3 ? Direction.droite : Direction.gauche);
                        break;
                    case Direction.bas:
                        this.direction = (d == 3 ? Direction.gauche : Direction.droite);
                        break;
                    case Direction.droite:
                        this.direction = (d == 3 ? Direction.bas : Direction.haut);
                        break;
                    case Direction.gauche:
                        this.direction = (d == 3 ? Direction.haut : Direction.bas);
                        break;
                }
            }
        }

        public void Detection()
        {

            // Calcul du vecteur
            int x = this.X - this.MP.x_player.X;
            int y = this.Y - this.MP.x_player.Y;
            double longeur = Math.Sqrt((y * y) + (x * x));

            // Deduction du sens de direction, gauche ou droite
             double sens = (x < 0 ? -1 : 1);
            // Calcul de la direction du vecteur
            decimal direction = ( x == 0) ? 0 : Decimal.Divide(y, x);

            

            // Les infirmieres ont une portée de detection de 10 cases dans toutes les direction
            if (longeur < 3200)
            {
                double pointX = 0;
                double pointY = 0;

                double caseX = 0;
                double caseY = 0;

                double tempX;
                double tempY;
                
                //boucle de parcours du vecteur
                int i = 0;
                bool end = false;
                
                while( (i < 100) || (end == false))
                {
                    pointX += x / 100;
                    pointY += y / 100;

                    //tempX = x / 32;
                    //tempY = y / 32;
                    //caseX = Math.Round(tempX , 0);

                    i++;
                }

                this.MP.DebugBox.Text =
                "x: " + x.ToString() + " | y: " + y.ToString()
                + Environment.NewLine + direction
                + Environment.NewLine + "player X: " + this.MP.x_player.X + " | player Y: " + this.MP.x_player.Y
                + Environment.NewLine + "Longueur: " + longeur
                + Environment.NewLine + "caseX: " + caseX;
            }
        }

    }
}
