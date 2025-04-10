using UnityEngine;
using Chess.Scripts.Core.Enums;

namespace Chess.Scripts.Core
{
    public class ChessGameManager : MonoBehaviour
    {
        public static ChessGameManager Instance { get; private set; }

        [field: SerializeField]
        public Team playerTeam { get; private set; } = Team.Player;  // Default to Player; can change via Inspector

        private void Awake()
        {
            // Singleton Pattern
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
    }
}