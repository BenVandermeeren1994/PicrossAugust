using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PiCross;

namespace ViewModel
{
    public class HelpCommmand : ICommand
    {
        private MainWindowVM mainWindowVM;
        private GameWindowVM gameWindowVM;
        private List<SquareVM> playingGrid;
        private List<bool> puzzleGrid;

        public HelpCommmand(MainWindowVM mainWindowVM, GameWindowVM gameWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
            this.gameWindowVM = gameWindowVM;
            playingGrid = gameWindowVM.Grid.Items.ToList();
            puzzleGrid = gameWindowVM.Puzzle.Grid.Items.ToList();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            for (int i = playingGrid.Count - 1; i >= 0; i--)
            {
                if (!(playingGrid[i].Contents.Value.ToString() == "x" && puzzleGrid[i] == true || playingGrid[i].Contents.Value.ToString() == "." && puzzleGrid[i] == false))
                {
                    gameWindowVM.Grid.Items.ElementAt(i).Contents.Value = Square.UNKNOWN;
                }
            }

            mainWindowVM.ActiveWindow = gameWindowVM;
        }
    }
}
