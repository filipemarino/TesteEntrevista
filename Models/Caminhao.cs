using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEntrevista.Models
{
   [Table("Caminhao")]
   public class Caminhao
   {
      [Display(Name = "Id")]
      public int Id { get; set; }                                                                                          // Id do registro chave unica

      [Required(ErrorMessage = "Campo é Obrigatório")]
      [Display(Name = "Placa/Chassis")]     
      [StringLength(20)]
      public string Placa { get; set; }                                                                                    // Placa do Veiculo

      [Required(ErrorMessage = "Campo é Obrigatório")]
      [Display(Name = "Modelo")]
      public string Modelo { get; set; }                                                                                   // Modelo do Veiculo

      [Required(ErrorMessage = "Campo é Obrigatório")]
      [Display(Name = "Ano de Fabricação")]
      [Range(1970, 9999, ErrorMessage = "O ano de fabricação deve conter 4 digitos")]
      public int AnoFab { get; set; }                                                                                      // Ano de fabricação do Veiculo -- entre 1970 a 9999

      [Required(ErrorMessage = "Campo é Obrigatório")]
      [Display(Name = "Ano do Modelo")]
      [Range(1970, 9999, ErrorMessage = "O ano do Modelo deve conter 4 digitos")]
      public int AnoMod { get; set; }                                                                                      // Ano do Modelo do Veiculo -- entre 1970 a 9999
   }
}
