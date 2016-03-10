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
        Usuario usuario;


        TicketVenta tmpTicket = new TicketVenta();
        private Sesion sesionActual;


        string strCodigo = "";
        const int COD_AUTENTICADO_OK = 1;
        const int COD_ESTADO_INICIAL = 2;
        const int COD_PANEL_CAJA = 3;
        const int COD_ACTUALIZAR_TICKET_CAJA = 4;
        const int COD_PANEL_ALMACEN = 5;
        const int COD_PANEL_CONFIG = 6;
        const int COD_PANEL_USUARIOS = 7;

        public MainWindow()
        {
            InitializeComponent();
            updateIU(COD_ESTADO_INICIAL);

        }
        #region Metodos privados
        /// <summary>
        /// Autentica al usuario con el codigo de acceso.
        /// </summary>
        /// <param name="codigo">The codigo.</param>
        /// <returns></returns>
        private bool autenticado(string codigo)
        {
            bool autenticado = false;
            foreach (Usuario item in udt.RepositorioUsuario.Get().ToList())
            {
                if (item.password == codigo)
                {
                    usuario = item;
                    autenticado = true;
                }
            }
            if (autenticado)
            {
                sesionActual = new Sesion
                {
                    InicioSesion = DateTime.Now,
                    UsuarioId = 1
                };
                udt.RepositorioSesion.Insert(sesionActual);
                udt.Save();
            }
            return autenticado;
        }

        /// <summary>
        /// Borra el articulo.
        /// </summary>
        /// <param name="item">articulo a borrar</param>
        private void borrarArticulo(Articulo item)
        {
            //throw new NotImplementedException();
        }

        #region Metodos privados de diseño


        /// <summary>
        /// Carga dinamicamente la vista de los articulos en el almacen
        /// </summary>
        private void añadirArticulosAlmacen()
        {
            panelAlmacen.Children.Clear();
            foreach (Articulo item in articulos)
            {

                StackPanel tmpPanel = new StackPanel();
                tmpPanel.Orientation = Orientation.Horizontal;
                tmpPanel.Height = 50;

                //añado imagen
                Image tmpImagen = new Image();
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri("Iconos/Productos/" + item.ArticuloId + ".jpg", UriKind.Relative);
                src.EndInit();
                tmpImagen.Source = src;
                tmpImagen.Stretch = Stretch.Uniform;
                tmpImagen.Width = 50;
                tmpImagen.Height = 50;
                tmpPanel.Children.Add(tmpImagen);
                //nombre
                Label tmpLabelNombre = new Label();
                tmpLabelNombre.Content = item.NombreArticulo;
                tmpLabelNombre.Width = 150;
                tmpPanel.Children.Add(tmpLabelNombre);

                //precio
                Label tmpLabelPrecio = new Label();
                tmpLabelPrecio.Content = item.PrecioArticulo.ToString();
                tmpLabelPrecio.Width = 30;
                tmpPanel.Children.Add(tmpLabelPrecio);

                // stock
                Label tmpLabelStock = new Label();
                tmpLabelStock.Content = item.StockArticulo.ToString();
                tmpLabelStock.Width = 30;
                tmpPanel.Children.Add(tmpLabelStock);

                //boton borrar
                Button tmpButton = new Button();
                tmpButton.Content = "Borrar";
                tmpButton.Click += delegate { borrarArticulo(item); };
                tmpButton.Style = FindResource("botonLogOut") as Style;
                tmpPanel.Children.Add(tmpButton);

               

                this.panelAlmacen.Children.Add(tmpPanel);
            }
        }


        /// <summary>
        /// Carga dinamicamente la vista del panel de caja
        /// </summary>
        private void añadirArticulosCaja()
        {
           panelProductos.Children.Clear();


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
        private void añadirlistaUsuarios()
        {
            panelListaUsuarios.Children.Clear();

            foreach (Usuario item in udt.RepositorioUsuario.Get().ToList())
            {
                
                StackPanel tmpPanel = new StackPanel();
                tmpPanel.Orientation = Orientation.Horizontal;
                tmpPanel.Height = 50;

                // stock
                Label tmpLabelNick = new Label();
                tmpLabelNick.Content = item.NickUsuario;
                tmpLabelNick.Width = 100;
                tmpPanel.Children.Add(tmpLabelNick);

                //nombre
                Label tmpLabelNombre = new Label();
                tmpLabelNombre.Content = item.NombreUsuario;
                tmpLabelNombre.Width = 150;
                tmpPanel.Children.Add(tmpLabelNombre);

                //precio
                Label tmpLabelApellido = new Label();
                tmpLabelApellido.Content = item.ApellidosUsuario;
                tmpLabelApellido.Width = 150;
                tmpPanel.Children.Add(tmpLabelApellido);


                //boton borrar
                //Button tmpButton = new Button();
                //tmpButton.Content = "Borrar";
                //tmpButton.Click += delegate { borrarArticulo(item); };
                //tmpButton.Style = FindResource("botonLogOut") as Style;
                //tmpPanel.Children.Add(tmpButton);
                
                this.panelListaUsuarios.Children.Add(tmpPanel);
            }
        }



        /// <summary>
        /// Actualiza la inferfaz de usuario segun un codigo.
        /// </summary>
        /// <param name="codCambio">The cod cambio.</param>
        private void updateIU(int codCambio)
        {
            autenticationPanel.Visibility = Visibility.Collapsed;
            panelPrincipal.Visibility = Visibility.Visible;
            panelCaja.Visibility = Visibility.Collapsed;
            scrollAlmacen.Visibility = Visibility.Collapsed;
            panelUsuarios.Visibility = Visibility.Collapsed;



            switch (codCambio)
            {
                case COD_ESTADO_INICIAL:
                    autenticationPanel.Visibility = Visibility.Visible;
                    panelPrincipal.Visibility = Visibility.Collapsed;
                    break;
                case COD_AUTENTICADO_OK:
                    break;
                case COD_PANEL_CAJA:
                    autenticationPanel.Visibility = Visibility.Collapsed;
                    panelCaja.Visibility = Visibility.Visible;
                    panelPrincipal.Visibility = Visibility.Visible;

                    añadirArticulosCaja();
                    break;
                case COD_ACTUALIZAR_TICKET_CAJA:
                    panelCaja.Visibility = Visibility.Visible;
                    listaTicket.ItemsSource = tmpTicket.LineasTicket.ToList().Select(i => new {/*i.Articulo.NombreArticulo, */    articulos.Where(j => j.ArticuloId == i.ArticuloId).FirstOrDefault().NombreArticulo, i.cantidad, i.precioArticulo, i.precioLinea });
                    labelPrecioTotal.Content = tmpTicket.precioTicket.ToString();
                    break;
                case COD_PANEL_ALMACEN:
                    scrollAlmacen.Visibility = Visibility.Visible;
                    añadirArticulosAlmacen();
                    break;
                case COD_PANEL_USUARIOS:
                    panelUsuarios.Visibility = Visibility.Visible;
                    añadirlistaUsuarios();
                    break;
                case COD_PANEL_CONFIG:
                    panelConfig.Visibility = Visibility.Visible;
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
            if (autenticado(strCodigo))
            {
                updateIU(COD_AUTENTICADO_OK);

            }
        }

        #endregion


        /// <summary>
        /// Handles the MouseLeftButtonUp event of the Caja control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Caja_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            articulos = udt.RepositorioArticulo.Get().ToList();
            updateIU(COD_PANEL_CAJA);
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

            updateIU(COD_ACTUALIZAR_TICKET_CAJA);
        }


        private void buttonNuevoTicket_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Borrar el ticket actual?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                tmpTicket = new TicketVenta();
                updateIU(COD_ACTUALIZAR_TICKET_CAJA);
            }
        }

        private void buttonconfirmarTicket_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Guardar ticket?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                tmpTicket.SesionId = sesionActual.SesionId;
                udt.RepositorioTicketVenta.Insert(tmpTicket);
                udt.Save();
                MessageBox.Show("Añadido correctamente");
                tmpTicket = new TicketVenta();
                updateIU(COD_ACTUALIZAR_TICKET_CAJA);
            }
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            articulos = udt.RepositorioArticulo.Get().ToList();
            updateIU(COD_PANEL_ALMACEN);

        }

        private void Usuarios_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            updateIU(COD_PANEL_USUARIOS);
        }

        private void Config_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            updateIU(COD_PANEL_CONFIG);
        }
    }
    #endregion
}
