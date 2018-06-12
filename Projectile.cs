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
using System.IO;

namespace LegendofGnome
{
    class Projectile
    {
        public double speed_X;
        public double speed_Y;
        private Canvas canvas;
        public Ellipse projectile;
        public Point arrow_pos = new Point(250, 144);

        public Projectile(Canvas c, Window window, Point playerPoint)
        {
            canvas = c;
            projectile = new Ellipse();
            projectile.Height = 20;
            projectile.Width = 20;

            BitmapImage bitmapBackground = new BitmapImage(new Uri("Shuriken Projectile.png", UriKind.Relative));
            ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
            projectile.Fill = backgroundBrush;
            canvas.Children.Add(projectile);
            FindSlope(window);
            Canvas.SetLeft(this.projectile, playerPoint.X + 25);
            Canvas.SetTop(this.projectile, playerPoint.Y + 25);
        }

        public void FindSlope(Window window)
        {
            double Click_X = Mouse.GetPosition(window).X - 500;//500 assumes map size is 1000 high
            double Click_Y = Mouse.GetPosition(window).Y - 400;//400 assumes map size is 800 high
            //MessageBox.Show(Click_X.ToString() + " " + Click_Y.ToString());

            double angle = Math.Atan2(Click_Y, Click_X);
            //find the length of lines on preset circle that coresponds with the angle.(changing circle width changes speed of projectiles)
            speed_X = Math.Sin(angle) * 10; //sin(angle) = x/100 * 100 = x
            speed_Y = Math.Cos(angle) * 10; //cos(angle) = y/100 * 100 = y
        }

        public void move()
        {
            double temp_x = Canvas.GetLeft(this.projectile) + speed_Y;
            Canvas.SetLeft(this.projectile, temp_x);
            double temp_y = Canvas.GetTop(this.projectile) + speed_X;
            Canvas.SetTop(this.projectile, temp_y);
        }
    }
}
