using System.Collections.Generic;
using Prism.Mvvm;

namespace Model
{
    /// <summary>
    /// Игрок
    /// </summary>
    public sealed class Player:BindableBase
    {
        #region Private fields

        private string _name;
        private bool _isSpawnProtected;
        private IEnumerable<SnakePoint> _snake;

        #endregion
        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Защищен ли на время возрождения
        /// </summary>
        public bool IsSpawnProtected
        {
            get => _isSpawnProtected;
            set => SetProperty(ref _isSpawnProtected, value);
        }

        /// <summary>
        /// Координаты змейки игрока
        /// </summary>
        public IEnumerable<SnakePoint> Snake
        {
            get => _snake;
            set => SetProperty(ref _snake, value);
        }
    }
}
