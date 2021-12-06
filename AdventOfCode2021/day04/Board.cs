namespace day04
{
    public class Board
    {
        private int[][] board = new int[25][];
        private bool won = false;

        public Board(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                board[i] = new int[] {numbers[i], 0};
            }
        }

        public void markNumber(int mark)
        {
            foreach (var number in board)
            {
                if (number[0] == mark)
                {
                    number[1] = 1;
                }
            }
        }

        public bool isWinner()
        {
            for (int i = 0; i < 5; i++)
            {
                if (board[i * 5][1] == 1 && board[i * 5 + 1][1] == 1 && board[i * 5 + 2][1] == 1 &&
                    board[i * 5 + 3][1] == 1 && board[i * 5 + 4][1] == 1)
                {
                    won = true;
                    return true;
                }
            }
            
            for (int i = 0; i < 5; i++)
            {
                if (board[i][1] == 1 && board[5 + i][1] == 1 && board[10 + i][1] == 1 &&
                    board[15 + i][1] == 1 && board[20 + i][1] == 1)
                {
                    won = true;
                    return true;
                }
            }

            return false;
        }

        public int calculateScore(int lastNumber)
        {
            int sumMarked = 0;
            foreach (var number in board)
            {
                if (number[1] == 0)
                {
                    sumMarked += number[0];
                }
            }

            return sumMarked * lastNumber;
        }

        public bool getWon()
        {
            return won;
        }
    }
}