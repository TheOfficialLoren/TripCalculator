using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TripCalculator.Models;
using TripCalculator.Services;

namespace TripCalculator.UI
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public CalculationResponse CalculateExpenses(CalculationRequest request)
        {
            return CalculationService.CalculateExpenses(request);
        }
    }
}
