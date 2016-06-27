using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Software_Engineering
{
    internal class Label : Drawable
    {
        private Point position;
        private Point size;

        private SpriteFont font;
        private String label;
        private Color color;

        public Label(Point position, Point size)
        {
            this.position = position;
            this.size = size;
        }

        Point Drawable.position { get; set; }

        Point Drawable.size{ get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 labelSize = font.MeasureString(this.label);
            Vector2 labelPosition = new Vector2(this.position.X + this.size.X / 2 - labelSize.X / 2, this.position.Y + this.size.Y / 2 - labelSize.Y / 2);
            spriteBatch.DrawString(this.font, this.label, labelPosition, color);
        }

        public Drawable SetBackground(GraphicsDeviceManager graphics, Color color)
        {
            throw new NotImplementedException();
        }

        public Drawable SetLabel(string label, SpriteFont font)
        {
            return SetLabel(label, font, Color.White);
        }

        public Drawable SetLabel(string label, SpriteFont font, Color color)
        {
            this.label = label;
            this.font = font;
            this.color = color;
            return this;
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}