using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one person
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Unique Id for the person
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Obvious
        /// </summary>
        public string Firstname { get; set; }
        /// <summary>
        /// The last name of the person
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Required email address
        /// </summary>
        public string EmailAddres { get; set; }
        /// <summary>
        /// Phone number of the person
        /// </summary>
        public string PhoneNumber { get; set; }
        public PersonModel()
        {

        }
        public PersonModel(string a, string b, string c, string d)
        {

        }
    }
    
}
