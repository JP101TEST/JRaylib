using System.Numerics;
using System.Text;
using CoffeeShop.Ui;
using CoffeeShop.Ui.Controller;
using CoffeeShop.Ui.Model;
using Raylib_cs;

namespace CoffeeShop;

public class Game
{
    public CPanel panel;
    
    public void Run()
    {
        Init();
        while (!Raylib.WindowShouldClose())
        {
            input();
            Update();
            Draw();
        }

        Dispose();
        Raylib.CloseWindow();
    }

    private void Init()
    {
        // * Initialize anything here
        Raylib.InitWindow(800, 480, "Hello World");

        Raylib.SetTargetFPS(60);

        ResourceManager.SetFont(Raylib.LoadFontEx("Font/School Teachers.otf", 96, null, 0));
        ResourceManager.LoadAllFronts();
        
        panel = new CPanel(new MPanel());
        panel.GetPanel().SetSize(new Vector2(350, 200));
        panel.GetPanel().SetColor(Color.Gray);
    }

    private void input()
    {
        // * Get input here
        if (Raylib.IsKeyReleased(KeyboardKey.One))
        {
            Console.WriteLine("Texture Filter: Point" );
            Raylib.SetTextureFilter(ResourceManager.GetFont().Texture, TextureFilter.Point);
        }
        else if (Raylib.IsKeyReleased(KeyboardKey.Two))
        {
            Console.WriteLine("Texture Filter: Bilinear" );
            Raylib.SetTextureFilter(ResourceManager.GetFont().Texture, TextureFilter.Bilinear);
        }
        else if (Raylib.IsKeyReleased(KeyboardKey.Three))
        {
            Console.WriteLine("Texture Filter: Trilinear" );
            Raylib.SetTextureFilter(ResourceManager.GetFont().Texture, TextureFilter.Trilinear);
        }

        if (Raylib.GetMouseWheelMove() > 0)
        {
            ResourceManager.AddUiSize(1);
        }
        else if (Raylib.GetMouseWheelMove() < 0)
        {
            ResourceManager.AddUiSize(-1);
        }
        
        panel.Input();
    }

    private void Update()
    {
        // * Update anything here
        panel.Update();
    }

    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);

        // * Draw anything here
        Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);
        Raylib.DrawTextEx(ResourceManager.GetFont(), "Hello, world!", new Vector2(12, 42), 50, 1, Color.Black);
        Raylib.DrawTextEx(ResourceManager.GetFonts(0), "Hello, world!", new Vector2(12, 1*ResourceManager.GetUiSize()), ResourceManager.GetUiSize(), 0, Color.Black);
        Raylib.DrawTextEx(ResourceManager.GetFonts(2), "Hello, world!", new Vector2(12, 2*ResourceManager.GetUiSize()), ResourceManager.GetUiSize(), 0, Color.Black);
        
        panel.Draw();
        
        Raylib.EndDrawing();
    }

    private void Dispose()
    {
    }
    
    // ฟังก์ชัน Normalize แก้ปัญหาสระลอย
    private string NormalizeText(string text)
    {
        return text.Normalize(NormalizationForm.FormC);
    }
}