using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete {
    public class EmailOrderProcessor : IOrderProcessor {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings emailSettings) {
            this.emailSettings = emailSettings;
        }

        public void ProcessorOrder(Cart cart, ShippingDetails shippingDetails) {
            using (var smtpClient = new SmtpClient()) {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.Password);

                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ была отправлен")
                    .AppendLine("---")
                    .AppendLine("Элементы:");

                foreach (var item in cart.Lines) {
                    var subtotal = item.Product.Price * item.Quantity;
                    body.AppendFormat("{0} x {1} (промежуточный итог: {2:c}",
                        item.Quantity,
                        item.Product.Name,
                        subtotal);
                }

                body.AppendFormat("Total order value: {0:c}",
                    cart.ComputeTotalPrice())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingDetails.Name)
                    .AppendLine(shippingDetails.Line1)
                    .AppendLine(shippingDetails.Line2 ?? "")
                    .AppendLine(shippingDetails.Line3 ?? "")
                    .AppendLine(shippingDetails.City)
                    .AppendLine(shippingDetails.State ?? "")
                    .AppendLine(shippingDetails.Country)
                    .AppendLine(shippingDetails.Zip)
                    .AppendLine("---")
                    .AppendFormat("Подарочная упаковка: {0}",
                        shippingDetails.GiftWrap ? "Да" : "Нет");

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress,
                    emailSettings.MailToAddress,
                    "Новый заказ отправлен!",
                    body.ToString());

                smtpClient.Send(mailMessage);
            }
        }
    }
}
