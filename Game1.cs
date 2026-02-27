using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using MonoGameFlappyBird.GameObjects;
using MonoGameFlappyBird.Inputs;

namespace MonoGameFlappyBird;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private World _world;
    private GameAssets _assets;
    public InputManager _inputManager = new InputManager();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;

    _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _assets = new GameAssets();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        
        _assets.Bird1 = Content.Load<Texture2D>("bird1");
        _assets.Bird2 = Content.Load<Texture2D>("bird2");
        _assets.Bird3 = Content.Load<Texture2D>("bird3");
        _assets.Pipe = Content.Load<Texture2D>("pipe");
        _world = new World(this, _assets);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        _inputManager.Update();
        
        _world.Update(gameTime);

        _inputManager.EndUpdate();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _world.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
