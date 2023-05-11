using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;

using System.Windows.Threading;
using Rectangle = System.Windows.Shapes.Rectangle;
using System.Windows.Automation;

namespace MarioGame
{
    /// <summary>
    /// Interaction logic for level.xaml
    /// </summary>
    public partial class level : Window
    {

        DispatcherTimer gameTimer = new DispatcherTimer();

        bool goLeft, goRight, goDown, goUp;
        bool noLeft, noRight, noDown, noUp;

        int speed = 8;

        int ghostSpeed = 10;
        int ghostMoveStep = 130;
        int currentGhost;
        int score = 0;
        private Rect pacmanHitBox;

        private double gravity = 1.0;  // adjust the gravity strength as desired
        private double verticalVelocity = 0.0;
        private double terminalVelocity = 20.0;  // limit the maximum falling speed
        private double groundY = 399;  // set this to the Y-coordinate of the top of the ground platform

        private bool isJumping = false;
        private int jumpSpeed = 5;
        private int jumpDuration = 10; // how many ticks the jump lasts
        private int jumpTick = 0; // how many ticks the jump has lasted so far
        private int jumpHeight = 50; // how high the jump goes
        private double gravitySpeed = 2.0; // define gravitySpeed here




        public level()
        {
            InitializeComponent();
            GameSetUp();

        }


