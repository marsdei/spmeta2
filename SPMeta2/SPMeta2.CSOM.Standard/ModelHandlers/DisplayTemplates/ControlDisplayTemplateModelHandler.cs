﻿using System;
using Microsoft.SharePoint.Client;
using SPMeta2.CSOM.ModelHandlers.Base;
using SPMeta2.CSOM.Standard.ModelHandlers.Base;
using SPMeta2.Enumerations;
using SPMeta2.Standard.Definitions.Base;
using SPMeta2.Standard.Definitions.DisplayTemplates;

namespace SPMeta2.CSOM.Standard.ModelHandlers.DisplayTemplates
{
    public class ControlDisplayTemplateModelHandler : TemplateModelHandlerBase
    {

        public override string FileExtension
        {
            get { return "html"; }
            set
            {

            }
        }

        protected override void MapProperties(object modelHost, ListItem item, TemplateDefinitionBase definition)
        {
            item[BuiltInInternalFieldNames.ContentTypeId] = "0x0101002039C03B61C64EC4A04F5361F385106601";
            //item["DisplayTemplateLevel"] = "Control";

        }

        public override Type TargetType
        {
            get { return typeof(ControlDisplayTemplateDefinition); }
        }
    }
}