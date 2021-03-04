using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TeamModel
    {
        public List<PersonModel> TeamMember { get; set; } = new List<PersonModel>();
        //in older version ctor TeamMember and then assign TeamMember to list
        public string TeamName { get; set; }
    }
}
