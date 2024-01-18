using System.CommandLine;

Command projectCommand = new("project", "Create a new project");

Command createCommand = new("create");
createCommand.Add(projectCommand);

RootCommand rootCommand = new();
rootCommand.AddCommand(createCommand);

await rootCommand.InvokeAsync(args).ConfigureAwait(false);