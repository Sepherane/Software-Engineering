using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Software_Engineering
{
    interface Option<T>
    {
        U Visit<U>(OptionVisitor<T, U> visitor, SpriteBatch spriteBatch);
        U Visit<U>(OptionVisitor<T, U> visitor, GameTime gameTime);
        bool IsNone();
    }

    class Some<T> : Option<T>
    {
        public T value;
        public Some(T value)
        {
            this.value = value;
        }

        public U Visit<U>(OptionVisitor<T, U> visitor, SpriteBatch spriteBatch)
        {
            return visitor.OnSome(this.value, spriteBatch);
        }

        public U Visit<U>(OptionVisitor<T, U> visitor, GameTime gameTime)
        {
            return visitor.OnSome(this.value, gameTime);
        }

        public bool IsNone()
        {
            return false;
        }
    }
    class None<T> : Option<T>
    {
        public None()
        {

        }

        public U Visit<U>(OptionVisitor<T, U> visitor, SpriteBatch spriteBatch)
        {
            return visitor.OnNone();
        }

        public U Visit<U>(OptionVisitor<T, U> visitor, GameTime gameTime)
        {
            return visitor.OnNone();
        }

        public bool IsNone()
        {
            return true;
        }
    }

    interface Iterator<T>
    {
        Option<T> GetNext();
    }

    class DrawableIterator : Iterator<Drawable>
    {
        List<Drawable> drawables;
        int current = -1;

        public DrawableIterator(List<Drawable> drawables)
        {
            this.drawables = drawables;
        }

        public Option<Drawable> GetNext()
        {
            current++;
            if (current >= drawables.Count)
                return new None<Drawable>();
            else
            {

            }
            return new Some<Drawable>(drawables[current]);
        }
    }
}