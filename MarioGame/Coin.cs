using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MarioGame
{
    internal class Coin
    {
        // Method to make a coin disappear
        public static void Disappear(params Ellipse[] coins)
        {
            foreach (Ellipse coin in coins)
            {
                coin.Fill = Brushes.Transparent;
            }
        }

        // Method to check if Mario has collided with the coin
        public static bool CheckCollision(Rectangle mario, params Ellipse[] coins)
        {
            Rect marioHitBox = new Rect(Canvas.GetLeft(mario), Canvas.GetTop(mario), mario.Width, mario.Height);

            foreach (Ellipse coin in coins)
            {
                Rect coinRect = new Rect(Canvas.GetLeft(coin), Canvas.GetTop(coin), coin.Width, coin.Height);
                if (marioHitBox.IntersectsWith(coinRect))
                {
                    return true;
                }
            }

            return false;
        }


    }
}
