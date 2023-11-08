using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay.UnitTests
{
    public class ElectionTests
    {
        [Fact]

        public void ElectionCreatesAnElectionWithYearAndEmptyRaces()
        {
            var election = new Election("2000");
            Assert.Equal("2000", election.Year);
            Assert.Equal(new List<Race>(), election.Races);
        }

        [Fact]

        public void AddRaceAddsRaceToListOfRaces()
        {
            var election = new Election("2000");
            var race1 = new Race("City Council D1");
            var race2 = new Race("City Council D2");

            election.AddRace(race1);
            election.AddRace(race2);

            Assert.Equal(new List<Race> { race1, race2}, election.Races);
        }

        [Fact]

        public void AllCandidatesRetunsListOfCandidates()
        {
            var election = new Election("2000");
            var race1 = new Race("City Council D1");
            var race2 = new Race("City Council D2");
            var can1 = new Candidate("Diana D", "Democrat");
            var can2 = new Candidate("Asher", "Democrat");
            var can3 = new Candidate("Sam", "Democrat");

            election.AddRace(race1);
            election.AddRace(race2);
            race1.RegisterCandidate(can3);
            race1.RegisterCandidate(can1);
            race2.RegisterCandidate(can2);

            var expected = new List<Candidate> { can3, can1, can2 }; // Order matters here

            Assert.Equal(expected, election.AllCandidates());
            Assert.Equal(3,election.AllCandidates().Count);
            Assert.Contains(can1, election.AllCandidates());
            Assert.Contains(can2, election.AllCandidates());
            Assert.Contains(can3, election.AllCandidates());
        }



        [Fact]

        public void VoteCountsReturnsDictionaryWithCandidateNamesAndVoteCounts()
        {
            var election = new Election("2000");
            var race1 = new Race("City Council D1");
            var race2 = new Race("City Council D2");
            var can1 = new Candidate("Diana D", "Democrat");
            var can2 = new Candidate("Asher", "Democrat");
            var can3 = new Candidate("Sam", "Democrat");

            can1.VoteFor();
            can1.VoteFor();
            can1.VoteFor();
            can2.VoteFor();
            can2.VoteFor();
            can3.VoteFor();

            election.AddRace(race1);
            election.AddRace(race2);
            race1.RegisterCandidate(can3);
            race1.RegisterCandidate(can1);
            race2.RegisterCandidate(can2);

            var expected = new Dictionary<string, int>() //  String and not custom because each candidates name is the key
            {
                {can1.Name, 3 },
                {can2.Name, 2 },
                {can3.Name, 1 },
            };
            // ^ Created a variable to simplify the Assert
            // ^ order doesnt matter for a dictionary, so this could be can3, can1, can2 or any combination
            Assert.Equal(expected, election.VoteCounts());
            
        }


    }
}
