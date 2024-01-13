using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using MessageSender.Api.Extensions;
using MessageSender.Api.Filters;
using MessageSender.Application.Sms.Models;
using MessageSender.Application.Sms.Services;
using MessageSender.MagtiIntegration.Extensions;
using MessageSender.PelekaIntegration.Extensions;
using MessageSender.Persistence.Extensions;
using MessageSender.SilknetIntegration.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options => options.Filters.Add<ApiKeyAuthFilter>())
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter()));

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<SendSmsRequestValidator>();
builder.Services.AddHttpClient();

builder.Services.AddScoped<ISmsService, SmsService>();

builder.AddRepositoryServices();
builder.AddMagtiIntegration();
builder.AddSilknetIntegration();
builder.AddPelekaIntegration();
builder.AddSwaggerWithApiKeySecurity();

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.Run();