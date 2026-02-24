using Microsoft.Xna.Framework;          // Vector2
using Microsoft.Xna.Framework.Graphics; // Texture2D, SpriteBatch
using Microsoft.Xna.Framework.Input;    // Keyboard (if used)
using System;

public class Bird
{
    Texture2D _texture;
    Vector2 _position;
    float _velocity;

    public Bird(Texture2D texture, Vector2 startPos)
    {
        _texture = texture;
        _position = startPos;
    }

    public void Update(float dt)
    {
        try
        {
            _velocity += 900f * dt; // gravity
            _position.Y += _velocity * dt;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _velocity = -350f; // flap
            }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }
}