namespace MonoGameFlappyBird.GameObjects;

public class PipeSpawner : Entity
{
    World world;
    int framesPerSpawn;

    public PipeSpawner(World _world)
    {
        world = _world;
    }

    public override void Update(GameTime gameTime)
    {
       // if time to spawn:                                 Edit this too.
       world.gameEntities.Add(new Pipe(assets, new Vector2(200, 200)));
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }
}