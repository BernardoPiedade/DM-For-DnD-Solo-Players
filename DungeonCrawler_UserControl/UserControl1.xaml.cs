﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DungeonCrawler_UserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    
    public class Monster_Token
    {
        int last_Monster_Position_X;
        int last_Monster_Position_Y;

        public Monster_Token()
        {
            last_Monster_Position_X = 0;
            last_Monster_Position_Y = 0;
        }

        public Monster_Token(Monster_Token m)
        {
            last_Monster_Position_X = m.last_Monster_Position_X;
            last_Monster_Position_Y = m.last_Monster_Position_Y;
        }

        public Monster_Token(int last_Monster_Position_X, int last_Monster_Position_Y)
        {
            this.Last_Monster_Position_X = last_Monster_Position_X;
            this.Last_Monster_Position_Y = last_Monster_Position_Y;
        }

        public int Last_Monster_Position_X { get => last_Monster_Position_X; set => last_Monster_Position_X = value; }
        public int Last_Monster_Position_Y { get => last_Monster_Position_Y; set => last_Monster_Position_Y = value; }

        public override bool Equals(object obj)
        {
            if (((Monster_Token)obj).last_Monster_Position_X == last_Monster_Position_X &&
                ((Monster_Token)obj).last_Monster_Position_Y == last_Monster_Position_Y)
                return true;
            return false;
        }
    }


    public partial class UserControl1 : UserControl
    {
        //static List<string> DamageType = new List<string>();
        static List<Monster_Token> Monster_Positions = new List<Monster_Token>();
        //List_Last_Positions -> max to 5 records
        static List<Monster_Token> List_Last_Positions = new List<Monster_Token>();
        static Random rnd = new Random();
        static int x = rnd.Next(0, 950);
        static int y = rnd.Next(0, 500);

        //get last player position
        static int last_Player_Position_X = 0;
        static int last_Player_Position_Y = 0;

        public UserControl1()
        {
            InitializeComponent();

            //DamageType.Add("Slashing");
            //DamageType.Add("Piercing");
            //DamageType.Add("Bludgeoning");
            //DamageType.Add("Poison");
            //DamageType.Add("Acid");
            //DamageType.Add("Fire");
            //DamageType.Add("Cold");
            //DamageType.Add("Radiant");
            //DamageType.Add("Necrotic");
            //DamageType.Add("Lightning");
            //DamageType.Add("Thunder");
            //DamageType.Add("Force");
            //DamageType.Add("Psychic");

            setPlayerPosition();
        }

        private void setPlayerPosition()
        {
            Rectangle rect;
            rect = new Rectangle();
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(@"img/player.png", UriKind.Relative));
            rect.Fill = imgBrush;
            rect.Width = 50;
            rect.Height = 50;
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
            canvas.Children.Add(rect);

            last_Player_Position_X = x;
            last_Player_Position_Y = y;
        }

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Up)
            {
                if (y-50 >= 0)
                {
                    y -= 50;

                    Rectangle r;
                    r = new Rectangle();
                    r.Fill = Brushes.White;
                    r.Width = 50;
                    r.Height = 50;
                    Canvas.SetLeft(r, last_Player_Position_X);
                    Canvas.SetTop(r, last_Player_Position_Y);
                    canvas.Children.Add(r);

                    Rectangle rect;
                    rect = new Rectangle();
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource = new BitmapImage(new Uri(@"img/player.png", UriKind.Relative));
                    rect.Fill = imgBrush;
                    rect.Width = 50;
                    rect.Height = 50;
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);
                    canvas.Children.Add(rect);

                    last_Player_Position_X = x;
                    last_Player_Position_Y = y;
                }
            }
            else if(e.Key == Key.Down)
            {

                if(y+50 <= 500)
                {
                    y += 50;

                    Rectangle r;
                    r = new Rectangle();
                    r.Fill = Brushes.White;
                    r.Width = 50;
                    r.Height = 50;
                    Canvas.SetLeft(r, last_Player_Position_X);
                    Canvas.SetTop(r, last_Player_Position_Y);
                    canvas.Children.Add(r);

                    Rectangle rect;
                    rect = new Rectangle();
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource = new BitmapImage(new Uri(@"img/player.png", UriKind.Relative));
                    rect.Fill = imgBrush;
                    rect.Width = 50;
                    rect.Height = 50;
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);
                    canvas.Children.Add(rect);

                    last_Player_Position_X = x;
                    last_Player_Position_Y = y;
                }
            }
            else if(e.Key == Key.Left)
            {

                if(x-50 >= 0)
                {
                    x -= 50;

                    Rectangle r;
                    r = new Rectangle();
                    r.Fill = Brushes.White;
                    r.Width = 50;
                    r.Height = 50;
                    Canvas.SetLeft(r, last_Player_Position_X);
                    Canvas.SetTop(r, last_Player_Position_Y);
                    canvas.Children.Add(r);

                    Rectangle rect;
                    rect = new Rectangle();
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource = new BitmapImage(new Uri(@"img/player.png", UriKind.Relative));
                    rect.Fill = imgBrush;
                    rect.Width = 50;
                    rect.Height = 50;
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);
                    canvas.Children.Add(rect);

                    last_Player_Position_X = x;
                    last_Player_Position_Y = y;
                }
            }
            else if(e.Key == Key.Right)
            {

                if(x+50 <= 950)
                {
                    x += 50;

                    Rectangle r;
                    r = new Rectangle();
                    r.Fill = Brushes.White;
                    r.Width = 50;
                    r.Height = 50;
                    Canvas.SetLeft(r, last_Player_Position_X);
                    Canvas.SetTop(r, last_Player_Position_Y);
                    canvas.Children.Add(r);

                    Rectangle rect;
                    rect = new Rectangle();
                    ImageBrush imgBrush = new ImageBrush();
                    imgBrush.ImageSource = new BitmapImage(new Uri(@"img/player.png", UriKind.Relative));
                    rect.Fill = imgBrush;
                    rect.Width = 50;
                    rect.Height = 50;
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);
                    canvas.Children.Add(rect);

                    last_Player_Position_X = x;
                    last_Player_Position_Y = y;
                }
            }
        }

        private void End_turn_Button_Click(object sender, RoutedEventArgs e)
        {
            Random rd = new Random();

            int pX = 0;
            int pY = 0;

            int clicks = 0;

            for (int i = 0; i < Monster_Positions.Count; i++)
            {
                int X = rd.Next(0, 150);
                int Y = rd.Next(0, 150);
                int Plus_Minus = rd.Next(0, 2);

                Rectangle r;
                r = new Rectangle();
                r.Fill = Brushes.White;
                r.Width = 50;
                r.Height = 50;
                Canvas.SetLeft(r, Monster_Positions[i].Last_Monster_Position_X);
                Canvas.SetTop(r, Monster_Positions[i].Last_Monster_Position_Y);
                canvas.Children.Add(r);

                // 0 = Plus | 1 = Minus
                if(Plus_Minus == 0)
                {
                    if (((Monster_Positions[i].Last_Monster_Position_X + X) >= 0) && ((Monster_Positions[i].Last_Monster_Position_X + X) <= 950))
                    {
                        for(int j = 0; j < List_Last_Positions.Count(); j++)
                        {
                            if ((Monster_Positions[i].Last_Monster_Position_X + X) != List_Last_Positions[j].Last_Monster_Position_X)
                            {
                                pX = Monster_Positions[i].Last_Monster_Position_X + X;
                            }
                            else
                            {
                                pX = Monster_Positions[i].Last_Monster_Position_X;
                            }
                        }
                    }

                    if (((Monster_Positions[i].Last_Monster_Position_Y + Y) >= 0) && ((Monster_Positions[i].Last_Monster_Position_Y + Y) <= 500))
                    {
                        for(int j = 0; j < List_Last_Positions.Count(); j++)
                        {
                            if((Monster_Positions[i].Last_Monster_Position_Y + Y) != List_Last_Positions[j].Last_Monster_Position_Y)
                            {
                                pY = Monster_Positions[i].Last_Monster_Position_Y + Y;
                            }
                            else
                            {
                                pY = Monster_Positions[i].Last_Monster_Position_Y;
                            }
                        }
                    }
                }
                else if (Plus_Minus == 1)
                {
                    if (((Monster_Positions[i].Last_Monster_Position_X - X) >= 0) && ((Monster_Positions[i].Last_Monster_Position_X - X) <= 950))
                    {
                        for(int j = 0; j < List_Last_Positions.Count(); j++)
                        {
                            if((Monster_Positions[i].Last_Monster_Position_X - X) != List_Last_Positions[j].Last_Monster_Position_X)
                            {
                                pX = Monster_Positions[i].Last_Monster_Position_X - X;
                            }
                            else
                            {
                                pX = Monster_Positions[i].Last_Monster_Position_X;
                            }
                        }
                    }

                    if (((Monster_Positions[i].Last_Monster_Position_Y - Y) >= 0) && ((Monster_Positions[i].Last_Monster_Position_Y - Y) <= 500))
                    {
                        for(int j = 0; j < List_Last_Positions.Count(); j++)
                        {
                            if((Monster_Positions[i].Last_Monster_Position_Y - Y) != List_Last_Positions[i].Last_Monster_Position_Y)
                            {
                                pY = Monster_Positions[i].Last_Monster_Position_Y - Y;
                            }
                            else
                            {
                                pY = Monster_Positions[i].Last_Monster_Position_Y;
                            }
                        }
                    }
                }
                
                if(i > 0)
                {
                    if (Plus_Minus == 0)
                    {
                        if (pX == (Monster_Positions[i - 1].Last_Monster_Position_X))
                        {
                            if((pX += 100) <= 950)
                            {
                                pX += 100;
                            }
                            else
                            {
                                pX -= 100;
                            }
                        }

                        if (pY == (Monster_Positions[i - 1].Last_Monster_Position_Y))
                        {
                            if((pY += 100) <= 500)
                            {
                                pY += 100;
                            }
                            else
                            {
                                pY -= 100;
                            }
                        }
                    }
                    else if (Plus_Minus == 1)
                    {
                        if (pX == (Monster_Positions[i - 1].Last_Monster_Position_X))
                        {
                            if((pX -= 100) >= 0)
                            {
                                pX -= 100;
                            }
                            else
                            {
                                pX += 100;
                            }
                        }

                        if (pY == (Monster_Positions[i - 1].Last_Monster_Position_Y))
                        {
                            if((pY -= 100) >= 0)
                            {
                                pY -= 100;
                            }
                            else
                            {
                                pY += 100;
                            }
                        }
                    }
                }

                Rectangle rect;
                rect = new Rectangle();
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(@"img/Monster.png", UriKind.Relative));
                rect.Fill = imgBrush;
                rect.Width = 50;
                rect.Height = 50;
                Canvas.SetLeft(rect, pX);
                Canvas.SetTop(rect, pY);
                canvas.Children.Add(rect);
                

                Monster_Positions[i].Last_Monster_Position_X = pX;
                Monster_Positions[i].Last_Monster_Position_Y = pY;

                clicks++;
                if (clicks == 5)
                {
                    List_Last_Positions.RemoveAt(0);
                    clicks = 0;
                }
            }
        }

        private void Add_Monster_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int Nx = r.Next(0, 950);
            int Ny = r.Next(0, 500);

            if((Nx != last_Player_Position_X) && (Ny != last_Player_Position_Y))
            {
                Rectangle rect;
                rect = new Rectangle();
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(@"img/Monster.png", UriKind.Relative));
                rect.Fill = imgBrush;
                rect.Width = 50;
                rect.Height = 50;
                Canvas.SetLeft(rect, Nx);
                Canvas.SetTop(rect, Ny);
                canvas.Children.Add(rect);

                int last_Monster_Position_X = Nx;
                int last_Monster_Position_Y = Ny;

                Monster_Positions.Add(new Monster_Token(last_Monster_Position_X, last_Monster_Position_Y));
                List_Last_Positions.Add(new Monster_Token(last_Monster_Position_X, last_Monster_Position_Y));
            }
            else
            {
                int Second_P_X = r.Next(0, 950);
                int Second_P_Y = r.Next(0, 500);

                Rectangle rect;
                rect = new Rectangle();
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(@"img/Monster.png", UriKind.Relative));
                rect.Fill = imgBrush;
                rect.Width = 50;
                rect.Height = 50;
                Canvas.SetLeft(rect, Second_P_X);
                Canvas.SetTop(rect, Second_P_Y);
                canvas.Children.Add(rect);

                int Second_last_Monster_Position_X = Second_P_X;
                int Second_last_Monster_Position_Y = Second_P_Y;

                Monster_Positions.Add(new Monster_Token(Second_last_Monster_Position_X, Second_last_Monster_Position_Y));
                List_Last_Positions.Add(new Monster_Token(Second_last_Monster_Position_X, Second_last_Monster_Position_Y));
            }
        }
    }
}