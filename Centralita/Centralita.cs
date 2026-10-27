using System.Collections.Generic;
using System.Text;

public class Centralita
{
    private List<Llamada> listaDeLlamadas;
    private string razonSocial;

    public Centralita(string razonSocial)
    {
        this.listaDeLlamadas = new List<Llamada>();
        this.razonSocial = razonSocial;
    }

    private void AgregarLlamada(Llamada nuevaLlamada)
    {
        this.listaDeLlamadas.Add(nuevaLlamada);
    }

    private string Mostrar()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Centralita: {this.razonSocial}");
        sb.AppendLine($"Total de llamadas: {this.listaDeLlamadas.Count}");
        foreach (Llamada llamada in this.listaDeLlamadas)
        {
            sb.AppendLine(llamada.ToString());
        }
        return sb.ToString();
    }

    public override string ToString()
    {
        return Mostrar();
    }

    public static bool operator ==(Centralita c, Llamada l)
    {
        if (ReferenceEquals(c, null) || ReferenceEquals(l, null)) return false;

        foreach (Llamada llamadaEnLista in c.listaDeLlamadas)
        {
            if (llamadaEnLista == l) return true;
        }
        return false;
    }

    public static bool operator !=(Centralita c, Llamada l)
    {
        return !(c == l);
    }

    public static Centralita operator +(Centralita c, Llamada l)
    {
        if (c != l)
        {
            c.AgregarLlamada(l);
        }
        return c;
    }

    public void OrdenarLlamadas()
    {
        this.listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
    }
}