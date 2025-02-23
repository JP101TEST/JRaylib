using CoffeeShop.MVC.Model.Interface;

namespace CoffeeShop.MVC.Controller;

public static class ScreenController
{
    private static ScreenInterface _screen;
    private static bool _isTranferIn = false;
    
    public static void SetScreen(ScreenInterface screen)
    {
        _screen = screen;
    }
    
    public static void Run()
    {
        _screen.Run();
    }
    
    public static void ChangeScreen(ScreenInterface screen)
    {
        _screen?.Dispose(); // เรียก Dispose หน้าจอเก่าก่อนเปลี่ยน
        _screen = screen;
    }
    
    public static void Dispose()
    {
        _screen.Dispose();
    }
}