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
    GameAssets assets;
    bool flipped;
    int spacing;
    float rotation;
    int speed = 5;

    public Pipe(World world, GameAssets _assets, Vector2 startPos, bool _flipped = false)
    {
        assets = _assets;
        _texture = _assets.Pipe;
        _position = startPos;
        flipped = _flipped;

        if (flipped) {
            Random random = new Random();
            spacing = random.Next(125, 350); 
            _position.Y -= spacing;
            rotation = MathHelper.ToRadians(180f);
        } else{
            world.entitiesToAdd.Add(new Pipe(world, assets, _position, true));
        }
    }

    public override void Update(GameTime gameTime)
    {
        _position.X -= speed;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!flipped) {
            spriteBatch.Draw(_texture, _position, Color.White);
        } else {

            Vector2 origin = new Vector2(
                0,//_texture.Width ,
                _texture.Height
            );            

            spriteBatch.Draw(
                _texture,
                _position,
                null,
                Color.White,
                MathF.PI/9999999,
                origin,
                1f,
                SpriteEffects.FlipVertically,
                0f
           );
        }
    }
}
