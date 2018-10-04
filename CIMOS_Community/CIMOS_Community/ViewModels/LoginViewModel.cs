namespace CIMOS_Community.ViewModels
{
    using GalaSoft.MvvmLight.Command;    
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {

        #region Attributes        
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get {
                return new RelayCommand(Login);
            }            
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email)) {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar un nombre de usuario o eMail",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar una contraseña",
                    "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;
        }

        #endregion

        #region Contructors
        public LoginViewModel()
        {
            this.Email = "ajimmenezz@gmail.com";
            this.IsEnabled = true;            
        }
        #endregion
    }
}
