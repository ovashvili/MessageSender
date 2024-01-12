
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using MessageSender.Application.Sms.Models;
using MessageSender.Persistence.Extensions;

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

builder.AddRepositoryServices();

var app = builder.Build();

app.UseRouting();
app.UseHttpLogging();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();