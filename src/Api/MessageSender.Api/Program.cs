
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using MessageSender.Application.Sms.Models;
using MessageSender.Application.Sms.Services;
using MessageSender.MagtiIntegration.Extensions;
using MessageSender.PelekaIntegration.Extensions;
using MessageSender.Persistence.Extensions;
using MessageSender.SilknetIntegration.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// builder.Services.Configure<ApiBehaviorOptions>(options =>
// {
//     options.SuppressModelStateInvalidFilter = true;
// });

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<SendSmsRequestValidator>();
builder.Services.AddHttpClient();

builder.Services.AddScoped<ISmsService, SmsService>();

builder.AddRepositoryServices();
builder.AddMagtiIntegration();
builder.AddSilknetIntegration();
builder.AddPelekaIntegration();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();