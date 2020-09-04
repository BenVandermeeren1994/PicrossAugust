using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiCross;
using System.ComponentModel;

namespace ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public MainWindowVM()
        {
            this.ActiveWindow = new StartWindowVM(this);
            this.PiCrossFacade = new PiCrossFacade();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private object activeWindow;

        public PiCrossFacade PiCrossFacade { get; }

        public Action ClosingAction { get; set; }

        public object ActiveWindow
        {
            get
            {
                return activeWindow;
            }
            set
            {
                activeWindow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveWindow)));
            }
        }

        public void StartGame()
        {
            this.ActiveWindow = new GameWindowVM(this);
        }

        public void StartGame(Puzzle puzzle)
        {
            this.ActiveWindow = new GameWindowVM(this, puzzle);
        }

        public void ChooseGame()
        {
            this.ActiveWindow = new ChooseWindowVM(this);
        }

        public void StartView()
        {
            this.ActiveWindow = new StartWindowVM(this);
        }

        public void CloseWindow()
        {
            this.ClosingAction?.Invoke();
        }

    }
}
