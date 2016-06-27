using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Software_Engineering
{
    class BorderedDrawable : DrawableDecorator
    {
        Texture2D borderTexture;
        Color borderColor;
        int borderWidth;

        public BorderedDrawable(Drawable d, GraphicsDeviceManager graphics, Color borderColor, int width) : base(d)
        {
            borderTexture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            borderTexture.SetData(new[] { Color.White }); // so that we can draw whatever color we want on top of it
            this.borderColor = borderColor;
            this.borderWidth = width;
        }

        public override Point position
        {
            get
            {
                return base.decorated_item.position;
            }

            set
            {
                base.decorated_item.position = value;
            }
        }

        public override Point size
        {
            get
            {
                return base.decorated_item.size;
            }

            set
            {
                base.decorated_item.size = value;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.decorated_item.Draw(spriteBatch);

            Rectangle item = new Rectangle(position, size);

            // Draw top line
            spriteBatch.Draw(borderTexture, new Rectangle(item.X, item.Y, item.Width, borderWidth), borderColor);

            // Draw left line
            spriteBatch.Draw(borderTexture, new Rectangle(item.X, item.Y, borderWidth, item.Height), borderColor);

            // Draw right line
            spriteBatch.Draw(borderTexture, new Rectangle((item.X + item.Width - borderWidth),
                                            item.Y,
                                            borderWidth,
                                            item.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(borderTexture, new Rectangle(item.X,
                                            item.Y + item.Height - borderWidth,
                                            item.Width,
                                            borderWidth), borderColor);
        }
    

        public override Drawable SetBackground(GraphicsDeviceManager graphics, Color color)
        {
            return base.decorated_item.SetBackground(graphics, color);
        }

        public override Drawable SetLabel(string label, SpriteFont font)
        {
            return base.decorated_item.SetLabel(label, font);
        }

        public override Drawable SetLabel(string label, SpriteFont font, Color color)
        {
            return base.decorated_item.SetLabel(label, font, color);
        }

        public override void Update(GameTime gameTime)
        {
            base.decorated_item.Update(gameTime);
        }
    }
}
