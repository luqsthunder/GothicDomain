using ImGuiNET;

namespace Editor.ImGuiController;

public class MetalController : IDisposable
{
   public MetalController(int width, int height)
   {
      ImGui.NewFrame();
   }

   public void Dispose()
   {
      throw new NotImplementedException();
   }
}