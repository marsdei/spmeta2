﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using SPMeta2.Definitions;
using SPMeta2.Validation.Common;
using SPMeta2.Validation.Extensions;
using SPMeta2.Validation.Services;

namespace SPMeta2.Validation.Validators.Definitions
{
    public class ContentTypeDefinitionValidator : DefinitionBaseValidator
    {
        public override void Validate(DefinitionBase definition, List<ValidationResult> result)
        {
            Validate<ContentTypeDefinition>(definition, model =>
            {
                model
                    .NotEmptyString(m => m.Name, result)
                    .NoSpacesBeforeOrAfter(m => m.Name, result)

                    .NotEmptyString(m => m.Description, result)
                    .NoSpacesBeforeOrAfter(m => m.Description, result)

                    .NotEmptyString(m => m.Group, result)
                    .NoSpacesBeforeOrAfter(m => m.Group, result)

                    .NotEmptyString(m => m.ParentContentTypeId, result);

                if (model.Id == default(Guid))
                    model.NotEmptyString(m => m.IdNumberValue, result);
            });
        }
    }
}
