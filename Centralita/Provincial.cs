public class Provincial : Llamada
{
    private Franja franjaHoraria;

    public enum Franja { Franja_1, Franja_2, Franja_3 }

    public override float CostoLlamada => CalcularCosto();

    public Provincial(string nroOrigen, string nroDestino, float duracion, Franja franja)
        : base(nroOrigen, nroDestino, duracion)
    {
        this.franjaHoraria = franja;
    }

    private float CalcularCosto()
    {
        float tarifa = franjaHoraria switch
        {
            Franja.Franja_1 => 0.99f,
            Franja.Franja_2 => 1.25f,
            Franja.Franja_3 => 0.66f,
            _ => 0
        };
        return this.duracion * tarifa;
    }

    protected override string Mostrar()
    {
        return $"{base.Mostrar()} - Franja: {this.franjaHoraria} - Costo Provincial: ${this.CostoLlamada}";
    }

    public override string ToString()
    {
        return Mostrar();
    }

    public override bool Equals(object obj)
    {
        return obj is Provincial;
    }

    public override int GetHashCode() => base.GetHashCode();
}