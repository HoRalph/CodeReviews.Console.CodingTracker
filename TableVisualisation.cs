using Spectre.Console;
using Spectre.Console.Cli;

public class Visualisation
{
    public static void DrawTable(List<string[]> rows)
    {
        var table = new Table();
        table.AddColumn(new TableColumn(new Markup("[yellow]Session ID[/]")));
        table.AddColumn(new TableColumn("[blue]Start Date Time[/]"));
        table.AddColumn(new TableColumn("[blue]End Date Time[/]"));
        table.AddColumn(new TableColumn("[Green]Duration[/]"));
        table.Centered();
        table.LeftAligned();
        foreach (string[] row in  rows)
        {
            table.AddRow(row);
        }
        AnsiConsole.Write(table);
    }
}