using System;
using System.Linq;
using APIConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace APIConsume.Controllers
{
    public class
        SimkaAdminController : Controller
    {
        private readonly SIATMAX_SISTERContext _context;
        public SimkaAdminController(SIATMAX_SISTERContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");


        }
        public IActionResult SedangStudi()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");


        }
        public IActionResult KelolaRekanan()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaAppraisal()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaButirAppraisal()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefPengembangan()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefKeluarga()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefGolongan()
        {
            if (HttpContext.Session.GetString("NPP") != null)
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefFungsional()
        {
            if (HttpContext.Session.GetString("NPP") != null)
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefKompetensi()
        {
            if (HttpContext.Session.GetString("NPP") != null)
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefJenjang()
        {
            if (HttpContext.Session.GetString("NPP") != null)
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefJabatanAkademik()
        {
            if (HttpContext.Session.GetString("NPP") != null)
                // memeriksa apakah user login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefPotongan()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefStatusStudi()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefTransaksiAkademik()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefPiutang()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefJenisKelas()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefJenisSemester()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefJenisTest()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefJenisTestDetail()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefJabatanStruktural()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRefRestitusi()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaPayroll()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaSuratKeputusan()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        public IActionResult KelolaKeluarga()
        {


            if (HttpContext.Session.GetString("role") == "admin")
            {
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                var balikan = new karyaa()
                {
                    karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.Nama }).ToList(),
                };
                return View(balikan);
            }
                

           
            else
                return RedirectToAction("Index", "Home");
          
        }
        public IActionResult KelolaMutasi()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaRekening()
        {

            if (HttpContext.Session.GetString("role") == "admin")
            {
                var balikan = new karyaa()
                {
                    karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.Nama }).ToList(),
                };

                return View(balikan);

            }

            else
                return RedirectToAction("Index", "Home");

           

        }
        public IActionResult KelolaAsuransi()
        {

            if (HttpContext.Session.GetString("role") == "admin")
            {
                var balikan = new karyaa()
                {
                    karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.Nama }).ToList(),
                };

                return View(balikan);
            }

            else
                return RedirectToAction("Index", "Home");


          
        }

        public IActionResult KelolaUnit()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");

        }
        public IActionResult KelolaRiwayatPendidikan()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaKaryawan()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaKarirFungsional()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaKarirStruktural()
        {
            if (HttpContext.Session.GetString("role") == "admin")
                // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult KelolaKarirGolongan()
            {
                if (HttpContext.Session.GetString("role") == "admin")
                    // memeriksa apakah admin yg login jika ya return view jika tidak forbidden
                    return View();
                else
                    return RedirectToAction("Index", "Home");
            }
            public IActionResult ResetPassword()
        {
            var balikan = new karyaa()
            {
                karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.Nama }).ToList(),
            };

            return View(balikan);
        }
        public IActionResult LoadDataKaryawan()
        {
            try
            {
                var customerData = _context.MstKaryawan
                .Include(m => m.IdUnitNavigation)
                .Include(m => m.MstIdUnitNavigation)
                .Include(m => m.MstIdUnitAkademikNavigation)
                 .Select(p => new { p.Npp, p.NamaLengkapGelar, p.IdRefFungsionalNavigation.Deskripsi, p.IdUnitNavigation.NamaUnit, p.EmailInstitusi, p.MstIdUnitAkademikNavigation.NamaUnitAkademik, penempatan = p.MstIdUnitNavigation.NamaUnit });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }

        }
        public IActionResult AddEditKaryawan(string npp="")
        {
            if (npp == "")
            {

                var balikan = new KaryawanForm()
                {
                    struktural = _context.RefJabatanStruktural.ToList(),

                    fungsional = _context.RefFungsional.ToList(),
                    unit = _context.MstUnit.OrderBy(c => c.NamaUnit).ToList(),
                    prodi=_context.MstUnitAkademik.OrderBy(c=>c.NamaUnitAkademik).ToList(),
                    golongan = _context.RefGolongan
                    .Select(c => new RefGolongan
                    {
                        IdRefGolongan = c.IdRefGolongan,
                        Deskripsi = c.IdRefGolongan + " - " + c.Deskripsi
                    })
                    .ToList(),
                    akademik = _context.RefJabatanAkademik.ToList(),
                    refkeluarga = _context.RefKeluarga.ToList(),
                };
                return View(balikan);
            }
            else
            {
                var karyawan = _context.MstKaryawan.Where(x => x.Npp.Equals(npp)).FirstOrDefault();

                var balikan = new KaryawanForm()
                {

                    struktural = _context.RefJabatanStruktural.ToList(),

                    fungsional = _context.RefFungsional.ToList(),
                    unit = _context.MstUnit.OrderBy(c => c.NamaUnit).ToList(),
                    prodi = _context.MstUnitAkademik.OrderBy(c => c.NamaUnitAkademik).ToList(),
                    golongan = _context.RefGolongan
                    .Select(c => new RefGolongan
                    {
                        IdRefGolongan = c.IdRefGolongan,
                        Deskripsi = c.IdRefGolongan + " - " + c.Deskripsi
                    })
                    .ToList(),
                    akademik = _context.RefJabatanAkademik.ToList(),
                    refkeluarga = _context.RefKeluarga.ToList(),
                    Npp = karyawan.Npp,
                    Nama = karyawan.Nama,
                    NamaLengkapGelar = karyawan.NamaLengkapGelar,
                    Nickname = karyawan.Nickname,
                    TempatLahir = karyawan.TempatLahir,
                    TglLahir = karyawan.TglLahir,
                    TglMasuk = karyawan.TglMasuk,
                    Alamat = karyawan.Alamat,
                    AlamatKota = karyawan.AlamatKota,
                    AlamatKodepos = karyawan.AlamatKodepos,
                    AlamatProvinsi = karyawan.AlamatProvinsi,
                    GolDarah = karyawan.GolDarah,
                    Warganegara = karyawan.Warganegara,
                    NoKtp = karyawan.NoKtp,
                    TglAkhirBerlakuKtp = karyawan.TglAkhirBerlakuKtp,
                    Npwp = karyawan.Npwp,
                    StatusPtkp = karyawan.StatusPtkp,
                    JnsKel = karyawan.JnsKel,
                    Agama = karyawan.Agama,
                    StatusSipil = karyawan.StatusSipil,
                    NoPaspor = karyawan.NoPaspor,
                    NipPns = karyawan.NipPns,
                    Inisial = karyawan.Inisial,
                    StatusAktifitas = karyawan.StatusAktifitas,
                    Nidn = karyawan.Nidn,
                    PendidikanTerakhir = karyawan.PendidikanTerakhir,
                    PendidikanDiakui = karyawan.PendidikanDiakui,
                    NoSertifikatPendidik = karyawan.NoSertifikatPendidik,
                    StatusRestitusi = karyawan.StatusRestitusi,
                    EmailInstitusi = karyawan.EmailInstitusi,
                    Email = karyawan.Email,
                    NoTelponRumah = karyawan.NoTelponRumah,
                    NoTelponHp = karyawan.NoTelponHp,
                    FileFotom = karyawan.FileFoto,
                    FileKtpm = karyawan.FileKtp,
                    StatusKepegawaian = karyawan.StatusKepegawaian,
                    StatusFungsional = karyawan.StatusFungsional,
                    IdRefFungsional = karyawan.IdRefFungsional,
                    IdUnit = karyawan.IdUnit,
                    MstIdUnit = karyawan.MstIdUnit,
                    IdUnitAkademik = karyawan.IdUnitAkademik,
                    IdUnitAkademikEpsbed = karyawan.IdUnitAkademikEpsbed,
                    IdRefGolongan = karyawan.IdRefGolongan,
                    IdRefGolonganLokal = karyawan.IdRefGolonganLokal,
                    IdRefJbtnAkademik = karyawan.IdRefJbtnAkademik,
                    FileAsuransim = karyawan.FileAsuransi,
                    FileKartuPegawaim = karyawan.FileKartuPegawai,
                    FileNpwpm = karyawan.FileNpwp,
                    FileSertifikasiPendidikm = karyawan.FileSertifikasiPendidik,
                    ID_DOSEN_SISTER = karyawan.ID_DOSEN_SISTER,



                };

                return View(balikan);
            }
        }
        public async Task<IActionResult> PostKaryawan(KaryawanForm karyawan)
        {
            // mengecek apakah karyawan ada
            var karyawanada = await _context.MstKaryawan.AsNoTracking().AnyAsync(x => x.Npp == karyawan.Npp);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var karyawandb = _context.MstKaryawan.AsNoTracking().FirstOrDefault(x => x.Npp == karyawan.Npp);
            MstKaryawan data = new MstKaryawan()
            {

                Npp = karyawan.Npp,
                Nama = karyawan.Nama,
                NamaLengkapGelar = karyawan.NamaLengkapGelar,
                Nickname = karyawan.Nickname,
                TempatLahir = karyawan.TempatLahir,
                TglLahir = karyawan.TglLahir,
                TglMasuk = karyawan.TglMasuk,
                Alamat = karyawan.Alamat,
                AlamatKota = karyawan.AlamatKota,
                AlamatKodepos = karyawan.AlamatKodepos,
                AlamatProvinsi = karyawan.AlamatProvinsi,
                GolDarah = karyawan.GolDarah,
                Warganegara = karyawan.Warganegara,
                NoKtp = karyawan.NoKtp,
                TglAkhirBerlakuKtp = karyawan.TglAkhirBerlakuKtp,
                Npwp = karyawan.Npwp,
                StatusPtkp = karyawan.StatusPtkp,
                JnsKel = karyawan.JnsKel,
                Agama = karyawan.Agama,
                StatusSipil = karyawan.StatusSipil,
                NoPaspor = karyawan.NoPaspor,
                NipPns = karyawan.NipPns,
                Inisial = karyawan.Inisial,
                StatusAktifitas = karyawan.StatusAktifitas,
                Nidn = karyawan.Nidn,
                PendidikanTerakhir = karyawan.PendidikanTerakhir,
                PendidikanDiakui = karyawan.PendidikanDiakui,
                NoSertifikatPendidik = karyawan.NoSertifikatPendidik,
                StatusRestitusi = karyawan.StatusRestitusi,
                EmailInstitusi = karyawan.EmailInstitusi,
                Email = karyawan.Email,
                NoTelponRumah = karyawan.NoTelponRumah,
                NoTelponHp = karyawan.NoTelponHp,
                StatusKepegawaian = karyawan.StatusKepegawaian,
                StatusFungsional = karyawan.StatusFungsional,
                IdRefFungsional = karyawan.IdRefFungsional,
                IdUnit = karyawan.IdUnit,
                MstIdUnit = karyawan.MstIdUnit,
                IdUnitAkademik = karyawan.IdUnitAkademik,
                IdUnitAkademikEpsbed = karyawan.IdUnitAkademikEpsbed,
                IdRefGolongan = karyawan.IdRefGolongan,
                IdRefGolonganLokal = karyawan.IdRefGolonganLokal,
                IdRefJbtnAkademik = karyawan.IdRefJbtnAkademik,
                Username = karyawan.Npp,
                Password = "1234567",// password default\
                CurrentStatus = karyawan.CurrentStatus,
                ID_DOSEN_SISTER = karyawan.ID_DOSEN_SISTER,



            };
            //mengubah Image menjadi byte base64 untuk disimpan ke db
            if (karyawan.FileFoto != null && karyawan.FileFoto.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = karyawan.FileFoto.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.FileFoto = p1;

            }
            else if (karyawandb != null)
                data.FileFoto = karyawandb.FileFoto;
            else data.FileFoto = null;

            if (karyawan.FileKtp != null && karyawan.FileKtp.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = karyawan.FileKtp.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.FileKtp = p1;
            }
            else if (karyawandb != null)
                data.FileKtp = karyawandb.FileKtp;
            else data.FileKtp = null;
            if (karyawan.FileKartuPegawai != null && karyawan.FileKartuPegawai.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = karyawan.FileKartuPegawai.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.FileKartuPegawai = p1;
            }
            else if (karyawandb != null)
                data.FileKartuPegawai = karyawandb.FileKartuPegawai;
            else data.FileKartuPegawai = null;
            if (karyawan.FileAsuransi != null && karyawan.FileAsuransi.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = karyawan.FileAsuransi.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.FileAsuransi = p1;
            }
            else if (karyawandb != null)
                data.FileAsuransi = karyawandb.FileAsuransi;
            else data.FileAsuransi = null;
            if (karyawan.FileNpwp != null && karyawan.FileNpwp.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = karyawan.FileNpwp.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.FileNpwp = p1;
            }
            else if (karyawandb != null)
                data.FileNpwp = karyawandb.FileNpwp;
            else data.FileNpwp = null;
            if (karyawan.FileSertifikasiPendidik != null && karyawan.FileSertifikasiPendidik.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = karyawan.FileSertifikasiPendidik.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.FileSertifikasiPendidik = p1;
            }
            else if (karyawandb != null)
                data.FileSertifikasiPendidik = karyawandb.FileSertifikasiPendidik;
            else data.FileSertifikasiPendidik = null;
            // END mengubah Image menjadi byte base64 untuk disimpan ke db

            if (karyawanada)
            {
               
                data.BiografiSingkat = karyawandb.BiografiSingkat;
                data.Password = karyawandb.Password;
            }
            if (!karyawanada)
            {
                _context.MstKaryawan.Add(data);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Add new data success." });
            }

            else
            {
                _context.Update(data);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Edit data success." });
            }
        }

        //start rekening
        public IActionResult LoadDataRekening(string npp)
        {
            try
            {
                var customerData = _context.MstRekening
             .Where(x => x.Npp.Equals(npp));


                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }

        }
        public IActionResult AddEditRekening(String id = "0")
        {
            if (id == "0")
            {

                var balikan = new FormRekening()

                {

                };
                return View(balikan);
            }
            else
            {
                var rekening = _context.MstRekening.Where(x => x.NoRekening.Equals(id)).FirstOrDefault();

                var balikan = new FormRekening()
                {
                    NamaBank = rekening.NamaBank,
                    NoRekening = rekening.NoRekening,
                    NoRekeningBaru = rekening.NoRekening,
                    Status = rekening.Status,
                    StatusRekening = rekening.StatusRekening



                };
                return View(balikan);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostRekening([FromBody]  FormRekening mstrekanan)
        {

            String id = mstrekanan.NoRekening;
            var rekeningada = await _context.MstRekening.AnyAsync(x => x.NoRekening == id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rekening = new MstRekening()
            {
                NamaBank = mstrekanan.NamaBank,
                NoRekening = mstrekanan.NoRekeningBaru,
                Npp = mstrekanan.Npp,
                Status = mstrekanan.Status,
                StatusRekening = mstrekanan.StatusRekening

            };
            if (!rekeningada)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                //code ini buat mengambil id baru dari database

                _context.MstRekening.Add(rekening);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                await DeleteRekening(id);
                _context.MstRekening.Add(rekening);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }


        public async Task<IActionResult> DeleteRekening([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.MstRekening.SingleOrDefaultAsync(m => m.NoRekening == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.MstRekening.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }


        //end of rekening

        //rekening
        public IActionResult LoadDataAsuransi(string npp)
        {
            try
            {
                var customerData = _context.MstAsuransi
             .Where(x => x.Npp.Equals(npp));


                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }

        }
        public IActionResult AddEditAsuransi(String id = "0")
        {
            if (id == "0")
            {

                var balikan = new MstAsuransiForm()

                {

                };
                return View(balikan);
            }
            else
            {
                var rekening = _context.MstAsuransi.Where(x => x.NoAsuransi.Equals(id)).FirstOrDefault();

                var balikan = new MstAsuransiForm()
                {
                    NamaInstitusi = rekening.NamaInstitusi,
                    NoAsuransi = rekening.NoAsuransi,
                    NoAsuransiBaru = rekening.NoAsuransi,
                    Status = rekening.Status,
                    TglBergabung = rekening.TglBergabung,
                };
                return View(balikan);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostAsuransi([FromBody]  MstAsuransiForm rekening)
        {

            String id = rekening.NoAsuransi;
            var rekeningada = await _context.MstAsuransi.AnyAsync(x => x.NoAsuransi == id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asuransi = new MstAsuransi()
            {
                Npp = rekening.Npp,
                NamaInstitusi = rekening.NamaInstitusi,
                NoAsuransi = rekening.NoAsuransiBaru,
                Status = rekening.Status,
                TglBergabung = rekening.TglBergabung,

            };
            if (!rekeningada)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                //code ini buat mengambil id baru dari database

                _context.MstAsuransi.Add(asuransi);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                await DeleteAsuransi(id);
                _context.MstAsuransi.Add(asuransi);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }


        public async Task<IActionResult> DeleteAsuransi([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.MstAsuransi.SingleOrDefaultAsync(m => m.NoAsuransi == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.MstAsuransi.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }

        //end of asuransi

        //keluarga
        public IActionResult LoadDataKeluarga(string npp)
        {
            try
            {
                var customerData = _context.MstKeluarga
             .Where(x => x.Npp.Equals(npp)).Select(x =>
             new
             {
                 x.IdKeluarga,
                 x.Nama,
                 hubungan = x.IdRefKeluargaNavigation.Deskripsi,
                 x.JnsKel,
                 x.TempatLahir,
                 TglLahir = (x.TglLahir),
                 x.GolDarah
             });


                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }

        }
        public IActionResult AddEditKeluarga(int id = 0)
        {
            if (id == 0)
            {

                var balikan = new GabungKeluarga()

                {
                    // mengambil  daftar jenis appraisal untuk dipopualte dalam select
                    RefKeluargas = _context.RefKeluarga.ToList(),




                };
                return View(balikan);
            }
            else
            {
                var keluarga = _context.MstKeluarga.Where(x => x.IdKeluarga.Equals(id)).FirstOrDefault();
                var balikan = new GabungKeluarga()
                {
                    RefKeluargas = _context.RefKeluarga.ToList(),
                    Nama = keluarga.Nama,
                    JnsKel = keluarga.JnsKel,
                    Npp = keluarga.Npp,
                    IsTanggung = keluarga.IsTanggung,
                    IsTanggungYadapen = keluarga.IsTanggungYadapen,
                    StatusSipil = keluarga.StatusSipil,
                    TglLahir = keluarga.TglLahir,
                    TempatLahir = keluarga.TempatLahir,
                    IdRefKeluarga = keluarga.IdRefKeluarga,
                    FileFotom = keluarga.FileFoto,
                    FileSuratm = keluarga.FileSurat,
                    IdKeluarga = keluarga.IdKeluarga,
                    GolDarah = keluarga.GolDarah,

                };

                return View(balikan);
            }
        }

        public async Task<IActionResult> PostKeluarga(GabungKeluarga keluarga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var karyawandb = _context.MstKeluarga.AsNoTracking().FirstOrDefault(x => x.IdKeluarga == keluarga.IdKeluarga);
            MstKeluarga data = new MstKeluarga()
            {
                IdKeluarga = keluarga.IdKeluarga,
                Npp = keluarga.Npp,
                Nama = keluarga.Nama,
                TempatLahir = keluarga.TempatLahir,
                TglLahir = keluarga.TglLahir,
                GolDarah = keluarga.GolDarah,
                IdRefKeluarga = keluarga.IdRefKeluarga,
                JnsKel = keluarga.JnsKel,
                IsTanggung = keluarga.IsTanggung,
                IsTanggungYadapen = keluarga.IsTanggungYadapen,
                StatusSipil = keluarga.StatusSipil,



            };
            if (keluarga.FileFoto != null && keluarga.FileFoto.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = keluarga.FileFoto.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.FileFoto = p1;

            }
            else if (karyawandb != null)
                data.FileFoto = karyawandb.FileFoto;
            else data.FileFoto = null;

            if (keluarga.FileSurat != null && keluarga.FileSurat.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = keluarga.FileSurat.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.FileSurat = p1;
            }
            else if (karyawandb != null)
                data.FileSurat = karyawandb.FileSurat;
            else data.FileSurat = null;
            if (data.IdKeluarga == 0)
            {
                //  mstrekanan.IdRefPengembangan = _context.RefPengembangan.Max(p => p.IdRefPengembangan) + 1;
                _context.MstKeluarga.Add(data);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(data);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }


        public async Task<IActionResult> DeleteKeluarga([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.MstKeluarga.SingleOrDefaultAsync(m => m.IdKeluarga == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.MstKeluarga.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end keluarga



        public JsonResult FindAkademik(int fungsional_id)
        {
            if (fungsional_id == 1)
            {
                var Kegiatan = _context.MstUnit
                .Where(p => p.IdRefStruktural == 7)
            .Select(p => new { p.IdUnit, p.NamaUnit });

                //return SelectList with your text and value
                var kegiatan = Kegiatan.OrderBy(c => c.NamaUnit).ToList();
                Console.WriteLine(kegiatan);
                return new JsonResult(kegiatan);
            }
            else
            {
                var Kegiatan = _context.MstUnit
            .Select(p => new { p.IdUnit, p.NamaUnit });

                //return SelectList with your text and value
                var kegiatan = Kegiatan.OrderBy(c => c.NamaUnit).ToList();
                Console.WriteLine(kegiatan);
                return new JsonResult(kegiatan);
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            //bersihan sessionn
            return RedirectToAction("Index", "Home");
        }
        public IActionResult LoadData() // untuk halaman index
        {
            if (HttpContext.Session.GetString("NPP") != null)
            {
                try
                {
                    var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                    // Skip number of Rows count  
                    var start = Request.Form["start"].FirstOrDefault();

                    // Paging Length 10,20  
                    var length = Request.Form["length"].FirstOrDefault();

                    // Sort Column Name  
                    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                    // Sort Column Direction (asc, desc)  
                    var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                    // Search Value from (Search box)  
                    var searchValue = Request.Form["search[value]"].FirstOrDefault();

                    //Paging Size (10, 20, 50,100)  
                    int pageSize = length != null ? Convert.ToInt32(length) : 0;

                    int skip = start != null ? Convert.ToInt32(start) : 0;

                    int recordsTotal = 0;

                    // getting all Customer data  

                    var customerData = _context.MstKaryawan
                          .Include(m => m.IdRefFungsionalNavigation)
                    .Include(m => m.IdRefGolonganNavigation)
                    .Include(m => m.IdRefJbtnAkademikNavigation)
                    .Include(m => m.IdRefTunjanganKhususNavigation)
                    .Include(m => m.IdUnitNavigation)
                    .Include(m => m.MstIdUnitNavigation)
                    .Include(m => m.MstIdUnitAkademikNavigation)
                       .Where(p => p.MstIdUnitAkademikNavigation.NamaUnitAkademik != null)
                        .Select(p => new { p.Npp, p.NamaLengkapGelar, p.IdUnitNavigation.NamaUnit, p.MstIdUnitAkademikNavigation.NamaUnitAkademik });


                    //Sorting  
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                    {
                        customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                    }
                    //Search  
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        customerData = customerData
                            .Where(m => m.NamaLengkapGelar.ToLower().Contains(searchValue.ToLower()) || m.Npp.ToLower().Contains(searchValue.ToLower()) || m.NamaUnitAkademik.ToLower().Contains(searchValue.ToLower()));
                    }

                    //total number of rows counts   
                    recordsTotal = customerData.Count();
                    //Paging   
                    var data = customerData.Skip(skip).Take(pageSize).ToList();
                    //Returning Json Data  
                    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }



        }

        // START rekanan
        public IActionResult LoadDataRekanan()
        {
            if (HttpContext.Session.GetString("NPP") != null)
            {
                try
                {
                    var customerData = _context.MstRekanan
                     .Select(p => new { p.IdMstRekanan, p.NamaRekanan, p.Jenis, p.NoTelp, p.Email, p.Alamat, p.Kota, p.Kodepos, p.KontakPerson, p.NoHp, p.Npwp, p.IsAktif });

                    return Json(new { data = customerData });

                }
                catch (Exception)
                {
                    throw;
                }
            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult AddEditRekanan(int id = 0)
        {
            if (HttpContext.Session.GetString("NPP") != null)
            {
                if (id == 0)
                {
                    return View(new MstRekanan());
                }
                else
                {
                    return View(_context.MstRekanan.Where(x => x.IdMstRekanan.Equals(id)).FirstOrDefault());
                }
            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostRekanan([FromBody]  MstRekanan mstrekanan)
        {
            if (HttpContext.Session.GetString("NPP") != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (mstrekanan.IdMstRekanan == 0)
                {
                    mstrekanan.IdMstRekanan = _context.MstRekanan.Max(p => p.IdMstRekanan) + 1;
                    _context.MstRekanan.Add(mstrekanan);

                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Add new data success." });
                }
                else
                {
                    _context.Update(mstrekanan);

                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Edit data success." });
                }
            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }

        // DELETE: api/Todo/5
        [HttpDelete("SimkaAdmin/DeleteRekanan/{id}")]
        public async Task<IActionResult> DeleteRekanan([FromRoute] int id)
        {
            if (HttpContext.Session.GetString("NPP") != null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var todo = await _context.MstRekanan.SingleOrDefaultAsync(m => m.IdMstRekanan == id);
                if (todo == null)
                {
                    return NotFound();
                }

                _context.MstRekanan.Remove(todo);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Delete success." });
            }
            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        // end rekanan
        // Start Pengembangan
        public IActionResult LoadDataRefPengembangan()
        {

            try
            {
                var customerData = _context.RefPengembangan
                 .Select(p => new { p.IdRefPengembangan, p.Deskripsi, jenisapr = p.IdRefJnsAppraisaliNavigation.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefPengembangan(int id = 0)
        {
            if (id == 0)
            {

                var balikan = new GabungPengembangan()

                {
                    // mengambil  daftar jenis appraisal untuk dipopualte dalam select
                    jenis = _context.RefJenisAppraisal.ToList(),

                    IdRefPengembangan = id


                };
                return View(balikan);
            }
            else
            {
                var butir = _context.RefPengembangan.Where(x => x.IdRefPengembangan.Equals(id)).FirstOrDefault();
                var balikan = new GabungPengembangan()
                {

                    jenis = _context.RefJenisAppraisal.ToList(),
                    //mengambil data appraisal yang dipilih
                    IdRefPengembangan = id,
                    IdRefJnsAppraisal = butir.IdRefJnsAppraisal,
                    Deskripsi = butir.Deskripsi
                };

                return View(balikan);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostRefPengembangan([FromBody]  RefPengembangan mstrekanan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (mstrekanan.IdRefPengembangan == 0)
            {
                //  mstrekanan.IdRefPengembangan = _context.RefPengembangan.Max(p => p.IdRefPengembangan) + 1;
                _context.RefPengembangan.Add(mstrekanan);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(mstrekanan);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }

        [HttpDelete("SimkaAdmin/DeletePengembangan/{id}")]
        public async Task<IActionResult> DeleteRefPengembangan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefPengembangan.SingleOrDefaultAsync(m => m.IdRefPengembangan == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefPengembangan.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Pengembangan


        // Start Pengembangan
        public IActionResult LoadDataTrPengembangan()
        {

            try
            {
                var customerData = _context.RefPengembangan
                 .Select(p => new { p.IdRefPengembangan, p.Deskripsi, jenisapr = p.IdRefJnsAppraisaliNavigation.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
   
        [HttpPost]
        public async Task<IActionResult> PostPengembangan([FromBody]  RefPengembangan mstrekanan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (mstrekanan.IdRefPengembangan == 0)
            {
                //  mstrekanan.IdRefPengembangan = _context.RefPengembangan.Max(p => p.IdRefPengembangan) + 1;
                _context.RefPengembangan.Add(mstrekanan);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(mstrekanan);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }

        [HttpDelete("SimkaAdmin/DeletePengembangan/{id}")]
        public async Task<IActionResult> DeletePengembangan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefPengembangan.SingleOrDefaultAsync(m => m.IdRefPengembangan == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefPengembangan.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Pengembangan

        // Start Unit
        public IActionResult LoadDataUnit()
        {

            try
            {
                var customerData = _context.MstUnit
                 .Select(p => new { p.IdUnit, p.NamaUnit, p.NppNavigation.Nama });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult LoadDataTahunAkademik()
        {

            try
            {
                var customerData = _context.TblTahunAkademik
                 .Select(p => new { p.IdTahunAkademik, p.TahunAkademik }).OrderByDescending(m => m.TahunAkademik);

                return Json(customerData);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult LoadDataKaryaa()
        {

            try
            {
                var customerData = _context.MstKaryawan
                 .Select(p => new { p.Npp, p.NamaLengkapGelar }).OrderBy(m => m.NamaLengkapGelar);

                return Json(customerData);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditUnit(int id = 0)
        {
            if (id == 0)
            {

                var balikan = new GabungUnit()

                {
                    // mengambil  daftar jenis appraisal untuk dipopualte dalam select
                    kepala = _context.MstKaryawan.Select(p => new kepala { Npp = p.Npp, Nama = p.Nama }).ToList(),
                    IdUnit = id


                };
                return View(balikan);
            }
            else
            {
                var butir = _context.MstUnit.Where(x => x.IdUnit.Equals(id)).FirstOrDefault();
                var balikan = new GabungUnit()
                {
                    kepala = _context.MstKaryawan.Select(p => new kepala { Npp = p.Npp, Nama = p.Nama }).OrderBy(c => c.Nama).ToList(),
                    IdUnit = id,
                    Npp = butir.Npp

                };

                return View(balikan);
            }
        }
        [HttpPost]
        public IActionResult PostUnit([FromBody]  MstUnit mstrekanan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                {
                    var result = _context.MstUnit.SingleOrDefault(b => b.IdUnit == mstrekanan.IdUnit);
                    if (result != null)
                    {
                        result.Npp = mstrekanan.Npp;
                        _context.SaveChanges();

                        return Json(new { success = true, message = "Update success." });
                    }
                    else

                        return Json(new { success = true, message = "UPDATE GAGAL" });
                }
            }
        }


        // end Unit
        // Start Payroll
        public IActionResult LoadDataPayroll()
        {

            try
            {
                var customerData = _context.MstTarifPayroll
                 .Select(p => new
                 {
                     p.IdMstTarifPayroll,
                     struktural = p.IdRefJabatanStrukturalNavigation.Deskripsi,
                     akademik = p.IdRefJabatanAkademikNavigation.Deskripsi,
                     golongan = p.IdRefGolonganNavigation.Deskripsi,
                     fungsional = p.IdRefFungsionalNavigation.Deskripsi,
                     jenjang = p.idRefJenjangNavigation.Deskripsi,
                     p.NamaTarifPayroll,
                     p.Masakerja,
                     p.Nominal,
                     p.Ket1,
                     p.Jenis,
                     p.JenjangKelas
                 });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditPayroll(int id = 0)
        {
            if (id == 0)
            {

                var balikan = new GabungPayroll()

                {
                    struktural = _context.RefJabatanStruktural.ToList(),
                    akademik = _context.RefJabatanAkademik.ToList(),
                    golongan = _context.RefGolongan.ToList(),
                    fungsional = _context.RefFungsional.ToList(),
                    jenjang = _context.RefJenjang.ToList(),

                    IdMstTarifPayroll = id,


                };
                return View(balikan);
            }
            else
            {
                var butir = _context.MstTarifPayroll.Where(x => x.IdMstTarifPayroll.Equals(id)).FirstOrDefault();
                var balikan = new GabungPayroll()
                {

                    struktural = _context.RefJabatanStruktural.ToList(),

                    akademik = _context.RefJabatanAkademik.ToList(),
                    golongan = _context.RefGolongan.ToList(),
                    fungsional = _context.RefFungsional.ToList(),
                    jenjang = _context.RefJenjang.ToList(),

                    IdMstTarifPayroll = id,
                    IdRefJbtnAkademik = butir.IdRefJbtnAkademik,
                    IdRefJenjang = butir.IdRefJenjang,
                    IdRefStruktural = butir.IdRefStruktural,
                    IdRefFungsional = butir.IdRefFungsional,
                    IdRefGolongan = butir.IdRefGolongan,
                    NamaTarifPayroll = butir.NamaTarifPayroll,
                    Nominal = butir.Nominal,
                    Jenis = butir.Jenis,
                    JenjangKelas = butir.JenjangKelas

                };

                return View(balikan);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostPayroll([FromBody]  MstTarifPayroll mstrekanan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (mstrekanan.IdMstTarifPayroll == 0)
            {
                //  mstrekanan.IdRefPengembangan = _context.RefPengembangan.Max(p => p.IdRefPengembangan) + 1;
                _context.MstTarifPayroll.Add(mstrekanan);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(mstrekanan);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }


        public async Task<IActionResult> DeletePayroll([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.MstTarifPayroll.SingleOrDefaultAsync(m => m.IdMstTarifPayroll == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.MstTarifPayroll.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Payroll

        // Start Jenis Test Detail
        public IActionResult LoadDataRefJenisTestDetail()
        {

            try
            {
                var customerData = _context.RefJenisTestDetail
                 .Select(p => new { p.IdRefJenisTestDetail, p.Deskripsi, jenistest = p.IdRefJenisTestNavigation.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefJenisTestDetail(int id = 0)
        {
            if (id == 0)
            {

                var balikan = new GabungTestDetail()

                {
                    // mengambil  daftar jenis appraisal untuk dipopualte dalam select
                    jenis = _context.RefJenisTest.ToList(),

                    IdRefJenisTestDetail = id


                };
                return View(balikan);
            }
            else
            {
                var butir = _context.RefJenisTestDetail.Where(x => x.IdRefJenisTestDetail.Equals(id)).FirstOrDefault();
                var balikan = new GabungTestDetail()
                {

                    jenis = _context.RefJenisTest.ToList(),
                    IdRefJenisTestDetail = id,
                    IdRefJenisTest = butir.IdRefJenisTest,
                    Deskripsi = butir.Deskripsi
                };

                return View(balikan);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostRefJenisTestDetail([FromBody]  RefJenisTestDetail mstrekanan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (mstrekanan.IdRefJenisTestDetail == 0)
            {
                //  mstrekanan.IdRefPengembangan = _context.RefPengembangan.Max(p => p.IdRefPengembangan) + 1;
                _context.RefJenisTestDetail.Add(mstrekanan);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(mstrekanan);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }
        public async Task<IActionResult> DeleteRefJenisTestDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefJenisTestDetail.SingleOrDefaultAsync(m => m.IdRefJenisTestDetail == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefJenisTestDetail.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Jenis Test Detail



        // Start  Ref Keluarga
        public IActionResult LoadDataRefKeluarga()
        {

            try
            {
                var customerData = _context.RefKeluarga
                 .Select(p => new { p.IdRefKeluarga, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefKeluarga(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefKeluarga());
            }
            else
            {
                return View(_context.RefKeluarga.Where(x => x.IdRefKeluarga.Equals(id)).FirstOrDefault());
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRefKeluarga([FromBody]  RefKeluarga refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefKeluarga == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefKeluarga.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }

        }

        public async Task<IActionResult> DeleteRefKeluarga([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefKeluarga.SingleOrDefaultAsync(m => m.IdRefKeluarga == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefKeluarga.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Keluarga ********************************************************************************************************

        // Start  Ref Jenis Kelas
        public IActionResult LoadDataRefJenisKelas()
        {

            try
            {
                var customerData = _context.RefJenisKelas
                 .Select(p => new { p.IdRefJenisKelas, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefJenisKelas(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefJenisKelas());
            }
            else
            {
                return View(_context.RefJenisKelas.Where(x => x.IdRefJenisKelas.Equals(id)).FirstOrDefault());
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRefJenisKelas([FromBody]  RefJenisKelas refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefJenisKelas == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefJenisKelas.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }

        }

        public async Task<IActionResult> DeleteRefJenisKelas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefJenisKelas.SingleOrDefaultAsync(m => m.IdRefJenisKelas == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefJenisKelas.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Jenis kelas ********************************************************************************************************

        // Start  Ref Piutabg
        public IActionResult LoadDataRefPiutang()
        {

            try
            {
                var customerData = _context.RefPiutang
                 .Select(p => new { p.IdRefPiutang, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefPiutang(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefPiutang());
            }
            else
            {
                return View(_context.RefPiutang.Where(x => x.IdRefPiutang.Equals(id)).FirstOrDefault());
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRefPiutang([FromBody]  RefPiutang refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefPiutang == 0)
            {
                refJenisAppraisal.IdRefPiutang = _context.RefPiutang.Max(p => p.IdRefPiutang) + 1;
                _context.RefPiutang.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }

        }

        public async Task<IActionResult> DeleteRefPiutang([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefPiutang.SingleOrDefaultAsync(m => m.IdRefPiutang == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefPiutang.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Piutang ********************************************************************************************************



        // Start  Ref Jenis Semester
        public IActionResult LoadDataRefJenisSemester()
        {

            try
            {
                var customerData = _context.RefJenisSemester
                 .Select(p => new { p.IdRefJenisSemester, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefJenisSemester(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefJenisSemester());
            }
            else
            {
                return View(_context.RefJenisSemester.Where(x => x.IdRefJenisSemester.Equals(id)).FirstOrDefault());
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRefJenisSemester([FromBody]  RefJenisSemester refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefJenisSemester == 0)
            {
                //refJenisAppraisal.IdRefJenisSemester = _context.RefPiutang.Max(p => p.idre) + 1;
                _context.RefJenisSemester.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }

        }

        public async Task<IActionResult> DeleteRefJenisSemester([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefJenisSemester.SingleOrDefaultAsync(m => m.IdRefJenisSemester == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefJenisSemester.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Jenis Semester **********************************************************************************************

        // Start  Ref Jenis Test
        public IActionResult LoadDataRefJenisTest()
        {

            try
            {
                var customerData = _context.RefJenisTest
                 .Select(p => new { p.IdRefJenisTest, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefJenisTest(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefJenisTest());
            }
            else
            {
                return View(_context.RefJenisTest.Where(x => x.IdRefJenisTest.Equals(id)).FirstOrDefault());
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRefJenisTest([FromBody]  RefJenisTest refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefJenisTest == 0)
            {
                //refJenisAppraisal.IdRefJenisSemester = _context.RefPiutang.Max(p => p.idre) + 1;
                _context.RefJenisTest.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }

        }

        public async Task<IActionResult> DeleteRefJenisTest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefJenisTest.SingleOrDefaultAsync(m => m.IdRefJenisTest == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefJenisTest.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Jenis Test**********************************************************************************************


        // Start  Ref potonmgan
        public IActionResult LoadDataRefPotongan()
        {

            try
            {
                var customerData = _context.RefPotonganP
                 .Select(p => new { p.IdRefPotongan, p.NamaPotongan, p.Nominal, p.IsTetap });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefPotongan(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefPotonganP());
            }
            else
            {
                return View(_context.RefPotonganP.Where(x => x.IdRefPotongan.Equals(id)).FirstOrDefault());
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRefPotongan([FromBody]  RefPotonganP refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefPotongan == 0)
            {
                refJenisAppraisal.IdRefPotongan = _context.RefPotonganP.Max(p => p.IdRefPotongan) + 1;
                _context.RefPotonganP.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }

        }

        public async Task<IActionResult> DeleteRefPotongan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefPotonganP.SingleOrDefaultAsync(m => m.IdRefPotongan == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefPotonganP.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Potongan

        // Start  Ref Jenjang
        public IActionResult LoadDataRefJenjang()
        {

            try
            {
                var customerData = _context.RefJenjang
                 .Select(p => new { p.IdRefJenjang, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefJenjang(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefJenjang());
            }
            else
            {
                return View(_context.RefJenjang.Where(x => x.IdRefJenjang.Equals(id)).FirstOrDefault());
            }

        }
        [HttpPost]
        public async Task<IActionResult> PostRefJenjang([FromBody]  RefJenjang refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefJenjang == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefJenjang.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }



        }

        // DELETE: api/Todo/5

        public async Task<IActionResult> DeleteRefJenjang([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefJenjang.SingleOrDefaultAsync(m => m.IdRefJenjang == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefJenjang.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Jenjang


        // Start  Ref Status Studi
        public IActionResult LoadDataRefStatusStudi()
        {

            try
            {
                var customerData = _context.RefStatusStudi
                 .Select(p => new { p.IdRefSs, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefStatusStudi(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefStatusStudi());
            }
            else
            {
                return View(_context.RefStatusStudi.Where(x => x.IdRefSs.Equals(id)).FirstOrDefault());
            }

        }
        [HttpPost]
        public async Task<IActionResult> PostRefStatusStudi([FromBody]  RefStatusStudi refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefSs == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefStatusStudi.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }

        // DELETE: api/Todo/5

        public async Task<IActionResult> DeleteRefStatusStudi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefStatusStudi.SingleOrDefaultAsync(m => m.IdRefSs == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefStatusStudi.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Status Studi

        // Start  Ref TR AKADEMIK
        public IActionResult LoadDataRefTrAkademik()
        {

            try
            {
                var customerData = _context.RefTrAkademik
                 .Select(p => new { p.IdRefTrAkademik, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult AddEditRefTrAkademik(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefTrAkademik());
            }
            else
            {
                return View(_context.RefTrAkademik.Where(x => x.IdRefTrAkademik.Equals(id)).FirstOrDefault());
            }

        }
        [HttpPost]
        public async Task<IActionResult> PostRefTrAkademik([FromBody]  RefTrAkademik refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefTrAkademik == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefTrAkademik.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }

        // DELETE: api/Todo/5

        public async Task<IActionResult> DeleteRefTrAkademik([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefTrAkademik.SingleOrDefaultAsync(m => m.IdRefTrAkademik == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefTrAkademik.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref TR AKADEMIK

        // Start Ref Fungsional
        public IActionResult LoadDataRefFungsional()
        {

            try
            {
                var customerData = _context.RefFungsional
                 .Select(p => new { p.IdRefFungsional, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefFungsional(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefFungsional());
            }
            else
            {
                return View(_context.RefFungsional.Where(x => x.IdRefFungsional.Equals(id)).FirstOrDefault());
            }

        }
        [HttpPost]
        public async Task<IActionResult> PostRefFungsional([FromBody]  RefFungsional refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefFungsional == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefFungsional.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }
        public async Task<IActionResult> DeleteRefFungsional([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefFungsional.SingleOrDefaultAsync(m => m.IdRefFungsional == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefFungsional.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Fungsional

        // Start Ref Restitusi
        public IActionResult LoadDataRefRestitusi()
        {

            try
            {
                var customerData = _context.RefRestitusi
                 .Select(p => new { p.IdRefRestitusi, p.Deskripsi, p.Nominal, p.IsActive });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefRestitusi(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefRestitusi());
            }
            else
            {
                return View(_context.RefRestitusi.Where(x => x.IdRefRestitusi.Equals(id)).FirstOrDefault());
            }

        }
        [HttpPost]
        public async Task<IActionResult> PostRefRestitusi([FromBody]  RefRestitusi refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefRestitusi == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefRestitusi.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }
        public async Task<IActionResult> DeleteRefRestitusi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefRestitusi.SingleOrDefaultAsync(m => m.IdRefRestitusi == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefRestitusi.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Restitusi

        // Start ref Kompetensi
        public IActionResult LoadDataRefKompetensi()
        {

            try
            {
                var customerData = _context.RefKompetensi
                 .Select(p => new { p.IdRefKompetensi, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefKompetensi(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefKompetensi());
            }
            else
            {
                return View(_context.RefKompetensi.Where(x => x.IdRefKompetensi.Equals(id)).FirstOrDefault());
            }

        }
        [HttpPost]
        public async Task<IActionResult> PostRefKompetensi([FromBody]  RefKompetensi refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefKompetensi == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefKompetensi.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }
        public async Task<IActionResult> DeleteRefKompetensi([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefKompetensi.SingleOrDefaultAsync(m => m.IdRefKompetensi == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefKompetensi.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Keluarga
        // Start Ref Golongan
        public IActionResult LoadDataRefGolongan()
        {

            try
            {
                var customerData = _context.RefGolongan
                 .Select(p => new { p.IdRefGolongan, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefGolongan(String id = "0")
        {
            if (id == "0")
            {
                return View(new RefGolongan());
            }
            else
            {
                return View(_context.RefGolongan.Where(x => x.IdRefGolongan.Equals(id)).FirstOrDefault());
            }

        }



        [HttpPost]
        public async Task<IActionResult> PostRefGolongan([FromBody]  RefGolongan refJenisAppraisal)

        {
            String id = refJenisAppraisal.IdRefGolongan;
            var golonganada = await _context.RefGolongan.AnyAsync(x => x.IdRefGolongan == id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!golonganada)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                //code ini buat mengambil id baru dari database

                _context.RefGolongan.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }
        public async Task<IActionResult> DeleteRefGolongan(String id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefGolongan.SingleOrDefaultAsync(m => m.IdRefGolongan == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefGolongan.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Ref Golongan


        // Start ButirAppraisal
        public IActionResult LoadDataButirAppraisal()
        {

            try
            {
                var customerData = _context.RefButirAppraisal
                 .Select(p => new
                 {
                     p.IdRefAppraisal,
                     jenisapr = p.IdRefJnsAppraisalNavigation.Deskripsi,
                     p.Deskripsi,
                     fungsional = p.IdRefFungsionalNavigation.Deskripsi
                 });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditButirAppraisal(int id = 0)
        {
            if (id == 0)
            {
                var balikan = new GabungButirAppraisal

                {
                    // mengambil daftar fungsional dan daftar jenis appraisal untuk dipopualte dalam select
                    fungsi = _context.RefFungsional.ToList(),
                    jenis = _context.RefJenisAppraisal.ToList(),
                    IdRefAppraisal = id
                };

                return View(balikan);
            }
            else
            {
                var butir = _context.RefButirAppraisal.Where(x => x.IdRefAppraisal.Equals(id)).FirstOrDefault();
                var balikan = new GabungButirAppraisal
                {
                    fungsi = _context.RefFungsional.ToList(),
                    jenis = _context.RefJenisAppraisal.ToList(),
                    //mengambil data appraisal yang dipilih
                    IdRefAppraisal = id,
                    IdRefJnsAppraisal = butir.IdRefJnsAppraisal,
                    IdRefFungsional = butir.IdRefFungsional,
                    Deskripsi = butir.Deskripsi
                };

                return View(balikan);
            }

        }
        [HttpPost]
        public async Task<IActionResult> PostButirAppraisal([FromBody] RefButirAppraisal refButirAppraisal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refButirAppraisal.IdRefAppraisal == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefButirAppraisal.Add(refButirAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refButirAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }
        // DELETE: api/Todo/5
        [HttpDelete("SimkaAdmin/DeleteButirAppraisal/{id}")]
        public async Task<IActionResult> DeleteButirAppraisal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefButirAppraisal.SingleOrDefaultAsync(m => m.IdRefAppraisal == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefButirAppraisal.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Butir Appraisal

        //Appraisal
        public IActionResult LoadDataAppraisal()
        {

            try
            {
                var customerData = _context.RefJenisAppraisal
                 .Select(p => new { p.IdRefJnsAppraisal, p.Deskripsi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditAppraisal(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefJenisAppraisal());
            }
            else
            {
                return View(_context.RefJenisAppraisal.Where(x => x.IdRefJnsAppraisal.Equals(id)).FirstOrDefault());
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostAppraisal([FromBody]  RefJenisAppraisal refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefJnsAppraisal == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefJenisAppraisal.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }

        }
        public async Task<IActionResult> DeleteAppraisal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefJenisAppraisal.SingleOrDefaultAsync(m => m.IdRefJnsAppraisal == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefJenisAppraisal.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Appraisal

        // Start JabatanAkademik
        public IActionResult LoadDataRefJabatanAkademik()
        {

            try
            {
                var customerData = _context.RefJabatanAkademik
                 .Select(p => new
                 {
                     p.IdRefJbtnAkademik,
                     fungsional = p.IdRefFungsionalNavigation.Deskripsi,
                     p.Deskripsi

                 });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefJabatanAkademik(int id = 0)
        {
            if (id == 0)
            {
                var balikan = new GabungJabatanAkademik

                {
                    // mengambil daftar fungsional dan daftar jenis appraisal untuk dipopualte dalam select
                    Fungsi = _context.RefFungsional.ToList(),
                    IdRefJbtnAkademik = id


                };

                return View(balikan);
            }
            else
            {
                var butir = _context.RefJabatanAkademik.Where(x => x.IdRefJbtnAkademik.Equals(id)).FirstOrDefault();
                var balikan = new GabungJabatanAkademik
                {
                    Fungsi = _context.RefFungsional.ToList(),

                    //mengambil data jabatan akademik yang telah dipilih
                    IdRefJbtnAkademik = id,
                    IdRefFungsional = butir.IdRefFungsional,
                    Deskripsi = butir.Deskripsi
                };

                return View(balikan);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRefJabatanAkademik([FromBody] RefJabatanAkademik refButirAppraisal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refButirAppraisal.IdRefJbtnAkademik == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefJabatanAkademik.Add(refButirAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refButirAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }
        public async Task<IActionResult> DeleteRefJabatanAkademik([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefJabatanAkademik.SingleOrDefaultAsync(m => m.IdRefJbtnAkademik == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefJabatanAkademik.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end jabatan akademik



        // Start  jabatan Strukrual
        public IActionResult LoadDataRefJabatanStruktural()
        {

            try
            {
                var customerData = _context.RefJabatanStruktural
                 .Select(p => new { p.IdRefStruktural, p.Deskripsi, p.SetaraSks, p.KelasAsuransi });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditRefJabatanStruktural(int id = 0)
        {
            if (id == 0)
            {
                return View(new RefJabatanStruktural());
            }
            else
            {
                return View(_context.RefJabatanStruktural.Where(x => x.IdRefStruktural.Equals(id)).FirstOrDefault());
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRefJabatanStruktural([FromBody]  RefJabatanStruktural refJenisAppraisal)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (refJenisAppraisal.IdRefStruktural == 0)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                _context.RefJabatanStruktural.Add(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(refJenisAppraisal);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }

        }

        public async Task<IActionResult> DeleteRefJabatanStruktural([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.RefJabatanStruktural.SingleOrDefaultAsync(m => m.IdRefStruktural == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.RefJabatanStruktural.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        // end Jabatan Struktural********************************************************************************************************


        //start surat keputusan
        public IActionResult LoadDataSuratKeputusan()
        {

            try
            {
                var customerData = _context.HstSk
                 .Select(p => new { p.NoSk, p.DeskripsiSk, p.TglAwal, p.TglAkhir });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditSuratKeputusan(string nosk = "0")
        {
            if (nosk == "0")
            {

                var balikan = new HstSkForm()
                {

                };
                return View(balikan);
            }
            else
            {
                var sk = _context.HstSk.Where(x => x.NoSk.Equals(nosk)).FirstOrDefault();

                var balikan = new HstSkForm()
                {
                    NoSk = sk.NoSk,
                    DateInserted = sk.DateInserted,
                    DeskripsiSk = sk.DeskripsiSk,
                    FileSk = sk.FileSk,
                    LevelSk = sk.LevelSk,
                    TglAkhir = sk.TglAkhir,
                    IdTahunAkademik = sk.IdTahunAkademik,
                    NoSemester = sk.NoSemester,
                    TglAwal = sk.TglAwal,
                    TglSk = sk.TglSk,

                };

                return View(balikan);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostSuratKeputusan(HstSkForm data)

        {
            String id = data.NoSk;
            var golonganada = await _context.HstSk.AnyAsync(x => x.NoSk == id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            HstSk skdb = await _context.HstSk.AsNoTracking().FirstOrDefaultAsync(x => x.NoSk == id);
            //mengambil data dari form
            data.DateInserted = DateTime.Now;
            var input = new HstSk();
            input.NoSk = data.NoSk;
            input.DeskripsiSk = data.DeskripsiSk;
            input.DateInserted = data.DateInserted;
            input.LevelSk = data.LevelSk;
            input.TglSk = data.TglSk;
            input.TglAwal = data.TglAwal;
            input.TglAkhir = data.TglAkhir;
            input.NoSemester = data.NoSemester;
            input.IdTahunAkademik = data.IdTahunAkademik;
            if (data.FileSkform != null && data.FileSkform.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = data.FileSkform.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                input.FileSk = p1;

            }
            else if (skdb != null)
                data.FileSk = skdb.FileSk;
            else data.FileSk = null;

            if (!golonganada)
            {
                // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
                //code ini buat mengambil id baru dari database

                _context.HstSk.Add(input);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(input);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }



        public async Task<IActionResult> DeleteSuratKeputusan([FromRoute] String id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.HstSk.SingleOrDefaultAsync(m => m.NoSk == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.HstSk.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        public IActionResult LoadDataListSK(string nosk = "0")
        {
            try
            {
                var customerData = _context.TblSkKaryawan
                     .Where(x => x.NoSk.Equals(nosk))
                 .Select(p => new { p.Npp, p.NppNavigation.Nama, p.Peran, p.TglAwal, p.TglAkhir })
                ;

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddEditListSK(string nosk = "0")
        {

            var balikan = new GabungListSk()
            {
                NoSk = nosk,
                karyawans = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.Nama }).OrderBy(c => c.Nama).ToList(),
            };

            return View(balikan);


        }
        public async Task<IActionResult> DeleteListSK(string npp, string nosk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.TblSkKaryawan.AsNoTracking().SingleOrDefaultAsync(m => (m.Npp == npp && m.NoSk == nosk));
            if (todo == null)
            {
                return NotFound();
            }

            _context.TblSkKaryawan.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }
        public async Task<IActionResult> PostListSK([FromBody]  TblSkKaryawan refJenisAppraisal)

        {

            // refJenisAppraisal.IdRefJnsAppraisal = _context.RefJenisAppraisal.Max(p => p.IdRefJnsAppraisal) + 1;
            //code ini buat mengambil id baru dari database

            _context.TblSkKaryawan.Add(refJenisAppraisal);

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Add new data success." });
        }



        //end surat keputusan

        public IActionResult LoadDataRiwayatPendidikanSedangStudi( int fungsional=0)
        {
            try
            {
                if(fungsional!=0)
                {
                    var customerData = _context.TrRiwayatPendidikan.Where(x => x.IdRefJenjang.Equals(fungsional) &&  x.IdRefSs ==1)
                   .Select(x => new
                   {
                       x.Npp,
                       x.IdRefJenjangNavigation.Deskripsi,
                       x.NamaSekolah,
                       x.NppNavigation.NamaLengkapGelar,
                       x.TahunLulus,
                       x.Jurusan,
                       x.ProgramStudi,
                       x.IdTrRp,
                       status = x.IdRefSsNavigation.Deskripsi
                   });
                    return Json(new { data = customerData });

                }else 
                {
                    {
                        var customerData = _context.TrRiwayatPendidikan.Where(x => x.IdRefSs == 1)
                       .Select(x => new
                       {
                           x.Npp,
                           x.IdRefJenjangNavigation.Deskripsi,
                           x.NamaSekolah,
                           x.NppNavigation.NamaLengkapGelar,
                           x.TahunLulus,
                           x.Jurusan,
                           x.ProgramStudi,
                           x.IdTrRp,
                           status = x.IdRefSsNavigation.Deskripsi
                       });
                        return Json(new { data = customerData });

                    }
                }
              



                

            }
            catch (Exception)
            {
                throw;
            }

        }
        //start riwayat pendidikan

        //keluarga
        public IActionResult LoadDataRiwayatPendidikan()
        {
            try
            {
                var customerData = _context.TrRiwayatPendidikan
                    .Select(x => new
                    {
                        x.Npp,
                        x.IdRefJenjangNavigation.Deskripsi,
                        x.NamaSekolah,
                        x.NppNavigation.NamaLengkapGelar,
                        x.TahunLulus,
                        x.Jurusan,
                        x.ProgramStudi,
                        x.IdTrRp,
                        status = x.IdRefSsNavigation.Deskripsi
                    });



                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }

        }
        public IActionResult AddEditRiwayatPendidikan(int id = 0)
        {
            if (id == 0)
            {

                var balikan = new TrRiwayatPendidikanForm()

                {
                    // mengambil  daftar jenis appraisal untuk dipopualte dalam select
                    karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.Nama }).ToList(),
                    jenjang = _context.RefJenjang.Select(x => new RefJenjang { IdRefJenjang = x.IdRefJenjang, Deskripsi = x.Deskripsi }).ToList(),
                    StatusStudi = _context.RefStatusStudi.Select(x => new RefStatusStudi { IdRefSs = x.IdRefSs, Deskripsi = x.Deskripsi }).ToList(),



                };
                return View(balikan);
            }
            else
            {
                var rp = _context.TrRiwayatPendidikan.Where(x => x.IdTrRp.Equals(id)).FirstOrDefault();
                var balikan = new TrRiwayatPendidikanForm()
                {
                    karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.Nama }).ToList(),
                    jenjang = _context.RefJenjang.Select(x => new RefJenjang { IdRefJenjang = x.IdRefJenjang, Deskripsi = x.Deskripsi }).ToList(),
                    StatusStudi = _context.RefStatusStudi.Select(x => new RefStatusStudi { IdRefSs = x.IdRefSs, Deskripsi = x.Deskripsi }).ToList(),
                    IdTrRp = rp.IdTrRp,
                    IdRefSs = rp.IdRefSs,
                    IdRefJenjang = rp.IdRefJenjang,
                    AsalBeasiswa = rp.AsalBeasiswa,
                    Fakultas = rp.Fakultas,
                    Gelar = rp.Gelar,
                    IdRefJenjangNavigation = rp.IdRefJenjangNavigation,
                    Ipk = rp.Ipk,
                    DateInserted = rp.DateInserted,
                    IdRefSsNavigation = rp.IdRefSsNavigation,
                    Jurusan = rp.Jurusan,
                    IsLast = rp.IsLast,
                    Keterangan = rp.Keterangan,
                    NoIjazah = rp.NoIjazah,
                    Npp = rp.Npp,
                    NamaSekolah = rp.NamaSekolah,
                    TglIjazah = rp.TglIjazah,
                    TahunLulus = rp.TahunLulus,
                    TahunMasuk = rp.TahunMasuk,
                    ProgramStudi = rp.ProgramStudi,
                    ScanIjazah = rp.ScanIjazah,
                    ScanTranskrip = rp.ScanTranskrip,
                    IsVerifiedKsdm = rp.IsVerifiedKsdm,
                    JenisFileIjazah = rp.JenisFileIjazah,
                    JenisFileTranskrip = rp.JenisFileTranskrip,




                };

                return View(balikan);
            }
        }

        public async Task<IActionResult> PostRiwayatPendidikan(TrRiwayatPendidikanForm rp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rpdb = _context.TrRiwayatPendidikan.AsNoTracking().FirstOrDefault(x => x.IdTrRp == rp.IdTrRp);
            rp.DateInserted = DateTime.Now; // mengganti tanggal isnserted
            TrRiwayatPendidikan data = new TrRiwayatPendidikan()
            {
                IdTrRp = rp.IdTrRp,
                IdRefSs = rp.IdRefSs,
                IdRefJenjang = rp.IdRefJenjang,
                AsalBeasiswa = rp.AsalBeasiswa,
                Fakultas = rp.Fakultas,
                Gelar = rp.Gelar,
                IdRefJenjangNavigation = rp.IdRefJenjangNavigation,
                Ipk = rp.Ipk,
                DateInserted = rp.DateInserted,
                IdRefSsNavigation = rp.IdRefSsNavigation,
                Jurusan = rp.Jurusan,
                IsLast = rp.IsLast,
                Keterangan = rp.Keterangan,
                NoIjazah = rp.NoIjazah,
                Npp = rp.Npp,
                NamaSekolah = rp.NamaSekolah,
                TglIjazah = rp.TglIjazah,
                TahunLulus = rp.TahunLulus,
                TahunMasuk = rp.TahunMasuk,
                ProgramStudi = rp.ProgramStudi,

                IsVerifiedKsdm = rp.IsVerifiedKsdm,
                JenisFileIjazah = rp.JenisFileIjazah,
                JenisFileTranskrip = rp.JenisFileTranskrip,


            };

            if (rp.ScanIjazahForm != null && rp.ScanIjazahForm.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = rp.ScanIjazahForm.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.ScanIjazah = p1;

            }
            else if (rpdb != null)
                data.ScanIjazah = rpdb.ScanIjazah;
            else data.ScanIjazah = null;
            if (rp.ScanTranskripForm != null && rp.ScanTranskripForm.Length > 0)
            {
                byte[] p1 = null;
                using (var fs1 = rp.ScanTranskripForm.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.ScanTranskrip = p1;

            }
            else if (rpdb != null)
                data.ScanTranskrip = rpdb.ScanTranskrip;
            else data.ScanTranskrip = null;
            if (data.IdTrRp == 0)
            {
                //  mstrekanan.IdRefPengembangan = _context.RefPengembangan.Max(p => p.IdRefPengembangan) + 1;
                _context.TrRiwayatPendidikan.Add(data);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Add new data success." });
            }
            else
            {
                _context.Update(data);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });
            }
        }


        public async Task<IActionResult> DeleteRiwayatPendidikan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.TrRiwayatPendidikan.SingleOrDefaultAsync(m => m.IdTrRp == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TrRiwayatPendidikan.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }

        //end riwayat pendidikan


        //Kelola Password

        public async Task<IActionResult> PostResetPassword(String npp)
        {

            try
            {



                var karyawandb = _context.MstKaryawan.AsNoTracking().FirstOrDefault(x => x.Npp == npp);

                karyawandb.Password = "1234567";
                _context.Update(karyawandb);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Reset Password berhasil" });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500; //Write your own error code
                Response.WriteAsync(ex.Message);
                return null;
            }
        }

        //End Kelola password

        // tampilan profil dosen
        public async Task<IActionResult> ProfilDosen(string npp)
        {

            if (HttpContext.Session.GetString("role") == "admin")
            //cek apakah login & sesuai dengan role
            {
                // simka part
                var balikan = new SimkaDosenPenelitian();

                balikan.Akademik = _context.MstUnitAkademik.FirstOrDefault(a => a.IdUnit == _context.MstKaryawan.FirstOrDefault(a => a.Npp == HttpContext.Session.GetString("NPP")).IdUnitAkademik);
                balikan.Penelitian = _context.TblPenelitian.Where(a => a.Npp == npp).ToList();
                balikan.Pengabdian = _context.TblPengabdian.Where(a => a.Npp == npp).ToList();
                //  balikan.Pengembangan = _context.TrPengembangan.Where(a => a.Npp == npp).ToList();

                balikan.Karyawan = _context.MstKaryawan
              .Include(m => m.IdRefFungsionalNavigation)
              .Include(m => m.IdRefGolonganNavigation)
              .Include(m => m.IdRefJbtnAkademikNavigation)
              .Include(m => m.IdRefTunjanganKhususNavigation)
              .Include(m => m.IdUnitNavigation)
              .Include(m => m.MstIdUnitNavigation)
              .FirstOrDefault(a => a.Npp == npp);
                //simka part

                var idDosen = balikan.Karyawan.ID_DOSEN_SISTER;


                return await Task.FromResult(View(balikan));
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }


        }

        [Route("/SimkaAdmin/LoadDataPengajaranAsync")]
        public async Task<IActionResult> LoadDataPengajaranAsync(string npp)
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("role") == "admin")
            {

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Sister_Token TokenSister = new Sister_Token();
                        var akun = new Sister_Akun();
                        akun.username = "GV3lhqNadhHePiwVQ5Y3Vw";
                        akun.password = "5QW4jKhZ8r8QDmYMHiepjHwpH/wcfTioexezIS9AS8XYPMPnNHhEHLbfpeDsP0R8";
                        akun.id_pengguna = "bd5df696-05d3-4db1-9e32-7c6be4e5ad36";
                        var json = JsonConvert.SerializeObject(akun);
                        var data = new StringContent(json, Encoding.UTF8, "application/json");
                        var url = "https://sister.uajy.ac.id/api.php/0.1/Login";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        PenelitianReq request = new PenelitianReq();
                        idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                        request.id_token = TokenSister.data.id_token;
                        request.id_dosen = idDosen;
                        request.updated_after = new Updated_After();
                        request.updated_after.bulan = "01";
                        request.updated_after.tahun = "1990";
                        request.updated_after.tanggal = "01";
                        json = JsonConvert.SerializeObject(request);
                        data = new StringContent(json, Encoding.UTF8, "application/json");
                        url = "https://sister.uajy.ac.id/api.php/0.1/Pengajaran";

                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();
                        var ajar = (Pengajaran)JsonConvert.DeserializeObject(apiResponse, typeof(Pengajaran));


                        return Json(new
                        {
                            ajar.data
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/SimkaAdmin/LoadDataPublikasi")]
        public async Task<IActionResult> LoadDataPublikasi(string npp)
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("role") == "admin")
            {

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Sister_Token TokenSister = new Sister_Token();
                        var akun = new Sister_Akun();
                        akun.username = "GV3lhqNadhHePiwVQ5Y3Vw";
                        akun.password = "5QW4jKhZ8r8QDmYMHiepjHwpH/wcfTioexezIS9AS8XYPMPnNHhEHLbfpeDsP0R8";
                        akun.id_pengguna = "bd5df696-05d3-4db1-9e32-7c6be4e5ad36";
                        var json = JsonConvert.SerializeObject(akun);
                        var data = new StringContent(json, Encoding.UTF8, "application/json");
                        var url = "https://sister.uajy.ac.id/api.php/0.1/Login";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        PenelitianReq request = new PenelitianReq();
                        idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                        request.id_token = TokenSister.data.id_token;
                        request.id_dosen = idDosen;
                        request.updated_after = new Updated_After();
                        request.updated_after.bulan = "01";
                        request.updated_after.tahun = "1990";
                        request.updated_after.tanggal = "01";
                        json = JsonConvert.SerializeObject(request);
                        data = new StringContent(json, Encoding.UTF8, "application/json");
                        url = "https://sister.uajy.ac.id/api.php/0.1/Publikasi";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();
                        var ajar = (Publikasi)JsonConvert.DeserializeObject(apiResponse, typeof(Publikasi));

                        return Json(new
                        {
                            ajar.data
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/SimkaAdmin/LoadDataPengabdian")]
        public async Task<IActionResult> LoadDataPengabdian(string npp)
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("NPP") != null)
            {

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Sister_Token TokenSister = new Sister_Token();
                        var akun = new Sister_Akun();
                        akun.username = "GV3lhqNadhHePiwVQ5Y3Vw";
                        akun.password = "5QW4jKhZ8r8QDmYMHiepjHwpH/wcfTioexezIS9AS8XYPMPnNHhEHLbfpeDsP0R8";
                        akun.id_pengguna = "bd5df696-05d3-4db1-9e32-7c6be4e5ad36";
                        var json = JsonConvert.SerializeObject(akun);
                        var data = new StringContent(json, Encoding.UTF8, "application/json");
                        var url = "https://sister.uajy.ac.id/api.php/0.1/Login";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        PenelitianReq request = new PenelitianReq();
                        idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                        request.id_token = TokenSister.data.id_token;
                        request.id_dosen = idDosen;
                        request.updated_after = new Updated_After();
                        request.updated_after.bulan = "01";
                        request.updated_after.tahun = "1990";
                        request.updated_after.tanggal = "01";
                        json = JsonConvert.SerializeObject(request);
                        data = new StringContent(json, Encoding.UTF8, "application/json");
                        url = "https://sister.uajy.ac.id/api.php/0.1/Pengabdian";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();
                        var ajar = (Pengabdian)JsonConvert.DeserializeObject(apiResponse, typeof(Pengabdian));

                        return Json(new
                        {
                            ajar.data
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/SimkaAdmin/LoadDataPenelitian")]
        public async Task<IActionResult> LoadDataPenelitian(string npp)
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("role") == "admin")
            {

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Sister_Token TokenSister = new Sister_Token();
                        var akun = new Sister_Akun();
                        akun.username = "GV3lhqNadhHePiwVQ5Y3Vw";
                        akun.password = "5QW4jKhZ8r8QDmYMHiepjHwpH/wcfTioexezIS9AS8XYPMPnNHhEHLbfpeDsP0R8";
                        akun.id_pengguna = "bd5df696-05d3-4db1-9e32-7c6be4e5ad36";
                        var json = JsonConvert.SerializeObject(akun);
                        var data = new StringContent(json, Encoding.UTF8, "application/json");
                        var url = "https://sister.uajy.ac.id/api.php/0.1/Login";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        PenelitianReq request = new PenelitianReq();
                        idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                        request.id_token = TokenSister.data.id_token;
                        request.id_dosen = idDosen;
                        request.updated_after = new Updated_After();
                        request.updated_after.bulan = "01";
                        request.updated_after.tahun = "1990";
                        request.updated_after.tanggal = "01";
                        json = JsonConvert.SerializeObject(request);
                        data = new StringContent(json, Encoding.UTF8, "application/json");
                        url = "https://sister.uajy.ac.id/api.php/0.1/Penelitian";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();
                        var ajar = (Penelitian)JsonConvert.DeserializeObject(apiResponse, typeof(Penelitian));

                        return Json(new
                        {
                            ajar.data
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult LoadDataRiwayatPendidikans(string npp)
        {
            try
            {
                var customerData = _context.TrRiwayatPendidikan.Where(x => x.Npp.Equals(npp))
                    .Select(x => new
                    {

                        x.IdRefJenjangNavigation.Deskripsi,
                        x.NamaSekolah,

                        x.TahunLulus,

                        x.ProgramStudi,

                        status = x.IdRefSsNavigation.Deskripsi
                    })

                    ;



                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }

        }
        public IActionResult LoadDataTrPengembanganDosen(string npp)
        {

            try
            {
                var customerData = _context.TrPengembangan.Where(x => x.Npp == npp)
                 .Select(p => new
                 {
                     p.IdTrPengembangan,
                     refPe = p.IdRefPengembanganNavigation.Deskripsi,
                     apr = p.IdRefJnsAppraisaliNavigation.Deskripsi,
                     p.Judul
                 });

                return Json(new { data = customerData });

            }
            catch (Exception)
            {
                throw;
            }
        }
        //// tampilan proful dosen

        // START mutasi
        public IActionResult LoadDataMutasi()
        {
            if (HttpContext.Session.GetString("NPP") != null)
            {
                try
                {
                    var customerData = _context.TrMutasi
                     .Select(p => new { p.IdTrMutasi, p.NoSk, p.Npp, p.NppNavigation.NamaLengkapGelar, p.IdUnitNavigation.NamaUnit });

                    return Json(new { data = customerData });

                }
                catch (Exception)
                {
                    throw;
                }
            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult AddEditMutasi(int id = 0)
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {
                if (id == 0)
                {
                    var balikan = new TrMutasiForm()
                    {
                        karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.NamaLengkapGelar }).ToList(),
                        unit = _context.MstUnit.Select(x => new MstUnit
                        {
                            IdUnit = x.IdUnit,
                            NamaUnit = x.NamaUnit
                        }).ToList(),
                    };

                    return View(balikan);
                }
                else
                {
                    var mutasi = _context.TrMutasi.Where(x => x.IdTrMutasi.Equals(id)).FirstOrDefault();
                    var balikan = new TrMutasiForm()
                    {
                        karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.NamaLengkapGelar }).ToList(),
                        unit = _context.MstUnit.Select(x => new MstUnit
                        {
                            IdUnit = x.IdUnit,
                            NamaUnit = x.NamaUnit
                        }).ToList(),
                        IdTrMutasi = mutasi.IdTrMutasi,
                        IdUnit = mutasi.IdUnit,
                        NoSk = mutasi.NoSk,
                        Npp = mutasi.Npp,


                    };
                    return View(balikan);
                }

            }
            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostMutasi([FromBody]  TrMutasi mutasi)
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var karyawandb = _context.MstKaryawan.AsNoTracking().FirstOrDefault(x => x.Npp == mutasi.Npp);

                var data = new TrMutasi()
                {

                    IdTrMutasi = mutasi.IdTrMutasi,
                    IdUnit = mutasi.IdUnit,
                    NoSk = mutasi.NoSk,
                    Npp = mutasi.Npp,


                };
                if (mutasi.IdTrMutasi == 0)
                {
                    // mstrekanan.IdMstRekanan = _context.MstRekanan.Max(p => p.IdMstRekanan) + 1;
                    _context.TrMutasi.Add(data);
                    karyawandb.IdUnit = data.IdUnit;
                    _context.Update(karyawandb);
                    await _context.SaveChangesAsync();


                    return Json(new { success = true, message = "Add new data success." });
                }
                else
                {
                    _context.Update(data);
                    karyawandb.IdUnit = mutasi.IdUnit;
                    _context.Update(karyawandb);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Edit data success." });
                }


            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }


        public IActionResult LoadDataUnitt()
        {

            try
            {
                var customerData = _context.MstUnit
                 .Select(p => new { p.IdUnit, p.NamaUnit });

                return Json(customerData);

            }
            catch (Exception)
            {
                throw;
            }
        }
        // end unit

        // START karir fungsional
        public IActionResult LoadDataKarirFungsional()
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {
                try
                {
                    var customerData = _context.TrKarirFungsional
                     .Select(p => new { p.IdKarir, p.NoSk, p.Npp, p.NppNavigation.NamaLengkapGelar,
                         lama = p.IdRefJbtnAkademikSblmNavigation.Deskripsi, baru = p.IdRefJbtnAkademikNavigation.Deskripsi, p.TglBerikut });

                    return Json(new { data = customerData });

                }
                catch (Exception)
                {
                    throw;
                }
            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult AddEditKarirFungsional(int id = 0)
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {
                if (id == 0)
                {
                    var balikan = new TrKarirFungsionalForm()
                    {
                        karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.NamaLengkapGelar }).ToList(),
                        akademik = _context.RefJabatanAkademik.Select(x => new RefJabatanAkademik { IdRefJbtnAkademik = x.IdRefJbtnAkademik,
                            Deskripsi = x.Deskripsi }).ToList(),
                    };

                    return View(balikan);
                }
                else
                {
                    var karirfungsional = _context.TrKarirFungsional.Where(x => x.IdKarir.Equals(id)).FirstOrDefault();
                    var balikan = new TrKarirFungsionalForm()
                    {
                        karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.NamaLengkapGelar }).ToList(),
                        akademik = _context.RefJabatanAkademik.Select(x => new RefJabatanAkademik
                        {
                            IdRefJbtnAkademik = x.IdRefJbtnAkademik,
                            Deskripsi = x.Deskripsi
                        }).ToList(),
                        BidangIlmu = karirfungsional.BidangIlmu,
                        IdKarir = karirfungsional.IdKarir,
                        IdRefJbtnAkademik = karirfungsional.IdRefJbtnAkademik,
                        JenisLokalNas = karirfungsional.JenisLokalNas,
                        IdRefJbtnAkademikSblm = karirfungsional.IdRefJbtnAkademikSblm,
                        NilaiA = karirfungsional.NilaiA,
                        NilaiB = karirfungsional.NilaiB,
                        NilaiC = karirfungsional.NilaiC,
                        NilaiD = karirfungsional.NilaiD,
                        NilaiTotal = karirfungsional.NilaiTotal,
                        NoSk = karirfungsional.NoSk,
                        Npp = karirfungsional.Npp,
                        TglBerikut = karirfungsional.TglBerikut,
                        Tmt = karirfungsional.Tmt


                    };
                    return View(balikan);
                }
            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostKarirFungsional([FromBody]  TrKarirFungsionalForm karirfungsional)
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = new TrKarirFungsional()
                {
                    BidangIlmu = karirfungsional.BidangIlmu,
                    IdKarir = karirfungsional.IdKarir,
                    IdRefJbtnAkademik = karirfungsional.IdRefJbtnAkademik,
                    JenisLokalNas = karirfungsional.JenisLokalNas,
                    IdRefJbtnAkademikSblm = karirfungsional.IdRefJbtnAkademikSblm,
                    NilaiA = karirfungsional.NilaiA,
                    NilaiB = karirfungsional.NilaiB,
                    NilaiC = karirfungsional.NilaiC,
                    NilaiD = karirfungsional.NilaiD,
                    NilaiTotal = karirfungsional.NilaiTotal,
                    NoSk = karirfungsional.NoSk,
                    Npp = karirfungsional.Npp,
                    TglBerikut = karirfungsional.TglBerikut,
                    Tmt = karirfungsional.Tmt


                };

                var karyawandb = _context.MstKaryawan.AsNoTracking().FirstOrDefault(x => x.Npp == karirfungsional.Npp);
                if (data.IdRefJbtnAkademikSblm == null)
                {
                    data.IdRefJbtnAkademikSblm = karyawandb.IdRefJbtnAkademik;
                }


                if (karirfungsional.IdKarir == 0)
                {
                    // mstrekanan.IdMstRekanan = _context.MstRekanan.Max(p => p.IdMstRekanan) + 1;
                    _context.TrKarirFungsional.Add(data);
                    karyawandb.IdRefJbtnAkademik = karirfungsional.IdRefJbtnAkademik;
                    _context.Update(karyawandb);
                    await _context.SaveChangesAsync();


                    return Json(new { success = true, message = "Add new data success." });
                }
                else
                {

                    _context.Update(data);
                    karyawandb.IdRefJbtnAkademik = karirfungsional.IdRefJbtnAkademik;
                    _context.Update(karyawandb);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Edit data success." });
                }


            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult LoadDataJabatanFungsionalRef()
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {
                try
                {
                    var customerData = _context.RefJabatanAkademik
                     .Select(p => new { p.IdRefFungsional, p.Deskripsi });

                    return Json(customerData);

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        // end rekanan
        public IActionResult KelolaPengembangan()
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {
                return View();
            }
            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult LoadDataTrPengembangann()
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {

                try
                {
                    var customerData = _context.TrPengembangan
                     .Select(p => new
                     {
                         p.Npp,
                         p.IdTrPengembangan,
                         refPe = p.IdRefPengembanganNavigation.Deskripsi,
                         apr = p.IdRefJnsAppraisaliNavigation.Deskripsi,
                         p.Judul
                     });

                    return Json(new { data = customerData });

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else 
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult AddEditPengembangan(int id = 0)
        {
            if (id == 0)
            {
                return View(new TrPengembanganForm()
                {
                    karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.NamaLengkapGelar }).ToList()
                });

            }
            else
            {
                var pengembangan = _context.TrPengembangan.Where(x => x.IdTrPengembangan.Equals(id)).FirstOrDefault();

                var balikan = new TrPengembanganForm()
                {
                    karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.NamaLengkapGelar }).ToList(),
                    IdTrPengembangan = pengembangan.IdTrPengembangan,
                    FilePengembangan = pengembangan.FilePengembangan,
                    Judul = pengembangan.Judul,
                    IssnIsbn = pengembangan.IssnIsbn,
                    Nilai = pengembangan.Nilai,
                    IdRefPengembangan = pengembangan.IdRefPengembangan,
                    IdRefAppraisal = pengembangan.IdRefAppraisal,
                    DanaLokal = pengembangan.DanaLokal,
                    TglMulai = pengembangan.TglMulai,
                    TglSelesai = pengembangan.TglSelesai,
                    Penerbit = pengembangan.Penerbit,
                    TingkatPeran = pengembangan.TingkatPeran,
                    Tempat = pengembangan.Tempat,
                    Peran = pengembangan.Peran,
                    SumberDana = pengembangan.SumberDana,
                    InstitusiDana = pengembangan.InstitusiDana,

                };

                return View(balikan);
            }

        }
        public async Task<IActionResult> PostPengembangan(TrPengembanganForm pengembangan)
        {
            // mengecek apakah karyawan ada
            var karyawanada = await _context.TrPengembangan.AsNoTracking().AnyAsync(x => x.IdTrPengembangan == pengembangan.IdTrPengembangan);
 if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pengembangandb = _context.TrPengembangan.AsNoTracking()
                .FirstOrDefault(x => x.IdTrPengembangan == pengembangan.IdTrPengembangan);
            TrPengembangan data = new TrPengembangan()
            {
                Npp = pengembangan.Npp,
                IdTrPengembangan = pengembangan.IdTrPengembangan,
                Judul = pengembangan.Judul,
                IssnIsbn = pengembangan.IssnIsbn,
                Nilai = pengembangan.Nilai,
                IdRefPengembangan = pengembangan.IdRefPengembangan,
                IdRefAppraisal = pengembangan.IdRefAppraisal,
                DanaLokal = pengembangan.DanaLokal,
                TglMulai = pengembangan.TglMulai,
                TglSelesai = pengembangan.TglSelesai,
                Penerbit = pengembangan.Penerbit,
                TingkatPeran = pengembangan.TingkatPeran,
                Tempat = pengembangan.Tempat,
                Peran = pengembangan.Peran,
                SumberDana = pengembangan.SumberDana,



            };
            //mengubah Image menjadi byte base64 untuk disimpan ke db
            if (pengembangan.FilePengembanganform != null && pengembangan.FilePengembanganform.Length > 0)
            {

                byte[] p1 = null;
                using (var fs1 = pengembangan.FilePengembanganform.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                data.FilePengembangan = p1;

            }
            else if (pengembangandb != null)
                data.FilePengembangan = pengembangandb.FilePengembangan;
            else data.FilePengembangan = null;
            // END mengubah Image menjadi byte base64 untuk disimpan ke db


            if (!karyawanada)
            {
                data.IdTrPengembangan = _context.TrPengembangan.Max(p => p.IdTrPengembangan) + 1;
                _context.TrPengembangan.Add(data);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Add new data success." });
            }

            else
            {
                _context.Update(data);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Edit data success." });
            }
        }
        public async Task<IActionResult> DeleteTrPengembangan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.TrPengembangan.SingleOrDefaultAsync(m => m.IdTrPengembangan == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TrPengembangan.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete success." });
        }



     
    

        // START rekanan
        public IActionResult LoadDataKarirGolongan()
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {
                try
                {
                    var customerData = _context.TrKarirGolongan
                        .Select(p => new {
                            p.IdTrKarirGolongan,
                            
                            p.Npp,
                            p.NoSk,
                            
                            p.NppNavigation.NamaLengkapGelar,
                            p.IdRefGolonganBaru,
                            p.IdRefGolonganLama,
                            p.TglBerikut
                        });



                    return Json(new { data = customerData });

                }
                catch (Exception)
                {
                    throw;
                }
            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult AddEditKarirGolongan(int id = 0)
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {
                if (id == 0)
                {
                    var balikan = new TrKarirGolonganForm()
                    {
                        karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.NamaLengkapGelar }).ToList(),
                        golongan = _context.RefGolongan.Select(x => new RefGolongan
                        {
                            IdRefGolongan = x.IdRefGolongan,
                            Deskripsi = x.Deskripsi
                        }).ToList(),
                    };

                    return View(balikan);
                }
                else
                {
                    var karirfungsional = _context.TrKarirGolongan.Where(x => x.IdTrKarirGolongan.Equals(id)).FirstOrDefault();

                    var balikan = new TrKarirGolonganForm()
                    {
                        karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.NamaLengkapGelar }).ToList(),
                        golongan = _context.RefGolongan.Select(x => new RefGolongan
                        {
                            IdRefGolongan = x.IdRefGolongan,
                            Deskripsi = x.Deskripsi
                        }).ToList(),
                        IdTrKarirGolongan = karirfungsional.IdTrKarirGolongan,
                        IdRefGolonganBaru = karirfungsional.IdRefGolonganBaru,
                        IdRefGolonganLama = karirfungsional.IdRefGolonganLama,
                        JenisLokalNas = karirfungsional.JenisLokalNas,
                     
                        NilaiA = karirfungsional.NilaiA,
                        NilaiB = karirfungsional.NilaiB,
                        NilaiC = karirfungsional.NilaiC,
                        NilaiD = karirfungsional.NilaiD,
                        MasaKerjaGol = karirfungsional.MasaKerjaGol,
                        Nilai= karirfungsional.NilaiA,
                        NoSk = karirfungsional.NoSk,
                        Npp = karirfungsional.Npp,
                        TglBerikut = karirfungsional.TglBerikut,
                        Tmt = karirfungsional.Tmt


                    };
                    return View(balikan);
                }
            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostKarirGolongan([FromBody]  TrKarirGolonganForm karirfungsional)
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = new TrKarirGolongan()
                {
                    IdTrKarirGolongan = karirfungsional.IdTrKarirGolongan,
                    IdRefGolonganBaru = karirfungsional.IdRefGolonganBaru,
                    IdRefGolonganLama = karirfungsional.IdRefGolonganLama,

                    JenisLokalNas = karirfungsional.JenisLokalNas,

                    NilaiA = karirfungsional.NilaiA,
                    NilaiB = karirfungsional.NilaiB,
                    NilaiC = karirfungsional.NilaiC,
                    NilaiD = karirfungsional.NilaiD,
                    MasaKerjaGol = karirfungsional.MasaKerjaGol,
                    Nilai = karirfungsional.NilaiA,
                    NoSk = karirfungsional.NoSk,
                    Npp = karirfungsional.Npp,
                    TglBerikut = karirfungsional.TglBerikut,
                    Tmt = karirfungsional.Tmt,
                    DateInserted = DateTime.Now,
                    IsLast = true,

                };

                var karyawandb = _context.MstKaryawan.AsNoTracking().FirstOrDefault(x => x.Npp == karirfungsional.Npp);

                data.IdRefGolonganLama = karyawandb.IdRefGolongan;

                if (karirfungsional.IdTrKarirGolongan == 0)
                {
                    // mstrekanan.IdMstRekanan = _context.MstRekanan.Max(p => p.IdMstRekanan) + 1;
                    _context.TrKarirGolongan.Add(data);
                    karyawandb.IdRefGolongan = karirfungsional.IdRefGolonganBaru;
                    _context.Update(karyawandb);
                    await _context.SaveChangesAsync();


                    return Json(new { success = true, message = "Add new data success." });
                }
                else
                {

                    _context.Update(data);
                    karyawandb.IdRefGolongan = karirfungsional.IdRefGolonganBaru;
                    _context.Update(karyawandb);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Edit data success." });
                }


            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult LoadDataGolonganRef()
        {

            try
            {
                var customerData = _context.RefJabatanAkademik
                 .Select(p => new { p.IdRefFungsional, p.Deskripsi });

                return Json(customerData);

            }
            catch (Exception)
            {
                throw;
            }
        }
        // end rekanan
        public IActionResult LoadDataKarirStruktural ()
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {
                try
                {
                    var customerData = _context.TrKarirStruktural
                      .Select(p => new { p.Npp, p.NoSk ,p.NppNavigation.NamaLengkapGelar , p.IdUnitNavigation.NamaUnit,
                      p.IdRefStrukturalNavigation.Deskripsi ,p.TglAwal , p.TglAkhir });

                    return Json(new { data = customerData });

                }
                catch (Exception)
                {
                    throw;
                }
            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> AddEditKarirStrukturalAsync(string npp , string nosk)
        {
            Console.WriteLine("test");
            Console.WriteLine(npp);
            Console.WriteLine("test");
            Console.WriteLine(nosk);

           
            var karyawanada = await _context.TrKarirStruktural.AsNoTracking().AnyAsync(x => x.Npp == npp && x.NoSk ==nosk);
            if (HttpContext.Session.GetString("role") == "admin")
            {
                if (!karyawanada)
                {
                    var balikan = new TrKarirStrukturalForm()
                    {
                        karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.NamaLengkapGelar }).ToList(),
                        unit = _context.MstUnit.Select(x => new MstUnit
                        {
                            IdUnit = x.IdUnit,
                            NamaUnit = x.NamaUnit
                        }).ToList(),
                        struktural = _context.RefJabatanStruktural.Select(x => new RefJabatanStruktural
                        {
                            IdRefStruktural = x.IdRefStruktural,
                            Deskripsi = x.Deskripsi,
                        }).ToList(),
                    };

                    return View(balikan);
                }
                else
                {
                    var karir = _context.TrKarirStruktural.Where(x => x.Npp == npp && x.NoSk == nosk).FirstOrDefault();

                    var balikan = new TrKarirStrukturalForm()
                    {
                        karyawan = _context.MstKaryawan.Select(x => new MstKaryawan { Npp = x.Npp, Nama = x.NamaLengkapGelar }).ToList(),
                        unit = _context.MstUnit.Select(x => new MstUnit
                        {
                            IdUnit = x.IdUnit,
                            NamaUnit = x.NamaUnit
                        }).ToList(),
                        struktural = _context.RefJabatanStruktural.Select(x => new RefJabatanStruktural
                        {
                            IdRefStruktural = x.IdRefStruktural,
                            Deskripsi = x.Deskripsi,
                        }).ToList(),               
                        NoSk = karir.NoSk,
                        Npp = karir.Npp,
                        IdRefStruktural=karir.IdRefStruktural,
                        IdUnit=karir.IdUnit,
                        Status=karir.Status,
                        TglAwal=karir.TglAwal,
                        TglAkhir=karir.TglAkhir,
                        IsLast=karir.IsLast,
                        MstIdUnit=karir.MstIdUnit,
                        
                      


                    };
                    return View(balikan);
                }
            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostKarirStruktural([FromBody]  TrKarirStrukturalForm  karir)
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {
                var npp = karir.Npp;
                var nosk = karir.NoSk;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var un = _context.MstUnit.FirstOrDefault(x => x.IdUnit == karir.IdUnit);
                var data = new TrKarirStruktural()
                {
                    NoSk = karir.NoSk,
                    Npp = karir.Npp,
                    IdRefStruktural = karir.IdRefStruktural,
                    IdUnit = karir.IdUnit,
                    Status = karir.Status,
                    TglAwal = karir.TglAwal,
                    TglAkhir = karir.TglAkhir,
                    IsLast = 1,
                    MstIdUnit = un.IdUnit,


                };

                var karyawandb = _context.MstKaryawan.AsNoTracking().FirstOrDefault(x => x.Npp == karir.Npp);

                var karyawanada = await _context.TrKarirStruktural.AsNoTracking().AnyAsync(x => x.Npp == npp && x.NoSk == nosk);

                if (!karyawanada)
                {
                    // mstrekanan.IdMstRekanan = _context.MstRekanan.Max(p => p.IdMstRekanan) + 1;
                    _context.TrKarirStruktural.Add(data);
                   
                    await _context.SaveChangesAsync();


                    return Json(new { success = true, message = "Add new data success." });
                }
                else
                {

                    _context.Update(data);
                   
                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Edit data success." });
                }


            }

            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }


    }

}