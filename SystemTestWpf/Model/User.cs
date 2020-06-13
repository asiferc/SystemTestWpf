using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTestWpf.Model
{
    public class User : INotifyPropertyChanged
    {
        private int _employeeId;
        private string _firstName;
        private string _address;
        private string _lastName;
        private DateTime _dob;



        public User()
        {
        }

        public int EmployeeID
        {
            get { return _employeeId; }
            set
            {
                _employeeId = value;
                NotifyOfPropertyChange("EmployeeID");
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange("FirstName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange("LastName");
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                NotifyOfPropertyChange("Address");
            }
        }

        public DateTime DOB
        {
            get { return _dob; }
            set
            {
                _dob = value;
                NotifyOfPropertyChange("BirthDate");
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOfPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
