using System;
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
using System.Windows.Threading;

namespace LegendofGnome
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Point playerPoint;
        Map map = new Map();
        List<Projectile> projectiles = new List<Projectile>();
        Player player = new Player();
        DispatcherTimer GameTimer = new DispatcherTimer();
        DispatcherTimer projectileTimer = new DispatcherTimer();
        public cursor LOLHand
        public MainWindow()
        {
            InitializeComponent();
            bool isMapGenerated = false;
            if(isMapGenerated == false)
            {
                Rectangle background = new Rectangle();
                background.Height = 1000;
                background.Width = 1300;
                background.Fill = Brushes.Blue;
                //ImageBrush backgroundBrush = new ImageBrush(Map);
                //background.Fill = backgroundBrush;
                Canvas.Children.Add(background);
                map.DoorGenerate(map.door1, Canvas);
                isMapGenerated = true;

            }
            bool isPlayerGenerated = false;
            if (isPlayerGenerated == false)
            {
                
                player.GeneratePlayer(Canvas, playerPoint);
                isPlayerGenerated = true;
            }
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            GameTimer.Start();

            projectileTimer.Tick += MovementTimer_Tick;
            projectileTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            projectileTimer.Start();

            FileStream fileStream;//set cursor
            fileStream = new FileStream("LOLHand.cur", FileMode.Open);
            LOLHand = new Cursor(fileStream);
            this.Cursor = projectile.LOLHand;
            this.ForceCursor = true;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            playerPoint = player.Move(player.playerRectangle, Canvas, playerPoint);
            Console.WriteLine(playerPoint.ToString());
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < projectiles.Count(); i++)
            {
                projectiles[i].move();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // MessageBox.Show(e.GetPosition(Canvas).ToString());
            projectiles.Add(new Projectile(Canvas, this, playerPoint));
        }
    }
}
