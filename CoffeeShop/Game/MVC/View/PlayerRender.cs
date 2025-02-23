using System.Numerics;
using CoffeeShop.MVC.Model;
using Raylib_cs;

namespace CoffeeShop.MVC.View;

public class PlayerRender
{
    private PlayerModel _playerModel;

    public PlayerRender(ref PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }
    
    public void Render()
    {
        ref Vector2 position = ref _playerModel.GetPosition();
        Raylib.DrawRectangle((int)position.X, (int)position.Y, 10, 10, Color.Red);
    }
}