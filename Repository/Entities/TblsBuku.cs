using System;
using System.Collections.Generic;

namespace TestDot1_DOT.Repositories.Entities
{
    public partial class TblsBuku
    {
        public TblsBuku()
        {
            TbliDataPinjamen = new HashSet<TbliDataPinjaman>();
        }

        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? NamaBuku { get; set; }
        public string? KodeBuku { get; set; }
        public string? Penerbit { get; set; }
        public string? TahunPenerbit { get; set; }

        public virtual ICollection<TbliDataPinjaman> TbliDataPinjamen { get; set; }
    }
}
