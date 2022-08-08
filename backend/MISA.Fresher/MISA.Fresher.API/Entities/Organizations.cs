namespace MISA.Fresher.API.Entities
{
    public class Organizations
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string BankAccount { get; set; }
        public DateTime FoundingDate { get; set; }
        public string BankName { get; set; }
        public int IncomeID { get; set; }
        public int TypeID { get; set; }
    }
}
