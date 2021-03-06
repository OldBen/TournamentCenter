﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace TournamentCenter
{
    public class GmailEmailService : SmtpClient
    {
        public string Username { get; set; }

        public GmailEmailService() :
                base(ConfigurationManager.AppSettings["GmailHost"], Int32.Parse(ConfigurationManager.AppSettings["GmailPort"]))
        {
            //Get values from web.config file:
            this.Username = ConfigurationManager.AppSettings["GmailUserName"];
            this.EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["GmailSsl"]);
            this.UseDefaultCredentials = false;
            this.Credentials = new System.Net.NetworkCredential(this.Username, ConfigurationManager.AppSettings["GmailPassword"]);
        }
    }
}