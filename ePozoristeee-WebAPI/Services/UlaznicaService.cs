using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePozoriste.Model;
using ePozoriste.WebAPI.Database;
using AutoMapper;
using QRCoder;
using System.Drawing;
using System.IO;

namespace ePozoriste.WebAPI.Services
{
    public class UlaznicaService : BaseCRUDService<Model.Ulaznica, UlaznicaSearchRequest, Database.Ulaznica, UlaznicaUpsertRequest, UlaznicaUpsertRequest>
    {
        public UlaznicaService(ePozoristeContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override List<Model.Ulaznica> Get(UlaznicaSearchRequest search)
        {
            var q = _context.Ulaznica.AsQueryable();
            if (search?.KupacId.HasValue == true)
            {
                q = q.Where(s => s.Kupac.KupacId == search.KupacId);
            }
            if (search?.PrikazivanjeId.HasValue == true)
            {
                q = q.Where(s => s.Prikazivanje.PrikazivanjeId == search.PrikazivanjeId);
            }
            if (search?.RezervacijaId.HasValue == true)
            {
                q = q.Where(s => s.Rezervacija.RezervacijaId == search.RezervacijaId);
            }
            var list = q.ToList();
            return _mapper.Map<List<Model.Ulaznica>>(list);
        }

        public override Model.Ulaznica Insert(UlaznicaUpsertRequest request)
        {
            Database.Kupac k = _context.Kupac.FirstOrDefault(l => l.KupacId == request.KupacId);
            Model.Kupac kupac = _mapper.Map<Model.Kupac>(k);
            Model.Prikazivanje p = _mapper.Map<Model.Prikazivanje>(_context.Prikazivanje.FirstOrDefault(s => s.PrikazivanjeId == request.PrikazivanjeId));
            Model.Sjediste sj = _mapper.Map<Model.Sjediste>(_context.Sjediste.FirstOrDefault(s => s.SjedisteId == request.SjedisteId));
            Model.Rezervacija r = _mapper.Map<Model.Rezervacija>(_context.Rezervacije.FirstOrDefault(s => s.RezervacijaId == request.RezervacijaId));
            string number = "Ime i prezime: " + kupac.KupacPodaci + "---Prikazivanje: " + p.DatumPrikazivanja + "----Sjediste: " + sj.SjedistePodaci   /*+ "$" + GetVoucherNumber(8)*/;

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(number, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);

            Bitmap qrCodeImage = code.GetGraphic(10);
            var bitmapBytes = BitmapToBytes(qrCodeImage);
            request.Qrkod = bitmapBytes;

            return base.Insert(request);

        }



        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
       
    }
}
