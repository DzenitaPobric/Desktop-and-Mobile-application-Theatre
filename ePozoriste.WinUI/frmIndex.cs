using ePozoriste.WinUI.Dokumenti;
using ePozoriste.WinUI.Glumac;
using ePozoriste.WinUI.Grad;
using ePozoriste.WinUI.Izvjestaji;
using ePozoriste.WinUI.Korisnik;
using ePozoriste.WinUI.Kupac;
using ePozoriste.WinUI.NagradnaIgra;
using ePozoriste.WinUI.Novosti;
using ePozoriste.WinUI.Predstava;
using ePozoriste.WinUI.Prikazivanje;
using ePozoriste.WinUI.Rezervacije;
using ePozoriste.WinUI.Sala;
using ePozoriste.WinUI.Sjediste;
using ePozoriste.WinUI.Sponzor;
using ePozoriste.WinUI.Ulaznica;
using ePozoriste.WinUI.Uplata;
using ePozoriste.WinUI.Zanr;
using System;
using System.Windows.Forms;

namespace ePozoriste.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
       //     toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
      //      statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrad frm = new frmGrad();
            frm.MdiParent = this;
            frm.Show();

        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmZanr frm = new frmZanr();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmPredstava frm = new frmPredstava();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviŽanrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmzanrDetalji frm = new frmzanrDetalji();
            frm.Show();
        }

        private void noviGradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGradDetalji frm = new frmGradDetalji();
            frm.Show();
        }

        private void prikazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSponzor frm = new frmSponzor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviSponzorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSponzorDetalji frm = new frmSponzorDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmSala frm = new frmSala();
            frm.MdiParent = this;
            frm.Show();
        }

        private void novaSalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalaDetalji frm = new frmSalaDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmGlumac frm = new frmGlumac();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviGlumacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGlumacDetalji frm = new frmGlumacDetalji();
            frm.Show();
        }

        private void prikazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUplata frm = new frmUplata();
            frm.MdiParent = this;
            frm.Show();
        }


        private void prikazUnosToolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
            frmPrikazivanje frm = new frmPrikazivanje();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmKorisnik frm = new frmKorisnik();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviKorisnikToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmKorisnikDetails frm = new frmKorisnikDetails();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmKupac frm = new frmKupac();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviKupacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKupacDetalji frm = new frmKupacDetalji();
            frm.MdiParent = this;
            frm.Show();
        }


        private void dodajNovuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNagradnaIgra frm = new frmNagradnaIgra();
           
            frm.Show();
        }


        private void pretragaToolStripMenuItem7_Click_1(object sender, EventArgs e)
        {
            frmNagradnaIgraDetalji frm = new frmNagradnaIgraDetalji();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmNovosti frm = new frmNovosti();
            frm.MdiParent = this;
            frm.Show();
        }

        private void unosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNovostiDetalji frm = new frmNovostiDetalji();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmPredstavaPrikaz frm = new frmPredstavaPrikaz();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmUplataPrikaz frm = new frmUplataPrikaz();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dodajNovuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUplata frm = new frmUplata();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frmPrikazivanjePrikaz frm = new frmPrikazivanjePrikaz();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dodajNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrikazivanje frm = new frmPrikazivanje();
            frm.MdiParent = this;
            frm.Show();
        }

        private void uplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUplateIzvjestaj frm = new frmUplateIzvjestaj();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rezervacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRezervacijeIZvjestaji frm = new frmRezervacijeIZvjestaji();
            frm.MdiParent = this;

            frm.Show();
        }
    
        private void pretragaToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            frmUlaznica frm = new frmUlaznica();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            frmRezervacije frm = new frmRezervacije();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dodajNovuToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmRezervacijeDetalji frm = new frmRezervacijeDetalji();
            frm.MdiParent = this;
            frm.Show();
        }

        private void unosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUlaznicaDetalji frm = new frmUlaznicaDetalji();
            frm.MdiParent = this;
            frm.Show();
        }


        private void pretragaToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            frmDokument frm = new frmDokument();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDokumentDetalji frm = new frmDokumentDetalji();
            frm.MdiParent = this;
            frm.Show();
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }
        
        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnikDetails frm = new frmKorisnikDetails();
            frm.MdiParent = this;
            frm.Show();
        }

        private void unosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmUlaznicaDetalji frm = new frmUlaznicaDetalji();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}

