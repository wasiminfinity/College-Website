using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class Contact_Us : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string sourcemail, destinationmail, message, name;
            sourcemail = txtEmail.Text;
            destinationmail = "website.dpi2017@gmail.com";
            name = txtName.Text;
            message = "Name :" + name + Environment.NewLine + "Email :" + txtEmail.Text + Environment.NewLine + "Message :" + txtMessage.Text;

            MailMessage mail = new MailMessage("website.dpi2017@gmail.com", destinationmail, name, message);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("website.dpi@gmail.com", "sanprasim356");

            smtp.Send(mail);
            Label1.Text = "Your mail was sent successfully. Thank you for contacting us.";

            txtName.Text = "";
            txtEmail.Text = "";
            txtMessage.Text = "";


        }
        catch
        {
            Label1.Text = "Your mail was not sent";
            txtName.Text = "";
            txtEmail.Text = "";
            txtMessage.Text = "";

        }
    }
}