using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MessageSender.Api.Filters;

public class SwaggerSchemeFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= new List<OpenApiParameter>();
        
        var clientIdHeader = operation.Parameters.FirstOrDefault(p => p.Name == "x-client-id");
        if (clientIdHeader is not null)
        {
            clientIdHeader.Required = true;
            return;
        }

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "x-client-id",
            In = ParameterLocation.Header,
            Required = true,
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
    }
}