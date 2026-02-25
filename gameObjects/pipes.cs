using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using MonoGameFlappyBird;

namespace MonoGameFlappyBird.GameObjects;

public class Pipe : Entity
{
    Texture2D _texture;
    Vector2 _position;
    float _velocity;

    GameAssets assets;

    public Pipe(GameAssets _assets, Vector2 startPos)
    {
        assets = _assets;
    }

    public override void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _velocity += 900f * dt; // gravity
        _position.Y += _velocity * dt;

        if (Keyboard.GetState().IsKeyDown(Keys.Space)){ _velocity = -350f; }// flap
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }
}
