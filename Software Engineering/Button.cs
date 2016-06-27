using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Software_Engineering
{
    class Button : Drawable
    {
        public Point position { get; set; }
        public Point size { get; set; }
        private String label;
        private Texture2D background;
        private SpriteFont font;
        private Color textColor = Color.White;
        private MouseState previousState;
        private MouseState currentMouseState;

        public Button(Point position, Point size)
        {
            this.position = position;
            this.size = size;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(position,size), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            previousState = currentMouseState;
            currentMouseState = Mouse.GetState();
            Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousState.LeftButton != ButtonState.Pressed && InRectangle(mousePosition))
            {
                OnClick();
                
            }
        }

        public bool InRectangle(Point position)
        {
            return (position.X > this.position.X && position.X < this.position.X + this.size.X && position.Y > this.position.Y && position.Y < this.position.Y + this.size.Y);
        }

        public Drawable SetBackground(GraphicsDeviceManager graphics, Color color)
        {
            this.background = new Texture2D(graphics.GraphicsDevice, 1, 1);
            this.background.SetData(new[] { color });
            return this;
        }

        public Drawable SetLabel(String label, SpriteFont font)
        {
            return SetLabel(label, font, Color.White);
        }

        public Drawable SetLabel(String label, SpriteFont font, Color color)
        {
            this.textColor = color;
            this.label = label;
            this.font = font;
            return this;
        }

        private void OnClick()
        {
            Random random = new Random();
            Color randomColor = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            this.background.SetData(new[] { randomColor });
        }
    }
}
