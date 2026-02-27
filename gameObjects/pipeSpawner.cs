using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        if (framesPerSpawn == 0) { 
            Random random = new Random();
            int rangeFloor = (int) (_position.Y-180f);
            int rangeCeiling = (int) (_position.Y+180f);
            int height = random.Next(rangeFloor, rangeCeiling);
            Vector2 spawnPos = new Vector2(_position.X, height);
            world.entitiesToAdd.Add(new Pipe(world, assets, spawnPos, false));
            framesPerSpawn = 120;
        }
        framesPerSpawn--;
    }

    public override void Draw(SpriteBatch spriteBatch) {}
}
