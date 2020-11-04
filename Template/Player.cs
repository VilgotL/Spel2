using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
	class Player : BaseClass
	{
        public Player(Texture2D t, Vector2 p, Rectangle r): base(t, p, r)
        {
            texture = t;
            position = p;
            rectangle = r;
        }

        public Vector2 Position
        {
            get { return position; }
        }
        public override void Update()
        {
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.D))
                position.X += 3;
            if (kstate.IsKeyDown(Keys.A))
                position.X -= 3;
            if (kstate.IsKeyDown(Keys.W))
                position.Y -= 3;
            if (kstate.IsKeyDown(Keys.S))
                position.Y += 3;
            rectangle.Location = position.ToPoint();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
	}
}
