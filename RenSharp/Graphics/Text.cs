using SDL2;

namespace RenSharp.Graphics;
using SDL2;

public class Text
{
    public IntPtr Handle { get; set; }
    public string Font { get; set; }
    public string TextString { get; set; }
    public uint Size { get; set; } = 24;
    public SDL.SDL_Color Color { get; set; } = new SDL.SDL_Color();

    private IntPtr MessageHandle;
    private SDL.SDL_Rect MessageRect;

    public Text(string text, uint size = 75 ,string font = "CharisSIL-Regular.ttf")
    {
        var color = Color;
        color.r = 255;
        color.g = 255;
        color.b = 255;
        Color = color;
        TextString = text;
        Font = font;
        Size = size;
        Console.WriteLine(Font);
        Console.WriteLine("Resources/Fonts/" + Font);
        if (SDL_ttf.TTF_Init() == -1)
        {
            Console.WriteLine("SDL could not initialize! SDL_Error: {0}", SDL_ttf.TTF_GetError());
            return;
        }
        Handle = SDL_ttf.TTF_OpenFont("Resources/Fonts/" + Font, (int)Size);
        //var surfaceMessage = SDL_ttf.TTF_RenderText_Solid(Handle, TextString, Color);
        var surfaceMessage = SDL_ttf.TTF_RenderText_Blended(Handle, TextString, Color);
        MessageHandle = SDL.SDL_CreateTextureFromSurface(Core.Renderer, surfaceMessage);
        
        MessageRect.x = 0;  //controls the rect's x coordinate 
        MessageRect.y = 0; // controls the rect's y coordinte
        MessageRect.w = 300; // controls the width of the rect
        MessageRect.h = 75; // controls the height of the rect
    }

    public void Draw()
    {
        SDL.SDL_RenderCopy(Core.Renderer, MessageHandle, IntPtr.Zero, ref MessageRect);
    }
}