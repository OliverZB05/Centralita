public abstract class Llamada
{
    protected float duracion;
    protected string nroDestino;
    protected string nroOrigen;

    public float Duracion { get { return duracion; } }
    public string NroDestino { get { return nroDestino; } }
    public string NroOrigen { get { return nroOrigen; } }

    // Propiedad abstracta de solo lectura
    public abstract float CostoLlamada { get; }

    // Constructor
    public Llamada(string nroOrigen, string nroDestino, float duracion)
    {
        this.nroOrigen = nroOrigen;
        this.nroDestino = nroDestino;
        this.duracion = duracion;
    }

    // Ahora es protected virtual
    protected virtual string Mostrar()
    {
        return $"Duración: {this.duracion} min. Origen: {this.nroOrigen} - Destino: {this.nroDestino}";
    }

    // Sobrecarga de operadores == y !=
    public static bool operator ==(Llamada l1, Llamada l2)
    {
        // Si ambos son nulos o ambos son la misma instancia
        if (ReferenceEquals(l1, null) || ReferenceEquals(l2, null)) return false;
        if (ReferenceEquals(l1, l2)) return true;

        // Aquí se apoya en el Equals de las clases derivadas para el tipo concreto
        if (l1.Equals(l2))
        {
            return l1.nroOrigen == l2.nroOrigen && l1.nroDestino == l2.nroDestino;
        }
        return false;
    }

    public static bool operator !=(Llamada l1, Llamada l2)
    {
        return !(l1 == l2);
    }

    // Método estático para ordenar
    public static int OrdenarPorDuracion(Llamada a, Llamada b)
    {
        return a.duracion.CompareTo(b.duracion);
    }
}