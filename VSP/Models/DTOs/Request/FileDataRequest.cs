using System.Web;
using VSP.Data.Models.Enums;

namespace VSP.Models.DTOs.Request
{
    public class FileDataDto
    {
        public string Author { get; set; }

        public string Tags { get; set; }

        public HeroesEnum Hero { get; set; }
    }
}
