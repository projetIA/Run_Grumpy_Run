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


        public Nurse(int x, int y, MainPage mp)
        {
            InitializeComponent();

            this.horloge = DateTime.Now;
            this.MP = mp;
            this.X = x;
            this.Y = y;
            RandomDirection();

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
                horloge = DateTime.Now;
                int newX = this.X;
                int newY = this.Y;
                
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
                    this.RandomDirection();
                }
                // Affichage à la nouvelle position
                this.Draw();
            }
        }

        public void RandomDirection()
        {
            Random rand = new Random();
            int value = rand.Next(4);

            switch (value)
            {
                case 0:
                    this.direction = Direction.haut;
                    break;
                case 1:
                    this.direction = Direction.bas;
                    break;
                case 2:
                    this.direction = Direction.droite;
                    break;
                case 3:
                    this.direction = Direction.gauche;
                    break;
            }
        }
    }
}
