using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWPF.Command
{
    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _getCommand = new CompositeCommand();
        public CompositeCommand CompositeCommand
        {
            get { return _getCommand; }
        }
        private CompositeCommand _saveCommand = new CompositeCommand();
        public CompositeCommand SaveCommand
        {
            get { return _saveCommand; }
        }
        private CompositeCommand _deleteCommand = new CompositeCommand();
        public CompositeCommand DeleteCommand
        {
            get { return _deleteCommand; }
        }
    }
}
