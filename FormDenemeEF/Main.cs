using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDenemeEF
{
    public partial class Main : Form
    {
        formdenemeEntities db;
        int id = 0;
        public Main()
        {
            InitializeComponent();
        }
        #region textbox temizleme
        public void ClearTexts()
        {
            txtName.Text = "";
            txtCity.Text = "";
            txtField.Text = "";
            lblPersonelId.Text = "";
        }
        #endregion

        #region personel getir
        public void GetPersonel()
        {
            db = new formdenemeEntities();
            PersonelGrid.DataSource = db.Personel.ToList();
            PersonelGrid.Columns[0].Visible = false;
            PersonelGrid.Columns[1].HeaderCell.Value = "Ad Soyad";
        }
        #endregion

        #region personel ekle
        public void AddPersonel()
        {
            Personel p = new Personel();
            p.AdSoyad = txtName.Text;
            p.Sehir = txtCity.Text;
            p.Alan = txtField.Text;
            db.Personel.Add(p);
            db.SaveChanges();
            ClearTexts();
            GetPersonel();
        }
        #endregion

        #region personel secme
        private void PersonelGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = PersonelGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCity.Text = PersonelGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtField.Text = PersonelGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
            lblPersonelId.Text = PersonelGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        #endregion

        #region personel sil
        public void DeletePersonel()
        {
            id = Convert.ToInt32(lblPersonelId.Text);
            var x = db.Personel.Find(id);
            db.Personel.Remove(x);
            db.SaveChanges();
            ClearTexts();
            GetPersonel();
        }
        #endregion

        #region personel guncelle
        public void UpdatePersonel()
        {
            id = Convert.ToInt32(lblPersonelId.Text);
            var x = db.Personel.Find(id);
            x.AdSoyad = txtName.Text;
            x.Sehir = txtCity.Text;
            x.Alan = txtField.Text;
            db.SaveChanges();
            ClearTexts();
            GetPersonel();
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            GetPersonel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPersonel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePersonel();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePersonel();
        }
    }
}
