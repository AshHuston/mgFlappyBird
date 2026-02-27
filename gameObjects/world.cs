using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using MonoGameFlappyBird;
using MonoGameFlappyBird.Functions;
using MonoGameFlappyBird.Inputs;
namespace MonoGameFlappyBird.GameObjects;

public class World
{
    private List<Entity> gameEntities = new List<Entity>();
    public List<Entity> entitiesToAdd = new List<Entity>();
    GameAssets assets;
    Bird bird;
    Game1 game;
    public InputManager _inputManager;

    public World(Game1 _game, GameAssets _assets)
    {
        game = _game;
        assets = _assets;  
        _inputManager = game._inputManager;
        bird = new Bird(assets, new Vector2(200, 200));
        gameEntities.Add(bird);
        gameEntities.Add(new PipeSpawner(this, assets, new Vector2(1900, 360)));
    }

    public void Add(Entity entity)
    {
        entitiesToAdd.Add(entity);
    }

    public void Update(GameTime gameTime) 
    {

        foreach (var e in gameEntities)
        {
            e.Update(gameTime);
            
            try {
                if (e._texture == null) throw new Exception($"{e.GetType().Name} texture is null");
                if (e != bird && EntityFunctions.EntitiesCollide((Entity)e, bird)) {
                    Console.WriteLine($"We DED");
                    //game.Exit();
                }
            } catch (Exception ex) {
                //Console.WriteLine($"Error checking entity collision: {e.GetType().Name} - {ex.Message}");
            }
            
        }

        gameEntities.AddRange(entitiesToAdd);
        entitiesToAdd.Clear();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var e in gameEntities)
        {
            e.Draw(spriteBatch);
        }
    }
}
