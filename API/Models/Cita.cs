using System;

namespace Gestion_De_Citas.Models;

public enum EstadoCita { Programada, Completada, Cancelada }

public class Cita
{
    public int Id { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public string Terapeuta { get; set; } = string.Empty;
    public string Servicio { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public EstadoCita Estado { get; set; } = EstadoCita.Programada;
}
