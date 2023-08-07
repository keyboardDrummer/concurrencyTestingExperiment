namespace ConcurrencyTestingExperiment;

public class ConcurrentOne
{
    public static int Counter = 0;
    public static int ExpectedConcurrents = 4;
    [Fact]
    public async Task Test1()
    {
        await RunTest();
    }

    public static async Task RunTest()
    {
        int max = 0;
        Counter++;
        for (int i = 0; i < 100; i++)
        {
            max = Math.Max(Counter, max);
            await Task.Delay(10);
        }

        Counter--;
        Assert.Equal(ExpectedConcurrents, max);
    }
}

public class ConcurrentTwo
{
    [Fact]
    public async Task Test1()
    {
        await ConcurrentOne.RunTest();
    }
}

public class ConcurrentThree
{
    [Fact]
    public async Task Test1()
    {
        await ConcurrentOne.RunTest();
    }
}

public class ConcurrentFour
{
    [Fact]
    public async Task Test1()
    {
        await ConcurrentOne.RunTest();
    }
}