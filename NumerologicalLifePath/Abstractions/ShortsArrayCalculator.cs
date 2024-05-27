namespace NumerologicalLifePath.Sdk.Abstractions;

public class ShortsArrayCalculator(ICommand<short[]> command) : ICalculator
{
    private bool run = false;

    public void SetClient(Client client)
    {
        command.SetClient(client);
    }

    public short[] Results
    {
        get
        {
            if (!run)
                Execute().Wait();
            return command.Result;
        }
    }

    public async Task Execute()
    {
        await Task.Run(() => command.Execute());
        run = true;
    }
}