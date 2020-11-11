using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Template
{
    class Enemy : BaseClass
    {
        protected float speed = 2f;

        public Enemy(Texture2D t, Vector2 p, Rectangle r) : base(t, p, r)
        {
            texture = t;
            position = p;
            rectangle = r;
        }

        public void Remove()
        {
            speed = 0;
            position.X = -100;
            position.Y = -100;
        }

        public override void Update()
        {
            position.Y += speed;
            rectangle.Location = position.ToPoint();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.Red);
        }
    }
}
