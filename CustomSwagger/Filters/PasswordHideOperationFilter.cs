using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;



// Not working....
public class PasswordHideOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null) return;

        foreach (var parameter in operation.Parameters)
        {
            if (parameter.Description?.ToLower() == "password")
            {
                parameter.Description = "******";
                parameter.Example = new OpenApiString("Passw0rd!");
            }
        }
    }

    
}
