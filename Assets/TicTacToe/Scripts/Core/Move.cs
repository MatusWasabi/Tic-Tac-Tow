namespace TicTacToe.Scripts.Core
{
    public class Move {
        public int X, Y;
        public char Player;

        public Move(int x, int y, char player) {
            X = x;
            Y = y;
            Player = player;
        }
    }
}