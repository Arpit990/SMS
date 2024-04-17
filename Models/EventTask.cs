namespace SpeakerManagementSystem.Models
{
    public class EventTask
    {
        public int Id { get; set; }
        public int EventId {  get; set; }
        public int TaskId { get; set; }
        public DateTime Deadline { get; set; }
    }
}
