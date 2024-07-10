using TicTacToe.Scripts.AIs;
using TicTacToe.Scripts.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Task = System.Threading.Tasks.Task;

namespace TicTacToe.Scripts.Player
{
    public class AIPlayer : MonoBehaviour, IPlayer {
        [FormerlySerializedAs("_symbol")] [SerializeField] private char symbol;
        [FormerlySerializedAs("_strategy")] [SerializeField] private AIStrategy strategy;
        [SerializeField] private float thinkDelay;
        [SerializeField] private UnityEvent onAIStartThinking;
        [SerializeField] private UnityEvent onAIEndThinking;
        
        public async void MakeMove(BoardManager boardManager) {
            if (boardManager.IsStale())
            {
                return;
            }
            
            await AIDelayThink(thinkDelay);
            strategy.Execute(boardManager, symbol);
        }

        private async Task AIDelayThink(float seconds)
        {
            onAIStartThinking.Invoke();
            await Task.Delay((int)(seconds * 100));
            onAIEndThinking.Invoke();
        }
      

        public char GetSymbol() {
            return symbol;
        }
        
    }
}
