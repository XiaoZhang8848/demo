using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1;

public interface IStrategyFactory
{
    IPayStrategy CreatePayStrategy(EnumPay payType);
}

public class StrategyFactory: IStrategyFactory
{
    private readonly IServiceProvider _serviceProvider;

    public StrategyFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public IPayStrategy CreatePayStrategy(EnumPay payType)
    {
        var dictionary = new Dictionary<EnumPay, Type>
        {
            { EnumPay.ALIYUN, typeof(AliyunPayStrategy) },
            { EnumPay.WX, typeof(WxPayStrategy) }
        };

        var services = _serviceProvider.GetServices(typeof(IPayStrategy));
        var service = services.Single(x => x!.GetType() == dictionary[payType]);
        return (IPayStrategy)service!;
    }
}