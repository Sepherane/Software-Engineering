using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Software_Engineering
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont font;
        private List<Drawable> drawables = new List<Drawable>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Arial");

            DrawableFactory factory = new ConcreteDrawableFactory();
            drawables.Add(new BorderedDrawable(factory.Create(DrawableType.Button, new Point(10, 10), new Point(100, 50)).SetBackground(graphics,Color.Red),graphics,Color.Green,3));
            drawables.Add(factory.Create(DrawableType.Label, new Point(200, 200), new Point(200, 30)).SetLabel("Software Engineering", font, Color.Black));
            drawables.Add(
                new LabeledButton(
                    new BorderedDrawable(
                        factory.Create(DrawableType.Button, new Point(200, 10), new Point(100, 50)).SetBackground(graphics, Color.Red), graphics, Color.White, 3), "Click Me!", font, Color.Yellow)
            );
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Iterator<Drawable> iterator = new DrawableIterator(drawables);
            OptionVisitor<Drawable, bool> visitor = new DrawableVisitor();
            Option<Drawable> a;

            while (!(a = iterator.GetNext()).IsNone())
            {
                a.Visit<bool>(visitor, gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            Iterator<Drawable> iterator = new DrawableIterator(drawables);
            OptionVisitor<Drawable, bool> visitor = new DrawableVisitor();
            Option<Drawable> a;

            while (!(a = iterator.GetNext()).IsNone())
            {
                a.Visit<bool>(visitor, spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}