using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public static class ChessPieceHighlighter
    {
        public static void HighlightPossibleMoves(ChessPiece piece)
        {
            var moves = piece.GetPossibleMoves();
            Debug.Log($"Got {moves.Count} possible moves");

            ChessBoardPlacementHandler.Instance.ClearHighlights();
            foreach (var move in moves)
            {
                ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
            }
        }
    }
}
