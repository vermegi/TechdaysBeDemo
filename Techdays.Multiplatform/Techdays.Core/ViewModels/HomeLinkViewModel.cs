using System.Windows.Input;

namespace Techdays.Core.ViewModels
{
    public class HomeLinkViewModel
    {
        public string Name { get; set; }

        public ICommand LinkCommand { get; set; }

        public string LinkPicture { get; set; }
    }
}