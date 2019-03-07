using System.Configuration;

namespace VideoSharingPlatform.Data.ApplicationDb
{
    public class ApplicationDbOptions
    {
        public ApplicationDbOptions()
        {
            // Reading connection string from app.config file
            ConnectionString = ConfigurationManager.ConnectionStrings["HighlightsConnString"].ConnectionString;
        }

        public string ConnectionString { get; set; }
    }
}
