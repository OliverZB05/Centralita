using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cambiamos CentralitaModelo por Centralita
            Centralita central = new Centralita("Central Telefónica Test");

            // 1. Instanciamos llamadas 
            // Local(nroOrigen, nroDestino, duracion, costo)
            Local local1 = new Local("111", "222", 10f, 0.5f);
            Local local2 = new Local("333", "444", 20f, 0.7f);

            // Provincial(nroOrigen, nroDestino, duracion, Franja)
            Provincial provincial1 = new Provincial("555", "666", 10f, Provincial.Franja.Franja_1);
            Provincial provincial2 = new Provincial("777", "888", 30f, Provincial.Franja.Franja_3);

            // Prueba de duplicado
            Local localDuplicada = new Local("111", "222", 15f, 0.9f);

            // 2. Registrar llamadas ÚNICAMENTE mediante el operador + 
            central = central + local1;
            central = central + local2;
            central = central + provincial1;
            central = central + provincial2;

            // Aquí se prueba que el operador + no agregue duplicados
            central = central + localDuplicada;

            // 3. Ordenar las llamadas
            central.OrdenarLlamadas();

            // 4. Mostrar la Centralita UNA SOLA VEZ después de ordenar
            Console.WriteLine("===== LLAMADAS REGISTRADAS (ORDENADAS) =====");
            Console.WriteLine(central.ToString());

            // Prueba del operador == entre Centralita y Llamada
            Console.WriteLine("\n¿La centralita contiene a local1?: " + (central == local1));
            Console.WriteLine("¿La centralita contiene a localDuplicada?: " + (central == localDuplicada));

            Console.ReadKey();
        }
    }
}