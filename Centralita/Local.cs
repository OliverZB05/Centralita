using System.Text;

namespace Centralita
{
    public class Local : Llamada
    {
        protected float costo;

        public Local(string origen, float duracion, string destino, float costo)
            : base(duracion, destino, origen)
        {
            this.costo = costo;
        }

        public Local(Llamada llamada, float costo)
            : this(llamada.NroOrigen, llamada.Duracion, llamada.NroDestino, costo)
        {
        }

        private float CalcularCosto()
        {
            return this.Duracion * this.costo;
        }

        public float CostoLlamada
        {
            get { return this.CalcularCosto(); }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine("Costo llamada: " + this.CostoLlamada);
            return sb.ToString();
        }
    }
}