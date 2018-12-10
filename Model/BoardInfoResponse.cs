using System.Collections.Generic;
using Prism.Mvvm;

namespace Model
{
    /// <summary>
    /// Ответ сервера с информацией об игровом поле
    /// </summary>
    public sealed class BoardInfoResponse:BindableBase
    {
        #region Private fields

        private bool _isStarted;
        private bool _isPaused;
        private int _roundNumber;
        private int _turnNumber;
        private int _turnTimeMilliseconds;
        private int _timeUntilNextTurnMilliseconds;
        private int _maxFood;
        private GameBoard _gameBoardSize;
        private IEnumerable<Player> _players;
        private IEnumerable<FoodPoint> _food;
        private IEnumerable<Wall> _walls;

        #endregion

        /// <summary>
        /// Начата ли игра
        /// </summary>
        public bool IsStarted
        {
            get => _isStarted;
            set => SetProperty(ref _isStarted, value);
        }

        /// <summary>
        /// Приостановлена ли игра
        /// </summary>
        public bool IsPaused
        {
            get => _isPaused;
            set => SetProperty(ref _isPaused, value);
        }

        /// <summary>
        /// Номер раунда
        /// </summary>
        public int RoundNumber
        {
            get => _roundNumber;
            set => SetProperty(ref _roundNumber, value);
        }

        /// <summary>
        /// Номер хода в раунде
        /// </summary>
        public int TurnNumber
        {
            get => _turnNumber;
            set => SetProperty(ref _turnNumber, value);
        }

        /// <summary>
        /// Время на ход
        /// </summary>
        public int TurnTimeMilliseconds
        {
            get => _turnTimeMilliseconds;
            set => SetProperty(ref _turnTimeMilliseconds, value);
        }

        /// <summary>
        /// Время до следующего хода
        /// </summary>
        public int TimeUntilNextTurnMilliseconds
        {
            get => _timeUntilNextTurnMilliseconds;
            set => SetProperty(ref _timeUntilNextTurnMilliseconds, value);
        }

        /// <summary>
        /// Максимальное количество еды на поле
        /// </summary>
        public int MaxFood
        {
            get => _maxFood;
            set => SetProperty(ref _maxFood, value);
        }

        /// <summary>
        /// Игровое поле
        /// </summary>
        public GameBoard GameBoardSize
        {
            get => _gameBoardSize;
            set => SetProperty(ref _gameBoardSize, value);
        }

        /// <summary>
        /// Игроки
        /// </summary>
        public IEnumerable<Player> Players
        {
            get => _players;
            set => SetProperty(ref _players, value);
        }

        /// <summary>
        /// Еда на поле
        /// </summary>
        public IEnumerable<FoodPoint> Food
        {
            get => _food;
            set => SetProperty(ref _food, value);
        }

        /// <summary>
        /// Стены на поле
        /// </summary>
        public IEnumerable<Wall> Walls
        {
            get => _walls;
            set => SetProperty(ref _walls, value);
        }

    }
}
