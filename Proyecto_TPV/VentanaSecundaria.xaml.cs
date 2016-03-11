using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_TPV
{
    /// <summary>
    /// Lógica de interacción para VentanaSecundaria.xaml
    /// </summary>
    public partial class VentanaSecundaria : Window
    {

        const int COD_NUEVO_PRECIO = 30;
        public VentanaSecundaria(int cod)
        {
            InitializeComponent();
            updateIU(cod);
        }

        private void updateIU(int cod)
        {
            switch (cod)
            {
                case COD_NUEVO_PRECIO:
                    panelActualizarPrecio.Visibility = Visibility.Visible;
                    this.Width = 300;
                    this.Height = 80;
                    this.Title = "Cambiar precio";
                    break;
            }
        }

        private void buttonAceptarNuevoPrecio_Click(object sender, RoutedEventArgs e)
        {
            int i;
            Int32.TryParse(textBoxNuevoPrecio.Text, out i);
            try
            {
                Convert.ToInt32(textBoxNuevoPrecio.Text);
            }
            catch
            {

            }

        }

        private void textBoxNuevoPrecio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
