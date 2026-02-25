using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MonoGameFlappyBird.GameObjects;

public class World
{
    public List<Entity> gameEntities = new List<Entity>();
    GameAssets assets;

    public World(GameAssets _assets)
    {
        assets = _assets;
        gameEntities.Add(new Bird(assets, new Vector2(200, 200)));
        gameEntities.Add(new (assets, new Vector2(200, 200)));
    }

    public void Update(GameTime gameTime) {
        foreach (var e in gameEntities)
        {
            e.Update(gameTime);
        }
    }

    public void Draw(SpriteBatch spriteBatch) {
        foreach (var e in gameEntities)
        {
            e.Draw(spriteBatch);
        }
    }
}