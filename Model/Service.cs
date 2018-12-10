using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;


namespace Model
{
    public class Service
    {
        #region Private fields

        private readonly IRestClient _restClient;
        private readonly IRestRequest _restRequest;
        private const string Token = "C%};NA|N:ZUxSH/vSxZ4";
        private const string Uri = "http://safeboard.northeurope.cloudapp.azure.com";
        private const string MyNickName = "prbll";

        #endregion

        #region Constructors

        public Service(IRestClient restClient, IRestRequest restRequest)
        {
            _restClient = restClient;
            _restRequest = restRequest;
        }

        #endregion

        /// <summary>
        /// Асинхронное получение имени игрока по токену
        /// </summary>
        /// <param name="token">Токен игрока</param>
        /// <returns></returns>
        public async Task<string> GetNameAsync(string token = null)
        {
            _restClient.BaseUrl = new System.Uri(Uri);
            _restRequest.Parameters.Clear();
            _restRequest.Resource = $"api/Player/name";
            _restRequest.AddQueryParameter("token", Token);
            var response = await _restClient.ExecuteGetTaskAsync<NameResponse>(_restRequest);
            return response.Data.Name;
        }

        /// <summary>
        /// Получение имени игрока по токену
        /// </summary>
        /// <param name="token">Токен игрока</param>
        /// <returns></returns>
        public string GetName(string token = null)
        {
            _restClient.BaseUrl = new System.Uri(Uri);
            _restRequest.Parameters.Clear();
            _restRequest.Resource = $"api/Player/name";
            _restRequest.Method = Method.GET;
            _restRequest.AddQueryParameter("token", Token);
            var response = _restClient.Execute<NameResponse>(_restRequest);
            return response.Data.Name;
        }

        /// <summary>
        /// Асинхронное получение состояния игрового поля
        /// </summary>
        /// <param name="token">Токен игрока</param>
        /// <returns></returns>
        public async Task<BoardInfoResponse> GetGameBoardAsync(string token = null)
        {
            
            _restClient.BaseUrl = new System.Uri(Uri);
            _restRequest.Parameters.Clear();
            _restRequest.Resource = $"api/Player/gameboard";
            _restRequest.Method = Method.GET;
            _restRequest.AddQueryParameter("token", Token);
            var response = await _restClient.ExecuteGetTaskAsync<BoardInfoResponse>(_restRequest);
            return response.Data;
        }

        /// <summary>
        /// Получение состояния игрового поля
        /// </summary>
        /// <param name="token">Токен игрока</param>
        /// <returns></returns>
        public BoardInfoResponse GetGameBoard(string token = null)
        {
            _restClient.BaseUrl = new System.Uri(Uri);
            _restRequest.Parameters.Clear();
            _restRequest.Resource = $"api/Player/gameboard";
            _restRequest.Method = Method.GET;
            _restRequest.AddQueryParameter("token", Token);
            var response = _restClient.Execute<BoardInfoResponse>(_restRequest);
            return response.Data;
        }

        /// <summary>
        /// Асинхронная отправка данных о ходе
        /// </summary>
        /// <param name="turnData">Данные</param>
        /// <returns></returns>
        public bool SendDataAsync(TurnData turnData)
        {
            var result = false;
            _restClient.BaseUrl = new System.Uri(Uri);
            turnData.Token = Token;
            _restRequest.Parameters.Clear();
            _restRequest.Resource = $"api/Player/direction";
            _restRequest.Method = Method.POST;
            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddBody(turnData);
            var response=_restClient.ExecuteAsync(_restRequest, r =>
            {
                if (r.ResponseStatus == ResponseStatus.Completed)
                {
                    result = true;
                }
            });
            return result;
        }

        /// <summary>
        /// Отправка данных о ходе
        /// </summary>
        /// <param name="turnData">Данные</param>
        /// <returns></returns>
        public bool SendData(TurnData turnData)
        {
            _restClient.BaseUrl = new System.Uri(Uri);
            turnData.Token = Token;
            _restRequest.Parameters.Clear();
            _restRequest.Resource = $"api/Player/direction";
            _restRequest.Method = Method.POST;
            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddBody(turnData);
            return _restClient.Execute(_restRequest).IsSuccessful;
        }

        /// <summary>
        /// Построение данных для отрисовки игрового поля
        /// </summary>
        /// <param name="gameBoard">Поле</param>
        /// <returns></returns>
        public List<string> BuildListData(BoardInfoResponse gameBoard)
        {
            var gameBoardSize = gameBoard.GameBoardSize;
            var cells = new List<string>();
            var players = gameBoard.Players;
            for (var i = 0; i < gameBoardSize.Height; i++)
            {
                for (var j = 0; j < gameBoardSize.Width; j++)
                {
                    if (gameBoard.Food.Where(width => width.X == j).FirstOrDefault(height => height.Y == i) != null)
                    {
                        cells.Add("Food");
                    }
                    else if (players.Where(player => player.Snake != null)
                        .Any(player => player.Snake.Where(width => width.X == j)
                                           .FirstOrDefault(height => height.Y == i) != null))
                    {
                        var query = players.Where(player => player.Snake != null).Where(nick => nick.Name == MyNickName)
                            .Any(player => player.Snake.Any(snake => snake.X == j && snake.Y == i));
                        cells.Add(query ? "MySnake" : "Snakes");
                    }
                    else if (gameBoard.Walls.Where(width => (width.X <= j && width.X + width.Width > j))
                                 .FirstOrDefault(height => (height.Y <= i && height.Y + height.Height > i)) != null)
                    {
                        cells.Add("Walls");
                    }
                    else
                    {
                        cells.Add("Board");
                    }
                }
            }
            return cells;
        }
    }
}
