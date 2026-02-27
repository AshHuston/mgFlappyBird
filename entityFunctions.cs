using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using MonoGameFlappyBird.GameObjects;
namespace MonoGameFlappyBird.Functions;


public static class EntityFunctions
{
    public static bool SpritesCollideRectangles(Vector2 origin1, Vector2 origin2, Texture2D texture1, Texture2D texture2){
        //build rect1
        Rectangle rect1 = new Rectangle(
            (int)MathF.Round(origin1.X),
            (int)MathF.Round(origin1.Y),
            (int)MathF.Round(origin1.X+texture1.Width),
            (int)MathF.Round(origin1.Y+texture1.Height)
        );

        //build rect2
        Rectangle rect2 = new Rectangle(
            (int)MathF.Round(origin2.X),
            (int)MathF.Round(origin2.Y),
            (int)MathF.Round(origin2.X+texture2.Width),
            (int)MathF.Round(origin2.Y+texture2.Height)
        );

        //check if overlap
        return rect1.Intersects(rect2);
    }

    public static bool EntitiesCollide(Entity e1, Entity e2){
        Vector2 origin1 = e1._position;
        Vector2 origin2 = e2._position;
        Texture2D texture1 = e1._texture;
        Texture2D texture2 = e2._texture;

        return SpritesCollideRectangles(origin1, origin2, texture1, texture2);
    }

    public static bool RectangleClicked(Rectangle rect){
        MouseState mouseState = Mouse.GetState();
        return rect.Contains(mouseState.X, mouseState.Y);
    }

    public static bool SpriteClicked(Entity e, bool mouseClicked){
        if (!mouseClicked) { return false; }
        Vector2 origin = e._position;
        Texture2D texture = e._texture;

        //if (e._texture == null) { return false; }

        Rectangle rect = new Rectangle(
            (int)MathF.Round(origin.X),
            (int)MathF.Round(origin.Y),
            texture.Width,
            texture.Height
        );

        return RectangleClicked(rect);
    }

    // THIS IS COMPLETLEY UNTESTED

    // Probably will make a bunch ov overloads for rectangels and circles and being clicked or passong ranges specifically rather than textures. 
}
