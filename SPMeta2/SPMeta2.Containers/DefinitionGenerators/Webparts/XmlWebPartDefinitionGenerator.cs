using System;
using System.Text;
using SPMeta2.Containers.Services;
using SPMeta2.Containers.Services.Base;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Base;
using SPMeta2.Definitions.Webparts;

namespace SPMeta2.Containers.DefinitionGenerators.Webparts
{
    public class XmlWebPartDefinitionGenerator : TypedDefinitionGeneratorServiceBase<XmlWebPartDefinition>
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
