using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using Vostok.Models;

namespace Vostok.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<Employee> Employees { get; set; }
        public static ObservableCollection<Workshop> Workshops { get; set; }
        public static ObservableCollection<City> Cities { get; set; }
        public static ObservableCollection<Brigade> Brigades { get; set; }
        public static ObservableCollection<Change> Changes { get; set; }

        public ICollectionView CitiesView { get; private set; } 
        public ICollectionView WorkshopsView { get; private set; }
        public ICollectionView EmployeesView { get; private set; }
        public ICollectionView ChangesView { get; private set; }
        public MainViewModel()
        {
            Employees = new ObservableCollection<Employee>(DataBase.Employees);
            Workshops = new ObservableCollection<Workshop>(DataBase.Workshops);
            Cities = new ObservableCollection<City>(DataBase.Cities);
            Brigades = new ObservableCollection<Brigade>(DataBase.Brigades);
            Changes = new ObservableCollection<Change>(DataBase.Changes);

            CitiesView = CollectionViewSource.GetDefaultView(Cities);
            WorkshopsView = CollectionViewSource.GetDefaultView(Workshops);
            EmployeesView = CollectionViewSource.GetDefaultView(Employees);
        }


        private City _selectedCity;
        public City SelectedCity
        {
            get =>  _selectedCity; 
            set {                
                _selectedCity = value;

                WorkshopsView.Filter = workshop => _selectedCity.IdsWorkshops.Contains((workshop as Workshop).Id);
            }
        }

        private Workshop _selectedWorkshop;
        public Workshop SelectedWorkshop
        {
            get => _selectedWorkshop;
            set
            {
                _selectedWorkshop = value;

                EmployeesView.Filter = emp => _selectedWorkshop.IdsEmployees.Contains((emp as Employee).Id);
            }
        }

        private Employee _selectedEmployee;

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                
                // Set Brigade
                var hours = DateTime.Now.Hour;
                SelectedBrigade = hours > 8 && hours < 20 ? Brigades[0] : Brigades[1];

                // Set Change
                Changes.Clear();
                for (int loop = 8, index = 0, start = _selectedBrigade.Start; (start + loop) % 24 <= _selectedBrigade.End; index++, start++)
                    Changes.Add(new Change() { Id = index, Name = $"{start % 24}-{(start + loop) % 24}" });

                ChangesView = CollectionViewSource.GetDefaultView(Changes);
            }
        }

        private Brigade _selectedBrigade { get; set; }

        public Brigade SelectedBrigade
        {
            get { return _selectedBrigade; }
            set
            {
                if (value != _selectedBrigade)
                {
                    _selectedBrigade = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
