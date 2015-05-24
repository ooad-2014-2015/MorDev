using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplic.ViewModels
{
    class DirektorViewModel
    {
        public MainWindowViewModel parent { get; set; }
        public DirektorViewModel(MainWindowViewModel P)
                {
                    parent = P;
                }
    }
}
