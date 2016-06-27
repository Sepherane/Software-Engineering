using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering
{
    interface OptionVisitor<T, U>
    {
        U OnSome(T value, SpriteBatch spriteBatch);
        U OnSome(T value, GameTime gameTime);
        U OnNone();
    }

    class DrawableVisitor : OptionVisitor<Drawable, bool>
    {
        public bool OnNone()
        {
            return false;
        }

        public bool OnSome(Drawable value, SpriteBatch spriteBatch)
        {
            value.Draw(spriteBatch);
            return true;
        }

        public bool OnSome(Drawable value, GameTime gameTime)
        {
            value.Update(gameTime);
            return true;
        }
    }
}
