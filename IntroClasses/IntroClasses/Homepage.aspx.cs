using IntroClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace IntroClasses
{
    public partial class Homepage : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["SchoolConnectionString1"].ConnectionString;
        Person person = new Person("Bob");
        Student student = new Student();
        protected void Page_Load(object sender, EventArgs e)
        {
            person.Name = "Earl";

            lbl_output.Text = person.Name;


        }

        protected void btn_change_Click(object sender, EventArgs e)
        {
            string new_name = txt_input.Text;
            person.Name = new_name;
            lbl_output.Text = person.Name;
        }

        protected void btn_show_Click(object sender, EventArgs e)
        {
            Database db = new Database(cs);
            gv1.DataSource = db.Select("SELECT * FROM Pupils");
            gv1.DataBind();
            db.Close();
        }
    }
}