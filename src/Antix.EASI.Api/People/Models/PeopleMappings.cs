using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Api.People.Models
{
    public static class PeopleMappings
    {
        public static Person ToContract(
            this PersonModel model)
        {
            if (model == null) return null;

            return new Person
            {
                Name = model.Name
            };
        }

        public static UpdatePersonModel ToModel(
            this Person contract)
        {
            if (contract == null) return null;

            return new UpdatePersonModel
            {
                Name = contract.Name
            };
        }
    }
}