using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PiCross;
using System.Collections;

namespace ViewModel
{
    public class ChooseWindowVM
    {
        public ChooseWindowVM(MainWindowVM mainWindowVM)
        {
            this.vm = mainWindowVM;

            var data = this.vm.PiCrossFacade.CreateDummyGameData();

            var list = data.PuzzleLibrary.Entries;

            this.Puzzles = new ArrayList();

            foreach (IPuzzleLibraryEntry entry in list)
            {
                this.Puzzles.Add(entry.Puzzle);
            }

            this.ChoosePuzzleCommand = new ChoosePuzzleCommand(mainWindowVM);
            this.BackCommand = new EasyCommand(() => this.vm.StartView());
            this.QuitCommand = new EasyCommand(() => this.vm.CloseWindow());
        }

        public PiCrossFacade Facade;

        public MainWindowVM vm;

        public ArrayList Puzzles { get; }
        public ICommand ChoosePuzzleCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand QuitCommand { get; }
    }

    public class ChoosePuzzleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainWindowVM vm { get; }


        public ChoosePuzzleCommand(MainWindowVM mainWindowVM)
        {
            vm = mainWindowVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var puzzle = parameter as Puzzle;
            this.vm.StartGame(puzzle);
        }
    }
}
