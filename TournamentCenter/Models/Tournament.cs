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
        private string sport;
        private DateTime deadline;
        private string organizer;
        private string sponsorLogoUrl;
        private int players;

        [Display(Name = "Registered players", Description ="Number of players registered for event.")]
        public int Players
        {
            get { return players; }
            set { players = value; }
        }



        [Display(Name ="Sponsor Logo", Prompt ="URL...", Description ="Logo of tournament's main sponsor.")]
        public string SponsorLogoUrl
        {
            get { return sponsorLogoUrl; }
            set { sponsorLogoUrl = value; }
        }

        [Required]
        [Display(Name="Organizer", Description ="Person responsible for organizing tournament.")]
        public string Organizer
        {
            get { return organizer; }
            set { organizer = value; }
        }


        [Display(Name = "Registration Deadline", Description = "Date when the registrations will be closed.")]
        [DataType(DataType.DateTime)]
        [Required]
        [Range(typeof(DateTime), "01/01/2001", "31/12/2099")]
        public DateTime Deadline
        {
            get { return deadline; }
            set { deadline = value; }
        }


        [Required]
        [Display(Name="Sport", Description ="Sport or game which will be played during event.")]
        public string Sport
        {
            get { return sport; }
            set { sport = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required]
        [StringLength(60, ErrorMessage = "Name you've given is too long.")]
        [Display(Name = "Tournament Name", Description = "Name of the event.")]
        public string TournamentName
        {
            get { return name; }
            set { name = value; }
        }



        [Display(Name = "Date", Description = "Date of the event.")]
        [DataType(DataType.DateTime)]
        [Required]
        [Range(typeof(DateTime), "01/01/2001", "31/12/2099")]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [Required]
        [StringLength(60, ErrorMessage = "Location name you've given is too long.")]
        [Display(Name = "Location", Description = "Place where the event will take place.")]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        
        [Display(Name = "Participants Limit", Description = "Maximum number of players that can compete in event. (0 or empty field means no limitations.)")]
        public int ParticipantsLimit
        {
            get { return limit; }
            set { limit = value; }
        }

    }
}