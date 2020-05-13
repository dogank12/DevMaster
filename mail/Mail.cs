using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    public class Mailer : IMailer
    {
        private Mailer() { }
        public string LastError = "";
        public string Service = "";

        public bool UseDefaultCredentials = false;
        public string Host = "";
        public bool EnableSsl = true;
        public int Port = -1;
        public string UserName = "";
        public string UserPwd = "";

        public Mailer(string Host, bool EnableSsl, int Port, bool UseDefaultCredentials, string UserName, string UserPwd)
        {
            if (UseDefaultCredentials)
                throw new Exception("Use of Default Credentials not supported.");

            this.UseDefaultCredentials = UseDefaultCredentials;
            this.Host = Host;
            this.EnableSsl = EnableSsl;
            this.Port = Port;
            this.UserName = UserName;
            this.UserPwd = UserPwd;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="From">tuple in the form of address, display name</param>
        /// <param name="Recipients">list of tuples in the form of address, display name</param>
        /// <param name="CarbonCopyees">list of tuples in the form of address, display name</param>
        /// <param name="BlindCarbonCopyees">list of tuples in the form of address, display name</param>
        /// <param name="SubjectText">title or subject of email</param>
        /// <param name="BodyText">html formatted text</param>
        public void Send(Tuple<string, string> From, List<Tuple<string, string>> Recipients, List<Tuple<string, string>> CarbonCopyees
            , List<Tuple<string, string>> BlindCarbonCopyees
            , string SubjectText, string BodyText)
        {
            #region //VALIDATION
            if (Recipients.Count == 0)
                if (CarbonCopyees.Count == 0)
                    if (BlindCarbonCopyees.Count == 0)
                        throw new Exception("There are no recipients! You need at least one.");
            #endregion
            //VALIDATION

            System.Net.Mail.MailAddress _fromAddress = new System.Net.Mail.MailAddress(From.Item1.Trim(), From.Item2.Trim());

            System.Net.Mail.MailMessage _email = new System.Net.Mail.MailMessage();
            _email.From = _fromAddress;
            _email.BodyEncoding = System.Text.Encoding.UTF8;
            _email.SubjectEncoding = System.Text.Encoding.UTF8;
            _email.IsBodyHtml = true;

            _email.Subject = SubjectText;
            _email.Body = BodyText;

            _email.To.Clear();
            foreach (var _to in Recipients)
            {
                System.Net.Mail.MailAddress _addr = new System.Net.Mail.MailAddress(_to.Item1.Trim(), _to.Item2.Trim());     //addr, display
                _email.To.Add(_addr);
            }

            foreach (var _bcc in BlindCarbonCopyees)
            {
                _email.Bcc.Add(new System.Net.Mail.MailAddress(_bcc.Item1.Trim(), _bcc.Item2.Trim()));
            }

            foreach (var _cc in CarbonCopyees)
            {
                _email.CC.Add(new System.Net.Mail.MailAddress(_cc.Item1.Trim(), _cc.Item2.Trim()));
            }

            SmtpClient _mailClient = new SmtpClient();

            _mailClient.UseDefaultCredentials = UseDefaultCredentials;

            if (_mailClient.UseDefaultCredentials)
            {

            }
            _mailClient.Host = Host;
            _mailClient.EnableSsl = EnableSsl;
            _mailClient.Port = Port;

            System.Net.NetworkCredential _authenticationInfo = new System.Net.NetworkCredential(UserName, UserPwd);
            _mailClient.Credentials = _authenticationInfo;

            _mailClient.Send(_email);


        }
    }
}
