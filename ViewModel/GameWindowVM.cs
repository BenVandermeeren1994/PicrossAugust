using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cells;
using DataStructures;
using PiCross;
using System.ComponentModel;
using System.Windows.Input;
using Utility;
using System.Windows.Threading;

namespace ViewModel
{
    public class GameWindowVM : INotifyPropertyChanged
    {
      
        public GameWindowVM(MainWindowVM mainWindowVM)
        {
            this.Puzzle = Puzzle.FromRowStrings(
                "xxxxx",
                "x...x",
                "x...x",
                "x...x",
                "xxxxx"
            );

            this.vm = mainWindowVM;

            this.Start(mainWindowVM, Puzzle);

            this.BackCommand = new EasyCommand(() => this.vm.StartView());
            this.QuitCommand = new EasyCommand(() => this.vm.CloseWindow());

        }

        public GameWindowVM(MainWindowVM mainWindowVM, Puzzle playablePuzzle)
        {
            this.MainWindowVM = mainWindowVM;
            this.Start(mainWindowVM, playablePuzzle);
            this.BackCommand = new EasyCommand(() => this.MainWindowVM.StartView());
            this.QuitCommand = new EasyCommand(() => this.MainWindowVM.CloseWindow());

        }
        public void Start(MainWindowVM mainWindowVM, Puzzle puzzle)
        {
            this.Vm = mainWindowVM;
            this.Puzzle = puzzle;
            this.PlayablePuzzle = mainWindowVM.PiCrossFacade.CreatePlayablePuzzle(puzzle);
            this.Grid = PlayablePuzzle.Grid.Map(puzzleSquare => new SquareVM(puzzleSquare)).Copy();
            this.ColumnConstraints = PlayablePuzzle.ColumnConstraints.Map(constraints => new ConstraintsVM(constraints)).Copy();
            this.RowConstraints = PlayablePuzzle.RowConstraints.Map(constraints => new ConstraintsVM(constraints)).Copy();
            StartTimer();
            this.Help = new HelpCommmand(mainWindowVM, this);
            this.IsSolved = PlayablePuzzle.IsSolved;
        }

        public ICommand BackCommand { get; }
        public ICommand QuitCommand { get; }
        public ICommand Help { get; private set; }
        public MainWindowVM MainWindowVM { get; }
        public Puzzle Puzzle;
        public MainWindowVM vm;
        public Cell<bool> IsSolved { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public PiCrossFacade Facade { get; }
        public IPlayablePuzzle PlayablePuzzle { get; private set; }
        public MainWindowVM Vm { get; private set; }
        public IGrid<SquareVM> Grid { get; private set; }
        public ISequence<ConstraintsVM> ColumnConstraints { get; private set; }
        public ISequence<ConstraintsVM> RowConstraints { get; private set; }


        //TIMER
        public Chronometer Chronometer { get; private set; }

        public DispatcherTimer timer;
        
        public void StartTimer()
        {
            this.timer = new DispatcherTimer();
            this.timer.Tick += new EventHandler(TimerTick);
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            this.timer.Start();
            this.Chronometer = new Chronometer();
            Chronometer.Start();
        }
        public void TimerTick(object sender,EventArgs e)
        {
            Chronometer.Tick();
            
            if((this.PlayablePuzzle.IsSolved.Value) == true)
            {
                this.PlayablePuzzle = null;
                this.Chronometer.Pause();              
                this.timer.Stop();
            }
        }

        



    }
}
