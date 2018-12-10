using Prism.Mvvm;

namespace Model
{
    /// <summary>
    /// Информация о ходе
    /// </summary>
    public sealed class TurnData:BindableBase
    {
        #region Private fields

        private string _direction;

        #endregion
        /// <summary>
        /// Направление движения
        /// </summary>
        public string Direction
        {
            get => _direction;
            set => SetProperty(ref _direction, value);
        }

        /// <summary>
        /// Токен игрока
        /// </summary>
        public string Token { get; set; }
    }
}