        private void GameSetUp()
        {
            MyCanvas.Focus();

            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
            currentGhost = currentGhost;

            ImageBrush marioImage = new ImageBrush();
            marioImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\mario.png"));
            mario.Fill = marioImage;

            ImageBrush marioGround = new ImageBrush();
            marioGround.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\ground.png"));
            ground.Fill = marioGround;

            ImageBrush marioPipe = new ImageBrush();
            marioPipe.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\pipe.png"));
            pipe.Fill = marioPipe;

            ImageBrush marioPipe1 = new ImageBrush();
            marioPipe1.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\pipe1.png"));
            pipe1.Fill = marioPipe1;

            ImageBrush marioBricks = new ImageBrush();
            marioBricks.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\Bricks.png"));
            bricks.Fill = marioBricks;

            ImageBrush marioCoin = new ImageBrush();
            marioCoin.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\money.png"));
            coin.Fill = marioCoin;

            ImageBrush marioCoin1 = new ImageBrush();
            marioCoin1.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\money - Copy.png"));
            coin1.Fill = marioCoin1;

            ImageBrush marioCoin2 = new ImageBrush();
            marioCoin2.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\money - Copy (2).png"));
            coin2.Fill = marioCoin2;

            ImageBrush marioCoin3 = new ImageBrush();
            marioCoin3.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\coin3.png"));
            coin3.Fill = marioCoin3;

            ImageBrush marioCoin4 = new ImageBrush();
            marioCoin4.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\coin4.png"));
            coin4.Fill = marioCoin4;

            ImageBrush marioCoin5 = new ImageBrush();
            marioCoin5.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\coin5.png"));
            coin5.Fill = marioCoin5;

            ImageBrush marioCoin6 = new ImageBrush();
            marioCoin6.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\coin6.png"));
            coin6.Fill = marioCoin6;

            ImageBrush marioEnemy = new ImageBrush();
            marioEnemy.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\enemy.png"));
            enemy.Fill = marioEnemy;

            ImageBrush marioEnemy2 = new ImageBrush();
            marioEnemy2.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\enemy2.png"));
            enemy2.Fill = marioEnemy2;

            ImageBrush marioEnemy3 = new ImageBrush();
            marioEnemy3.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\enemy3.png"));
            enemy3.Fill = marioEnemy3;

            ImageBrush marioEnemy4 = new ImageBrush();
            marioEnemy4.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\enemy4.png"));
            enemy4.Fill = marioEnemy4;

            ImageBrush marioEnemy5 = new ImageBrush();
            marioEnemy5.ImageSource = new BitmapImage(new Uri("C:\\Users\\isuru\\OneDrive\\Desktop\\MarioGame\\images\\enemy5.png"));
            enemy5.Fill = marioEnemy5;

        }
        //jump/
        private void CanvasKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space)
            {
                // initiate jump
                if (!isJumping)
                {
                    isJumping = true;
                }
            }
            if (e.Key == Key.Left && noLeft == false)
            {
                goRight = goUp = goDown = false;
                noRight = noUp = noDown = false;

                goLeft = true;

                mario.RenderTransform = new RotateTransform(-180, mario.Width / 2, mario.Height / 2);
            }
            if (e.Key == Key.Right && noRight == false)
            {
                noLeft = noUp = noDown = false;
                goLeft = goUp = goDown = false;

                goRight = true;

                mario.RenderTransform = new RotateTransform(0, mario.Width / 2, mario.Height / 2);
            }


        }

        private void ApplyGravity()
        {
            // apply gravity to Mario's vertical velocity
            verticalVelocity += gravity;
            if (verticalVelocity > terminalVelocity)
            {
                verticalVelocity = terminalVelocity;
            }

            // update Mario's position based on his current velocity
            double marioY = Canvas.GetTop(mario) + verticalVelocity;
            Canvas.SetTop(mario, marioY);

            // check if Mario has collided with the ground
            if (marioY + mario.Height >= groundY)
            {
                verticalVelocity = 0.0;
                Canvas.SetTop(mario, groundY - mario.Height);
            }

            // handle jumping
            if (isJumping)
            {
                int jumpDelta = (int)(((jumpDuration - jumpTick) / (double)jumpDuration) * jumpHeight);
                Canvas.SetTop(mario, Canvas.GetTop(mario) - jumpSpeed - jumpDelta);
                jumpTick++;

                if (jumpTick >= jumpDuration)
                {
                    isJumping = false;
                    jumpTick = 0;
                }
            }
            // handle falling
            else
            {
                Canvas.SetTop(mario, Canvas.GetTop(mario) + gravitySpeed);
            }
        }


        private List<Ellipse> coins = new List<Ellipse>();
        private bool condition;

        public NavigationService NavigationService { get; private set; }

        //gravity functionality
        private void GameLoop(object sender, EventArgs e)
        {
            //this if stament for movment
            if (goRight && Keyboard.IsKeyDown(Key.Right))
            {
                Canvas.SetLeft(mario, Canvas.GetLeft(mario) + speed);
            }
            if (goLeft && Keyboard.IsKeyDown(Key.Left))
            {
                Canvas.SetLeft(mario, Canvas.GetLeft(mario) - speed);
            }

            //this controlers the edge of the game
            if (goDown && Canvas.GetTop(mario) + 80 > Application.Current.MainWindow.Height)
            {
                noDown = true;
                goDown = false;
            }
            if (goUp && Canvas.GetTop(mario) < 1)
            {
                noUp = true;
                goUp = false;
            }

            ApplyGravity();

            coins.Add(coin);
            coins.Add(coin1);
            coins.Add(coin2);
            coins.Add(coin3);
            coins.Add(coin4);



            // Check if Mario is colliding with the ground
            Rect marioHitBox = new Rect(Canvas.GetLeft(mario), Canvas.GetTop(mario), mario.Width, mario.Height);
            Rect groundHitBox = new Rect(Canvas.GetLeft(ground), Canvas.GetTop(ground), ground.Width, ground.Height);
            Rect pipeHitbox = new Rect(Canvas.GetLeft(pipe), Canvas.GetTop(pipe), pipe.Width, pipe.Height);
            Rect pipe1Hitbox = new Rect(Canvas.GetLeft(pipe1), Canvas.GetTop(pipe1), pipe1.Width, pipe1.Height);
            Rect bricksHitBox = new Rect(Canvas.GetLeft(bricks), Canvas.GetTop(bricks), bricks.Width, bricks.Height);
            //Rect enemyHitBox = new Rect(Canvas.GetLeft(enemy), Canvas.GetTop(enemy), enemy.Width, enemy.Height);

            foreach (var enemy in MyCanvas.Children.OfType<Rectangle>())
            {
                Rect enemyHitBox = new Rect(Canvas.GetLeft(enemy), Canvas.GetTop(enemy), enemy.Width, enemy.Height);

                if ((string)enemy.Tag == "ghost")
                {
                    if (enemy.Name.ToString() == "enemy")
                    {
                        Canvas.SetLeft(enemy, Canvas.GetLeft(enemy) - ghostSpeed);
                        if (marioHitBox.IntersectsWith(enemyHitBox))
                        {
                            GameOver("Enemy got you, press ok to play again");
                        }
                    }
                    else
                    {
                        Canvas.SetLeft(enemy, Canvas.GetLeft(enemy) + ghostSpeed);
                    }

                    if (enemy.Name.ToString() == "enemy2")
                    {
                        Canvas.SetLeft(enemy, Canvas.GetLeft(enemy) - ghostSpeed);
                        if (marioHitBox.IntersectsWith(enemyHitBox))
                        {
                            GameOver("Enemy got you, press ok to play again");
                        }
                    }
                    else
                    {
                        Canvas.SetLeft(enemy, Canvas.GetLeft(enemy) + ghostSpeed);
                    }

                    if (enemy.Name.ToString() == "enemy3")
                    {
                        Canvas.SetLeft(enemy, Canvas.GetLeft(enemy) - ghostSpeed);
                        if (marioHitBox.IntersectsWith(enemyHitBox))
                        {
                            GameOver("Enemy got you, press ok to play again");
                        }
                    }
                    else
                    {
                        Canvas.SetLeft(enemy, Canvas.GetLeft(enemy) + ghostSpeed);
                    }

                    if (Canvas.GetLeft(enemy) < 0 || Canvas.GetLeft(enemy) + enemy.Width > 1500)
                    {
                        ghostSpeed = -ghostSpeed; // change the direction of movement
                        Canvas.SetLeft(enemy, Canvas.GetLeft(enemy) + ghostSpeed); // move the enemy in the opposite direction
                    }

                    // check if the enemy has reached the left wall
                    if (Canvas.GetLeft(enemy) < 0)
                    {
                        ghostSpeed = -ghostSpeed; // change the direction of movement
                        Canvas.SetLeft(enemy, Canvas.GetLeft(enemy) + ghostSpeed); // move the enemy towards the right edge
                    }

                }
            }



            // Declare a variable to keep track of the score
            int score = 0;

            foreach (Ellipse coin in coins)
            {
                if (Coin.CheckCollision(mario, coin))
                {
                    MyCanvas.Children.Remove(coin);
                    score++;
                    lblScore.Content = "Score: " + score.ToString();
                    lblScore.InvalidateVisual();
                }
            }

            foreach (Ellipse coin1 in coins)
            {
                if (Coin.CheckCollision(mario, coin1))
                {
                    MyCanvas.Children.Remove(coin1);
                    score++;
                    lblScore.Content = "Score: " + score.ToString();
                    lblScore.InvalidateVisual();
                }
            }

            foreach (Ellipse coin2 in coins)
            {
                if (Coin.CheckCollision(mario, coin2))
                {
                    MyCanvas.Children.Remove(coin2);
                    score++;
                    lblScore.Content = "Score: " + score.ToString();
                    lblScore.InvalidateVisual();
                }
            }

            foreach (Ellipse coin3 in coins)
            {
                if (Coin.CheckCollision(mario, coin3))
                {
                    MyCanvas.Children.Remove(coin3);
                    score++;
                    lblScore.Content = "Score: " + score.ToString();
                    lblScore.InvalidateVisual();
                }
            }

            if (Coin.CheckCollision(mario, coin4))
            {
                MyCanvas.Children.Remove(coin4);
                score++;
                lblScore.Content = "Score: " + score.ToString();
                lblScore.InvalidateVisual();
            }

            if (Coin.CheckCollision(mario, coin5))
            {
                MyCanvas.Children.Remove(coin5);
                score++;
                lblScore.Content = "Score: " + score.ToString();
                lblScore.InvalidateVisual();
            }

            if (Coin.CheckCollision(mario, coin6))
            {
                MyCanvas.Children.Remove(coin6);
                score++;
                lblScore.Content = "Score: " + score.ToString();
                lblScore.InvalidateVisual();
            }


            //this code to check for ground collsion
            if (marioHitBox.IntersectsWith(groundHitBox))
            {
                Canvas.SetTop(mario, Canvas.GetTop(ground) - mario.Height);
            }

            //
            if (marioHitBox.IntersectsWith(pipeHitbox) || marioHitBox.IntersectsWith(pipe1Hitbox))
            {
                if (marioHitBox.Bottom >= pipeHitbox.Top)
                {
                    Canvas.SetTop(mario, Canvas.GetTop(mario) - (marioHitBox.Bottom - pipeHitbox.Top));
                }
                if (marioHitBox.Right >= pipeHitbox.Left && marioHitBox.Left < pipeHitbox.Left)
                {
                    Canvas.SetLeft(mario, Canvas.GetLeft(mario) - (marioHitBox.Right - pipeHitbox.Left));
                }
                if (marioHitBox.Left <= pipeHitbox.Right && marioHitBox.Right > pipeHitbox.Right)
                {
                    Canvas.SetLeft(mario, Canvas.GetLeft(mario) + (pipeHitbox.Right - marioHitBox.Left));
                }
            }

            if (marioHitBox.IntersectsWith(bricksHitBox))
            {
                if (marioHitBox.Bottom >= bricksHitBox.Top)
                {
                    Canvas.SetTop(mario, Canvas.GetTop(mario) - (marioHitBox.Bottom - bricksHitBox.Top));
                }
                if (marioHitBox.Right >= bricksHitBox.Left && marioHitBox.Left < bricksHitBox.Left)
                {
                    Canvas.SetLeft(mario, Canvas.GetLeft(mario) - (marioHitBox.Right - bricksHitBox.Left));
                }
                if (marioHitBox.Left <= bricksHitBox.Right && marioHitBox.Right > bricksHitBox.Right)
                {
                    Canvas.SetLeft(mario, Canvas.GetLeft(mario) + (bricksHitBox.Right - marioHitBox.Left));
                }
            }
            if (goLeft && Canvas.GetLeft(mario) < 10)
            {
                noLeft = true;
                goLeft = false;
            }

            if (goRight && Canvas.GetLeft(mario) + 40 > Application.Current.MainWindow.Width)
            {
                noRight = true;
                goRight = false;
            }
            MyCanvas.Focus();

        }
        private void GameOver(string message)
        {
            gameTimer.Stop();
            MessageBox.Show(message, "MARIO IS OVER");

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

    }
}



