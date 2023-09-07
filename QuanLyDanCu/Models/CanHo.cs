namespace QuanLyDanCu.Models
{
    public class CanHo
    {
        public int Id { get; set; }
        public double DienTich { get; set; }
        public string DiaChi { get; set; }
        public ICollection<CuDanCanHo> CuDanCanHos { get; set; }
    }
}
