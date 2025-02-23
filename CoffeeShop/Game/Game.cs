using System.Numerics;
using System.Text;
using CoffeeShop.Core.Screen;
using CoffeeShop.MVC.Controller;
using CoffeeShop.MVC.Model;
using CoffeeShop.MVC.View;
using Raylib_cs;

namespace CoffeeShop;

public class Game
{
    
    public void Run()
    {
        Init();
        while (!Raylib.WindowShouldClose())
        {
           ScreenController.Run();
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

        // Screen Controller
       ScreenController.SetScreen(new MainMenu());
    }
    
    private void Dispose()
    {
        // ถ้ามี Texture หรือ Font ที่โหลดมา ควร Unload ที่นี่
        Raylib.UnloadFont(ResourceManager.GetFont());
        ScreenController.Dispose();
    }

    // ฟังก์ชัน Normalize แก้ปัญหาสระลอย
    private string NormalizeText(string text)
    {
        return text.Normalize(NormalizationForm.FormC);
    }
}