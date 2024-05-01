namespace NumerologicalLifePath;

public class Calculator(ICommand[] commands)
{
    private readonly ICommand[] _commands = commands;
    private bool run = false;
    public Client Client
    {
        set
        {
            foreach (var command in _commands)
                (command.Client) = value;
        }
    }

    public Dictionary<string, Int16> Results
    {
        get {
            if (!run)
                Execute().Wait();

            var result = new Dictionary<string, Int16>(_commands.Length);
            for (int i = 0; i < _commands.Length; i++) { 
                var cmd = _commands[i];
                result.Add(cmd.GetType().Name.Replace("Command","").Replace("Compound",""), cmd.Result);
            }
                

            return result;
        }
    }

    public async Task Execute() {

        var tasks = new List<Task>();

        foreach (var command in _commands)
            tasks.Add(Task.Factory.StartNew(() => command.Execute()));

        await Task.WhenAll(tasks);
        run = true;
    }
}
