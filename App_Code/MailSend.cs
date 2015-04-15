using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

    class MailSend
    {

        public bool GMailSend(string body)
        {
            try
            {
                MailMessage mail = new MailMessage();

                //前面是發信email後面是顯示的名稱
                mail.From = new MailAddress("Bestmall@spihg.com", "Best嚴選購物網");

                //收信者email
                mail.To.Add("bonnie@spihg.com");
                //mail.CC.Add("bonnie@spihg.com");

                //設定優先權
                mail.Priority = MailPriority.Normal;

                //標題
                mail.Subject = "Best嚴選購物網 廠商登記資訊";

                //內容
                mail.Body = body;

                //內容使用html
                mail.IsBodyHtml = true;

                //設定gmail的smtp
                SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

                //您在gmail的帳號密碼
                MySmtp.Credentials = new System.Net.NetworkCredential("bestmall@spihg.com", ".spihg.com");

                //開啟ssl
                MySmtp.EnableSsl = true;

                //發送郵件
                MySmtp.Send(mail);

                //放掉宣告出來的MySmtp
                MySmtp = null;

                //放掉宣告出來的mail
                mail.Dispose(); 
                       

                return true;//成功
            }
            catch (Exception ex)
            {
                return false;//寄失敗
            }
        }

    }

