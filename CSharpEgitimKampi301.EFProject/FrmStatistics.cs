using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            // Toplam Lokasyon Sayısı
            lblLocationCount.Text = db.Location.Count().ToString();
            // Toplam kapasite Sayısı
            lblSumCapacity.Text = db.Location.Sum(x => x.LocationCapacity).ToString();
            // Rehber Sayısı
            lblGuideCount.Text = db.Guide.Count().ToString();
            // ortalama kapasite
            lblCapacity.Text = db.Location.Average(x => x.LocationCapacity).ToString();
            // ortalama fiyat
            lblAvgLocationPrice.Text = db.Location.Average(x => x.LocationPrice)?.ToString("0.00") + "₺";
            // Eklenen Son Ülke
            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();
            // kapadokya tur kapasitesi
            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(y => y.LocationCapacity).FirstOrDefault().ToString();
            //türkiyedeki tur kapasitesi
            lblTurkiyeCapacityAvarege.Text = db.Location.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapacity).ToString();
            //roma gezisinin rehberinin ismi
             var romeGuideId = db.Location.Where(x => x.LocationCity == "Roma Turistik").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
            // En yüksek kapasiteli tur
            var maxCapacity = db.Location.Max(x => x.LocationCapacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCity).FirstOrDefault().ToString();
            // max ücretli tur
            var maxPrice = db.Location.Max(x => x.LocationPrice);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.LocationPrice == maxPrice).Select(y => y.LocationPrice).FirstOrDefault().ToString();
            // ayşegül çınarın tur sayısı
            var guideIdByNameAysegulCınar = db.Guide.Where(x => x.GuideName=="Ayşegül" && x.GuideSurname =="Çınar").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCınarLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameAysegulCınar).Count().ToString();

        }
    }
}
