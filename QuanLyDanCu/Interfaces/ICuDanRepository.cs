using QuanLyDanCu.Models;

namespace QuanLyDanCu.Interfaces
{
    public interface ICuDanRepository
    {
        ICollection<CuDan> GetCuDans();
        CuDan GetCuDan(int id);
        CuDan GetCuDan(string name);
        ICollection<CanHo> GetCanHoByCuDan(int cuDanId);
        bool CuDanExist(int cuDanId);
        bool CreateCuDan(CuDan cuDan);
        bool UpdateCuDan(CuDan cuDan);
        bool DeleteCuDan(CuDan cuDan);
        bool AddCuDanForCanHo(int cuDanId, int canHoId);
        bool Save();
    }
}
