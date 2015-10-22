using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using Microsoft.SharePoint.WebPartPages;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Services;
using SPMeta2.SSOM.ModelHosts;
using SPMeta2.Utils;
using WebPart = System.Web.UI.WebControls.WebParts.WebPart;

namespace SPMeta2.SSOM.ModelHandlers.Webparts
{
    public class ImageWebPartModelHandler : WebPartModelHandler
    {
        #region properties

        public override Type TargetType
        {
            get { return typeof(ImageWebPartDefinition); }
        }

        #endregion

        #region methods

        protected override void ProcessWebpartProperties(WebPart webpartInstance, WebPartDefinition webpartModel)
        {
            base.ProcessWebpartProperties(webpartInstance, webpartModel);

            var typedWebpart = webpartInstance.WithAssertAndCast<ImageWebPart>("webpartInstance", value => value.RequireNotNull());
            var definition = webpartModel.WithAssertAndCast<ImageWebPartDefinition>("webpartModel", value => value.RequireNotNull());

            // TODO, specific provision
        }

        #endregion
    }
}
