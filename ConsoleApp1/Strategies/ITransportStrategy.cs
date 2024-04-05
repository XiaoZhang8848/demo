using ConsoleApp1.Enums;

namespace ConsoleApp1.Strategies;

public interface ITransportStrategy
{
    void Transport();
}

public class LangTransportStrategy: ITransportStrategy
{
    public void Transport()
    {
        Console.WriteLine("陆运...");
    }
}

public class ShippingTransportStrategy: ITransportStrategy
{
    public void Transport()
    {
        Console.WriteLine("海运...");
    }
}

public class AirTransportStrategy : ITransportStrategy
{
    public void Transport()
    {
        Console.WriteLine("空运...");
    }
}

public class TransportStrategyContext
{
    private readonly ITransportStrategy _transportStrategy;

    public TransportStrategyContext(ITransportStrategy transportStrategy)
    {
        _transportStrategy = transportStrategy;
    }

    public void Transport()
    {
        Console.WriteLine("执行一些逻辑...");
        _transportStrategy.Transport();
    }
}