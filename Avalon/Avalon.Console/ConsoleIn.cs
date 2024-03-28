namespace Avalon.Console;

public class ConsoleIn : In
{
    internal virtual ConsoleIntern Intern { get; set; }

    public override string Read()
    {
        return this.Intern.Read();
    }
}