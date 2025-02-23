using System.Numerics;
using CoffeeShop.MVC.Controller;
using CoffeeShop.MVC.Model;
using CoffeeShop.MVC.Model.Interface;
using CoffeeShop.MVC.View;
using CoffeeShop.Utile;
using Raylib_cs;

namespace CoffeeShop.Core.Screen;

public class Cafe : ScreenInterface
{
    private PlayerModel playerModel;
    private PlayerController playerController;
    private PlayerRender playerRender;
    
    ScreenTransfer screenTransaction = null;
    
    public Cafe()
    {
        Init();
    }
    
    public void Run()
    {
            Update();
            Draw();
    }
    

    private void Init()
    {
        // Player Model
        playerModel = new PlayerModel();
        playerModel.SetPosition(new Vector2(200, 200));
        playerModel.SetSize(new Vector2(100, 100));
        // Player Controller
        playerController = new PlayerController(ref playerModel);
        // Player Render
        playerRender = new PlayerRender(ref playerModel);
    }

    private void Update()
    {
        playerController.Update();
        ChangeScreen();
        if (screenTransaction != null)
        {
            screenTransaction.Update();
            if (screenTransaction.IsTranferEnd())
            {
                ScreenController.ChangeScreen(new MainMenu()); 
            }
        }
    }

    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        
        playerRender.Render();

        if (screenTransaction != null)
        {
           screenTransaction.Draw();
        }
        
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
            // ScreenController.ChangeScreen(new MainMenu()); 
            screenTransaction = new ScreenTransfer(1.2f);
        }
    }
}