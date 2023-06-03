using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleGlicemia_002.ViewModel
{
    public class GlicemiaViewModel
    {
        [Key]
        public int GlicemiaID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(40, 500, ErrorMessage = "O Campo {0} dever ter valor entre 40 e 500")]
        [DisplayName("Glicemia Medida")]
        [DataType(DataType.Text)]
        public int? GlicemiaMedida { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Data Medição")]
        [DataType(DataType.Date)]
        public DateTime? DataMedicao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Hora Medição")]
        [DataType(DataType.Time)]
        public DateTime? HoraMedicao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Data Aplicação")]
        [DataType(DataType.Date)]
        public DateTime? DataAplicacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Hora Aplicação")]
        [DataType(DataType.Time)]
        public DateTime? HoraAplicacao { get; set; }

        [Range(20, 46, ErrorMessage = "O Campo {0} dever ter valor entre 20 e 46")]
        [DisplayName("Dose Regular")]
        [DataType(DataType.Text)]
        public int? DoseRegular { get; set; }

        [Range(2, 18, ErrorMessage = "O Campo {0} dever ter valor entre 2 e 18")]
        [DisplayName("Dose Ajuste")]
        [DataType(DataType.Text)]
        public int? DoseAjuste { get; set; }

        [StringLength(4096)]
        [DisplayName("Observações")]
        [DataType(DataType.Text)]
        public string? Observacao { get; set; }

        //-------------------------------------------------------------------------------

        //public string? EhErro { get; set; }
        //public string? MensagemRetorno { get; set; }
    }
}
