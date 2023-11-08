using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.email
{
    public class EmailService : IEmailService
    {
        public void SendDummyPasswordToEmail(string email, string password)
        {
            MailMessage mailMsg = new MailMessage();
            //validacija regexa meila
            mailMsg.To.Add(email);

            MailAddress mailAddress = new MailAddress("svenadev@gmail.com");
            mailMsg.From = mailAddress;

            mailMsg.Subject = "Privremena lozinka za prijavu na SveNaDev aplikaciju.";
            mailMsg.Body = "Postovani," +
                "\nVasa lozinka je: " + password +
                "\nMozete se ulogovati klikom na sledeci link: " +
                "http://localhost:4200/login";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("svenadev", "qzbkcnzoebbfuvoy");
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMsg);
        }
    }
}
