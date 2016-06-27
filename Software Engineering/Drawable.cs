using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Software_Engineering
{
    public interface Drawable
    {
        Point position { get; set; }
        Point size { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        Drawable SetBackground(GraphicsDeviceManager graphics, Color color);
        Drawable SetLabel(String label, SpriteFont font);
        Drawable SetLabel(String label, SpriteFont font, Color color);
    }
}
