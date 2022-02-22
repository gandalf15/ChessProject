using System;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    ///  ChessPiece: Represents a chess piece and provide basic functionality.
    /// </summary> 
    public abstract class ChessPiece
    {
        /// <summary>
        /// Gets or sets the coordinates of the ChessPiece on a ChessBoard.
        /// </summary>
        public virtual ChessCoordinates Coordinates { get; set; }

        /// <summary>
        /// Gets the color of the ChessPiece.
        /// </summary>
        public ChessPieceColor PieceColor { get; init; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceColor"></param>
        protected ChessPiece(ChessPieceColor pieceColor)
        {
            PieceColor = pieceColor;
        }

        public abstract MoveResult ValidateMove(ChessCoordinates destination, bool[,] boardOccupancy);
        public abstract CaptureResult ValidateCapture(ChessCoordinates destination, bool[,] boardOccupancy);

        public override string ToString()
        {
            var colorName = Enum.GetName(PieceColor);
            if (Coordinates is null) return $"No coordinates set.{Environment.NewLine}Piece Color: {colorName}";
            return string.Format("Piece: {4}{0}Coordinates: (X: {1}, Y: {2}){0}Piece Color: {3}",
                Environment.NewLine, Coordinates.X, Coordinates.Y, colorName, this.GetType().Name);
        }
    }
}
