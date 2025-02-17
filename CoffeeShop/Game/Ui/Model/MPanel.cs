using System.Numerics;
using Raylib_cs;

namespace CoffeeShop.Ui.Model;

public class MPanel 
{
    private Vector2 _position = Vector2.Zero;
    private Vector2 _size = Vector2.Zero;
    private Color _color = Color.White;
    
    private bool _enabled = false;
    private bool _visible = true;

    public MPanel()
    {

    }

    public MPanel(Vector2 position, Vector2 size, Color color)
    {
       _position = position;
        _size = size;
        _color = color;
    }
    
    // Setters
    public void SetPosition(Vector2 position)
    {
        _position = position;
    }
    
    public void SetSize(Vector2 size)
    {
        _size = size;
    }
   
    public void SetColor(Color color)
    {
        _color = color;
    }
    
    public void Enable()
    {
        _enabled = true;
    }
    
    public void Disable()
    {
        _enabled = false;
    }
    
    public void Show()
    {
        _visible = true;
    }
    
    public void Hide()
    {
        _visible = false;
    }
    
    // Getters
    public ref Vector2 GetPosition()
    {
        return ref _position;
    }
    
    public ref Vector2 GetSize()
    {
        return ref _size;
    }
    
    public ref Color GetColor()
    {
        return ref _color;
    }
    
    public bool IsEnabled()
    {
        return _enabled;
    }
    
    public bool IsVisible()
    {
        return _visible;
    }
}