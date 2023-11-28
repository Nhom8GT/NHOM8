﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Do_an_CTDL
{
    // Định nghĩa lớp BinarySearchTree để thực hiện các thao tác trên cây nhị phân
    public class BinarySearchTree
    {
        public Node Root { get; set; }
        // Phương thức Insert để chèn một giá trị vào cây nhị phân
        public bool Insert(Hosokhachhang value)
        {
            Node before = null, after = this.Root;
            while (after != null)
            {
                before = after;
                // So sánh giá trị ngày đặt phòng để xác định vị trí chèn
                if (value.Ngaydatphong <= after.Data.Ngaydatphong)
                    after = after.LeftNode;
                else if (value.Ngaydatphong > after.Data.Ngaydatphong)
                    after = after.RightNode;
                else
                    return false;
            }
            Node newNode = new Node();
            newNode.Data = value;
            if (this.Root == null)
                this.Root = newNode;
            else
            {
                if (value.Ngaydatphong <= before.Data.Ngaydatphong)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }
        // Phương thức TraverseInOrder để duyệt cây theo thứ tự trung tố và in ra thông tin
        public void TraverseInOrder(Node parent)
        {
            CultureInfo viVn = new CultureInfo("vi-VN");
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.WriteLine("{0,5}{1,25}{2,5}{3,15}{4,15}{5,25}{6,6}", parent.Data.Madatphong, parent.Data.Tenkhachhang, parent.Data.GioiTinh,
                     parent.Data.Ngaydatphong.ToString("d", viVn), parent.Data.loaiphong, parent.Data.trangthaiphong, parent.Data.sodienthoai);
                TraverseInOrder(parent.RightNode);
            }
        }
        // Phương thức findname để tìm kiếm khách hàng theo tên
        public void findname(Node parent, string Tenkhachhang)
        {
            CultureInfo viVn = new CultureInfo("vi-VN");
            if (parent != null)
            {
                findname(parent.LeftNode, Tenkhachhang);
                if (parent.Data.Tenkhachhang == Tenkhachhang)
                    Console.WriteLine("{0,5}{1,25}{2,5}{3,15}{4,15}{5,25}{6,6}",
                    parent.Data.Madatphong, parent.Data.Tenkhachhang,
                    parent.Data.GioiTinh,
                    parent.Data.Ngaydatphong.ToString("d", viVn),
                    parent.Data.loaiphong, parent.Data.trangthaiphong, parent.Data.sodienthoai);
                findname(parent.RightNode, Tenkhachhang);
            }
        }
        // Phương thức finddate để tìm kiếm khách hàng theo khoảng thời gian đặt phòng
        public void finddate(Node parent, DateTime date1, DateTime date2)
        {
            CultureInfo viVn = new CultureInfo("vi-VN");
            if (parent != null)
            {
                finddate(parent.LeftNode, date1, date2);
                if (parent.Data.Ngaydatphong <= date2 && parent.Data.Ngaydatphong >=
                date1)
                    Console.WriteLine("{0,5}{1,25}{2,5}{3,15}{4,15}{5,25}{6,6}",
                    parent.Data.Madatphong, parent.Data.Tenkhachhang,
                    parent.Data.GioiTinh,
                    parent.Data.Ngaydatphong.ToString("d", viVn),
                    parent.Data.loaiphong, parent.Data.trangthaiphong, parent.Data.sodienthoai);
                finddate(parent.RightNode, date1, date2);
            }
        }
        // Phương thức TaoHoSo để tạo hồ sơ khách hàng và chèn vào cây nhị phân
        public void TaoHoSo(ref BinarySearchTree binaryTree)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Hosokhachhang h = new Hosokhachhang();
            Console.WriteLine("Nhập mã đặt phòng (ID_Booking): ");
            h.Madatphong = Console.ReadLine();
            Console.WriteLine("Nhập tên khách hàng: ");
            h.Tenkhachhang = Console.ReadLine();
            do
            {
                Console.WriteLine("Nhập giới tính khách hàng(male/female): ");
                h.GioiTinh = Console.ReadLine();
            }
            while (h.GioiTinh != "male" && h.GioiTinh != "female");

            Console.WriteLine("Nhập ngày đặt phòng: ");
            h.Ngaydatphong = DateTime.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("Loại phòng đã được đặt:(Standard/Deluxe):  ");
                h.loaiphong = Console.ReadLine();
            }
            while (h.loaiphong != "Standard" && h.loaiphong != "Deluxe");
            do
            {
                Console.WriteLine("Nhập trạng thái hiện tại của phòng(cancle/no_cancle): ");
                h.trangthaiphong = Console.ReadLine();
            }
            while (h.trangthaiphong != "cancle" && h.trangthaiphong != "no_cancle");
            Console.WriteLine("Nhập số điện thoại khách hàng ");
            h.sodienthoai = (Console.ReadLine());
            binaryTree.Insert(h);
        }
    }
}
