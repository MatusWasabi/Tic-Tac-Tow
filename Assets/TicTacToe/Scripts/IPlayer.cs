using UnityEngine;

namespace TicTacToe.Scripts
{
    public interface IPlayer 
    { 
        void MakeMove(BoardManager boardManager);
        char GetSymbol();
        bool IsTurn();
    }
}
