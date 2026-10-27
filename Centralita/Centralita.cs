using System.Collections.Generic;
using System.Text;

namespace Centralita
{
    public enum TipoLlamada
    {
        Local,
        Provincial,
        Todas
    }

    public class Centralita
    {
        private List<Llamada> listaDeLlamadas;
        private string razonSocial;

        public Centralita()
        {
            this.listaDeLlamadas = new List<Llamada>();
            // SOLUCIÓN AL WARNING CS8618:
            // Inicializamos razonSocial para que no sea nula por defecto.
            this.razonSocial = string.Empty;
        }

        public Centralita(string razonSocial) : this()
        {
            this.razonSocial = razonSocial;
        }

        public List<Llamada> Llamadas
        {
            get { return this.listaDeLlamadas; }
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float ganancia = 0;

            foreach (Llamada llamada in this.listaDeLlamadas)
            {
                // Simplificamos el código usando Pattern Matching:
                if (llamada is Local local && (tipo == TipoLlamada.Todas || tipo == TipoLlamada.Local))
                {
                    ganancia += local.CostoLlamada;
                }
                else if (llamada is Provincial provincial && (tipo == TipoLlamada.Todas || tipo == TipoLlamada.Provincial))
                {
                    ganancia += provincial.CostoLlamada;
                }
            }
            return ganancia;
        }

        public float GananciaPorLocal { get { return this.CalcularGanancia(TipoLlamada.Local); } }
        public float GananciaPorProvincial { get { return this.CalcularGanancia(TipoLlamada.Provincial); } }
        public float GananciaPorTotal { get { return this.CalcularGanancia(TipoLlamada.Todas); } }

        public void OrdenarLlamadas()
        {
            this.listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Razón Social: " + this.razonSocial);
            sb.AppendLine("Facturación Total: " + this.GananciaPorTotal);
            sb.AppendLine("Facturación Local: " + this.GananciaPorLocal);
            sb.AppendLine("Facturación Provincial: " + this.GananciaPorProvincial);
            sb.AppendLine("\n=== Detalle de llamadas ===");

            foreach (Llamada llamada in this.listaDeLlamadas)
            {
                sb.AppendLine(llamada.Mostrar());
                sb.AppendLine("-------------------------");
            }
            return sb.ToString();
        }
    }
}