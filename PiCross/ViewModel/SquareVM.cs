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
    public class SquareVM
    {
        private readonly IPlayablePuzzleSquare iPlayablePuzzleSquarewrapped;
        private readonly Cell<Square> vmContents;
        private readonly Vector2D vmPosition;

        public SquareVM(IPlayablePuzzleSquare iPlayablePuzzleSquarewrapped)
        {
            this.iPlayablePuzzleSquarewrapped = iPlayablePuzzleSquarewrapped;
            vmContents = iPlayablePuzzleSquarewrapped.Contents;
            vmPosition = iPlayablePuzzleSquarewrapped.Position;
            this.SwitchColor = new SwitchColorCommand(this.vmContents);
        }

        public Cell<Square> Contents
        {
            get
            {
                return vmContents;
            }
        }

        public Vector2D Position
        {
            get
            {
                return vmPosition;
            }
        }

        public ICommand SwitchColor
        {
            get;
        }

        public class SwitchColorCommand : ICommand
        {

            private readonly Cell<Square> squareContent;

            public SwitchColorCommand(Cell<Square> squareContent)
            {
                this.squareContent = squareContent;
            }

           public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                if (squareContent.Value == Square.UNKNOWN)
                {
                    squareContent.Value = Square.FILLED;
                }
                else if (squareContent.Value == Square.FILLED)
                {
                    squareContent.Value = Square.EMPTY;
                }
                else
                {
                    squareContent.Value = Square.UNKNOWN;
                }
            }
        }
    }
}
