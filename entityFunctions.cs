using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MonoGameFlappyBird.Functions;

public bool spritesCollideRectangles(Vector2 origin1, Vector2 origin2, Texture2D texture1, Texture2D texture1){
    //build rect1
    Rectangle rect1 = new Rectangle(origin1.X, origin1.Y, origin1.X+texture1.Width, origin1.Y+texture1.height);

    //build rect2
    Rectangle rect2 = new Rectangle(origin2.X, origin2.Y, origin2.X+texture2.Width, origin2.Y+texture2.Width);

    //check if overlap
    return rect1.Intersects(rect2);
}

// THIS IS COMPLETLEY UNTESTED

// Probably will make a bunch ov overloads for rectangels and circles and being clicked or passong ranges specifically rather than textures. 