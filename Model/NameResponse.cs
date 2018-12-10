using Prism.Mvvm;

namespace Model
{
    /// <summary>
    /// Ответ сервера с именем игрока
    /// </summary>
    public sealed class NameResponse:BindableBase
    {
        #region Private fields

        private string _name;

        #endregion
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}
