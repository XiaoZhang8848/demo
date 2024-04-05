namespace ConsoleApp1;

public interface IPayStrategy
{
    void Pay();
}

public class AliyunPayStrategy : IPayStrategy
{
    public void Pay()
    {
        Console.WriteLine("阿里云支付...");
    }
}

public class WxPayStrategy : IPayStrategy
{
    public void Pay()
    {
        Console.WriteLine("微信支付...");
    }
}

public class PayStrategyContext
{
    private readonly IPayStrategy _payStrategy;

    public PayStrategyContext(IPayStrategy payStrategy)
    {
        _payStrategy = payStrategy;
    }

    public void Pay()
    {
        _payStrategy.Pay();
    }
}