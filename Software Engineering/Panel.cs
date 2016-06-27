using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Software_Engineering
{
    internal class Panel : Drawable
    {
        private Point position;
        private Point size;
        private Texture2D background;

        public Panel(Point position, Point size)
        {
            this.position = position;
            this.size = size;
        }

        Point Drawable.position { get;set; }

        Point Drawable.size {get; set;}

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(position, size), Color.White);
        }

        public Drawable SetBackground(GraphicsDeviceManager graphics, Color color)
        {
            this.background = new Texture2D(graphics.GraphicsDevice, 1, 1);
            this.background.SetData(new[] { color });
            return this;
        }

        public Drawable SetLabel(string label, SpriteFont font)
        {
            throw new NotImplementedException();
        }

        public Drawable SetLabel(string label, SpriteFont font, Color color)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}