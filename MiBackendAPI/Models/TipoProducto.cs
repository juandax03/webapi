using System.ComponentModel.DataAnnotations.Schema;
namespace MiBackendAPI.Models
{
    [Table("tipo_producto")]  // Esto indica que la tabla en la BD es "tipo_producto"

    public class TipoProducto
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Clase { get; set; }
        public string Nombre { get; set; }
        public string Tipologia { get; set; }
    }
}
