using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Testrili : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        
        Response.Write(this.Calendar1.SelectedDate.ToShortDateString());
    }
}
