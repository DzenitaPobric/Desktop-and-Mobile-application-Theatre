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
    public partial class frmRezervacijeIZvjestaji : Form
    {
        public APIService _rezervacije = new APIService("Rezervacija");
        public APIService _prikazivanja = new APIService("Prikazivanje");
        public APIService _predstave = new APIService("Predstava");

        public frmRezervacijeIZvjestaji()
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
            var predstave = await _predstave.Get<List<Model.Predstava>>(null);
            List<Model.Predstava> listaPredstava = new List<Model.Predstava>();

            List<IzvjestajRezervacije> lista = new List<IzvjestajRezervacije>();
            decimal ukupnaZarada = 0;

            foreach (var p in predstave)
            {
                int brojRezervacija = 0;
                decimal zarada = 0;
                var prikazivanje = await _prikazivanja.Get<List<Model.Prikazivanje>>(new PrikazivanjeSearchRequest() {  PredstavaId = p.PredstavaId, Godina=idGodina });
                foreach (var prik in prikazivanje)
                {
                    var rezervacije = await _rezervacije.Get<List<Rezervacija>>(new RezervacijaSearchRequest() { PrikazivanjeId = prik.PrikazivanjeId });
                    foreach (var r in rezervacije)
                    {
                        if (prik.PrikazivanjeId == r.PrikazivanjeId)
                        {
                            brojRezervacija++;
                            zarada += prik.Cijena;
                        }
                    }
                }
                ukupnaZarada += zarada;
                lista.Add(new IzvjestajRezervacije() { Predstava = p.Naziv, Zanr = p.NazivZanra, BrojRezervacija = brojRezervacija, Zarada = zarada });
              
            }
            txtUkupno.Text = ukupnaZarada.ToString();

            dgvPrikaz.AutoGenerateColumns = false;
            dgvPrikaz.DataSource = lista;

        }

        private void frmRezervacijeIZvjestaji_Load(object sender, EventArgs e)
        {
            LoadGodine();

        }


        private async void cmbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbGodina.SelectedItem;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadIzvjestaji(id);

                chart1.DataSource = dgvPrikaz.DataSource;
                chart1.Series["Predstava"].XValueMember = "Predstava";
                chart1.Series["Predstava"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

                chart1.Series["Predstava"].YValueMembers = "Zarada";
                chart1.Series["Predstava"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

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
            foreach (DataGridViewColumn column in dgw.Columns)
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
                    pdfptable.AddCell(new Phrase(cell.Value.ToString(), text));
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
            exportGridToPdf(dgvPrikaz, "izvjestajRezervacije");
        }
    }
}
