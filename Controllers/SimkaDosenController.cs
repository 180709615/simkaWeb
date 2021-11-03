using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using APIConsume.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;
using System.IO;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using APIConsume.DAO;
using Dapper;
using System.Dynamic;
using OfficeOpenXml;
using System.Security.Cryptography;

namespace APIConsume.Controllers
{
    [System.Runtime.InteropServices.Guid("6D594843-F805-4AB9-AFB7-2A9CD3F5887C")]
    public class SimkaDosenController : Controller
    {
        private readonly SIATMAX_SISTERContext _context;
        private readonly DATA_SISTERContext _DATA_SISTERcontext;
        private string baseUrl = "https://sister.uajy.ac.id/ws.php/1.0";


        public SimkaDosenController(SIATMAX_SISTERContext context, DATA_SISTERContext contexData_Sister)
        {
            _context = context;
            _DATA_SISTERcontext = contexData_Sister;
        }
        public IActionResult Index()
        {
            string npp = HttpContext.Session.GetString("NPP");
            if (HttpContext.Session.GetString("NPP") != null && HttpContext.Session.GetString("role") == "dosen")
                return View();
            else
                return RedirectToAction("Index", "SimkaKaryawan");


        }

        public IActionResult GantiPassword()
        {
            return RedirectToAction("GantiPassword", "Administrasi");
        }
        public IActionResult EditBiografi()
        {
            return RedirectToAction("EditBiografi", "Administrasi");
        }
        public IActionResult KelolaPengembangan()
        {
            if (HttpContext.Session.GetString("NPP") != null)
                return View();
            else

                return RedirectToAction("Index", "Home");
        }
        public IActionResult LoadDataTrPengembangan()
        {
            if (HttpContext.Session.GetString("NPP") != null)
            //cek apakah login & sesuai dengan role
            {
                try
                {
                    var customerData = _context.TrPengembangan.Where(x => x.Npp == HttpContext.Session.GetString("NPP"))
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
            else
            {
                return StatusCode(401, "401 Akses Tidak Dijinkan, mohon login kembali");
            }

        }
        public IActionResult AddEditPengembangan(int id = 0)
        {
            if (id == 0)
            {
                return View(new TrPengembanganForm());
            }
            else
            {
                var pengembangan = _context.TrPengembangan.Where(x => x.IdTrPengembangan.Equals(id)).FirstOrDefault();

                var balikan = new TrPengembanganForm()
                {
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

            var Npp = HttpContext.Session.GetString("NPP");
            if (!ModelState.IsValid) // ModelState.IsValid digunain buat ngecek form yang dikirim dari view itu sudah cocok
                                     // belum sama modelnya

            //Use: var errors = ModelState.Values.SelectMany(v => v.Errors);
            //with a break point to view any validation issues.
            {
                return BadRequest(ModelState);
            }
            var pengembangandb = _context.TrPengembangan.AsNoTracking()
                .FirstOrDefault(x => x.IdTrPengembangan == pengembangan.IdTrPengembangan);
            TrPengembangan data = new TrPengembangan()
            {



                Npp = Npp,
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
                data.IdTrPengembangan = _context.TrPengembangan.Max(p => p.IdTrPengembangan) + 1; //Max itu ngembaliin tipe data yang sama dengan kolom yang dipilihnya,
                _context.TrPengembangan.Add(data);                                                // kalau mau pake buat return object nanti jadine .Where().Max();
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
        public async Task<IActionResult> DeletePengembangan([FromRoute] int id)
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

        public IActionResult AddEditTodo(int id = 0)
        {
            if (id == 0)
            {
                return View(new TrPengembangan());
            }
            else
            {
                return View(_context.TrPengembangan.Where(x => x.IdTrPengembangan.Equals(id)).FirstOrDefault());
            }

        }

        public IActionResult simkapengembangan()
        {
            return View();

        }
        public IActionResult Restitusi()
        {
            string npp = HttpContext.Session.GetString("NPP");
            if (HttpContext.Session.GetString("NPP") != null && HttpContext.Session.GetString("role") == "dosen")
                return RedirectToAction("Restitusi", "Administrasi");
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }

        }



        public JsonResult FindKegiatan(int tridharma_id)
        {
            //Use EF core to get all colors of this Code
            var Kegiatan = _context.RefPengembangan
                  .Where(p => p.IdRefJnsAppraisal == tridharma_id)
              .Select(p => new { p.IdRefPengembangan, p.Deskripsi });

            //return SelectList with your text and value
            var kegiatan = Kegiatan.ToList();

            return new JsonResult(kegiatan);


        }
        public async Task<IActionResult> Create(int id_appraisal, int id_pengembangan, String Judul,
            DateTime dateStart, DateTime dateEnd, String Tempat, String Penerbit, String Isbn, String Sumberdana, int besardana,
            String peran, String tingkat, float nilai, IFormFile Image)
        {
            TrPengembangan tr = new TrPengembangan();
            if (Image != null)

            {
                if (Image.Length > 0)

                //Convert Image to byte and save to database

                {

                    byte[] p1 = null;
                    using (var fs1 = Image.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    tr.FilePengembangan = p1;

                }
            }

            tr.IdTrPengembangan = _context.TrPengembangan.Max(p => p.IdTrPengembangan) + 1;
            tr.Npp = HttpContext.Session.GetString("NPP");
            tr.IdRefAppraisal = id_appraisal;
            tr.IdRefPengembangan = id_pengembangan;
            tr.Judul = Judul;
            tr.TglMulai = dateStart;
            tr.TglSelesai = dateEnd;
            tr.Tempat = Tempat;
            tr.Penerbit = Penerbit;
            tr.IssnIsbn = Isbn;
            tr.SumberDana = Sumberdana;
            tr.DanaEksternal = besardana;
            tr.Peran = peran;
            tr.TingkatPeran = tingkat;
            tr.Nilai = nilai;


            _context.Add(tr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        //public async Task<IActionResult> TestingLoadDosen()
        //{

        //    return await Task.FromResult(View());
        //}

        public async Task<IActionResult> Simkaprofile()
        {

            string npp = HttpContext.Session.GetString("NPP");
            if (HttpContext.Session.GetString("NPP") != null && HttpContext.Session.GetString("role") == "dosen")
            //cek apakah login & sesuai dengan role
            {

                // simka part
                dynamic balikan = new ExpandoObject();

                balikan.Akademik = _context.MstUnitAkademik.FirstOrDefault(a => a.IdUnit == _context.MstKaryawan.FirstOrDefault(a => a.Npp == HttpContext.Session.GetString("NPP")).IdUnitAkademik);
                balikan.Penelitian = _context.TblPenelitian.Where(a => a.Npp == npp).ToList();
                balikan.Pengabdian = _context.TblPengabdian.Where(a => a.Npp == npp).ToList();
                //balikan.semester = (new PerbandinganPengajaranDAO()).GetSemester();
                balikan.semester = await getIdSemesterSister();

                //balikan.Penelitian_Sister = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Where(a => a.NPP == npp).ToList();

                //  balikan.Pengembangan = _context.TrPengembangan.Where(a => a.Npp == npp).ToList();

                //([double]12345.67).ToString("N") buat ubah format uang bair ada thousand separator

                balikan.Karyawan = _context.MstKaryawan
              .Include(m => m.IdRefFungsionalNavigation)
              .Include(m => m.IdRefGolonganNavigation)
              .Include(m => m.IdRefJbtnAkademikNavigation)
              .Include(m => m.IdRefTunjanganKhususNavigation)
              .Include(m => m.IdUnitNavigation)
              .Include(m => m.MstIdUnitNavigation)
              .FirstOrDefault(a => a.Npp == npp); // Include itu semacem join tabel, kalo ThenInclude itu men join kan 2 tabel yang sedang join tabel awal
                //simka part

                var idDosen = balikan.Karyawan.ID_DOSEN_SISTER;

                if (balikan.Karyawan.ID_DOSEN_SISTER != null)
                // memastikan id dosen tidak null /kosong 
                //sebelum mengakses api dikti
                {
                    /*
                    using (var httpClient = new HttpClient())
                    {

                        balikan.Sister = new Sister_DosenPenelitian();
                        Sister_Token reservation = new Sister_Token();
                        PenelitianReq request = new PenelitianReq();
                        // start mengambil token
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

                        reservation = JsonConvert.DeserializeObject<Sister_Token>(apiResponse);
                        //end mengambil token 

                        

                      request.id_token = reservation.data.id_token;
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

                      balikan.Sister.pen = (Penelitian)JsonConvert.DeserializeObject(apiResponse, typeof(Penelitian));

                    request.id_token = reservation.data.id_token;
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
                  balikan.Sister.abdi = (Pengabdian)JsonConvert.DeserializeObject(apiResponse, typeof(Pengabdian));


                  var DetailDos = new Sister_DetailDosenRequest();
                  DetailDos.id_token = reservation.data.id_token;
                  DetailDos.id_dosen = idDosen;
                  Console.WriteLine(idDosen);
                  json = JsonConvert.SerializeObject(DetailDos);
                  data = new StringContent(json, Encoding.UTF8, "application/json");
                  url = "https://sister.uajy.ac.id/api.php/0.1/Dosen/detail";

                  httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                  response = await httpClient.PostAsync(url, data);
                  apiResponse = await response.Content.ReadAsStringAsync();

                  balikan.Sister.dos = (Sister_DosenDetail)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_DosenDetail));

                url = "https://sister.uajy.ac.id/api.php/0.1/Pembicara";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.PostAsync(url, data);
                apiResponse = await response.Content.ReadAsStringAsync();
                balikan.Sister.bicara = (Pembicara)JsonConvert.DeserializeObject(apiResponse, typeof(Pembicara));


                url = "https://sister.uajy.ac.id/api.php/0.1/Publikasi";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.PostAsync(url, data);
                apiResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(apiResponse);
                balikan.Sister.publi = (Publikasi)JsonConvert.DeserializeObject(apiResponse, typeof(Publikasi));
                //  dospen.bicara = (Pembicara)JsonConvert.DeserializeObject(apiResponse, typeof(Pembicara));

/*
                url = "https://sister.uajy.ac.id/api.php/0.1/JabatanStruktural";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.PostAsync(url, data);
                apiResponse = await response.Content.ReadAsStringAsync();


                url = "https://sister.uajy.ac.id/api.php/0.1/JabatanStruktural/detail";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.PostAsync(url, data);
                apiResponse = await response.Content.ReadAsStringAsync();

                url = "https://sister.uajy.ac.id/api.php/0.1/Paten";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.PostAsync(url, data);
                apiResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(apiResponse);


                }
                */

                }
                return await Task.FromResult(View(balikan));
            }
            else
            {
                return RedirectToAction("Simkaprofile", "SimkaKaryawan");

            }


        }

        [Route("/SimkaDosen/LoadDataPengajaranAsync")]
        public async Task<IActionResult> LoadDataPengajaranAsync(string id_semester)
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");
                var data = _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Where(a => a.NPP == npp && a.id_semester == id_semester).ToList();
                return Json(new
                {
                    data
                });
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";

                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/SimkaDosen/LoadDataPublikasi")]
        public async Task<IActionResult> LoadDataPublikasi()
        {

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");
                string id_dosen = _context.MstKaryawan.AsNoTracking().FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;

                //var data = _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AsNoTracking().Where(a => a.NPP1 == npp || a.NPP2 == npp || a.NPP3 == npp || a.NPP4 == npp || a.NPP5 == npp || a.NPP6 == npp).ToList();
                //var data = (from publikasi in _DATA_SISTERcontext.TrPublikasi_DATA_SISTER
                //            join penulis in _DATA_SISTERcontext.TblPenulis_DATA_SISTER on publikasi.id equals penulis.id_riwayat_publikasi_paten
                //            where penulis.id_sdm == id_dosen
                //            select publikasi
                //        ).ToList();
                var data = (new PublikasiSisterDAO()).GetPublikasiSister(id_dosen);
                return Json(new
                {
                    data
                });
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/SimkaDosen/LoadDataPengabdian")]
        public async Task<IActionResult> LoadDataPengabdian()
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("NPP") != null)
            {
                //string npp = HttpContext.Session.GetString("NPP");
                string npp = HttpContext.Session.GetString("NPP");
                string id_dosen = _context.MstKaryawan.AsNoTracking().FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                //var data = (from penelitian in _DATA_SISTERcontext.TrPengabdian_DATA_SISTER
                //            join anggota in _DATA_SISTERcontext.TblAnggota_DATA_SISTER on penelitian.id_penelitian_pengabdian equals anggota.id_penelitian_pengabdian
                //            where anggota.id_sdm == id_dosen
                //            select penelitian
                //        ).ToList();

                var data = (new PengabdianSisterDAO()).GetPengabdianSister(id_dosen);
                return Json(new
                {
                    data
                });
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";

                return RedirectToAction("Index", "Home");
            }
        }

        [Route("/SimkaDosen/LoadDataPenelitian")]
        public async Task<IActionResult> LoadDataPenelitian()
        {

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");
                //string npp = "02.11.817";
                string id_dosen = _context.MstKaryawan.AsNoTracking().FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                //var data = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AsNoTracking().Where(a => a.NPP1 == npp || a.NPP2 == npp || a.NPP3 == npp || a.NPP4 == npp || a.NPP5 == npp || a.NPP6 == npp).ToList();
                //data = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AsNoTracking()
                //    .Join(
                //        _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Where(a=> a.id_sdm == npp).ToList(),
                //        penelitian => penelitian.id_penelitian_pengabdian,
                //        anggota => anggota.id_penelitian_pengabdian,
                //        (penelitian, anggota )=> penelitian

                //    ).ToList();


                //var data = (from penelitian in _DATA_SISTERcontext.TrPenelitian_DATA_SISTER
                //            join anggota in _DATA_SISTERcontext.TblAnggota_DATA_SISTER on penelitian.id_penelitian_pengabdian equals anggota.id_penelitian_pengabdian
                //            where anggota.id_sdm == id_dosen
                //            select penelitian
                //           // select new { penelitian.judul_penelitian_pengabdian, penelitian.durasi_kegiatan, penelitian.jenis_skim, penelitian.tahun_kegiatan , anggota.peran, anggota.no }
                //        ).ToList();
                var data = (new PenelitianSisterDAO()).GetPenelitianSister(id_dosen);
                return Json(new
                {
                    data
                });
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";

                return RedirectToAction("Index", "Home");
            }
        }


        public IActionResult LoadDataRiwayatPendidikan()
        {
            string npp = HttpContext.Session.GetString("NPP");
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


        [Route("/SimkaDosen/LoadDataPenelitianProdi")]
        public async Task<IActionResult> LoadDataPenelitianProdi(int id_unit)
        {
            string idDosen = null;
            var listNPP = _context.MstKaryawan.AsNoTracking().Where(a => a.IdUnitAkademik == id_unit).ToList();

            List<string> listID_DOSEN = new List<string>();

            foreach (var item in listNPP)
            {
                if (!String.IsNullOrEmpty(item.ID_DOSEN_SISTER))
                {
                    listID_DOSEN.Add(item.ID_DOSEN_SISTER);

                }
            }

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");

                //var data = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.ToList();
                var data = (from penelitian in _DATA_SISTERcontext.TrPenelitian_DATA_SISTER
                            join anggota in _DATA_SISTERcontext.TblAnggota_DATA_SISTER on penelitian.id_penelitian_pengabdian equals anggota.id_penelitian_pengabdian
                            where listID_DOSEN.Contains(anggota.id_sdm)
                            select penelitian
                        ).Distinct().ToList();
                return Json(new
                {
                    data
                });
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> LoadDataPengabdianProdi(int id_unit)
        {
            string idDosen = null;
            var listNPP = _context.MstKaryawan.AsNoTracking().Where(a => a.IdUnitAkademik == id_unit).ToList();

            List<string> listID_DOSEN = new List<string>();

            foreach (var item in listNPP)
            {
                if (!String.IsNullOrEmpty(item.ID_DOSEN_SISTER))
                {
                    listID_DOSEN.Add(item.ID_DOSEN_SISTER);

                }
            }

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");

                //var data = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.ToList();
                var data = (from pengabdian in _DATA_SISTERcontext.TrPengabdian_DATA_SISTER
                            join anggota in _DATA_SISTERcontext.TblAnggota_DATA_SISTER on pengabdian.id_penelitian_pengabdian equals anggota.id_penelitian_pengabdian
                            where listID_DOSEN.Contains(anggota.id_sdm)
                            select pengabdian
                        ).Distinct().ToList();
                return Json(new
                {
                    data
                });
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> LoadDataPengajaranAsyncProdi(string id_semester,int id_unit)
        {
            string idDosen = null;

            var listNPP = _context.MstKaryawan.AsNoTracking().Where(a => a.IdUnitAkademik == id_unit).ToList();

            List<string> listNPP2 = new List<string>();
            foreach(var item in listNPP)
            {
                listNPP2.Add(item.Npp);
            }

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");

                var data = _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Where(a => a.id_semester == id_semester && listNPP2.Any(b=> b == a.NPP)).ToList();
                //var data = from _DATA_SISTERcontext.TrPengajaran_DATA_SISTER
                //    where listNPP2

                return Json(new
                {
                    data
                });
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";

                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> LoadDataPublikasiProdi(int id_unit)
        {
            string idDosen = null;
            var listNPP = _context.MstKaryawan.AsNoTracking().Where(a => a.IdUnitAkademik == id_unit).ToList();

            List<string> listID_DOSEN = new List<string>();

            foreach (var item in listNPP)
            {
                if (!String.IsNullOrEmpty(item.ID_DOSEN_SISTER))
                {
                    listID_DOSEN.Add(item.ID_DOSEN_SISTER);

                }
            }

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");

                //var data = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.ToList();
                var data = (from publikasi in _DATA_SISTERcontext.TrPublikasi_DATA_SISTER
                            join penulis in _DATA_SISTERcontext.TblPenulis_DATA_SISTER on publikasi.id equals penulis.id_riwayat_publikasi_paten
                            where listID_DOSEN.Contains(penulis.id_sdm)
                            select publikasi
                        ).Distinct().ToList();
                return Json(new
                {
                    data
                });
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";

                return RedirectToAction("Index", "Home");
            }
        }


        public async Task<IActionResult> SinkronDataPenelitianSISTER()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<TrPenelitian_DATA_SISTER> masterList = new List<TrPenelitian_DATA_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<TrPenelitian_DATA_SISTER> compareList = new List<TrPenelitian_DATA_SISTER>();

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        PenelitianReq request = new PenelitianReq();
                        idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                        idDosen = idDosen != null ? idDosen.Trim() : null;

                        if (!String.IsNullOrEmpty(idDosen))
                        {
                            url = baseUrl + "/penelitian?id_sdm=" + idDosen;
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                            response = await httpClient.GetAsync(url);
                            apiResponse = await response.Content.ReadAsStringAsync();

                            if (response.IsSuccessStatusCode)
                            {
                                var ajar = JsonConvert.DeserializeObject<List<Penelitian>>(apiResponse);

                                Penelitian_detail_req request_detail = new Penelitian_detail_req();

                                if (ajar != null)
                                {
                                    int noIncrementAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Max(a => (int?)a.no) ?? 0;

                                    int testcounter = 0;

                                    foreach (Penelitian itemPenelitian in ajar)
                                    {
                                        
                                        url = baseUrl + "/penelitian/" + itemPenelitian.id;
                                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                        response = await httpClient.GetAsync(url);
                                        apiResponse = await response.Content.ReadAsStringAsync();
                                        if (response.IsSuccessStatusCode)
                                        {
                                            var detail = JsonConvert.DeserializeObject<Penelitian_Detail>(apiResponse);

                                            TrPenelitian_DATA_SISTER entrydata = new TrPenelitian_DATA_SISTER();
                                            entrydata.id_penelitian_pengabdian = detail.id;
                                            entrydata.id_kategori_kegiatan = detail.id_kategori_kegiatan;

                                            entrydata.judul_penelitian_pengabdian = detail.judul;
                                            entrydata.durasi_kegiatan = detail.lama_kegiatan;
                                            entrydata.tahun_pelaksanaan_ke = detail.tahun_pelaksanaan_ke;
                                            entrydata.dana_dari_dikti = Convert.ToDecimal(detail.dana_dikti);
                                            entrydata.dana_dari_PT = Convert.ToDecimal(detail.dana_perguruan_tinggi);
                                            entrydata.dana_dari_instansi_lain = Convert.ToDecimal(detail.dana_institusi_lain);
                                            entrydata.in_kind = detail.in_kind;
                                            entrydata.no_sk_tugas = detail.sk_penugasan;
                                            entrydata.tanggal_sk_penugasan = Convert.ToDateTime(detail.tanggal_sk_penugasan).Date;
                                            entrydata.tempat_kegiatan = detail.lokasi;
                                            entrydata.id_jenis_skim = detail.id_jenis_skim;
                                            entrydata.jenis_skim = detail.jenis_skim;
                                            entrydata.tahun_usulan = detail.tahun_usulan;
                                            entrydata.tahun_kegiatan = detail.tahun_kegiatan;
                                            entrydata.tahun_pelaksanaan = detail.tahun_pelaksanaan;
                                            entrydata.id_litabmas_sebelumnya = detail.id_litabmas_sebelumnya;
                                            entrydata.litabmas_sebelumnya = detail.litabmas_sebelumnya;
                                            entrydata.id_afiliasi = detail.id_afiliasi;
                                            entrydata.afiliasi = detail.afiliasi;
                                            entrydata.id_kelompok_bidang = detail.id_kelompok_bidang;
                                            entrydata.nama_kelompok_bidang = detail.kelompok_bidang;
                                            entrydata.NPP1 = npp;


                                            if (_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == detail.id) &&
                                                    !masterList.Any(a => a.id_penelitian_pengabdian == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                                   // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);

                                            testcounter++;
                                            //if (testcounter != 5)
                                            //    continue;

                                            List<TblAnggota_DATA_SISTER> masterListAnggota = (new AnggotaSisterDAO()).GetAnggotaById_penelitian_pengabdian(detail.id).data;
                                            List<TblAnggota_DATA_SISTER> compareListAnggota = new List<TblAnggota_DATA_SISTER>();
                                            if (detail.anggota != null && detail.anggota.Length > 0) // ============== Sinkron Penulis ================
                                            {
                                                foreach (Anggota itemAnggota in detail.anggota)
                                                {
                                                    TblAnggota_DATA_SISTER entryAnggota = new TblAnggota_DATA_SISTER();
                                                    entryAnggota.jenis = itemAnggota.jenis;
                                                    entryAnggota.nama = itemAnggota.nama;
                                                    entryAnggota.nipd = itemAnggota.nipd;
                                                    entryAnggota.peran = itemAnggota.peran;
                                                    entryAnggota.id_sdm = itemAnggota.id_sdm;
                                                    entryAnggota.id_orang = itemAnggota.id_orang;
                                                    entryAnggota.id_pd = itemAnggota.id_pd;
                                                    entryAnggota.stat_aktif = itemAnggota.stat_aktif == true ? 1 : 0;
                                                    entryAnggota.id_penelitian_pengabdian = detail.id;

                                                    compareListAnggota.Add(entryAnggota);

                                                }


                                                List<TblAnggota_DATA_SISTER> toBeAddedAnggota = new List<TblAnggota_DATA_SISTER>();
                                                List<TblAnggota_DATA_SISTER> toBeDeletedAnggota = new List<TblAnggota_DATA_SISTER>();
                                                List<TblAnggota_DATA_SISTER> toBeUpdatedAnggota = new List<TblAnggota_DATA_SISTER>();

                                                toBeAddedAnggota = compareListAnggota.Where(a => !masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                                foreach (var itemtobeaddedAnggota in toBeAddedAnggota)
                                                {
                                                    noIncrementAnggota++;
                                                    itemtobeaddedAnggota.no = noIncrementAnggota;
                                                }
                                                toBeDeletedAnggota = masterListAnggota.Where(a => !compareListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                                toBeUpdatedAnggota = compareListAnggota.Where(a => masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                                _DATA_SISTERcontext.TblAnggota_DATA_SISTER.AddRange(toBeAddedAnggota);
                                                _DATA_SISTERcontext.TblAnggota_DATA_SISTER.RemoveRange(toBeDeletedAnggota);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedAnggota)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblAnggota_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_penelitian_pengabdian == item.id_penelitian_pengabdian && a.id_sdm == item.id_sdm);

                                                    itemToUpdate = item;
                                                }
                                                await _DATA_SISTERcontext.SaveChangesAsync();

                                            }




                                            List<TblDokumen_DATA_SISTER> masterListDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Where(a => a.id_publikasi_atau_penelitian == detail.id).ToList();
                                            List<TblDokumen_DATA_SISTER> compareListDokumen = new List<TblDokumen_DATA_SISTER>();

                                            if (detail.dokumen != null && detail.dokumen.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Dokumen itemDokumen in detail.dokumen)
                                                {
                                                    TblDokumen_DATA_SISTER entryDokumen = new TblDokumen_DATA_SISTER();
                                                    entryDokumen.id_dokumen = itemDokumen.id;
                                                    entryDokumen.id_publikasi_atau_penelitian = detail.id;
                                                    entryDokumen.nama_dokumen = itemDokumen.nama;
                                                    entryDokumen.nama_file = itemDokumen.nama_file;
                                                    entryDokumen.jenis_file = itemDokumen.jenis_file;
                                                    entryDokumen.tanggal_upload = Convert.ToDateTime(itemDokumen.tanggal_upload);
                                                    //entryDokumen.nama_jenis_dokumen = itemDokumen.nama;
                                                    entryDokumen.tautan = itemDokumen.tautan;
                                                    entryDokumen.keterangan_dokumen = itemDokumen.keterangan;




                                                    compareListDokumen.Add(entryDokumen);

                                                }


                                                List<TblDokumen_DATA_SISTER> toBeAddedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeDeletedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeUpdatedDokumen = new List<TblDokumen_DATA_SISTER>();

                                                toBeAddedDokumen = compareListDokumen.Where(a => !masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                foreach (var itemtobeaddeddokumen in toBeAddedDokumen)
                                                {
                                                    noIncrementDokumen++;
                                                    itemtobeaddeddokumen.no = noIncrementDokumen;
                                                }
                                                toBeDeletedDokumen = masterListDokumen.Where(a => !compareListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();
                                                toBeUpdatedDokumen = compareListDokumen.Where(a => masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.AddRange(toBeAddedDokumen);
                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.RemoveRange(toBeDeletedDokumen);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedDokumen)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblDokumen_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_dokumen == item.id_dokumen);
                                                    itemToUpdate = item;
                                                }
                                            }



                                            List<TblMitra_Litabmas_DATA_SISTER> masterListMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
                                            List<TblMitra_Litabmas_DATA_SISTER> compareListMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

                                            if (detail.mitra_litabmas != null && detail.mitra_litabmas.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Mitra_Litabmas itemMitra in detail.mitra_litabmas)
                                                {
                                                    TblMitra_Litabmas_DATA_SISTER entryMitra = new TblMitra_Litabmas_DATA_SISTER();
                                                    entryMitra.id_penelitian_pengabdian = detail.id;
                                                    entryMitra.id = itemMitra.id;
                                                    entryMitra.nama = itemMitra.nama;

                                                    compareListMitra.Add(entryMitra);

                                                }


                                                List<TblMitra_Litabmas_DATA_SISTER> toBeAddedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
                                                List<TblMitra_Litabmas_DATA_SISTER> toBeDeletedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
                                                List<TblMitra_Litabmas_DATA_SISTER> toBeUpdatedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

                                                toBeAddedMitra = compareListMitra.Where(a => !masterListMitra.Any(b => a.id == b.id)).ToList();

                                                foreach (var itemtobeaddedMitra in toBeAddedMitra)
                                                {
                                                    noIncrementMitra++;
                                                    itemtobeaddedMitra.no = noIncrementMitra;
                                                }
                                                toBeDeletedMitra = masterListMitra.Where(a => !compareListMitra.Any(b => a.id == b.id)).ToList();
                                                toBeUpdatedMitra = compareListMitra.Where(a => masterListMitra.Any(b => a.id == b.id)).ToList();

                                                _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.AddRange(toBeAddedMitra);
                                                _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.RemoveRange(toBeDeletedMitra);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedMitra)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER
                                                        .FirstOrDefault(a => a.id == item.id);
                                                    itemToUpdate = item;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            TrPenelitian_DATA_SISTER entrydata = new TrPenelitian_DATA_SISTER();
                                            entrydata.id_penelitian_pengabdian = itemPenelitian.id;
                                            entrydata.judul_penelitian_pengabdian = itemPenelitian.judul;
                                            entrydata.tahun_pelaksanaan = itemPenelitian.tahun_pelaksanaan;

                                            if (_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id) &&
                                                    !masterList.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                                           // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == itemPenelitian.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);
                                        }



                                    }
                                    List<TrPenelitian_DATA_SISTER> toBeAdded = new List<TrPenelitian_DATA_SISTER>();
                                    List<TrPenelitian_DATA_SISTER> toBeDeleted = new List<TrPenelitian_DATA_SISTER>();
                                    List<TrPenelitian_DATA_SISTER> toBeUpdated = new List<TrPenelitian_DATA_SISTER>();

                                    toBeAdded = compareList.Where(a => !masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                    toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                    toBeUpdated = compareList.Where(a => masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                    _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AddRange(toBeAdded);
                                    await _DATA_SISTERcontext.SaveChangesAsync();

                                    _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.RemoveRange(toBeDeleted);
                                    await _DATA_SISTERcontext.SaveChangesAsync();

                                    int counter = 0;
                                    foreach (var item in toBeUpdated)
                                    {
                                        counter++;
                                        var itemToUpdate = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Find(item.id_penelitian_pengabdian);

                                        itemToUpdate.id_penelitian_pengabdian = item.id_penelitian_pengabdian;

                                        // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil

                                        itemToUpdate.id_kategori_kegiatan = item.id_kategori_kegiatan != null ? item.id_kategori_kegiatan : itemToUpdate.id_kategori_kegiatan;

                                        itemToUpdate.judul_penelitian_pengabdian = item.judul_penelitian_pengabdian != null ? item.judul_penelitian_pengabdian : itemToUpdate.judul_penelitian_pengabdian;
                                        itemToUpdate.durasi_kegiatan = item.durasi_kegiatan != null ? item.durasi_kegiatan : itemToUpdate.durasi_kegiatan;
                                        itemToUpdate.tahun_pelaksanaan_ke = item.tahun_pelaksanaan_ke != null ? item.tahun_pelaksanaan_ke : itemToUpdate.tahun_pelaksanaan_ke;
                                        itemToUpdate.dana_dari_dikti = item.dana_dari_dikti != null ? item.dana_dari_dikti : itemToUpdate.dana_dari_dikti;
                                        itemToUpdate.dana_dari_PT = item.dana_dari_PT != null ? item.dana_dari_PT : itemToUpdate.dana_dari_PT;
                                        itemToUpdate.dana_dari_instansi_lain = item.dana_dari_instansi_lain != null ? item.dana_dari_instansi_lain : itemToUpdate.dana_dari_instansi_lain;
                                        itemToUpdate.in_kind = item.in_kind != null ? item.in_kind : itemToUpdate.in_kind;
                                        itemToUpdate.no_sk_tugas = item.no_sk_tugas != null ? item.no_sk_tugas : itemToUpdate.no_sk_tugas;
                                        itemToUpdate.tanggal_sk_penugasan = item.tanggal_sk_penugasan != null ? item.tanggal_sk_penugasan : itemToUpdate.tanggal_sk_penugasan;
                                        itemToUpdate.tempat_kegiatan = item.tempat_kegiatan != null ? item.tempat_kegiatan : itemToUpdate.tempat_kegiatan;
                                        itemToUpdate.id_jenis_skim = item.id_jenis_skim != null ? item.id_jenis_skim : itemToUpdate.id_jenis_skim;
                                        itemToUpdate.jenis_skim = item.jenis_skim != null ? item.jenis_skim : itemToUpdate.jenis_skim;
                                        itemToUpdate.tahun_usulan = item.tahun_usulan != null ? item.tahun_usulan : itemToUpdate.tahun_usulan;
                                        itemToUpdate.tahun_kegiatan = item.tahun_kegiatan != null ? item.tahun_kegiatan : itemToUpdate.tahun_kegiatan;
                                        itemToUpdate.tahun_pelaksanaan = item.tahun_pelaksanaan != null ? item.tahun_pelaksanaan : itemToUpdate.tahun_pelaksanaan;
                                        itemToUpdate.litabmas_sebelumnya = item.litabmas_sebelumnya != null ? item.litabmas_sebelumnya : itemToUpdate.litabmas_sebelumnya;
                                        itemToUpdate.id_afiliasi = item.id_afiliasi != null ? item.id_afiliasi : itemToUpdate.id_afiliasi;
                                        itemToUpdate.afiliasi = item.afiliasi != null ? item.afiliasi : itemToUpdate.afiliasi;
                                        itemToUpdate.id_kelompok_bidang = item.id_kelompok_bidang != null ? item.id_kelompok_bidang : itemToUpdate.id_kelompok_bidang;
                                        itemToUpdate.nama_kelompok_bidang = item.nama_kelompok_bidang != null ? item.nama_kelompok_bidang : itemToUpdate.nama_kelompok_bidang;
                                        if (itemToUpdate.NPP1 == null) // cek apakah kosong
                                            itemToUpdate.NPP1 = item.NPP1;
                                        else if (itemToUpdate.NPP2 == null && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP2 = item.NPP1;
                                        else if (itemToUpdate.NPP3 == null && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP3 = item.NPP1;
                                        else if (itemToUpdate.NPP4 == null && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP4 = item.NPP1;
                                        else if (itemToUpdate.NPP5 == null && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP5 = item.NPP1;
                                        else if (itemToUpdate.NPP6 == null && item.NPP1 != itemToUpdate.NPP5 && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP6 = item.NPP1;

                                        await _DATA_SISTERcontext.SaveChangesAsync();

                                    }

                                    await _DATA_SISTERcontext.SaveChangesAsync();

                                }
                                

                                return Json(new { success = true, message = ajar });
                            }
                            else
                            {
                                var ajar = JsonConvert.DeserializeObject<Penelitian>(apiResponse);

                                return Json(new { success = false, message = ajar.message });
                            }

                            //return Json(new { success = true, message = "Sinkronisasi Penelitian sukses." });
                            return Json(new { success = true, message = "ajar" });
                        }
                        else
                        {
                            return Json(new { success = false, message = "ID Dosen Sister tidak ditemukan." });
                        }


                    }
                    catch (Exception ex)
                    {
                        return Json(new
                        {
                            ex
                        });
                    }
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> SinkronDataPengabdianSISTER()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<TrPengabdian_DATA_SISTER> masterList = new List<TrPengabdian_DATA_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<TrPengabdian_DATA_SISTER> compareList = new List<TrPengabdian_DATA_SISTER>();

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        PenelitianReq request = new PenelitianReq();
                        idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                        idDosen = idDosen != null ? idDosen.Trim() : null;
                        if (!String.IsNullOrEmpty(idDosen) && idDosen.Length == 36)
                        {
                            url = baseUrl + "/pengabdian?id_sdm=" + idDosen;
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                            response = await httpClient.GetAsync(url);
                            apiResponse = await response.Content.ReadAsStringAsync();
                            if (response.IsSuccessStatusCode)
                            {
                                var ajar = JsonConvert.DeserializeObject<List<Penelitian>>(apiResponse);

                                if (ajar != null)
                                {
                                    int noIncrementAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Max(a => (int?)a.no) ?? 0;


                                    foreach (Penelitian itemPenelitian in ajar)
                                    {
                                        url = baseUrl + "/pengabdian/" + itemPenelitian.id;
                                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                        response = await httpClient.GetAsync(url);
                                        apiResponse = await response.Content.ReadAsStringAsync();
                                        if (response.IsSuccessStatusCode)
                                        {
                                            var detail = JsonConvert.DeserializeObject<Penelitian_Detail>(apiResponse);

                                            TrPengabdian_DATA_SISTER entrydata = new TrPengabdian_DATA_SISTER();
                                            entrydata.id_penelitian_pengabdian = detail.id;
                                            entrydata.id_kategori_kegiatan = detail.id_kategori_kegiatan;

                                            entrydata.judul_penelitian_pengabdian = detail.judul;
                                            entrydata.durasi_kegiatan = detail.lama_kegiatan;
                                            entrydata.tahun_pelaksanaan_ke = detail.tahun_pelaksanaan_ke;
                                            entrydata.dana_dari_dikti = Convert.ToDecimal(detail.dana_dikti);
                                            entrydata.dana_dari_PT = Convert.ToDecimal(detail.dana_perguruan_tinggi);
                                            entrydata.dana_dari_instansi_lain = Convert.ToDecimal(detail.dana_institusi_lain);
                                            entrydata.in_kind = detail.in_kind;
                                            entrydata.no_sk_tugas = detail.sk_penugasan;
                                            entrydata.tanggal_sk_penugasan = Convert.ToDateTime(detail.tanggal_sk_penugasan).Date;
                                            entrydata.tempat_kegiatan = detail.lokasi;
                                            entrydata.id_jenis_skim = detail.id_jenis_skim;
                                            entrydata.jenis_skim = detail.jenis_skim;
                                            entrydata.tahun_usulan = detail.tahun_usulan;
                                            entrydata.tahun_kegiatan = detail.tahun_kegiatan;
                                            entrydata.tahun_pelaksanaan = detail.tahun_pelaksanaan;
                                            entrydata.id_litabmas_sebelumnya = detail.id_litabmas_sebelumnya;
                                            entrydata.litabmas_sebelumnya = detail.litabmas_sebelumnya;
                                            entrydata.id_afiliasi = detail.id_afiliasi;
                                            entrydata.afiliasi = detail.afiliasi;
                                            entrydata.id_kelompok_bidang = detail.id_kelompok_bidang;
                                            entrydata.nama_kelompok_bidang = detail.kelompok_bidang;
                                            entrydata.NPP1 = npp;

                                            if (_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == detail.id) &&
                                                    !masterList.Any(a => a.id_penelitian_pengabdian == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                                   // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);

                                            List<TblAnggota_DATA_SISTER> masterListAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
                                            List<TblAnggota_DATA_SISTER> compareListAnggota = new List<TblAnggota_DATA_SISTER>();

                                            if (detail.anggota != null && detail.anggota.Length > 0) // ============== Sinkron Penulis ================
                                            {
                                                foreach (Anggota itemAnggota in detail.anggota)
                                                {
                                                    TblAnggota_DATA_SISTER entryAnggota = new TblAnggota_DATA_SISTER();
                                                    entryAnggota.jenis = itemAnggota.jenis;
                                                    entryAnggota.nama = itemAnggota.nama;
                                                    entryAnggota.nipd = itemAnggota.nipd;
                                                    entryAnggota.peran = itemAnggota.peran;
                                                    entryAnggota.id_sdm = itemAnggota.id_sdm;
                                                    entryAnggota.id_orang = itemAnggota.id_orang;
                                                    entryAnggota.id_pd = itemAnggota.id_pd;
                                                    entryAnggota.stat_aktif = itemAnggota.stat_aktif == true ? 1 : 0;
                                                    entryAnggota.id_penelitian_pengabdian = detail.id;

                                                    compareListAnggota.Add(entryAnggota);

                                                }


                                                List<TblAnggota_DATA_SISTER> toBeAddedAnggota = new List<TblAnggota_DATA_SISTER>();
                                                List<TblAnggota_DATA_SISTER> toBeDeletedAnggota = new List<TblAnggota_DATA_SISTER>();
                                                List<TblAnggota_DATA_SISTER> toBeUpdatedAnggota = new List<TblAnggota_DATA_SISTER>();

                                                toBeAddedAnggota = compareListAnggota.Where(a => !masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                                foreach (var itemtobeaddedAnggota in toBeAddedAnggota)
                                                {
                                                    noIncrementAnggota++;
                                                    itemtobeaddedAnggota.no = noIncrementAnggota;
                                                }
                                                toBeDeletedAnggota = masterListAnggota.Where(a => !compareListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                                toBeUpdatedAnggota = compareListAnggota.Where(a => masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                                _DATA_SISTERcontext.TblAnggota_DATA_SISTER.AddRange(toBeAddedAnggota);
                                                _DATA_SISTERcontext.TblAnggota_DATA_SISTER.RemoveRange(toBeDeletedAnggota);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedAnggota)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblAnggota_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_penelitian_pengabdian == item.id_penelitian_pengabdian && a.id_sdm == item.id_sdm);

                                                    itemToUpdate = item;
                                                }
                                            }




                                            List<TblDokumen_DATA_SISTER> masterListDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Where(a => a.id_publikasi_atau_penelitian == detail.id).ToList();
                                            List<TblDokumen_DATA_SISTER> compareListDokumen = new List<TblDokumen_DATA_SISTER>();

                                            if (detail.dokumen != null && detail.dokumen.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Dokumen itemDokumen in detail.dokumen)
                                                {
                                                    TblDokumen_DATA_SISTER entryDokumen = new TblDokumen_DATA_SISTER();
                                                    entryDokumen.id_dokumen = itemDokumen.id;
                                                    entryDokumen.id_publikasi_atau_penelitian = detail.id;
                                                    entryDokumen.nama_dokumen = itemDokumen.nama;
                                                    entryDokumen.nama_file = itemDokumen.nama_file;
                                                    entryDokumen.jenis_file = itemDokumen.jenis_file;
                                                    entryDokumen.tanggal_upload = Convert.ToDateTime(itemDokumen.tanggal_upload);
                                                    //entryDokumen.nama_jenis_dokumen = itemDokumen.nama;
                                                    entryDokumen.tautan = itemDokumen.tautan;
                                                    entryDokumen.keterangan_dokumen = itemDokumen.keterangan;




                                                    compareListDokumen.Add(entryDokumen);

                                                }


                                                List<TblDokumen_DATA_SISTER> toBeAddedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeDeletedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeUpdatedDokumen = new List<TblDokumen_DATA_SISTER>();

                                                toBeAddedDokumen = compareListDokumen.Where(a => !masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                foreach (var itemtobeaddeddokumen in toBeAddedDokumen)
                                                {
                                                    noIncrementDokumen++;
                                                    itemtobeaddeddokumen.no = noIncrementDokumen;
                                                }
                                                toBeDeletedDokumen = masterListDokumen.Where(a => !compareListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();
                                                toBeUpdatedDokumen = compareListDokumen.Where(a => masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.AddRange(toBeAddedDokumen);
                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.RemoveRange(toBeDeletedDokumen);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedDokumen)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblDokumen_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_dokumen == item.id_dokumen);
                                                    itemToUpdate = item;
                                                }
                                            }



                                            List<TblMitra_Litabmas_DATA_SISTER> masterListMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
                                            List<TblMitra_Litabmas_DATA_SISTER> compareListMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

                                            if (detail.mitra_litabmas != null && detail.mitra_litabmas.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Mitra_Litabmas itemMitra in detail.mitra_litabmas)
                                                {
                                                    TblMitra_Litabmas_DATA_SISTER entryMitra = new TblMitra_Litabmas_DATA_SISTER();
                                                    entryMitra.id_penelitian_pengabdian = detail.id;
                                                    entryMitra.id = itemMitra.id;
                                                    entryMitra.nama = itemMitra.nama;

                                                    compareListMitra.Add(entryMitra);

                                                }


                                                List<TblMitra_Litabmas_DATA_SISTER> toBeAddedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
                                                List<TblMitra_Litabmas_DATA_SISTER> toBeDeletedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
                                                List<TblMitra_Litabmas_DATA_SISTER> toBeUpdatedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

                                                toBeAddedMitra = compareListMitra.Where(a => !masterListMitra.Any(b => a.id == b.id)).ToList();

                                                foreach (var itemtobeaddedMitra in toBeAddedMitra)
                                                {
                                                    noIncrementMitra++;
                                                    itemtobeaddedMitra.no = noIncrementMitra;
                                                }
                                                toBeDeletedMitra = masterListMitra.Where(a => !compareListMitra.Any(b => a.id == b.id)).ToList();
                                                toBeUpdatedMitra = compareListMitra.Where(a => masterListMitra.Any(b => a.id == b.id)).ToList();

                                                _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.AddRange(toBeAddedMitra);
                                                _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.RemoveRange(toBeDeletedMitra);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedMitra)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER
                                                        .FirstOrDefault(a => a.id == item.id);
                                                    itemToUpdate = item;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            TrPengabdian_DATA_SISTER entrydata = new TrPengabdian_DATA_SISTER();
                                            entrydata.id_penelitian_pengabdian = itemPenelitian.id;
                                            entrydata.judul_penelitian_pengabdian = itemPenelitian.judul;
                                            entrydata.tahun_pelaksanaan = itemPenelitian.tahun_pelaksanaan;

                                            if (_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id) &&
                                                   !masterList.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                                          // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == itemPenelitian.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);
                                        }


                                    }
                                    List<TrPengabdian_DATA_SISTER> toBeAdded = new List<TrPengabdian_DATA_SISTER>();
                                    List<TrPengabdian_DATA_SISTER> toBeDeleted = new List<TrPengabdian_DATA_SISTER>();
                                    List<TrPengabdian_DATA_SISTER> toBeUpdated = new List<TrPengabdian_DATA_SISTER>();

                                    toBeAdded = compareList.Where(a => !masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                    toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                    toBeUpdated = compareList.Where(a => masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                    _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.AddRange(toBeAdded);
                                    _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.RemoveRange(toBeDeleted);
                                    int counter = 0;
                                    foreach (var item in toBeUpdated)
                                    {
                                        counter++;
                                        var itemToUpdate = _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Find(item.id_penelitian_pengabdian);

                                        counter++;
                                        itemToUpdate.id_penelitian_pengabdian = item.id_penelitian_pengabdian;

                                        // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil

                                        itemToUpdate.id_kategori_kegiatan = item.id_kategori_kegiatan != null ? item.id_kategori_kegiatan : itemToUpdate.id_kategori_kegiatan;

                                        itemToUpdate.judul_penelitian_pengabdian = item.judul_penelitian_pengabdian != null ? item.judul_penelitian_pengabdian : itemToUpdate.judul_penelitian_pengabdian;
                                        itemToUpdate.durasi_kegiatan = item.durasi_kegiatan != null ? item.durasi_kegiatan : itemToUpdate.durasi_kegiatan;
                                        itemToUpdate.tahun_pelaksanaan_ke = item.tahun_pelaksanaan_ke != null ? item.tahun_pelaksanaan_ke : itemToUpdate.tahun_pelaksanaan_ke;
                                        itemToUpdate.dana_dari_dikti = item.dana_dari_dikti != null ? item.dana_dari_dikti : itemToUpdate.dana_dari_dikti;
                                        itemToUpdate.dana_dari_PT = item.dana_dari_PT != null ? item.dana_dari_PT : itemToUpdate.dana_dari_PT;
                                        itemToUpdate.dana_dari_instansi_lain = item.dana_dari_instansi_lain != null ? item.dana_dari_instansi_lain : itemToUpdate.dana_dari_instansi_lain;
                                        itemToUpdate.in_kind = item.in_kind != null ? item.in_kind : itemToUpdate.in_kind;
                                        itemToUpdate.no_sk_tugas = item.no_sk_tugas != null ? item.no_sk_tugas : itemToUpdate.no_sk_tugas;
                                        itemToUpdate.tanggal_sk_penugasan = item.tanggal_sk_penugasan != null ? item.tanggal_sk_penugasan : itemToUpdate.tanggal_sk_penugasan;
                                        itemToUpdate.tempat_kegiatan = item.tempat_kegiatan != null ? item.tempat_kegiatan : itemToUpdate.tempat_kegiatan;
                                        itemToUpdate.id_jenis_skim = item.id_jenis_skim != null ? item.id_jenis_skim : itemToUpdate.id_jenis_skim;
                                        itemToUpdate.jenis_skim = item.jenis_skim != null ? item.jenis_skim : itemToUpdate.jenis_skim;
                                        itemToUpdate.tahun_usulan = item.tahun_usulan != null ? item.tahun_usulan : itemToUpdate.tahun_usulan;
                                        itemToUpdate.tahun_kegiatan = item.tahun_kegiatan != null ? item.tahun_kegiatan : itemToUpdate.tahun_kegiatan;
                                        itemToUpdate.tahun_pelaksanaan = item.tahun_pelaksanaan != null ? item.tahun_pelaksanaan : itemToUpdate.tahun_pelaksanaan;
                                        itemToUpdate.litabmas_sebelumnya = item.litabmas_sebelumnya != null ? item.litabmas_sebelumnya : itemToUpdate.litabmas_sebelumnya;
                                        itemToUpdate.id_afiliasi = item.id_afiliasi != null ? item.id_afiliasi : itemToUpdate.id_afiliasi;
                                        itemToUpdate.afiliasi = item.afiliasi != null ? item.afiliasi : itemToUpdate.afiliasi;
                                        itemToUpdate.id_kelompok_bidang = item.id_kelompok_bidang != null ? item.id_kelompok_bidang : itemToUpdate.id_kelompok_bidang;
                                        itemToUpdate.nama_kelompok_bidang = item.nama_kelompok_bidang != null ? item.nama_kelompok_bidang : itemToUpdate.nama_kelompok_bidang;
                                        if (itemToUpdate.NPP1 == null) // cek apakah kosong
                                            itemToUpdate.NPP1 = item.NPP1;
                                        else if (itemToUpdate.NPP2 == null && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP2 = item.NPP1;
                                        else if (itemToUpdate.NPP3 == null && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP3 = item.NPP1;
                                        else if (itemToUpdate.NPP4 == null && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP4 = item.NPP1;
                                        else if (itemToUpdate.NPP5 == null && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP5 = item.NPP1;
                                        else if (itemToUpdate.NPP6 == null && item.NPP1 != itemToUpdate.NPP5 && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP6 = item.NPP1;

                                    }
                                    await _DATA_SISTERcontext.SaveChangesAsync();


                                }

                                return Json(new { success = true, message = ajar });


                            }
                            else
                            {
                                var ajar = JsonConvert.DeserializeObject<Penelitian>(apiResponse);

                                return Json(new { success = false, message = ajar.message });
                            }
                        }
                        else
                        {
                            return Json(new { success = false, message = "ID Dosen Sister tidak ditemukan." });
                        }




                        //return Json(new { success = true, message = "Sinkronisasi Penelitian sukses." });

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

        public async Task<IActionResult> SinkronDataPengajaranSISTER(string id_semester)
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");
            //string id_semester = "20201"; // 2020/2021 Ganjil
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<TrPengajaran_Data_SISTER> masterList = new List<TrPengajaran_Data_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<TrPengajaran_Data_SISTER> compareList = new List<TrPengajaran_Data_SISTER>();

            if (HttpContext.Session.GetString("NPP") != null)
            {
                if(id_semester != null)
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
                            var url = baseUrl + "/authorize";
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            var response = await httpClient.PostAsync(url, data);
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            Console.WriteLine("test");
                            TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                            PenelitianReq request = new PenelitianReq();
                            idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                            idDosen = idDosen != null ? idDosen.Trim() : null;
                            if (!String.IsNullOrEmpty(idDosen) && idDosen.Length == 36)
                            {
                                url = baseUrl + "/pengajaran?id_sdm=" + idDosen + "&id_semester=" + id_semester;
                                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                response = await httpClient.GetAsync(url);
                                apiResponse = await response.Content.ReadAsStringAsync();

                                if (response.IsSuccessStatusCode)
                                {
                                    var ajar = JsonConvert.DeserializeObject<List<Pengajaran>>(apiResponse);


                                    if (ajar != null)
                                    {

                                        foreach (Pengajaran itemPengajaran in ajar)
                                        {
                                            url = baseUrl + "/pengajaran/" + itemPengajaran.id;
                                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                            //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                            response = await httpClient.GetAsync(url);
                                            apiResponse = await response.Content.ReadAsStringAsync();
                                            if (response.IsSuccessStatusCode)
                                            {
                                                var detail = JsonConvert.DeserializeObject<Pengajaran_detail>(apiResponse);

                                                TrPengajaran_Data_SISTER entrydata = new TrPengajaran_Data_SISTER();
                                                entrydata.id = detail.id;
                                                entrydata.semester = detail.semester;
                                                entrydata.mata_kuliah = detail.mata_kuliah;
                                                entrydata.kelas = detail.kelas;
                                                entrydata.sks = detail.sks;
                                                entrydata.id_semester = detail.id_semester;
                                                entrydata.sks_tatap_muka = detail.sks_tatap_muka;
                                                entrydata.sks_praktik = detail.sks_praktik;
                                                entrydata.sks_praktik_lapangan = detail.sks_praktik_lapangan;
                                                entrydata.sks_simulasi = detail.sks_simulasi;
                                                entrydata.tatap_muka_rencana = detail.tatap_muka_rencana;
                                                entrydata.tatap_muka_realisasi = detail.tatap_muka_realisasi;
                                                entrydata.jumlah_mahasiswa = detail.jumlah_mahasiswa;
                                                entrydata.jenis_evaluasi = detail.jenis_evaluasi;
                                                entrydata.nama_substansi = detail.nama_substansi;
                                                entrydata.NPP = npp;


                                                if (_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Any(a => a.id == detail.id) &&
                                                        !masterList.Any(a => a.id == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                 // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                                {
                                                    masterList.Add(_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                    compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                                }
                                                else
                                                    compareList.Add(entrydata);


                                            }
                                            else
                                            {
                                                TrPengajaran_Data_SISTER entrydata = new TrPengajaran_Data_SISTER();
                                                entrydata.id = itemPengajaran.id;
                                                entrydata.mata_kuliah = itemPengajaran.mata_kuliah;
                                                entrydata.kelas = itemPengajaran.kelas;
                                                entrydata.semester = itemPengajaran.semester;
                                                entrydata.sks = itemPengajaran.sks;
                                                entrydata.NPP = npp;
                                                if (_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Any(a => a.id == itemPengajaran.id) &&
                                                        !masterList.Any(a => a.id == itemPengajaran.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                         // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                                {
                                                    masterList.Add(_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == itemPengajaran.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                    compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                                }
                                                else
                                                    compareList.Add(entrydata);
                                            }


                                        }
                                        List<TrPengajaran_Data_SISTER> toBeAdded = new List<TrPengajaran_Data_SISTER>();
                                        List<TrPengajaran_Data_SISTER> toBeDeleted = new List<TrPengajaran_Data_SISTER>();
                                        List<TrPengajaran_Data_SISTER> toBeUpdated = new List<TrPengajaran_Data_SISTER>();

                                        toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                        toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                        toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                        _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.AddRange(toBeAdded);
                                        _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.RemoveRange(toBeDeleted);
                                        int counter = 0;
                                        foreach (var item in toBeUpdated)
                                        {
                                            counter++;
                                            var itemToUpdate = _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Find(item.id);

                                            itemToUpdate.id = item.id;

                                            // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil

                                            itemToUpdate.semester = item.semester != null ? item.semester : itemToUpdate.semester;

                                            itemToUpdate.mata_kuliah = item.mata_kuliah != null ? item.mata_kuliah : itemToUpdate.mata_kuliah;
                                            itemToUpdate.kelas = item.kelas != null ? item.kelas : itemToUpdate.kelas;
                                            itemToUpdate.sks = item.sks != null ? item.sks : itemToUpdate.sks;
                                            itemToUpdate.id_semester = item.id_semester != null ? item.id_semester : itemToUpdate.id_semester;
                                            itemToUpdate.sks_tatap_muka = item.sks_tatap_muka != null ? item.sks_tatap_muka : itemToUpdate.sks_tatap_muka;
                                            itemToUpdate.sks_praktik = item.sks_praktik != null ? item.sks_praktik : itemToUpdate.sks_praktik;
                                            itemToUpdate.sks_praktik_lapangan = item.sks_praktik_lapangan != null ? item.sks_praktik_lapangan : itemToUpdate.sks_praktik_lapangan;
                                            itemToUpdate.sks_simulasi = item.sks_simulasi != null ? item.sks_simulasi : itemToUpdate.sks_simulasi;
                                            itemToUpdate.tatap_muka_rencana = item.tatap_muka_rencana != null ? item.tatap_muka_rencana : itemToUpdate.tatap_muka_rencana;
                                            itemToUpdate.tatap_muka_realisasi = item.tatap_muka_realisasi != null ? item.tatap_muka_realisasi : itemToUpdate.tatap_muka_realisasi;
                                            itemToUpdate.jumlah_mahasiswa = item.jumlah_mahasiswa != null ? item.jumlah_mahasiswa : itemToUpdate.jumlah_mahasiswa;
                                            itemToUpdate.jenis_evaluasi = item.jenis_evaluasi != null ? item.jenis_evaluasi : itemToUpdate.jenis_evaluasi;
                                            itemToUpdate.nama_substansi = item.nama_substansi != null ? item.nama_substansi : itemToUpdate.nama_substansi;
                                            itemToUpdate.NPP = item.NPP != null ? item.NPP : itemToUpdate.NPP;

                                        }

                                        await _DATA_SISTERcontext.SaveChangesAsync();

                                    }
                                    
                                    return Json(new { success = true, message = ajar });


                                }
                                else
                                {
                                    var ajar = JsonConvert.DeserializeObject<Pengajaran>(apiResponse);

                                    return Json(new { success = false, message = ajar.message });
                                }
                            }
                            else
                            {
                                return Json(new { success = false, message = "ID Dosen Sister tidak ditemukan." });
                            }


                            //return Json(new { success = true, message = "Sinkronisasi Penelitian sukses." });

                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Semester harap dipilih" });
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> SinkronDataPublikasiSISTER()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");
            var index = 0;
            
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<TrPublikasi_DATA_SISTER> masterList = new List<TrPublikasi_DATA_SISTER>(); 

            List<TrPublikasi_DATA_SISTER> compareList = new List<TrPublikasi_DATA_SISTER>(); // nanti dibandingin sama masterlist

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                        idDosen = idDosen != null ? idDosen.Trim() : null;
                        if (!String.IsNullOrEmpty(idDosen) && idDosen.Length == 36)
                        {
                            url = baseUrl + "/publikasi?id_sdm=" + idDosen;
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                            response = await httpClient.GetAsync(url);
                            apiResponse = await response.Content.ReadAsStringAsync();

                            if (response.IsSuccessStatusCode)
                            {
                                var ajar = JsonConvert.DeserializeObject<List<Publikasi>>(apiResponse);

                                try
                                {


                                    if (ajar != null)
                                    {
                                        int noIncrementPenulis = _DATA_SISTERcontext.TblPenulis_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                        int noIncrementDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Max(a => (int?)a.no) ?? 0;

                                        foreach (Publikasi itemPublikasi in ajar)
                                        {

                                            url = baseUrl + "/publikasi/" + itemPublikasi.id;
                                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                            //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                            response = await httpClient.GetAsync(url);
                                            apiResponse = await response.Content.ReadAsStringAsync();
                                            if (response.IsSuccessStatusCode)
                                            {
                                                var detail = JsonConvert.DeserializeObject<Publikasi_detail>(apiResponse);

                                                TrPublikasi_DATA_SISTER entrydata = new TrPublikasi_DATA_SISTER();
                                                entrydata.id = detail.id;
                                                entrydata.kategori_kegiatan = detail.kategori_kegiatan;
                                                entrydata.judul = detail.judul;
                                                entrydata.quartile = detail.quartile;
                                                entrydata.jenis_publikasi = detail.jenis_publikasi;
                                                entrydata.tanggal = Convert.ToDateTime(detail.tanggal);
                                                entrydata.id_kategori_kegiatan = detail.id_kategori_kegiatan;
                                                entrydata.id_jenis_publikasi = detail.id_jenis_publikasi;
                                                entrydata.kategori_capaian_luaran = detail.kategori_capaian_luaran;
                                                entrydata.id_kategori_capaian_luaran = detail.id_kategori_capaian_luaran;
                                                entrydata.judul_litabmas = detail.judul_litabmas;
                                                entrydata.id_litabmas = detail.id_litabmas;
                                                entrydata.nomor_paten = detail.nomor_paten;
                                                entrydata.pemberi_paten = detail.pemberi_paten;
                                                entrydata.penerbit = detail.penerbit;
                                                entrydata.isbn = detail.isbn;
                                                entrydata.jumlah_halaman = detail.jumlah_halaman;
                                                entrydata.tautan = detail.tautan;
                                                entrydata.keterangan = detail.keterangan;
                                                entrydata.judul_artikel = detail.judul_artikel;
                                                entrydata.judul_asli = detail.judul_asli;
                                                entrydata.nama_jurnal = detail.nama_jurnal;
                                                entrydata.halaman = detail.halaman;
                                                entrydata.edisi = detail.edisi;
                                                entrydata.volume = detail.volume;
                                                entrydata.nomor = detail.nomor;
                                                entrydata.doi = detail.doi;
                                                entrydata.issn = detail.issn;
                                                entrydata.e_issn = detail.e_issn;
                                                entrydata.seminar = detail.seminar == true ? 1 : 0;
                                                entrydata.prosiding = detail.prosiding == true ? 1 : 0;
                                                entrydata.asal_data = detail.asal_data;
                                                entrydata.NPP1 = npp;


                                                if (_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Any(a => a.id == detail.id)) // Kalau ada id yg sama dari api dan di database maka masuk masterlist
                                                {
                                                    masterList.Add(_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == detail.id));
                                                    compareList.Add(entrydata);
                                                }
                                                else
                                                    compareList.Add(entrydata);

                                                List<TblPenulis_DATA_SISTER> masterListPenulis = _DATA_SISTERcontext.TblPenulis_DATA_SISTER.Where(a => a.id_riwayat_publikasi_paten == detail.id).ToList();
                                                List<TblPenulis_DATA_SISTER> compareListPenulis = new List<TblPenulis_DATA_SISTER>();

                                                if (detail.penulis != null && detail.penulis.Length > 0) // ============== Sinkron Penulis ================
                                                {
                                                    foreach (Penulis itemPenulis in detail.penulis)
                                                    {
                                                        TblPenulis_DATA_SISTER entryPenulis = new TblPenulis_DATA_SISTER();
                                                        entryPenulis.nama = itemPenulis.nama;
                                                        entryPenulis.id_riwayat_publikasi_paten = detail.id;
                                                        entryPenulis.urutan = itemPenulis.urutan;
                                                        entryPenulis.afiliasi = itemPenulis.afiliasi;
                                                        entryPenulis.peran = itemPenulis.peran;
                                                        entryPenulis.jenis = itemPenulis.jenis;
                                                        entryPenulis.corresponding_author = itemPenulis.corresponding_author == true ? 1 : 0;
                                                        entryPenulis.id_sdm = itemPenulis.id_sdm;
                                                        entryPenulis.id_peserta_didik = itemPenulis.id_peserta_didik;
                                                        entryPenulis.id_orang = itemPenulis.id_orang;
                                                        entryPenulis.nomor_induk_peserta_didik = itemPenulis.nomor_induk_peserta_didik;




                                                        compareListPenulis.Add(entryPenulis);

                                                    }

                                                    List<TblPenulis_DATA_SISTER> toBeAddedPenulis = new List<TblPenulis_DATA_SISTER>();
                                                    List<TblPenulis_DATA_SISTER> toBeDeletedPenulis = new List<TblPenulis_DATA_SISTER>();
                                                    List<TblPenulis_DATA_SISTER> toBeUpdatedPenulis = new List<TblPenulis_DATA_SISTER>();

                                                    toBeAddedPenulis = compareListPenulis.Where(a => !masterListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();

                                                    foreach (var itemtobeaddedPenulis in toBeAddedPenulis)
                                                    {
                                                        noIncrementPenulis++;
                                                        itemtobeaddedPenulis.no = noIncrementPenulis;
                                                    }
                                                    toBeDeletedPenulis = masterListPenulis.Where(a => !compareListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();
                                                    toBeUpdatedPenulis = compareListPenulis.Where(a => masterListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();

                                                    _DATA_SISTERcontext.TblPenulis_DATA_SISTER.AddRange(toBeAddedPenulis);
                                                    _DATA_SISTERcontext.TblPenulis_DATA_SISTER.RemoveRange(toBeDeletedPenulis);
                                                    int counterAnggota = 0;
                                                    foreach (var item in toBeUpdatedPenulis)
                                                    {
                                                        counterAnggota++;
                                                        var itemToUpdate = _DATA_SISTERcontext.TblPenulis_DATA_SISTER
                                                            .FirstOrDefault(a => a.id_riwayat_publikasi_paten == item.id_riwayat_publikasi_paten && a.id_sdm == item.id_sdm);

                                                        itemToUpdate = item;
                                                    }
                                                }

                                                await _DATA_SISTERcontext.SaveChangesAsync();



                                                List<TblDokumen_DATA_SISTER> masterListDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Where(a => a.id_publikasi_atau_penelitian == detail.id).ToList();
                                                List<TblDokumen_DATA_SISTER> compareListDokumen = new List<TblDokumen_DATA_SISTER>();

                                                if (detail.dokumen != null && detail.dokumen.Length > 0) // ============== Sinkron Dokumen ================
                                                {
                                                    foreach (Dokumen itemDokumen in detail.dokumen)
                                                    {
                                                        TblDokumen_DATA_SISTER entryDokumen = new TblDokumen_DATA_SISTER();
                                                        entryDokumen.id_dokumen = itemDokumen.id;
                                                        entryDokumen.id_publikasi_atau_penelitian = detail.id;
                                                        entryDokumen.nama_dokumen = itemDokumen.nama;
                                                        entryDokumen.nama_file = itemDokumen.nama_file;
                                                        entryDokumen.jenis_file = itemDokumen.jenis_file;
                                                        entryDokumen.tanggal_upload = Convert.ToDateTime(itemDokumen.tanggal_upload);
                                                        //entryDokumen.nama_jenis_dokumen = itemDokumen.nama;
                                                        entryDokumen.tautan = itemDokumen.tautan;
                                                        entryDokumen.keterangan_dokumen = itemDokumen.keterangan;




                                                        compareListDokumen.Add(entryDokumen);

                                                    }


                                                    List<TblDokumen_DATA_SISTER> toBeAddedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                    List<TblDokumen_DATA_SISTER> toBeDeletedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                    List<TblDokumen_DATA_SISTER> toBeUpdatedDokumen = new List<TblDokumen_DATA_SISTER>();

                                                    toBeAddedDokumen = compareListDokumen.Where(a => !masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                    foreach (var itemtobeaddeddokumen in toBeAddedDokumen)
                                                    {
                                                        noIncrementDokumen++;
                                                        itemtobeaddeddokumen.no = noIncrementDokumen;
                                                    }
                                                    toBeDeletedDokumen = masterListDokumen.Where(a => !compareListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();
                                                    toBeUpdatedDokumen = compareListDokumen.Where(a => masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                    _DATA_SISTERcontext.TblDokumen_DATA_SISTER.AddRange(toBeAddedDokumen);
                                                    _DATA_SISTERcontext.TblDokumen_DATA_SISTER.RemoveRange(toBeDeletedDokumen);
                                                    int counterAnggota = 0;
                                                    foreach (var item in toBeUpdatedDokumen)
                                                    {
                                                        counterAnggota++;
                                                        var itemToUpdate = _DATA_SISTERcontext.TblDokumen_DATA_SISTER
                                                            .FirstOrDefault(a => a.id_dokumen == item.id_dokumen);
                                                        itemToUpdate = item;
                                                    }
                                                    await _DATA_SISTERcontext.SaveChangesAsync();

                                                }

                                            }
                                            else // kadang ada id yang ga bisa dicari detail nya, maka bakal masuk sini, tapi ya jadi gatau penulis, dokumen dll
                                            {
                                                TrPublikasi_DATA_SISTER entrydata = new TrPublikasi_DATA_SISTER();
                                                entrydata.id = itemPublikasi.id;
                                                entrydata.kategori_kegiatan = itemPublikasi.kategori_kegiatan;
                                                entrydata.judul = itemPublikasi.judul;
                                                entrydata.quartile = itemPublikasi.quartile;
                                                entrydata.jenis_publikasi = itemPublikasi.jenis_publikasi;
                                                entrydata.tanggal = Convert.ToDateTime(itemPublikasi.tanggal);
                                                entrydata.asal_data = itemPublikasi.asal_data;
                                                entrydata.NPP1 = npp;


                                                if (_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Any(a => a.id == itemPublikasi.id)) // cek apakah ada data di tabel yang sama dengan id tersebut                                                                                            // kalau returnya true berarti harus dinegasi kan                                                                                   

                                                {
                                                    masterList.Add(_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == itemPublikasi.id));
                                                    compareList.Add(entrydata);
                                                }
                                                else
                                                    compareList.Add(entrydata);
                                            }


                                            index++;

                                        }
                                        List<TrPublikasi_DATA_SISTER> toBeAdded = new List<TrPublikasi_DATA_SISTER>();
                                        List<TrPublikasi_DATA_SISTER> toBeDeleted = new List<TrPublikasi_DATA_SISTER>();
                                        List<TrPublikasi_DATA_SISTER> toBeUpdated = new List<TrPublikasi_DATA_SISTER>();

                                        toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                        toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                        toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                        _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AddRange(toBeAdded);
                                        _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.RemoveRange(toBeDeleted);
                                        int counter = 0;
                                        foreach (var item in toBeUpdated)
                                        {
                                            counter++;
                                            var itemToUpdate = _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Find(item.id);

                                            itemToUpdate.id = item.id;

                                            // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil

                                            itemToUpdate.kategori_kegiatan = item.kategori_kegiatan != null ? item.kategori_kegiatan : itemToUpdate.kategori_kegiatan;
                                            itemToUpdate.judul = item.judul != null ? item.judul : itemToUpdate.judul;
                                            itemToUpdate.quartile = item.quartile != null ? item.quartile : itemToUpdate.quartile;
                                            itemToUpdate.jenis_publikasi = item.jenis_publikasi != null ? item.jenis_publikasi : itemToUpdate.jenis_publikasi;
                                            itemToUpdate.tanggal = item.tanggal != null ? item.tanggal : itemToUpdate.tanggal;
                                            itemToUpdate.id_kategori_kegiatan = item.id_kategori_kegiatan != null ? item.id_kategori_kegiatan : itemToUpdate.id_kategori_kegiatan;
                                            itemToUpdate.id_jenis_publikasi = item.id_jenis_publikasi != null ? item.id_jenis_publikasi : itemToUpdate.id_jenis_publikasi;
                                            itemToUpdate.kategori_capaian_luaran = item.kategori_capaian_luaran != null ? item.kategori_capaian_luaran : itemToUpdate.kategori_capaian_luaran;
                                            itemToUpdate.id_kategori_capaian_luaran = item.id_kategori_capaian_luaran != null ? item.id_kategori_capaian_luaran : itemToUpdate.id_kategori_capaian_luaran;
                                            itemToUpdate.judul_litabmas = item.judul_litabmas != null ? item.judul_litabmas : itemToUpdate.judul_litabmas;
                                            itemToUpdate.id_litabmas = item.id_litabmas != null ? item.id_litabmas : itemToUpdate.id_litabmas;
                                            itemToUpdate.nomor_paten = item.nomor_paten != null ? item.nomor_paten : itemToUpdate.nomor_paten;
                                            itemToUpdate.pemberi_paten = item.pemberi_paten != null ? item.pemberi_paten : itemToUpdate.pemberi_paten;
                                            itemToUpdate.penerbit = item.penerbit != null ? item.penerbit : itemToUpdate.penerbit;
                                            itemToUpdate.isbn = item.isbn != null ? item.isbn : itemToUpdate.isbn;
                                            itemToUpdate.jumlah_halaman = item.jumlah_halaman != null ? item.jumlah_halaman : itemToUpdate.jumlah_halaman;
                                            itemToUpdate.tautan = item.tautan != null ? item.tautan : itemToUpdate.tautan;
                                            itemToUpdate.keterangan = item.keterangan != null ? item.keterangan : itemToUpdate.keterangan;
                                            itemToUpdate.judul_artikel = item.judul_artikel != null ? item.judul_artikel : itemToUpdate.judul_artikel;
                                            itemToUpdate.judul_asli = item.judul_asli != null ? item.judul_asli : itemToUpdate.judul_asli;
                                            itemToUpdate.nama_jurnal = item.nama_jurnal != null ? item.nama_jurnal : itemToUpdate.nama_jurnal;
                                            itemToUpdate.halaman = item.halaman != null ? item.halaman : itemToUpdate.halaman;
                                            itemToUpdate.edisi = item.edisi != null ? item.edisi : itemToUpdate.edisi;
                                            itemToUpdate.volume = item.volume != null ? item.volume : itemToUpdate.volume;
                                            itemToUpdate.nomor = item.nomor != null ? item.nomor : itemToUpdate.nomor;
                                            itemToUpdate.doi = item.doi != null ? item.doi : itemToUpdate.doi;
                                            itemToUpdate.issn = item.issn != null ? item.issn : itemToUpdate.issn;
                                            itemToUpdate.e_issn = item.e_issn != null ? item.e_issn : itemToUpdate.e_issn;
                                            itemToUpdate.seminar = item.seminar != null ? item.seminar : itemToUpdate.seminar;
                                            itemToUpdate.prosiding = item.prosiding != null ? item.prosiding : itemToUpdate.prosiding;
                                            itemToUpdate.asal_data = item.asal_data != null ? item.asal_data : itemToUpdate.asal_data;

                                            if (itemToUpdate.NPP1 == null) // cek apakah kosong
                                                itemToUpdate.NPP1 = item.NPP1;
                                            else if (itemToUpdate.NPP2 == null && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                                itemToUpdate.NPP2 = item.NPP1;
                                            else if (itemToUpdate.NPP3 == null && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                                itemToUpdate.NPP3 = item.NPP1;
                                            else if (itemToUpdate.NPP4 == null && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                                itemToUpdate.NPP4 = item.NPP1;
                                            else if (itemToUpdate.NPP5 == null && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                                itemToUpdate.NPP5 = item.NPP1;
                                            else if (itemToUpdate.NPP6 == null && item.NPP1 != itemToUpdate.NPP5 && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                                itemToUpdate.NPP6 = item.NPP1;
                                        }

                                        await _DATA_SISTERcontext.SaveChangesAsync();

                                    }
                                }
                                catch (Exception ex)
                                {
                                    return Json(new { success = false, message = ex.Message + " ====> \n ID =" + ajar[index].id +"\n Judul =" +ajar[index].judul});

                                }

                                return Json(new { success = true, message = ajar });

                            }
                            else
                            {
                                var ajar = JsonConvert.DeserializeObject<Publikasi>(apiResponse);

                                return Json(new { success = false, message = ajar.message });
                            }

                        }
                        else
                        {
                            return Json(new { success = false, message = "ID Dosen Sister tidak ditemukan." });
                        }



                    }
                    catch (Exception ex)
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

        //public async Task<IActionResult> SinkronDataPenelitianProdiSISTER(int id_unit)
        //{
           
        //    var listNPP = _context.MstKaryawan.AsNoTracking().Where(a => a.IdUnitAkademik == id_unit).ToList();

        //    var nppstring = "";

        //    foreach (var dataNpp in listNPP)
        //    {
        //        string idDosen = null;
        //        string npp = dataNpp.Npp;
        //        //string npp = "02.11.817"; 
        //        //string npp = "03.17.953";
        //        List<TrPenelitian_DATA_SISTER> masterList = new List<TrPenelitian_DATA_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

        //        List<TrPenelitian_DATA_SISTER> compareList = new List<TrPenelitian_DATA_SISTER>();

        //        if (HttpContext.Session.GetString("NPP") != null)
        //        {

        //            using (var httpClient = new HttpClient())
        //            {
        //                try
        //                {
        //                    Sister_Token TokenSister = new Sister_Token();
        //                    var akun = new Sister_Akun();
        //                    akun.username = "GV3lhqNadhHePiwVQ5Y3Vw";
        //                    akun.password = "5QW4jKhZ8r8QDmYMHiepjHwpH/wcfTioexezIS9AS8XYPMPnNHhEHLbfpeDsP0R8";
        //                    akun.id_pengguna = "bd5df696-05d3-4db1-9e32-7c6be4e5ad36";
        //                    var json = JsonConvert.SerializeObject(akun);
        //                    var data = new StringContent(json, Encoding.UTF8, "application/json");
        //                    var url = baseUrl + "/authorize";
        //                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //                    var response = await httpClient.PostAsync(url, data);
        //                    string apiResponse = await response.Content.ReadAsStringAsync();

        //                    Console.WriteLine("test");
        //                    TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
        //                    PenelitianReq request = new PenelitianReq();
        //                    idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
        //                    if (!String.IsNullOrEmpty(idDosen))
        //                    {
        //                        url = baseUrl + "/penelitian?id_sdm=" + idDosen;
        //                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
        //                        response = await httpClient.GetAsync(url);
        //                        apiResponse = await response.Content.ReadAsStringAsync();

        //                        if (response.IsSuccessStatusCode)
        //                        {
        //                            var ajar = JsonConvert.DeserializeObject<List<Penelitian>>(apiResponse);

        //                            if (ajar != null )
        //                            {
        //                                int noIncrementAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
        //                                int noIncrementDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
        //                                int noIncrementMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Max(a => (int?)a.no) ?? 0;


        //                                foreach (Penelitian itemPenelitian in ajar)
        //                                {
        //                                    await Task.Delay(500);
        //                                    url = baseUrl + "/penelitian/" + itemPenelitian.id;
        //                                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                                    //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
        //                                    response = await httpClient.GetAsync(url);
        //                                    apiResponse = await response.Content.ReadAsStringAsync();
        //                                    if (response.IsSuccessStatusCode)
        //                                    {
        //                                        var detail = JsonConvert.DeserializeObject<Penelitian_Detail>(apiResponse);

        //                                        TrPenelitian_DATA_SISTER entrydata = new TrPenelitian_DATA_SISTER();
        //                                        entrydata.id_penelitian_pengabdian = detail.id;
        //                                        entrydata.id_kategori_kegiatan = detail.id_kategori_kegiatan;

        //                                        entrydata.judul_penelitian_pengabdian = detail.judul;
        //                                        entrydata.durasi_kegiatan = detail.lama_kegiatan;
        //                                        entrydata.tahun_pelaksanaan_ke = detail.tahun_pelaksanaan_ke;
        //                                        entrydata.dana_dari_dikti = Convert.ToDecimal(detail.dana_dikti);
        //                                        entrydata.dana_dari_PT = Convert.ToDecimal(detail.dana_perguruan_tinggi);
        //                                        entrydata.dana_dari_instansi_lain = Convert.ToDecimal(detail.dana_institusi_lain);
        //                                        entrydata.in_kind = detail.in_kind;
        //                                        entrydata.no_sk_tugas = detail.sk_penugasan;
        //                                        entrydata.tanggal_sk_penugasan = Convert.ToDateTime(detail.tanggal_sk_penugasan).Date;
        //                                        entrydata.tempat_kegiatan = detail.lokasi;
        //                                        entrydata.id_jenis_skim = detail.id_jenis_skim;
        //                                        entrydata.jenis_skim = detail.jenis_skim;
        //                                        entrydata.tahun_usulan = detail.tahun_usulan;
        //                                        entrydata.tahun_kegiatan = detail.tahun_kegiatan;
        //                                        entrydata.tahun_pelaksanaan = detail.tahun_pelaksanaan;
        //                                        entrydata.id_litabmas_sebelumnya = detail.id_litabmas_sebelumnya;
        //                                        entrydata.litabmas_sebelumnya = detail.litabmas_sebelumnya;
        //                                        entrydata.id_afiliasi = detail.id_afiliasi;
        //                                        entrydata.afiliasi = detail.afiliasi;
        //                                        entrydata.id_kelompok_bidang = detail.id_kelompok_bidang;
        //                                        entrydata.nama_kelompok_bidang = detail.kelompok_bidang;
        //                                        entrydata.NPP1 = npp;

        //                                        if (_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == detail.id) &&
        //                                                !masterList.Any(a => a.id_penelitian_pengabdian == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
        //                                                                                                               // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
        //                                        {
        //                                            masterList.Add(_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
        //                                            compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
        //                                        }
        //                                        else
        //                                            compareList.Add(entrydata);

        //                                        List<TblAnggota_DATA_SISTER> masterListAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
        //                                        List<TblAnggota_DATA_SISTER> compareListAnggota = new List<TblAnggota_DATA_SISTER>();

        //                                        if (detail.anggota != null && detail.anggota.Length > 0) // ============== Sinkron Penulis ================
        //                                        {
        //                                            foreach (Anggota itemAnggota in detail.anggota)
        //                                            {
        //                                                TblAnggota_DATA_SISTER entryAnggota = new TblAnggota_DATA_SISTER();
        //                                                entryAnggota.jenis = itemAnggota.jenis;
        //                                                entryAnggota.nama = itemAnggota.nama;
        //                                                entryAnggota.nipd = itemAnggota.nipd;
        //                                                entryAnggota.peran = itemAnggota.peran;
        //                                                entryAnggota.id_sdm = itemAnggota.id_sdm;
        //                                                entryAnggota.id_orang = itemAnggota.id_orang;
        //                                                entryAnggota.id_pd = itemAnggota.id_pd;
        //                                                entryAnggota.stat_aktif = itemAnggota.stat_aktif == true ? 1 : 0;
        //                                                entryAnggota.id_penelitian_pengabdian = detail.id;

        //                                                compareListAnggota.Add(entryAnggota);

        //                                            }


        //                                            List<TblAnggota_DATA_SISTER> toBeAddedAnggota = new List<TblAnggota_DATA_SISTER>();
        //                                            List<TblAnggota_DATA_SISTER> toBeDeletedAnggota = new List<TblAnggota_DATA_SISTER>();
        //                                            List<TblAnggota_DATA_SISTER> toBeUpdatedAnggota = new List<TblAnggota_DATA_SISTER>();

        //                                            toBeAddedAnggota = compareListAnggota.Where(a => !masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

        //                                            foreach (var itemtobeaddedAnggota in toBeAddedAnggota)
        //                                            {
        //                                                noIncrementAnggota++;
        //                                                itemtobeaddedAnggota.no = noIncrementAnggota;
        //                                            }
        //                                            toBeDeletedAnggota = masterListAnggota.Where(a => !compareListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
        //                                            toBeUpdatedAnggota = compareListAnggota.Where(a => masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

        //                                            _DATA_SISTERcontext.TblAnggota_DATA_SISTER.AddRange(toBeAddedAnggota);
        //                                            _DATA_SISTERcontext.TblAnggota_DATA_SISTER.RemoveRange(toBeDeletedAnggota);
        //                                            int counterAnggota = 0;
        //                                            foreach (var item in toBeUpdatedAnggota)
        //                                            {
        //                                                counterAnggota++;
        //                                                var itemToUpdate = _DATA_SISTERcontext.TblAnggota_DATA_SISTER
        //                                                    .FirstOrDefault(a => a.id_penelitian_pengabdian == item.id_penelitian_pengabdian && a.id_sdm == item.id_sdm);

        //                                                itemToUpdate = item;
        //                                            }
        //                                        }




        //                                        List<TblDokumen_DATA_SISTER> masterListDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Where(a => a.id_publikasi_atau_penelitian == detail.id).ToList();
        //                                        List<TblDokumen_DATA_SISTER> compareListDokumen = new List<TblDokumen_DATA_SISTER>();

        //                                        if (detail.dokumen != null && detail.dokumen.Length > 0) // ============== Sinkron Dokumen ================
        //                                        {
        //                                            foreach (Dokumen itemDokumen in detail.dokumen)
        //                                            {
        //                                                TblDokumen_DATA_SISTER entryDokumen = new TblDokumen_DATA_SISTER();
        //                                                entryDokumen.id_dokumen = itemDokumen.id;
        //                                                entryDokumen.id_publikasi_atau_penelitian = detail.id;
        //                                                entryDokumen.nama_dokumen = itemDokumen.nama;
        //                                                entryDokumen.nama_file = itemDokumen.nama_file;
        //                                                entryDokumen.jenis_file = itemDokumen.jenis_file;
        //                                                entryDokumen.tanggal_upload = Convert.ToDateTime(itemDokumen.tanggal_upload);
        //                                                //entryDokumen.nama_jenis_dokumen = itemDokumen.nama;
        //                                                entryDokumen.tautan = itemDokumen.tautan;
        //                                                entryDokumen.keterangan_dokumen = itemDokumen.keterangan;




        //                                                compareListDokumen.Add(entryDokumen);

        //                                            }


        //                                            List<TblDokumen_DATA_SISTER> toBeAddedDokumen = new List<TblDokumen_DATA_SISTER>();
        //                                            List<TblDokumen_DATA_SISTER> toBeDeletedDokumen = new List<TblDokumen_DATA_SISTER>();
        //                                            List<TblDokumen_DATA_SISTER> toBeUpdatedDokumen = new List<TblDokumen_DATA_SISTER>();

        //                                            toBeAddedDokumen = compareListDokumen.Where(a => !masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

        //                                            foreach (var itemtobeaddeddokumen in toBeAddedDokumen)
        //                                            {
        //                                                noIncrementDokumen++;
        //                                                itemtobeaddeddokumen.no = noIncrementDokumen;
        //                                            }
        //                                            toBeDeletedDokumen = masterListDokumen.Where(a => !compareListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();
        //                                            toBeUpdatedDokumen = compareListDokumen.Where(a => masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

        //                                            _DATA_SISTERcontext.TblDokumen_DATA_SISTER.AddRange(toBeAddedDokumen);
        //                                            _DATA_SISTERcontext.TblDokumen_DATA_SISTER.RemoveRange(toBeDeletedDokumen);
        //                                            int counterAnggota = 0;
        //                                            foreach (var item in toBeUpdatedDokumen)
        //                                            {
        //                                                counterAnggota++;
        //                                                var itemToUpdate = _DATA_SISTERcontext.TblDokumen_DATA_SISTER
        //                                                    .FirstOrDefault(a => a.id_dokumen == item.id_dokumen);
        //                                                itemToUpdate = item;
        //                                            }
        //                                        }



        //                                        List<TblMitra_Litabmas_DATA_SISTER> masterListMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
        //                                        List<TblMitra_Litabmas_DATA_SISTER> compareListMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

        //                                        if (detail.mitra_litabmas != null && detail.mitra_litabmas.Length > 0) // ============== Sinkron Dokumen ================
        //                                        {
        //                                            foreach (Mitra_Litabmas itemMitra in detail.mitra_litabmas)
        //                                            {
        //                                                TblMitra_Litabmas_DATA_SISTER entryMitra = new TblMitra_Litabmas_DATA_SISTER();
        //                                                entryMitra.id_penelitian_pengabdian = detail.id;
        //                                                entryMitra.id = itemMitra.id;
        //                                                entryMitra.nama = itemMitra.nama;

        //                                                compareListMitra.Add(entryMitra);

        //                                            }


        //                                            List<TblMitra_Litabmas_DATA_SISTER> toBeAddedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
        //                                            List<TblMitra_Litabmas_DATA_SISTER> toBeDeletedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
        //                                            List<TblMitra_Litabmas_DATA_SISTER> toBeUpdatedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

        //                                            toBeAddedMitra = compareListMitra.Where(a => !masterListMitra.Any(b => a.id == b.id)).ToList();

        //                                            foreach (var itemtobeaddedMitra in toBeAddedMitra)
        //                                            {
        //                                                noIncrementMitra++;
        //                                                itemtobeaddedMitra.no = noIncrementMitra;
        //                                            }
        //                                            toBeDeletedMitra = masterListMitra.Where(a => !compareListMitra.Any(b => a.id == b.id)).ToList();
        //                                            toBeUpdatedMitra = compareListMitra.Where(a => masterListMitra.Any(b => a.id == b.id)).ToList();

        //                                            _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.AddRange(toBeAddedMitra);
        //                                            _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.RemoveRange(toBeDeletedMitra);
        //                                            int counterAnggota = 0;
        //                                            foreach (var item in toBeUpdatedMitra)
        //                                            {
        //                                                counterAnggota++;
        //                                                var itemToUpdate = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER
        //                                                    .FirstOrDefault(a => a.id == item.id);
        //                                                itemToUpdate = item;
        //                                            }
        //                                        }

        //                                    }
        //                                    else
        //                                    {
        //                                        TrPenelitian_DATA_SISTER entrydata = new TrPenelitian_DATA_SISTER();
        //                                        entrydata.id_penelitian_pengabdian = itemPenelitian.id;
        //                                        entrydata.judul_penelitian_pengabdian = itemPenelitian.judul;
        //                                        entrydata.tahun_pelaksanaan = itemPenelitian.tahun_pelaksanaan;
        //                                        entrydata.NPP1 = npp;

        //                                        if (_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id) &&
        //                                               !masterList.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
        //                                                                                                                      // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
        //                                        {
        //                                            masterList.Add(_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == itemPenelitian.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
        //                                            compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
        //                                        }
        //                                        else
        //                                            compareList.Add(entrydata);
        //                                    }


        //                                }
        //                                List<TrPenelitian_DATA_SISTER> toBeAdded = new List<TrPenelitian_DATA_SISTER>();
        //                                List<TrPenelitian_DATA_SISTER> toBeDeleted = new List<TrPenelitian_DATA_SISTER>();
        //                                List<TrPenelitian_DATA_SISTER> toBeUpdated = new List<TrPenelitian_DATA_SISTER>();

        //                                toBeAdded = compareList.Where(a => !masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
        //                                toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
        //                                toBeUpdated = compareList.Where(a => masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

        //                                _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AddRange(toBeAdded);
        //                                _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.RemoveRange(toBeDeleted);
        //                                int counter = 0;
        //                                foreach (var item in toBeUpdated)
        //                                {
        //                                    counter++;
        //                                    var itemToUpdate = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Find(item.id_penelitian_pengabdian);

        //                                    itemToUpdate.id_penelitian_pengabdian = item.id_penelitian_pengabdian;

        //                                    // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil

        //                                    itemToUpdate.id_kategori_kegiatan = item.id_kategori_kegiatan != null ? item.id_kategori_kegiatan : itemToUpdate.id_kategori_kegiatan;

        //                                    itemToUpdate.judul_penelitian_pengabdian = item.judul_penelitian_pengabdian != null ? item.judul_penelitian_pengabdian : itemToUpdate.judul_penelitian_pengabdian;
        //                                    itemToUpdate.durasi_kegiatan = item.durasi_kegiatan != null ? item.durasi_kegiatan : itemToUpdate.durasi_kegiatan;
        //                                    itemToUpdate.tahun_pelaksanaan_ke = item.tahun_pelaksanaan_ke != null ? item.tahun_pelaksanaan_ke : itemToUpdate.tahun_pelaksanaan_ke;
        //                                    itemToUpdate.dana_dari_dikti = item.dana_dari_dikti != null ? item.dana_dari_dikti : itemToUpdate.dana_dari_dikti;
        //                                    itemToUpdate.dana_dari_PT = item.dana_dari_PT != null ? item.dana_dari_PT : itemToUpdate.dana_dari_PT;
        //                                    itemToUpdate.dana_dari_instansi_lain = item.dana_dari_instansi_lain != null ? item.dana_dari_instansi_lain : itemToUpdate.dana_dari_instansi_lain;
        //                                    itemToUpdate.in_kind = item.in_kind != null ? item.in_kind : itemToUpdate.in_kind;
        //                                    itemToUpdate.no_sk_tugas = item.no_sk_tugas != null ? item.no_sk_tugas : itemToUpdate.no_sk_tugas;
        //                                    itemToUpdate.tanggal_sk_penugasan = item.tanggal_sk_penugasan != null ? item.tanggal_sk_penugasan : itemToUpdate.tanggal_sk_penugasan;
        //                                    itemToUpdate.tempat_kegiatan = item.tempat_kegiatan != null ? item.tempat_kegiatan : itemToUpdate.tempat_kegiatan;
        //                                    itemToUpdate.id_jenis_skim = item.id_jenis_skim != null ? item.id_jenis_skim : itemToUpdate.id_jenis_skim;
        //                                    itemToUpdate.jenis_skim = item.jenis_skim != null ? item.jenis_skim : itemToUpdate.jenis_skim;
        //                                    itemToUpdate.tahun_usulan = item.tahun_usulan != null ? item.tahun_usulan : itemToUpdate.tahun_usulan;
        //                                    itemToUpdate.tahun_kegiatan = item.tahun_kegiatan != null ? item.tahun_kegiatan : itemToUpdate.tahun_kegiatan;
        //                                    itemToUpdate.tahun_pelaksanaan = item.tahun_pelaksanaan != null ? item.tahun_pelaksanaan : itemToUpdate.tahun_pelaksanaan;
        //                                    itemToUpdate.litabmas_sebelumnya = item.litabmas_sebelumnya != null ? item.litabmas_sebelumnya : itemToUpdate.litabmas_sebelumnya;
        //                                    itemToUpdate.id_afiliasi = item.id_afiliasi != null ? item.id_afiliasi : itemToUpdate.id_afiliasi;
        //                                    itemToUpdate.afiliasi = item.afiliasi != null ? item.afiliasi : itemToUpdate.afiliasi;
        //                                    itemToUpdate.id_kelompok_bidang = item.id_kelompok_bidang != null ? item.id_kelompok_bidang : itemToUpdate.id_kelompok_bidang;
        //                                    itemToUpdate.nama_kelompok_bidang = item.nama_kelompok_bidang != null ? item.nama_kelompok_bidang : itemToUpdate.nama_kelompok_bidang;
        //                                    if (itemToUpdate.NPP1 == null) // cek apakah kosong
        //                                        itemToUpdate.NPP1 = item.NPP1;
        //                                    else if (itemToUpdate.NPP2 == null && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
        //                                        itemToUpdate.NPP2 = item.NPP1;
        //                                    else if (itemToUpdate.NPP3 == null && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
        //                                        itemToUpdate.NPP3 = item.NPP1;
        //                                    else if (itemToUpdate.NPP4 == null && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
        //                                        itemToUpdate.NPP4 = item.NPP1;
        //                                    else if (itemToUpdate.NPP5 == null && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
        //                                        itemToUpdate.NPP5 = item.NPP1;
        //                                    else if (itemToUpdate.NPP6 == null && item.NPP1 != itemToUpdate.NPP5 && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
        //                                        itemToUpdate.NPP6 = item.NPP1;
        //                                }

        //                                await _DATA_SISTERcontext.SaveChangesAsync();
        //                                await Task.Delay(2000);
        //                            }
        //                            return Json(new { success = true, message =  });


        //                        }

        //                    }


        //                    //return Json(new { success = true, message = "Sinkronisasi Penelitian sukses." });


        //                }
        //                catch (Exception)
        //                {
        //                    throw;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            TempData["Message"] = "Sesi Berakhir.";
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    return Json(new { success = true, message = "ajar" });


        //}

        public async Task<IActionResult> SinkronDataPublikasiProdiSISTER()
        {
            var id_unit = _context.MstUnit.AsNoTracking().FirstOrDefault(a => a.NamaUnit == "Program Studi Informatika").IdUnit;

            var listNPP = _context.MstKaryawan.AsNoTracking().Where(a => a.IdUnitAkademik == id_unit).Take(10).ToList();

            var nppstring = "";

            foreach (var dataNpp in listNPP)
            {
                string idDosen = null;
                string npp = dataNpp.Npp;
                //string npp = "01.13.847";
                //string npp = "03.17.953";
                List<TrPublikasi_DATA_SISTER> masterList = new List<TrPublikasi_DATA_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

                List<TrPublikasi_DATA_SISTER> compareList = new List<TrPublikasi_DATA_SISTER>();

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
                            var url = baseUrl + "/authorize";
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            var response = await httpClient.PostAsync(url, data);
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            Console.WriteLine("test");
                            TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                            idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                            idDosen = idDosen != null ? idDosen.Trim() : null;
                            if (!String.IsNullOrEmpty(idDosen) && idDosen.Length == 36)
                            {
                                url = baseUrl + "/publikasi?id_sdm=" + idDosen;
                                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                response = await httpClient.GetAsync(url);
                                apiResponse = await response.Content.ReadAsStringAsync();


                                if (response.IsSuccessStatusCode)
                                {
                                    var ajar = JsonConvert.DeserializeObject<List<Publikasi>>(apiResponse);

                                    if (ajar != null )
                                    {
                                        int noIncrementPenulis = _DATA_SISTERcontext.TblPenulis_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                        int noIncrementDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Max(a => (int?)a.no) ?? 0;

                                        foreach (Publikasi itemPublikasi in ajar)
                                        {
                                            await Task.Delay(500);

                                            url = baseUrl + "/publikasi/" + itemPublikasi.id;
                                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                            //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                            response = await httpClient.GetAsync(url);
                                            apiResponse = await response.Content.ReadAsStringAsync();
                                            if (response.IsSuccessStatusCode)
                                            {
                                                var detail = JsonConvert.DeserializeObject<Publikasi_detail>(apiResponse);

                                                TrPublikasi_DATA_SISTER entrydata = new TrPublikasi_DATA_SISTER();
                                                entrydata.id = detail.id;
                                                entrydata.kategori_kegiatan = detail.kategori_kegiatan;
                                                entrydata.judul = detail.judul;
                                                entrydata.quartile = detail.quartile;
                                                entrydata.jenis_publikasi = detail.jenis_publikasi;
                                                entrydata.tanggal = Convert.ToDateTime(detail.tanggal);
                                                entrydata.id_kategori_kegiatan = detail.id_kategori_kegiatan;
                                                entrydata.id_jenis_publikasi = detail.id_jenis_publikasi;
                                                entrydata.kategori_capaian_luaran = detail.kategori_capaian_luaran;
                                                entrydata.id_kategori_capaian_luaran = detail.id_kategori_capaian_luaran;
                                                entrydata.judul_litabmas = detail.judul_litabmas;
                                                entrydata.id_litabmas = detail.id_litabmas;
                                                entrydata.nomor_paten = detail.nomor_paten;
                                                entrydata.pemberi_paten = detail.pemberi_paten;
                                                entrydata.penerbit = detail.penerbit;
                                                entrydata.isbn = detail.isbn;
                                                entrydata.jumlah_halaman = detail.jumlah_halaman;
                                                entrydata.tautan = detail.tautan;
                                                entrydata.keterangan = detail.keterangan;
                                                entrydata.judul_artikel = detail.judul_artikel;
                                                entrydata.judul_asli = detail.judul_asli;
                                                entrydata.nama_jurnal = detail.nama_jurnal;
                                                entrydata.halaman = detail.halaman;
                                                entrydata.edisi = detail.edisi;
                                                entrydata.volume = detail.volume;
                                                entrydata.nomor = detail.nomor;
                                                entrydata.doi = detail.doi;
                                                entrydata.issn = detail.issn;
                                                entrydata.e_issn = detail.e_issn;
                                                entrydata.seminar = detail.seminar == true ? 1 : 0;
                                                entrydata.prosiding = detail.prosiding == true ? 1 : 0;
                                                entrydata.asal_data = detail.asal_data;
                                                entrydata.NPP1 = npp;


                                                if (_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Any(a => a.id == detail.id) &&
                                                        !masterList.Any(a => a.id == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                 // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                                {
                                                    masterList.Add(_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                    compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                                }
                                                else
                                                    compareList.Add(entrydata);

                                                List<TblPenulis_DATA_SISTER> masterListPenulis = _DATA_SISTERcontext.TblPenulis_DATA_SISTER.Where(a => a.id_riwayat_publikasi_paten == detail.id).ToList();
                                                List<TblPenulis_DATA_SISTER> compareListPenulis = new List<TblPenulis_DATA_SISTER>();

                                                if (detail.penulis != null && detail.penulis.Length > 0) // ============== Sinkron Penulis ================
                                                {
                                                    foreach (Penulis itemPenulis in detail.penulis)
                                                    {
                                                        TblPenulis_DATA_SISTER entryPenulis = new TblPenulis_DATA_SISTER();
                                                        entryPenulis.nama = itemPenulis.nama;
                                                        entryPenulis.id_riwayat_publikasi_paten = detail.id;
                                                        entryPenulis.urutan = itemPenulis.urutan;
                                                        entryPenulis.afiliasi = itemPenulis.afiliasi;
                                                        entryPenulis.peran = itemPenulis.peran;
                                                        entryPenulis.jenis = itemPenulis.jenis;
                                                        entryPenulis.corresponding_author = itemPenulis.corresponding_author == true ? 1 : 0;
                                                        entryPenulis.id_sdm = itemPenulis.id_sdm;
                                                        entryPenulis.id_peserta_didik = itemPenulis.id_peserta_didik;
                                                        entryPenulis.id_orang = itemPenulis.id_orang;
                                                        entryPenulis.nomor_induk_peserta_didik = itemPenulis.nomor_induk_peserta_didik;

                                                        compareListPenulis.Add(entryPenulis);

                                                    }


                                                    List<TblPenulis_DATA_SISTER> toBeAddedPenulis = new List<TblPenulis_DATA_SISTER>();
                                                    List<TblPenulis_DATA_SISTER> toBeDeletedPenulis = new List<TblPenulis_DATA_SISTER>();
                                                    List<TblPenulis_DATA_SISTER> toBeUpdatedPenulis = new List<TblPenulis_DATA_SISTER>();

                                                    toBeAddedPenulis = compareListPenulis.Where(a => !masterListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();

                                                    foreach (var itemtobeaddedPenulis in toBeAddedPenulis)
                                                    {
                                                        noIncrementPenulis++;
                                                        itemtobeaddedPenulis.no = noIncrementPenulis;
                                                    }
                                                    toBeDeletedPenulis = masterListPenulis.Where(a => !compareListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();
                                                    toBeUpdatedPenulis = compareListPenulis.Where(a => masterListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();

                                                    _DATA_SISTERcontext.TblPenulis_DATA_SISTER.AddRange(toBeAddedPenulis);
                                                    _DATA_SISTERcontext.TblPenulis_DATA_SISTER.RemoveRange(toBeDeletedPenulis);
                                                    int counterAnggota = 0;
                                                    foreach (var item in toBeUpdatedPenulis)
                                                    {
                                                        counterAnggota++;
                                                        var itemToUpdate = _DATA_SISTERcontext.TblPenulis_DATA_SISTER
                                                            .FirstOrDefault(a => a.id_riwayat_publikasi_paten == item.id_riwayat_publikasi_paten && a.id_sdm == item.id_sdm);

                                                        itemToUpdate = item;
                                                    }
                                                }




                                                List<TblDokumen_DATA_SISTER> masterListDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Where(a => a.id_publikasi_atau_penelitian == detail.id).ToList();
                                                List<TblDokumen_DATA_SISTER> compareListDokumen = new List<TblDokumen_DATA_SISTER>();

                                                if (detail.dokumen != null && detail.dokumen.Length > 0) // ============== Sinkron Dokumen ================
                                                {
                                                    foreach (Dokumen itemDokumen in detail.dokumen)
                                                    {
                                                        TblDokumen_DATA_SISTER entryDokumen = new TblDokumen_DATA_SISTER();
                                                        entryDokumen.id_dokumen = itemDokumen.id;
                                                        entryDokumen.id_publikasi_atau_penelitian = detail.id;
                                                        entryDokumen.nama_dokumen = itemDokumen.nama;
                                                        entryDokumen.nama_file = itemDokumen.nama_file;
                                                        entryDokumen.jenis_file = itemDokumen.jenis_file;
                                                        entryDokumen.tanggal_upload = Convert.ToDateTime(itemDokumen.tanggal_upload);
                                                        //entryDokumen.nama_jenis_dokumen = itemDokumen.nama;
                                                        entryDokumen.tautan = itemDokumen.tautan;
                                                        entryDokumen.keterangan_dokumen = itemDokumen.keterangan;

                                                        compareListDokumen.Add(entryDokumen);

                                                    }


                                                    List<TblDokumen_DATA_SISTER> toBeAddedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                    List<TblDokumen_DATA_SISTER> toBeDeletedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                    List<TblDokumen_DATA_SISTER> toBeUpdatedDokumen = new List<TblDokumen_DATA_SISTER>();

                                                    toBeAddedDokumen = compareListDokumen.Where(a => !masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                    foreach (var itemtobeaddeddokumen in toBeAddedDokumen)
                                                    {
                                                        noIncrementDokumen++;
                                                        itemtobeaddeddokumen.no = noIncrementDokumen;
                                                    }
                                                    toBeDeletedDokumen = masterListDokumen.Where(a => !compareListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();
                                                    toBeUpdatedDokumen = compareListDokumen.Where(a => masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                    _DATA_SISTERcontext.TblDokumen_DATA_SISTER.AddRange(toBeAddedDokumen);
                                                    _DATA_SISTERcontext.TblDokumen_DATA_SISTER.RemoveRange(toBeDeletedDokumen);
                                                    int counterAnggota = 0;
                                                    foreach (var item in toBeUpdatedDokumen)
                                                    {
                                                        counterAnggota++;
                                                        var itemToUpdate = _DATA_SISTERcontext.TblDokumen_DATA_SISTER
                                                            .FirstOrDefault(a => a.id_dokumen == item.id_dokumen);
                                                        itemToUpdate = item;
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                TrPublikasi_DATA_SISTER entrydata = new TrPublikasi_DATA_SISTER();
                                                entrydata.id = itemPublikasi.id;
                                                entrydata.kategori_kegiatan = itemPublikasi.kategori_kegiatan;
                                                entrydata.judul = itemPublikasi.judul;
                                                entrydata.quartile = itemPublikasi.quartile;
                                                entrydata.jenis_publikasi = itemPublikasi.jenis_publikasi;
                                                entrydata.tanggal = Convert.ToDateTime(itemPublikasi.tanggal);
                                                entrydata.asal_data = itemPublikasi.asal_data;
                                                entrydata.NPP1 = npp;



                                                if (_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Any(a => a.id == itemPublikasi.id) &&
                                                       !masterList.Any(a => a.id == itemPublikasi.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                       // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                                {
                                                    masterList.Add(_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == itemPublikasi.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                    compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                                }
                                                else
                                                    compareList.Add(entrydata);
                                            }


                                        }
                                        List<TrPublikasi_DATA_SISTER> toBeAdded = new List<TrPublikasi_DATA_SISTER>();
                                        List<TrPublikasi_DATA_SISTER> toBeDeleted = new List<TrPublikasi_DATA_SISTER>();
                                        List<TrPublikasi_DATA_SISTER> toBeUpdated = new List<TrPublikasi_DATA_SISTER>();

                                        toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                        toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                        toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                        _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AddRange(toBeAdded);
                                        _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.RemoveRange(toBeDeleted);
                                        int counter = 0;
                                        foreach (var item in toBeUpdated)
                                        {
                                            counter++;
                                            var itemToUpdate = _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Find(item.id);

                                            itemToUpdate.id = item.id;

                                            // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil



                                            itemToUpdate.kategori_kegiatan = item.kategori_kegiatan != null ? item.kategori_kegiatan : itemToUpdate.kategori_kegiatan;
                                            itemToUpdate.judul = item.judul != null ? item.judul : itemToUpdate.judul;
                                            itemToUpdate.quartile = item.quartile != null ? item.quartile : itemToUpdate.quartile;
                                            itemToUpdate.jenis_publikasi = item.jenis_publikasi != null ? item.jenis_publikasi : itemToUpdate.jenis_publikasi;
                                            itemToUpdate.tanggal = item.tanggal != null ? item.tanggal : itemToUpdate.tanggal;
                                            itemToUpdate.id_kategori_kegiatan = item.id_kategori_kegiatan != null ? item.id_kategori_kegiatan : itemToUpdate.id_kategori_kegiatan;
                                            itemToUpdate.id_jenis_publikasi = item.id_jenis_publikasi != null ? item.id_jenis_publikasi : itemToUpdate.id_jenis_publikasi;
                                            itemToUpdate.kategori_capaian_luaran = item.kategori_capaian_luaran != null ? item.kategori_capaian_luaran : itemToUpdate.kategori_capaian_luaran;
                                            itemToUpdate.id_kategori_capaian_luaran = item.id_kategori_capaian_luaran != null ? item.id_kategori_capaian_luaran : itemToUpdate.id_kategori_capaian_luaran;
                                            itemToUpdate.judul_litabmas = item.judul_litabmas != null ? item.judul_litabmas : itemToUpdate.judul_litabmas;
                                            itemToUpdate.id_litabmas = item.id_litabmas != null ? item.id_litabmas : itemToUpdate.id_litabmas;
                                            itemToUpdate.nomor_paten = item.nomor_paten != null ? item.nomor_paten : itemToUpdate.nomor_paten;
                                            itemToUpdate.pemberi_paten = item.pemberi_paten != null ? item.pemberi_paten : itemToUpdate.pemberi_paten;
                                            itemToUpdate.penerbit = item.penerbit != null ? item.penerbit : itemToUpdate.penerbit;
                                            itemToUpdate.isbn = item.isbn != null ? item.isbn : itemToUpdate.isbn;
                                            itemToUpdate.jumlah_halaman = item.jumlah_halaman != null ? item.jumlah_halaman : itemToUpdate.jumlah_halaman;
                                            itemToUpdate.tautan = item.tautan != null ? item.tautan : itemToUpdate.tautan;
                                            itemToUpdate.keterangan = item.keterangan != null ? item.keterangan : itemToUpdate.keterangan;
                                            itemToUpdate.judul_artikel = item.judul_artikel != null ? item.judul_artikel : itemToUpdate.judul_artikel;
                                            itemToUpdate.judul_asli = item.judul_asli != null ? item.judul_asli : itemToUpdate.judul_asli;
                                            itemToUpdate.nama_jurnal = item.nama_jurnal != null ? item.nama_jurnal : itemToUpdate.nama_jurnal;
                                            itemToUpdate.halaman = item.halaman != null ? item.halaman : itemToUpdate.halaman;
                                            itemToUpdate.edisi = item.edisi != null ? item.edisi : itemToUpdate.edisi;
                                            itemToUpdate.volume = item.volume != null ? item.volume : itemToUpdate.volume;
                                            itemToUpdate.nomor = item.nomor != null ? item.nomor : itemToUpdate.nomor;
                                            itemToUpdate.doi = item.doi != null ? item.doi : itemToUpdate.doi;
                                            itemToUpdate.issn = item.issn != null ? item.issn : itemToUpdate.issn;
                                            itemToUpdate.e_issn = item.e_issn != null ? item.e_issn : itemToUpdate.e_issn;
                                            itemToUpdate.seminar = item.seminar != null ? item.seminar : itemToUpdate.seminar;
                                            itemToUpdate.prosiding = item.prosiding != null ? item.prosiding : itemToUpdate.prosiding;
                                            itemToUpdate.asal_data = item.asal_data != null ? item.asal_data : itemToUpdate.asal_data;

                                            if (itemToUpdate.NPP1 == null) // cek apakah kosong
                                                itemToUpdate.NPP1 = item.NPP1;
                                            else if (itemToUpdate.NPP2 == null && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                                itemToUpdate.NPP2 = item.NPP1;
                                            else if (itemToUpdate.NPP3 == null && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                                itemToUpdate.NPP3 = item.NPP1;
                                            else if (itemToUpdate.NPP4 == null && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                                itemToUpdate.NPP4 = item.NPP1;
                                            else if (itemToUpdate.NPP5 == null && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                                itemToUpdate.NPP5 = item.NPP1;
                                            else if (itemToUpdate.NPP6 == null && item.NPP1 != itemToUpdate.NPP5 && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                                itemToUpdate.NPP6 = item.NPP1;
                                        }

                                        await _DATA_SISTERcontext.SaveChangesAsync();

                                    }



                                }
                                else
                                {
                                    var ajar = JsonConvert.DeserializeObject<Penelitian>(apiResponse);
                                    return Json(new { success = false, nama = "", message = ajar.detail });

                                }
                            }
                            else
                            {
                                return Json(new { success = false, nama = "", message = "ID Dosen Sister tidak ditemukan." });
                            }


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
            return Json(new { success = true, message = "Sinkronisasi Publikasi Berhasil" });

        }
        public async Task<IActionResult> SinkronDataPengabdianProdiSISTER()
        {
            var id_unit = _context.MstUnit.AsNoTracking().FirstOrDefault(a => a.NamaUnit == "Program Studi Informatika").IdUnit;
           

            var listNPP = _context.MstKaryawan.AsNoTracking().Where(a => a.IdUnitAkademik == id_unit).ToList();

            var nppstring = "";

            foreach (var dataNpp in listNPP)
            {
                string idDosen = null;
                string npp = dataNpp.Npp;
                //string npp = "02.11.817"; 
                //string npp = "03.17.953";
                List<TrPengabdian_DATA_SISTER> masterList = new List<TrPengabdian_DATA_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

                List<TrPengabdian_DATA_SISTER> compareList = new List<TrPengabdian_DATA_SISTER>();

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
                            var url = baseUrl + "/authorize";
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            var response = await httpClient.PostAsync(url, data);
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            Console.WriteLine("test");
                            TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                            PenelitianReq request = new PenelitianReq();
                            idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                            idDosen = idDosen != null ? idDosen.Trim() : null;
                            if (!String.IsNullOrEmpty(idDosen) && idDosen.Length == 36)
                            {
                                 url = baseUrl + "/pengabdian?id_sdm=" + idDosen;
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                            response = await httpClient.GetAsync(url);
                            apiResponse = await response.Content.ReadAsStringAsync();


                            if (response.IsSuccessStatusCode)
                            {
                                var ajar = JsonConvert.DeserializeObject<List<Penelitian>>(apiResponse);

                                if (ajar != null)
                                {
                                    int noIncrementAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Max(a => (int?)a.no) ?? 0;


                                    foreach (Penelitian itemPenelitian in ajar)
                                    {
                                        await Task.Delay(200);

                                        url = baseUrl + "/pengabdian/" + itemPenelitian.id;
                                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                        response = await httpClient.GetAsync(url);
                                        apiResponse = await response.Content.ReadAsStringAsync();
                                        if (response.IsSuccessStatusCode)
                                        {
                                            var detail = JsonConvert.DeserializeObject<Penelitian_Detail>(apiResponse);

                                            TrPengabdian_DATA_SISTER entrydata = new TrPengabdian_DATA_SISTER();
                                            entrydata.id_penelitian_pengabdian = detail.id;
                                            entrydata.id_kategori_kegiatan = detail.id_kategori_kegiatan;

                                            entrydata.judul_penelitian_pengabdian = detail.judul;
                                            entrydata.durasi_kegiatan = detail.lama_kegiatan;
                                            entrydata.tahun_pelaksanaan_ke = detail.tahun_pelaksanaan_ke;
                                            entrydata.dana_dari_dikti = Convert.ToDecimal(detail.dana_dikti);
                                            entrydata.dana_dari_PT = Convert.ToDecimal(detail.dana_perguruan_tinggi);
                                            entrydata.dana_dari_instansi_lain = Convert.ToDecimal(detail.dana_institusi_lain);
                                            entrydata.in_kind = detail.in_kind;
                                            entrydata.no_sk_tugas = detail.sk_penugasan;
                                            entrydata.tanggal_sk_penugasan = Convert.ToDateTime(detail.tanggal_sk_penugasan).Date;
                                            entrydata.tempat_kegiatan = detail.lokasi;
                                            entrydata.id_jenis_skim = detail.id_jenis_skim;
                                            entrydata.jenis_skim = detail.jenis_skim;
                                            entrydata.tahun_usulan = detail.tahun_usulan;
                                            entrydata.tahun_kegiatan = detail.tahun_kegiatan;
                                            entrydata.tahun_pelaksanaan = detail.tahun_pelaksanaan;
                                            entrydata.id_litabmas_sebelumnya = detail.id_litabmas_sebelumnya;
                                            entrydata.litabmas_sebelumnya = detail.litabmas_sebelumnya;
                                            entrydata.id_afiliasi = detail.id_afiliasi;
                                            entrydata.afiliasi = detail.afiliasi;
                                            entrydata.id_kelompok_bidang = detail.id_kelompok_bidang;
                                            entrydata.nama_kelompok_bidang = detail.kelompok_bidang;
                                            entrydata.NPP1 = npp;

                                            if (_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == detail.id) &&
                                                    !masterList.Any(a => a.id_penelitian_pengabdian == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                                   // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);

                                            List<TblAnggota_DATA_SISTER> masterListAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
                                            List<TblAnggota_DATA_SISTER> compareListAnggota = new List<TblAnggota_DATA_SISTER>();

                                            if (detail.anggota != null && detail.anggota.Length > 0) // ============== Sinkron Penulis ================
                                            {
                                                foreach (Anggota itemAnggota in detail.anggota)
                                                {
                                                    TblAnggota_DATA_SISTER entryAnggota = new TblAnggota_DATA_SISTER();
                                                    entryAnggota.jenis = itemAnggota.jenis;
                                                    entryAnggota.nama = itemAnggota.nama;
                                                    entryAnggota.nipd = itemAnggota.nipd;
                                                    entryAnggota.peran = itemAnggota.peran;
                                                    entryAnggota.id_sdm = itemAnggota.id_sdm;
                                                    entryAnggota.id_orang = itemAnggota.id_orang;
                                                    entryAnggota.id_pd = itemAnggota.id_pd;
                                                    entryAnggota.stat_aktif = itemAnggota.stat_aktif == true ? 1 : 0;
                                                    entryAnggota.id_penelitian_pengabdian = detail.id;

                                                    compareListAnggota.Add(entryAnggota);

                                                }


                                                List<TblAnggota_DATA_SISTER> toBeAddedAnggota = new List<TblAnggota_DATA_SISTER>();
                                                List<TblAnggota_DATA_SISTER> toBeDeletedAnggota = new List<TblAnggota_DATA_SISTER>();
                                                List<TblAnggota_DATA_SISTER> toBeUpdatedAnggota = new List<TblAnggota_DATA_SISTER>();

                                                toBeAddedAnggota = compareListAnggota.Where(a => !masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                                foreach (var itemtobeaddedAnggota in toBeAddedAnggota)
                                                {
                                                    noIncrementAnggota++;
                                                    itemtobeaddedAnggota.no = noIncrementAnggota;
                                                }
                                                toBeDeletedAnggota = masterListAnggota.Where(a => !compareListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                                toBeUpdatedAnggota = compareListAnggota.Where(a => masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                                _DATA_SISTERcontext.TblAnggota_DATA_SISTER.AddRange(toBeAddedAnggota);
                                                _DATA_SISTERcontext.TblAnggota_DATA_SISTER.RemoveRange(toBeDeletedAnggota);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedAnggota)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblAnggota_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_penelitian_pengabdian == item.id_penelitian_pengabdian && a.id_sdm == item.id_sdm);

                                                    itemToUpdate = item;
                                                }
                                            }




                                            List<TblDokumen_DATA_SISTER> masterListDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Where(a => a.id_publikasi_atau_penelitian == detail.id).ToList();
                                            List<TblDokumen_DATA_SISTER> compareListDokumen = new List<TblDokumen_DATA_SISTER>();

                                            if (detail.dokumen != null && detail.dokumen.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Dokumen itemDokumen in detail.dokumen)
                                                {
                                                    TblDokumen_DATA_SISTER entryDokumen = new TblDokumen_DATA_SISTER();
                                                    entryDokumen.id_dokumen = itemDokumen.id;
                                                    entryDokumen.id_publikasi_atau_penelitian = detail.id;
                                                    entryDokumen.nama_dokumen = itemDokumen.nama;
                                                    entryDokumen.nama_file = itemDokumen.nama_file;
                                                    entryDokumen.jenis_file = itemDokumen.jenis_file;
                                                    entryDokumen.tanggal_upload = Convert.ToDateTime(itemDokumen.tanggal_upload);
                                                    //entryDokumen.nama_jenis_dokumen = itemDokumen.nama;
                                                    entryDokumen.tautan = itemDokumen.tautan;
                                                    entryDokumen.keterangan_dokumen = itemDokumen.keterangan;




                                                    compareListDokumen.Add(entryDokumen);

                                                }


                                                List<TblDokumen_DATA_SISTER> toBeAddedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeDeletedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeUpdatedDokumen = new List<TblDokumen_DATA_SISTER>();

                                                toBeAddedDokumen = compareListDokumen.Where(a => !masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                foreach (var itemtobeaddeddokumen in toBeAddedDokumen)
                                                {
                                                    noIncrementDokumen++;
                                                    itemtobeaddeddokumen.no = noIncrementDokumen;
                                                }
                                                toBeDeletedDokumen = masterListDokumen.Where(a => !compareListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();
                                                toBeUpdatedDokumen = compareListDokumen.Where(a => masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.AddRange(toBeAddedDokumen);
                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.RemoveRange(toBeDeletedDokumen);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedDokumen)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblDokumen_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_dokumen == item.id_dokumen);
                                                    itemToUpdate = item;
                                                }
                                            }



                                            List<TblMitra_Litabmas_DATA_SISTER> masterListMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
                                            List<TblMitra_Litabmas_DATA_SISTER> compareListMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

                                            if (detail.mitra_litabmas != null && detail.mitra_litabmas.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Mitra_Litabmas itemMitra in detail.mitra_litabmas)
                                                {
                                                    TblMitra_Litabmas_DATA_SISTER entryMitra = new TblMitra_Litabmas_DATA_SISTER();
                                                    entryMitra.id_penelitian_pengabdian = detail.id;
                                                    entryMitra.id = itemMitra.id;
                                                    entryMitra.nama = itemMitra.nama;

                                                    compareListMitra.Add(entryMitra);

                                                }


                                                List<TblMitra_Litabmas_DATA_SISTER> toBeAddedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
                                                List<TblMitra_Litabmas_DATA_SISTER> toBeDeletedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
                                                List<TblMitra_Litabmas_DATA_SISTER> toBeUpdatedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

                                                toBeAddedMitra = compareListMitra.Where(a => !masterListMitra.Any(b => a.id == b.id)).ToList();

                                                foreach (var itemtobeaddedMitra in toBeAddedMitra)
                                                {
                                                    noIncrementMitra++;
                                                    itemtobeaddedMitra.no = noIncrementMitra;
                                                }
                                                toBeDeletedMitra = masterListMitra.Where(a => !compareListMitra.Any(b => a.id == b.id)).ToList();
                                                toBeUpdatedMitra = compareListMitra.Where(a => masterListMitra.Any(b => a.id == b.id)).ToList();

                                                _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.AddRange(toBeAddedMitra);
                                                _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.RemoveRange(toBeDeletedMitra);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedMitra)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER
                                                        .FirstOrDefault(a => a.id == item.id);
                                                    itemToUpdate = item;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            TrPengabdian_DATA_SISTER entrydata = new TrPengabdian_DATA_SISTER();
                                            entrydata.id_penelitian_pengabdian = itemPenelitian.id;
                                            entrydata.judul_penelitian_pengabdian = itemPenelitian.judul;
                                            entrydata.tahun_pelaksanaan = itemPenelitian.tahun_pelaksanaan;
                                            entrydata.NPP1 = npp;

                                            if (_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id) &&
                                                    !masterList.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                                           // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == itemPenelitian.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);
                                        }

                                    }
                                    List<TrPengabdian_DATA_SISTER> toBeAdded = new List<TrPengabdian_DATA_SISTER>();
                                    List<TrPengabdian_DATA_SISTER> toBeDeleted = new List<TrPengabdian_DATA_SISTER>();
                                    List<TrPengabdian_DATA_SISTER> toBeUpdated = new List<TrPengabdian_DATA_SISTER>();

                                    toBeAdded = compareList.Where(a => !masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                    toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                    toBeUpdated = compareList.Where(a => masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                    _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.AddRange(toBeAdded);
                                    _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.RemoveRange(toBeDeleted);
                                    int counter = 0;
                                    foreach (var item in toBeUpdated)
                                    {
                                        counter++;
                                        var itemToUpdate = _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Find(item.id_penelitian_pengabdian);

                                        counter++;
                                        itemToUpdate.id_penelitian_pengabdian = item.id_penelitian_pengabdian;

                                        // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil

                                        itemToUpdate.id_kategori_kegiatan = item.id_kategori_kegiatan != null ? item.id_kategori_kegiatan : itemToUpdate.id_kategori_kegiatan;

                                        itemToUpdate.judul_penelitian_pengabdian = item.judul_penelitian_pengabdian != null ? item.judul_penelitian_pengabdian : itemToUpdate.judul_penelitian_pengabdian;
                                        itemToUpdate.durasi_kegiatan = item.durasi_kegiatan != null ? item.durasi_kegiatan : itemToUpdate.durasi_kegiatan;
                                        itemToUpdate.tahun_pelaksanaan_ke = item.tahun_pelaksanaan_ke != null ? item.tahun_pelaksanaan_ke : itemToUpdate.tahun_pelaksanaan_ke;
                                        itemToUpdate.dana_dari_dikti = item.dana_dari_dikti != null ? item.dana_dari_dikti : itemToUpdate.dana_dari_dikti;
                                        itemToUpdate.dana_dari_PT = item.dana_dari_PT != null ? item.dana_dari_PT : itemToUpdate.dana_dari_PT;
                                        itemToUpdate.dana_dari_instansi_lain = item.dana_dari_instansi_lain != null ? item.dana_dari_instansi_lain : itemToUpdate.dana_dari_instansi_lain;
                                        itemToUpdate.in_kind = item.in_kind != null ? item.in_kind : itemToUpdate.in_kind;
                                        itemToUpdate.no_sk_tugas = item.no_sk_tugas != null ? item.no_sk_tugas : itemToUpdate.no_sk_tugas;
                                        itemToUpdate.tanggal_sk_penugasan = item.tanggal_sk_penugasan != null ? item.tanggal_sk_penugasan : itemToUpdate.tanggal_sk_penugasan;
                                        itemToUpdate.tempat_kegiatan = item.tempat_kegiatan != null ? item.tempat_kegiatan : itemToUpdate.tempat_kegiatan;
                                        itemToUpdate.id_jenis_skim = item.id_jenis_skim != null ? item.id_jenis_skim : itemToUpdate.id_jenis_skim;
                                        itemToUpdate.jenis_skim = item.jenis_skim != null ? item.jenis_skim : itemToUpdate.jenis_skim;
                                        itemToUpdate.tahun_usulan = item.tahun_usulan != null ? item.tahun_usulan : itemToUpdate.tahun_usulan;
                                        itemToUpdate.tahun_kegiatan = item.tahun_kegiatan != null ? item.tahun_kegiatan : itemToUpdate.tahun_kegiatan;
                                        itemToUpdate.tahun_pelaksanaan = item.tahun_pelaksanaan != null ? item.tahun_pelaksanaan : itemToUpdate.tahun_pelaksanaan;
                                        itemToUpdate.litabmas_sebelumnya = item.litabmas_sebelumnya != null ? item.litabmas_sebelumnya : itemToUpdate.litabmas_sebelumnya;
                                        itemToUpdate.id_afiliasi = item.id_afiliasi != null ? item.id_afiliasi : itemToUpdate.id_afiliasi;
                                        itemToUpdate.afiliasi = item.afiliasi != null ? item.afiliasi : itemToUpdate.afiliasi;
                                        itemToUpdate.id_kelompok_bidang = item.id_kelompok_bidang != null ? item.id_kelompok_bidang : itemToUpdate.id_kelompok_bidang;
                                        itemToUpdate.nama_kelompok_bidang = item.nama_kelompok_bidang != null ? item.nama_kelompok_bidang : itemToUpdate.nama_kelompok_bidang;
                                        if (itemToUpdate.NPP1 == null) // cek apakah kosong
                                            itemToUpdate.NPP1 = item.NPP1;
                                        else if (itemToUpdate.NPP2 == null && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP2 = item.NPP1;
                                        else if (itemToUpdate.NPP3 == null && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP3 = item.NPP1;
                                        else if (itemToUpdate.NPP4 == null && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP4 = item.NPP1;
                                        else if (itemToUpdate.NPP5 == null && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP5 = item.NPP1;
                                        else if (itemToUpdate.NPP6 == null && item.NPP1 != itemToUpdate.NPP5 && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP6 = item.NPP1;
                                    }

                                    await _DATA_SISTERcontext.SaveChangesAsync();
                                }

                            }

                            }
                            else
                            {

                                var ajar = JsonConvert.DeserializeObject<Penelitian>(apiResponse);
                                return Json(new { success = false, nama = "", message = ajar.detail });
                            }


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
            return Json(new { success = true, message = "Sinkronisasi Pengabdian Berhasil" });


        }

        public async Task<IActionResult> SinkronDataPengajaranProdiSISTER(string id_semester)
        {
            var id_unit = _context.MstUnit.AsNoTracking().FirstOrDefault(a => a.NamaUnit == "Program Studi Informatika").IdUnit;
           

            var listNPP = _context.MstKaryawan.AsNoTracking().Where(a => a.IdUnitAkademik == id_unit).ToList();

            var nppstring = "";

            foreach (var dataNpp in listNPP)
            {
                string idDosen = null;
                string npp = dataNpp.Npp;
                // id_semester = "20191"; // 2020/2021 Ganjil
                                              //string npp = "02.11.817"; 
                                              //string npp = "03.17.953";
                List<TrPengajaran_Data_SISTER> masterList = new List<TrPengajaran_Data_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

                List<TrPengajaran_Data_SISTER> compareList = new List<TrPengajaran_Data_SISTER>();

                if (HttpContext.Session.GetString("NPP") != null)
                {
                    if(id_semester != null)
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
                                var url = baseUrl + "/authorize";
                                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                                var response = await httpClient.PostAsync(url, data);
                                string apiResponse = await response.Content.ReadAsStringAsync();

                                Console.WriteLine("test");
                                TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                                PenelitianReq request = new PenelitianReq();
                                idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                                idDosen = idDosen != null ? idDosen.Trim() : null;
                                if (!String.IsNullOrEmpty(idDosen) && idDosen.Length == 36)
                                {
                                    url = baseUrl + "/pengajaran?id_sdm=" + idDosen + "&id_semester=" + id_semester;
                                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                    response = await httpClient.GetAsync(url);
                                    apiResponse = await response.Content.ReadAsStringAsync();


                                    if (response.IsSuccessStatusCode)
                                    {
                                        var ajar = JsonConvert.DeserializeObject<List<Pengajaran>>(apiResponse);

                                        if (ajar != null && idDosen != null)
                                        {

                                            foreach (Pengajaran itemPengajaran in ajar)
                                            {

                                                url = baseUrl + "/pengajaran/" + itemPengajaran.id;
                                                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                                //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                                response = await httpClient.GetAsync(url);
                                                apiResponse = await response.Content.ReadAsStringAsync();
                                                if (response.IsSuccessStatusCode)
                                                {
                                                    var detail = JsonConvert.DeserializeObject<Pengajaran_detail>(apiResponse);

                                                    TrPengajaran_Data_SISTER entrydata = new TrPengajaran_Data_SISTER();
                                                    entrydata.id = detail.id;
                                                    entrydata.semester = detail.semester;
                                                    entrydata.mata_kuliah = detail.mata_kuliah;
                                                    entrydata.kelas = detail.kelas;
                                                    entrydata.sks = detail.sks;
                                                    entrydata.id_semester = detail.id_semester;
                                                    entrydata.sks_tatap_muka = detail.sks_tatap_muka;
                                                    entrydata.sks_praktik = detail.sks_praktik;
                                                    entrydata.sks_praktik_lapangan = detail.sks_praktik_lapangan;
                                                    entrydata.sks_simulasi = detail.sks_simulasi;
                                                    entrydata.tatap_muka_rencana = detail.tatap_muka_rencana;
                                                    entrydata.tatap_muka_realisasi = detail.tatap_muka_realisasi;
                                                    entrydata.jumlah_mahasiswa = detail.jumlah_mahasiswa;
                                                    entrydata.jenis_evaluasi = detail.jenis_evaluasi;
                                                    entrydata.nama_substansi = detail.nama_substansi;
                                                    entrydata.NPP = npp;


                                                    if (_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Any(a => a.id == detail.id) &&
                                                        !masterList.Any(a => a.id == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                 // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                                    {
                                                        masterList.Add(_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                        compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                                    }
                                                    else
                                                        compareList.Add(entrydata);


                                                }
                                                else
                                                {


                                                    TrPengajaran_Data_SISTER entrydata = new TrPengajaran_Data_SISTER();
                                                    entrydata.id = itemPengajaran.id;
                                                    entrydata.mata_kuliah = itemPengajaran.mata_kuliah;
                                                    entrydata.kelas = itemPengajaran.kelas;
                                                    entrydata.semester = itemPengajaran.semester;
                                                    entrydata.sks = itemPengajaran.sks;
                                                    entrydata.NPP = npp;
                                                    if (_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Any(a => a.id == itemPengajaran.id) &&
                                                        !masterList.Any(a => a.id == itemPengajaran.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                         // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                                    {
                                                        masterList.Add(_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == itemPengajaran.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                        compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                                    }
                                                    else
                                                        compareList.Add(entrydata);
                                                }


                                            }
                                            List<TrPengajaran_Data_SISTER> toBeAdded = new List<TrPengajaran_Data_SISTER>();
                                            List<TrPengajaran_Data_SISTER> toBeDeleted = new List<TrPengajaran_Data_SISTER>();
                                            List<TrPengajaran_Data_SISTER> toBeUpdated = new List<TrPengajaran_Data_SISTER>();

                                            toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                            toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                            toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                            _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.AddRange(toBeAdded);
                                            _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.RemoveRange(toBeDeleted);
                                            int counter = 0;
                                            foreach (var item in toBeUpdated)
                                            {
                                                counter++;
                                                var itemToUpdate = _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Find(item.id);

                                                itemToUpdate.id = item.id;

                                                // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil

                                                itemToUpdate.semester = item.semester != null ? item.semester : itemToUpdate.semester;

                                                itemToUpdate.mata_kuliah = item.mata_kuliah != null ? item.mata_kuliah : itemToUpdate.mata_kuliah;
                                                itemToUpdate.kelas = item.kelas != null ? item.kelas : itemToUpdate.kelas;
                                                itemToUpdate.sks = item.sks != null ? item.sks : itemToUpdate.sks;
                                                itemToUpdate.id_semester = item.id_semester != null ? item.id_semester : itemToUpdate.id_semester;
                                                itemToUpdate.sks_tatap_muka = item.sks_tatap_muka != null ? item.sks_tatap_muka : itemToUpdate.sks_tatap_muka;
                                                itemToUpdate.sks_praktik = item.sks_praktik != null ? item.sks_praktik : itemToUpdate.sks_praktik;
                                                itemToUpdate.sks_praktik_lapangan = item.sks_praktik_lapangan != null ? item.sks_praktik_lapangan : itemToUpdate.sks_praktik_lapangan;
                                                itemToUpdate.sks_simulasi = item.sks_simulasi != null ? item.sks_simulasi : itemToUpdate.sks_simulasi;
                                                itemToUpdate.tatap_muka_rencana = item.tatap_muka_rencana != null ? item.tatap_muka_rencana : itemToUpdate.tatap_muka_rencana;
                                                itemToUpdate.tatap_muka_realisasi = item.tatap_muka_realisasi != null ? item.tatap_muka_realisasi : itemToUpdate.tatap_muka_realisasi;
                                                itemToUpdate.jumlah_mahasiswa = item.jumlah_mahasiswa != null ? item.jumlah_mahasiswa : itemToUpdate.jumlah_mahasiswa;
                                                itemToUpdate.jenis_evaluasi = item.jenis_evaluasi != null ? item.jenis_evaluasi : itemToUpdate.jenis_evaluasi;
                                                itemToUpdate.nama_substansi = item.nama_substansi != null ? item.nama_substansi : itemToUpdate.nama_substansi;
                                                itemToUpdate.NPP = item.NPP != null ? item.NPP : itemToUpdate.NPP;

                                            }

                                            await _DATA_SISTERcontext.SaveChangesAsync();
                                            await Task.Delay(3000);
                                        }

                                    }
                                }
                                

                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                    else
                    {
                        return Json(new { success = false, message = "Semester harap dipilih" });
                    }
                }
                else
                {
                    TempData["Message"] = "Sesi Berakhir.";
                    return RedirectToAction("Index", "Home");
                }
            }
            return Json(new { success = true, message = "Sinkronisasi Pengajaran Berhasil" });

        }

        public JsonResult getListNppByProdi(int id_unit)
        {

            var listNPP = _context.MstKaryawan.AsNoTracking().Where(a => a.IdUnitAkademik == id_unit).ToList();

            if (listNPP != null)
            {
                return Json(new
                {
                    data = listNPP,
                    success = true
                });
            }
            else
            {
                return Json(new
                {

                    success = false
                });
            }


        }

        public async Task<IActionResult> SinkronDataPenelitianSISTERbyNPP(string npp)
        {
            string idDosen = null;
            string namaDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).Nama;

            //string npp = HttpContext.Session.GetString("NPP");
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<TrPenelitian_DATA_SISTER> masterList = new List<TrPenelitian_DATA_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<TrPenelitian_DATA_SISTER> compareList = new List<TrPenelitian_DATA_SISTER>();

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        PenelitianReq request = new PenelitianReq();
                        idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                        idDosen = idDosen != null ? idDosen.Trim() : null;
                        if (!String.IsNullOrEmpty(idDosen) && idDosen.Length == 36)

                        {
                            url = baseUrl + "/penelitian?id_sdm=" + idDosen;
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                            response = await httpClient.GetAsync(url);
                            apiResponse = await response.Content.ReadAsStringAsync();

                            if (response.IsSuccessStatusCode)
                            {
                                var ajar = JsonConvert.DeserializeObject<List<Penelitian>>(apiResponse);

                                Penelitian_detail_req request_detail = new Penelitian_detail_req();

                                if (ajar != null && idDosen != null)
                                {
                                    int noIncrementAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Max(a => (int?)a.no) ?? 0;


                                    foreach (Penelitian itemPenelitian in ajar)
                                    {
                                        url = baseUrl + "/penelitian/" + itemPenelitian.id;
                                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                        response = await httpClient.GetAsync(url);
                                        apiResponse = await response.Content.ReadAsStringAsync();
                                        if (response.IsSuccessStatusCode)
                                        {
                                            var detail = JsonConvert.DeserializeObject<Penelitian_Detail>(apiResponse);

                                            TrPenelitian_DATA_SISTER entrydata = new TrPenelitian_DATA_SISTER();
                                            entrydata.id_penelitian_pengabdian = detail.id;
                                            entrydata.id_kategori_kegiatan = detail.id_kategori_kegiatan;

                                            entrydata.judul_penelitian_pengabdian = detail.judul;
                                            entrydata.durasi_kegiatan = detail.lama_kegiatan;
                                            entrydata.tahun_pelaksanaan_ke = detail.tahun_pelaksanaan_ke;
                                            entrydata.dana_dari_dikti = Convert.ToDecimal(detail.dana_dikti);
                                            entrydata.dana_dari_PT = Convert.ToDecimal(detail.dana_perguruan_tinggi);
                                            entrydata.dana_dari_instansi_lain = Convert.ToDecimal(detail.dana_institusi_lain);
                                            entrydata.in_kind = detail.in_kind;
                                            entrydata.no_sk_tugas = detail.sk_penugasan;
                                            entrydata.tanggal_sk_penugasan = Convert.ToDateTime(detail.tanggal_sk_penugasan).Date;
                                            entrydata.tempat_kegiatan = detail.lokasi;
                                            entrydata.id_jenis_skim = detail.id_jenis_skim;
                                            entrydata.jenis_skim = detail.jenis_skim;
                                            entrydata.tahun_usulan = detail.tahun_usulan;
                                            entrydata.tahun_kegiatan = detail.tahun_kegiatan;
                                            entrydata.tahun_pelaksanaan = detail.tahun_pelaksanaan;
                                            entrydata.id_litabmas_sebelumnya = detail.id_litabmas_sebelumnya;
                                            entrydata.litabmas_sebelumnya = detail.litabmas_sebelumnya;
                                            entrydata.id_afiliasi = detail.id_afiliasi;
                                            entrydata.afiliasi = detail.afiliasi;
                                            entrydata.id_kelompok_bidang = detail.id_kelompok_bidang;
                                            entrydata.nama_kelompok_bidang = detail.kelompok_bidang;
                                            entrydata.NPP1 = npp;





                                            if (_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == detail.id) &&
                                                    !masterList.Any(a => a.id_penelitian_pengabdian == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                                   // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);

                                            List<TblAnggota_DATA_SISTER> masterListAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
                                            List<TblAnggota_DATA_SISTER> compareListAnggota = new List<TblAnggota_DATA_SISTER>();

                                            if (detail.anggota != null && detail.anggota.Length > 0) // ============== Sinkron Penulis ================
                                            {
                                                foreach (Anggota itemAnggota in detail.anggota)
                                                {
                                                    TblAnggota_DATA_SISTER entryAnggota = new TblAnggota_DATA_SISTER();
                                                    entryAnggota.jenis = itemAnggota.jenis;
                                                    entryAnggota.nama = itemAnggota.nama;
                                                    entryAnggota.nipd = itemAnggota.nipd;
                                                    entryAnggota.peran = itemAnggota.peran;
                                                    entryAnggota.id_sdm = itemAnggota.id_sdm;
                                                    entryAnggota.id_orang = itemAnggota.id_orang;
                                                    entryAnggota.id_pd = itemAnggota.id_pd;
                                                    entryAnggota.stat_aktif = itemAnggota.stat_aktif == true ? 1 : 0;
                                                    entryAnggota.id_penelitian_pengabdian = detail.id;

                                                    compareListAnggota.Add(entryAnggota);

                                                }


                                                List<TblAnggota_DATA_SISTER> toBeAddedAnggota = new List<TblAnggota_DATA_SISTER>();
                                                List<TblAnggota_DATA_SISTER> toBeDeletedAnggota = new List<TblAnggota_DATA_SISTER>();
                                                List<TblAnggota_DATA_SISTER> toBeUpdatedAnggota = new List<TblAnggota_DATA_SISTER>();

                                                toBeAddedAnggota = compareListAnggota.Where(a => !masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                                foreach (var itemtobeaddedAnggota in toBeAddedAnggota)
                                                {
                                                    noIncrementAnggota++;
                                                    itemtobeaddedAnggota.no = noIncrementAnggota;
                                                }
                                                toBeDeletedAnggota = masterListAnggota.Where(a => !compareListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                                toBeUpdatedAnggota = compareListAnggota.Where(a => masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                                _DATA_SISTERcontext.TblAnggota_DATA_SISTER.AddRange(toBeAddedAnggota);
                                                _DATA_SISTERcontext.TblAnggota_DATA_SISTER.RemoveRange(toBeDeletedAnggota);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedAnggota)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblAnggota_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_penelitian_pengabdian == item.id_penelitian_pengabdian && a.id_sdm == item.id_sdm);

                                                    itemToUpdate = item;
                                                }
                                            }




                                            List<TblDokumen_DATA_SISTER> masterListDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Where(a => a.id_publikasi_atau_penelitian == detail.id).ToList();
                                            List<TblDokumen_DATA_SISTER> compareListDokumen = new List<TblDokumen_DATA_SISTER>();

                                            if (detail.dokumen != null && detail.dokumen.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Dokumen itemDokumen in detail.dokumen)
                                                {
                                                    TblDokumen_DATA_SISTER entryDokumen = new TblDokumen_DATA_SISTER();
                                                    entryDokumen.id_dokumen = itemDokumen.id;
                                                    entryDokumen.id_publikasi_atau_penelitian = detail.id;
                                                    entryDokumen.nama_dokumen = itemDokumen.nama;
                                                    entryDokumen.nama_file = itemDokumen.nama_file;
                                                    entryDokumen.jenis_file = itemDokumen.jenis_file;
                                                    entryDokumen.tanggal_upload = Convert.ToDateTime(itemDokumen.tanggal_upload);
                                                    //entryDokumen.nama_jenis_dokumen = itemDokumen.nama;
                                                    entryDokumen.tautan = itemDokumen.tautan;
                                                    entryDokumen.keterangan_dokumen = itemDokumen.keterangan;




                                                    compareListDokumen.Add(entryDokumen);

                                                }


                                                List<TblDokumen_DATA_SISTER> toBeAddedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeDeletedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeUpdatedDokumen = new List<TblDokumen_DATA_SISTER>();

                                                toBeAddedDokumen = compareListDokumen.Where(a => !masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                foreach (var itemtobeaddeddokumen in toBeAddedDokumen)
                                                {
                                                    noIncrementDokumen++;
                                                    itemtobeaddeddokumen.no = noIncrementDokumen;
                                                }
                                                toBeDeletedDokumen = masterListDokumen.Where(a => !compareListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();
                                                toBeUpdatedDokumen = compareListDokumen.Where(a => masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.AddRange(toBeAddedDokumen);
                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.RemoveRange(toBeDeletedDokumen);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedDokumen)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblDokumen_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_dokumen == item.id_dokumen);
                                                    itemToUpdate = item;
                                                }
                                            }



                                            List<TblMitra_Litabmas_DATA_SISTER> masterListMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
                                            List<TblMitra_Litabmas_DATA_SISTER> compareListMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

                                            if (detail.mitra_litabmas != null && detail.mitra_litabmas.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Mitra_Litabmas itemMitra in detail.mitra_litabmas)
                                                {
                                                    TblMitra_Litabmas_DATA_SISTER entryMitra = new TblMitra_Litabmas_DATA_SISTER();
                                                    entryMitra.id_penelitian_pengabdian = detail.id;
                                                    entryMitra.id = itemMitra.id;
                                                    entryMitra.nama = itemMitra.nama;

                                                    compareListMitra.Add(entryMitra);

                                                }


                                                List<TblMitra_Litabmas_DATA_SISTER> toBeAddedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
                                                List<TblMitra_Litabmas_DATA_SISTER> toBeDeletedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
                                                List<TblMitra_Litabmas_DATA_SISTER> toBeUpdatedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

                                                toBeAddedMitra = compareListMitra.Where(a => !masterListMitra.Any(b => a.id == b.id)).ToList();

                                                foreach (var itemtobeaddedMitra in toBeAddedMitra)
                                                {
                                                    noIncrementMitra++;
                                                    itemtobeaddedMitra.no = noIncrementMitra;
                                                }
                                                toBeDeletedMitra = masterListMitra.Where(a => !compareListMitra.Any(b => a.id == b.id)).ToList();
                                                toBeUpdatedMitra = compareListMitra.Where(a => masterListMitra.Any(b => a.id == b.id)).ToList();

                                                _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.AddRange(toBeAddedMitra);
                                                _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.RemoveRange(toBeDeletedMitra);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedMitra)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER
                                                        .FirstOrDefault(a => a.id == item.id);
                                                    itemToUpdate = item;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            TrPenelitian_DATA_SISTER entrydata = new TrPenelitian_DATA_SISTER();
                                            entrydata.id_penelitian_pengabdian = itemPenelitian.id;
                                            entrydata.judul_penelitian_pengabdian = itemPenelitian.judul;
                                            entrydata.tahun_pelaksanaan = itemPenelitian.tahun_pelaksanaan;

                                            if (_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id) &&
                                                    !masterList.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                                           // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == itemPenelitian.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);
                                        }


                                    }
                                    List<TrPenelitian_DATA_SISTER> toBeAdded = new List<TrPenelitian_DATA_SISTER>();
                                    List<TrPenelitian_DATA_SISTER> toBeDeleted = new List<TrPenelitian_DATA_SISTER>();
                                    List<TrPenelitian_DATA_SISTER> toBeUpdated = new List<TrPenelitian_DATA_SISTER>();

                                    toBeAdded = compareList.Where(a => !masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                    toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                    toBeUpdated = compareList.Where(a => masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                    _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AddRange(toBeAdded);
                                    _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.RemoveRange(toBeDeleted);
                                    int counter = 0;
                                    foreach (var item in toBeUpdated)
                                    {
                                        counter++;
                                        var itemToUpdate = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Find(item.id_penelitian_pengabdian);

                                        itemToUpdate.id_penelitian_pengabdian = item.id_penelitian_pengabdian;

                                        // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil

                                        itemToUpdate.id_kategori_kegiatan = item.id_kategori_kegiatan != null ? item.id_kategori_kegiatan : itemToUpdate.id_kategori_kegiatan;

                                        itemToUpdate.judul_penelitian_pengabdian = item.judul_penelitian_pengabdian != null ? item.judul_penelitian_pengabdian : itemToUpdate.judul_penelitian_pengabdian;
                                        itemToUpdate.durasi_kegiatan = item.durasi_kegiatan != null ? item.durasi_kegiatan : itemToUpdate.durasi_kegiatan;
                                        itemToUpdate.tahun_pelaksanaan_ke = item.tahun_pelaksanaan_ke != null ? item.tahun_pelaksanaan_ke : itemToUpdate.tahun_pelaksanaan_ke;
                                        itemToUpdate.dana_dari_dikti = item.dana_dari_dikti != null ? item.dana_dari_dikti : itemToUpdate.dana_dari_dikti;
                                        itemToUpdate.dana_dari_PT = item.dana_dari_PT != null ? item.dana_dari_PT : itemToUpdate.dana_dari_PT;
                                        itemToUpdate.dana_dari_instansi_lain = item.dana_dari_instansi_lain != null ? item.dana_dari_instansi_lain : itemToUpdate.dana_dari_instansi_lain;
                                        itemToUpdate.in_kind = item.in_kind != null ? item.in_kind : itemToUpdate.in_kind;
                                        itemToUpdate.no_sk_tugas = item.no_sk_tugas != null ? item.no_sk_tugas : itemToUpdate.no_sk_tugas;
                                        itemToUpdate.tanggal_sk_penugasan = item.tanggal_sk_penugasan != null ? item.tanggal_sk_penugasan : itemToUpdate.tanggal_sk_penugasan;
                                        itemToUpdate.tempat_kegiatan = item.tempat_kegiatan != null ? item.tempat_kegiatan : itemToUpdate.tempat_kegiatan;
                                        itemToUpdate.id_jenis_skim = item.id_jenis_skim != null ? item.id_jenis_skim : itemToUpdate.id_jenis_skim;
                                        itemToUpdate.jenis_skim = item.jenis_skim != null ? item.jenis_skim : itemToUpdate.jenis_skim;
                                        itemToUpdate.tahun_usulan = item.tahun_usulan != null ? item.tahun_usulan : itemToUpdate.tahun_usulan;
                                        itemToUpdate.tahun_kegiatan = item.tahun_kegiatan != null ? item.tahun_kegiatan : itemToUpdate.tahun_kegiatan;
                                        itemToUpdate.tahun_pelaksanaan = item.tahun_pelaksanaan != null ? item.tahun_pelaksanaan : itemToUpdate.tahun_pelaksanaan;
                                        itemToUpdate.litabmas_sebelumnya = item.litabmas_sebelumnya != null ? item.litabmas_sebelumnya : itemToUpdate.litabmas_sebelumnya;
                                        itemToUpdate.id_afiliasi = item.id_afiliasi != null ? item.id_afiliasi : itemToUpdate.id_afiliasi;
                                        itemToUpdate.afiliasi = item.afiliasi != null ? item.afiliasi : itemToUpdate.afiliasi;
                                        itemToUpdate.id_kelompok_bidang = item.id_kelompok_bidang != null ? item.id_kelompok_bidang : itemToUpdate.id_kelompok_bidang;
                                        itemToUpdate.nama_kelompok_bidang = item.nama_kelompok_bidang != null ? item.nama_kelompok_bidang : itemToUpdate.nama_kelompok_bidang;
                                        if (itemToUpdate.NPP1 == null) // cek apakah kosong
                                            itemToUpdate.NPP1 = item.NPP1;
                                        else if (itemToUpdate.NPP2 == null && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP2 = item.NPP1;
                                        else if (itemToUpdate.NPP3 == null && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP3 = item.NPP1;
                                        else if (itemToUpdate.NPP4 == null && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP4 = item.NPP1;
                                        else if (itemToUpdate.NPP5 == null && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP5 = item.NPP1;
                                        else if (itemToUpdate.NPP6 == null && item.NPP1 != itemToUpdate.NPP5 && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP6 = item.NPP1;
                                    }

                                    await _DATA_SISTERcontext.SaveChangesAsync();

                                }
                                

                                return Json(new { success = true, nama = namaDosen });
                            }
                            else
                            {

                                var ajar = JsonConvert.DeserializeObject<Penelitian>(apiResponse);
                                return Json(new { success = false, nama = namaDosen, message = ajar.detail });
                            }

                            //return Json(new { success = true, message = "Sinkronisasi Penelitian sukses." });
                            
                        }
                        else
                        {
                            return Json(new { success = false, nama = namaDosen, message = "ID Dosen Sister tidak ditemukan." });
                        }


                    }
                    catch (Exception e)
                    {
                        return Json(new { error = true, message = e.Message, nama = namaDosen, npp = npp });

                    }
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> SinkronDataPengabdianProdiSISTERbyNPP(string npp)
        {
            string namaDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).Nama;


            var nppstring = "";

            
            string idDosen = null;
            
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<TrPengabdian_DATA_SISTER> masterList = new List<TrPengabdian_DATA_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<TrPengabdian_DATA_SISTER> compareList = new List<TrPengabdian_DATA_SISTER>();

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        PenelitianReq request = new PenelitianReq();
                        idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                        idDosen = idDosen != null ? idDosen.Trim() : null;
                        if (!String.IsNullOrEmpty(idDosen) && idDosen.Length == 36)
                        {
                            url = baseUrl + "/pengabdian?id_sdm=" + idDosen;
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                            response = await httpClient.GetAsync(url);
                            apiResponse = await response.Content.ReadAsStringAsync();


                            if (response.IsSuccessStatusCode)
                            {
                                var ajar = JsonConvert.DeserializeObject<List<Penelitian>>(apiResponse);

                                if (ajar != null)
                                {
                                    int noIncrementAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Max(a => (int?)a.no) ?? 0;


                                    foreach (Penelitian itemPenelitian in ajar)
                                    {
                                        await Task.Delay(200);

                                        url = baseUrl + "/pengabdian/" + itemPenelitian.id;
                                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                        response = await httpClient.GetAsync(url);
                                        apiResponse = await response.Content.ReadAsStringAsync();
                                        if (response.IsSuccessStatusCode)
                                        {
                                            var detail = JsonConvert.DeserializeObject<Penelitian_Detail>(apiResponse);

                                            TrPengabdian_DATA_SISTER entrydata = new TrPengabdian_DATA_SISTER();
                                            entrydata.id_penelitian_pengabdian = detail.id;
                                            entrydata.id_kategori_kegiatan = detail.id_kategori_kegiatan;

                                            entrydata.judul_penelitian_pengabdian = detail.judul;
                                            entrydata.durasi_kegiatan = detail.lama_kegiatan;
                                            entrydata.tahun_pelaksanaan_ke = detail.tahun_pelaksanaan_ke;
                                            entrydata.dana_dari_dikti = Convert.ToDecimal(detail.dana_dikti);
                                            entrydata.dana_dari_PT = Convert.ToDecimal(detail.dana_perguruan_tinggi);
                                            entrydata.dana_dari_instansi_lain = Convert.ToDecimal(detail.dana_institusi_lain);
                                            entrydata.in_kind = detail.in_kind;
                                            entrydata.no_sk_tugas = detail.sk_penugasan;
                                            entrydata.tanggal_sk_penugasan = Convert.ToDateTime(detail.tanggal_sk_penugasan).Date;
                                            entrydata.tempat_kegiatan = detail.lokasi;
                                            entrydata.id_jenis_skim = detail.id_jenis_skim;
                                            entrydata.jenis_skim = detail.jenis_skim;
                                            entrydata.tahun_usulan = detail.tahun_usulan;
                                            entrydata.tahun_kegiatan = detail.tahun_kegiatan;
                                            entrydata.tahun_pelaksanaan = detail.tahun_pelaksanaan;
                                            entrydata.id_litabmas_sebelumnya = detail.id_litabmas_sebelumnya;
                                            entrydata.litabmas_sebelumnya = detail.litabmas_sebelumnya;
                                            entrydata.id_afiliasi = detail.id_afiliasi;
                                            entrydata.afiliasi = detail.afiliasi;
                                            entrydata.id_kelompok_bidang = detail.id_kelompok_bidang;
                                            entrydata.nama_kelompok_bidang = detail.kelompok_bidang;
                                            entrydata.NPP1 = npp;

                                            if (_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == detail.id) &&
                                                    !masterList.Any(a => a.id_penelitian_pengabdian == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                                    // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);

                                            List<TblAnggota_DATA_SISTER> masterListAnggota = _DATA_SISTERcontext.TblAnggota_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
                                            List<TblAnggota_DATA_SISTER> compareListAnggota = new List<TblAnggota_DATA_SISTER>();

                                            if (detail.anggota != null && detail.anggota.Length > 0) // ============== Sinkron Penulis ================
                                            {
                                                foreach (Anggota itemAnggota in detail.anggota)
                                                {
                                                    TblAnggota_DATA_SISTER entryAnggota = new TblAnggota_DATA_SISTER();
                                                    entryAnggota.jenis = itemAnggota.jenis;
                                                    entryAnggota.nama = itemAnggota.nama;
                                                    entryAnggota.nipd = itemAnggota.nipd;
                                                    entryAnggota.peran = itemAnggota.peran;
                                                    entryAnggota.id_sdm = itemAnggota.id_sdm;
                                                    entryAnggota.id_orang = itemAnggota.id_orang;
                                                    entryAnggota.id_pd = itemAnggota.id_pd;
                                                    entryAnggota.stat_aktif = itemAnggota.stat_aktif == true ? 1 : 0;
                                                    entryAnggota.id_penelitian_pengabdian = detail.id;

                                                    compareListAnggota.Add(entryAnggota);

                                                }


                                                List<TblAnggota_DATA_SISTER> toBeAddedAnggota = new List<TblAnggota_DATA_SISTER>();
                                                List<TblAnggota_DATA_SISTER> toBeDeletedAnggota = new List<TblAnggota_DATA_SISTER>();
                                                List<TblAnggota_DATA_SISTER> toBeUpdatedAnggota = new List<TblAnggota_DATA_SISTER>();

                                                toBeAddedAnggota = compareListAnggota.Where(a => !masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                                foreach (var itemtobeaddedAnggota in toBeAddedAnggota)
                                                {
                                                    noIncrementAnggota++;
                                                    itemtobeaddedAnggota.no = noIncrementAnggota;
                                                }
                                                toBeDeletedAnggota = masterListAnggota.Where(a => !compareListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                                toBeUpdatedAnggota = compareListAnggota.Where(a => masterListAnggota.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                                _DATA_SISTERcontext.TblAnggota_DATA_SISTER.AddRange(toBeAddedAnggota);
                                                _DATA_SISTERcontext.TblAnggota_DATA_SISTER.RemoveRange(toBeDeletedAnggota);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedAnggota)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblAnggota_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_penelitian_pengabdian == item.id_penelitian_pengabdian && a.id_sdm == item.id_sdm);

                                                    itemToUpdate = item;
                                                }
                                            }




                                            List<TblDokumen_DATA_SISTER> masterListDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Where(a => a.id_publikasi_atau_penelitian == detail.id).ToList();
                                            List<TblDokumen_DATA_SISTER> compareListDokumen = new List<TblDokumen_DATA_SISTER>();

                                            if (detail.dokumen != null && detail.dokumen.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Dokumen itemDokumen in detail.dokumen)
                                                {
                                                    TblDokumen_DATA_SISTER entryDokumen = new TblDokumen_DATA_SISTER();
                                                    entryDokumen.id_dokumen = itemDokumen.id;
                                                    entryDokumen.id_publikasi_atau_penelitian = detail.id;
                                                    entryDokumen.nama_dokumen = itemDokumen.nama;
                                                    entryDokumen.nama_file = itemDokumen.nama_file;
                                                    entryDokumen.jenis_file = itemDokumen.jenis_file;
                                                    entryDokumen.tanggal_upload = Convert.ToDateTime(itemDokumen.tanggal_upload);
                                                    //entryDokumen.nama_jenis_dokumen = itemDokumen.nama;
                                                    entryDokumen.tautan = itemDokumen.tautan;
                                                    entryDokumen.keterangan_dokumen = itemDokumen.keterangan;




                                                    compareListDokumen.Add(entryDokumen);

                                                }


                                                List<TblDokumen_DATA_SISTER> toBeAddedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeDeletedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeUpdatedDokumen = new List<TblDokumen_DATA_SISTER>();

                                                toBeAddedDokumen = compareListDokumen.Where(a => !masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                foreach (var itemtobeaddeddokumen in toBeAddedDokumen)
                                                {
                                                    noIncrementDokumen++;
                                                    itemtobeaddeddokumen.no = noIncrementDokumen;
                                                }
                                                toBeDeletedDokumen = masterListDokumen.Where(a => !compareListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();
                                                toBeUpdatedDokumen = compareListDokumen.Where(a => masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.AddRange(toBeAddedDokumen);
                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.RemoveRange(toBeDeletedDokumen);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedDokumen)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblDokumen_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_dokumen == item.id_dokumen);
                                                    itemToUpdate = item;
                                                }
                                            }



                                            List<TblMitra_Litabmas_DATA_SISTER> masterListMitra = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.Where(a => a.id_penelitian_pengabdian == detail.id).ToList();
                                            List<TblMitra_Litabmas_DATA_SISTER> compareListMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

                                            if (detail.mitra_litabmas != null && detail.mitra_litabmas.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Mitra_Litabmas itemMitra in detail.mitra_litabmas)
                                                {
                                                    TblMitra_Litabmas_DATA_SISTER entryMitra = new TblMitra_Litabmas_DATA_SISTER();
                                                    entryMitra.id_penelitian_pengabdian = detail.id;
                                                    entryMitra.id = itemMitra.id;
                                                    entryMitra.nama = itemMitra.nama;

                                                    compareListMitra.Add(entryMitra);

                                                }


                                                List<TblMitra_Litabmas_DATA_SISTER> toBeAddedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
                                                List<TblMitra_Litabmas_DATA_SISTER> toBeDeletedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();
                                                List<TblMitra_Litabmas_DATA_SISTER> toBeUpdatedMitra = new List<TblMitra_Litabmas_DATA_SISTER>();

                                                toBeAddedMitra = compareListMitra.Where(a => !masterListMitra.Any(b => a.id == b.id)).ToList();

                                                foreach (var itemtobeaddedMitra in toBeAddedMitra)
                                                {
                                                    noIncrementMitra++;
                                                    itemtobeaddedMitra.no = noIncrementMitra;
                                                }
                                                toBeDeletedMitra = masterListMitra.Where(a => !compareListMitra.Any(b => a.id == b.id)).ToList();
                                                toBeUpdatedMitra = compareListMitra.Where(a => masterListMitra.Any(b => a.id == b.id)).ToList();

                                                _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.AddRange(toBeAddedMitra);
                                                _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER.RemoveRange(toBeDeletedMitra);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedMitra)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblMitra_Litabmas_DATA_SISTER
                                                        .FirstOrDefault(a => a.id == item.id);
                                                    itemToUpdate = item;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            TrPengabdian_DATA_SISTER entrydata = new TrPengabdian_DATA_SISTER();
                                            entrydata.id_penelitian_pengabdian = itemPenelitian.id;
                                            entrydata.judul_penelitian_pengabdian = itemPenelitian.judul;
                                            entrydata.tahun_pelaksanaan = itemPenelitian.tahun_pelaksanaan;
                                            entrydata.NPP1 = npp;

                                            if (_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id) &&
                                                    !masterList.Any(a => a.id_penelitian_pengabdian == itemPenelitian.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                                            // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPengabdian_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id_penelitian_pengabdian == itemPenelitian.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);
                                        }

                                    }
                                    List<TrPengabdian_DATA_SISTER> toBeAdded = new List<TrPengabdian_DATA_SISTER>();
                                    List<TrPengabdian_DATA_SISTER> toBeDeleted = new List<TrPengabdian_DATA_SISTER>();
                                    List<TrPengabdian_DATA_SISTER> toBeUpdated = new List<TrPengabdian_DATA_SISTER>();

                                    toBeAdded = compareList.Where(a => !masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                    toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                                    toBeUpdated = compareList.Where(a => masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                                    _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.AddRange(toBeAdded);
                                    _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.RemoveRange(toBeDeleted);
                                    int counter = 0;
                                    foreach (var item in toBeUpdated)
                                    {
                                        counter++;
                                        var itemToUpdate = _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Find(item.id_penelitian_pengabdian);

                                        counter++;
                                        itemToUpdate.id_penelitian_pengabdian = item.id_penelitian_pengabdian;

                                        // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil

                                        itemToUpdate.id_kategori_kegiatan = item.id_kategori_kegiatan != null ? item.id_kategori_kegiatan : itemToUpdate.id_kategori_kegiatan;

                                        itemToUpdate.judul_penelitian_pengabdian = item.judul_penelitian_pengabdian != null ? item.judul_penelitian_pengabdian : itemToUpdate.judul_penelitian_pengabdian;
                                        itemToUpdate.durasi_kegiatan = item.durasi_kegiatan != null ? item.durasi_kegiatan : itemToUpdate.durasi_kegiatan;
                                        itemToUpdate.tahun_pelaksanaan_ke = item.tahun_pelaksanaan_ke != null ? item.tahun_pelaksanaan_ke : itemToUpdate.tahun_pelaksanaan_ke;
                                        itemToUpdate.dana_dari_dikti = item.dana_dari_dikti != null ? item.dana_dari_dikti : itemToUpdate.dana_dari_dikti;
                                        itemToUpdate.dana_dari_PT = item.dana_dari_PT != null ? item.dana_dari_PT : itemToUpdate.dana_dari_PT;
                                        itemToUpdate.dana_dari_instansi_lain = item.dana_dari_instansi_lain != null ? item.dana_dari_instansi_lain : itemToUpdate.dana_dari_instansi_lain;
                                        itemToUpdate.in_kind = item.in_kind != null ? item.in_kind : itemToUpdate.in_kind;
                                        itemToUpdate.no_sk_tugas = item.no_sk_tugas != null ? item.no_sk_tugas : itemToUpdate.no_sk_tugas;
                                        itemToUpdate.tanggal_sk_penugasan = item.tanggal_sk_penugasan != null ? item.tanggal_sk_penugasan : itemToUpdate.tanggal_sk_penugasan;
                                        itemToUpdate.tempat_kegiatan = item.tempat_kegiatan != null ? item.tempat_kegiatan : itemToUpdate.tempat_kegiatan;
                                        itemToUpdate.id_jenis_skim = item.id_jenis_skim != null ? item.id_jenis_skim : itemToUpdate.id_jenis_skim;
                                        itemToUpdate.jenis_skim = item.jenis_skim != null ? item.jenis_skim : itemToUpdate.jenis_skim;
                                        itemToUpdate.tahun_usulan = item.tahun_usulan != null ? item.tahun_usulan : itemToUpdate.tahun_usulan;
                                        itemToUpdate.tahun_kegiatan = item.tahun_kegiatan != null ? item.tahun_kegiatan : itemToUpdate.tahun_kegiatan;
                                        itemToUpdate.tahun_pelaksanaan = item.tahun_pelaksanaan != null ? item.tahun_pelaksanaan : itemToUpdate.tahun_pelaksanaan;
                                        itemToUpdate.litabmas_sebelumnya = item.litabmas_sebelumnya != null ? item.litabmas_sebelumnya : itemToUpdate.litabmas_sebelumnya;
                                        itemToUpdate.id_afiliasi = item.id_afiliasi != null ? item.id_afiliasi : itemToUpdate.id_afiliasi;
                                        itemToUpdate.afiliasi = item.afiliasi != null ? item.afiliasi : itemToUpdate.afiliasi;
                                        itemToUpdate.id_kelompok_bidang = item.id_kelompok_bidang != null ? item.id_kelompok_bidang : itemToUpdate.id_kelompok_bidang;
                                        itemToUpdate.nama_kelompok_bidang = item.nama_kelompok_bidang != null ? item.nama_kelompok_bidang : itemToUpdate.nama_kelompok_bidang;
                                        if (itemToUpdate.NPP1 == null) // cek apakah kosong
                                            itemToUpdate.NPP1 = item.NPP1;
                                        else if (itemToUpdate.NPP2 == null && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP2 = item.NPP1;
                                        else if (itemToUpdate.NPP3 == null && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP3 = item.NPP1;
                                        else if (itemToUpdate.NPP4 == null && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP4 = item.NPP1;
                                        else if (itemToUpdate.NPP5 == null && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP5 = item.NPP1;
                                        else if (itemToUpdate.NPP6 == null && item.NPP1 != itemToUpdate.NPP5 && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP6 = item.NPP1;
                                    }

                                    await _DATA_SISTERcontext.SaveChangesAsync();
                                }
                                return Json(new { success = true, nama = namaDosen });
                            }
                            else
                            {

                                var ajar = JsonConvert.DeserializeObject<Penelitian>(apiResponse);
                                return Json(new { success = false, nama = namaDosen, message = ajar.detail });
                            }

                        }
                        
                        else
                        {
                            return Json(new { success = false, nama = namaDosen, message = "ID Dosen Sister tidak ditemukan." });
                        }


                    }
                    catch (Exception e)
                    {
                        return Json(new { error = true, message = e.Message, nama = namaDosen, npp = npp });

                    }
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
            
            return Json(new { success = true, message = "Sinkronisasi Pengabdian Berhasil" });


        }

        public async Task<IActionResult> SinkronDataPublikasiProdiSISTERbyNPP(string npp)
        {
            string namaDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).Nama;


            var nppstring = "";

           
            string idDosen = null;
            
            
            List<TrPublikasi_DATA_SISTER> masterList = new List<TrPublikasi_DATA_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<TrPublikasi_DATA_SISTER> compareList = new List<TrPublikasi_DATA_SISTER>();

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                        idDosen = idDosen != null ? idDosen.Trim() : null;
                        if (!String.IsNullOrEmpty(idDosen) && idDosen.Length == 36)
                        {
                            url = baseUrl + "/publikasi?id_sdm=" + idDosen;
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                            response = await httpClient.GetAsync(url);
                            apiResponse = await response.Content.ReadAsStringAsync();


                            if (response.IsSuccessStatusCode)
                            {
                                var ajar = JsonConvert.DeserializeObject<List<Publikasi>>(apiResponse);

                                if (ajar != null)
                                {
                                    int noIncrementPenulis = _DATA_SISTERcontext.TblPenulis_DATA_SISTER.Max(a => (int?)a.no) ?? 0;
                                    int noIncrementDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Max(a => (int?)a.no) ?? 0;

                                    foreach (Publikasi itemPublikasi in ajar)
                                    {
                                        await Task.Delay(500);

                                        url = baseUrl + "/publikasi/" + itemPublikasi.id;
                                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                        response = await httpClient.GetAsync(url);
                                        apiResponse = await response.Content.ReadAsStringAsync();
                                        if (response.IsSuccessStatusCode)
                                        {
                                            var detail = JsonConvert.DeserializeObject<Publikasi_detail>(apiResponse);

                                            TrPublikasi_DATA_SISTER entrydata = new TrPublikasi_DATA_SISTER();
                                            entrydata.id = detail.id;
                                            entrydata.kategori_kegiatan = detail.kategori_kegiatan;
                                            entrydata.judul = detail.judul;
                                            entrydata.quartile = detail.quartile;
                                            entrydata.jenis_publikasi = detail.jenis_publikasi;
                                            entrydata.tanggal = Convert.ToDateTime(detail.tanggal);
                                            entrydata.id_kategori_kegiatan = detail.id_kategori_kegiatan;
                                            entrydata.id_jenis_publikasi = detail.id_jenis_publikasi;
                                            entrydata.kategori_capaian_luaran = detail.kategori_capaian_luaran;
                                            entrydata.id_kategori_capaian_luaran = detail.id_kategori_capaian_luaran;
                                            entrydata.judul_litabmas = detail.judul_litabmas;
                                            entrydata.id_litabmas = detail.id_litabmas;
                                            entrydata.nomor_paten = detail.nomor_paten;
                                            entrydata.pemberi_paten = detail.pemberi_paten;
                                            entrydata.penerbit = detail.penerbit;
                                            entrydata.isbn = detail.isbn;
                                            entrydata.jumlah_halaman = detail.jumlah_halaman;
                                            entrydata.tautan = detail.tautan;
                                            entrydata.keterangan = detail.keterangan;
                                            entrydata.judul_artikel = detail.judul_artikel;
                                            entrydata.judul_asli = detail.judul_asli;
                                            entrydata.nama_jurnal = detail.nama_jurnal;
                                            entrydata.halaman = detail.halaman;
                                            entrydata.edisi = detail.edisi;
                                            entrydata.volume = detail.volume;
                                            entrydata.nomor = detail.nomor;
                                            entrydata.doi = detail.doi;
                                            entrydata.issn = detail.issn;
                                            entrydata.e_issn = detail.e_issn;
                                            entrydata.seminar = detail.seminar == true ? 1 : 0;
                                            entrydata.prosiding = detail.prosiding == true ? 1 : 0;
                                            entrydata.asal_data = detail.asal_data;
                                            entrydata.NPP1 = npp;


                                            if (_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Any(a => a.id == detail.id) &&
                                                    !masterList.Any(a => a.id == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);

                                            List<TblPenulis_DATA_SISTER> masterListPenulis = _DATA_SISTERcontext.TblPenulis_DATA_SISTER.Where(a => a.id_riwayat_publikasi_paten == detail.id).ToList();
                                            List<TblPenulis_DATA_SISTER> compareListPenulis = new List<TblPenulis_DATA_SISTER>();

                                            if (detail.penulis != null && detail.penulis.Length > 0) // ============== Sinkron Penulis ================
                                            {
                                                foreach (Penulis itemPenulis in detail.penulis)
                                                {
                                                    TblPenulis_DATA_SISTER entryPenulis = new TblPenulis_DATA_SISTER();
                                                    entryPenulis.nama = itemPenulis.nama;
                                                    entryPenulis.id_riwayat_publikasi_paten = detail.id;
                                                    entryPenulis.urutan = itemPenulis.urutan;
                                                    entryPenulis.afiliasi = itemPenulis.afiliasi;
                                                    entryPenulis.peran = itemPenulis.peran;
                                                    entryPenulis.jenis = itemPenulis.jenis;
                                                    entryPenulis.corresponding_author = itemPenulis.corresponding_author == true ? 1 : 0;
                                                    entryPenulis.id_sdm = itemPenulis.id_sdm;
                                                    entryPenulis.id_peserta_didik = itemPenulis.id_peserta_didik;
                                                    entryPenulis.id_orang = itemPenulis.id_orang;
                                                    entryPenulis.nomor_induk_peserta_didik = itemPenulis.nomor_induk_peserta_didik;

                                                    compareListPenulis.Add(entryPenulis);

                                                }


                                                List<TblPenulis_DATA_SISTER> toBeAddedPenulis = new List<TblPenulis_DATA_SISTER>();
                                                List<TblPenulis_DATA_SISTER> toBeDeletedPenulis = new List<TblPenulis_DATA_SISTER>();
                                                List<TblPenulis_DATA_SISTER> toBeUpdatedPenulis = new List<TblPenulis_DATA_SISTER>();

                                                toBeAddedPenulis = compareListPenulis.Where(a => !masterListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();

                                                foreach (var itemtobeaddedPenulis in toBeAddedPenulis)
                                                {
                                                    noIncrementPenulis++;
                                                    itemtobeaddedPenulis.no = noIncrementPenulis;
                                                }
                                                toBeDeletedPenulis = masterListPenulis.Where(a => !compareListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();
                                                toBeUpdatedPenulis = compareListPenulis.Where(a => masterListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();

                                                _DATA_SISTERcontext.TblPenulis_DATA_SISTER.AddRange(toBeAddedPenulis);
                                                _DATA_SISTERcontext.TblPenulis_DATA_SISTER.RemoveRange(toBeDeletedPenulis);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedPenulis)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblPenulis_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_riwayat_publikasi_paten == item.id_riwayat_publikasi_paten && a.id_sdm == item.id_sdm);

                                                    itemToUpdate = item;
                                                }
                                            }




                                            List<TblDokumen_DATA_SISTER> masterListDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Where(a => a.id_publikasi_atau_penelitian == detail.id).ToList();
                                            List<TblDokumen_DATA_SISTER> compareListDokumen = new List<TblDokumen_DATA_SISTER>();

                                            if (detail.dokumen != null && detail.dokumen.Length > 0) // ============== Sinkron Dokumen ================
                                            {
                                                foreach (Dokumen itemDokumen in detail.dokumen)
                                                {
                                                    TblDokumen_DATA_SISTER entryDokumen = new TblDokumen_DATA_SISTER();
                                                    entryDokumen.id_dokumen = itemDokumen.id;
                                                    entryDokumen.id_publikasi_atau_penelitian = detail.id;
                                                    entryDokumen.nama_dokumen = itemDokumen.nama;
                                                    entryDokumen.nama_file = itemDokumen.nama_file;
                                                    entryDokumen.jenis_file = itemDokumen.jenis_file;
                                                    entryDokumen.tanggal_upload = Convert.ToDateTime(itemDokumen.tanggal_upload);
                                                    //entryDokumen.nama_jenis_dokumen = itemDokumen.nama;
                                                    entryDokumen.tautan = itemDokumen.tautan;
                                                    entryDokumen.keterangan_dokumen = itemDokumen.keterangan;

                                                    compareListDokumen.Add(entryDokumen);

                                                }


                                                List<TblDokumen_DATA_SISTER> toBeAddedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeDeletedDokumen = new List<TblDokumen_DATA_SISTER>();
                                                List<TblDokumen_DATA_SISTER> toBeUpdatedDokumen = new List<TblDokumen_DATA_SISTER>();

                                                toBeAddedDokumen = compareListDokumen.Where(a => !masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                foreach (var itemtobeaddeddokumen in toBeAddedDokumen)
                                                {
                                                    noIncrementDokumen++;
                                                    itemtobeaddeddokumen.no = noIncrementDokumen;
                                                }
                                                toBeDeletedDokumen = masterListDokumen.Where(a => !compareListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();
                                                toBeUpdatedDokumen = compareListDokumen.Where(a => masterListDokumen.Any(b => a.id_dokumen == b.id_dokumen)).ToList();

                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.AddRange(toBeAddedDokumen);
                                                _DATA_SISTERcontext.TblDokumen_DATA_SISTER.RemoveRange(toBeDeletedDokumen);
                                                int counterAnggota = 0;
                                                foreach (var item in toBeUpdatedDokumen)
                                                {
                                                    counterAnggota++;
                                                    var itemToUpdate = _DATA_SISTERcontext.TblDokumen_DATA_SISTER
                                                        .FirstOrDefault(a => a.id_dokumen == item.id_dokumen);
                                                    itemToUpdate = item;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            TrPublikasi_DATA_SISTER entrydata = new TrPublikasi_DATA_SISTER();
                                            entrydata.id = itemPublikasi.id;
                                            entrydata.kategori_kegiatan = itemPublikasi.kategori_kegiatan;
                                            entrydata.judul = itemPublikasi.judul;
                                            entrydata.quartile = itemPublikasi.quartile;
                                            entrydata.jenis_publikasi = itemPublikasi.jenis_publikasi;
                                            entrydata.tanggal = Convert.ToDateTime(itemPublikasi.tanggal);
                                            entrydata.asal_data = itemPublikasi.asal_data;
                                            entrydata.NPP1 = npp;



                                            if (_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Any(a => a.id == itemPublikasi.id) &&
                                                    !masterList.Any(a => a.id == itemPublikasi.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                    // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                            {
                                                masterList.Add(_DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == itemPublikasi.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                            }
                                            else
                                                compareList.Add(entrydata);
                                        }


                                    }
                                    List<TrPublikasi_DATA_SISTER> toBeAdded = new List<TrPublikasi_DATA_SISTER>();
                                    List<TrPublikasi_DATA_SISTER> toBeDeleted = new List<TrPublikasi_DATA_SISTER>();
                                    List<TrPublikasi_DATA_SISTER> toBeUpdated = new List<TrPublikasi_DATA_SISTER>();

                                    toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                    toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                    toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                    _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AddRange(toBeAdded);
                                    _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.RemoveRange(toBeDeleted);
                                    int counter = 0;
                                    foreach (var item in toBeUpdated)
                                    {
                                        counter++;
                                        var itemToUpdate = _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Find(item.id);

                                        itemToUpdate.id = item.id;

                                        // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil



                                        itemToUpdate.kategori_kegiatan = item.kategori_kegiatan != null ? item.kategori_kegiatan : itemToUpdate.kategori_kegiatan;
                                        itemToUpdate.judul = item.judul != null ? item.judul : itemToUpdate.judul;
                                        itemToUpdate.quartile = item.quartile != null ? item.quartile : itemToUpdate.quartile;
                                        itemToUpdate.jenis_publikasi = item.jenis_publikasi != null ? item.jenis_publikasi : itemToUpdate.jenis_publikasi;
                                        itemToUpdate.tanggal = item.tanggal != null ? item.tanggal : itemToUpdate.tanggal;
                                        itemToUpdate.id_kategori_kegiatan = item.id_kategori_kegiatan != null ? item.id_kategori_kegiatan : itemToUpdate.id_kategori_kegiatan;
                                        itemToUpdate.id_jenis_publikasi = item.id_jenis_publikasi != null ? item.id_jenis_publikasi : itemToUpdate.id_jenis_publikasi;
                                        itemToUpdate.kategori_capaian_luaran = item.kategori_capaian_luaran != null ? item.kategori_capaian_luaran : itemToUpdate.kategori_capaian_luaran;
                                        itemToUpdate.id_kategori_capaian_luaran = item.id_kategori_capaian_luaran != null ? item.id_kategori_capaian_luaran : itemToUpdate.id_kategori_capaian_luaran;
                                        itemToUpdate.judul_litabmas = item.judul_litabmas != null ? item.judul_litabmas : itemToUpdate.judul_litabmas;
                                        itemToUpdate.id_litabmas = item.id_litabmas != null ? item.id_litabmas : itemToUpdate.id_litabmas;
                                        itemToUpdate.nomor_paten = item.nomor_paten != null ? item.nomor_paten : itemToUpdate.nomor_paten;
                                        itemToUpdate.pemberi_paten = item.pemberi_paten != null ? item.pemberi_paten : itemToUpdate.pemberi_paten;
                                        itemToUpdate.penerbit = item.penerbit != null ? item.penerbit : itemToUpdate.penerbit;
                                        itemToUpdate.isbn = item.isbn != null ? item.isbn : itemToUpdate.isbn;
                                        itemToUpdate.jumlah_halaman = item.jumlah_halaman != null ? item.jumlah_halaman : itemToUpdate.jumlah_halaman;
                                        itemToUpdate.tautan = item.tautan != null ? item.tautan : itemToUpdate.tautan;
                                        itemToUpdate.keterangan = item.keterangan != null ? item.keterangan : itemToUpdate.keterangan;
                                        itemToUpdate.judul_artikel = item.judul_artikel != null ? item.judul_artikel : itemToUpdate.judul_artikel;
                                        itemToUpdate.judul_asli = item.judul_asli != null ? item.judul_asli : itemToUpdate.judul_asli;
                                        itemToUpdate.nama_jurnal = item.nama_jurnal != null ? item.nama_jurnal : itemToUpdate.nama_jurnal;
                                        itemToUpdate.halaman = item.halaman != null ? item.halaman : itemToUpdate.halaman;
                                        itemToUpdate.edisi = item.edisi != null ? item.edisi : itemToUpdate.edisi;
                                        itemToUpdate.volume = item.volume != null ? item.volume : itemToUpdate.volume;
                                        itemToUpdate.nomor = item.nomor != null ? item.nomor : itemToUpdate.nomor;
                                        itemToUpdate.doi = item.doi != null ? item.doi : itemToUpdate.doi;
                                        itemToUpdate.issn = item.issn != null ? item.issn : itemToUpdate.issn;
                                        itemToUpdate.e_issn = item.e_issn != null ? item.e_issn : itemToUpdate.e_issn;
                                        itemToUpdate.seminar = item.seminar != null ? item.seminar : itemToUpdate.seminar;
                                        itemToUpdate.prosiding = item.prosiding != null ? item.prosiding : itemToUpdate.prosiding;
                                        itemToUpdate.asal_data = item.asal_data != null ? item.asal_data : itemToUpdate.asal_data;

                                        if (itemToUpdate.NPP1 == null) // cek apakah kosong
                                            itemToUpdate.NPP1 = item.NPP1;
                                        else if (itemToUpdate.NPP2 == null && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP2 = item.NPP1;
                                        else if (itemToUpdate.NPP3 == null && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP3 = item.NPP1;
                                        else if (itemToUpdate.NPP4 == null && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1) // cek apakah kosong dan tidak sama dengan NPP1 biar ga ke dobel
                                            itemToUpdate.NPP4 = item.NPP1;
                                        else if (itemToUpdate.NPP5 == null && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP5 = item.NPP1;
                                        else if (itemToUpdate.NPP6 == null && item.NPP1 != itemToUpdate.NPP5 && item.NPP1 != itemToUpdate.NPP4 && item.NPP1 != itemToUpdate.NPP3 && item.NPP1 != itemToUpdate.NPP2 && item.NPP1 != itemToUpdate.NPP1)
                                            itemToUpdate.NPP6 = item.NPP1;
                                    }

                                    await _DATA_SISTERcontext.SaveChangesAsync();

                                }
                                return Json(new { success = true, nama = namaDosen });


                            }
                            else
                            {
                                var ajar = JsonConvert.DeserializeObject<Penelitian>(apiResponse);
                                return Json(new { success = false, nama = namaDosen, message = ajar.detail });

                            }
                        }
                        else
                        {
                            return Json(new { success = false, nama = namaDosen, message = "ID Dosen Sister tidak ditemukan." });
                        }


                    }
                    catch (Exception e)
                    {
                        return Json(new { error = true, message = e.Message, nama = namaDosen, npp = npp });

                    }
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
            
        }

        public async Task<IActionResult> SinkronDataPengajaranProdiSISTERbyNPP(string id_semester, string npp)
        {
            string namaDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).Nama;


           
            string idDosen = null;
           
          
            List<TrPengajaran_Data_SISTER> masterList = new List<TrPengajaran_Data_SISTER>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<TrPengajaran_Data_SISTER> compareList = new List<TrPengajaran_Data_SISTER>();

            if (HttpContext.Session.GetString("NPP") != null)
            {
                if (id_semester != null)
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
                            var url = baseUrl + "/authorize";
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            var response = await httpClient.PostAsync(url, data);
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            Console.WriteLine("test");
                            TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                            PenelitianReq request = new PenelitianReq();
                            idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                            idDosen = idDosen != null ? idDosen.Trim() : null;
                            if (!String.IsNullOrEmpty(idDosen) && idDosen.Length == 36)
                            {
                                url = baseUrl + "/pengajaran?id_sdm=" + idDosen + "&id_semester=" + id_semester;
                                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                response = await httpClient.GetAsync(url);
                                apiResponse = await response.Content.ReadAsStringAsync();


                                if (response.IsSuccessStatusCode)
                                {
                                    var ajar = JsonConvert.DeserializeObject<List<Pengajaran>>(apiResponse);

                                    if (ajar != null )
                                    {

                                        foreach (Pengajaran itemPengajaran in ajar)
                                        {

                                            url = baseUrl + "/pengajaran/" + itemPengajaran.id;
                                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                            //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                                            response = await httpClient.GetAsync(url);
                                            apiResponse = await response.Content.ReadAsStringAsync();
                                            if (response.IsSuccessStatusCode)
                                            {
                                                var detail = JsonConvert.DeserializeObject<Pengajaran_detail>(apiResponse);

                                                TrPengajaran_Data_SISTER entrydata = new TrPengajaran_Data_SISTER();
                                                entrydata.id = detail.id;
                                                entrydata.semester = detail.semester;
                                                entrydata.mata_kuliah = detail.mata_kuliah;
                                                entrydata.kelas = detail.kelas;
                                                entrydata.sks = detail.sks;
                                                entrydata.id_semester = detail.id_semester;
                                                entrydata.sks_tatap_muka = detail.sks_tatap_muka;
                                                entrydata.sks_praktik = detail.sks_praktik;
                                                entrydata.sks_praktik_lapangan = detail.sks_praktik_lapangan;
                                                entrydata.sks_simulasi = detail.sks_simulasi;
                                                entrydata.tatap_muka_rencana = detail.tatap_muka_rencana;
                                                entrydata.tatap_muka_realisasi = detail.tatap_muka_realisasi;
                                                entrydata.jumlah_mahasiswa = detail.jumlah_mahasiswa;
                                                entrydata.jenis_evaluasi = detail.jenis_evaluasi;
                                                entrydata.nama_substansi = detail.nama_substansi;
                                                entrydata.NPP = npp;


                                                if (_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Any(a => a.id == detail.id) &&
                                                    !masterList.Any(a => a.id == detail.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                                {
                                                    masterList.Add(_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == detail.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                    compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                                }
                                                else
                                                    compareList.Add(entrydata);


                                            }
                                            else
                                            {


                                                TrPengajaran_Data_SISTER entrydata = new TrPengajaran_Data_SISTER();
                                                entrydata.id = itemPengajaran.id;
                                                entrydata.mata_kuliah = itemPengajaran.mata_kuliah;
                                                entrydata.kelas = itemPengajaran.kelas;
                                                entrydata.semester = itemPengajaran.semester;
                                                entrydata.sks = itemPengajaran.sks;
                                                entrydata.NPP = npp;
                                                if (_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Any(a => a.id == itemPengajaran.id) &&
                                                    !masterList.Any(a => a.id == itemPengajaran.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                        // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                                {
                                                    masterList.Add(_DATA_SISTERcontext.TrPengajaran_DATA_SISTER.AsNoTracking().FirstOrDefault(a => a.id == itemPengajaran.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                                    compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                                }
                                                else
                                                    compareList.Add(entrydata);
                                            }


                                        }
                                        List<TrPengajaran_Data_SISTER> toBeAdded = new List<TrPengajaran_Data_SISTER>();
                                        List<TrPengajaran_Data_SISTER> toBeDeleted = new List<TrPengajaran_Data_SISTER>();
                                        List<TrPengajaran_Data_SISTER> toBeUpdated = new List<TrPengajaran_Data_SISTER>();

                                        toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                        toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                        toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                        _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.AddRange(toBeAdded);
                                        _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.RemoveRange(toBeDeleted);
                                        int counter = 0;
                                        foreach (var item in toBeUpdated)
                                        {
                                            counter++;
                                            var itemToUpdate = _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Find(item.id);

                                            itemToUpdate.id = item.id;

                                            // dikasih exception kalau null, karena ada ada id yang detail nya ga bisa diambil

                                            itemToUpdate.semester = item.semester != null ? item.semester : itemToUpdate.semester;

                                            itemToUpdate.mata_kuliah = item.mata_kuliah != null ? item.mata_kuliah : itemToUpdate.mata_kuliah;
                                            itemToUpdate.kelas = item.kelas != null ? item.kelas : itemToUpdate.kelas;
                                            itemToUpdate.sks = item.sks != null ? item.sks : itemToUpdate.sks;
                                            itemToUpdate.id_semester = item.id_semester != null ? item.id_semester : itemToUpdate.id_semester;
                                            itemToUpdate.sks_tatap_muka = item.sks_tatap_muka != null ? item.sks_tatap_muka : itemToUpdate.sks_tatap_muka;
                                            itemToUpdate.sks_praktik = item.sks_praktik != null ? item.sks_praktik : itemToUpdate.sks_praktik;
                                            itemToUpdate.sks_praktik_lapangan = item.sks_praktik_lapangan != null ? item.sks_praktik_lapangan : itemToUpdate.sks_praktik_lapangan;
                                            itemToUpdate.sks_simulasi = item.sks_simulasi != null ? item.sks_simulasi : itemToUpdate.sks_simulasi;
                                            itemToUpdate.tatap_muka_rencana = item.tatap_muka_rencana != null ? item.tatap_muka_rencana : itemToUpdate.tatap_muka_rencana;
                                            itemToUpdate.tatap_muka_realisasi = item.tatap_muka_realisasi != null ? item.tatap_muka_realisasi : itemToUpdate.tatap_muka_realisasi;
                                            itemToUpdate.jumlah_mahasiswa = item.jumlah_mahasiswa != null ? item.jumlah_mahasiswa : itemToUpdate.jumlah_mahasiswa;
                                            itemToUpdate.jenis_evaluasi = item.jenis_evaluasi != null ? item.jenis_evaluasi : itemToUpdate.jenis_evaluasi;
                                            itemToUpdate.nama_substansi = item.nama_substansi != null ? item.nama_substansi : itemToUpdate.nama_substansi;
                                            itemToUpdate.NPP = item.NPP != null ? item.NPP : itemToUpdate.NPP;

                                        }

                                        await _DATA_SISTERcontext.SaveChangesAsync();
                                        await Task.Delay(3000);
                                    }
                                    return Json(new { success = true, nama = namaDosen });

                                }
                                else
                                {
                                    var ajar = JsonConvert.DeserializeObject<Pengajaran>(apiResponse);
                                    return Json(new { success = false, nama = namaDosen, message = ajar.detail });

                                }

                            }
                            else
                            {
                                return Json(new { success = false, nama = namaDosen, message = "ID Dosen Sister tidak ditemukan." });
                            }


                        }
                        catch (Exception e)
                        {
                            return Json(new { error = true, message = e.Message, nama = namaDosen, npp = npp });
                        }
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Semester harap dipilih" });
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
            
            return Json(new { success = true, message = "Sinkronisasi Pengajaran Berhasil" });

        }

        public async Task<IActionResult> PerbandinganPengajaran_SPKP(string id_semester)
        {
            string idDosen = null;



            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");

              

                using (SqlConnection conn = new SqlConnection(Connection.DataSisterConnection))
                {
                    try
                    {
                        string query = @"SELECT * 
                                        FROM perbandingan_pengajaran_spkp 
                                        WHERE id_semester = @id_semester AND NPP = @NPP";


                        var param = new { id_semester = id_semester, NPP = npp };
                        dynamic data = conn.Query<dynamic>(query, param).ToList();
                        foreach (var item in data)
                        {
                            if (item.sks == item.SKS_SPKP)
                            {
                                item.apakah_SKS_sama = "Ya";
                            }
                            else
                                item.apakah_SKS_sama = "Tidak";

                        }
                        return Json(new
                        {
                            data

                        });

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        conn.Dispose();
                    }


                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";

                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DisplayperbandinganPengajaran()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.semester = (new PerbandinganPengajaranDAO()).GetSemester();
            

            return View(mymodel);
        }

        public JsonResult ajaxPengajaran(int id_smt)
        {
            var npp = HttpContext.Session.GetString("NPP");

            List<object> data = new List<object>();
            data = (new PerbandinganPengajaranDAO()).GetPerbandinganPengajaran(id_smt, npp);

            return Json(data);
        }

        public async Task<List<SemesterSister>> getIdSemesterSister()
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
                    var url = baseUrl + "/authorize";
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await httpClient.PostAsync(url, data);
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("test");
                    TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                    PenelitianReq request = new PenelitianReq();
                    url = baseUrl + "/referensi/semester";
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                    response = await httpClient.GetAsync(url);
                    apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        List<SemesterSister> ajar = JsonConvert.DeserializeObject<List<SemesterSister>>(apiResponse);
                        return ajar;
                    }
                    else
                    {
                        var ajar = JsonConvert.DeserializeObject<SemesterSister>(apiResponse);
                        return null;
                    }
                }
                catch 
                {
                    throw;
                }
            }

        }

        public async Task<IActionResult> TestingLoadDosen()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.semesterSister = await getIdSemesterSister();
            List<Unit> Unit = new List<Unit>();

            Unit.Add(new Unit{ id_unit=40 , nama_unit= "Program Studi Akuntansi" ,kode_unit= "EA" });
            Unit.Add(new Unit{ id_unit = 41, nama_unit = "Program Studi Manajemen", kode_unit = "EM" });
            Unit.Add(new Unit{ id_unit = 44, nama_unit = "Program Studi Ekonomi Pembangunan", kode_unit = "EP" });
            Unit.Add(new Unit{ id_unit = 46, nama_unit = "Program Studi Ilmu Komunikasi", kode_unit = "KOM" });
            Unit.Add(new Unit{ id_unit = 47, nama_unit = "Program Studi Sosiologi", kode_unit = "SOS" });
            Unit.Add(new Unit{ id_unit = 49, nama_unit = "Program Studi Arsitektur", kode_unit = "TA" });
            Unit.Add(new Unit{ id_unit = 50, nama_unit = "Program Studi Teknik Sipil", kode_unit = "TS" });
            Unit.Add(new Unit{ id_unit = 53, nama_unit = "Program Studi Teknik Industri", kode_unit = "TI" });
            Unit.Add(new Unit { id_unit = 54, nama_unit = "Program Studi Informatika", kode_unit = "TF" });
            Unit.Add(new Unit { id_unit = 57, nama_unit = "Program Pascasarjana", kode_unit = "PASCA" });
            Unit.Add(new Unit { id_unit = 59, nama_unit = "Program Studi Manajemen", kode_unit = "MM" });
            Unit.Add(new Unit { id_unit = 60, nama_unit = "Program Studi Teknik Sipil", kode_unit = "MTS" });
            Unit.Add(new Unit { id_unit = 61, nama_unit = "Program Studi Arsitektur", kode_unit = "MIH" });
            Unit.Add(new Unit { id_unit = 62, nama_unit = "Program Studi Arsitektur", kode_unit = "MTA" });
            Unit.Add(new Unit { id_unit = 63, nama_unit = "Program Studi Informatika", kode_unit = "MTF" });


            mymodel.mstUnit = (new MstUnitDAO()).GetNamaUnit();
            return View(mymodel);
        }

        public async Task<IActionResult> ExportPublikasi()
        {
            byte[] result;
            var npp = HttpContext.Session.GetString("NPP");
            var dosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp);

            string namafile = "Publikasi "+dosen.Nama+".xlsx";

            //dynamic data = (from publikasi in _DATA_SISTERcontext.TrPublikasi_DATA_SISTER
            //                join penulis in _DATA_SISTERcontext.TblPenulis_DATA_SISTER on publikasi.id equals penulis.id_riwayat_publikasi_paten
            //                where penulis.id_sdm == dosen.ID_DOSEN_SISTER
            //                select new { publikasi.judul, publikasi.kategori_kegiatan, publikasi.judul_artikel, publikasi.tanggal.ToString(), penulis.peran, penulis.urutan }
            //        ).ToList();

            //dynamic obj = new ExpandoObject();

            //foreach(dynamic item in data)
            //{
            //    item.tanggal = item.tanggal.ToString();
            //}
            var data = (new PublikasiSisterDAO()).GetPublikasiSister(dosen.ID_DOSEN_SISTER);
            
            using (var package = new ExcelPackage())
            {
                try
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1"); //Worksheet name
                    worksheet.Cells.LoadFromCollection(data, true);
                    result = package.GetAsByteArray();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return File(result, "application/ms-excel", namafile);
        }
        public class SemesterSister
        {
            public int id { get; set; }
            public string nama { get; set; }
            public string message { get; set; }
            public string detail { get; set; }

        }

        public class PerguruanTinggi
        {
            public string id { get; set; }
            public string nama { get; set; }
            public string message { get; set; }
            public string detail { get; set; }

        }

        public class Unit
        {
            public int id_unit { get; set; }
            public string nama_unit { get; set; }
            public string kode_unit { get; set; }



        }

        

        public JsonResult tesPublikasi()
        {
            string npp = HttpContext.Session.GetString("NPP");
            string id_dosen = _context.MstKaryawan.AsNoTracking().FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;

            //var data = _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AsNoTracking().Where(a => a.NPP1 == npp || a.NPP2 == npp || a.NPP3 == npp || a.NPP4 == npp || a.NPP5 == npp || a.NPP6 == npp).ToList();
            //var data = (from publikasi in _DATA_SISTERcontext.TrPublikasi_DATA_SISTER
            //            join penulis in _DATA_SISTERcontext.TblPenulis_DATA_SISTER on publikasi.id equals penulis.id_riwayat_publikasi_paten
            //            where penulis.id_sdm == id_dosen
            //            select publikasi
            //        ).ToList();
            var data = (new PublikasiSisterDAO()).GetPublikasiSister(id_dosen);
            return Json(new
            {
                data
            });
        }

        public async Task<IActionResult> LoadDataRefSemester()
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");

                var data = _DATA_SISTERcontext.RefSemesterSister.ToList();
                return Json(new
                {
                    data
                });
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> SinkronDataReferensiSister()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<RefSemesterSister> masterList = new List<RefSemesterSister>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<RefSemesterSister> compareList = new List<RefSemesterSister>();

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));
                        
                       
                            url = baseUrl + "/referensi/semester";
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                            response = await httpClient.GetAsync(url);
                            apiResponse = await response.Content.ReadAsStringAsync();

                            if (response.IsSuccessStatusCode)
                            {
                                var ajar = JsonConvert.DeserializeObject<List<SemesterSister>>(apiResponse);

                                if (ajar != null)
                                {
                                   
                                    foreach (SemesterSister itemSemester in ajar)
                                    {
                                        RefSemesterSister entrydata = new RefSemesterSister();
                                        entrydata.id = itemSemester.id;
                                        entrydata.nama = itemSemester.nama;

                                    if (_DATA_SISTERcontext.RefSemesterSister.Any(a => a.id == itemSemester.id) &&
                                               !masterList.Any(a => a.id == itemSemester.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                                              // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                    {
                                        masterList.Add(_DATA_SISTERcontext.RefSemesterSister.AsNoTracking().FirstOrDefault(a => a.id == itemSemester.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                        compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                    }
                                    else
                                        compareList.Add(entrydata);

                                }
                                    List<RefSemesterSister> toBeAdded = new List<RefSemesterSister>();
                                    List<RefSemesterSister> toBeDeleted = new List<RefSemesterSister>();
                                    List<RefSemesterSister> toBeUpdated = new List<RefSemesterSister>();

                                    toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                    toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                    toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                    _DATA_SISTERcontext.RefSemesterSister.AddRange(toBeAdded);
                                    _DATA_SISTERcontext.RefSemesterSister.RemoveRange(toBeDeleted);
                                    int counter = 0;
                                    foreach (var item in toBeUpdated)
                                    {
                                        counter++;
                                        var itemToUpdate = _DATA_SISTERcontext.RefSemesterSister.Find(item.id);

                                        itemToUpdate = item;
                                    }

                                    await _DATA_SISTERcontext.SaveChangesAsync();

                                }


                                return Json(new { success = true, message = ajar });
                            }
                            else
                            {
                                var ajar = JsonConvert.DeserializeObject<SemesterSister>(apiResponse);

                                return Json(new { success = false, message = ajar.message });
                            }

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

        public async Task<IActionResult> SinkronDataPerguruanTinggiSister()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<RefPerguruanTinggiSister> masterList = new List<RefPerguruanTinggiSister>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<RefPerguruanTinggiSister> compareList = new List<RefPerguruanTinggiSister>();

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));


                        url = baseUrl + "/referensi/perguruan_tinggi";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                        response = await httpClient.GetAsync(url);
                        apiResponse = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            var ajar = JsonConvert.DeserializeObject<List<PerguruanTinggi>>(apiResponse);

                            if (ajar != null)
                            {

                                foreach (PerguruanTinggi itemSemester in ajar)
                                {
                                    RefPerguruanTinggiSister entrydata = new RefPerguruanTinggiSister();
                                    entrydata.id = itemSemester.id;
                                    entrydata.nama = itemSemester.nama;

                                    if (_DATA_SISTERcontext.RefPerguruanTinggiSister.Any(a => a.id == itemSemester.id) &&
                                               !masterList.Any(a => a.id == itemSemester.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                              // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                    {
                                        masterList.Add(_DATA_SISTERcontext.RefPerguruanTinggiSister.AsNoTracking().FirstOrDefault(a => a.id == itemSemester.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                        compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                    }
                                    else
                                        compareList.Add(entrydata);

                                }
                                List<RefPerguruanTinggiSister> toBeAdded = new List<RefPerguruanTinggiSister>();
                                List<RefPerguruanTinggiSister> toBeDeleted = new List<RefPerguruanTinggiSister>();
                                List<RefPerguruanTinggiSister> toBeUpdated = new List<RefPerguruanTinggiSister>();

                                toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                _DATA_SISTERcontext.RefPerguruanTinggiSister.AddRange(toBeAdded);
                                _DATA_SISTERcontext.RefPerguruanTinggiSister.RemoveRange(toBeDeleted);
                                int counter = 0;
                                foreach (var item in toBeUpdated)
                                {
                                    counter++;
                                    var itemToUpdate = _DATA_SISTERcontext.RefPerguruanTinggiSister.Find(item.id);

                                    itemToUpdate = item;
                                }

                                await _DATA_SISTERcontext.SaveChangesAsync();

                            }


                            return Json(new { success = true, message = ajar });
                        }
                        else
                        {
                            var ajar = JsonConvert.DeserializeObject<PerguruanTinggi>(apiResponse);

                            return Json(new { success = false, message = ajar.message });
                        }

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

        public async Task<IActionResult> SinkronDataKategoriCapaianLuaranSister()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<RefKategoriCapaianLuaranSister> masterList = new List<RefKategoriCapaianLuaranSister>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<RefKategoriCapaianLuaranSister> compareList = new List<RefKategoriCapaianLuaranSister>();

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));


                        url = baseUrl + "/referensi/kategori_capaian_luaran";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                        response = await httpClient.GetAsync(url);
                        apiResponse = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            var ajar = JsonConvert.DeserializeObject<List<SemesterSister>>(apiResponse);

                            if (ajar != null)
                            {

                                foreach (SemesterSister itemSemester in ajar)
                                {
                                    RefKategoriCapaianLuaranSister entrydata = new RefKategoriCapaianLuaranSister();
                                    entrydata.id = itemSemester.id;
                                    entrydata.nama = itemSemester.nama;

                                    if (_DATA_SISTERcontext.RefKategoriCapaianLuaranSister.Any(a => a.id == itemSemester.id) &&
                                               !masterList.Any(a => a.id == itemSemester.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                              // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                    {
                                        masterList.Add(_DATA_SISTERcontext.RefKategoriCapaianLuaranSister.AsNoTracking().FirstOrDefault(a => a.id == itemSemester.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                        compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                    }
                                    else
                                        compareList.Add(entrydata);

                                }
                                List<RefKategoriCapaianLuaranSister> toBeAdded = new List<RefKategoriCapaianLuaranSister>();
                                List<RefKategoriCapaianLuaranSister> toBeDeleted = new List<RefKategoriCapaianLuaranSister>();
                                List<RefKategoriCapaianLuaranSister> toBeUpdated = new List<RefKategoriCapaianLuaranSister>();

                                toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                _DATA_SISTERcontext.RefKategoriCapaianLuaranSister.AddRange(toBeAdded);
                                _DATA_SISTERcontext.RefKategoriCapaianLuaranSister.RemoveRange(toBeDeleted);
                                int counter = 0;
                                foreach (var item in toBeUpdated)
                                {
                                    counter++;
                                    var itemToUpdate = _DATA_SISTERcontext.RefKategoriCapaianLuaranSister.Find(item.id);

                                    itemToUpdate = item;
                                }

                                await _DATA_SISTERcontext.SaveChangesAsync();

                            }


                            return Json(new { success = true, message = ajar });
                        }
                        else
                        {
                            var ajar = JsonConvert.DeserializeObject<SemesterSister>(apiResponse);

                            return Json(new { success = false, message = ajar.message });
                        }

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

        public async Task<IActionResult> SinkronDataJenisPublikasiSister()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<RefJenisPublikasiSister> masterList = new List<RefJenisPublikasiSister>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<RefJenisPublikasiSister> compareList = new List<RefJenisPublikasiSister>();

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));


                        url = baseUrl + "/referensi/jenis_publikasi";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                        response = await httpClient.GetAsync(url);
                        apiResponse = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            var ajar = JsonConvert.DeserializeObject<List<SemesterSister>>(apiResponse);

                            if (ajar != null)
                            {

                                foreach (SemesterSister itemSemester in ajar)
                                {
                                    RefJenisPublikasiSister entrydata = new RefJenisPublikasiSister();
                                    entrydata.id = itemSemester.id;
                                    entrydata.nama = itemSemester.nama;

                                    if (_DATA_SISTERcontext.RefKategoriCapaianLuaranSister.Any(a => a.id == itemSemester.id) &&
                                               !masterList.Any(a => a.id == itemSemester.id)) // cek apakah ada data di tabel yang                                                                                               // kalau returnya true berarti harus dinegasi kan                                                                                   
                                                                                              // karena list ini bakal dimasukkin ke masterlist juga jadi nanti bisa ke dobel
                                    {
                                        masterList.Add(_DATA_SISTERcontext.RefJenisPublikasiSister.AsNoTracking().FirstOrDefault(a => a.id == itemSemester.id)); // untuk dosen yang punya id_penelitian yg sudah tersimpan di database,
                                        compareList.Add(entrydata);                                                                                                              // jadi jatuhnya cuma mengupdate row, nambahin dosen ke NPP2 dst
                                    }
                                    else
                                        compareList.Add(entrydata);

                                }
                                List<RefJenisPublikasiSister> toBeAdded = new List<RefJenisPublikasiSister>();
                                List<RefJenisPublikasiSister> toBeDeleted = new List<RefJenisPublikasiSister>();
                                List<RefJenisPublikasiSister> toBeUpdated = new List<RefJenisPublikasiSister>();

                                toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                _DATA_SISTERcontext.RefJenisPublikasiSister.AddRange(toBeAdded);
                                _DATA_SISTERcontext.RefJenisPublikasiSister.RemoveRange(toBeDeleted);
                                int counter = 0;
                                foreach (var item in toBeUpdated)
                                {
                                    counter++;
                                    var itemToUpdate = _DATA_SISTERcontext.RefJenisPublikasiSister.Find(item.id);

                                    itemToUpdate = item;
                                }

                                await _DATA_SISTERcontext.SaveChangesAsync();

                            }


                            return Json(new { success = true, message = ajar });
                        }
                        else
                        {
                            var ajar = JsonConvert.DeserializeObject<SemesterSister>(apiResponse);

                            return Json(new { success = false, message = ajar.message });
                        }

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

        public async Task<IActionResult> SinkronDataReferensiKategoriKegiatanSister()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");
            //string npp = "02.11.817"; 
            //string npp = "03.17.953";
            List<RefKategoriKegiatanSister> masterList = new List<RefKategoriKegiatanSister>(); // buat cari data yang NPP nya sama dengan Npp dosen saat ini

            List<RefKategoriKegiatanSister> compareList = new List<RefKategoriKegiatanSister>();
            
            masterList = (new ReferensiSisterDAO()).GetAllRefKategoriKegiatan().data;

            //(new ReferensiSisterDAO()).DeleteAllRefKategoriKegiatan();

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
                        var url = baseUrl + "/authorize";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await httpClient.PostAsync(url, data);
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("test");
                        TokenSister = (Sister_Token)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_Token));


                        url = baseUrl + "/referensi/kategori_kegiatan?tipe=list";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSister.token);
                        response = await httpClient.GetAsync(url);
                        apiResponse = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            var ajar = JsonConvert.DeserializeObject<List<RefKategoriKegiatanSister>>(apiResponse);

                            if (ajar != null)
                            {

                                foreach (RefKategoriKegiatanSister itemRef in ajar)
                                {
                                    RefKategoriKegiatanSister entrydata = new RefKategoriKegiatanSister();
                                    entrydata.id = itemRef.id;
                                    entrydata.parent_id = itemRef.parent_id;
                                    entrydata.nama = itemRef.nama;

                                    //DBOutput output = (new ReferensiSisterDAO()).AddRefKategoriKegiatan(itemRef.id, itemRef.parent_id, itemRef.nama);

                                    //if (output.status == false)
                                    //{
                                    //    return Json(new
                                    //    {
                                    //        status = output.status, message = output.pesan, id = itemRef.id
                                    //    });
                                    //    break;
                                        

                                    //}
                                    compareList.Add(entrydata);

                                }
                                List<RefKategoriKegiatanSister> toBeAdded = new List<RefKategoriKegiatanSister>();
                                List<RefKategoriKegiatanSister> toBeDeleted = new List<RefKategoriKegiatanSister>();
                                List<RefKategoriKegiatanSister> toBeUpdated = new List<RefKategoriKegiatanSister>();

                                toBeAdded = compareList.Where(a => !masterList.Any(b => a.id == b.id)).ToList();
                                toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id == b.id)).ToList();
                                toBeUpdated = compareList.Where(a => masterList.Any(b => a.id == b.id)).ToList();

                                foreach (RefKategoriKegiatanSister itemtobeadded in toBeAdded)
                                {
                                    DBOutput output = (new ReferensiSisterDAO()).AddRefKategoriKegiatan(itemtobeadded.id, itemtobeadded.parent_id, itemtobeadded.nama);

                                    if (output.status == false)
                                    {
                                        return Json(new
                                        {
                                            di = "add",
                                            status = output.status,
                                            message = output.pesan,
                                            id = itemtobeadded.id
                                        });

                                    }


                                }
                                foreach (RefKategoriKegiatanSister itemtobedeleted in toBeDeleted)
                                {
                                    DBOutput output = (new ReferensiSisterDAO()).DeleteRefKategoriKegiatan(itemtobedeleted.id);

                                    if (output.status == false)
                                    {
                                        return Json(new
                                        {
                                            di = "delete",
                                            status = output.status,
                                            message = output.pesan,
                                            id = itemtobedeleted.id
                                        });

                                    }


                                }
                                int counter = 0;
                                foreach (RefKategoriKegiatanSister item in toBeUpdated)
                                {
                                    DBOutput output = (new ReferensiSisterDAO()).UpdateRefKategoriKegiatan(item.id, item.parent_id, item.nama);

                                    if (output.status == false)
                                    {
                                        return Json(new
                                        {
                                            di = "update",
                                            status = output.status,
                                            message = output.pesan,
                                            id = item.id
                                        });

                                    }
                                }



                            }


                            return Json(new { success = true, message = ajar });
                        }
                        else
                        {
                            var ajar = JsonConvert.DeserializeObject<RefKategoriKegiatanSister>(apiResponse);

                            return Json(new { success = false, message = ajar.message });
                        }

                    }
                    catch (Exception ex)
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

        public async Task<IActionResult> EnkripsiPasswordAll()
        {
            List<MstKaryawan> listNpp = _context.MstKaryawan.ToList();
            //string passwordHash = getHash("1234567");

            foreach (MstKaryawan item in listNpp)
            {
                try
                {
                    if (!String.IsNullOrEmpty(item.Password))
                    {
                        string passwordHash = getHash(item.Password);
                        var output = await (new MstKaryawanDAO()).EncryptPassword(item.Npp, passwordHash);
                    }


                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        success = false,
                        npp = item.Npp,
                        message = ex.Message

                    });
                }


            }

            return Json(new
            {
                success = true,
                message = "Enkripsi Password Berhasil"
                

            });
        }
        public static string getHash(string password)
        {
           
            Encoding enc = Encoding.GetEncoding(1252);
            RIPEMD160 ripemdHasher = RIPEMD160.Create();
            byte[] data = ripemdHasher.ComputeHash(Encoding.Default.GetBytes(password));
            string str = enc.GetString(data);

            return str;
        }

        public async Task<IActionResult> UbahPasswordView()
        {

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");
                string nama = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).Nama;

                TempData["Nama"] = nama;
                return View();

            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
            //return View();
        }

        public async Task<IActionResult> UbahPassword(string passwordLama, string passwordBaru)
        {
            string npp = HttpContext.Session.GetString("NPP");
            var data = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp);
            if (npp != null)
            {
                if (!String.IsNullOrEmpty(passwordLama) && !String.IsNullOrEmpty(passwordBaru)) // Cek input kosong
                {
                    if (data.PASSWORD_RIPEM == getHash(passwordLama)) // Cek apakah password lama sama
                    {

                        try
                        {
                            var result = (new MstKaryawanDAO()).UbahPassword(npp, passwordBaru, getHash(passwordBaru));
                            return Json(new
                            {
                                success = true,
                                message = "Berhasil diubah"
                            });
                        }
                        catch (Exception ex)
                        {
                            return Json(new
                            {
                                success = false,
                                message = ex.Message
                            });
                        }


                    }
                    else
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Password lama salah"
                        });
                    }
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "Kolom input tidak boleh kosong"
                    });
                }
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult UbahPasswordFormDosen()
        {

            var model = new UbahPasswordForm();
            return View(model);


        }

        [HttpPost]
        public IActionResult UbahPasswordFormDosen(UbahPasswordForm model)
        {
          
            if (ModelState.IsValid)
            {
                
                var npp = HttpContext.Session.GetString("NPP");
                var data = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp);
                if (data != null)
                {
                    if (data.PASSWORD_RIPEM != getHash(model.passwordLama))
                    {
                        TempData["ErrorMessage"] = "Password Lama Salah";
                        return View();

                    }
                    else
                    {
                        try
                        {
                            var result = (new MstKaryawanDAO()).UbahPassword(npp, model.passwordBaru, getHash(model.passwordBaru));

                            //string swal = @"Swal.fire({
                            //              title: 'Ubah Password Berhasil',
                            //              text: 'You won't be able to revert this!',
                            //              icon: 'success',
                            //              allowOutsideClick:false,
                            //              confirmButtonColor: '#3085d6',
                            //              cancelButtonColor: '#d33',
                            //              confirmButtonText: 'Kembali ke halaman profile'
                            //            }).then((result) => {
                            //                if (result.isConfirmed)
                            //                {
                            //                    window.location.replace('/SimkaDosen/SimkaProfile');
                            //                }
                            //            }); ";
                            
                            TempData["SuccessMessage"] = "Ubah Password Berhasil";
                            //TempData["alert"] = "<script>alert('Ubah Password Berhasil');</script>";
                            //TempData["href"] = "<script>setTimeout(function(){window.location.replace('/SimkaDosen/SimkaProfile');},2000)</script>";
                            //TempData["swal"] = "<script src='//cdn.jsdelivr.net/npm/sweetalert2@11'></script><script>" + swal+"</script>";

                            
                            return RedirectToAction("SimkaProfile");

                        }
                        catch (Exception ex)
                        {
                            TempData["ErrorMessage"] = "<script>alert('" + ex.Message + "');</script>";
                            return View();
                        }
                    }
                    
                }

            }
            //var a = model;
            return View();
        }

    }
}


