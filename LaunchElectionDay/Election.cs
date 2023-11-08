using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay
{
    public class Election
    {
        public string Year {  get; set; }

        public List<Race> Races { get; set; }
        Dictionary<string, int> counts;

        public Election(string year)
        {
            Year = year;
            Races = new List<Race>();
            counts = new Dictionary<string, int>();
        }


        public void AddRace(Race race) 
        {
            Races.Add(race);
        }

        public List<Candidate> AllCandidates()
        {
           var candidates = new List<Candidate>();
            foreach (var race in Races) // using races to get to candidates. The list of candidates are buried within a list races
            {
                foreach (var can in race.Candidates)
                {
                    candidates.Add(can);
                }
            }
            return candidates;
        }

        public Dictionary<string, int> VoteCounts()
        {

            foreach (var race in Races)
            {
                foreach (var candidate in race.Candidates) // Nesting foreach loops to iterate through all candidates by iterating through the races to get to them.
                {
                    counts.Add(candidate.Name,candidate.Votes);
                }
            }
            return counts;
        }

    }
}
