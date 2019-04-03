using System.Collections.Generic;

namespace VSP.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel(List<string> tags)
        {
            Tags = tags;
        }

        public List<string> Tags { get; set; }
    }
}
