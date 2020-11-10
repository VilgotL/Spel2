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
        public Enemy(Texture2D t, Vector2 p, Rectangle r) : base(t, p, r)
        {
            texture = t;
            position = p;
            rectangle = r;
        }

        public override void Update()
        {
            position.Y += 2;
            rectangle.Location = position.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.Red);
        }
    }
}
