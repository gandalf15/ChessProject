using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarWinds.MSP.Chess;

namespace src.Classes
{
    public abstract class ChessPiece
    {
        private int _xCoordinate;
        private int _yCoordinate;
        private readonly PieceColor _pieceColor;

        protected ChessPiece(PieceColor pieceColor)
        {
            _pieceColor = pieceColor;
        }

        public abstract bool Move(MovementType movementType, int newX, int newY);

        public override string ToString()
        {
            return CurrentPositionAsString();
        }
        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, _xCoordinate, _yCoordinate, _pieceColor);
        }
    }
}
