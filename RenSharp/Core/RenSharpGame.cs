using RenSharp.Graphics;
using SDL2;

namespace RenSharp;

public class RenSharpGame
{
    private bool running = false;
    private Image peppy;
    
    public RenSharpGame()
    {
        if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
        {
            Console.WriteLine("SDL could not initialize! SDL_Error: {0}", SDL.SDL_GetError());
            return;
        }
        
        Core.Window = SDL.SDL_CreateWindow("RenSharp Game",
        0,
        40,
        800,
        600,
        SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
        
        if (Core.Window == IntPtr.Zero)
        {
            Console.WriteLine($"There was an issue creating the window. {SDL.SDL_GetError()}");
        }

        Core.Renderer = SDL.SDL_CreateRenderer(
            Core.Window, 
            -1, 
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
        
        if (Core.Renderer == IntPtr.Zero)
        {
            Console.WriteLine($"There was an issue creating the renderer. {SDL.SDL_GetError()}");
        }

        peppy = new Image("peppy.png");
        running = true;
    }
    
    protected virtual void Instructions()
    {}

    private void Render()
    {
        SDL.SDL_SetRenderDrawColor(Core.Renderer, 38, 35, 33, 255);
        SDL.SDL_RenderClear(Core.Renderer);
        
        
        peppy.Render();
        
        
        SDL.SDL_RenderPresent(Core.Renderer);
    }

    private void Update()
    {
        SDL.SDL_Event e;
        while (SDL.SDL_PollEvent(out e) == 1)
        {
            switch (e.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    running = false;
                    break;
            }
        }
    }

    public void Run()
    {
        while (running)
        {
            Update();
            Render();
            Instructions();
        }
        
        SDL.SDL_DestroyRenderer(Core.Renderer);
        SDL.SDL_DestroyWindow(Core.Window);
        SDL.SDL_Quit();
    }
}