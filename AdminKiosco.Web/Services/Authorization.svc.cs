using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using AdminKiosco.Common;

namespace AdminKiosco.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [JSONPSupportBehavior]
    public class Authorization
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public bool Authorize(string table, string action, string roles)
        {
            List<Guid> _roles = new List<Guid>();
            foreach(string rol in roles.Split('|'))
            {
                _roles.Add(new Guid(rol));
            }
            return AuthorizationConfig.Authorize(table, action, _roles);
        }
    }
}
