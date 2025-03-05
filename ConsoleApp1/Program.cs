using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;

    public class nhanvien
    {
        public string maso { get; set; }
        public string hoten { get; set; }
        public int luongcung { get; set; }
        public nhanvien() { }
        public nhanvien(string maso, string hoten, int luongcung)
        {
            maso = maso;
            hoten = hoten;
            luongcung = luongcung;
        }
        public virtual void nhap()
        {
            Console.Write("nhap so nhan vien");
            maso = Console.ReadLine();
            Console.Write("nhap ho ten nhan vien");
            hoten = Console.ReadLine();
            Console.Write("nhap luong cung");
            luongcung = int.Parse(Console.ReadLine());
        }
        public virtual int tinhluong()
        {
            return luongcung;
        }
        public class nhanvienbc : nhanvien
        {
            public string mucxeploai { get; set; }
            public nhanvienbc() { }
            public nhanvienbc(string maso, string hoten, int luongcung, string mucxeploai) : base(maso, hoten, luongcung)
            {
                mucxeploai = mucxeploai;
            }
            public override void nhap()
            {
                base.nhap();
                Console.Write("nhap muc xep loai(A,B,C)");
                mucxeploai = Console.ReadLine();
            }
            public override int tinhluong()
            {
                double thuong = 0;
                switch (mucxeploai.ToUpper())
                {
                    case "A":
                        thuong = 1.5 * luongcung;
                        break;
                    case "B":
                        thuong = 1.0 * luongcung;
                        break;
                    case "C":
                        thuong = 0.5 * luongcung;
                        break;
                }
                return luongcung = (int)thuong;

            }
        }
        public class nhanvienhd : nhanvien
        {
            public int doanhthu { get; set; }
            public nhanvienhd() { }
            public nhanvienhd(string maso, string hoten, int luongcung, int doanhthu) : base(maso, hoten, luongcung)
            {
                doanhthu = doanhthu;
            }
            public override void nhap()
            {
                base.nhap();
                Console.Write("nhap doanh thu");
                doanhthu = int.Parse(Console.ReadLine());
            }
        }
        public class quanlynv

        {
            public List<nhanvien> dsNV { get; set; }
            public quanlynv()
            {
                dsNV = new List<nhanvien>();

            }
            public void nhapds()
            {
                Console.Write("nhap so luong nhan vien:");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("chon loai nhan vien (1: bien che, 2: hopdong):");
                    int loainv = int.Parse(Console.ReadLine());
                    nhanvien nv = null;
                    if (loainv == 1)
                    {
                        nv = new nhanvienbc();

                    }
                    else if (loainv == 2)
                    {
                        nv = new nhanvienhd();
                    }
                    nv.nhap();
                    dsNV.Add(nv);
                }
            }
            public void xuatds()
            {
                Console.WriteLine("Danh sách nhân viên:");
                foreach (var nv in dsNV)
                {
                    Console.WriteLine($"ma so: (nv.maso), ho ten: {nv.hoten}, luong thuc lanh:  {nv.tinhluong()}");
                }
            }
        }
        class Program
{
    static void Main()
    {
                quanlynv qlnv = new quanlynv();
        int chon;

        do
        {
            Console.WriteLine("\nChọn chức năng:");
            Console.WriteLine("1. Nhập danh sách nhân viên");
            Console.WriteLine("2. Hiển thị thông tin nhân viên");
            Console.WriteLine("3. Tính tổng lương");
            Console.WriteLine("4. Tính lương trung bình");
            Console.WriteLine("5. Thoát");
            Console.Write("Nhập lựa chọn: ");
            chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    qlnv.nhapds();
                    break;
                case 2:
                    qlnv.xuatds();
                    break;
                case 3:
                    Console.WriteLine($"Tổng lương công ty phải trả: {qlnv.tinhluongcung()}");
                    break;
                case 4:
                    Console.WriteLine($"Lương trung bình của các nhân viên: {qlnv.TinhLuongTrungBinh():0.00}");
                    break;
                case 5:
                    Console.WriteLine("Thoát chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        } while (chon != 5);
    }
}



        static void Main(string[] args)
        {
        }
    }
    }
