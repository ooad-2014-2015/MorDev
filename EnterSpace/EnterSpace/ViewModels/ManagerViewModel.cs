using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSpace.Models
{
    public class ManagerViewModel
    {
        public MainWindowViewModel Parent { get; set; }
        public ManagerViewModel(MainWindowViewModel P)
        {
            Parent = P;
        }
    }
}
