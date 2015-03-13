﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SPMeta2.Attributes;
using SPMeta2.Attributes.Regression;
using SPMeta2.Definitions.Base;
using SPMeta2.Utils;

namespace SPMeta2.Definitions.Webparts
{
    /// <summary>
    /// Allows to define and deploy 'Content Editor' web part.
    /// </summary>
    [SPObjectType(SPObjectModelType.SSOM, "System.Web.UI.WebControls.WebParts.WebPart", "System.Web")]
    [SPObjectType(SPObjectModelType.CSOM, "Microsoft.SharePoint.Client.WebParts.WebPart", "Microsoft.SharePoint.Client")]

    [DefaultRootHost(typeof(WebDefinition))]
    [DefaultParentHost(typeof(WebPartPageDefinition))]

    [Serializable]
    [ExpectArrayExtensionMethod]

    public class ContentEditorWebPartDefinition : WebPartDefinition
    {
        #region properties

        public string Content { get; set; }

        [ExpectValidation]
        public string ContentLink { get; set; }

        #endregion

        #region methods

        public override string ToString()
        {
            return new ToStringResult<ContentEditorWebPartDefinition>(this, base.ToString())
                          .AddPropertyValue(p => p.Content)
                          .AddPropertyValue(p => p.ContentLink)
                          .ToString();
        }

        #endregion
    }
}
