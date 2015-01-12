using System;
using Newtonsoft.Json.Serialization;

namespace Antix.EASI.Web.Configuration
{
    public class SpecialCamelCasePropertyNamesContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            var contract = base.CreateDictionaryContract(objectType);

            contract.PropertyNameResolver = propertyName => propertyName;

            return contract;
        }
    }
}