using Microsoft.Xna.Framework;          // core types
using Microsoft.Xna.Framework.Graphics; // drawing
using Microsoft.Xna.Framework.Input;    // keyboard input
using System;

public class Game1 : Game
{
    GraphicsDeviceManager _graphics; // manages window
    SpriteBatch _spriteBatch;        // draws textures

    Texture2D _square;               // 1x1 texture
    Vector2 _position = new Vector2(200, 200); // square position
    float _speed = 200f;             // pixels per second

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this); // init graphics
        Content.RootDirectory = "Content";           // content folder
        IsMouseVisible = true;                       // show cursor
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice); // init spritebatch

        _square = new Texture2D(GraphicsDevice, 1, 1);  // create 1x1 texture
        _square.SetData(new[] { Color.White });         // fill white
        Console.WriteLine("load");
    }

    protected override void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds; // delta time
        var keyboard = Keyboard.GetState();                      // read input

        if (keyboard.IsKeyDown(Keys.Escape))
            Exit(); // quit game

        Vector2 direction = Vector2.Zero; // movement vector

        if (keyboard.IsKeyDown(Keys.W)) direction.Y -= 1;
        if (keyboard.IsKeyDown(Keys.S)) direction.Y += 1;
        if (keyboard.IsKeyDown(Keys.A)) direction.X -= 1;
        if (keyboard.IsKeyDown(Keys.D)) direction.X += 1;

        if (direction != Vector2.Zero)
            direction.Normalize(); // prevent faster diagonal

        _position += direction * _speed * dt; // move square

        base.Update(gameTime); // required call
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue); // clear screen
               
        _spriteBatch.Begin(); // start drawing

        _spriteBatch.Draw(
            _square,
            new Rectangle((int)_position.X, (int)_position.Y, 50, 50),
            Color.Red); // draw 50x50 square

        _spriteBatch.End(); // finish drawing

        base.Draw(gameTime); // required call
    }
}