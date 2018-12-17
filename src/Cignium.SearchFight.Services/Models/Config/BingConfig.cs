namespace Cignium.SearchFight.Services.Models.Config
{
    public class BingConfig : BaseConfig
    {
        public static string BaseUrl => GetFromConfiguration("Bing.BaseUrl");
        public static string ApiKey => GetFromConfiguration("Bing.ApiKey");        
    }
}