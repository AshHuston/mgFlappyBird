using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MonoGameFlappyBird.GameObjects;

public abstract class Entity
{
    public bool IsAlive = true;
    public Texture2D _texture;
    public Vector2 _position;
    protected World world;
    protected GameAssets assets;

    public virtual void Update(GameTime gameTime) { }
    public virtual void Draw(SpriteBatch spriteBatch) { }
}
