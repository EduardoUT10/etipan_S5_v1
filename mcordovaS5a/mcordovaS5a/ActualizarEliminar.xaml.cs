﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mcordovaS5a
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarEliminar : ContentPage
    {
        private List<Estudiante> listaEstudiante;
        public ActualizarEliminar(int codigo,string nombre, string apellido,int edad)
        {
            InitializeComponent();
            txtCodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;    
            txtApellido.Text = apellido;    
            txtEdad.Text = edad.ToString();    
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection(); //contenedor de los datos como un vector

            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.20.34/ws_uisrael/post.php?txtCodigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);

            DisplayAlert("ACTUALIZAR", "Dato actualizado con exito", "Cerrar");

            Navigation.PushAsync(new MainPage());
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection(); //contenedor de los datos como un vector

            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.20.34/ws_uisrael/post.php?txtCodigo=" + txtCodigo.Text, "DELETE", parametros);

            DisplayAlert("ELIMINAR", "Dato actualizado con exito", "Cerrar");

            Navigation.PushAsync(new MainPage());
        }
    }
    }
