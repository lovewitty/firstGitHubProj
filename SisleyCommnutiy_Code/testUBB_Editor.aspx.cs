using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testUBB_Editor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UBB.UBB_Class ubb = new UBB.UBB_Class();
        Response.Write(ubb.UBBToHtml(UBBTextBox1.Value.Trim()));
    }

}