using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPProject.Entities
{
    public class UserDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Work> Works { get; set; }

        public UserDetails()
        {
            Teams = new HashSet<Team>();
            Tasks = new HashSet<Task>();
            Works = new HashSet<Work>();
        }

    }
}