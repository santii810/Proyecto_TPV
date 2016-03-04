namespace Proyecto_TPV.Migrations
{
    using Model.DB;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Proyecto_TPV.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Proyecto_TPV.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Usuario usu = new Usuario
            {
                NombreUsuario = "Administrador",
                NickUsuario = "Admin",
                password = "1234",
                ApellidosUsuario = ""
            };
            context.Usuarios.Add(usu);

            context.Articulos.AddOrUpdate(
                new Articulo
                {
                    NombreArticulo = "Coca-Cola",
                    PrecioArticulo = 1.8,
                    StockArticulo = 0
                }
                );

            context.Articulos.AddOrUpdate(
    new Articulo
    {
        NombreArticulo = "Coca-Cola Zero",
        PrecioArticulo = 1.8,
        StockArticulo = 0
    }
    );
            context.Articulos.AddOrUpdate(
    new Articulo
    {
        NombreArticulo = "Coca-Cola Ligth",
        PrecioArticulo = 1.8,
        StockArticulo = 0
    }
    );
            context.Articulos.AddOrUpdate(
    new Articulo
    {
        NombreArticulo = "Kas Naranja",
        PrecioArticulo = 1.8,
        StockArticulo = 0
    }
    );
            context.Articulos.AddOrUpdate(
    new Articulo
    {
        NombreArticulo = "Kas Limon",
        PrecioArticulo = 1.8,
        StockArticulo = 0

    });
            context.Articulos.AddOrUpdate(
new Articulo
{
NombreArticulo = "Schweppes",
PrecioArticulo = 1.8,
StockArticulo = 0

});
            context.Articulos.AddOrUpdate(
new Articulo
{
NombreArticulo = "Estrella Galicia",
PrecioArticulo = 2,
StockArticulo = 0

});
            context.Articulos.AddOrUpdate(
new Articulo
{
NombreArticulo = "Estrella 1906",
PrecioArticulo = 2.2,
StockArticulo = 0

});
            context.Articulos.AddOrUpdate(
new Articulo
{
NombreArticulo = "Agua",
PrecioArticulo = 1.2,
StockArticulo = 0

});
            context.Articulos.AddOrUpdate(
new Articulo
{
NombreArticulo = "Cafe",
PrecioArticulo = 1.2,
StockArticulo = 0

});



            context.SaveChanges();


        }
    }
}
