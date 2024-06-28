using System;
using System.Collections.Generic;

namespace TestDot1_DOT.Repositories.Entities
{
    public partial class TblsUser
    {
        public TblsUser()
        {
            TbliDataPinjamen = new HashSet<TbliDataPinjaman>();
        }

        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? NamaLengkap { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string? NoTelp { get; set; }
        public string? AlamatRumah { get; set; }
        public string? KodeSiswa { get; set; }

        public virtual ICollection<TbliDataPinjaman> TbliDataPinjamen { get; set; }
    }
}
