namespace EMGVoitures.Models
{
    public class Voiture
    {
        public int Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public bool EstVendue { get; set; }
    }
}
