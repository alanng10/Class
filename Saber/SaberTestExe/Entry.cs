namespace Saber.Test.Exe;

class Entry
{
    [STAThread]
    static int Main(string[] arg)
    {
        EntryEntry entry;
        entry = new ModuleEntry();
        entry.Init();
        entry.ArgSet(arg);
        int o;
        o = entry.Execute();
        return o;
    }
}