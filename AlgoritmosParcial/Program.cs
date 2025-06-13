namespace Modelo_de_Practica_Tyla_Junio_2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inicialización de empleados y variables necesarios
            int maxProductos = 23; // Definir un máximo de productos en el inventario
            int maxProductosCarrito = 33;
            int maxProductosDistintos = 11;
            //Empleados
            Cajero cajero = new Cajero();
            Vendedor vendedor = new Vendedor();
            Repositor repositor = new Repositor();
            Inventario inventario = new Inventario(maxProductos);

            bool funcionando = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al sistema" +
                                  "\n¿Qué querés hacer hoy:" +
                                  "\n1 - Ingresar como Repositor" +
                                  "\n2 - Ingresar como Vendedor" +
                                  "\n3 - Ingresar como Cajero");

                int menuSeleccionado = Consola.PedirNumeroPositivo(1, 3);

                switch (menuSeleccionado)
                {
                    case (int)MenuTipoEmpleado.Repositor:
                        Console.Clear();
                        MenuRepositor(repositor, inventario);
                        break;
                    case (int)MenuTipoEmpleado.Vendedor:
                        Console.Clear();
                        break;
                    case (int)MenuTipoEmpleado.Cajero:
                        Console.Clear();
                        break;
                }

            } while (funcionando);

            Console.WriteLine("Presione cualquier tecla para salir");
            Console.ReadKey();
        }

        public static void MenuRepositor(Repositor repositor, Inventario inventario)
        {
            bool funcionandorepo = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al sistema del Repositor" +
                                  "\n¿Qué querés hacer hoy:" +
                                  "\n1 - Agregar" +
                                  "\n2 - Quitar" +
                                  "\n3 - Volver al menú principal");

                int menurepo = Consola.PedirNumeroPositivo(1, 3);

                switch (menurepo)
                {
                    case 1:
                        Console.WriteLine("Llamar al método 'agregar' del Repositor");
                        int cantidad = Consola.PedirNumeroPositivo(1, 999999999);
                        repositor.Agregar(inventario, cantidad);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Llamar al método 'quitar' del Repositor");
                        int cantidad2 = Consola.PedirNumeroPositivo(1, 999999999);
                        repositor.Quitar(inventario, cantidad2);
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

        static void MenuCajero(Cajero cajero, Inventario inventario, Carrito carrito)
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
                        cajero.Cobrar(carrito); // Ejemplo de uso del método Cobrar
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
        private Producto[] productos { get; set; }
        private RegistroInventario[] registros { get; set; }
        public Inventario(int maxProductos)
        {
            MaxProductos = maxProductos;
        }
        public void AgregarProducto(Producto producto, RegistroInventario registro)
        {
          
        }
    }
    public class RegistroInventario
    {
        public int ProductoId { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
    }
    public class Producto
    {
        private int Id { get; }
        private string Nombre { get; set; }

        public Producto(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
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
    }
    public class Venta
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
        public Validador Validador { get; set; }
        public void Agregar(Inventario? Iventario, int cantidad) 
        {
            Console.WriteLine($"Agregando {cantidad}");
        }
        public void Quitar(Inventario? Iventario, int cantidad) { }
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
        public bool ValidarAlgo()
        {
            // Implementación de validación
            return true;
        }
    }
}