using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PaddleBall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private double dx = 2;
        private double dy = 2;
        private double vertDirection = 1;
        private double horizDirection = -1;

        private double gameBallTop = 0;
        private double gameBallLeft = 0;
        private double rectangleTop = 0;
        private double rectangleLeft = 0;

        private int curScore = 0;
        private int currentHighScore = 0;
        private Boolean currentlyPlaying = false;
        private Boolean isPaused = false;

        public MainWindow()
        {
            InitializeComponent();
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            gameTimer.Tick += GameTimer_Tick;
            gameBallTop = Canvas.GetTop(gameBall);
            gameBallLeft = Canvas.GetLeft(gameBall);
            rectangleTop = Canvas.GetTop(gameRectangle);
            rectangleLeft = Canvas.GetLeft(gameRectangle); //never needs to be updated b/c never changes

            //The following code sets the canvas background as the Resource Image 'orangebackground'
            System.Drawing.Bitmap background = Properties.Resources.orangebackground;
            ImageBrush ib = new ImageBrush();
            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(background.GetHbitmap(),
                                                         IntPtr.Zero,
                                                         Int32Rect.Empty,
                                                         BitmapSizeOptions.FromEmptyOptions());
            this.highScore.Text = "HIGH SCORE: " + currentHighScore;
            background.Dispose();
            ib.ImageSource = bitmapSource;
            myGameCanvas.Background = ib;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //Handling the Ball hitting the paddle
            if (gameBallLeft <= rectangleLeft + gameRectangle.Width
                && rectangleTop - gameBall.Height/2 <= gameBallTop
                && rectangleTop + gameRectangle.Height + gameBall.Height/2 >= gameBallTop)
            {
                horizDirection *= -1;
                this.curScore++;
                if (curScore > currentHighScore)
                    currentHighScore = curScore;
                    this.highScore.Text = "HIGH SCORE: " + currentHighScore;
                this.currentScore.Text = "Current Score: " + curScore;
            }
            else if (gameBallLeft <= rectangleLeft + gameRectangle.Width)
            {//Handling when the ball misses the paddle
                this.gameTimer.IsEnabled = false;
                this.currentScore.Text = "GAME OVER";
                this.currentlyPlaying = false;
                gameBallTop = 300;
                gameBallLeft = 600;
                Canvas.SetTop(gameBall, gameBallTop);
                Canvas.SetLeft(gameBall, gameBallLeft);
            }
            

            //Handling the Ball hitting the edge of the canvas
            if (gameBallTop <= 0 || gameBallTop >= (myGameCanvas.Height - gameBall.Height))
            {
                vertDirection *= -1;
            }
            if (gameBallLeft <= 0 || gameBallLeft >= (myGameCanvas.Width - gameBall.Width))
            {
                horizDirection *= -1;
            }

            gameBallLeft += dx * horizDirection;
            gameBallTop += dy * vertDirection;

            Canvas.SetTop(gameBall, gameBallTop);
            Canvas.SetLeft(gameBall, gameBallLeft);
        }

        private void gameRectangle_KeyDown(object sender, KeyEventArgs e)
        {

            if((e.Key == Key.Down || e.Key == Key.S) && rectangleTop <= (myGameCanvas.Height - gameRectangle.Height))
            {
                rectangleTop += 3;
            }
            if((e.Key == Key.Up || e.Key == Key.W) && rectangleTop >= 0)
            {
                rectangleTop -= 3;
            }
            Canvas.SetTop(gameRectangle, rectangleTop);
        }

        //Play Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!currentlyPlaying)
            {
                this.curScore = 0;
                this.currentScore.Text = "Current Score: " + this.curScore;
                currentlyPlaying = true;

                gameTimer.IsEnabled = true;
            }
        }

        //Pause Button
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (currentlyPlaying && isPaused)
            {
                gameTimer.IsEnabled = true;
                isPaused = false;
                btnPause.Content = "Pause";
            }
            else if (currentlyPlaying)
            {
                btnPause.Content = "Resume";
                isPaused = true;
                gameTimer.IsEnabled = false;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
