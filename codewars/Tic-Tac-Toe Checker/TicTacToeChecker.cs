using System;
public class TicTacToeChecker
{
    public int IsSolved(int[,] board)
    {
        bool empty = false;
        int firstDiag = board[0,0] * board[1,1] * board[2,2];
        int secondDiag = board[0,2] * board[1,1] * board[2,0];
        for (int i = 0; i < 3 ; i++)
        {
            int row = 1;
            int column = 1;
            for (int j = 0; j < 3; j++)
            {
                row *= board[i,j];
                column *= board[j,i];
            }
            if (row == 1 || column == 1) return 1;
            if (row == 8 || column == 8) return 2;
            if (row == 0 || column == 0) empty = true;
      }
      if (firstDiag == 1 || secondDiag == 1) return 1;
      if (firstDiag == 8 || secondDiag == 8) return 2;
      if (empty) return -1;
      return 0;
  }

}