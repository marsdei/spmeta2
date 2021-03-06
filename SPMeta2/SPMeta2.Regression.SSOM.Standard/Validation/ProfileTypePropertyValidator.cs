using System;
using Microsoft.SharePoint.Publishing.WebControls;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Base;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Regression.SSOM.Validation;
using SPMeta2.SSOM.Extensions;
using SPMeta2.SSOM.ModelHosts;
using SPMeta2.Standard.Definitions.Webparts;
using SPMeta2.Utils;
using Microsoft.SharePoint.Portal.WebControls;
using Microsoft.Office.Server.Search.WebControls;
using Microsoft.Office.Server.WebControls;
using SPMeta2.Standard.Definitions;
using Microsoft.Office.Server.UserProfiles;


namespace SPMeta2.Regression.SSOM.Standard.Validation.Webparts
{
    public class ProfileTypePropertyValidator : WebPartDefinitionValidator
    {
        #region properties

        public override Type TargetType
        {
            get { return typeof(ProfileTypePropertyDefinition); }
        }

        #endregion

        #region methods

        public override void DeployModel(object modelHost, DefinitionBase model)
        {
            var host = modelHost.WithAssertAndCast<SiteModelHost>("modelHost", value => value.RequireNotNull());
            var typedModel = model.WithAssertAndCast<ProfileTypePropertyValidator>("model", value => value.RequireNotNull());

            ProfileTypeProperty spObject = null;

            var assert = ServiceFactory.AssertService
                                       .NewAssert(typedModel, typedModel)
                                       .ShouldNotBeNull(spObject);
        }

        #endregion
    }
}
