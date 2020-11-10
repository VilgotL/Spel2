using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Template
{
    class BaseClass
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Rectangle rectangle;

        public BaseClass(Texture2D t, Vector2 p, Rectangle r)
        {
            texture = t;
            position = p;
            rectangle = r;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
