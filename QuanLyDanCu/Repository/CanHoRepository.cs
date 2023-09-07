using QuanLyDanCu.Data;
using QuanLyDanCu.Interfaces;
using QuanLyDanCu.Models;

namespace QuanLyDanCu.Repository
{
    public class CanHoRepository : ICanHoRepository
    {
        private readonly DataContext _context;

        public CanHoRepository(DataContext context)
        {
            _context = context;
        }
        public bool CanHoExists(int canHoId)
        {
            return _context.CanHos.Any(c => c.Id == canHoId);
        }

        public bool CreateCanHo(CanHo canHo)
        {
            _context.Add(canHo);
            return Save();
        }

        public bool DeleteCanHo(CanHo canHo)
        {
            _context.Remove(canHo);
            return Save();
        }

        public CanHo GetCanHo(int id)
        {
            return _context.CanHos.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<CanHo> GetCanHos()
        {
            return _context.CanHos.OrderBy(c => c.Id).ToList();
        }

        public ICollection<CuDan> GetCuDanByCanHo(int canHoId)
        {
            return _context.CuDanCanHos.Where(e => e.CanHoId == canHoId).Select(c => c.CuDan).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCanHo(CanHo canHo)
        {
            _context.Update(canHo);
            return Save();
        }
    }
}
