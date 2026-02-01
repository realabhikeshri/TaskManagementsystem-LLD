using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementsystem_LLD.Models
{
    public class User
    {
        public Guid Id { get; }
        public string Name { get; }

        public User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
