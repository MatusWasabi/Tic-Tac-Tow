using TicTacToe.Scripts.Core;

namespace TicTacToe.Scripts.Player
{
    public interface IPlayer 
    { 
        void MakeMove(BoardManager boardManager);
        char GetSymbol();
    }
}
