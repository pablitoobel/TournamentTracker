using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (IsVaildForm())
            {
                PersonModel personModel = new PersonModel();
                personModel.Firstname = firstNameValue.Text;
                personModel.LastName = lastNameValue.Text;
                personModel.EmailAddres = emailValue.Text;
                personModel.PhoneNumber = cellphoneNumberValue.Text;

                GlobalConfig.Connection.CreatePerson(personModel);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneNumberValue.Text = "";
            }
            else
                MessageBox.Show("Wrong data");

        }
        private bool IsVaildForm()
        {
            bool output = true;
            // todo - logic
            if (firstNameValue.Text.Length == 0)
            {
                return output = false;
            }
            if (lastNameValue.Text.Length == 0)
            {
                return output = false;
            }
            if (emailValue.Text.Length == 0 || !emailValue.Text.Contains('@'))
            {
                return output = false;
            }
            return output;
        }
    }
}
