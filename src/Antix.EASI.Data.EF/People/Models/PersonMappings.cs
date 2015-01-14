using Antix.EASI.Domain.People.Models;

namespace Antix.EASI.Data.EF.People.Models
{
    public static class PersonMappings
    {
        public static void Map(
            this PersonData data, UpdatePersonModel model)
        {
            data.Name = model.Name;
        }
    }
}