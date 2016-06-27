using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering
{
    abstract class DrawableFactory
    {
        public abstract Drawable Create(DrawableType type, Point position, Point size);
    }
    class ConcreteDrawableFactory : DrawableFactory
    {
        public override Drawable Create(DrawableType type, Point position, Point size)
        {
            if (type == DrawableType.Button)
                return new Button(position, size);
            if (type == DrawableType.Label)
                return new Label(position, size);
            if (type == DrawableType.Panel)
                return new Panel(position, size);

            return null;
        }
    }

    enum DrawableType
    {
        Panel,
        Button,
        Label
    }
}