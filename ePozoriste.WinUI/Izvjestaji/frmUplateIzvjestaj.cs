using ePozoriste.Model;
using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace ePozoriste.WinUI.Izvjestaji
{
    public partial class frmUplateIzvjestaj : Form
    {
        public APIService _sponzori = new APIService("Sponzor");
        public APIService _uplate = new APIService("Uplata");


        public frmUplateIzvjestaj()
        {
            InitializeComponent();
        }
        private void LoadGodine()
        {
            var gZ = DateTime.Now.Year;
            var gP = 2016;
            for (int i = gP; i <= gZ; i++)
            {
                cmbGodina.Items.Add(i);
            }
            cmbGodina.Text = "---Odaberite godinu---";

        }
        private async Task LoadIzvjestaji(int idGodina)
        {
            var sponzori = await _sponzori.Get<List<Model.Sponzor>>(null);
            List<Model.Sponzor> listaSponzora = new List<Model.Sponzor>();

            List<Model.IzvjestajUplata> lista = new List<Model.IzvjestajUplata>();
            double ukupnaZarada = 0;

            foreach (var s in sponzori)
            {
                int brojUplata = 0;
                double zarada = 0;
                var uplate = await _uplate.Get<List<Model.Uplata>>(new UplataSearchRequest() { Godina = idGodina, SponzorId = s.SponzorId });
                foreach (var u in uplate)
                {
                    brojUplata++;
                    zarada += u.Iznos;
                }
                ukupnaZarada += zarada;

                lista.Add(new IzvjestajUplata() { nazivSponzora = s.Naziv, brojUplata = brojUplata, zarada = zarada });
            }

            txtUkupno.Text = ukupnaZarada.ToString();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }


        private void frmUplateIzvjestaj_Load(object sender, EventArgs e)
        {
            LoadGodine();
        }

        private async void cmbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbGodina.SelectedItem;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadIzvjestaji(id); 
                
                chart1.DataSource = dataGridView1.DataSource;
                chart1.Series["nazivSponzora"].XValueMember = "nazivSponzora";
                chart1.Series["nazivSponzora"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                chart1.Series["nazivSponzora"].YValueMembers = "zarada";
                chart1.Series["nazivSponzora"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chart1.ChartAreas[0].AxisX.Interval = 1;


            }
        }

        

        public void exportGridToPdf(DataGridView dgw, string fileName)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfptable = new PdfPTable(dgw.Columns.Count);

            pdfptable.DefaultCell.Padding = 3;
            pdfptable.WidthPercentage = 100;
            pdfptable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfptable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

            //header
            foreach(DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfptable.AddCell(cell);
            }


            //datarow
            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfptable.AddCell(new Phrase(cell.Value.ToString(),text));
                }
            }

            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = fileName;
            savefiledialoge.DefaultExt = ".pdf";
            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfptable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exportGridToPdf(dataGridView1, "izvjestajUplate");
        }
    }
}
