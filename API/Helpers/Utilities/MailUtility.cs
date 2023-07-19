using System.Net;
using System.Net.Mail;

namespace API.Helpers.Utilities
{
    public class MailUtility
    {
        #region Methods

        public static bool Send(string from, string password, string to, string subject, string body, bool isBodyHtml, string host, int port, bool enableSSL, ref Exception error)
        {

            //Khai báo một lá thư
            MailMessage mail = new MailMessage();

            //Khai báo đối tượng gửi thư , người đưa thư
            SmtpClient SmtpServer = new SmtpClient(host);


            //Ghi các giá trị lên lá thư
            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;

            SmtpServer.Port = port;
            SmtpServer.Credentials = new NetworkCredential(from, password);
            SmtpServer.EnableSsl = enableSSL;

            try
            {
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public bool Send()
        {
            Exception error = null;
            bool result = Send(this.From, this.Password, this.To, this.Subject, this.Body, this.IsBodyHtml, this.Host, this.Port, this.EnableSSL, ref error);
            this.Error = error;

            return result;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Trả về hoặc thiết lập giá trị From
        /// </summary>
        public string From
        {
            get;
            set;
        }

        /// <summary>
        /// Trả về hoặc thiết lập Password
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Trả về hoặc thiêế lập điểm đến;
        /// </summary>
        public string To
        {
            get;
            set;

        }

        public string Subject
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public bool IsBodyHtml
        {
            get;
            set;
        }

        public string Host
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public bool EnableSSL
        {
            get;
            set;
        }

        public Exception Error
        {
            get;
            set;
        }

        #endregion

        #region Constructor
        public MailUtility()
        {

        }

        public MailUtility(string from, string password)
        {
            this.From = from;
            this.Password = password;
        }
        #endregion
    }
}