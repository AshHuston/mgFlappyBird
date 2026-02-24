using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameFlappyBird.GameObjects;

public class Bird : Entity
{
    Texture2D _texture;
    Vector2 _position;
    float _velocity;

    public Bird(GameAssets _assets, Vector2 startPos)
    {
        _texture = _assets.Bird1;
        _position = startPos;
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
        spriteBatch.Draw(_texture, _position, Color.Blue);
    }
}
