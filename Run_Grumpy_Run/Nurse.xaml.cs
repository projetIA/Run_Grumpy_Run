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
using System.Windows.Media.Imaging;
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
            ImageBrush brush = new ImageBrush();
            switch (this.direction)
            {
                case Direction.gauche:                  
                    brush.ImageSource = new BitmapImage(new Uri(@"images/nurse/nurse2.png", UriKind.Relative));
                    rect.Fill = brush;
                    break;

                case Direction.droite:                   
                    brush.ImageSource = new BitmapImage(new Uri(@"images/nurse/nurse3.png", UriKind.Relative));
                    rect.Fill = brush;
                    break;

                case Direction.haut:
                    brush.ImageSource = new BitmapImage(new Uri(@"images/nurse/nurse4.png", UriKind.Relative));
                    rect.Fill = brush;
                    break;

                case Direction.bas:
                    brush.ImageSource = new BitmapImage(new Uri(@"images/nurse/nurse1.png", UriKind.Relative));
                    rect.Fill = brush;
                    break;
            }
        }

        public void MiseAJour()
        {
            if (DateTime.Now > horloge.AddMilliseconds(250))
            {
                horloge = DateTime.Now;
                if (Detection())
                {

                }
                else
                {
                    this.Deplacement();
                }
                this.Draw();
            }
        }

        public void Deplacement()
        {
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

        public bool Detection()
        {
                // Calcul du vecteur
                int x = this.MP.x_player.X - this.X;
                int y = this.MP.x_player.Y - this.Y;
                int nbcase = Math.Abs(x / 32) + Math.Abs(y / 32);
                double longeur = Math.Round(Math.Sqrt((y * y) + (x * x)));
                double diviseur = Math.Round(longeur / nbcase, 2);
                int adition = Convert.ToInt32(diviseur);


                // Les infirmieres ont une portée de detection de 10 cases dans toutes les direction
                if (longeur < 160)
                {
                    int _x = Math.Abs(x);
                    int _y = Math.Abs(y);

                    int caseX = this.X;
                    int caseY = this.Y;
                    int newX = caseX;
                    int newY = caseY;

                    //boucle de parcours du vecteur
                    int i = 0;
                    bool end = false;

                    while (i < nbcase)
                    {
                        if (_x > _y && x < 0)
                        {
                            caseX -= 32;
                            _y += adition;
                        }
                        else if (_x > _y && x > 0)
                        {
                            caseX += 32;
                            _y += adition;
                        }
                        else if (_x < _y && y < 0)
                        {
                            caseY -= 32;
                            _x += adition;
                        }
                        else if (_x < _y && y > 0)
                        {
                            caseY += 32;
                            _x += adition;
                        }
                        else if (_x == _y)
                        {
                            Random rand = new Random();
                            int d = rand.Next(2);
                            if (d == 2 && y > 0)
                            {
                                caseY += 32;
                                _x += adition;
                            }
                            else if (d == 2 && y < 0)
                            {
                                caseY -= 32;
                                _x += adition;
                            }
                            else
                            {
                                if (x < 0)
                                {
                                    caseX -= 32;
                                    _y += adition;

                                }
                                else
                                {
                                    caseX += 32;
                                    _y += adition;
                                }
                            }

                        }
                        else
                        {
                            break;
                        }
                        if (i == 0)
                        {
                            newX = caseX;
                            newY = caseY;
                        }
                        if (!MP.Zone_OK(caseX, caseY, 32, 32))
                        {
                            end = true;
                            break;
                        }
                        this.MP.DebugBox.Text = i.ToString();
                        i++;
                    }
                    if (end == false && MP.Zone_OK(newX, newY, 32, 32))
                    {
                        this.X = newX;
                        this.Y = newY;
                        this.Draw();
                        return true;
                    }

                    

                    this.MP.DebugBox.Text =
                    "x: " + x.ToString() + " | y: " + y.ToString()
                    + Environment.NewLine + "_x: " + _x.ToString() + " | _y: " + _y.ToString()
                    + Environment.NewLine + direction
                    + Environment.NewLine + "player X: " + this.MP.x_player.X + " | player Y: " + this.MP.x_player.Y
                    + Environment.NewLine + "nurse X: " + this.X + " | nurse Y: " + this.Y
                    + Environment.NewLine + "Longueur: " + longeur
                    + Environment.NewLine + "caseX: " + caseX + "caseY: " + caseY
                    + Environment.NewLine + "newX: " + newX + "newY: " + newY
                    + Environment.NewLine + "nbcase: " + nbcase + "diviseur: " + diviseur + "adition: " + adition;

                    return false;
                }
                return false;
            
        }

    }
}
