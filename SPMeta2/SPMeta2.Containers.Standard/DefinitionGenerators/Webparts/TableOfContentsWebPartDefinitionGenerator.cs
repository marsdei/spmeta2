using System;
using SPMeta2.Containers.Services.Base;
using SPMeta2.Definitions;
using SPMeta2.Standard.Definitions.Webparts;

namespace SPMeta2.Containers.Standard.DefinitionGenerators.Webparts
{
    public class TableOfContentsWebPartDefinitionGenerator : TypedDefinitionGeneratorServiceBase<TableOfContentsWebPartDefinition>
    {
        public override DefinitionBase GenerateRandomDefinition(Action<DefinitionBase> action)
        {
            return WithEmptyDefinition(def =>
            {
                // TODO
            });
        }
    }
}
