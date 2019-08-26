using Prism.Mvvm;
using PrismWPF.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModule.ViewModels
{
    public class ToolbarViewModel : BindableBase
    {
        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }

        public ToolbarViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;
        }
    }
}
