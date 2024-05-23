namespace NumerologicalLifePath.Sdk.Abstractions;

public class Calculator(ICommand[] commands)
{
    private readonly ICommand[] _commands = commands;
    private bool run = false;

    public void SetClient(Client client)
    {
        foreach (var command in _commands)
            command.SetClient(client);
    }

    public Dictionary<string, short> Results
    {
        get
        {
            if (!run)
                Execute().Wait();

            var result = new Dictionary<string, short>(_commands.Length);
            for (int i = 0; i < _commands.Length; i++)
            {
                var cmd = _commands[i];
                result.Add(cmd.GetType().Name.Replace("Command", "").Replace("Compound", ""), cmd.Result);
            }


            return result;
        }
    }

    public async Task Execute()
    {

        var tasks = new List<Task>();

        foreach (var command in _commands)
            tasks.Add(Task.Factory.StartNew(() => command.Execute()));

        await Task.WhenAll(tasks);
        run = true;
    }
}
