using System;
using System.Collections.Generic;
using System.Linq;

namespace Lad_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student() { msv="1", hoTen="Nguyen Van A", ngSinh=new DateTime(2000,1,1), gioiTinh=true, email="A@gmail.com", sdt="01234567", nganhHoc="CNTT", dtb=7.5f, trangThai=true },
                new Student() { msv="2", hoTen="Nguyen Van B", ngSinh=new DateTime(2001,2,2), gioiTinh=false, email="B@gmail.com", sdt="01234568", nganhHoc="Kinh tế", dtb=8.2f, trangThai=true },
                new Student() { msv="3", hoTen="Nguyen Van C", ngSinh=new DateTime(2002,3,3), gioiTinh=true, email="C@gmail.com", sdt="01234569", nganhHoc="CNTT", dtb=9.0f, trangThai=false }
            };

            string choise;
            do
            {
                menu();
                Console.Write("Mời chọn: ");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1": ThemSinhVien(students); break;
                    case "2": HienThiThongTin(students); break;
                    case "3": TimTheoMa(students); break;
                    case "4": TimGanDungTheoTen(students); break;
                    case "5": CapNhatSinhVien(students); break;
                    case "6": XoaSinhVien(students); break;
                    case "7": SapXepTheoHoTen(students); break;
                    case "8": SapXepTheoDTB(students); break;
                    case "9": SinhVienLonHon8(students); break;
                    case "10": SinhVienDiemMax(students); break;
                    case "11": DTBAll(students); break;
                    case "12": ThongKeTheoNganh(students); break;
                    case "13": ThongKeTheoTrangThai(students); break;
                    case "14": Console.WriteLine("Kết thúc chương trình."); break;
                    default: Console.WriteLine("Nhập sai, vui lòng thử lại."); break;
                }
            } while (choise != "14");
        }

        static void menu()
        {
            Console.WriteLine("\nChọn chức năng:");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Hiển thị danh sách");
            Console.WriteLine("3. Tìm sinh viên theo mã");
            Console.WriteLine("4. Tìm gần đúng theo họ tên");
            Console.WriteLine("5. Cập nhật sinh viên");
            Console.WriteLine("6. Xóa sinh viên");
            Console.WriteLine("7. Sắp xếp theo họ tên");
            Console.WriteLine("8. Sắp xếp theo điểm trung bình");
            Console.WriteLine("9. Sinh viên có điểm >= 8");
            Console.WriteLine("10. Sinh viên có điểm cao nhất");
            Console.WriteLine("11. Điểm trung bình toàn bộ sinh viên");
            Console.WriteLine("12. Thống kê sinh viên theo ngành");
            Console.WriteLine("13. Thống kê sinh viên theo trạng thái");
            Console.WriteLine("14. Thoát");
        }

        static void HienThiThongTin(List<Student> students)
        {
            Console.WriteLine("\nDanh sách sinh viên:");
            foreach (var sv in students)
            {
                Console.WriteLine($"MSV: {sv.msv}, Họ tên: {sv.hoTen}, Ngày sinh: {sv.ngSinh.ToShortDateString()}, Giới tính: {(sv.gioiTinh ? "Nam" : "Nữ")}, Email: {sv.email}, SĐT: {sv.sdt}, Ngành: {sv.nganhHoc}, DTB: {sv.dtb}, Trạng thái: {(sv.trangThai ? "Đang học" : "Tốt nghiệp")}");
            }
        }

        static void ThemSinhVien(List<Student> students)
        {
            Student sv = new Student();

            Console.Write("Nhập mã SV: ");
            sv.msv = Console.ReadLine();
            if (students.Any(s => s.msv == sv.msv))
            {
                Console.WriteLine(" Mã sinh viên đã tồn tại!");
                return;
            }

            Console.Write("Nhập họ tên: ");
            sv.hoTen = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sv.hoTen))
            {
                Console.WriteLine(" Họ tên không được rỗng!");
                return;
            }

            Console.Write("Nhập ngày sinh (yyyy-MM-dd): ");
            sv.ngSinh = DateTime.Parse(Console.ReadLine());

            Console.Write("Giới tính (Nam=1, Nữ=0): ");
            sv.gioiTinh = Console.ReadLine() == "1";

            Console.Write("Nhập email: ");
            sv.email = Console.ReadLine();
            if (!sv.email.Contains("@") || !sv.email.Contains("."))
            {
                Console.WriteLine(" Email không đúng định dạng!");
                return;
            }

            Console.Write("Nhập SĐT: ");
            sv.sdt = Console.ReadLine();

            Console.Write("Nhập ngành học: ");
            sv.nganhHoc = Console.ReadLine();

            Console.Write("Nhập điểm TB: ");
            sv.dtb = float.Parse(Console.ReadLine());
            if (sv.dtb < 0 || sv.dtb > 10)
            {
                Console.WriteLine(" Điểm trung bình phải từ 0 đến 10!");
                return;
            }

            Console.Write("Trạng thái (Đang học=1, Tốt nghiệp=0): ");
            sv.trangThai = Console.ReadLine() == "1";

            students.Add(sv);
            Console.WriteLine(" Thêm sinh viên thành công!");
        }


        static void TimTheoMa(List<Student> students)
        {
            Console.Write("Nhập mã SV cần tìm: ");
            string ma = Console.ReadLine();
            var sv = students.FirstOrDefault(s => s.msv == ma);
            if (sv != null) Console.WriteLine($"Tìm thấy: {sv.hoTen}, DTB: {sv.dtb}");
            else Console.WriteLine("Không tìm thấy.");
        }

        static void TimGanDungTheoTen(List<Student> students)
        {
            Console.Write("Nhập tên gần đúng: ");
            string ten = Console.ReadLine();
            var list = students.Where(s => s.hoTen.Contains(ten)).ToList();
            HienThiThongTin(list);
        }

        static void CapNhatSinhVien(List<Student> students)
        {
            Console.Write("Nhập mã SV cần cập nhật: ");
            string ma = Console.ReadLine();
            var sv = students.FirstOrDefault(s => s.msv == ma);
            if (sv != null)
            {
                Console.Write("Nhập họ tên mới: "); sv.hoTen = Console.ReadLine();
                Console.Write("Nhập email mới: "); sv.email = Console.ReadLine();
                Console.Write("Nhập SĐT mới: "); sv.sdt = Console.ReadLine();
                Console.Write("Nhập điểm TB mới: "); sv.dtb = float.Parse(Console.ReadLine());
                Console.Write("Nhập ngành mới: "); sv.nganhHoc = Console.ReadLine();
                Console.Write("Nhập trạng thái mới (1=Đang học,0=Tốt nghiệp): "); sv.trangThai = Console.ReadLine() == "1";
            }
            else Console.WriteLine("Không tìm thấy.");
        }

        static void XoaSinhVien(List<Student> students)
        {
            Console.Write("Nhập mã SV cần xóa: ");
            string ma = Console.ReadLine();
            var sv = students.FirstOrDefault(s => s.msv == ma);
            if (sv != null) students.Remove(sv);
            else Console.WriteLine("Không tìm thấy.");
        }

        static void SapXepTheoHoTen(List<Student> students)
        {
            var list = students.OrderBy(s => s.hoTen).ToList();
            HienThiThongTin(list);
        }

        static void SapXepTheoDTB(List<Student> students)
        {
            var list = students.OrderByDescending(s => s.dtb).ToList();
            HienThiThongTin(list);
        }

        static void SinhVienLonHon8(List<Student> students)
        {
            var list = students.Where(s => s.dtb >= 8).ToList();
            HienThiThongTin(list);
        }

        static void SinhVienDiemMax(List<Student> students)
        {
            float max = students.Max(s => s.dtb);
            var list = students.Where(s => s.dtb == max).ToList();
            HienThiThongTin(list);
        }

        static void DTBAll(List<Student> students)
        {
            float tb = students.Average(s => s.dtb);
            Console.WriteLine($"Điểm trung bình toàn bộ SV: {tb}");
        }

        static void ThongKeTheoNganh(List<Student> students)
        {
            var group = students.GroupBy(s => s.nganhHoc);
            foreach (var g in group)
            {
                Console.WriteLine($"Ngành {g.Key}: {g.Count()} sinh viên");
            }
        }

        static void ThongKeTheoTrangThai(List<Student> students)
        {
            var group = students.GroupBy(s => s.trangThai);
            foreach (var g in group)
            {
                Console.WriteLine($"{(g.Key ? "Đang học" : "Tốt nghiệp")}: {g.Count()} sinh viên");
            }
        }
    }
}
