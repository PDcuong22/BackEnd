namespace QuanLyDanCu.Models
{
    public class CuDan
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ThuongTru { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? SDT { get; set; }
        public ICollection<CuDanCanHo> CuDanCanHos { get; set; }
    }
}
