using Prism.Mvvm;

namespace Model
{
    /// <summary>
    /// Игровое поле
    /// </summary>
    public sealed class GameBoard:BindableBase
    {
        #region Private fields

        private int _width;
        private int _height;

        #endregion
        /// <summary>
        /// Ширина поля
        /// </summary>
        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        /// <summary>
        /// Высота поля
        /// </summary>
        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }
    }
}
