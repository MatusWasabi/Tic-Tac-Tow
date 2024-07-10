using TicTacToe.Scripts.Player;
using UnityEngine;
using UnityEngine.Events;

namespace TicTacToe.Scripts.Core
{
    /// <summary>
    /// Manipulate the whole game from here.
    /// This is a high-level class and must not reference to concrete if possible.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BoardManager boardManager;

        // Interface cannot be exposed to inspector. So we assigning it through game object.
        [SerializeField] private GameObject player1;
        [SerializeField] private GameObject player2;
        private IPlayer _player1;
        private IPlayer _player2;
        private IPlayer _currentPlayer;
        
        [SerializeField] private UnityEvent<string> onSomeoneWin;
        [SerializeField] private UnityEvent onNoWinner;

        private void Start()
        {
            _player1 = player1.GetComponent<IPlayer>();
            _player2 = player2.GetComponent<IPlayer>();
            _currentPlayer = _player1;
        }

        // Call this whenever you want to place mark on the board.
        public void PlaceMark()
        {
            _currentPlayer.MakeMove(boardManager);
            
            if (boardManager.IsWinner(_player1.GetSymbol()))
            {
                onSomeoneWin.Invoke(_player1.GetSymbol().ToString());
                return;
            }
            if(boardManager.IsWinner(_player2.GetSymbol()))
            {
                onSomeoneWin.Invoke(_player2.GetSymbol().ToString());
                return;
            }
            if (boardManager.IsStale())
            {
                onNoWinner.Invoke();
            }
        }

        public void ResetGame()
        {
            boardManager.ResetBoard();
            _currentPlayer = _player1;
        }
        
        // Call this whenever you want to switch player. For example, when human player click on button.
        public void SwitchPlayer()
        {
            _currentPlayer = (_currentPlayer == _player1) ? _player2 : _player1;
        }
    }
}
