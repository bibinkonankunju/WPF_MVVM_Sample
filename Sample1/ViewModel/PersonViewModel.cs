using Sample1.Command;
using Sample1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sample1.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public PersonViewModel()
        {
            Person = new Person();
            PersonList = new ObservableCollection<Person>();
        }

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { _person = value; NotifyPropertyChanged("Person"); }
        }

        private ObservableCollection<Person> _personList;
        public ObservableCollection<Person> PersonList
        {
            get { return _personList; }
            set { _personList = value; NotifyPropertyChanged("PersonList"); }
        }

        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if(_submitCommand == null)
                {
                    _submitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _submitCommand;
            }
        }

        private void SubmitExecute(object parameter)
        {
            PersonList.Add(Person);
        }

        private bool CanSubmitExecute(object parameter)
        {
            if(string.IsNullOrEmpty(Person.FName) || string.IsNullOrEmpty(Person.LName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
