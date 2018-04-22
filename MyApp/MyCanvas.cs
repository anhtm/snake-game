using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
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

    public partial class MyCanvas : Form
    {
        int maxHeight;
        int maxWidth;
        int dotWidth = 20;
        int bodyElements = 5;
        int snakeSpeed = 3;
        Dot snakeHead;
        Dot berry;
        Snake snake;
        int score = 0;
        //bool gameOver = false;

        public MyCanvas()
        {
            
            InitializeComponent();
            // height = 600
            maxHeight = this.ClientSize.Height;
            // width = 700
            maxWidth = this.ClientSize.Width;
            this.KeyPreview = true;
            CreateSnake();
            CreateBerry();
            // Create a timer and set a two second interval.
            timer.Interval = 1000 / snakeSpeed;
            timer.Tick += this.UpdateGameSession;
            timer.Start();
            timer2.Interval = 1000 / snakeSpeed;
            timer2.Tick += this.UpdateGameStatus;
            timer2.Start();
        }

        private void StartNewGame() {
            snakeSpeed = 3;
            score = 0;
            bodyElements = 5;
            CreateSnake();
            CreateBerry();
        }

        // Draw the initial snake
        private void CreateSnake() {
            Point p = new Point(100, 100);
            snakeHead = new Dot(p, Color.Brown, dotWidth);
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

        // Add a new body part at the end of the snake when it eats a berry
        private void AddBodyPart(int index) {
            Directions snakeDirection = snake.Direction;
            Point p = snake.Body[0].Location;
            int x;
            int y;
            if (snakeDirection == Directions.Up)
            {
                // keep x as it is
                x = p.X;
                // y set into a verticle line; downward
                y = (p.Y + index * dotWidth);
            }
            else if (snakeDirection == Directions.Down)
            {
                // keep x as it is
                x = p.X;
                // y set into a verticle line; upward
                y = (p.Y - index * dotWidth);
            }
            else if (snakeDirection == Directions.Left)
            {
                x = p.X + index * dotWidth;
                y = p.Y;
            }
            else
            {
                x = p.X - index * dotWidth;
                y = p.Y;
            }

            Point bodyPoint = new Point(x, y);
            Dot dot = new Dot(bodyPoint, Color.Black, dotWidth);

            snake.Body.Add(dot);
        }

        // Create berry randomly
        private void CreateBerry() {
            Random rnd = new Random();
            int randomX = rnd.Next(0, maxWidth / 20) * 20;
            int randomY = rnd.Next(0, maxHeight / 20) * 20;
            Point randomPoint = new Point(randomX, randomY);
            berry = new Dot(randomPoint, Color.HotPink, dotWidth);
        }

        private void UpdateGameSession(object sender, EventArgs e)
        {
            //Update snake Direction
            UpdateSnakeHeading(snake.Direction);
            //Refresh the screen to redraw snake
            this.Refresh();
        }

        //Update snake heading recalculate teh position of the head based on the heading
        private void UpdateSnakeHeading(Directions d)
        {
            Point newPoint;

            //Assigning New Location for the body Elements (black Dot) 
            var upperIndex = snake.Body.Count - 2;
            for (int i = upperIndex; i > -1; i--)
            {
                Point pt = snake.Body[i].Location;
                snake.Body[i + 1].Location = pt;
            }

            if (d == Directions.Right && snake.Direction != Directions.Left)
            {
                newPoint = new Point(snake.Body[0].Location.X + dotWidth, snake.Body[0].Location.Y);
                snake.Body[0].Location = newPoint;
                snake.Direction = d;
            }
            if (d == Directions.Left && snake.Direction != Directions.Right)
            {
                newPoint = new Point(snake.Body[0].Location.X - dotWidth, snake.Body[0].Location.Y);
                snake.Body[0].Location = newPoint;
                snake.Direction = d;
            }
            if (d == Directions.Up && snake.Direction != Directions.Down)
            {
                newPoint = new Point(snake.Body[0].Location.X, snake.Body[0].Location.Y - dotWidth);
                snake.Body[0].Location = newPoint;
                snake.Direction = d;
            }
            if (d == Directions.Down && snake.Direction != Directions.Up)
            {
                newPoint = new Point(snake.Body[0].Location.X, snake.Body[0].Location.Y + dotWidth);
                snake.Direction = d;
                snake.Body[0].Location = newPoint;
            }

            // Update label during each interval
            label1.Text = "Score: " + score;
            label2.Text = "Speed: " + (snakeSpeed - 2);
        }

        // Update score, speed, bodyElements and Canvas regarding the status
        private void UpdateGameStatus(object sender, EventArgs e) {
            int headX = snake.Body[0].Location.X;
            int headY = snake.Body[0].Location.Y;

            // check if snake has eaten a berry
            if (headX == berry.Location.X && headY == berry.Location.Y) {
                score += 10;
                TrackSpeed();
                bodyElements++;
                CreateBerry();
                AddBodyPart(bodyElements - 1);
                this.Refresh();
            }

            // check if snake has biten itself
            for (int i = 1; i < snake.Body.Count; i++) {
                if (headX == snake.Body[i].Location.X && headY == snake.Body[i].Location.Y) {
                    StartNewGame();
                    TrackSpeed();
                    this.Refresh();
                }
            }

            // check if snake has hit the wall
            if (headX > maxWidth || headY > maxHeight || headX < 0 || headY < 0) {
                StartNewGame();
                TrackSpeed();
                this.Refresh();
            }
        }

        // Keep track of speed regarding the score
        private void TrackSpeed() {
            // increase snakeSpeed every 3 points
            if (score % 30 == 0 && score != 0)
            {
                snakeSpeed++;
                timer.Interval = 1000 / snakeSpeed;
                timer2.Interval = 1000 / snakeSpeed;
            }
            if (score == 0) {
                snakeSpeed = 3;
                timer.Interval = 1000 / snakeSpeed;
                timer2.Interval = 1000 / snakeSpeed;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keydata)
        {
            if (keydata == Keys.Up && snake.Direction != Directions.Down)
            {
                UpdateSnakeHeading(Directions.Up);
                return true;
            }
            if (keydata == Keys.Down && snake.Direction != Directions.Up)
            {
                UpdateSnakeHeading(Directions.Down);
                return true;
            }
            if (keydata == Keys.Left && snake.Direction != Directions.Right)
            {
                UpdateSnakeHeading(Directions.Left);
                return true;
            }
            if (keydata == Keys.Right && snake.Direction != Directions.Left)
            {
                UpdateSnakeHeading(Directions.Right);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keydata);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw border 
            Pen borderPen = new Pen(Color.Black, 3);
            Rectangle border = new Rectangle(1, 1, maxWidth, maxHeight);
            SolidBrush borderBrush = new SolidBrush(Color.White);
            e.Graphics.DrawRectangle(borderPen, border);
            e.Graphics.FillRectangle(borderBrush, border);

            // Draw berry
            int berryWidth = dotWidth;
            SolidBrush berryBrush = new SolidBrush(berry.Color);
            Rectangle berrySquare = new Rectangle(berry.Location.X,
                                                  berry.Location.Y,
                                                  berryWidth,
                                                  berryWidth);
            e.Graphics.FillRectangle(berryBrush, berrySquare);

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

            base.OnPaint(e);
        }

        private void CanvasLoad(object sender, EventArgs e)
        {
            
        }
    }
}