using System.ComponentModel.DataAnnotations;

namespace MTLCRISTALVK18BACK.Models.Reservas
{
    public class Reservas
    {
        [Key]
        public int IdResv { get; set; }
        public int Numresv { get; set; }
        public string? Estadoresv { get; set; }
        public string? Tiporesv { get; set; }
        public string? Tiemporentresv { get; set; }
        public string? Diasemofinresv { get; set; }
        public string? Precioresv { get; set; }
        public string? Statushabresv { get; set; }
        public string? Statuspagohabresv { get; set; }
        public string? Limpiezahabresv { get; set; }
        public string? Horarentaresv { get; set; }
        public string? Folioordenresv { get; set; }
        public string? AcargoUserMTL { get; set; }
        public int TurnoUserMTL { get; set; }

        public List<Tipo1Cliente> Tipo1ResvdCl { get; set; } = new List<Tipo1Cliente>();
        public List<Tipo2Consumos> Tipo2ResvdCl { get; set; } = new List<Tipo2Consumos>();
    }

    public class Tipo1Cliente
    {
        [Key]
        public int IdClte { get; set; }
        [Required]
        public string? StatusingresoCl { get; set; }
        public string? AutPlacasCl { get; set; }
        public string? AutMarcaCl { get; set; }
        public string? AutColorCl { get; set; }
        public string? FrecuenciaCl { get; set; }
        public string? AdvertCl { get; set; }
        public string? NumHabCl { get; set; }
        public string? FechaEntradaCl { get; set; }
        public string? FechaSalidaCl { get; set; }
        public decimal TotalConsumos { get; set; }
        public string? AcargoUserMTL1 { get; set; }


    }

    public class Tipo2Consumos
    {
        [Key]
        public int IdCsms { get; set; }
        public string? Descripcion { get; set; }
        public string? Cantidad { get; set; }
        public string? PrecioUnit { get; set; }
        public string? StatusPagado { get; set; }
        public string? Totalpagado { get; set; }
        public string? Totalconsumos { get; set; }
        public string? AcargoUserMTL2 { get; set; }
    }
}
