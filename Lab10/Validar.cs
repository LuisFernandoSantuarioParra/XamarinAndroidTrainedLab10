using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", Icon = "@drawable/icon")]
    public class Validar : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Validar);

            var Email = FindViewById<EditText>(Resource.Id.Email);
            var Password = FindViewById<EditText>(Resource.Id.Password);

            var EmailHeader = FindViewById<TextView>(Resource.Id.EmailHeader);
            var PasswordHeader = FindViewById<TextView>(Resource.Id.PasswordHeader);

            EmailHeader.Text = GetText(Resource.String.EmailHeader);
            PasswordHeader.Text = GetText(Resource.String.PasswordHeader);
           


            //validar actividad
            var ValidarButton = FindViewById<Button>(Resource.Id.ValidadActividad);
            ValidarButton.Text = GetText(Resource.String.Validar);

            var menssage = FindViewById<TextView>(Resource.Id.message);
            var email = string.Empty;
            var password = string.Empty;

            ValidarButton.Click += (object sender, System.EventArgs e) =>
            {
                email = Email.Text;
                password = Password.Text;
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    menssage.Text = "No se ha proporcionado contraseña o correo electronico, verifique de nuevo";

                }
                else
                {

                    Validate(email, password);
                }



            };


        }
        //metodo para validar actividad
        private async void Validate(string email, string password)
        {
            var menssage = FindViewById<TextView>(Resource.Id.message);

            var ServiceClient = new SALLab10.ServiceClient();

            string StudentEmail = email;
            string Password = password;

            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            var Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            menssage.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";

        }
    }
}