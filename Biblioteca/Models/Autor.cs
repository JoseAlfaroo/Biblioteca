using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Biblioteca.Models;

public class Autor
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int? AutorID { get; set; }


  public string? NombresAutor { get; set; }


  public string? ApellidosAutor { get; set; }

  public int? PaisID { get; set; }

  [JsonIgnore]
  public Pais? Pais { get; set; }
}
