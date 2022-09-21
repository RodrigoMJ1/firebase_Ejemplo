using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using firebase_Ejemplo.Vistas;

namespace firebase_Ejemplo.Vistas
{
    public partial class mostrarUsuario : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "kUdJV3rDF90RpMcK2cbR8SPNMMfn2I46WQ8MQUAA",
            BasePath = "https://sistema-de-guarda-valores-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;
        public mostrarUsuario()
        {
            InitializeComponent();
        }

        private void mostrarUsuario_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                mostrarUsuario cerrar = new mostrarUsuario();
                cerrar.Hide();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("Informacion/" + textBox1.Text);
            Data obj = response.ResultAs<Data>();


            if(obj.Edad != null)
            {
                MessageBox.Show("Trabajador encontrado!");
                id.Text = obj.Id;
                nombre.Text = obj.Nombre;
                area.Text = obj.Area;
                edad.Text = obj.Edad;
            }
            else
            {
                MessageBox.Show("Trabajador no encontrado!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertarUsuario regresar =  new insertarUsuario();
            regresar.Show();
            mostrarUsuario cerrar = new mostrarUsuario();
            cerrar.Close();
        }
    }
}
