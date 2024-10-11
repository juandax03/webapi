namespace MiFrontendBlazor.Models
{
    public class ProyectoModel
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string resumen { get; set; }
        public float presupuesto { get; set; }
        public string tipo_financiacion { get; set; }
        public string tipo_fondos { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
    }
}
