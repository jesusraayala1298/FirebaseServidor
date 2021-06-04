using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace FirebaseServidor
{
 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private async Task btnPeticion_ClickAsync()
        {
            //CREDENCIALES PROPORCIONADAS POR FIREBASE
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("C:/Users/Jesus Ramirez Ayala/Downloads/fir-android-7686b-firebase-adminsdk-6i4e0-128d7be009.json")
            });

            //TOKEN DEL DISPOSITIVO PARA ENVIAR LA NOTIFICACION
            var registrationToken = "cfCiQuv4RoaCVDh4wbeZRx:APA91bGUwLq62WPx22Z5Z9PK5ZwrqKuu_KeUNoQw6i-54yFcW8_pRJdvHArjhsDXo1HeLMptwZuioY4PGN8aTr9h-Gd83srkzeYrxnFvE9YgB-FOFNJZ2a48vBhHbvT3HF7RecV_Se73";

            //SE CREA EL MENSAJE QUE CONTENDRA LA NOTIFICACION
            var message = new FirebaseAdmin.Messaging.Message()
            {
                Notification = new Notification()
                {
                    Title = txtTitulo.Text,
                    Body = txtMensaje.Text,
                },
                Token = registrationToken,
            };

            //ENVIAR EL MENSAJE AL TOKEN
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            //RESPUESTA DE LA PETICION CON EL ID DEL MENSAJE ENVIADO
            MessageBox.Show("Successfully sent message: " + response);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            btnPeticion_ClickAsync();
        }
    }
}
