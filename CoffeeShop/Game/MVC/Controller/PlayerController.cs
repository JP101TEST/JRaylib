using System.Numerics;
using CoffeeShop.MVC.Model;
using Raylib_cs;

namespace CoffeeShop.MVC.Controller;

public class PlayerController
{
    private PlayerModel _playerModel;

    public PlayerController(ref PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public void Input()
    {
    }

    public void Update()
    {
        // Move ment
        Movement();
    }

    private void Movement()
    {
        ref Vector2 position = ref _playerModel.GetPosition();
        Vector2 vectorMovement = Vector2.Zero;

        // Move up/down
        if (Raylib.IsKeyDown(KeyboardKey.W)) vectorMovement.Y = -1;
        if (Raylib.IsKeyDown(KeyboardKey.S)) vectorMovement.Y = 1;

        // Move left/right
        if (Raylib.IsKeyDown(KeyboardKey.A)) vectorMovement.X = -1;
        if (Raylib.IsKeyDown(KeyboardKey.D)) vectorMovement.X = 1;

        // Normalize vector เพื่อให้การเคลื่อนที่แนวเฉียงไม่เร็วขึ้น
        if (vectorMovement != Vector2.Zero)
        {
            vectorMovement = Vector2.Normalize(vectorMovement);
        }

        position += vectorMovement * _playerModel.GetSpeed();
    }
}