using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntecLoginPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            BackgroundColor = Color.White;
        }

        private async void ButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameEntry.Text))
            {
                await DisplayAlert("Error", "Campo name no puede estar vacio", "Ok");
            }
            else if (string.IsNullOrEmpty(emailEntry.Text))
            {
                await DisplayAlert("Error", "Campo email no puede estar vacio", "Ok");
            }
            else if (string.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Campo password no puede estar vacio", "Ok");
            }
            else if (string.IsNullOrEmpty(confirmPasswordEntry.Text))
            {
                await DisplayAlert("Error", "Campo confirm password no puede estar vacio", "Ok");
            }
            else if(passwordEntry.Text != confirmPasswordEntry.Text)
            {
                await DisplayAlert("Error", "las claves no coinciden, favor revisar", "Ok");
            }
            else
            {
                var lines = UsersFile.GetUserList();

                bool userCreated = false;

                foreach (var line in lines)
                {
                    var lineArray = line.Split('|');

                    if(lineArray[1].ToLower() == emailEntry.Text.ToLower())
                    {
                        userCreated = true;
                        break;
                    }
                }

                if (userCreated)
                {
                    await DisplayAlert("Email existente", "El email ya existe, elegir otro", "Ok");
                }
                else
                {
                    string userLine = nameEntry.Text + "|" + emailEntry.Text + "|" + passwordEntry.Text;

                    lines.Add(userLine);
                    
                    UsersFile.AddLines(lines);
                    
                    await DisplayAlert("Creado", "El usuario fue creado satisfactoriamente", "Ok");

                    await Navigation.PopAsync();
                }
                
            }
        }
    }
}