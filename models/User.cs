using System.ComponentModel.DataAnnotations;
 
 namespace testeef.Models
 {
    public class User
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 6 e 20 caracteres")]
        [MinLength(6, ErrorMessage = "Este campo deve conter entre 6 e 20 caracteres")]
    
        public string Usuario {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 6 e 20 caracteres")]
        [MinLength(6, ErrorMessage = "Este campo deve conter entre 6 e 20 caracteres")]
    
        public string Senha {get; set;}
    }    
 }