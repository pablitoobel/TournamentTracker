using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        /// <summary>
        /// The unique identifier for the Prize
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identifier for the place 1-first
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// String for a Place Name
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// Total amount of money that Team can win
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// Percentage of overall take.
        /// From 0 to 1
        /// </summary>
        public double PrizePercentage { get; set; }

        public PrizeModel()
        {

        }
        public PrizeModel(string placeNumber, string placeName, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;

        }
    }
}
