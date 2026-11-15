using SDL3;
using Microsoft.Extensions.Logging;


namespace Editor;

/// <summary>
/// The main class for the editor.
/// </summary>
public static class EditorEntryPoint
{
  public static void Main()
  {
    using var factory = LoggerFactory.Create(builder => builder.AddConsole());
    var logger = factory.CreateLogger("SDL3");
    if (!SDL.Init(SDL.InitFlags.Video | SDL.InitFlags.Audio | SDL.InitFlags.Gamepad))
    {
      logger.LogError("SDL failed to initialize video");
      return;
    }

    var windowFlags = SDL.WindowFlags.Metal | SDL.WindowFlags.Resizable |
                      SDL.WindowFlags.HighPixelDensity;
    if (!SDL.CreateWindowAndRenderer("Gothic Domain Editor", 1360, 720, windowFlags,
          out var window, out var renderer))
    {
      logger.LogError("SDL failed to create window and renderer");
      return;
    }

    SDL.SetRenderDrawColor(renderer, 0, 128, 128, 0);

    var isOpen = true;
    
    while (isOpen)
    {
      while (SDL.PollEvent(out var ev))
      {
        if (ev.Type == (uint)SDL.EventType.Quit)
        {
          isOpen = false;
        }
      }

      SDL.RenderClear(renderer);
      SDL.RenderPresent(renderer);
    }

    SDL.DestroyRenderer(renderer);
    SDL.DestroyWindow(window);
    
    SDL.Quit();
  }
}