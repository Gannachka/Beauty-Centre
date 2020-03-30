using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace beauty_center
{
    class UserAuthenticationViewModel : INotifyPropertyChanged
    {
        private MainWindow _mainWindow;
        private UserAuthentication _selectedUserAuthentication;
        public UserAuthentication SelectedUserAuthentication
        {
            get 
            { 
                return _selectedUserAuthentication; 
            }
            set 
            {
                _selectedUserAuthentication = value;
                OnPropertyChanged("SelectedUserAuthentication");
            }
        }
        private RelayCommand _enter;
        public RelayCommand Enter
        {
            get
            {
                return _enter ??
                    (_enter = new RelayCommand(obj =>
                      {
                          UserAuthentication user = obj as UserAuthentication;
                          user.Password = _mainWindow.AuthenticationPassBox.Password;
                          MessageBox.Show($"Username:{user.Login}\nPassword:{user.Password}");
                      }));
            }
        }
        private RelayCommand _registration;
        public RelayCommand Registration
        {
            get
            {
                return _registration ??
                    (_registration = new RelayCommand(obj =>
                   {
                       RegistrationWindow registrationWindow = new RegistrationWindow(_mainWindow);
                       registrationWindow.Show();
                   }));
            }
        }
        public UserAuthenticationViewModel(MainWindow mainWindow) 
        {
            SelectedUserAuthentication = new UserAuthentication();
            _mainWindow = mainWindow;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
