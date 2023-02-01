using Firebase.Auth;
using System.ComponentModel;

namespace JohanCarrasco_Catalogo_P3.ViewModels
{
	internal class RegisterViewModel : INotifyPropertyChanged
	{
		public string webApiKey = "AIzaSyC3igGjXs5iswvXJOBAH9tTOnrnvWZbSSc";

		private INavigation _navigation;

		private string email;
		private string contrasenia;

		public event PropertyChangedEventHandler PropertyChanged;

		public string Email
		{
			get => email;
			set
			{
				email = value;
				RaisePropertyChanged("Email");
			}
		}

		public string Contrasenia
		{
			get =>contrasenia;
			set
			{
				contrasenia = value;
				RaisePropertyChanged("Contraseña");
			}
		}

		public Command RegisterUser { get; }

		private void RaisePropertyChanged(string x)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(x));
		}

		public RegisterViewModel(INavigation navigation)
		{
			this._navigation = navigation;

			RegisterUser = new Command(RegisterUserTappedAsync);
		}

		private async void RegisterUserTappedAsync(object obj)
		{
			try
			{
				var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
				var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Contrasenia);
				string token = auth.FirebaseToken;
				if(token != null)
				{
					await App.Current.MainPage.DisplayAlert("Alert", "Registro exitoso!", "OK");
				}
				await this._navigation.PopAsync();
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
			}
		}
	}
}
