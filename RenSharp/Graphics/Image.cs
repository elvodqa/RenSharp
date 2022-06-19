using RenSharp.Math;
using SDL2;

namespace RenSharp.Graphics;

public class Image : IDisposable
{
    public IntPtr Handle { get; set; }
    public Vector2i Size { get; set; } = new Vector2i(100, 100);
    public Vector2i Position { get; set; } = new Vector2i(0, 0);
    private SDL.SDL_Rect Rect;
   
    
    /// <summary>
    /// Loads an image from "Reources/Images" directory.
    /// If file is in Resources file there is no need to
    /// write it as "Resources/Images/myImage.png"
    /// </summary>
    /// <param name="ImageName"></param>
    public Image(string ImageName)
    {
        Handle = SDL_image.IMG_LoadTexture(Core.Renderer, "Resources/Images/" + ImageName);
        Rect.x = Position.X;
        Rect.y = Position.Y;
        Rect.w = Size.X;
        Rect.h = Size.Y;
    }

    public void Render()
    {
        SDL.SDL_RenderCopy(Core.Renderer, Handle, IntPtr.Zero, ref Rect);
    }
    
    public void Dispose()
    {
    }
}