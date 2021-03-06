﻿using Proyecto_TPV.Model.DB;
using Proyecto_TPV.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Articulo ArticuloCambiar;


        string strCodigo = "";
        const int COD_AUTENTICADO_OK = 1;
        const int COD_ESTADO_INICIAL = 2;
        const int COD_PANEL_CAJA = 3;
        const int COD_ACTUALIZAR_TICKET_CAJA = 4;
        const int COD_PANEL_ALMACEN = 5;
        const int COD_PANEL_CONFIG = 6;
        const int COD_PANEL_USUARIOS = 7;
        const int COD_NUEVO_PRECIO = 8;
        const int COD_ADD_ARTICULO = 9;
        const int COD_PANEL_ADD_USUARIO = 10;
        const int COD_PANEL_MOD_PASS = 11;
        const int COD_PANEL_PROVEED = 12;
        const int COD_PANEL_PEDIDOS = 13;
        const int COD_PANEL_VENTAS = 14;
        const int COD_PANEL_SESIONES = 15;
        const int COD_NUEVO_PROVEED = 16;
        const int COD_NUEVO_PEDIDO = 17;
        const int COD_DETALLES_PEDIDO = 18;
        const int COD_DETALLES_VENTA = 19;
        const int COD_DETALLES_SESION = 20;
        const int COD_ACTUALIZAR_TICKET_PEDIDO = 22;


        private Pedido detallesPedido;
        private TicketVenta detallesVenta;
        private Proveedor detallesProveedor;
        private Pedido tmpCompra = new Pedido();


        public MainWindow()
        {
            InitializeComponent();
            updateIU(COD_ESTADO_INICIAL);
            Application.Current.MainWindow.Closing += new CancelEventHandler(MainWindow_Closing);
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (sesionActual != null)
                cerrarSesion();
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
                labelNombreUsuario.Content = usuario.NombreUsuario;
                sesionActual = new Sesion
                {
                    InicioSesion = DateTime.Now,
                    UsuarioId = 1
                };
                udt.RepositorioSesion.Insert(sesionActual);
                udt.Save();
            }
            MessageBox.Show("Autenticado incorrecto");
            return autenticado;
        }

        /// <summary>
        /// Carga dinamicamente la vista de los articulos en el almacen
        /// </summary>
        private void añadirArticulosAlmacen()
        {
            panelAlmacen.Children.Clear();

            Button tmpAddUsuario = new Button();
            tmpAddUsuario.Content = "Añadir articulo";
            tmpAddUsuario.Style = FindResource("botonLogOut") as Style;
            tmpAddUsuario.Click += delegate { añadirArticulo_Click(); };


            this.panelAlmacen.Children.Add(tmpAddUsuario);

            foreach (Articulo item in udt.RepositorioArticulo.Get().ToList())
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

                //boton modificar
                Button tmpButtonModificar = new Button();
                tmpButtonModificar.Content = "Modificar";
                tmpButtonModificar.Click += delegate { ButtonModificarArticulo_Click(item); };
                tmpButtonModificar.Style = FindResource("botonLogOut") as Style;
                tmpPanel.Children.Add(tmpButtonModificar);



                this.panelAlmacen.Children.Add(tmpPanel);
            }
        }
        /// <summary>
        /// Carga dinamicamente la vista del panel de caja
        /// </summary>
        private void añadirArticulosCaja()
        {
            panelProductos.Children.Clear();


            foreach (Articulo item in udt.RepositorioArticulo.Get().ToList())
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
        /// <summary>
        /// carga dinamicamente la lista de usuarios.
        /// </summary>
        private void añadirListaUsuarios()
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
        private void añadirListaProveed()
        {
            panelProveed.Children.Clear();

            Button tmpAddProvedd = new Button();
            tmpAddProvedd.Content = "Añadir proveedor";
            tmpAddProvedd.Style = FindResource("botonLogOut") as Style;
            tmpAddProvedd.Click += delegate { addProveed_Click(); };
            this.panelProveed.Children.Add(tmpAddProvedd);


            foreach (Proveedor item in udt.RepositorioProveedor.Get().ToList())
            {

                StackPanel tmpPanel = new StackPanel();
                tmpPanel.Orientation = Orientation.Horizontal;
                tmpPanel.Height = 50;

                // nombre
                Label tmpLabelNombre = new Label();
                tmpLabelNombre.Content = item.NombreProveedor;
                tmpLabelNombre.Width = 100;
                tmpPanel.Children.Add(tmpLabelNombre);

                //relefono
                Label tmpLabelTelefono = new Label();
                tmpLabelTelefono.Content = item.TelefonoProveedor;
                tmpLabelTelefono.Width = 150;
                tmpPanel.Children.Add(tmpLabelTelefono);

                //email
                Label tmpLabelEmail = new Label();
                tmpLabelEmail.Content = item.EmailProveedor;
                tmpLabelEmail.Width = 150;
                tmpPanel.Children.Add(tmpLabelEmail);

                //boton detalles
                Button tmpButtonDetalles = new Button();
                tmpButtonDetalles.Content = "Hacer pedido";
                tmpButtonDetalles.Click += delegate { ButtonNuevoPedidoProveedor_Click(item); };
                tmpButtonDetalles.Style = FindResource("botonLogOut") as Style;
                tmpPanel.Children.Add(tmpButtonDetalles);



                this.panelProveed.Children.Add(tmpPanel);
            }
        }
        private void añadirListaPedidos()
        {
            panelPedidos.Children.Clear();

            Button tmpAddProvedd = new Button();
            tmpAddProvedd.Content = "Nuevo pedido";
            tmpAddProvedd.Style = FindResource("botonLogOut") as Style;
            tmpAddProvedd.Click += delegate { nuevoPedido_Click(); };
            this.panelPedidos.Children.Add(tmpAddProvedd);


            foreach (Pedido item in udt.RepositorioPedido.Get().ToList())
            {

                StackPanel tmpPanel = new StackPanel();
                tmpPanel.Orientation = Orientation.Horizontal;
                tmpPanel.Height = 50;

                // fecha
                Label tmpLabelNombre = new Label();
                tmpLabelNombre.Content = item.FechaPedido.ToString();
                tmpLabelNombre.Width = 100;
                tmpPanel.Children.Add(tmpLabelNombre);

                //proveedor
                Label tmpLabelTelefono = new Label();
                tmpLabelTelefono.Content = item.Proveedor.NombreProveedor;
                tmpLabelTelefono.Width = 150;
                tmpPanel.Children.Add(tmpLabelTelefono);



                //boton detalles
                Button tmpButtonDetalles = new Button();
                tmpButtonDetalles.Content = "Detalles";
                tmpButtonDetalles.Click += delegate { ButtonDetallesPedido_Click(item); };
                tmpButtonDetalles.Style = FindResource("botonLogOut") as Style;
                tmpPanel.Children.Add(tmpButtonDetalles);


                this.panelPedidos.Children.Add(tmpPanel);
            }
        }
        private void verDetallesPedidos()
        {
            panelDetallesPedido.Children.Clear();

            foreach (LineaPedido item in udt.RepositorioLineaPedido.Get().ToList())
            {
                if (item.PedidoId == detallesPedido.PedidoId)
                {
                    StackPanel tmpPanel = new StackPanel();
                    tmpPanel.Orientation = Orientation.Horizontal;
                    tmpPanel.Height = 50;

                    Image tmpImagen = new Image();
                    BitmapImage src = new BitmapImage();
                    src.BeginInit();
                    src.UriSource = new Uri("Iconos/Productos/" + item.ArticuloId + ".jpg", UriKind.Relative);
                    src.EndInit();
                    tmpImagen.Source = src;
                    tmpImagen.Stretch = Stretch.Uniform;
                    tmpImagen.Width = 40;
                    tmpPanel.Children.Add(tmpImagen);

                    // articulo
                    Label tmpLabelArticulo = new Label();
                    tmpLabelArticulo.Content = item.Articulo.NombreArticulo;
                    tmpLabelArticulo.Width = 100;
                    tmpPanel.Children.Add(tmpLabelArticulo);

                    // cantidad
                    Label tmpLabelCantidad = new Label();
                    tmpLabelCantidad.Content = item.cantidad.ToString();
                    tmpLabelCantidad.Width = 100;
                    tmpPanel.Children.Add(tmpLabelCantidad);

                    //precio
                    Label tmpLabelPrecio = new Label();
                    tmpLabelPrecio.Content = item.precioArticulo.ToString();
                    tmpLabelPrecio.Width = 150;
                    tmpPanel.Children.Add(tmpLabelPrecio);


                    this.panelDetallesPedido.Children.Add(tmpPanel);
                }
            }
        }
        private void añadirListaVentas()
        {
            panelVentas.Children.Clear();

            foreach (TicketVenta item in udt.RepositorioTicketVenta.Get().ToList())
            {

                StackPanel tmpPanel = new StackPanel();
                tmpPanel.Orientation = Orientation.Horizontal;
                tmpPanel.Height = 50;

                // ticket
                Label tmpLabelNombre = new Label();
                tmpLabelNombre.Content = "IdTicket: " + item.TicketVentaId;
                tmpLabelNombre.Width = 100;
                tmpPanel.Children.Add(tmpLabelNombre);

                // sesion
                Label tmpLabelSesion = new Label();
                tmpLabelSesion.Content = "IdSesion: " + item.SesionId;
                tmpLabelSesion.Width = 100;
                tmpPanel.Children.Add(tmpLabelSesion);

                // fecha
                Label tmpFecha = new Label();
                tmpFecha.Content = item.FechaTicketVenta.ToString();
                tmpFecha.Width = 150;
                tmpPanel.Children.Add(tmpFecha);


                //boton detalles
                Button tmpButtonDetalles = new Button();
                tmpButtonDetalles.Content = "Detalles";
                tmpButtonDetalles.Click += delegate { ButtonDetallesVenta_Click(item); };
                tmpButtonDetalles.Style = FindResource("botonLogOut") as Style;
                tmpPanel.Children.Add(tmpButtonDetalles);

                this.panelVentas.Children.Add(tmpPanel);

            }
        }
        private void añadirListaSesiones()
        {
            panelSesiones.Children.Clear();

            foreach (Sesion item in udt.RepositorioSesion.Get().ToList())
            {

                StackPanel tmpPanel = new StackPanel();
                tmpPanel.Orientation = Orientation.Horizontal;
                tmpPanel.Height = 50;

                // usuario
                Label tmpLabelUsuario = new Label();
                tmpLabelUsuario.Content = item.Usuario.NickUsuario;
                tmpLabelUsuario.Width = 100;
                tmpPanel.Children.Add(tmpLabelUsuario);

                // inicio sesion
                Label tmpLabelInicioSesion = new Label();
                tmpLabelInicioSesion.Content = item.InicioSesion;
                tmpLabelInicioSesion.Width = 100;
                tmpPanel.Children.Add(tmpLabelInicioSesion);

                // inicio sesion
                Label tmpLabelFinSesion = new Label();
                tmpLabelFinSesion.Content = item.FinSesion;
                tmpLabelFinSesion.Width = 100;
                tmpPanel.Children.Add(tmpLabelFinSesion);


                //boton detalles
                Button tmpButtonDetalles = new Button();
                tmpButtonDetalles.Content = "Detalles";
                //   tmpButtonDetalles.Click += delegate { ButtonDetallesSesion_Click(item); };
                tmpButtonDetalles.Style = FindResource("botonLogOut") as Style;
                tmpPanel.Children.Add(tmpButtonDetalles);

                this.panelSesiones.Children.Add(tmpPanel);
            }
        }
        private void verDetallesVenta()
        {
            panelDetallesVenta.Children.Clear();

            foreach (LineaTicket item in udt.RepositorioLineaTicket.Get().ToList())
            {
                if (item.TicketVentaId == detallesVenta.TicketVentaId)
                {




                    StackPanel tmpPanel = new StackPanel();
                    tmpPanel.Orientation = Orientation.Horizontal;
                    tmpPanel.Height = 50;



                    Image tmpImagen = new Image();
                    BitmapImage src = new BitmapImage();
                    src.BeginInit();
                    src.UriSource = new Uri("Iconos/Productos/" + item.ArticuloId + ".jpg", UriKind.Relative);
                    src.EndInit();
                    tmpImagen.Source = src;
                    tmpImagen.Stretch = Stretch.Uniform;
                    tmpImagen.Width = 40;
                    tmpPanel.Children.Add(tmpImagen);

                    // articulo
                    Label tmpLabelArticulo = new Label();
                    tmpLabelArticulo.Content = item.Articulo.NombreArticulo;
                    tmpLabelArticulo.Width = 100;
                    tmpPanel.Children.Add(tmpLabelArticulo);

                    // cantidad
                    Label tmpLabelCantidad = new Label();
                    tmpLabelCantidad.Content = item.cantidad.ToString();
                    tmpLabelCantidad.Width = 100;
                    tmpPanel.Children.Add(tmpLabelCantidad);

                    //precio
                    Label tmpLabelPrecio = new Label();
                    tmpLabelPrecio.Content = item.precioArticulo.ToString();
                    tmpLabelPrecio.Width = 150;
                    tmpPanel.Children.Add(tmpLabelPrecio);


                    this.panelDetallesVenta.Children.Add(tmpPanel);
                }

            }
        }
        private void añadirArticulosAPedido()
        {
            panelProductosPedido.Children.Clear();


            foreach (Articulo item in udt.RepositorioArticulo.Get().ToList())
            {
                Image tmpImagen = new Image();
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri("Iconos/Productos/" + item.ArticuloId + ".jpg", UriKind.Relative);
                src.EndInit();
                tmpImagen.Source = src;
                tmpImagen.Stretch = Stretch.Uniform;
                tmpImagen.Width = 100;
                tmpImagen.MouseLeftButtonUp += delegate { pulsarArticuloPedido(item); };
                this.panelProductosPedido.Children.Add(tmpImagen);
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
            panelNuevoPrecio.Visibility = Visibility.Collapsed;
            panelAddArticulo.Visibility = Visibility.Collapsed;
            panelAddUsuario.Visibility = Visibility.Collapsed;
            panelUpdatePass.Visibility = Visibility.Collapsed;
            panelProveed.Visibility = Visibility.Collapsed;
            panelConfig.Visibility = Visibility.Collapsed;
            panelNuevoProveed.Visibility = Visibility.Collapsed;
            panelPedidos.Visibility = Visibility.Collapsed;
            panelSesiones.Visibility = Visibility.Collapsed;
            panelVentas.Visibility = Visibility.Collapsed;
            panelDetallesPedido.Visibility = Visibility.Collapsed;
            panelDetallesVenta.Visibility = Visibility.Collapsed;
            panelNuevoPedido.Visibility = Visibility.Collapsed;
            scrollProveed.Visibility = Visibility.Collapsed;
            scrollPedidos.Visibility = Visibility.Collapsed;
            scrollVentas.Visibility = Visibility.Collapsed;
            scrollDetallesPedido.Visibility = Visibility.Collapsed;
            scrollDetallesVenta.Visibility = Visibility.Collapsed;
            scrollSesiones.Visibility = Visibility.Collapsed;

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
                    panelAlmacen.Visibility = Visibility.Visible;
                    añadirArticulosAlmacen();
                    break;
                case COD_PANEL_USUARIOS:
                    panelUsuarios.Visibility = Visibility.Visible;
                    añadirListaUsuarios();
                    break;
                case COD_PANEL_CONFIG:
                    panelConfig.Visibility = Visibility.Visible;
                    break;
                case COD_NUEVO_PRECIO:
                    panelNuevoPrecio.Visibility = Visibility.Visible;
                    scrollAlmacen.Visibility = Visibility.Visible;
                    panelAlmacen.Visibility = Visibility.Visible;
                    break;
                case COD_ADD_ARTICULO:
                    panelAddArticulo.Visibility = Visibility.Visible;
                    scrollAlmacen.Visibility = Visibility.Visible;
                    panelAlmacen.Visibility = Visibility.Visible;
                    break;
                case COD_PANEL_ADD_USUARIO:
                    panelAddUsuario.Visibility = Visibility.Visible;
                    break;
                case COD_PANEL_MOD_PASS:
                    panelUpdatePass.Visibility = Visibility.Visible;
                    break;
                case COD_PANEL_PROVEED:
                    scrollProveed.Visibility = Visibility.Visible;
                    panelProveed.Visibility = Visibility.Visible;
                    panelConfig.Visibility = Visibility.Visible;
                    añadirListaProveed();
                    break;
                case COD_PANEL_PEDIDOS:
                    panelPedidos.Visibility = Visibility.Visible;
                    scrollPedidos.Visibility = Visibility.Visible;
                    panelConfig.Visibility = Visibility.Visible;
                    añadirListaPedidos();
                    break;
                case COD_PANEL_VENTAS:
                    panelVentas.Visibility = Visibility.Visible;
                    scrollVentas.Visibility = Visibility.Visible;
                    panelConfig.Visibility = Visibility.Visible;
                    añadirListaVentas();
                    break;
                case COD_PANEL_SESIONES:
                    panelSesiones.Visibility = Visibility.Visible;
                    scrollSesiones.Visibility = Visibility.Visible;
                    panelConfig.Visibility = Visibility.Visible;
                    añadirListaSesiones();
                    break;
                case COD_NUEVO_PROVEED:
                    panelNuevoProveed.Visibility = Visibility.Visible;
                    panelConfig.Visibility = Visibility.Visible;
                    break;
                case COD_DETALLES_PEDIDO:
                    panelDetallesPedido.Visibility = Visibility.Visible;
                    scrollDetallesPedido.Visibility = Visibility.Visible;
                    panelConfig.Visibility = Visibility.Visible;
                    verDetallesPedidos();
                    break;
                case COD_DETALLES_VENTA:
                    panelDetallesVenta.Visibility = Visibility.Visible;
                    scrollDetallesVenta.Visibility = Visibility.Visible;
                    panelConfig.Visibility = Visibility.Visible;
                    verDetallesVenta();
                    break;
                case COD_NUEVO_PEDIDO:
                    panelNuevoPedido.Visibility = Visibility.Visible;
                    panelConfig.Visibility = Visibility.Visible;
                    añadirArticulosAPedido();
                    break;
                case COD_ACTUALIZAR_TICKET_PEDIDO:
                    panelNuevoPedido.Visibility = Visibility.Visible;
                    panelConfig.Visibility = Visibility.Visible;
                    listaPedido.ItemsSource = tmpCompra.LineasPedido.ToList().Select(i => new {/*i.Articulo.NombreArticulo, */    articulos.Where(j => j.ArticuloId == i.ArticuloId).FirstOrDefault().NombreArticulo, i.cantidad });
                    labelPrecioTotalPedido.Content = tmpCompra.precioTicket.ToString();
                    break;
                default:
                    MessageBox.Show("Codigo de actualizacion desconocido: " + codCambio.ToString());
                    break;
            }
        }








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

        private void pulsarArticuloPedido(Articulo item)
        {

            if (tmpCompra.LineasPedido.Where(i => i.ArticuloId == item.ArticuloId).FirstOrDefault() == null)
            {
                LineaPedido tmpLineaPedido = new LineaPedido
                {
                    ArticuloId = item.ArticuloId,
                    cantidad = 1,
                    precioArticulo = item.PrecioArticulo
                };
                tmpCompra.LineasPedido.Add(tmpLineaPedido);
            }
            else
            {
                tmpCompra.LineasPedido.Where(i => i.ArticuloId == item.ArticuloId).FirstOrDefault().cantidad++;
            }

            updateIU(COD_ACTUALIZAR_TICKET_PEDIDO);
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
                tmpTicket.FechaTicketVenta = DateTime.Now;
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

        private void Proveed_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            updateIU(COD_PANEL_PROVEED);
        }

        private void Pedidos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            updateIU(COD_PANEL_PEDIDOS);
        }

        private void Ventas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            updateIU(COD_PANEL_VENTAS);
        }

        private void Sesiones_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            updateIU(COD_PANEL_SESIONES);
        }



        private void añadirArticulo_Click()
        {
            updateIU(COD_ADD_ARTICULO);

        }




        private void ButtonModificarArticulo_Click(Articulo item)
        {
            updateIU(COD_NUEVO_PRECIO);
            ArticuloCambiar = item;
        }

        private void buttonAceptarNuevoPrecio_Click(object sender, RoutedEventArgs e)
        {
            double nuevoPrecio = ArticuloCambiar.PrecioArticulo;
            try
            {
                nuevoPrecio = Convert.ToDouble(textBoxNuevoPrecio.Text);
            }
            catch
            {
                MessageBox.Show("El precio no es valido");
            }
            ArticuloCambiar.PrecioArticulo = nuevoPrecio;
            udt.RepositorioArticulo.Update(ArticuloCambiar.ArticuloId, ArticuloCambiar);
            udt.Save();
            updateIU(COD_PANEL_ALMACEN);
        }

        private void buttonNuevoArticulo_Click(object sender, RoutedEventArgs e)
        {
            Articulo tmp = new Articulo();
            tmp.NombreArticulo = textBoxNombreArticulo.Text;
            try
            {
                tmp.PrecioArticulo = Convert.ToDouble(textBoxPrecioArticulo.Text);
            }
            catch
            {
                MessageBox.Show("Precio incorrecto");
            }

            udt.RepositorioArticulo.Insert(tmp);
            udt.Save();
            articulos = udt.RepositorioArticulo.Get().ToList();
            updateIU(COD_PANEL_ALMACEN);
        }

        private void crearUsuario_Click(object sender, RoutedEventArgs e)
        {
            updateIU(COD_PANEL_ADD_USUARIO);
        }

        private void buttonNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int numContraseña = Convert.ToInt32(textBoxPassUsuario.Password);
                if (numContraseña < 1000 || numContraseña >= 10000)
                {
                    MessageBox.Show("Contraseña incorrecta, deben ser solo 4 numeros");
                }

                else
                {

                    Usuario tmpUsuario = new Usuario
                    {
                        NombreUsuario = textBoxNombreUsuario.Text,
                        ApellidosUsuario = textBoxApellidosUsuario.Text,
                        NickUsuario = textBoxNickUsuario.Text,
                        password = textBoxPassUsuario.Password
                    };
                    udt.RepositorioUsuario.Insert(tmpUsuario);
                    udt.Save();
                    updateIU(COD_PANEL_USUARIOS);

                }
            }
            catch
            {
                MessageBox.Show("Contraseña incorrecta, deben ser solo 4 numeros");
            }
        }

        private void cambiarContraseña_Click(object sender, RoutedEventArgs e)
        {
            updateIU(COD_PANEL_MOD_PASS);
        }

        private void buttonNuevaPass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numContraseña = Convert.ToInt32(textBoxNuevaPass.Password);
                if (numContraseña < 1000 || numContraseña >= 10000)
                {
                    MessageBox.Show("Contraseña incorrecta, deben ser solo 4 numeros");
                }
                else
                {
                    this.usuario.password = textBoxNuevaPass.Password;
                    udt.RepositorioUsuario.Update(this.usuario.UsuarioId, this.usuario);
                    udt.Save();
                    updateIU(COD_PANEL_USUARIOS);
                }

            }
            catch
            {
                MessageBox.Show("Contraseña incorrecta, deben ser solo 4 numeros");
            }
        }
        private void addProveed_Click()
        {
            updateIU(COD_NUEVO_PROVEED);
        }

        private void buttonNuevoProveed_Click(object sender, RoutedEventArgs e)
        {
            bool telefono = false, email = false;
            // pruebo telefono
            try
            {
                int numTelefono = Convert.ToInt32(textBoxTelefonoProveed.Text);
                if (numTelefono >= 100000000 && numTelefono < 1000000000)
                {
                    telefono = true;
                }
                else
                {
                    MessageBox.Show("Telefono incorrecto");
                }
            }
            catch
            {
                MessageBox.Show("Telefono incorrecto");
            }

            ////email
            //string[] strEmail = textBoxEmailProov.Text.Split('@');
            //if (strEmail.Length > 1)
            //{
            //    email = true;
            //}
            if (RegexUtilities.IsValidEmail(textBoxEmailProov.Text))
            {
                email = true;
            }
            else
            {
                MessageBox.Show("Email incorrecto");
            }


            if (telefono && email)
            {


                Proveedor tmpProveedor = new Proveedor()
                {
                    NombreProveedor = textBoxNombreProveed.Text,
                    TelefonoProveedor = textBoxTelefonoProveed.Text,
                    EmailProveedor = textBoxEmailProov.Text
                };

                udt.RepositorioProveedor.Insert(tmpProveedor);
                udt.Save();
                updateIU(COD_PANEL_PROVEED);
            }

        }

        private void ButtonDetallesPedido_Click(Pedido item)
        {
            detallesPedido = item;
            updateIU(COD_DETALLES_PEDIDO);
        }

        private void nuevoPedido_Click()
        {
            updateIU(COD_PANEL_PROVEED);
        }
        private void ButtonDetallesVenta_Click(TicketVenta item)
        {
            detallesVenta = item;
            updateIU(COD_DETALLES_VENTA);
        }

        private void ButtonNuevoPedidoProveedor_Click(Proveedor item)
        {
            articulos = udt.RepositorioArticulo.Get().ToList();
            updateIU(COD_NUEVO_PEDIDO);
            detallesProveedor = item;
        }

        private void buttonconfirmarPedido_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Realizar pedido?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                tmpCompra.FechaPedido = DateTime.Now;
                tmpCompra.ProveedorId = detallesProveedor.ProveedorId;
                udt.RepositorioPedido.Insert(tmpCompra);
                udt.Save();
                MessageBox.Show("Añadido correctamente");
                tmpCompra = new Pedido();
                updateIU(COD_PANEL_PEDIDOS);
            }
        }

        private void buttonNuevoPedidoCompra_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Borrar el pedido actual?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                tmpCompra = new Pedido();
                updateIU(COD_ACTUALIZAR_TICKET_PEDIDO);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //log out
            cerrarSesion();

        }

        private void cerrarSesion()
        {

            sesionActual.FinSesion = DateTime.Now;
            udt.RepositorioSesion.Update(sesionActual);
            udt.Save();

            strCodigo = "";
            textBoxCodigo.Text = "";
            updateIU(COD_ESTADO_INICIAL);
        }
    }
    #endregion
}
