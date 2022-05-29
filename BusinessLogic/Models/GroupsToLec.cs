using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class GroupsToLec
    {
        public int LectionId { get; set; } //связь с т студенты (многие ко одному)
        public int? GroupId { get; set; }  //связь с т студенты (многие ко одному)
    }
}
