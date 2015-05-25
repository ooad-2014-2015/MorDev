using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSpace.Models
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
