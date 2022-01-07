namespace webapi.Models
{
  using System;
  using System.ComponentModel.DataAnnotations;
  public class Chamado
  {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage ="A solicitação não pode ficar vazia")]
    public string Summary { get; set; }
    [Required]
    public string Client { get; set; }
    public DateTime DateOpen { get; set; }
    public string Resolution { get; set; }

  }
}