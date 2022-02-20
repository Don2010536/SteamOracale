using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamOracale
{
    class Graph
    {
        public List<Profile> profiles = new List<Profile>();

        /// <summary>
        /// Returns the index of the profile with the given steamid in the profiles list
        /// If the profile doesn't exist it will be created and added with the index returned
        /// </summary>
        /// <param name="steamID"></param>
        /// <returns></returns>
        public int IndexOf(string steamID, Profile sender = null)
        {
            foreach (Profile profile in profiles)
            {
                if (profile.steamID == steamID)
                {
                    return profiles.IndexOf(profile);
                }
            }

            return AddProfile(steamID, sender.weight + 1);
        }

        /// <summary>
        /// Adds a new profile to the graph and returns the index of the profile
        /// </summary>
        /// <param name="steamID"></param>
        /// <returns></returns>
        public int AddProfile(string steamID, int weight)
        {
            profiles.Add(new Profile(steamID, weight));
            return profiles.Count - 1;
        }
    }
}
