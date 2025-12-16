using Gerenciador.Credito.Messaging.KafkaMessage;
using Gerenciador.Credito.Messaging.KafkaMessage.Interfaces;
using Gerenciador.Credito.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IMessageConsumer, KafkaConsumer>();

var host = builder.Build();
host.Run();
