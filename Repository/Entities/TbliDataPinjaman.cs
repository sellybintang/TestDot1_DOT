using System;
using System.Collections.Generic;

namespace TestDot1_DOT.Repositories.Entities
{
    public partial class TbliDataPinjaman
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

        public virtual TblsBuku? PinjamanBuku { get; set; }
        public virtual TblsUser? User { get; set; }
    }
}
