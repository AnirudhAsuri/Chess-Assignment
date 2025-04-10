using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.Scripts.Core.Enums;

namespace Chess.Scripts.Core
{
    public abstract class ChessPiece: MonoBehaviour
    {
        [SerializeField] protected ChessPlayerPlacementHandler placementHandler;
        public bool isEnemy => team != ChessGameManager.Instance.playerTeam;
        private void Start()
        {
            placementHandler = GetComponent<ChessPlayerPlacementHandler>();
        }

        [field: SerializeField]
        public Team team { get; private set; }


        [SerializeField] protected int row;
        [SerializeField] protected int column;

        public Vector2Int boardPosition => new Vector2Int(placementHandler.row, placementHandler.column);

        protected static readonly Vector2Int[] orthogonalDirections = {
        new Vector2Int(1, 0),   // Right
        new Vector2Int(-1, 0),  // Left
        new Vector2Int(0, 1),   // Up
        new Vector2Int(0, -1)   // Down
        };

        protected static readonly Vector2Int[] diagonalDirections = {
        new Vector2Int(1, 1),    // Top-right
        new Vector2Int(-1, 1),   // Top-left
        new Vector2Int(1, -1),   // Bottom-right
        new Vector2Int(-1, -1)   // Bottom-left
        };


        public abstract List<Vector2Int> GetPossibleMoves();

        public void HighlightPossibleMoves()
        {
            var moves = GetPossibleMoves();
            Debug.Log($"Got {moves.Count} possible moves");

            ChessBoardPlacementHandler.Instance.ClearHighlights();
            foreach (var move in moves)
            {
                ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
            }
        }

        public bool TryAddMove(Vector2Int pos, ref List<Vector2Int> moves)
        {
            Debug.Log("MOO");
            var tile = ChessBoardPlacementHandler.Instance.GetTile(pos.y, pos.x);
            if (tile == null) return false;

            // Check if any piece occupies the tile at pos
            ChessPiece[] allPieces = FindObjectsOfType<ChessPiece>();
            foreach (var piece in allPieces)
            {
                if (piece.boardPosition == pos)
                {
                    if (piece.isEnemy)
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

        public bool IsInsideBoard(Vector2Int pos)
        {
            return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
        }
    }
}