namespace TestDot1_DOT.Models
{
    public class BukuViewModel
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? NamaBuku { get; set; }
        public string? KodeBuku { get; set; }
        public string? Penerbit { get; set; }
        public string? TahunPenerbit { get; set; }
    }
}
