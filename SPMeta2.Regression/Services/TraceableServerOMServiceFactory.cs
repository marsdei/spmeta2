﻿using SPMeta2.SSOM;
using SPMeta2.SSOM.Services;

namespace SPMeta2.Regression.Services
{
    public class TraceableServerOMServiceFactory : SSOMProvisionService
    {
        #region contructors

        public TraceableServerOMServiceFactory()
        {
            //ModelService.OnDeployingModel += (s, a) => Trace.WriteLine(string.Format("Deploying model: [{0}]", a.Model.ToString()));
            //ModelService.OnDeployedModel += (s, a) => Trace.WriteLine(string.Format("Deployed model: [{0}]", a.Model.ToString()));
        }

        #endregion
    }
}
