using System;

namespace MyApp
{
    public class Config
    {

        public static int maxHeight;
        public static int maxWidth;
        public static int period;
        public static int dotWidth;
        public static int bodyElements;
        public static int snakeSpeed;
        public static int score;
        public static int highScore;
        public static bool gameOver;

        public Config()
        {
            maxWidth = 0;
            maxHeight = 0;
            period = 800;
            dotWidth = 20;
            bodyElements = 5;
            snakeSpeed = 5;
            score = 0;
            highScore = 0;
            gameOver = false;

        }

        public static int MaxHeight
        {
            get
            {
                return maxHeight;
            }
            set
            {
                maxHeight = value;
            }
        }

        public static int MaxWidth
        {
            get
            {
                return maxWidth;
            }
            set
            {
                maxWidth = value;
            }
        }

        public static int Period
        {
            get
            {
                return period;
            }
            set
            {
                period = value;
            }
        }

        public static int DotWidth
        {
            get
            {
                return dotWidth;
            }
            set
            {
                dotWidth = value;
            }
        }

        public static int BodyElements
        {
            get
            {
                return bodyElements;
            }
            set
            {
                bodyElements = value;
            }
        }

        public static int SnakeSpeed
        {
            get
            {
                return snakeSpeed;
            }
            set
            {
                snakeSpeed = value;
            }
        }

        public static int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public static int HighScore
        {
            get
            {
                return highScore;
            }
            set
            {
                highScore = value;
            }
        }

        public static bool GameOver
        {
            get
            {
                return gameOver;
            }
            set
            {
                gameOver = value;
            }
        }

    }
}
