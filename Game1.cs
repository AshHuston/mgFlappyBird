using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using MonoGameFlappyBird.GameObjects;

namespace MonoGameFlappyBird;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Bird _bird;
    private GameAssets _assets;

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

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _assets = new GameAssets();

        _assets.Bird1 = Content.Load<Texture2D>("bird1");
        _assets.Bird2 = Content.Load<Texture2D>("bird2");
        _assets.Bird3 = Content.Load<Texture2D>("bird3");
        _assets.Pipe = Content.Load<Texture2D>("pipe");
        _bird = new Bird(_assets, new Vector2(200, 200));

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        //     Exit();

        //float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _bird.Update(gameTime);
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _bird.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
