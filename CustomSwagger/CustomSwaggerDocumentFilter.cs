using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebAPITest.CustomSwagger
{


    //Swagger UI modification test. Not working tho :(, will probably modify Swagger code directy.
    public class CustomSwaggerDocumentFilter : IDocumentFilter
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CustomSwaggerDocumentFilter(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }





        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            
            var baseUrl = _hostingEnvironment.WebRootPath;
            var imagePath = "/img/image.png";

            
            var imageUrl = new Uri(baseUrl + imagePath, UriKind.RelativeOrAbsolute);

            var externalDocs = new OpenApiExternalDocs
            {
                Description = "Logo",
                Url = imageUrl
            };

           
            swaggerDoc.ExternalDocs = externalDocs;
        }
    }


}
