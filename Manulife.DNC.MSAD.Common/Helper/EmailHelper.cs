using MailKit.Net.Smtp;
using MimeKit;
using System.Text;
using Newtonsoft.Json;
using System;

namespace Manulife.DNC.MSAD.Common
{
    public class EmailHelper
    {
        public static void SendHealthEmail(EmailSettings settings, string content)
        {
            try
            {
                dynamic list = JsonConvert.DeserializeObject(content);
                if (list != null && list.Count > 0)
                {
                    var emailBody = new StringBuilder("健康检查故障:\r\n");
                    foreach (var noticy in list)
                    {
                        emailBody.AppendLine($"--------------------------------------");
                        emailBody.AppendLine($"Node:{noticy.Node}");
                        emailBody.AppendLine($"Service ID:{noticy.ServiceID}");
                        emailBody.AppendLine($"Service Name:{noticy.ServiceName}");
                        emailBody.AppendLine($"Check ID:{noticy.CheckID}");
                        emailBody.AppendLine($"Check Name:{noticy.Name}");
                        emailBody.AppendLine($"Check Status:{noticy.Status}");
                        emailBody.AppendLine($"Check Output:{noticy.Output}");
                        emailBody.AppendLine($"--------------------------------------");
                    }

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(settings.FromWho, settings.FromAccount));
                    message.To.Add(new MailboxAddress(settings.ToWho, settings.ToAccount));

                    message.Subject = settings.Subject;
                    message.Body = new TextPart("plain") { Text = emailBody.ToString() };
                    using (var client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        client.Connect(settings.SmtpServer, settings.SmtpPort, false);
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        client.Authenticate(settings.AuthAccount, settings.AuthPassword);
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async void SendHealthEmailAsync(EmailSettings settings, string content)
        {
            try
            {
                dynamic list = JsonConvert.DeserializeObject(content);
                if (list != null && list.Count > 0)
                {
                    var emailBody = new StringBuilder("健康检查故障:\r\n");
                    foreach (var noticy in list)
                    {
                        emailBody.AppendLine($"--------------------------------------");
                        emailBody.AppendLine($"Node:{noticy.Node}");
                        emailBody.AppendLine($"Service ID:{noticy.ServiceID}");
                        emailBody.AppendLine($"Service Name:{noticy.ServiceName}");
                        emailBody.AppendLine($"Check ID:{noticy.CheckID}");
                        emailBody.AppendLine($"Check Name:{noticy.Name}");
                        emailBody.AppendLine($"Check Status:{noticy.Status}");
                        emailBody.AppendLine($"Check Output:{noticy.Output}");
                        emailBody.AppendLine($"--------------------------------------");
                    }

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(settings.FromWho, settings.FromAccount));
                    message.To.Add(new MailboxAddress(settings.ToWho, settings.ToAccount));

                    message.Subject = settings.Subject;
                    message.Body = new TextPart("plain") { Text = emailBody.ToString() };
                    using (var client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        await client.ConnectAsync(settings.SmtpServer, settings.SmtpPort, false);
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        await client.AuthenticateAsync(settings.AuthAccount, settings.AuthPassword);
                        await client.SendAsync(message);
                        await client.DisconnectAsync(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
