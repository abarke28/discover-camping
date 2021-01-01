using discover_camping.Helpers;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System;

namespace discover_camping.notifiers
{
    public class EmailNotifier : INotifier
    {
        private string _senderEmail;
        private string _senderPw;
        private string _emailsString;
        private IList<MailAddress> _emails;

        public EmailNotifier()
        {
            GetConfig();
        }

        public void Notify()
        {
            if (_emails == null || _emails.Count == 0) throw new ArgumentNullException(nameof(_emails));

            Console.WriteLine("Notifying watchers");

            var message = new MailMessage
            {
                From = new MailAddress(_senderEmail),
                Subject = Constants.SUBJECT,
                Body = string.Format(Constants.BODY, Constants.DISCOVER_BACKCOUNTRY_RESERVATIONS)
            };

            foreach (var email in _emails)
            {
                message.To.Add(email);
            }

            var client = new SmtpClient
            {
                Host = Constants.GMAIL,
                Port = Constants.PORT,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_senderEmail, _senderPw),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            Console.WriteLine("Sending Email");
            client.Send(message);
            Console.WriteLine("Email Sent");
        }

        private void GetConfig()
        {
            _senderEmail = ConfigurationManager.AppSettings[Constants.SENDER_EMAIL];
            _senderPw = ConfigurationManager.AppSettings[Constants.SENDER_PW];
            _emailsString = ConfigurationManager.AppSettings[Constants.EMAILS];

            _emails = _emailsString.Split(";").Select(e => new MailAddress(e)).ToList();
        }
    }
}