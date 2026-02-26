using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MonoGameFlappyBird.GameObjects;

public class World
{
    private List<Entity> gameEntities = new List<Entity>();
    public List<Entity> entitiesToAdd = new List<Entity>();
    GameAssets assets;

    public World(GameAssets _assets)
    {
        assets = _assets;
        gameEntities.Add(new Bird(assets, new Vector2(200, 200)));
        gameEntities.Add(new PipeSpawner(this, assets, new Vector2(1000, 200)));
    }

    public void Add(Entity entity)
    {
        entitiesToAdd.Add(entity);
    }

    public void Update(GameTime gameTime) {
        foreach (var e in gameEntities)
        {
            e.Update(gameTime);
        }

        gameEntities.AddRange(entitiesToAdd);
        entitiesToAdd.Clear();
    }

    public void Draw(SpriteBatch spriteBatch) {
        foreach (var e in gameEntities)
        {
            e.Draw(spriteBatch);
        }
    }
}
