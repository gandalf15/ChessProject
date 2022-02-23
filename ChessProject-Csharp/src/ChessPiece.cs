using SolarWinds.MSP.Chess.Enums;
using System;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    ///  Represents a chess piece and provide basic functionality.
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
        /// Initializes the color of a ChessPiece.
        /// </summary>
        /// <param name="pieceColor">ChessPieceColor that represents the color of a chess piece.</param>
        protected ChessPiece(ChessPieceColor pieceColor)
        {
            PieceColor = pieceColor;
        }

        /// <summary>
        /// Abstract method that validates a move.
        /// </summary>
        /// <param name="destination">ChessCoordinates destination of the move.</param>
        /// <param name="boardOccupancy">2D array that represents ChessBoard occupancy state.</param>
        /// <returns></returns>
        public abstract MoveResult ValidateMove(ChessCoordinates destination, in bool[,] boardOccupancy);

        /// <summary>
        /// Abstract method that validates a capture move. 
        /// </summary>
        /// <param name="destination">ChessCoordinates destination of the capture move.</param>
        /// <param name="boardOccupancy">2D array that represents ChessBoard occupancy state.</param>
        /// <returns></returns>
        public abstract CaptureResult ValidateCapture(ChessCoordinates destination, in bool[,] boardOccupancy);

        /// <summary>
        /// Textual description of a ChessPiece instance.
        /// </summary>
        /// <returns>String that describes a ChessPiece instance.</returns>
        public override string ToString()
        {
            var colorName = Enum.GetName(PieceColor);
            if (Coordinates is null) return $"No coordinates set.{Environment.NewLine}Piece Color: {colorName}";
            return string.Format("Piece: {4}{0}Coordinates: (X: {1}, Y: {2}){0}Piece Color: {3}",
                Environment.NewLine, Coordinates.X, Coordinates.Y, colorName, this.GetType().Name);
        }
    }
}
