using System.Numerics;
using System.Text;
using Raylib_cs;

namespace CoffeeShop;

public class Game
{

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
    }

    private void input()
    {
        // * Get input here
        if (Raylib.IsKeyReleased(KeyboardKey.One))
        {
            Raylib.SetTextureFilter(ResourceManager.GetFont().Texture, TextureFilter.Point);
        }
        else if (Raylib.IsKeyReleased(KeyboardKey.Two))
        {
            Raylib.SetTextureFilter(ResourceManager.GetFont().Texture, TextureFilter.Bilinear);
        }
        else if (Raylib.IsKeyReleased(KeyboardKey.Three))
        {
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
    }

    private void Update()
    {
        // * Update anything here
    }

    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);

        // * Draw anything here
        Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);
        Raylib.DrawTextEx(ResourceManager.GetFont(), "Hello, world!", new Vector2(12, 42), 50, 1, Color.Black);
        Raylib.DrawTextEx(ResourceManager.GetFonts(0), "Hello, world!", new Vector2(12, 1*ResourceManager.GetUiSize()), ResourceManager.GetUiSize(), 0, Color.Black);
        Raylib.DrawTextEx(ResourceManager.GetFonts(1), "Hello, world!", new Vector2(12, 2*ResourceManager.GetUiSize()), ResourceManager.GetUiSize(), 0, Color.Black);
        Raylib.DrawTextEx(ResourceManager.GetFonts(2), NormalizeText("สวัดดีdawf, โลก!"), new Vector2(12, 3*ResourceManager.GetUiSize()), ResourceManager.GetUiSize(), 0, Color.Black);
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