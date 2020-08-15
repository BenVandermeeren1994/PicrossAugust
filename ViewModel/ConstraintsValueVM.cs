using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ConstraintsValueVM
    {
        private readonly IPlayablePuzzleConstraintsValue iPlayablePuzzleConstraintsValuewrapped;
        private readonly int vmValue;
        private readonly Cell<bool> vmIsSatisfied;

        public ConstraintsValueVM(IPlayablePuzzleConstraintsValue iPlayablePuzzleConstraintsValuewrapped)
        {
            this.iPlayablePuzzleConstraintsValuewrapped = iPlayablePuzzleConstraintsValuewrapped;
            vmValue = iPlayablePuzzleConstraintsValuewrapped.Value;
            vmIsSatisfied = iPlayablePuzzleConstraintsValuewrapped.IsSatisfied;
        }

        public int Value
        {
            get
            {
                return vmValue;
            }
        }

        public Cell<bool> IsSatisfied
        {
            get
            {
                return vmIsSatisfied;
            }
        }
    }
}
