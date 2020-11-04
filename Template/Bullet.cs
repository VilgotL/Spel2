using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    class Bullet : BaseClass
    {
        public Bullet(Texture2D t, Vector2 p, Rectangle r) : base(t, p, r)
        {
            texture = t;
            position = p;
            rectangle = r;
        }

        public override void Update()
        {
            position.Y -= 5;
            rectangle.Location = position.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
