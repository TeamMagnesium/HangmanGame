using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanMain
{
    public sealed class ScoreManager
    {
        private const int MaxNumberOFPlayers = 5;

        private static ScoreManager instance;

        private ScoreManager() { }

        public static ScoreManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScoreManager();
                }

                return instance;
            }
        }        

        private List<Player> topPlayers = new List<Player>();
        public List<Player> TopPlayers
        {
            get { return topPlayers; }
        }


        public bool IsPlayerTop(int mistakes)
        {
            if (topPlayers.Count < MaxNumberOFPlayers)
            {
                return true;
            }

            for (int i = 0; i < topPlayers.Count; i++)
            {
                if (topPlayers[i].Mistakes > mistakes)
                {
                    return true;
                }
            }

            return false;
        }

        public void AddPlayerToScoreBoard(Player player)
        {
            if (topPlayers.Count < MaxNumberOFPlayers)
            {
                topPlayers.Add(player);
            }
            else
            {
                for (int i = 0; i < topPlayers.Count; i++)
                {
                    if (topPlayers[i].Mistakes > player.Mistakes)
                    {
                        topPlayers.Insert(i, player);
                        topPlayers.RemoveAt(topPlayers.Count - 1);
                        break;
                    }
                }
            }
            SortPlayers();
        }

        private void SortPlayers()
        {
            topPlayers.Sort((Player firstPlayer, Player secondPlayer) => -(secondPlayer.Mistakes.CompareTo(firstPlayer.Mistakes)));
        }
    }
}
