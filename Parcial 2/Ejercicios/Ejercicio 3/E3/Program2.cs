//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace E3
//{
//    internal class Program2
//    {
//        public static void ValidarPalindromo()
//        {
//            Console.WriteLine("--- EJERCICIO 2: Verificación de Palíndromo con Pila ---");

//            // Declaraciones de variables según el diagrama
//            ClasePilaDinamica<char> Pila = new ClasePilaDinamica<char>();
//            string cadena;
//            string cadena_inv = ""; // Inicializar la cadena inversa
//            char C;
//            int i;

//            Console.Write("Ingrese la cadena a verificar: ");
//            cadena = Console.ReadLine();

//            // -----------------------------------------------------------
//            // PRIMERA FASE: Llenar la pila
//            // i=0 ; i < cadena.lenght ; i++
//            for (i = 0; i < cadena.Length; i++)
//            {
//                C = cadena[i]; // C = cadena[i]
//                Pila.Push(C);  // Pila.Push(C)
//            }

//            // -----------------------------------------------------------
//            // SEGUNDA FASE: Vaciar la pila y construir la cadena invertida
//            // Volvemos a iterar para sacar los elementos de la pila
//            // i=0 ; i < cadena.lenght ; i++
//            for (i = 0; i < cadena.Length; i++)
//            {
//                // Usamos Pop() sin argumentos tal como se indica en el diagrama 
//                // con 'C = Pila.Pop()'
//                try
//                {
//                    C = Pila.Pop();
//                    // cadena inv = cadena inv + C
//                    cadena_inv = cadena_inv + C;
//                }
//                catch (Exception)
//                {
//                    // Debería ser inalcanzable si la pila se llenó correctamente
//                    Console.WriteLine("Error: La pila se vació prematuramente.");
//                    return;
//                }
//            }

//            Console.WriteLine("---------------------------------------------------------");
//            Console.WriteLine($"Cadena Original: {cadena}");
//            Console.WriteLine($"Cadena Invertida: {cadena_inv}");

//            // -----------------------------------------------------------
//            // TERCERA FASE: Comparación
//            // Eliminamos espacios y convertimos a minúsculas para una comparación 
//            // más robusta (aunque el diagrama solo pide la comparación directa).
//            string cadenaLimpia = cadena.Replace(" ", "").ToLower();
//            string cadenaInvLimpia = cadena_inv.Replace(" ", "").ToLower();

//            if (cadenaLimpia == cadenaInvLimpia) // cadena == cadena inv
//            {
//                Console.WriteLine("RESULTADO: \"Sí es palíndromo\"");
//            }
//            else
//            {
//                Console.WriteLine("RESULTADO: \"No es palíndromo\"");
//            }
//            Console.WriteLine("---------------------------------------------------------");
//        }

//        static void Main(string[] args)
//        {
//            try
//            {
//                ValidarPalindromo();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Ocurrió un error: {ex.Message}");
//            }
//            Console.ReadKey();
//        }
//    }
//}
