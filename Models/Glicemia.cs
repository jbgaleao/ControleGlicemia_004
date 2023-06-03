namespace ControleGlicemia_002.Models
{
    public class Glicemia
    {
        public Glicemia()
        {

        }
        public int GlicemiaID { get; set; }
        public int? GlicemiaMedida { get; set; }
        public DateTime? DataMedicao { get; set; }
        public DateTime? HoraMedicao { get; set; }
        public DateTime? DataAplicacao { get; set; }
        public DateTime? HoraAplicacao { get; set; }
        public int? DoseRegular { get; set; }
        public int? DoseAjuste { get; set; }
        public string? Observacao { get; set; }
    }
}
