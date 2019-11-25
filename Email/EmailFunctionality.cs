﻿using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace AutoFocus_CodeFirst.Email
{
    public class EmailFunctionality
    {


    private const String API_KEY = "";
        List<String> Emails = new List<string>();

        




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



        public void SendBulkEmail(String Bulk)
        {
            String subject = "Hello Everybody!";
            String contents = "Hello and Welcome to Auto-Focus! We are currently having tons of offers on our website! Please do" +
                "check us out at Auto-Focus.io";
         
                var client = new SendGridClient(API_KEY);
                var from = new EmailAddress("noreply@AutoFocus.com", "Auto-Focus Rent A Car");
                var to = new EmailAddress(Bulk, "");
                var plainTextContent = contents;
                var htmlContent = "<p>" + contents + "</p>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var bytes = File.ReadAllBytes("C:/Users/Mashaal/Documents/FIT-5032-Internet_App_Dev/AutoFocus_Attachment.pdf");
                var file = Convert.ToBase64String(bytes);
                msg.AddAttachment("AutoFocusPromo.pdf", file);
                var response = client.SendEmailAsync(msg);
           
   
        }

    }
}

