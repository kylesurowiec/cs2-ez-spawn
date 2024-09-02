namespace CS2EZSpawn.Test;

public abstract class BaseTestWithLogger
{
    protected readonly ITestOutputHelper Output;

    protected BaseTestWithLogger(ITestOutputHelper output)
    {
        Output = output;
    }
}

