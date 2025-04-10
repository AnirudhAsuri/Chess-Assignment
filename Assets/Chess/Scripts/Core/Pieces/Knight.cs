using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core.Pieces
{
    public class Knight : ChessPiece
    {
        // Knight's unique movement pattern
        private static readonly Vector2Int[] knightDirections = {
            new Vector2Int(2, 1),  // 2 squares in x, 1 in y
            new Vector2Int(2, -1), // 2 squares in x, -1 in y
            new Vector2Int(-2, 1), // -2 squares in x, 1 in y
            new Vector2Int(-2, -1),// -2 squares in x, -1 in y
            new Vector2Int(1, 2),  // 1 square in x, 2 in y
            new Vector2Int(1, -2), // 1 square in x, -2 in y
            new Vector2Int(-1, 2), // -1 square in x, 2 in y
            new Vector2Int(-1, -2) // -1 square in x, -2 in y
        };

        public override List<Vector2Int> GetPossibleMoves()
        {
            var possibleMoves = new List<Vector2Int>();

            foreach (var direction in knightDirections)
            {
                var current = boardPosition + direction;

                if (MoveUtility.IsInsideBoard(current))
                {
                    // The Knight can jump over pieces, so no need to check for occupancy
                    // Simply add the move if it's a valid tile
                    ChessPiece[] allPieces = FindObjectsOfType<ChessPiece>();
                    foreach (var piece in allPieces)
                    {
                        if (piece.boardPosition == current)
                        {
                            if (piece.isEnemy)
                            {
                                possibleMoves.Add(current); // capturable piece
                            }
                            break;
                        }
                    }
                    if (IsEmptyOrEnemy(current))
                    {
                        possibleMoves.Add(current);
                    }
                }
            }

            return possibleMoves;
        }

        // Helper function to check if the tile is empty or contains an enemy piece
        private bool IsEmptyOrEnemy(Vector2Int pos)
        {
            ChessPiece[] allPieces = FindObjectsOfType<ChessPiece>();
            foreach (var piece in allPieces)
            {
                if (piece.boardPosition == pos)
                {
                    if (piece.isEnemy) return true; // capturable piece
                    return false; // same-team piece or blocked
                }
            }
            return true; // empty tile
        }
    }
}