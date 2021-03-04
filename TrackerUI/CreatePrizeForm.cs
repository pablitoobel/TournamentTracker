using System;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel prizeModel = new PrizeModel(placeNumberValue.Text, placeNameValue.Text,
                    prizeAmountValue.Text, prizePercentageValue.Text);


                GlobalConfig.Connection.CreatePrize(prizeModel);
                
                placeNumberValue.Text = "";
                placeNameValue.Text = "";
                prizeAmountValue.Text = "0";
                prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("TryAgain");
            }


        }

        private bool ValidateForm()
        { 
            //TODO - change int to double after tests
            // seprate checks are more friendly for user
            bool output = true;
            int placeNumber = 0;
            //when TryParse crashes it returnes as false
            bool placeNumberValidValue = int.TryParse(placeNumberValue.Text, out placeNumber);
            if (!placeNumberValidValue)
            {
                // TODO -valid or not message
                output = false;
            }
            if(placeNumber < 1)
            {
                output = false;
            }
            if(placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            int prizePercentage = 0;

            bool prizeAmountValidation = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValidation = int.TryParse(prizePercentageValue.Text, out prizePercentage);

            if (prizeAmountValidation == false || prizePercentageValidation == false)
            {
                output = false;
            }

            if ((prizeAmount <= 0 && prizePercentage <= 0) || (prizePercentage < 0 || prizePercentage > 100))
            {
                output = false;
            }

            return output;
        }
    }
}
