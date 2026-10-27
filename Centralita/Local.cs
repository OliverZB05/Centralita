public class Local : Llamada
{
    private float costo;

    public override float CostoLlamada => CalcularCosto();

    public Local(string nroOrigen, string nroDestino, float duracion, float costo)
        : base(nroOrigen, nroDestino, duracion)
    {
        this.costo = costo;
    }

    private float CalcularCosto()
    {
        return this.duracion * this.costo;
    }

    protected override string Mostrar()
    {
        // Reutiliza base.Mostrar() y agrega lo específico
        return $"{base.Mostrar()} - Costo Local: ${this.CostoLlamada}";
    }

    public override string ToString()
    {
        return Mostrar();
    }

    public override bool Equals(object obj)
    {
        // Solo es igual si es del mismo tipo concreto
        return obj is Local;
    }

    public override int GetHashCode() => base.GetHashCode();
}