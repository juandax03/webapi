using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MiBackendAPI.Models
{   
    [Table("termino_clave")] 
    public class TerminoClave
    {
        [Key]
        [MaxLength(30)]
        public string termino { get; set; }

        [MaxLength(30)]
        public string? termino_ingles { get; set; }
    }
}
