using System.Net;
using System.Net.Mail;

public class EmailService
{
	public async Task SendEmail(string emailAddress, string subject, string body)
	{
		string smtpServer = "smtp.elasticemail.com";
		int port = 2525;
		string username = "as2489@fayoum.edu.eg";
		string password = "01123248047ms";
		bool enableSsl = true;

		using (SmtpClient client = new SmtpClient(smtpServer, port))
		{
			client.EnableSsl = enableSsl;
			client.UseDefaultCredentials = false;
			client.Credentials = new NetworkCredential(username, password);

			MailMessage mailMessage = new MailMessage("noreply@example.com", emailAddress, subject, body);
			mailMessage.IsBodyHtml = true;
			await client.SendMailAsync(mailMessage);
		}
	}

}
