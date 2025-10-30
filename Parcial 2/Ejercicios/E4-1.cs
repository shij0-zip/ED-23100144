using System;

namespace E3
{
    internal class Program
    {
        public static char PeekPila(ClasePilaDinamica<char> pila)
        {
            if (pila.Vacia)
            {
                return '\0'; // Retorna null char si está vacía
            }
            // Temporalmente sacamos el elemento para 'espiarlo'
            char topElement = pila.Pop();
            pila.Push(topElement); // Lo volvemos a insertar
            return topElement;
        }

        public static void ValidarBalanceo()
        {
            Console.WriteLine("--- EJERCICIO 1: Validación de Balanceo de Paréntesis/Corchetes ---");
            Console.Write("Ingrese la cadena a validar: ");
            string cadena = Console.ReadLine();

            // Pila para almacenar los caracteres de apertura (paréntesis y corchetes)
            ClasePilaDinamica<char> pila = new ClasePilaDinamica<char>();
            bool error = false;
            char f = '\0'; // Representa el valor f en el diagrama (carácter actual)
            char Dentro = '\0'; // Representa la variable 'Dentro' en el diagrama (carácter en el tope de la pila)

            // Bucle principal: for (i=0; i < cadena.lenght; i++)
            for (int i = 0; i < cadena.Length; i++)
            {
                f = cadena[i]; // f = valor(i)

                // 1. Es un caracter de apertura? '(', '['
                if (f == '(' || f == '[')
                {
                    // InsertarPila(f)
                    pila.Push(f);
                }
                // 2. Es un caracter de cierre? ')', ']'
                else if (f == ')' || f == ']')
                {
                    // Verifica si la pila está vacía (Error: cierra sin abrir)
                    if (pila.Vacia)
                    {
                        error = true; // 'Error' en el diagrama
                        break;
                    }

                    // Dentro = SacarPila()
                    Dentro = pila.Pop();

                    // Comprobaciones de coincidencia
                    if (f == ')' && Dentro == '(')
                    {
                        // Coincidencia correcta: No se hace nada, el pop ya se hizo.
                    }
                    else if (f == ']' && Dentro == '[')
                    {
                        // Coincidencia correcta: No se hace nada.
                    }
                    else
                    {
                        // f == ')' pero Dentro != '(', o f == ']' pero Dentro != '['
                        error = true; // 'Error' en el diagrama
                        break;
                    }
                }
                // 3. Otros caracteres (f != '(', '[', ')', ']')
                // Se ignoran según la lógica simplificada del diagrama,
                // que solo trata con paréntesis y corchetes.
            } // Fin del bucle, vuelve al punto 1 (1) en el diagrama

            Console.WriteLine("-----------------------------------------------------------------");

            // Comprobación final
            if (error || !pila.Vacia) // Si hubo un error o la pila no está vacía (aperturas sin cierre)
            {
                // La parte 'f == null' no tiene sentido en el diagrama al final del bucle,
                // la condición final es si la pila quedó Vacía o no, y si hubo un error previo.
                if (error)
                {
                    Console.WriteLine($"RESULTADO: {cadena} -> Falso (Error de sintaxis o pila vacía al cerrar)");
                }
                else
                {
                    Console.WriteLine($"RESULTADO: {cadena} -> Falso (Quedan corchetes/paréntesis sin cerrar)");
                }
            }
            else // La pila está Vacía y no hubo error previo.
            {
                Console.WriteLine($"RESULTADO: {cadena} -> Correcto");
            }

            Console.WriteLine("-----------------------------------------------------------------");
        }

        static void Main(string[] args)
        {
            try
            {
                ValidarBalanceo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
