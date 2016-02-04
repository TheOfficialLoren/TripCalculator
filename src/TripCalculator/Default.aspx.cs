using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TripCalculator.UI
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                }
            }
            catch (Exception ex)
            {
                    Response.Write(ex.ToString());
            }
        }

    }
}