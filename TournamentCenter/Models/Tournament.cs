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

        [Display(Name = "Tournament Name", Description = "Name of the event.")]
        public string TournamentName
        {
            get { return name; }
            set { name = value; }
        }

        [Display(Name = "Date", Description = "Date of the event.")]
        [DataType(DataType.Date)]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [Display(Name = "Location", Description = "Place where the event will take place.")]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        [Display(Name = "Participants Limit", Description = "Maximum number of players that can compete in event.")]
        public int ParticipantsLimit
        {
            get { return limit; }
            set { limit = value; }
        }

    }
}