using RenSharp.Math;
using SDL2;

namespace RenSharp.Graphics;

public class Image : IDisposable
{
    public IntPtr Handle { get; set; }
    public Vector2i Size 
    {
        get { return new Vector2i(Rect.w, Rect.h); }
       
        set
        {
            Rect.w = value.X;
            Rect.h = value.Y;
        }
    }
    public Vector2i Position 
    { 
        get
        {
            return new Vector2i(Rect.x, Rect.y);
        }
        set
        {
            Rect.x = value.X;
            Rect.y = value.Y;
        }
    }
    private SDL.SDL_Rect Rect;
   
    
    /// <summary>
    /// Loads an image from "Reources/Images" directory.
    /// If file is in Resources file there is no need to
    /// write it as "Resources/Images/myImage.png"
    /// </summary>
    /// <param name="ImageName"></param>
    public Image(string ImageName)
    {
        
        //System.Drawing.Image? img = System.Drawing.Image.FromFile(@"Resources/Images/" + ImageName);
        var img = SixLabors.ImageSharp.Image.Load(@"Resources/Images/" + ImageName);
        Position = new Vector2i(0, 0);
        Size = new Vector2i(img.Width, img.Height);
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