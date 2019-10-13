using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AutoFocus_CodeFirst.Email
{
    public class EmailFunctionality
    {
        private const String API_KEY = "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";

        public void Send(String toEmail,String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@AutoFocus.com", "Auto-Focus Rent A Car");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

    }
}
