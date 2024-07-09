using UnityEngine;
using UnityEngine.Events;

namespace TicTacToe.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public BoardManager boardManager;

        // Interface cannot be exposed to inspector. So assigned it through gameobject.
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

        public void PlaceMark()
        {
            _currentPlayer.MakeMove(boardManager);
            
            if (boardManager.IsWinner(_currentPlayer.GetSymbol()))
            {
                onSomeoneWin.Invoke(_currentPlayer.GetSymbol().ToString());
                return;
            }
            
            if (boardManager.IsStale())
            {
                onNoWinner.Invoke();
                return;
            }

            
            
        }
        
        
        public void SwitchPlayer()
        {
            _currentPlayer = (_currentPlayer == _player1) ? _player2 : _player1;
        }
    }
}
