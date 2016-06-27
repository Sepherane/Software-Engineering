using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Software_Engineering
{
    abstract class DrawableDecorator : Drawable
    {
        protected Drawable decorated_item;
        public DrawableDecorator(Drawable d)
        {
            this.decorated_item = d;
        }

        public abstract Point position { get; set; }
        public abstract Point size { get; set; }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract Drawable SetBackground(GraphicsDeviceManager graphics, Color color);

        public abstract Drawable SetLabel(string label, SpriteFont font);

        public abstract Drawable SetLabel(string label, SpriteFont font, Color color);

        public abstract void Update(GameTime gameTime);
    }
}
