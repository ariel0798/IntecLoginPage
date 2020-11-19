using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntecLoginPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : TabbedPage
    {
        public LoginPage()
        {
            InitializeComponent();
            RegistroLabelClicked();
        }

        void RegistroLabelClicked()
        {
            registroLabel.GestureRecognizers.Add(new TapGestureRecognizer()  
            {
                Command = new Command(async () =>
                 {
                     await Navigation.PushAsync(new RegistrationPage());
                 }   
                )
            });
        }

        private async void ButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailEntry.Text))
            {
                await DisplayAlert("Error", "Campo email no puede estar vacio", "Ok");
            }
            else if (string.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Campo password no puede estar vacio", "Ok");
            }
            else
            {
                var lines = UsersFile.GetUserList();

                bool foundUser = false;

                foreach(var line in lines)
                {
                    var lineArray = line.Split('|');

                    if (lineArray[1].ToLower() == emailEntry.Text.ToLower() && passwordEntry.Text == lineArray[2])
                    {
                        foundUser = true;
                        await DisplayAlert("Bienvenido", lineArray[0] +", ahora iras a la pagina master detail ", "Ok");
                        await Navigation.PushAsync(new MasterDetailPageXample());
                    }
                }

                if (!foundUser)
                    await DisplayAlert("Error", "El email o password es incorrecto", "Ok");
            }
        }
    }
}