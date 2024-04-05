using ConsoleApp1;
using ConsoleApp1.Enums;
using ConsoleApp1.Strategies;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddTransient<IStrategyFactory, StrategyFactory>();
services.AddTransient<IPayStrategy, AliyunPayStrategy>();
services.AddTransient<IPayStrategy, WxPayStrategy>();
services.AddTransient<ITransportStrategy, LangTransportStrategy>();
services.AddTransient<ITransportStrategy, ShippingTransportStrategy>();
services.AddTransient<ITransportStrategy, AirTransportStrategy>();

using var serviceProvider = services.BuildServiceProvider();
var factory = serviceProvider.GetRequiredService<IStrategyFactory>();

var payStrategy = factory.CreatePayStrategy(EnumPay.ALIYUN);
var payStrategy1 = factory.CreatePayStrategy(EnumPay.WX);
var payStrategyContext = new PayStrategyContext(payStrategy);
var payStrategyContext1 = new PayStrategyContext(payStrategy1);
payStrategyContext.Pay();
payStrategyContext1.Pay();

var transportStrategy = factory.CreateTransportStrategy(EnumTransport.LAND);
var transportStrategy1 = factory.CreateTransportStrategy(EnumTransport.SHIPPING);
var transportStrategy2 = factory.CreateTransportStrategy(EnumTransport.AIR);
var transportStrategyContext = new TransportStrategyContext(transportStrategy);
var transportStrategyContext1 = new TransportStrategyContext(transportStrategy1);
var transportStrategyContext2 = new TransportStrategyContext(transportStrategy2);
transportStrategyContext.Transport();
transportStrategyContext1.Transport();
transportStrategyContext2.Transport();