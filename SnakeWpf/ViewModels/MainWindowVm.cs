using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Threading;
using Model;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace SnakeWpf.ViewModels
{
    public class MainWindowVm:BindableBase
    {
        #region Private fields

        private readonly Service _remoteService;

        private int _turnTimeMilliseconds;
        private BoardInfoResponse _myGameBoard;
        private int _timeUntilNextTurnMilliseconds;
        private List<string> _cells;
        private TurnData _turnData;

        #endregion

        public DelegateCommand<KeyEventArgs> KeyUpEventCommand { get; set; }
        public DelegateCommand<KeyEventArgs> KeyRightEventCommand { get; set; }
        public DelegateCommand<KeyEventArgs> KeyLeftEventCommand { get; set; }
        public DelegateCommand<KeyEventArgs> KeyDownEventCommand { get; set; }

        public MainWindowVm(Service remoteService,IEventAggregator aggregator)
        {
            KeyUpEventCommand=new DelegateCommand<KeyEventArgs>(KeyUpEventHandler);
            KeyRightEventCommand = new DelegateCommand<KeyEventArgs>(KeyRightEventHandler);
            KeyLeftEventCommand = new DelegateCommand<KeyEventArgs>(KeyLeftEventHandler);
            KeyDownEventCommand = new DelegateCommand<KeyEventArgs>(KeyDownEventHandler);
            _remoteService = remoteService;
            LoadData();
            var dispatcherTimer=new DispatcherTimer
            {Interval = new TimeSpan(0,0,0,0,TurnTimeMilliseconds/5)};
            dispatcherTimer.Tick += Load;
            dispatcherTimer.Start();
        }

        public async void LoadDataAsync()
        {
            MyGameBoard = await _remoteService.GetGameBoardAsync();
            Cells = _remoteService.BuildListData(MyGameBoard);
            TimeUntilNextTurnMilliseconds = MyGameBoard.TimeUntilNextTurnMilliseconds;
            TurnTimeMilliseconds = MyGameBoard.TurnTimeMilliseconds;
        }

        public void LoadData()
        {
            MyGameBoard = _remoteService.GetGameBoard();
            Cells = _remoteService.BuildListData(MyGameBoard);
            TimeUntilNextTurnMilliseconds = MyGameBoard.TimeUntilNextTurnMilliseconds;
            TurnTimeMilliseconds = MyGameBoard.TurnTimeMilliseconds;
        }

        public void SendDataAsync()
        {
            _remoteService.SendDataAsync(MyTurnData);
        }

        public void SendData()
        {
            _remoteService.SendData(MyTurnData);
        }

        public TurnData MyTurnData
        {
            get => _turnData;
            set => SetProperty(ref _turnData, value);
        }

        public List<string> Cells
        {
            get => _cells;
            set => SetProperty(ref _cells, value);
        }

        public BoardInfoResponse MyGameBoard
        {
            get => _myGameBoard;
            set => SetProperty(ref _myGameBoard, value);
        }

        public int TimeUntilNextTurnMilliseconds
        {
            get => _timeUntilNextTurnMilliseconds;
            set => SetProperty(ref _timeUntilNextTurnMilliseconds, value);
        }

        public int TurnTimeMilliseconds
        {
            get => _turnTimeMilliseconds;
            set => SetProperty(ref _turnTimeMilliseconds, value);
        }

        public void KeyUpEventHandler(KeyEventArgs args)
        {
            MyTurnData=new TurnData(){Direction="Top"};
            SendData();
        }

        public void KeyRightEventHandler(KeyEventArgs args)
        {
            MyTurnData = new TurnData() { Direction = "Right" };
            SendData();
        }

        public void KeyLeftEventHandler(KeyEventArgs args)
        {
            MyTurnData = new TurnData() { Direction = "Left" };
            SendData();
        }

        public void KeyDownEventHandler(KeyEventArgs args)
        {
            MyTurnData = new TurnData() { Direction = "Bottom" };
            SendData();
        }

        private void Load(object sender, EventArgs e)
        {
            LoadDataAsync();
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
