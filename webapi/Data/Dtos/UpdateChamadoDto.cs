using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Data.Dtos
{
  public class UpdateChamadoDto
  {
    [Required(ErrorMessage = "A solicitação não pode ficar vazia")]
    public string Summary { get; set; }
    [Required]
    public string Client { get; set; }
    public DateTime DateOpen { get; set; }
    public string Resolution { get; set; }
  }
}