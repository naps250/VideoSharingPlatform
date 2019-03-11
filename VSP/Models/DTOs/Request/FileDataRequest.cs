using System.Web;
using VSP.Data.Models.Enums;

namespace VSP.Models.DTOs.Request
{
    public class FileDataDto
    {
        public HeroesEnum Hero { get; set; }

        public string Tags { get; set; }
    }
}
