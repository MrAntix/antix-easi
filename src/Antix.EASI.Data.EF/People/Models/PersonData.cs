using System.Data.Entity.ModelConfiguration;

namespace Antix.EASI.Data.EF.People.Models
{
    public class PersonData
    {
        public string Name { get; set; }

        public class Configuration :
            ComplexTypeConfiguration<PersonData>
        {
            public Configuration()
            {
                Property(d => d.Name)
                    .HasMaxLength(DataContext.NAME_LENGTH);
            }
        }
    }
}