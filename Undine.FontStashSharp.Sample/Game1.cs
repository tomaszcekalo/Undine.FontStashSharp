using System;
using System.IO;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Undine.Core;
using Undine.LeopotamEcs;
using Undine.MonoGame;

namespace Undine.FontStashSharp.Sample
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ISystem _FontStashSharpSystem;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        private const int AtlasesPerRow = 6;
        private const int AtlasSize = 256;
        private FontSystem _fontSystem;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var settings = new FontSystemSettings
            {
                TextureWidth = AtlasSize,
                TextureHeight = AtlasSize
            };
            _fontSystem = new FontSystem(settings);
            _fontSystem.AddFont(File.ReadAllBytes(@"Fonts/DroidSans.ttf"));
            var font = _fontSystem.GetFont(40);

            // TODO: use this.Content to load your game content here
            var container = new LeopotamEcsContainer();
            _FontStashSharpSystem = container.GetSystem(new FontStashSharpSystem(_spriteBatch));
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new FontStashSharpComponent()
            {
                Text = "TEST",
                Font = font,
                FontSystemEffect = FontSystemEffect.Stroked,
                EffectAmount = 2
            });
            entity.AddComponent(new TransformComponent()
            {
                Scale = Vector2.One,
                Position = _spriteBatch.GraphicsDevice.Viewport.Bounds.Center.ToVector2()
            });
            entity.AddComponent(new ColorComponent()
            {
                Color = Color.White,
            });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _FontStashSharpSystem.ProcessAll();

            base.Draw(gameTime);
        }

        private void LoadFontSystem(FontSystem result)
        {
            result.AddFont(File.ReadAllBytes(@"Fonts/DroidSans.ttf"));
        }
    }
}