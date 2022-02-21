using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarWinds.MSP.Chess;

namespace SolarWinds.MSP.Chess
{
    public abstract class ChessPiece
    {
        public virtual ChessCoordinates Coordinates { get; set; }
        public ChessPieceColor PieceColor { get; init; }

        protected ChessPiece(ChessPieceColor pieceColor)
        {
            PieceColor = pieceColor;
        }

        public abstract MoveResult ValidateMove(ChessCoordinates destination, bool[,] boardOccupancy);
        public abstract CaptureResult ValidateCapture(ChessCoordinates destination, bool[,] boardOccupancy);

        public override string ToString()
        {
            return CurrentPositionAsString();
        }
        protected string CurrentPositionAsString()
        {
            var colorName = Enum.GetName(PieceColor);
            if (Coordinates is null) return $"No coordinates set.{Environment.NewLine}Piece Color: {colorName}";
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, Coordinates.X, Coordinates.Y, colorName);
        }
    }
}
