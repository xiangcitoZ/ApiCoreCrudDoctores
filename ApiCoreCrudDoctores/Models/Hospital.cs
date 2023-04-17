using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCoreCrudDoctores.Models
{
    [Table("HOSPITAL")]
    public class Hospital
    {
        [Key]
        [Column("HOSPITAL_COD")]
        public int IdHospital { get; set; }
       
        [Column("NOMBRE")]
        public string Nombre { get; set; }
       


    }
}
