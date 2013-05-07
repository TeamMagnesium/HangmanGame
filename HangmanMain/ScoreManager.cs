using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanMain
{
    public class ScoreManager
    {
        private static List<Player> topPlayers = new List<Player>();

        public static bool isPlayerTop(int mistakes)
        {
            if (topPlayers.Count < 5)
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

        public static void AddPlayerToScoreBoard(Player player)
        {
            if (topPlayers.Count < 5)
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

        private static void SortPlayers()
        {
            // not sure if sorting works right
            topPlayers.Sort((Player firstPlayer, Player secondPlayer) => firstPlayer.Mistakes.CompareTo(secondPlayer.Mistakes));
            topPlayers.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
        }

        public static void PrintScoreboard()
        {
            ConsoleRenderer.PrintScoreboard(topPlayers);
        }

    }
}
