namespace webapi.Services
{
    public class EmailService
    {
        private readonly ILogger<EmailService> _logger;
        public EmailService(ILogger<EmailService> Logger)
        {
            _logger = Logger;
        }
        public bool SendEmail
        (
            string From,
            string To,
            string Subject,
            string Message
        ){
            _logger.LogInformation($"From: {From}. To: {To}. Subject: {Subject}. Message: {Message}");
            return true;
        }
    }
}