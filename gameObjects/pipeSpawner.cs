using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace MonoGameFlappyBird.GameObjects;

public class PipeSpawner : Entity
{
    World world;
    Vector2 _position;
    GameAssets assets;
    int framesPerSpawn;

    public PipeSpawner(World _world, GameAssets _assets, Vector2 startPos)
    {
        world = _world;
        _position = startPos;
        assets = _assets;
    }

    public override void Update(GameTime gameTime)
    {
        if (framesPerSpawn %120 == 0) { 
            Random random = new Random();
            int height = random.Next(50, 450);
            Vector2 spawnPos = new Vector2(_position.X, height);
            world.entitiesToAdd.Add(new Pipe(world, assets, spawnPos, false));
        }
        framesPerSpawn++;
    }

    public override void Draw(SpriteBatch spriteBatch) {}
}
