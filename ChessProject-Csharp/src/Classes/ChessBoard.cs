using System;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public const int MaxBoardWidth = 7;
        public const int MaxBoardHeight = 7;
        private Pawn[,] pieces;

        public ChessBoard()
        {
            pieces = new Pawn[MaxBoardWidth, MaxBoardHeight];
        }

        public void Add(Pawn pawn, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            throw new NotImplementedException("Need to implement ChessBoard.Add()");
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            throw new NotImplementedException("Need to implement ChessBoard.IsLegalBoardPosition()");
        }
    }
}
