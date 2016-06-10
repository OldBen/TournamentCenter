using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TournamentCenter.Models
{
    public class Tournament
    {
        private int id;
        private string name;
        private string location;
        private DateTime date;
        private int limit;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string TournamentName
        {
            get { return name; }
            set { name = value; }
        }
        [DataType(DataType.Date)]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public int ParticipantsLimit
        {
            get { return limit; }
            set { limit = value; }
        }

    }
}