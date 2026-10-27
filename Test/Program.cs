using System;
using Centralita; // para Llamada, Local, Provincial, Franja
using CentralitaModelo = Centralita.Centralita; // alias por si hay conflicto de nombres

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CentralitaModelo central = new CentralitaModelo("Central Telefónica Test");

            // Dos llamadas Local
            Local local1 = new Local("111", 10f, "222", 0.5f);

            Llamada llamadaBaseLocal = new Llamada(20f, "333", "444");
            Local local2 = new Local(llamadaBaseLocal, 1f);

            // Dos llamadas Provincial
            Provincial provincial1 = new Provincial("555", Franja.Franja_1, 10f, "666");

            Llamada llamadaBaseProvincial = new Llamada(30f, "777", "888");
            Provincial provincial2 = new Provincial(Franja.Franja_3, llamadaBaseProvincial);

            // Agregar a la centralita
            central.Llamadas.Add(local1);
            central.Llamadas.Add(local2);
            central.Llamadas.Add(provincial1);
            central.Llamadas.Add(provincial2);

            Console.WriteLine("===== ANTES DE ORDENAR =====");
            Console.WriteLine(central.Mostrar());

            Console.WriteLine("Ganancia por Local: " + central.GananciaPorLocal);
            Console.WriteLine("Ganancia por Provincial: " + central.GananciaPorProvincial);
            Console.WriteLine("Ganancia Total: " + central.GananciaPorTotal);

            central.OrdenarLlamadas();

            Console.WriteLine();
            Console.WriteLine("===== DESPUÉS DE ORDENAR =====");
            Console.WriteLine(central.Mostrar());

            Console.ReadKey();
        }
    }
}