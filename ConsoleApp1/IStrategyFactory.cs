using ConsoleApp1.Enums;
using ConsoleApp1.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1;

public interface IStrategyFactory
{
    IPayStrategy CreatePayStrategy(EnumPay payType);
    
    ITransportStrategy CreateTransportStrategy(EnumTransport transport);
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
    
    public ITransportStrategy CreateTransportStrategy(EnumTransport transport)
    {
        var dictionary = new Dictionary<EnumTransport, Type>
        {
            { EnumTransport.LAND, typeof(LangTransportStrategy) },
            { EnumTransport.SHIPPING, typeof(ShippingTransportStrategy) },
            { EnumTransport.AIR, typeof(AirTransportStrategy) }
        };

        var services = _serviceProvider.GetServices(typeof(ITransportStrategy));
        var service = services.Single(x => x!.GetType() == dictionary[transport]);
        return (ITransportStrategy)service!;
    }
}