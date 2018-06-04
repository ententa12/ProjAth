using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPProject.Entities
{
    public class Work
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }

        public virtual UserDetails User { get; set; }
        public virtual Task Task { get; set; }

    }
}