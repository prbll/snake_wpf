using Prism.Mvvm;

namespace Model
{
    /// <summary>
    /// Точка в двумерном пространстве
    /// </summary>
    public class BasePoint:BindableBase
    {
        #region Private fields

        private int _x;
        private int _y;

        #endregion

        /// <summary>
        /// Координата X
        /// </summary>
        public int X
        {
            get => _x;
            set => SetProperty(ref _x,value);
        }

        /// <summary>
        /// Координата Y
        /// </summary>
        public int Y
        {
            get => _y;
            set => SetProperty(ref _y, value);
        }
    }
}
