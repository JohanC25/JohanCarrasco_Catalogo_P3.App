using SQLite;
using System.ComponentModel.DataAnnotations;

namespace JohanCarrasco_Catalogo_P3.Models
{
    [Table("CatalogoUsers")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required]
        private string NombreUsuario { get; set; }
        [Required]
        private string Contrasenia { get; set; }
        [Required]
        private string Telefono { get; set; }
        public DateTime Date { get; set; }
    }
}
