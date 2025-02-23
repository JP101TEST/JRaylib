using CoffeeShop.MVC.Model.Interface;
using System.Numerics;
using CoffeeShop.MVC.Controller;
using Raylib_cs;

namespace CoffeeShop.Core.Screen;

public class MainMenu : ScreenInterface
{
    
    public MainMenu()
    {
        Init();
    }
    public void Run()
    {
        Update();
        Draw();
    }
    
    public void Init()
    {
        
    }   

    public void Update()
    {
        ChangeScreen();
    }

    public void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);

        // * Draw anything here
        Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);
        Raylib.DrawTextEx(ResourceManager.GetFont(), "Hello, world!", new Vector2(12, 42), 50, 1, Color.Black);
        Raylib.DrawTextEx(ResourceManager.GetFonts(0), "Hello, world!",
            new Vector2(12, 1 * ResourceManager.GetUiSize()), ResourceManager.GetUiSize(), 0, Color.Black);
        Raylib.DrawTextEx(ResourceManager.GetFonts(2), "Hello, world!",
            new Vector2(12, 2 * ResourceManager.GetUiSize()), ResourceManager.GetUiSize(), 0, Color.Black);

        Raylib.EndDrawing();   
    }

    public void Dispose()
    {
        
    }
    
    private void ChangeScreen()
    {
        if (Raylib.IsKeyReleased(KeyboardKey.One))
        {
            // ResourceManager.ChangeScreen();
            ScreenController.ChangeScreen(new Cafe());
        }
    }
}