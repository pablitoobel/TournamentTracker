using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents a one tournament.
    /// </summary>
    public class TorunamentModel
    {
        public string TorunamentName { get; set; }
        /// <summary>
        /// The amount of money required to get into the tournamnt.
        /// </summary>
        public decimal EntryFee { get; set; }
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        public List<PrizeModel> Prizes { get; set; }
        /// <summary>
        /// The matczups per round.
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; }

        public TorunamentModel()
        {
            Prizes = new List<PrizeModel>();
            Rounds = new List<List<MatchupModel>>();
        }
    }
}
