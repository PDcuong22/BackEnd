using QuanLyDanCu.Data;
using QuanLyDanCu.Interfaces;
using QuanLyDanCu.Models;

namespace QuanLyDanCu.Repository
{
    public class CuDanRepository : ICuDanRepository
    {
        private readonly DataContext _context;
        public CuDanRepository(DataContext context) 
        {
            _context = context;
        }

        public bool AddCuDanForCanHo(int cuDanId, int canHoId)
        {
            var cuDanRequest = _context.CuDans.Where(c => c.Id == cuDanId).FirstOrDefault();
            var canHoRequest = _context.CanHos.Where(ch => ch.Id == canHoId).FirstOrDefault();
            var cuDanCanHo = new CuDanCanHo()
            {
                CanHo = canHoRequest,
                CuDan = cuDanRequest,
            };

            _context.Add(cuDanCanHo);
            return Save();
        }

        public bool CreateCuDan(CuDan cuDan)
        {
           // var cuDanCanHoEntity = _context.CanHos.Where(c => c.Id == canHoId).FirstOrDefault();
           /*
            var cuDanCanHo = new CuDanCanHo()
            {
               // CanHo = cuDanCanHoEntity,
                CuDan = cuDan,
            };
           */
           // _context.Add(cuDanCanHo);
            _context.Add(cuDan);

            return Save();
        }


        public bool CuDanExist(int cuDanId)
        {
            return _context.CuDans.Any(c => c.Id == cuDanId);
        }

        public bool DeleteCuDan(CuDan cuDan)
        {
            _context.Remove(cuDan);
            return Save();
        }

        public ICollection<CanHo> GetCanHoByCuDan(int cuDanId)
        {
            return _context.CuDanCanHos.Where(e => e.CuDanId == cuDanId).Select(c => c.CanHo).ToList();
        }

        public CuDan GetCuDan(int id)
        {
            return _context.CuDans.Where(c => c.Id == id).FirstOrDefault();
        }

        public CuDan GetCuDan(string name)
        {
            return _context.CuDans.Where(c => c.Name == name).FirstOrDefault();
        }

        public ICollection<CuDan> GetCuDans() 
        {
            return _context.CuDans.OrderBy(c => c.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCuDan(CuDan cuDan)
        {
            _context.Update(cuDan);
            return Save();
        }
    }
}
