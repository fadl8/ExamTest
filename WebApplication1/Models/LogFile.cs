using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class LogFile
    {
        public int Id { get; set; }
        public string? Action { get; set; }

        [ForeignKey("SystemUser")]
        public long SystemUserId { get; set; }
        public SystemUser SystemUser { get; set; }
    }

    public class LogFileViewModel
    {
        public int Id { get; set; }
        public string? Action { get; set; } 
        public long SystemUserName { get; set; }
        
    }
}
