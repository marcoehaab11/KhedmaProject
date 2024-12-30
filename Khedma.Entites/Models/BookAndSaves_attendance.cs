namespace Khedma.Entites.Models
{
    public class BookAndSaves_attendance
    {
        public int Id { get; set; }
        public int MakhdoumID { get; set; }
        public int StageID { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        public bool attendance { get; set; } = false;
        public bool committed { get; set; } = false;
        public bool excellence { get; set; } = false;

        public TheStage TheStage { get; set; }
        public Makhdoum Makhdoum { get; set; }
    }
}
