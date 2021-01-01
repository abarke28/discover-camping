using discover_camping.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Net;

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
            var message = new MailMessage();

            message.From = new MailAddress(_senderEmail);

            foreach(var email in _emails)
            {
                message.To.Add(email);
            }

            message.Subject = Constants.SUBJECT;
            message.Body = string.Format(Constants.BODY, Constants.DISCOVER_BACKCOUNTRY_RESERVATIONS);

            var client = new SmtpClient
            {
                Host = Constants.GMAIL,
                Port = Constants.PORT,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_senderEmail, _senderPw),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            client.Send(message);
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