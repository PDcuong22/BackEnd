namespace QuanLyDanCu.Models
{
    public class CuDanCanHo
    {
        public int CuDanId { get; set; }
        public int CanHoId { get; set; }
        public CanHo CanHo { get; set; }
        public CuDan CuDan { get; set; }
    }
}
