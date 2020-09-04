using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ConstraintsVM
    {
        private readonly IPlayablePuzzleConstraints iPlayablePuzzleConstraintswrapped;
        private readonly ISequence<ConstraintsValueVM> vmValues;
        private readonly Cell<bool> vmIsSatisfied;

        public ConstraintsVM(IPlayablePuzzleConstraints iPlayablePuzzleConstraintswrapped)
        {
            this.iPlayablePuzzleConstraintswrapped = iPlayablePuzzleConstraintswrapped;
            vmValues = iPlayablePuzzleConstraintswrapped.Values.Map(constraints => new ConstraintsValueVM(constraints)).Copy();
            vmIsSatisfied = iPlayablePuzzleConstraintswrapped.IsSatisfied;
        }

        public ISequence<ConstraintsValueVM> Values
        {
            get
            {
                return vmValues;
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
