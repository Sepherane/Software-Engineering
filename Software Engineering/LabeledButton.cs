using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Software_Engineering
{
    class LabeledButton : DrawableDecorator
    {
        String label;
        SpriteFont font;
        Color color;

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

        public LabeledButton(Drawable button, String label, SpriteFont font, Color color) : base(button)
        {
            this.label = label;
            this.font = font;
            this.color = color;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.decorated_item.Draw(spriteBatch);

            // Center the text nicely
            Vector2 labelSize = font.MeasureString(this.label);
            Vector2 labelPosition = new Vector2(this.position.X + this.size.X / 2 - labelSize.X / 2, this.position.Y + this.size.Y / 2 - labelSize.Y / 2);
            spriteBatch.DrawString(this.font, this.label, labelPosition, color);
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
