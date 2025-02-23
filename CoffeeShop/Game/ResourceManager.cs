using Raylib_cs;

namespace CoffeeShop;

public static class ResourceManager
{
    private static int _screenHeight = 0;
    private static int _screenWidth = 0;
    
    private static Font _font;
    private static List<Font> _fonts;
    private static int _uiSize = 1;
    
    

    private static string baseDirectory = AppContext.BaseDirectory; // ใช้ Base Directory ของไฟล์ที่รันอยู่
    public static void LoadAllFronts()
    {
        Console.WriteLine("Loading fonts...");
        string sourceDirectory = baseDirectory + "/Font/";
        string[] fileType = { ".otf", ".ttf" }; // ต้องใช้จุดนำหน้าสกุลไฟล์
        _fonts = new List<Font>();
        List<string> fontFiles = new List<string>();

        // ค้นหาไฟล์จาก directory ที่กำหนด
        foreach (var ext in fileType)
        {
            fontFiles.AddRange(Directory.EnumerateFiles(sourceDirectory, $"*{ext}", SearchOption.TopDirectoryOnly));
        }

        // แสดงไฟล์ที่พบ
        foreach (string file in fontFiles)
        {
            Console.WriteLine(file);

            if (file == "Font/NotoSansThai-VariableFont_wdth,wght.ttf")
            {
                // โหลด Codepoints
                // int[] codepoints = GenerateCodepoints();
                //
                // _fonts.Add(Raylib.LoadFontEx(file, 36, codepoints, codepoints.Length));
                continue;
            }
            else
            {
                _fonts.Add(Raylib.LoadFontEx(file, 96, null, 0));
            }

            Raylib.SetTextureFilter(_fonts.Last().Texture, TextureFilter.Trilinear);
        }
    }

    // ! ยังไม่ได้ใช้ vvv
    
    // ฟังก์ชันสร้าง Codepoints ไทย + อังกฤษ + ญี่ปุ่น
    static int[] GenerateCodepoints()
    {
        int[] thai = CreateRange(0x0E00, 0x0E7F);    // ภาษาไทย
        int[] english = CreateRange(0x0020, 0x007E); // ภาษาอังกฤษ
        int[] japanese = CreateRange(0x3040, 0x30FF);// ญี่ปุ่น (ฮิรางานะ + คาตาคานะ)
        int[] kanji = CreateRange(0x4E00, 0x9FAF);   // คันจิ

        int[] allCodepoints = new int[thai.Length + english.Length + japanese.Length + kanji.Length];
        thai.CopyTo(allCodepoints, 0);
        english.CopyTo(allCodepoints, thai.Length);
        japanese.CopyTo(allCodepoints, thai.Length + english.Length);
        kanji.CopyTo(allCodepoints, thai.Length + english.Length + japanese.Length);

        return allCodepoints;
    }
    
    // ฟังก์ชันสร้างช่วง Unicode Codepoints
    private static int[] CreateRange(int start, int end)
    {
        int[] range = new int[end - start + 1];
        for (int i = 0; i < range.Length; i++)
        {
            range[i] = start + i;
        }
        return range;
    }

    // ! ยังไม่ได้ใช้ ^^^
    
    public static void SetFont(Font font)
    {
        _font = font;
    }

    // Getter
    public static ref Font GetFont()
    {
        return ref _font;
    }

    public static Font GetFonts(int index)
    {
        return _fonts[index];
    }
    
    public static int GetScreenWidth()
    {
        return _screenWidth;
    }
    
    public static int GetScreenHeight()
    {
        return _screenHeight;
    }
    // Setter
    public static void SetUiSize(int size)
    {
        _uiSize = size;
    }

    public static void AddUiSize(int size)
    {
        _uiSize += size;
    }

    public static int GetUiSize()
    {
        return _uiSize;
    }
    
    public static void SetScreenSize(int width, int height)
    {
        _screenWidth = width;
        _screenHeight = height;
    }
}