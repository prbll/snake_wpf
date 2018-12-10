using Prism.Mvvm;

namespace Model
{
    /// <summary>
    /// Стена на игровом поле
    /// </summary>
    public sealed class Wall:BindableBase
    {
        #region Private fields

        private int _x;
        private int _y;
        private int _width;
        private int _height;

        #endregion
        /// <summary>
        /// Координата X
        /// </summary>
        public int X
        {
            get => _x;
            set => SetProperty(ref _x, value);
        }

        /// <summary>
        /// Координата X
        /// </summary>
        public int Y
        {
            get => _y;
            set => SetProperty(ref _y, value);
        }

        /// <summary>
        /// Ширина
        /// </summary>
        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        /// <summary>
        /// Высота
        /// </summary>
        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }
    }
}
