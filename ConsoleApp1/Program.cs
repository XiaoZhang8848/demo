using ConsoleApp1;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddTransient<IStrategyFactory, StrategyFactory>();
services.AddTransient<IPayStrategy, AliyunPayStrategy>();
services.AddTransient<IPayStrategy, WxPayStrategy>();
services.AddTransient<PayStrategyContext>();

using var serviceProvider = services.BuildServiceProvider();
var factory = serviceProvider.GetRequiredService<IStrategyFactory>();

var payStrategy = factory.CreatePayStrategy(EnumPay.ALIYUN);
var payStrategy1 = factory.CreatePayStrategy(EnumPay.WX);
var payStrategyContext = new PayStrategyContext(payStrategy);
var payStrategyContext1 = new PayStrategyContext(payStrategy1);
payStrategyContext.Pay();
payStrategyContext1.Pay();