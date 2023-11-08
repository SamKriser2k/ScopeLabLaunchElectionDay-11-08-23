using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay
{
    public class Race
    {
        public string Office {  get; set; }
        public List<Candidate> Candidates { get; set; }

        public bool IsOpen = true;

        public Race(string office)
        {
        Office = office;
        Candidates = new List<Candidate>(); // giving the list a starting value
        }

        public void RegisterCandidate (Candidate candidate) //  doesnt matter that the 2nd candidate says candidate, could say anything
        {
            Candidates.Add(candidate);
        }

        public void Close()
        {
            IsOpen = false;
        }


    }
}
