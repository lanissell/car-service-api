using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class RemoveUnwantedSchemasDocumentFilter : IDocumentFilter
{
    private const string NameOfDTO = "DTO";
    private const string NameOfBase = "Base";

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var schemasToRemove = swaggerDoc.Components.Schemas
            .Where(s => !s.Key.Contains(NameOfDTO) || s.Key.Contains(NameOfBase))
            .Select(s => s.Key)
            .ToList();

        foreach (var schema in schemasToRemove)
        {
            swaggerDoc.Components.Schemas.Remove(schema);
        }

        var schemas = swaggerDoc.Components.Schemas;

        foreach (var key in schemas.Keys)
        {
            schemas[key].Title = key.Replace(NameOfDTO, String.Empty);
        }
    }
}