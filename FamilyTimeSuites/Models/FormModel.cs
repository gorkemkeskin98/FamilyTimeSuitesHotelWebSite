using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyTimeSuites.Models
{
    public class FormModel
    {
        [Required]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Soyadi { get; set; }
        [MaxLength(15,ErrorMessage ="Telefon numaranızı giriniz.")]
        public string Tel { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [EmailAddress(ErrorMessage ="Email geçersiz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [MaxLength(500,ErrorMessage ="500 karakter girebilirsiniz.")]
        public string Mesaj { get; set; }
    }
}