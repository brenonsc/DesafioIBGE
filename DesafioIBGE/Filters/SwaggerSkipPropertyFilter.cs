namespace DesafioIBGE.Filters;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

public class SwaggerSkipPropertyFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema?.Properties == null)
        {
            return;
        }

        var skipProperties = context.Type.GetProperties().Where(t => t.GetCustomAttribute<SwaggerIgnoreAttribute>() != null);

        foreach (var skipProperty in skipProperties)
        {
            var propertyToSkip = schema.Properties.Keys.SingleOrDefault(x => string.Equals(x, skipProperty.Name, StringComparison.OrdinalIgnoreCase));

            if (propertyToSkip != null)
            {
                schema.Properties.Remove(propertyToSkip);
            }
        }
    }
}