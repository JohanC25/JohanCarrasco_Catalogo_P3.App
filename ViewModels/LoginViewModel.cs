using Firebase.Auth;
using Newtonsoft.Json;
using System.ComponentModel;

namespace JohanCarrasco_Catalogo_P3.ViewModels
{
	internal class LoginViewModel : INotifyPropertyChanged
	{
		public string webApiKey = "AIzaSyC3igGjXs5iswvXJOBAH9tTOnrnvWZbSSc";

		private INavigation _navigation;

		private string email;

		private string password;

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

		public string Password
		{
			get => password; 
			set
			{
				password = value;
				RaisePropertyChanged("Password");
			}
		}

		public Command RegisterBtn { get; }
		public Command LoginBtn { get; }


		public LoginViewModel(INavigation navigation) 
		{
			this._navigation = navigation;
			RegisterBtn = new Command(RegisterBtnTappedAsync);
			LoginBtn = new Command(LoginBtnTappedAsync);
		}

		private async void LoginBtnTappedAsync(object obj)
		{
			var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
			try
			{
				var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);
				var content = await auth.GetFreshAuthAsync();
				var serializedContent = JsonConvert.SerializeObject(content);
				Preferences.Set("FreshFirebaseToken", serializedContent);
				await this._navigation.PushAsync(new Dashboard());
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
			}
			
		}		

		private async void RegisterBtnTappedAsync(object obj)
		{
			await this._navigation.PushAsync(new RegisterPage());
		}

		private void RaisePropertyChanged(string x)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(x));
		}
	}
}
