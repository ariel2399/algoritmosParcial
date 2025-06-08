namespace Modelo_de_Practica_Tyla_Junio_2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //consola
            Consola consola = new Consola();
            //Empleados
            Cajero cajero = new Cajero();
            Vendedor vendedor = new Vendedor();
            Repositor repositor = new Repositor();
            Inventario inventario = new Inventario();

            bool funcionando = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al sistema" +
                                  "\n¿Qué querés hacer hoy:" +
                                  "\n1 - Ingresar como Repositor" +
                                  "\n2 - Ingresar como Vendedor" +
                                  "\n3 - Ingresar como Cajero" +
                                  "\n4 - Salir");

                int menu = consola.PedirNumeroPositivo(1, 4);

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Acá debería mostrar el menú del repositor");
                        MenuRepositor(repositor, inventario, consola);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Acá debería mostrar el menú del vendedor");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Acá debería mostrar el menú del cajero");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Saliendo del sistema");
                        funcionando = false;
                        Console.ReadKey();
                        break;
                }

            } while (funcionando);

            Console.WriteLine("Presione cualquier tecla para salir");
            Console.ReadKey();
        }

        public static void MenuRepositor(Repositor repositor, Inventario inventario, Consola consola)
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

                int menurepo = consola.PedirNumeroPositivo(1, 3);

                switch (menurepo)
                {
                    case 1:
                        Console.WriteLine("Llamar al método 'agregar' del Repositor");
                        int cantidad = consola.PedirNumeroPositivo(1, 100); // Ejemplo de cantidad a agregar
                        repositor.Agregar(inventario, cantidad);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Llamar al método 'quitar' del Repositor");
                        Console.ReadKey();
                        break;
                    case 3:
                        funcionandorepo = false;
                        break;
                }
            } while (funcionandorepo);
        }

        static void MenuVendedor(Vendedor vendedor, Inventario inventario, Consola consola)
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

                int menuvender = consola.PedirNumeroPositivo(1, 3);

                switch (menuvender)
                {
                    case 1:
                        Console.WriteLine("Llamar al método 'vender' del Vendedor");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Llamar al método 'cotizar' del Vendedor");
                        Console.ReadKey();
                        break;
                    case 3:
                        funcionandovender = false;
                        break;
                }
            } while (funcionandovender);
        }

        static void MenuCajero(Cajero cajero, Inventario inventario, Consola consola)
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

                int opcion = consola.PedirNumeroPositivo(1, 4);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Llamar a método para ver productos pendientes de cobro");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Llamar a método para cobrar venta");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Llamar a método para cerrar caja / ver resumen");
                        Console.ReadKey();
                        break;
                    case 4:
                        funcionandocajero = false;
                        break;
                }
            } while (funcionandocajero);
        }
    }

    public class Consola
    {
        public int PedirNumeroPositivo(int min, int max)
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
        public RegistroInventario[] registros { get; set; }
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
        private int[] Productos { get; set; }
        public bool Agregar(int productoId, int cantidad)
        {
            return true;
        }
        public bool Quitar(int productoId, int cantidad)
        {
            return true;
        }
    }
    public class Venta
    {
        public Carrito Carrito { get; set; }
        public bool EstaCobrado { get; set; }
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

    public class Empleado
    {
        public int NroLegajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido
        {
            get;
        }

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
        public void Cierre() { }
        public void Resumen() { }
        public void ListaSabana() { }
        public void CierreSistema() { }
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