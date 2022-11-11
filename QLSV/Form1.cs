using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            QLSVDataContext db = new QLSVDataContext();
            //tim kiem theo MaHS
            dtgvData.DataSource = db.HocSinhs.Where(d => d.MaHS.Equals(txtTimKiem.Text));
            MessageBox.Show("Tìm thành công", "Tìm");
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //c1
            QLSVDataContext db = new QLSVDataContext();
            dtgvData.DataSource = db.HocSinhs.Select(d => d);

            //c2
            //using (QLSVDataContext db = new QLSVDataContext())
            //{
            //    dtgvData.DataSource = from u in db.HocSinhs
            //                          select u;
            //}

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            QLSVDataContext db = new QLSVDataContext();
            // chon dong dau tien co cot la MaHS
            string id = dtgvData.SelectedCells[0].OwningRow.Cells["MaHS"].Value.ToString();
            // lay duy nhat 1 truong
            HocSinh delete = db.HocSinhs.Where(p => p.MaHS.Equals(id)).SingleOrDefault();
            //xoa
            db.HocSinhs.DeleteOnSubmit(delete);
            //luu lai ( cap nhat lai )
            db.SubmitChanges();
            btnXem_Click(sender, e);
            MessageBox.Show("Xoá thành công", "Xoá");
        }
        //them loi
        private void btnThem_Click(object sender, EventArgs e)
        {
            //QLSVDataContext db = new QLSVDataContext();
            //// chon dong dau tien co cot
            //string id = dtgvData.SelectedCells[0].OwningRow.Cells["MaHS"].Value.ToString();
            //string name = dtgvData.SelectedCells[0].OwningRow.Cells["TenHS"].Value.ToString();
            ////DateTime dateofbirth = (DateTime)dtgvData.SelectedCells[0].OwningRow.Cells["NgaySinh"].Value;
            //string dc = dtgvData.SelectedCells[0].OwningRow.Cells["DiaChi"].Value.ToString();
            //float dtb = (float)dtgvData.SelectedCells[0].OwningRow.Cells["DTB"].Value;
            //string ML = dtgvData.SelectedCells[0].OwningRow.Cells["MaLop"].Value.ToString();
            ////them
            //HocSinh HS = new HocSinh();
            //HS.MaHS = id;
            //HS.TenHS = name;
            ////khi ngay sinh rong    
            //if (dtgvData.SelectedCells[0].OwningRow.Cells["NgaySinh"].Value == null) HS.NgaySinh = null;
            //else HS.NgaySinh = (DateTime)dtgvData.SelectedCells[0].OwningRow.Cells["NgaySinh"].Value;
            //HS.DiaChi = dc;
            //HS.DTB = dtb;
            //HS.MaLop = ML;
            ////them
            //db.HocSinhs.InsertOnSubmit(HS);
            ////luu lai ( cap nhat lai )
            //db.SubmitChanges();
            //btnXem_Click(sender, e);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            QLSVDataContext db = new QLSVDataContext();
            // chon dong dau tien co cot
            string id = dtgvData.SelectedCells[0].OwningRow.Cells["MaHS"].Value.ToString();
            string name = dtgvData.SelectedCells[0].OwningRow.Cells["TenHS"].Value.ToString();
            //DateTime dateofbirth = (DateTime)dtgvData.SelectedCells[0].OwningRow.Cells["NgaySinh"].Value;
            string dc = dtgvData.SelectedCells[0].OwningRow.Cells["DiaChi"].Value.ToString();
            float dtb = (float)dtgvData.SelectedCells[0].OwningRow.Cells["DTB"].Value;
            string ML = dtgvData.SelectedCells[0].OwningRow.Cells["MaLop"].Value.ToString();
            //sua
            HocSinh edit = db.HocSinhs.Where(p => p.MaHS.Equals(id)).SingleOrDefault();
            edit.TenHS = name;
            //khi ngay sinh rong    
            if(dtgvData.SelectedCells[0].OwningRow.Cells["NgaySinh"].Value==null) edit.NgaySinh = null;
            else edit.NgaySinh = (DateTime)dtgvData.SelectedCells[0].OwningRow.Cells["NgaySinh"].Value;

            edit.DiaChi = dc;
            edit.DTB = dtb;
            edit.MaLop = ML;
            //luu lai ( cap nhat lai )
            db.SubmitChanges();
            btnXem_Click(sender, e);
            MessageBox.Show("Sửa thành công", "Sửa");
        }
    }
}
