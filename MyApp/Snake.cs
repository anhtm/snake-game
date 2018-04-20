using System;
using System.Collections.Generic;

namespace MyApp
{
    public class Snake
    {
        private List<Dot> body;
        private Directions direction;

        internal List<Dot> Body
        {
            get => body;
            set => body = value;
        }

        public Directions Direction
        {
            get => direction;
            set => direction = value;
        }

        public Snake()
        {
            body = new List<Dot>();
            direction = Directions.Right;
        }
    }
}
