namespace WodLufia.EntryPoint;

public static class GameEntryPoint 
{
    [STAThread]
    private static void Main(string[] args)
    {
        var game = new GameLoop();
        game.Run();
    }
}