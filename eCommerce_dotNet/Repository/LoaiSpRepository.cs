using eCommerce_dotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce_dotNet.Repository
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly MasterContext _masterContext;

        public LoaiSpRepository(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }

        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _masterContext.TLoaiSps.Add(loaiSp);  // Add entity to DbSet
            _masterContext.SaveChanges();         // Save changes to the database
            return loaiSp;
        }

        public TLoaiSp Delete(string maloaiSp)
        {
            var loaiSp = _masterContext.TLoaiSps.Find(maloaiSp); // Find entity by key
            if (loaiSp != null)
            {
                _masterContext.TLoaiSps.Remove(loaiSp);  // Remove entity from DbSet
                _masterContext.SaveChanges();            // Save changes to the database
            }
            return loaiSp;
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _masterContext.TLoaiSps; // Return all records from the table
        }

        public TLoaiSp GetLoaiSp(string maloaiSp)
        {
            return _masterContext.TLoaiSps.Find(maloaiSp); // Find and return entity by primary key
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _masterContext.TLoaiSps.Update(loaiSp); // Update entity in DbSet
            _masterContext.SaveChanges();           // Save changes to the database
            return loaiSp;
        }
    }
}
