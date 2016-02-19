using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_TPV.Model;



namespace Proyecto_TPV.Repositorios
{
    public class UnidadDeTrabajo:IDisposable
    {
        private Context context = new Context();
        private bool disposed = false;
        
        private RepositorioArticulo repositorioArticulo;
        private RepositorioLineaPedido repositorioLineaPedido;
        private RepositorioLineaTicket repositorioLineaTicket;
        private RepositorioPedido repositorioPedido;
        private RepositorioProveedor repositorioProveedor;
        private RepositorioSesion repositorioSesion;
        private RepositorioTicketVenta repositorioTicketVenta;
        private RepositorioUsuario repositorioUsuario;



        public RepositorioArticulo RepositorioArticulo
        {
            get
            {
                if (this.repositorioArticulo == null)
                {
                    this.repositorioArticulo =
                        new RepositorioArticulo(context);
                }

                return repositorioArticulo;
            }
        }
        
        public RepositorioLineaPedido RepositorioLineaPedido
        {
            get
            {
                if (this.repositorioLineaPedido == null)
                {
                    this.repositorioLineaPedido =
                        new RepositorioLineaPedido(context);
                }

                return repositorioLineaPedido;
            }
        }
        public RepositorioLineaTicket RepositorioLineaTicket
        {
            get
            {
                if (this.repositorioLineaTicket == null)
                {
                    this.repositorioLineaTicket =
                        new RepositorioLineaTicket(context);
                }

                return repositorioLineaTicket;
            }
        }

        public RepositorioPedido RepositorioPedido
        {
            get
            {
                if (this.repositorioPedido == null)
                {
                    this.repositorioPedido =
                        new RepositorioPedido(context);
                }

                return repositorioPedido;
            }
        }

        public RepositorioProveedor RepositorioProveedor
        {
            get
            {
                if (this.repositorioProveedor == null)
                {
                    this.repositorioProveedor =
                        new RepositorioProveedor(context);
                }

                return repositorioProveedor;
            }
        }

        public RepositorioSesion RepositorioSesion
        {
            get
            {
                if (this.repositorioSesion == null)
                {
                    this.repositorioSesion =
                        new RepositorioSesion(context);
                }

                return repositorioSesion;
            }
        }

        public RepositorioTicketVenta RepositorioTicketVenta
        {
            get
            {
                if (this.repositorioTicketVenta == null)
                {
                    this.repositorioTicketVenta =
                        new RepositorioTicketVenta(context);
                }

                return repositorioTicketVenta;
            }
        }


        public RepositorioUsuario RepositorioUsuario
        {
            get
            {
                if (this.repositorioUsuario == null)
                {
                    this.repositorioUsuario =
                        new RepositorioUsuario(context);
                }

                return repositorioUsuario;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
