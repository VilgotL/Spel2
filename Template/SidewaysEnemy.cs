using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Template
{
    class SidewaysEnemy : BaseClass
    {
        protected float speed = 2f;
        protected static Stopwatch time = new Stopwatch();
        protected static Random rnd = new Random();

        public SidewaysEnemy(Texture2D t, Vector2 p, Rectangle r) : base(t, p, r)
        {
            texture = t;
            position = p;
            rectangle = r;
        }

        public int YPos
        {
            get;
            private set;
        }

        public void Remove()
        {
            speed = 0;
            position.X = -100;
            position.Y = -100;
        }

        public void UpdateForEach()
        {
            YPos = rnd.Next(400, 801);
        }

        public override void Update()
        {
            position.X += speed;
            rectangle.Location = position.ToPoint();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.Red);
        }
    }
}