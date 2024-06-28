using TestDot1_DOT.Repositories.Entities;
using TestDot1_DOT.Repositories.Interface;

namespace TestDot1_DOT.Repositories.Repositories
{
    public class DataPinjamanRepository: IDataPinjamanRepository
    {
        private readonly Test_DOTContext _contex;

        public DataPinjamanRepository(Test_DOTContext context) =>
            _contex = context;
        public void Create(TbliDataPinjaman entity)
        {

            //entity = model;
            _contex.Set<TbliDataPinjaman>().Add(entity);
            _contex.SaveChanges();
        }
        //public TblsUser GetUser(TblsUser user)
        //{

        //}
        //public TblsUser Update(TblsUser user)
        //{

        //}
        //public TblsUser Delete(TblsUser user)
        //{

        //}
    }
}
