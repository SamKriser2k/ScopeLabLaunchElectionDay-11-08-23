using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay.UnitTests
{
    public class RaceTests
    {

        [Fact]
        public void IsCreatedWithDistractNameAndEmptyCandidates()
        {
            var race = new Race("City Council District 10");
            Assert.Equal("City Council District 10", race.Office);
            Assert.Equal(new List<Candidate>(), race.Candidates);
        }


        [Fact]
        public void RegisterCandidateAddsCandidateToRace()
        {
            var race = new Race("City Council District 10");
            var diana = new Candidate("Diana D", "Democrat");
            var lance = new Candidate("Lance", "Democrat");

            race.RegisterCandidate(diana);
            race.RegisterCandidate(lance);

            Assert.Equal(diana, race.Candidates[0]);
            Assert.Equal(lance, race.Candidates[1]);
        }
    }
}
