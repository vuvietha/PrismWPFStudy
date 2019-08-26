using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWPF.Command
{
    public interface IApplicationCommands
    {
        CompositeCommand CompositeCommand { get; }
        CompositeCommand SaveCommand { get; }
        CompositeCommand DeleteCommand { get; }

    }
}
