using SolarWinds.MSP.Chess.Enums;
using System;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Represents a Pawn chess piece.
    /// </summary>
    public sealed class Pawn : ChessPiece
    {
        /// <summary>
        /// Creates a Pawn of a specific color.
        /// </summary>
        /// <param name="pieceColor">ChessPieceColor of the Pawn.</param>
        public Pawn(ChessPieceColor pieceColor) : base(pieceColor) { }

        /// <summary>
        /// Validates a move
        /// </summary>
        /// <param name="destination">ChessCoordinates destination of the move.</param>
        /// <param name="boardOccupancy">2D array that represents ChessBoard occupancy state.</param>
        /// <returns>MoveResult</returns>
        public override MoveResult ValidateMove(ChessCoordinates destination, bool[,] boardOccupancy)
        {
            // Check if not moving sideways.
            if (Coordinates.Y != destination.Y) return MoveResult.NotValidMove;

            // Determine the distance and direction.
            var distance = Coordinates.X - destination.X;
            var direction = "up";
            if (distance > 0) direction = "down";
            var absDistance = Math.Abs(Coordinates.X - destination.X);

            // Check if moving the right direction.
            if (direction == "up" && PieceColor is ChessPieceColor.Black) return MoveResult.NotValidMove;
            if (direction == "down" && PieceColor is ChessPieceColor.White) return MoveResult.NotValidMove;

            // Distinguish two types of move. 1 and 2 squares move.
            switch (absDistance)
            {
                case 1:
                    return boardOccupancy[destination.X, destination.Y] ? MoveResult.Blocked : MoveResult.Avalilable;
                case 2:
                    // Check if pawn is at the starting position.
                    if (Coordinates.X == 1 && PieceColor == ChessPieceColor.White)
                    {
                        if (boardOccupancy[destination.X, destination.Y] ||
                            boardOccupancy[Coordinates.X + 1, Coordinates.Y]) return MoveResult.Blocked;
                        return MoveResult.Avalilable;
                    }
                    else if (Coordinates.X == 6 && PieceColor == ChessPieceColor.Black)
                    {
                        if (boardOccupancy[destination.X, destination.Y] ||
                            boardOccupancy[Coordinates.X - 1, Coordinates.Y]) return MoveResult.Blocked;
                        return MoveResult.Avalilable;
                    }
                    else
                    {
                        return MoveResult.NotValidMove;
                    }
                default:
                    return MoveResult.NotValidMove;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destination">ChessCoordinates destination of the capture move.</param>
        /// <param name="boardOccupancy">2D array that represents ChessBoard occupancy state.</param>
        /// <returns>CaptureResult</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override CaptureResult ValidateCapture(ChessCoordinates destination, bool[,] boardOccupancy)
        {
            throw new NotImplementedException("CaptureResult method for Pawn is not implemented.");
        }

    }
}
