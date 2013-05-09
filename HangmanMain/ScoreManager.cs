using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
    public class ScoreManager
    {
        private const int MaxNumberOFPlayers = 5;

        private List<Player> topPlayers = new List<Player>();
        public List<Player> TopPlayers
        {
            get { return topPlayers; }
            private set { topPlayers = value; }
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
            // not sure if sorting works right
            topPlayers.Sort((Player firstPlayer, Player secondPlayer) => firstPlayer.Mistakes.CompareTo(secondPlayer.Mistakes));
            topPlayers.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
        }
    }
}
