
using Microsoft.JSInterop;


namespace Games.Pages
{
    public partial class TicTacToeGame
    {
        string[] board = { "", "", "", "", "", "", "", "", "" };
        string player = "X";
        int[][] winningCombos =
        {
            new int[3] {0,1,2},
            new int[3] {3,4,5},
            new int[3] {6,7,8},
            new int[3] {0,3,6},
            new int[3] {1,4,7},
            new int[3] {2,5,8},
            new int[3] {0,4,8},
            new int[3] {2,4,6}
        };

        private async Task SquareCliked(int index)
        {
            if (!string.IsNullOrEmpty(board[index]))
            {
                return;
            }

            board[index] = player;
            player = player == "X" ? "O" : "X";

            foreach (int[] combo in winningCombos)
            {
                int p1 = combo[0];
                int p2 = combo[1];
                int p3 = combo[2];
                if (board[p1] == String.Empty || board[p2] == String.Empty || board[p3] == String.Empty) continue;
                if (board[p1] == board[p2] && board[p2] == board[p3] && board[p1] == board[p3])
                {
                    string winner = player == "X" ? "The player ◯" : "The player 🗙";
                    await JS.InvokeVoidAsync("ShowSwal", winner);
                    ResetGame();
                }
            }

            if (board.All(x => x != ""))
            {
                await JS.InvokeVoidAsync("ShowTie");
                ResetGame();
            }
        }
        private string GetSquareValue(int index)
        {
            var squareValue = board[index];

            if (squareValue.Equals("X", StringComparison.OrdinalIgnoreCase))
            {
                return "square-x";
            }
            else if (squareValue.Equals("O", StringComparison.OrdinalIgnoreCase))
            {
                return "square-o";
            }
            return string.Empty;
        }
        private void ResetGame()
        {
            for (int i = 0; i < board.Length; i++)
            {
                player = "X";
                board[i] = "";
            };
        }
    }
}
