using Spectre.Console;
using Spectre.Console.Cli;

public class Visualisation
{
    public static void DrawTable()
    {
        var table = new Table();
        table.AddColumn(new TableColumn(new Markup("[yellow]Foo[/]")));
    table.AddColumn(new TableColumn("[blue]Bar[/]"));
    AnsiConsole.Write(table);
    }
}