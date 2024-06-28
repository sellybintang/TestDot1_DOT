namespace TestDot1_DOT.Models
{
    public class DataPinjamanViewModel
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? UserId { get; set; }
        public string? KodeSiswa { get; set; }
        public Guid? PinjamanBukuId { get; set; }
        public string? KodeBuku { get; set; }
        public DateTime? WaktuPinjaman { get; set; }
        public DateTime? WaktuPengembalian { get; set; }
    }
}
