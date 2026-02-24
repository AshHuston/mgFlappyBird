using System;

try
{
    using var game = new MonoGameFlappyBird.Game1();
    game.Run();
}
catch(Exception e)
{
    Console.WriteLine(e);
    Console.ReadLine();
}