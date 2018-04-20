using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        int maxHeight = 0;
        int maxWidth = 0;
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
            int maxPosY = this.ClientSize.Height / dotWidth;
            // width = 292
            int maxPosX = this.ClientSize.Width / dotWidth;
            //InitializeComponent();
            this.KeyPreview = true;
            this.createSnake();
            this.createBerry();
            //timer1.Interval = 5000 / snakeSpeed;
            //timer1.Tick += UpdateGameSession();
            //timer1.Start();

        }

        private void createSnake() {
            Point p = new Point(100,100);
            snakeHead = new Dot(p, Color.Azure, dotWidth);
            snake = new Snake();
            snake.Body.Add(snakeHead);
        }

        private void createBerry() {
            Random rnd = new Random();
            int randomX = rnd.Next(10, 100);
            int randomY = rnd.Next(10, 100);
            Point randomPoint = new Point(randomX, randomY);
            berry = new Dot(randomPoint, Color.HotPink, dotWidth);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw snake
            SolidBrush headBrush = new SolidBrush(snakeHead.Color);
            Rectangle headSquare = new Rectangle(snakeHead.Location.X,
                                                  snakeHead.Location.Y,
                                                  dotWidth,
                                                  dotWidth);
            for (int i = 1; i <= bodyElements; i++) {
                Rectangle snakeBody = new Rectangle(snakeHead.Location.X - i * dotWidth,
                                                    snakeHead.Location.Y - i * dotWidth,
                                                   dotWidth,
                                                    dotWidth);
                e.Graphics.FillRectangle(headBrush, headSquare);
            }

            e.Graphics.FillRectangle(headBrush, headSquare);

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