using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPProject.Entities
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<UserDetails> Members { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        //public UserDetails TeamLeader { get; set; }
        //public UserDetails Director { get; set; }

        public Team()
        {
            Tasks = new HashSet<Task>();
        }
    }
}