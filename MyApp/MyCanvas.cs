using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace MyApp
{
    public enum Directions
    {
        Up,
        Down,
        Left,
        Right
    }

    public class MyCanvas : Form
    {
        // No properties.
        int maxHeight;
        int maxWidth;
        int dotWidth = 10;
        int bodyElements = 3;
        int snakeSpeed = 1;
        Dot snakeHead;
        Dot berry;
        Snake snake;

        public MyCanvas()
        {
            // Default constructor
            // height = 273

            maxHeight = this.ClientSize.Height / dotWidth;
            // width = 292
            maxWidth = this.ClientSize.Width / dotWidth;
            //InitializeComponent();
            //this.KeyPreview = true;
            this.CreateSnake();
            this.CreateBerry();
            // Create a timer and set a two second interval.
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 5000 / snakeSpeed;
            //timer1.Tick += UpdateGameSession();
            timer1.Start();

        }

        // Draw the initial snake
        private void CreateSnake() {
            Point p = new Point(100,100);
            snakeHead = new Dot(p, Color.Azure, dotWidth);
            snake = new Snake();
            snake.Body.Add(snakeHead);
            Directions snakeDirection = snake.Direction;
            for (int i = 1; i < bodyElements; i++)
            {
                int x;
                int y;
                if (snakeDirection == Directions.Up)
                {
                    // keep x as it is
                    x = p.X;
                    // y set into a verticle line; downward
                    y = (p.Y + i * dotWidth);
                }
                else if (snakeDirection == Directions.Down)
                {
                    // keep x as it is
                    x = p.X;
                    // y set into a verticle line; upward
                    y = (p.Y - i * dotWidth);
                }
                else if (snakeDirection == Directions.Left)
                {
                    x = p.X + i * dotWidth;
                    y = p.Y;
                }
                else
                {
                    x = p.X - i * dotWidth;
                    y = p.Y;
                }

                Point bodyPoint = new Point(x, y);
                Dot dot = new Dot(bodyPoint, Color.Black, dotWidth);

                snake.Body.Add(dot);
            }
        }

        private void CreateBerry() {
            Random rnd = new Random();
            int randomX = rnd.Next(10, 100);
            int randomY = rnd.Next(10, 100);
            Point randomPoint = new Point(randomX, randomY);
            berry = new Dot(randomPoint, Color.HotPink, dotWidth);
        }

        private void UpdateGameSession() {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw snake head
            SolidBrush headBrush = new SolidBrush(snakeHead.Color);
            Rectangle headSquare = new Rectangle(snakeHead.Location.X,
                                                  snakeHead.Location.Y,
                                                  dotWidth,
                                                  dotWidth);
            e.Graphics.FillRectangle(headBrush, headSquare);

            // Draw snake body
            foreach (var item in snake.Body)
            {
                SolidBrush blackBrush = new SolidBrush(item.Color);
                e.Graphics.FillRectangle(blackBrush, item.Location.X, item.Location.Y, item.Width, item.Width);
            }

            // Draw berry
            SolidBrush berryBrush = new SolidBrush(berry.Color);
            Rectangle berrySquare = new Rectangle(berry.Location.X,
                                                  berry.Location.Y,
                                                  dotWidth,
                                                  dotWidth);
            e.Graphics.FillRectangle(berryBrush, berrySquare);

            base.OnPaint(e);
        }
    }
}