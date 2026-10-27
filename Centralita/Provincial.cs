using System.Text;

namespace Centralita
{
    public enum Franja
    {
        Franja_1,
        Franja_2,
        Franja_3
    }

    public class Provincial : Llamada
    {
        protected Franja franjaHoraria;

        public Provincial(string origen, Franja franja, float duracion, string destino)
            : base(duracion, destino, origen)
        {
            this.franjaHoraria = franja;
        }

        public Provincial(Franja franja, Llamada llamada)
            : this(llamada.NroOrigen, franja, llamada.Duracion, llamada.NroDestino)
        {
        }

        private float CalcularCosto()
        {
            float valorFranja;
            switch (this.franjaHoraria)
            {
                case Franja.Franja_1: valorFranja = 0.99f; break;
                case Franja.Franja_2: valorFranja = 1.25f; break;
                default: valorFranja = 0.66f; break;
            }
            return this.Duracion * valorFranja;
        }

        public float CostoLlamada
        {
            get { return this.CalcularCosto(); }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine("Franja horaria: " + this.franjaHoraria);
            sb.AppendLine("Costo llamada: " + this.CostoLlamada);
            return sb.ToString();
        }
    }
}