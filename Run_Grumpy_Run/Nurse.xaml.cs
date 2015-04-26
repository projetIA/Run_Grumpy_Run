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
        public string name { get; set; }

        public MainPage MP {get;set;}
        public DateTime horloge;
        
        public enum Direction { droite, haut, bas, gauche };
        public Direction direction { get; set; }


        public Nurse(string name, int x, int y, MainPage mp)
        {
            InitializeComponent();

            this.horloge = DateTime.Now;
            this.MP = mp;
            this.X = x;
            this.Y = y;
            this.name = name;
            this.direction = RandomDirection();

            this.Draw();
        }

        public void Draw()
        {
            Canvas.SetLeft(this, this.X);
            Canvas.SetTop(this, this.Y);
        }

        public void MiseAJour()
        {
            if (DateTime.Now > horloge.AddMilliseconds(300))
            {
                horloge = DateTime.Now;
                int newX = this.X;
                int newY = this.Y;

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
                    this.direction = RandomDirection();
                }

                // Affichage à la nouvelle position
                this.Draw();
            }
        }

        public Direction RandomDirection()
        {
            Random rand = new Random();
            int value = rand.Next(4);
            Direction dir = Direction.haut; // set by default so Visual Studio is happy;

            switch (value)
            {
                case 0:
                    dir =  Direction.haut;
                    break;
                case 1:
                    dir = Direction.bas;
                    break;
                case 2:
                    dir = Direction.droite;
                    break;
                case 3:
                    dir = Direction.gauche;
                    break;
            }

            //this.MP.DebugBox.Text += Environment.NewLine + this.name + ": " + dir.ToString() ;
            return dir;
        }
    }
}
