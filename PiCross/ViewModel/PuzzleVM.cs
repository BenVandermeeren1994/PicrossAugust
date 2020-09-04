using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PuzzleVM
    {
        private readonly IPlayablePuzzle iPlayablePuzzlewrapped;
        private readonly IGrid<SquareVM> vmGrid;
        private readonly ISequence<ConstraintsVM> vmColumnConstraints;
        private readonly ISequence<ConstraintsVM> vmRowConstraints;
        private readonly Cell<bool> vmIsSolved;
        public PuzzleVM(IPlayablePuzzle iPlayablePuzzlewrapped)
        {
            this.iPlayablePuzzlewrapped = iPlayablePuzzlewrapped;
            //setters
             vmGrid = iPlayablePuzzlewrapped.Grid.Map(square => new SquareVM(square)).Copy();
             vmColumnConstraints = iPlayablePuzzlewrapped.ColumnConstraints.Map(constraints => new ConstraintsVM(constraints)).Copy();
             vmRowConstraints = iPlayablePuzzlewrapped.RowConstraints.Map(constraints => new ConstraintsVM(constraints)).Copy();
             vmIsSolved = iPlayablePuzzlewrapped.IsSolved;
        }

        public IGrid<SquareVM> Grid
        {
            get
            {
                return vmGrid;
            }
        }

        public ISequence<ConstraintsVM> ColumnConstraints 
        {
            get
            {
                return vmColumnConstraints;
            }
        }

        public ISequence<ConstraintsVM> RowConstraints
        {
            get
            {
                return vmRowConstraints;
            }
        }

        public Cell<bool> IsSolved 
        {
            get
            {
                return vmIsSolved;
            } 
        }
    }
}
