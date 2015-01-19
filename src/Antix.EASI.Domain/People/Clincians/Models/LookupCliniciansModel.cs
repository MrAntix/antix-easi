namespace Antix.EASI.Domain.People.Clincians.Models
{
    public class LookupCliniciansModel
    {
        int _count;

        public string Text { get; set; }

        public int Index { get; set; }

        public int Count
        {
            get { return _count < 5 ? 5 : _count > 20 ? 20 : _count; }
            set { _count = value; }
        }

        public static readonly LookupCliniciansModel Default
            = new LookupCliniciansModel
            {
                Text = null,
                Index = 0,
                Count = 10
            };
    }
}