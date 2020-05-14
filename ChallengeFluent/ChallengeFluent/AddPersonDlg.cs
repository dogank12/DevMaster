using ChallengeFluent.Validators;
using FluentValidation.Results;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChallengeFluent
{
    //https://www.youtube.com/watch?v=Zh1ccvTFzs8
    public partial class AddPersonDlg : Form
    {
        BindingList<string> _errors = new BindingList<string>();
        int _id = -1;
        public AddPersonDlg()
        {
            InitializeComponent();
            Errors.DataSource = _errors;
        }

        private void CreateNewPerson_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "";
            _errors.Clear();

            if (!int.TryParse(this.Id.Text, out int _id))
            {
                _errors.Add("Invalid id");
                return;
            }
            PersonModel _p = new PersonModel();
            
            _p.FirstName = FirstName.Text;
            _p.LastName = LastName.Text;
            _p.DateOfBirth = DateOfBirthTimePicker.Value;
            _p.Address = new AddressModel();
            _p.Address.AddressType = "new";
            _p.Address.City = "";
            _p.Address.State = "";
            _p.Address.StreetAddress = "";
            _p.Address.ZipCode = "";

            #region //Fluent validation
            PersonValidator _validator = new PersonValidator();
            var _results = _validator.Validate(_p);
            if(_results.IsValid==false)
                foreach(ValidationFailure error in _results.Errors)
                    _errors.Add(error.ErrorMessage);

            #endregion
            StatusLabel.Text = "Complete";
        }

    }
}
