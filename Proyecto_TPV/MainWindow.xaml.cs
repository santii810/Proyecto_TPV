using Proyecto_TPV.Model.DB;
using Proyecto_TPV.Repositorios;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_TPV
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnidadDeTrabajo udt = new UnidadDeTrabajo();

        ICollection<Articulo> articulos;
        ICollection<Pedido> pedidos;

        TicketVenta tmpTicket = new TicketVenta();

        string strCodigo = "";
        const int COD_AUTENTICADO_OK = 1;
        const int COD_ESTADO_INICIAL = 2;
        const int COD_PANEL_CAJA = 3;

        public MainWindow()
        {
            InitializeComponent();
            updateIU(COD_ESTADO_INICIAL);
            articulos = udt.RepositorioArticulo.Get().ToList();

        }
        #region Metodos privados
        private bool autenticado()
        {
            return true;
        }

        #region Metodos privados de diseño
        private void actualizarTicketCaja(TicketVenta ticket)
        {
            listaTicket.ItemsSource = ticket.LineasTicket.ToList();
        }
        private void updateIU(int codCambio)
        {
            switch (codCambio)
            {
                case COD_ESTADO_INICIAL:
                    autenticationPanel.Visibility = Visibility.Visible;
                    panelPrincipal.Visibility = Visibility.Collapsed;
                    panelCaja.Visibility = Visibility.Collapsed;
                    break;
                case COD_AUTENTICADO_OK:
                    autenticationPanel.Visibility = Visibility.Collapsed;
                    panelCaja.Visibility = Visibility.Collapsed;
                    panelPrincipal.Visibility = Visibility.Visible;
                    break;
                case COD_PANEL_CAJA:
                    autenticationPanel.Visibility = Visibility.Collapsed;
                    panelCaja.Visibility = Visibility.Visible;
                    panelPrincipal.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
        #endregion



        #endregion


        #region Listeners
        #region Listener numeros autenticado


        private void buttonAutenticado1_Click(object sender, RoutedEventArgs e)
        {
            strCodigo += "1";
            textBoxCodigo.Text = textBoxCodigo.Text + "*";
        }

        private void buttonAutenticado2_Click(object sender, RoutedEventArgs e)
        {
            strCodigo += "2";
            textBoxCodigo.Text = textBoxCodigo.Text + "*";
        }

        private void buttonAutenticado3_Click(object sender, RoutedEventArgs e)
        {

            strCodigo += "3";
            textBoxCodigo.Text = textBoxCodigo.Text + "*";
        }

        private void buttonAutenticado4_Click(object sender, RoutedEventArgs e)
        {
            strCodigo += "4";
            textBoxCodigo.Text = textBoxCodigo.Text + "*";
        }

        private void buttonAutenticado5_Click(object sender, RoutedEventArgs e)
        {
            strCodigo += "5";
            textBoxCodigo.Text = textBoxCodigo.Text + "*";
        }

        private void buttonAutenticado6_Click(object sender, RoutedEventArgs e)
        {
            strCodigo += "6";
            textBoxCodigo.Text = textBoxCodigo.Text + "*";
        }

        private void buttonAutenticado7_Click(object sender, RoutedEventArgs e)
        {
            strCodigo += "7";
            textBoxCodigo.Text = textBoxCodigo.Text + "*";
        }

        private void buttonAutenticado8_Click(object sender, RoutedEventArgs e)
        {
            strCodigo += "8";
            textBoxCodigo.Text = textBoxCodigo.Text + "*";
        }

        private void buttonAutenticado9_Click(object sender, RoutedEventArgs e)
        {
            strCodigo += "9";
            textBoxCodigo.Text = textBoxCodigo.Text + "*";
        }

        private void buttonAutenticado0_Click(object sender, RoutedEventArgs e)
        {
            strCodigo += "0";
            textBoxCodigo.Text = textBoxCodigo.Text + "*";
        }

        private void buttonAutenticadoCancel_Click(object sender, RoutedEventArgs e)
        {
            if (strCodigo.Length > 0)
            {
                strCodigo = strCodigo.Remove(strCodigo.Length - 1);
                textBoxCodigo.Text = textBoxCodigo.Text.Remove(textBoxCodigo.Text.Length - 1);
            }
        }

        private void buttonAutenticadoOk_Click(object sender, RoutedEventArgs e)
        {
            if (autenticado())
            {
                updateIU(COD_AUTENTICADO_OK);

            }
        }

        #endregion

        #region Listeners numeros caja
        private void buttonCaja1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCaja2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCaja3_Click(object sender, RoutedEventArgs e)
        {


        }

        private void buttonCaja4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCaja5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCaja6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCaja7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCaja8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCaja9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCaja0_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCajaCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCajaOk_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void Caja_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            updateIU(COD_PANEL_CAJA);
            /*Articulo item = new Articulo
            {
                NombreArticulo = "cocacola",
                ArticuloId = "cocacola"
            };*/
            foreach (Articulo item in articulos)
            {
                Image tmpImagen = new Image();
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri("Iconos/Productos/" + item.ArticuloId + ".jpg", UriKind.Relative);
                src.EndInit();
                tmpImagen.Source = src;
                tmpImagen.Stretch = Stretch.Uniform;
                tmpImagen.Width = 100;
                tmpImagen.MouseLeftButtonUp += delegate { pulsarArticuloCaja(item); };

                this.panelProductos.Children.Add(tmpImagen);
            }




        }

        private void pulsarArticuloCaja(Articulo item)
        {

            if (tmpTicket.LineasTicket.Where(i => i.ArticuloId == item.ArticuloId).FirstOrDefault() == null)
            {

                LineaTicket tmpLineaTicket = new LineaTicket
                {
                    ArticuloId = item.ArticuloId,
                    cantidad = 1,
                    precioArticulo = item.PrecioArticulo
                };
                tmpTicket.LineasTicket.Add(tmpLineaTicket);
            }
            else
            {
                tmpTicket.LineasTicket.Where(i => i.ArticuloId == item.ArticuloId).FirstOrDefault().cantidad++;
            }

            actualizarTicketCaja(tmpTicket);
        }


        private void buttonNuevoTicket_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Borrar el ticket actual?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                tmpTicket = new TicketVenta();
                actualizarTicketCaja(tmpTicket);
            }
        }

        private void buttonconfirmarTicket_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
    #endregion
}
