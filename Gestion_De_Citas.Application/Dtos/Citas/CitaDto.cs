
namespace Gestion_De_Citas.Application.Dtos.Citas

{

    public class CitaDto
    {
        public DateTime Fecha { get; set; }
        public int Pacientes { get; set; }

        public int Id { get; set; }

        public string Nombre { get; set; } = "";
    }
}