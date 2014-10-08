﻿using System;
using System.Linq;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using SPMeta2.Common;
using SPMeta2.CSOM.ModelHandlers;
using SPMeta2.CSOM.Standard.ModelHosts;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Taxonomy;
using SPMeta2.Utils;

namespace SPMeta2.CSOM.Standard.ModelHandlers.Taxonomy
{
    public class TaxonomyGroupModelHandler : CSOMModelHandlerBase
    {
        #region properties

        public override Type TargetType
        {
            get { return typeof(TaxonomyGroupDefinition); }
        }

        #endregion

        #region methods

        public override void DeployModel(object modelHost, DefinitionBase model)
        {
            var siteModelHost = modelHost.WithAssertAndCast<TermStoreModelHost>("modelHost", value => value.RequireNotNull());
            var groupModel = model.WithAssertAndCast<TaxonomyGroupDefinition>("model", value => value.RequireNotNull());

            DeployTaxonomyGroup(modelHost, siteModelHost, groupModel);
        }

        public override void WithResolvingModelHost(object modelHost, DefinitionBase model, Type childModelType, Action<object> action)
        {
            var storeModelHost = modelHost.WithAssertAndCast<TermStoreModelHost>("modelHost", value => value.RequireNotNull());
            var groupModel = model.WithAssertAndCast<TaxonomyGroupDefinition>("model", value => value.RequireNotNull());

            var termStore = storeModelHost.HostTermStore;
            var currentGroup = FindGroup(termStore, groupModel);

            action(new TermGroupModelHost
            {
                HostTermStore = termStore,
                HostGroup = currentGroup
            });
        }

        protected TermGroup FindGroup(TermStore termStore, TaxonomyGroupDefinition groupModel)
        {
            var context = termStore.Context;

            TermGroup currentGroup = null;

            if (groupModel.Id.HasValue)
                currentGroup = termStore.GetGroup(groupModel.Id.Value);
            else if (!string.IsNullOrEmpty(groupModel.Name))
            {
                context.Load(termStore.Groups, g => g.Include(t => t.Name));
                context.ExecuteQuery();

                currentGroup = termStore.Groups.FirstOrDefault(g => g.Name.ToUpper() == groupModel.Name.ToUpper());
            }

            if (currentGroup != null)
            {
                context.Load(currentGroup, g => g.Id);
                context.Load(currentGroup, g => g.Name);

                context.ExecuteQuery();
            }

            return currentGroup;
        }

        private void DeployTaxonomyGroup(object modelHost, TermStoreModelHost siteModelHost, TaxonomyGroupDefinition groupModel)
        {
            var termStore = siteModelHost.HostTermStore;
            var currentGroup = FindGroup(termStore, groupModel);

            InvokeOnModelEvent(this, new ModelEventArgs
            {
                CurrentModelNode = null,
                Model = null,
                EventType = ModelEventType.OnProvisioning,
                Object = currentGroup,
                ObjectType = typeof(TermGroup),
                ObjectDefinition = groupModel,
                ModelHost = modelHost
            });

            if (currentGroup == null)
            {
                currentGroup = groupModel.Id.HasValue
                                        ? termStore.CreateGroup(groupModel.Name, groupModel.Id.Value)
                                        : termStore.CreateGroup(groupModel.Name, Guid.NewGuid());

                InvokeOnModelEvent(this, new ModelEventArgs
                {
                    CurrentModelNode = null,
                    Model = null,
                    EventType = ModelEventType.OnProvisioned,
                    Object = currentGroup,
                    ObjectType = typeof(TermGroup),
                    ObjectDefinition = groupModel,
                    ModelHost = modelHost
                });

            }
            else
            {
                InvokeOnModelEvent(this, new ModelEventArgs
                {
                    CurrentModelNode = null,
                    Model = null,
                    EventType = ModelEventType.OnProvisioned,
                    Object = currentGroup,
                    ObjectType = typeof(TermGroup),
                    ObjectDefinition = groupModel,
                    ModelHost = modelHost
                });
            }
        }

        #endregion
    }
}
