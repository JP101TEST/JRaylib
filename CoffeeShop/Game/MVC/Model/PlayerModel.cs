using System.Numerics;
using Raylib_cs;

namespace CoffeeShop.MVC.Model;

public class PlayerModel
{
    private string _name;
    private float _speed = 3.0f; 
        
    private Texture2D _hire;
    private Texture2D _cloth;
    private Color _skinColor;
    private Vector2 _size;
    private Vector2 _position;
    
    
    private bool _hitBox = false;
    
    // Constructor
    public PlayerModel()
    {
        
    }
    
    public PlayerModel(string name,ref Texture2D hire,ref Texture2D cloth, Color skinColor, Vector2 size, Vector2 position)
    {
        _name = name;
        _hire = hire;
        _cloth = cloth;
        _skinColor = skinColor;
        _size = size;
        _position = position;
    }
    // Getters
    public string GetName() => _name;
    public float GetSpeed() => _speed;
    public bool GetHitBox() => _hitBox;
    
    public ref readonly Texture2D GetHire() => ref _hire;
    public ref readonly Texture2D GetCloth() => ref _cloth;
    public ref readonly Color GetSkinColor() => ref _skinColor;
    public ref Vector2 GetSize() => ref _size;
    public ref Vector2 GetPosition() => ref _position;
    
    // Setters
    public void SetName(string name) => _name = name;
    public void SetSpeed(int speed) => _speed = speed;
    public void SetHitBox(bool hitBox) => _hitBox = hitBox;
    
    public void SetHire(in Texture2D hire) => _hire = hire;
    public void SetCloth(in Texture2D cloth) => _cloth = cloth;
    public void SetSkinColor(Color skinColor) => _skinColor = skinColor;
    public void SetSize(Vector2 size) => _size = size;
    public void SetPosition(Vector2 position) => _position = position;
    
    
}