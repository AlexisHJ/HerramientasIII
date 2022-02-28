using System;
using System.Collections.Generic;
using System.Linq;

namespace Taller_Objetos_Final
{
    class Program
    {
         static void Main(string[] args)
        {
            List<Producto> ListaProductos = new List<Producto>();
            int seleccion;
            do
            {
                Console.WriteLine("Bienvenido a su tienda, es un placer atenderlo el día de hoy. ");
                Console.WriteLine(DateTime.Now);
                Console.WriteLine();
                Console.WriteLine("Cuentemos que desea por favor.");
                seleccion = Menu();
                Console.Clear();
                switch (seleccion)                
                {                    
                    case 1:
                    agregar(ListaProductos);
                    break;
                    case 2:
                    vender(ListaProductos);
                    break;
                    case 3:
                    sumar(ListaProductos);
                    break;
                    case 4:
                    promedio(ListaProductos);
                    break;
                    case 5:
                    buscar(ListaProductos);
                    break;
                    case 6:
                    imprimir(ListaProductos);
                    break;
                    case 7:
                    Console.WriteLine("Usted a decidido terminar, siempre es un placer atenderlo.");
                    Console.ReadKey();
                    break;
                    default:
                    Console.WriteLine("Por favor ingrese un valor valido.");
                    break;
                }
            } while (seleccion != 7);
        }
        static int Menu()
        {          
            Console.WriteLine("Seleccione por favor la opcion que desea: ");
            Console.WriteLine();
            Console.WriteLine("##################"); 
            Console.WriteLine("# Menu Principal #");
            Console.WriteLine("##################");
            Console.WriteLine();
            Console.WriteLine("1. Agregar un producto");
            Console.WriteLine("2. Vender un producto");
            Console.WriteLine("3. Sumar el precio de los productos selecionados");
            Console.WriteLine("4. Calcular el promedio de precios de los productos");
            Console.WriteLine("5. Buscar un producto en especifico");
            Console.WriteLine("6. Imprimir la lista actual de productos");
            Console.WriteLine("7. Terminar y salir del menu");
            try
            {
                int seleccion = int.Parse(Console.ReadLine());
                return seleccion;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        static void agregar(List<Producto> Lista)
        {
            Console.WriteLine("###########");
            Console.WriteLine("# Agregar #");
            Console.WriteLine("###########");
            Console.WriteLine();
            try
            {
                Producto Produc = new Producto();
                Produc.Codigo = Lista.Count + 1;
                Console.WriteLine("Digite el nombre del producto por favor: ");
                Produc.Nombre = Console.ReadLine();
                Console.WriteLine("Digite el precio del producto por favor: ");
                Produc.Costo = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite la categoria a la que pertenece por favor: ");
                Produc.Tipo = Console.ReadLine();
                Console.WriteLine("Digite la cantidad del producto en stock: ");
                Produc.Inventario = int.Parse(Console.ReadLine());
                Lista.Add(Produc);
                Console.WriteLine("Felicidades, el producto fue agregado con exito.");
            }
            catch (Exception){
                Console.WriteLine("Por favor ingrese un valor valido.");}
            Console.ReadKey();
            Console.Clear();
        }
        static void vender(List<Producto> Lista)
        {
            Console.WriteLine();
            if (Lista.Count > 0)
            {                
                double sumatoria = 0;
                double SumaTotal = 0;
                int opc = 0;
                do
                {
                    if (Lista.Count > 0)
                    {
                        Console.WriteLine("###############");
                        Console.WriteLine("# Disponibles #");
                        Console.WriteLine("###############");
                        Console.WriteLine();
                        foreach (var item in Lista){
                            Console.WriteLine(item.Codigo + " " + item.Nombre + " " + item.Costo + " pesos " + item.Inventario + " unidades disponibles");}                        
                        Console.WriteLine("Digite el codigo del producto por favor: ");
                        int cod = int.Parse(Console.ReadLine());
                        Console.WriteLine("Cuantas unidades del producto desea: ");
                        int unidad = int.Parse(Console.ReadLine());
                        var producto = (from i in Lista where i.Codigo == cod select i).FirstOrDefault();
                        if (producto != null)
                        {
                            sumatoria = (sumatoria + producto.Costo) * unidad;
                            producto.Inventario -= unidad;
                            Console.WriteLine("¡Genial! El producto se encuentra en su carrito de compras. ");
                            SumaTotal += sumatoria;
                            sumatoria = 0;
                            if (producto.Inventario == 0){
                                Lista.Remove(producto);}
                        }
                        else{
                            Console.WriteLine("Lo sentimos, el codigo ingresado no existe, verifiquelo por favor.");}
                        Console.ReadKey();
                        Console.Clear();
                        if (Lista.Count > 0)
                        {
                            Console.WriteLine("Si desea puede seguir eligiendo productos, ¿desea hacerlo?.");
                            Console.WriteLine("Digite 1 para si.");
                            Console.WriteLine("Digite 2 para no.");
                            opc = int.Parse(Console.ReadLine());
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Lo sentimos, no tenemos ese producto disponible temporalmente.");
                            opc = 2;
                            Console.ReadKey();
                            Console.Clear();
                        }

                    }

                } while (opc != 2);         
                Console.WriteLine("El precio total de su compra es de " + SumaTotal + " pesos.");             
            }
            else{
                Console.WriteLine("No encontramos una seleccion.");}
            Console.ReadKey();
            Console.Clear();
        }
        static void sumar(List<Producto> lista)
        {
            Console.WriteLine("########");
            Console.WriteLine("# Suma #");
            Console.WriteLine("########");
            Console.WriteLine();
            if (lista.Count > 0)
            {
                double sumatoria = 0;
                foreach (var item in lista){sumatoria += item.Costo;}
                Console.WriteLine("Segun las lista de articulos seleccionados la sumatoria es: " + sumatoria + " pesos");
            }
            else{Console.WriteLine("Si desea sumar una lista de articulos por favor seleccionelos.");}
            Console.ReadKey();
            Console.Clear();
        }
        static void promedio(List<Producto> lista)
        {
            Console.WriteLine("############");
            Console.WriteLine("# Promedio #");
            Console.WriteLine("############");
            Console.WriteLine();
            if (lista.Count > 0)
            {
                int contador = 0;
                double suma = 0;
                double promedio = 0;               
                foreach (var item in lista){suma += item.Costo; contador++;}
                promedio = (suma / contador);
                Console.WriteLine("El promedio de lo seleccionado es: " + promedio + " pesos");
            }
            else{Console.WriteLine("Si la lista no tiene items selecionados no puede promediarse");}
            Console.ReadKey();
            Console.Clear();
        }
        static void buscar(List<Producto> Lista)
        {
            if (Lista.Count > 0)
            {
                Console.WriteLine("############");
                Console.WriteLine("# Busqueda #");
                Console.WriteLine("############");
                Console.WriteLine();
                Console.WriteLine("1. Si desea buscar por Nombre.");
                Console.WriteLine("2. Si desea buscar por Codigo.");
                Console.WriteLine("3. Si desea buscar por Precio.");
                Console.WriteLine("4. Si desea buscar por Categoria");
                Console.WriteLine("5. Si desea buscar por Stock");
                int Seleccion = int.Parse(Console.ReadLine());
                switch (Seleccion)
                {
                    case 1:
                        Console.WriteLine("Digite por favor el nombre del producto que desea buscar: ");
                        string nombres = Console.ReadLine();
                        var Lnombres = (from i in Lista where i.Nombre == nombres select i).ToList();
                        imprimir(Lnombres);
                        break;
                    case 2:
                        Console.WriteLine("Digite por favor el Codigo del producto que desea buscar: ");
                        int codigo = int.Parse(Console.ReadLine());
                        var Lcodigo = (from i in Lista where i.Codigo == codigo select i).ToList();
                        imprimir(Lcodigo);
                        break;
                    case 3:
                        Console.WriteLine("Digite por favor el precio del producto que desea buscar: ");
                        double valor = double.Parse(Console.ReadLine());
                        Console.WriteLine("Digite por favor el modo de busqueda: ");
                        Console.WriteLine("Digite 1 para mayor");
                        Console.WriteLine("Digite 2 para menor");
                        double precio = double.Parse(Console.ReadLine());
                        List<Producto> Lprecios = new List<Producto>();
                        if (precio == 1)
                        {Lprecios = (from i in Lista where i.Costo >= valor select i).ToList();}
                        else
                        {Lprecios = (from i in Lista where i.Costo <= valor select i).ToList();}
                        imprimir(Lprecios);
                        break;
                    case 4:
                        Console.WriteLine("Digite por favor la categoria del producto que desea buscar: ");
                        string categoria = Console.ReadLine();
                        var Lcategoria = (from i in Lista where i.Tipo == categoria select i).ToList();
                        imprimir(Lcategoria);
                        break;
                    case 5:
                        Console.WriteLine("Digite por favor el Stock del producto que desea buscar: ");
                        int stock = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite por favor el modo de busqueda: ");
                        Console.WriteLine("Digite 1 para mayor");
                        Console.WriteLine("Digite 2 para menor");
                        int opcion = int.Parse(Console.ReadLine());
                        List<Producto> Lstock = new List<Producto>();
                        if (opcion == 1)
                        {Lstock = (from i in Lista where i.Inventario >= stock select i).ToList();}
                        else
                        {Lstock = (from i in Lista where i.Inventario <= stock select i).ToList();}
                        imprimir(Lstock);
                        break;
                    default:
                        Console.WriteLine("Digite por favor un valor dentro de las opciones posibles.");
                        break;
                }
            }
            else
            {Console.WriteLine("No se encuentran items para realizar la busqueda.");}
            Console.ReadKey();
            Console.Clear();
        }
        static void imprimir(List<Producto> Lista)
        {
            Console.WriteLine("###############");
            Console.WriteLine("# Informacion #");
            Console.WriteLine("###############");
            Console.WriteLine();
            if (Lista.Count > 0)
            {foreach (var item in Lista){ Console.WriteLine($"El nombre producto es: {item.Nombre}, Su Codigo es: {item.Codigo}, El valor del producto es: {item.Costo}, Su Categoria es: {item.Tipo}, Se encuentra en stock: {item.Inventario}");}}
            else{Console.WriteLine("Actualmente no tenemos items en la lista");}
            Console.ReadKey();
            Console.Clear();
        }

    }
}