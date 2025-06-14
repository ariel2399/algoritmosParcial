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
            DatosVenta datosVenta = new DatosVenta();
            bool funcionando = false;
            Inventario inventario = new Inventario(maxProductos);
            //carritos en venta que estan en cola para cobrarse.
            Carrito[] carritos = new Carrito[99999999]; ; 
            //Empleados
            Cajero cajero = new Cajero();
            Vendedor vendedor = new Vendedor();
            Repositor repositor = new Repositor();

            funcionando = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al sistema de gestión de empleados y productos.");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Ingresar como Repositor");
                Console.WriteLine("2. Ingresar como Vendedor");
                Console.WriteLine("3. Ingresar como Cajero");

                int menuSeleccionado = Herramienta.PedirNumeroPositivo(1, 3);

                switch (menuSeleccionado)
                {
                    case 1:
                        Console.Clear();
                        MenuRepositor(repositor, inventario, maxProductos, precioMinimo, precioMaximo);
                        break;
                    case 2:
                        Console.Clear();
                        MenuVendedor(vendedor, carritos, inventario);
                        break;
                    case 3:
                        Console.Clear();
                        MenuCajero(cajero, inventario, carritos, ref funcionando);
                        break;
                }

            } while (funcionando);

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

                int menurepo = Herramienta.PedirNumeroPositivo(1, 3);

                switch (menurepo)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Ingrese el ID del producto (1 a " + maxProductos + "):");
                        int idProducto = Herramienta.PedirNumeroPositivo(1, maxProductos);
                        Console.WriteLine("Ingrese la cantidad de productos a agregar (1 a 999999999):");
                        int cantidad = Herramienta.PedirNumeroPositivo(1, 9999);
                        Console.WriteLine("Ingrese el precio del producto (entre " + precioMinimo + " y " + precioMaximo + "):");
                        int precio = Herramienta.PedirNumeroPositivo(precioMinimo, precioMaximo);
                        repositor.AgregarProducto(inventario, idProducto, cantidad, precio);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ingrese el ID del producto (1 a " + maxProductos + "):");
                        int idProducto2 = Herramienta.PedirNumeroPositivo(1, maxProductos);
                        Console.WriteLine("Ingrese la cantidad de productos a agregar (1 a 999999999):");
                        int cantidad2 = Herramienta.PedirNumeroPositivo(1, 9999);
                        repositor.QuitarProducto(inventario, idProducto2, cantidad2);
                        Console.ReadKey();
                        break;
                    case 3:
                        funcionandorepo = false;
                        break;
                }
            } while (funcionandorepo);
        }
        static void MenuVendedor(Vendedor vendedor, Carrito[] ventaClientes, Inventario inventario)
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

                int menuvender = Herramienta.PedirNumeroPositivo(1, 3);

                switch (menuvender)
                {
                    case 1:
                        Console.WriteLine("Ingrese el ID del producto )");
                        int idProducto = Herramienta.PedirNumeroPositivo(1, 100);
                        vendedor.Vender(idProducto,ventaClientes, inventario);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Llamar al método 'cotizar' del Vendedor");
                        vendedor.RegistrarPrecio(1, inventario, 2); // Ejemplo de uso del método Cotizar
                        Console.ReadKey();
                        break;
                    case 3:
                        funcionandovender = false;
                        break;
                }
            } while (funcionandovender);
        }
        static void MenuCajero(Cajero cajero, Inventario inventario, Carrito[] carritos, ref bool funcionandoPrincipal)
        {
            bool funcionandocajero = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Menú del Cajero" +                
                                  "\n1 - Cobrar venta" +
                                  "\n2 - Cerrar caja / Ver resumen del día" +
                                  "\n4 - Volver al menú principal");

                int opcion = Herramienta.PedirNumeroPositivo(1, 4);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Vamos a cobrar los carritos segun el orden de llegada. Empezamos con el primero que este sin cobrar.");
                        cajero.Cobrar(carritos, inventario); 
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Llamar a método para cerrar caja / ver resumen");
                        cajero.CierreDelDia(carritos,ref funcionandoPrincipal); // Ejemplo de uso del método Cierre
                        Console.ReadKey();
                        break;
                    case 3:
                        funcionandocajero = false;
                        break;
                }
            } while (funcionandocajero);
        }
    }

    public static class Herramienta
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
        private int MaxProductos { get; set; } //33
        private int ProductosDistintos { get; set; }//11
        private int[,] Compartimentos { get; set; }
        public bool EstaCobrado { get; set; } //checkear si hacerlo en metodo mejor.
    
        public bool Agregar(int productoId, int cantidad)
        {
            bool resp = false;
            for (int i = 0; i < MaxProductos; i++)
            {
                if (Compartimentos[i, 0] == 0)
                {
                    Compartimentos[i, 0] = productoId;
                    Compartimentos[i, 1] = cantidad;
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
                    Compartimentos[i, 0] = 0;
                    Compartimentos[i, 1] = 0;
                    resp = true;
                }
            }
            return resp;
        }
        public int CantidadProductos()
        {
            return 100;
        }
        public int CantidadProductosDistintos()
        {
            return 100;
        }
        public int TotalCarrito(Inventario inventario)
        {
            //lees el array Compartimentos y sumarizas el total segun el precio que esta dentro de inventario
            return 100;//total provisorio antes de descuentos
        }
    }

    public class ResumenVentas
    {
        public int[]? Ventas { get; set; }
        public void PedirResumen() { }
    }
    public struct DatosVenta
    {
        public int TotalSinDescuentos { get; set; }
        public int TotalCobrado { get; set; }
        public int CantidadVentas { get; set; }
        public int CantidadUnidades { get; set; }
        public decimal PromedioUnidadesVendidas { get; set; }
        public decimal TicketPromedio { get; set; }
        public int DiferenciaPorcentualConDescuento { get; set; }


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
        public void Vender(int productoId, Carrito[] ventaClientes, Inventario? Iventario)
        { 
            //completas el carrito con el producto id, antes tomando el precio y cantidad de inventario. que sea valido
        }
        public void RegistrarPrecio(int productoId, Inventario? Iventario, int precio) 
        {
            //buscas en tu inventario el producto con el productoId y agregas precio. Consultar antes si tiene precio no modificar nada.
        }
    }
    public class Cajero : Empleado
    {
        public Validador Validador { get; set; }
        public void Cobrar(Carrito[] carrito, Inventario inventario)
        {

            //dame el ultimo carrito para que tengas sin cobrar.
            Carrito changuito = null;
            int total = 0;
            int totalCantidad = 0;
            int totalDistintos = 0;
            for (int i = 0; i < carrito.Length; i++)
            {
                if (carrito[i].EstaCobrado == false)
                {
                    changuito = carrito[i];
                    //le pregunto a carrito: dame el total
                    total = changuito.TotalCarrito(inventario);
                    totalCantidad = changuito.CantidadProductos();
                    totalDistintos = changuito.CantidadProductosDistintos();
                    break;
                }
            }

            //cobro este carrito con los descuentos
             //segun los campos etc. ejemplo:
            // 1. Ajustes por monto
            //if (subtotal < 5000) montoFinal *= 1.15;
            //else if (subtotal < 10000) montoFinal *= 1.12;
            //else if (subtotal < 15000) montoFinal *= 1.09;
            //else if (subtotal >= 35000) montoFinal *= 0.85;
            //else if (subtotal >= 25000) montoFinal *= 0.89;
            //else if (subtotal >= 15000) montoFinal *= 0.925;
            //// 2. Ajustes por unidades
            //if (totalUnidades < 5) montoFinal *= 1.10;
            //else if (totalUnidades < 10) montoFinal *= 1.075;
            //else if (totalUnidades < 15) montoFinal *= 1.05;
            //else if (totalUnidades >= 25) montoFinal *= 0.95;
            //else if (totalUnidades >= 20) montoFinal *= 0.964;
            //else if (totalUnidades >= 15) montoFinal *= 0.976;
            //// 3. Ajustes por cantidad de productos distintos
            //if (totalProductosDistintos < 2) montoFinal *= 1.15;
            //else if (totalProductosDistintos < 4) montoFinal *= 1.10;
            //else if (totalProductosDistintos < 6) montoFinal *= 1.05;
            //else if (totalProductosDistintos >= 8) montoFinal *= 0.85;
            //else if (totalProductosDistintos >= 7) montoFinal *= 0.90;
            //else if (totalProductosDistintos >= 6) montoFinal *= 0.95;


            //luego le doy mensaje q cobre
            //dejar mensaje que le cobre X, que incluyo determinados descuentos
        }
        public void CierreDelDia(Carrito[] carritos, ref bool funcionandoPrincipal)
        {
            // Total vendido en pesos sin descuentos / aumentos.
            //○ Total de lo cobrado. 
            //○ Cantidad de ventas realizadas. 
            //○ Cantidad de unidades vendidas. 
            //○ Promedio de Unidades por Ventas y Cobrado por ventas.
            //○ Diferencia porcentual entre lo cobrado y lo vendido sin descuento/ aumento.
            //=> (1 - (sumatoria de ventas con descuento / sumatoria de ventas sin descuento)) * 100


        }
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