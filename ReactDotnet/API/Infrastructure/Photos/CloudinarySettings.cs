namespace API.Infrastructure.Photos
{
    public class CloudinarySettings
    {
        public string cloudname { get; set; }
        public string  ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }
}

// start up
//   services.Configure<CloudinarySettings>(Configuration.GetSection("Cloudinary"));


//  dotnet user-secrets set "cloudinary:ApiSecret" "az4t9-5KkWcuD91Rlmknl1x2rQs"
//  dotnet user-secrets set "cloudinary:ApiKey" "838539351511577"
// dotnet user-secrets  set "cloudinary:CloudName" "djfe4cnxb"