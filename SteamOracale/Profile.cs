using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamOracale
{
    class Profile
    {
        public readonly string steamID;

        public bool searched;
        public int weight;

        // string is a steamID of a profile int is a index to the node containing that steamID in the graph
        public readonly Dictionary<string, int> connections;

        public Profile(string steamID, int weight)
        {
            this.steamID = steamID;
            this.weight = weight;
            connections = new Dictionary<string, int>();
        }

        /// <summary>
        /// Generates the dictionary of connections 
        /// </summary>
        public void SearchProfile(Graph g)
        {
            SteamAPI api = new SteamAPI();

            string result = api.GetFriendsList(steamID);

            if (result is not null)
            {
                dynamic stuff = JObject.Parse(result);

                JArray friends = stuff.friendslist.friends;

                foreach (dynamic token in friends)
                {
                    if (!connections.ContainsKey($"{token.steamid}"))
                    connections.Add(Convert.ToString(token.steamid), g.IndexOf(Convert.ToString(token.steamid), this));
                }
            }
            searched = true;
        }
    }
}
