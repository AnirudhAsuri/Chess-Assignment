using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public static class MoveUtility
    {
        public static bool IsInsideBoard(Vector2Int pos)
        {
            return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
        }

        public static bool TryAddMove(Vector2Int pos, ref List<Vector2Int> moves, ChessPiece self)
        {
            var tile = ChessBoardPlacementHandler.Instance.GetTile(pos.y, pos.x);
            if (tile == null) return false;

            var allPieces = Object.FindObjectsOfType<ChessPiece>();
            foreach (var piece in allPieces)
            {
                if (piece.boardPosition == pos)
                {
                    if (piece.isEnemy != self.isEnemy)
                    {
                        moves.Add(pos);
                        break;
                    }
                    return false;
                }
            }

            moves.Add(pos);
            return true;
        }
    }
}