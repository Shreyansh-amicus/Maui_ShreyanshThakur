namespace Maui_ShreyanshThakur.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Site { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime ScheduledDate { get; set; }
    }
}