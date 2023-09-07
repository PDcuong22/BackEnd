using QuanLyDanCu.Models;

namespace QuanLyDanCu.Interfaces
{
    public interface ICanHoRepository
    {
        ICollection<CanHo> GetCanHos();
        CanHo GetCanHo(int id);
        ICollection<CuDan> GetCuDanByCanHo(int canHoId);
        bool CreateCanHo(CanHo canHo);
        bool UpdateCanHo(CanHo canHo);
        bool DeleteCanHo(CanHo canHo);
        bool CanHoExists(int canHoId);
        bool Save();
    }
}
