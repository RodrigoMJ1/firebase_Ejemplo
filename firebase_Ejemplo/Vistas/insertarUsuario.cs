using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using firebase_Ejemplo.Vistas;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace firebase_Ejemplo
{
    public partial class insertarUsuario : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "kUdJV3rDF90RpMcK2cbR8SPNMMfn2I46WQ8MQUAA",
            BasePath = "https://sistema-de-guarda-valores-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        public insertarUsuario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Conexión establecida");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                Id = textBox1.Text,
                Nombre = textBox2.Text,
                Area = textBox3.Text,
                Edad = textBox4.Text
            };

            SetResponse response = await client.SetTaskAsync("Informacion/"+ textBox1.Text, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Datos Insertados con id: "+ result.Id);
        }

        private  void button2_Click(object sender, EventArgs e)
        {
            mostrarUsuario mostrar = new mostrarUsuario();
            mostrar.Show();
            insertarUsuario cerrar = new insertarUsuario();
            cerrar.Close();
        }
    }
}
