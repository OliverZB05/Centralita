using System.Text;

namespace Centralita
{
    public class Llamada
    {
        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        public float Duracion { get { return this.duracion; } }
        public string NroDestino { get { return this.nroDestino; } }
        public string NroOrigen { get { return this.nroOrigen; } }

        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Duración: " + this.duracion);
            sb.AppendLine("Nro. Destino: " + this.nroDestino);
            sb.AppendLine("Nro. Origen: " + this.nroOrigen);
            return sb.ToString();
        }

        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            return llamada1.Duracion.CompareTo(llamada2.Duracion);
        }
    }
}