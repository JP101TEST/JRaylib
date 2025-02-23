using System;
using CoffeeShop;
using Raylib_cs;

public class ScreenTransfer
{
    private float _frameCurrent = 0;
    private float _frameMax = 0;
    private bool _tranferEnd = false;
    private Color _color;

    public ScreenTransfer(float timeForTransitionSeconds)
    {
        // ตรวจสอบค่าที่รับเข้ามา
        if (timeForTransitionSeconds > 59 || timeForTransitionSeconds < 0.01)
        {
            throw new ArgumentException("Time for transition must be less than 60 and greater than 0.01");
        }

        _frameMax = 60f * timeForTransitionSeconds;
        _color = new Color(0, 0, 0, 0); // กำหนดค่าเริ่มต้น
    }

    public void Update()
    {
        if (_frameCurrent < _frameMax)
        {
            _frameCurrent++;
            _color.A = (byte)(_frameCurrent / _frameMax * 255);
            
        }
        else
        {
            _tranferEnd = true;
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), _color);
    }

    public bool IsTranferEnd() => _tranferEnd;
}