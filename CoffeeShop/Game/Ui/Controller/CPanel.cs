using System.Numerics;
using CoffeeShop.Ui.Controller.Interface;
using CoffeeShop.Ui.Model;
using CoffeeShop.Utile;
using Raylib_cs;

namespace CoffeeShop.Ui.Controller;

public class CPanel : IPanel
{
    private MPanel _panel;
    private bool _isStickDownAndMove = false;
    private Vector2 _mousePositionAfterClick;
    private Vector2 _panelPositionBeforeClick;

    public CPanel(MPanel panel)
    {
        _panel = panel;
    }
    
    public void Input()
    {
        Vector2 mousePos = Raylib.GetMousePosition();
        
        if (!_panel.IsEnabled() && UtileMouse.CheckMouseInRectangle(ref mousePos, ref _panel.GetPosition(),
                                    ref _panel.GetSize())
                                && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            _panel.Enable();
            _isStickDownAndMove = false;
            Console.WriteLine("Enable");
        }
        
        if (_panel.IsEnabled())
        {
            if (!UtileMouse.CheckMouseInRectangle(ref mousePos, ref _panel.GetPosition(), ref _panel.GetSize())
                && Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                _panel.Disable();
                Console.WriteLine("Disable");
                return;
            }

            if (!_isStickDownAndMove && Raylib.IsMouseButtonReleased(MouseButton.Left))
            {
                Console.WriteLine("Out of panel");
                _isStickDownAndMove = false;
                
            }
            
            if (!_isStickDownAndMove && Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                _mousePositionAfterClick = Raylib.GetMousePosition();
                _panelPositionBeforeClick = _panel.GetPosition();
                _isStickDownAndMove = true;
            }
            
            if (_isStickDownAndMove&& Raylib.IsMouseButtonDown(MouseButton.Left) 
                && _mousePositionAfterClick != Raylib.GetMousePosition())
            {
                Vector2 _panelOffset = Vector2.Add(_panel.GetPosition(),Vector2.Divide(_panel.GetSize(),2.0f));
                Console.WriteLine("_panelOffset : "+_panelOffset);
                // Console.WriteLine("_mousePositionAfterClick : "+_mousePositionAfterClick);
                // Console.WriteLine("Mouse pos : " + Raylib.GetMousePosition());
                // Console.WriteLine("Panel pos : " + _panel.GetPosition());
                // Console.WriteLine("Move : " + Vector2.Subtract(_mousePositionAfterClick,Raylib.GetMousePosition()));
                // Console.WriteLine("_panel new pos : "+Vector2.Add(_panel.GetPosition(),Vector2.Subtract(_mousePositionAfterClick,Raylib.GetMousePosition())));
                Vector2 _panelNewPos = Vector2.Subtract(_panelPositionBeforeClick,Vector2.Subtract(_mousePositionAfterClick,Raylib.GetMousePosition()));
                _panel.SetPosition(_panelNewPos);
            }
            
        }
    }

    public void Update()
    {
        
    }

    public void Draw()
    {
        int x = (int)_panel.GetPosition().X;
        int y = (int)_panel.GetPosition().Y;
        int width = (int)_panel.GetSize().X;
        int height = (int)_panel.GetSize().Y;
        Vector2 _panelOffset = Vector2.Add(_panel.GetPosition(),Vector2.Divide(_panel.GetSize(),2.0f));
        Raylib.DrawRectangle(x, y, width, height, _panel.GetColor());
        Raylib.DrawRectangleLines(x, y, width, height, Color.Black);
        Raylib.DrawCircle((int)_panelOffset.X,(int)_panelOffset.Y,5,Color.Red);
    }
    
    public ref MPanel GetPanel()
    {
        return ref _panel;
    }
}