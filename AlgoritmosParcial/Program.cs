namespace Modelo_de_Practica_Tyla_Junio_2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inicialización de empleados y variables necesarios
            int maxProductos = 23; // Definir un máximo de productos en el inventario

            int precioMinimo = 321; // Definir un precio mínimo para los productos
            int precioMaximo = 2345;

            // Inicialización de objetos necesarios
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            Inventario inventario = new Inventario(maxProductos);
            VentaCliente[] ventaClientes = new VentaCliente[99999999]; ; 
            //Empleados
            Cajero cajero = new Cajero();
            Vendedor vendedor = new Vendedor();
            Repositor repositor = new Repositor();

            menuPrincipal.Funcionando = true;

            do
            {
                menuPrincipal.MostrarMenuPrincipal();

                int menuSeleccionado = Consola.PedirNumeroPositivo(1, 3);

                switch (menuSeleccionado)
                {
                    case (int)MenuTipoEmpleado.Repositor:
                        Console.Clear();
                        MenuRepositor(repositor, inventario, maxProductos, precioMinimo, precioMaximo);
                        break;
                    case (int)MenuTipoEmpleado.Vendedor:
                        Console.Clear();
                        MenuVendedor(vendedor, inventario);
                        break;
                    case (int)MenuTipoEmpleado.Cajero:
                        Console.Clear();
                        MenuCajero(cajero, inventario, ventaClientes);
                        break;
                }

            } while (menuPrincipal.Funcionando);

            Console.WriteLine("Presione cualquier tecla para salir");
            Console.ReadKey();
        }
        public static void MenuRepositor(Repositor repositor, Inventario inventario, 
            int maxProductos, int precioMinimo, int precioMaximo)
        {
            bool funcionandorepo = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al sistema del Repositor" +
                                  "\n¿Qué querés hacer:" +
                                  "\n1 - Agregar productos" +
                                  "\n2 - Quitar productos" +
                                  "\n3 - Volver al menú principal");

                int menurepo = Consola.PedirNumeroPositivo(1, 3);

                switch (menurepo)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Ingrese el ID del producto (1 a " + maxProductos + "):");
                        int idProducto = Consola.PedirNumeroPositivo(1, maxProductos);
                        Console.WriteLine("Ingrese la cantidad de productos a agregar (1 a 999999999):");
                        int cantidad = Consola.PedirNumeroPositivo(1, 9999);
                        Console.WriteLine("Ingrese el precio del producto (entre " + precioMinimo + " y " + precioMaximo + "):");
                        int precio = Consola.PedirNumeroPositivo(precioMinimo, precioMaximo);
                        repositor.AgregarProducto(inventario, idProducto, cantidad, precio);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ingrese el ID del producto (1 a " + maxProductos + "):");
                        int idProducto2 = Consola.PedirNumeroPositivo(1, maxProductos);
                        Console.WriteLine("Ingrese la cantidad de productos a agregar (1 a 999999999):");
                        int cantidad2 = Consola.PedirNumeroPositivo(1, 9999);
                        repositor.QuitarProducto(inventario, idProducto2, cantidad2);
                        Console.ReadKey();
                        break;
                    case 3:
                        funcionandorepo = false;
                        break;
                }
            } while (funcionandorepo);
        }
        static void MenuVendedor(Vendedor vendedor, Inventario inventario)
        {
            bool funcionandovender = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al sistema del Vendedor" +
                                  "\n¿Qué querés hacer hoy:" +
                                  "\n1 - Vender" +
                                  "\n2 - Cotizar" +
                                  "\n3 - Volver al menú principal");

                int menuvender = Consola.PedirNumeroPositivo(1, 3);

                switch (menuvender)
                {
                    case 1:
                        Console.WriteLine("Llamar al método 'vender' del Vendedor");
                        vendedor.Vender(1, inventario); // Ejemplo de uso del método Cotizar
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Llamar al método 'cotizar' del Vendedor");
                        vendedor.Cotizar(1, inventario); // Ejemplo de uso del método Cotizar
                        Console.ReadKey();
                        break;
                    case 3:
                        funcionandovender = false;
                        break;
                }
            } while (funcionandovender);
        }
        static void MenuCajero(Cajero cajero, Inventario inventario, VentaCliente[] ventaClientes)
        {
            bool funcionandocajero = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Menú del Cajero" +
                                  "\n1 - Ver productos a cobrar" +
                                  "\n2 - Cobrar venta" +
                                  "\n3 - Cerrar caja / Ver resumen del día" +
                                  "\n4 - Volver al menú principal");

                int opcion = Consola.PedirNumeroPositivo(1, 4);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Llamar a método para ver productos pendientes de cobro");
                        //cajero.
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Llamar a método para cobrar venta");
                        cajero.Cobrar(null); // Ejemplo de uso del método Cobrar
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Llamar a método para cerrar caja / ver resumen");
                        cajero.CierreDelDia(); // Ejemplo de uso del método Cierre
                        Console.ReadKey();
                        break;
                    case 4:
                        funcionandocajero = false;
                        break;
                }
            } while (funcionandocajero);
        }
    }
    public class MenuPrincipal
    {
        public bool Funcionando { get; set; } = false;
        public void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al sistema de gestión de empleados y productos.");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Ingresar como Repositor");
            Console.WriteLine("2. Ingresar como Vendedor");
            Console.WriteLine("3. Ingresar como Cajero");
        }
    }
    public enum MenuTipoEmpleado
    {
        Repositor = 1,
        Vendedor,
        Cajero
    }
    public static class Consola
    {
        public static int PedirNumeroPositivo(int min, int max)
        {
            int numero = -1;

            do
            {
                Console.Write($"Ingrese un número entre {min} y {max}: ");

                if (!int.TryParse(Console.ReadLine(), out int input) || input < min || input > max)
                {
                    Console.WriteLine("Número inválido.");
                }
                else
                {
                    numero = input;
                }

            } while (numero < min || numero > max);

            return numero;
        }
    }

    // Gestión  Producto
    public class Inventario
    {
        private int MaxProductos { get; set; }
        private RegistroInventario[] registros { get; set; }
        public Inventario(int maxProductos)
        {
            MaxProductos = maxProductos;
            registros = new RegistroInventario[maxProductos];
        }
        public void AgregarProductoStockPrecio(int idProducto, int cantidad, int precio)
        {
            var nuevoRegistro = new RegistroInventario
            {
                Stock = cantidad,
                Precio = precio
            };
            if (registros[idProducto - 1] is null)
            {
                registros[idProducto - 1] = nuevoRegistro;
            }
            else
            {
                var registro = registros[idProducto - 1];
                registro.Stock = registro.Stock + cantidad;
                registros[idProducto - 1] = registro;
            }  
        }
        public void QuitarProductoStock(int idProducto, int cantidad)
        {
            var registro = registros[idProducto - 1];
            if (registro is not null)
            {
                registro.Stock = registro.Stock + cantidad;
                registros[idProducto - 1] = registro;
            }
        }
    }
    public class RegistroInventario
    {
        public int Stock { get; set; }
        public double Precio { get; set; }
    }
    public class Carrito
    {
        private int MaxProductos { get; set; }
        private int ProductosDistintos { get; set; }
        private int[,] ProductoCantidad { get; set; }
    
        public bool Agregar(int productoId, int cantidad)
        {
            bool resp = false;
            for (int i = 0; i < MaxProductos; i++)
            {
                if (ProductoCantidad[i, 0] == 0)
                {
                    ProductoCantidad[i, 0] = productoId;
                    ProductoCantidad[i, 1] = cantidad;
                    resp = true;
                }
            }
            return resp;
        }
        public bool Quitar(int productoId, int cantidad)
        {
            bool resp = false;
            for (int i = 0; i < MaxProductos; i++)
            {
                if (i == productoId)
                {
                    ProductoCantidad[i, 0] = 0;
                    ProductoCantidad[i, 1] = 0;
                    resp = true;
                }
            }
            return resp;
        }
        public int CantidadProductos()
        {
            int cantidad = 0;
            for (int i = 0; i < MaxProductos; i++)
            {
                if (ProductoCantidad[i, 0] != 0)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }
        public int CantidadProductosDistintos()
        {
            int cantidad = 0;
            for (int i = 0; i < MaxProductos; i++)
            {
                if (ProductoCantidad[i, 0] != 0)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }
        public int TotalCarrito()
        {
            int total = 0;
            for (int i = 0; i < MaxProductos; i++)
            {
                if (ProductoCantidad[i, 0] != 0)
                {
                    total += ProductoCantidad[i, 1]; // Asumiendo que la cantidad es el precio por simplicidad
                }
            }
            return total;
        }
    }
    public class VentaCliente
    {
        public Carrito Carrito { get; set; }
        public bool EstaFinalizado { get; set; }
        public int Cobrar()
        {
            return 1;
        }

    }
    public class ResumenVentas
    {
        public int[]? Ventas { get; set; }
        public void PedirResumen() { }
    }
    public class SistemaContable
    {
    }
    public class Empleado// dueño?
    {
        //definición de propiedades comunes para todos los empleados
    }
    public class Repositor : Empleado
    {
        public ValidadorRepositor Validador { get; set; }
        public bool AgregarProducto(Inventario iventario, int idProducto, int cantidad, int precio) 
        {
            //if (!Validador.ValidarProducto())
            //{
            //    Console.WriteLine("Producto invalido.");
            //    return false;
            //}
            //if (!Validador.ValidarCantidad())
            //{
            //    Console.WriteLine("Cantidad invalida.");
            //    return false;
            //}
            //if (!Validador.ValidarPrecio())
            //{
            //    Console.WriteLine("Precio invalido.");
            //    return false;
            //}

            iventario.AgregarProductoStockPrecio(idProducto, cantidad, precio);
            return true;
        }
        public bool QuitarProducto(Inventario iventario, int idProducto, int cantidad)
        {    //if (!Validador.ValidarProducto())
            //{
            //    Console.WriteLine("Producto invalido.");
            //    return false;
            //}
            //if (!Validador.ValidarCantidad())
            //{
            //    Console.WriteLine("Cantidad invalida.");
            //    return false;
            //}
            //if (!Validador.ValidarPrecio())
            //{
            //    Console.WriteLine("Precio invalido.");
            //    return false;
            //}
            iventario.QuitarProductoStock(idProducto, cantidad);
            return true;
        }
    }
    public class Vendedor : Empleado
    {
        public Validador Validador { get; set; }
        public void Vender(int productoId, Inventario? Iventario) { }
        public void Cotizar(int productoId, Inventario? Iventario) { }
    }
    public class Cajero : Empleado
    {
        public ResumenVentas[] ResumenVentas { get; set; }
        public SistemaContable SistemaContable { get; set; }
        public Validador Validador { get; set; }
        public void Cobrar(Carrito carrito) { }
        public void CierreDelDia() { }
    }
    public abstract class Validador
    {
        public abstract bool Validar();
    }
    public class ValidadorRepositor 
    {
        //private Producto Producto { get; set; }
        //private Inventario Inventario { get; set; }

        //public ValidadorRepositor(Producto producto, Inventario inventario)
        //{
        //    Producto = producto;
        //    Inventario = inventario;
        //}

        //métodos de validación específicos para agregar o quitar productos
        public bool ValidarProducto()
        {
            // Lógica para validar el producto
            return true;
        }
        public bool ValidarCantidad()
        {
            // Lógica para validar la cantidad
            return true; 
        }
        public bool ValidarPrecio()
        {
            // Lógica para validar el precio
            return true;
        }
    }

    public abstract class Descuento
    {
        public abstract double CalcularDescuento(double precio, int cantidad);
    }
    #region Diseño clases opcional
    public abstract class Dueño
    {
        public abstract void AgregarStock();
        public abstract void QuitarStock();
    }
    public class Repositor2 : Dueño
    {
        public override void AgregarStock()
        {
            throw new NotImplementedException();
        }

        public override void QuitarStock()
        {
            throw new NotImplementedException();
        }
    }
    public class VendedorS : Repositor2
    {
        public void Vender()
        {
        }
        public void Cotizar()
        {
        }
    }
    public class CajeroS : VendedorS
    {
        public void CobrarAlCliente()
        {
        }
        public void CierreDelDia()
        {
        }
    }
    #endregion
}