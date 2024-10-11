using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiBackendAPI.Models
{   
    [Table("proyecto")]

  public class Proyecto
{
    public int id { get; set; }
    public string titulo { get; set; }
    public string resumen { get; set; }
    public double presupuesto { get; set; }  // Cambiar de float a double
    public string tipo_financiacion { get; set; }
    public string tipo_fondos { get; set; }
    public DateTime fecha_inicio { get; set; }
    public DateTime? fecha_fin { get; set; }
}
}
