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

namespace APIConsume.Controllers
{
    public class SimkaDosenController : Controller
    {
        private readonly SIATMAX_SISTERContext _context;
        private readonly DATA_SISTERContext _DATA_SISTERcontext;


        public SimkaDosenController(SIATMAX_SISTERContext context, DATA_SISTERContext contexData_Sister)
        {
            _context = context;
            _DATA_SISTERcontext = contexData_Sister;
        }
        public IActionResult Index()
        {
            return View();
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
            return RedirectToAction("Restitusi", "Administrasi");

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
        public async Task<IActionResult> Simkaprofile()
        {

            string npp = HttpContext.Session.GetString("NPP");
            if (HttpContext.Session.GetString("NPP") != null && HttpContext.Session.GetString("role") == "dosen")
            //cek apakah login & sesuai dengan role
            {

                // simka part
                var balikan = new SimkaDosenPenelitian();

                balikan.Akademik = _context.MstUnitAkademik.FirstOrDefault(a => a.IdUnit == _context.MstKaryawan.FirstOrDefault(a => a.Npp == HttpContext.Session.GetString("NPP")).IdUnitAkademik);
                balikan.Penelitian = _context.TblPenelitian.Where(a => a.Npp == npp).ToList();
                balikan.Pengabdian = _context.TblPengabdian.Where(a => a.Npp == npp).ToList();
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
        public async Task<IActionResult> LoadDataPengajaranAsync()
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");
                var data = _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Where(a => a.NPP == npp).ToList();
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
            string idDosen = null;

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");
                var data = _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Where(a => a.NPP == npp).ToList();
                foreach(TrPublikasi_DATA_SISTER item in data)
                {
                    item.tanggal_terbit = item.tanggal_terbit.Date;
                }
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
                string npp = HttpContext.Session.GetString("NPP");
                var data = _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Where(a => a.NPP == npp).ToList();
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
            string idDosen = null;

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");

                var data = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Where(a => a.NPP == npp).ToList();
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

            List<TrPenelitian_DATA_SISTER> masterList = new List<TrPenelitian_DATA_SISTER>();
            masterList = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Where(a => a.NPP == npp).ToList();
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


                        //yang diatas buat dapetin list dari Penelitian dulu

                        // PERULANGAN GET DETAIL PENELITIAN BUAT DIMASUKKIN compareList

                        Penelitian_detail_req request_detail = new Penelitian_detail_req();
                        foreach (Penelitians item in ajar.data)
                        {

                            request_detail.id_token = TokenSister.data.id_token;
                            request_detail.id_dosen = idDosen;
                            request_detail.id_penelitian_pengabdian = item.id_penelitian_pengabdian;
                            json = JsonConvert.SerializeObject(request_detail);
                            data = new StringContent(json, Encoding.UTF8, "application/json");
                            url = "https://sister.uajy.ac.id/api.php/0.1/Penelitian/detail";
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            response = await httpClient.PostAsync(url, data);
                            apiResponse = await response.Content.ReadAsStringAsync();
                            var detail = (Penelitian_Detail)JsonConvert.DeserializeObject(apiResponse, typeof(Penelitian_Detail));

                            TrPenelitian_DATA_SISTER entrydata = new TrPenelitian_DATA_SISTER();
                            entrydata.id_penelitian_pengabdian = detail.data.id_penelitian_pengabdian;
                            entrydata.judul_penelitian_pengabdian = detail.data.judul_penelitian_pengabdian;
                            entrydata.durasi_kegiatan = detail.data.durasi_kegiatan;
                            entrydata.tahun_pelaksanaan_ke = detail.data.tahun_pelaksanaan_ke;
                            entrydata.dana_dari_dikti = Convert.ToDecimal(detail.data.dana_dari_dikti);
                            entrydata.dana_dari_PT = Convert.ToDecimal(detail.data.dana_dari_PT);
                            entrydata.dana_dari_instansi_lain = Convert.ToDecimal(detail.data.dana_dari_instansi_lain);
                            entrydata.in_kind = detail.data.in_kind;
                            entrydata.no_sk_tugas = detail.data.no_sk_tugas;
                            entrydata.tanggal_sk_penugasan = Convert.ToDateTime(detail.data.tanggal_sk_penugasan).Date;  
                            entrydata.tempat_kegiatan = detail.data.tempat_kegiatan;
                            entrydata.nama_tahun_anggaran = detail.data.nama_tahun_anggaran;
                            entrydata.nama_skim = detail.data.nama_skim;
                            entrydata.parent_judul_litabmas = detail.data.parent_judul_litabmas;
                            entrydata.nama_lembaga = detail.data.nama_lembaga;
                            entrydata.nama_kelompok_bidang = detail.data.nama_kelompok_bidang;
                            entrydata.NPP = HttpContext.Session.GetString("NPP");
                            entrydata.nama_tahun_ajaran = item.nama_tahun_ajaran;

                            compareList.Add(entrydata);

                        }

                        List<TrPenelitian_DATA_SISTER> toBeAdded = new List<TrPenelitian_DATA_SISTER>();
                        List<TrPenelitian_DATA_SISTER> toBeDeleted = new List<TrPenelitian_DATA_SISTER>();
                        List<TrPenelitian_DATA_SISTER> toBeUpdated = new List<TrPenelitian_DATA_SISTER>();

                        toBeAdded = compareList.Where(a => !masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                        toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                        toBeUpdated = masterList.Where(a => compareList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                        _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.AddRange(toBeAdded);
                        _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.RemoveRange(toBeDeleted);
                        foreach (var item in toBeUpdated)
                        {
                            var itemToUpdate = _DATA_SISTERcontext.TrPenelitian_DATA_SISTER.Find(item.id_penelitian_pengabdian);
                            itemToUpdate = item;
                        }

                        await _DATA_SISTERcontext.SaveChangesAsync();

                        ////return Json(new { success = true, message = "Edit data success." });


                        return Json(new { success = true, message = "Sinkronisasi Penelitian sukses." });
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

        public async Task<IActionResult> SinkronDataPengajaranSISTER()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");

            List<TrPengajaran_Data_SISTER> masterList = new List<TrPengajaran_Data_SISTER>();
            masterList = _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Where(a => a.NPP == npp).ToList();
            List<TrPengajaran_Data_SISTER> compareList = new List<TrPengajaran_Data_SISTER>();


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
                        url = "https://sister.uajy.ac.id/api.php/0.1/Pengajaran";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();
                        var ajar = (Pengajaran)JsonConvert.DeserializeObject(apiResponse, typeof(Pengajaran));


                        //yang diatas buat dapetin list dari Penelitian dulu

                        // PERULANGAN GET DETAIL PENELITIAN BUAT DIMASUKKIN compareList

                        Pengajaran_detail_req request_detail = new Pengajaran_detail_req(); // Request dan Response yang diberikan API Pengabdian dan
                                                                                            // Penelitian sama sehingga saya menggunakan kelas yang sama
                        foreach (Pengajarans item in ajar.data)
                        {

                            request_detail.id_token = TokenSister.data.id_token;
                            request_detail.id_dosen = idDosen;
                            request_detail.id_pembelajaran = item.id_pembelajaran;
                            json = JsonConvert.SerializeObject(request_detail);
                            data = new StringContent(json, Encoding.UTF8, "application/json");
                            url = "https://sister.uajy.ac.id/api.php/0.1/Pengajaran/detail";
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            response = await httpClient.PostAsync(url, data);
                            apiResponse = await response.Content.ReadAsStringAsync();
                            var detail = (Pengajaran_detail)JsonConvert.DeserializeObject(apiResponse, typeof(Pengajaran_detail));

                            TrPengajaran_Data_SISTER entrydata = new TrPengajaran_Data_SISTER();
                            entrydata.id_pembelajaran = detail.data.id_pembelajaran;
                            entrydata.sks_total_persubstansi = Convert.ToDecimal(detail.data.sks_total_persubstansi);
                            entrydata.sks_tatap_muka_persubstansi = Convert.ToDecimal(detail.data.sks_tatap_muka_persubstansi);
                            entrydata.sks_praktek_persubstansi = Convert.ToDecimal(detail.data.sks_praktek_persubstansi);
                            entrydata.sks_praktek_lapangan_persubstansi = Convert.ToDecimal(detail.data.sks_praktek_lapangan_persubstansi);
                            entrydata.sks_simulasi_persubstansi = Convert.ToDecimal(detail.data.sks_simulasi_persubstansi);
                            entrydata.jumlah_tim_rencana = Convert.ToInt32(detail.data.jumlah_tim_rencana);
                            entrydata.jumlah_tim_real = Convert.ToInt32(detail.data.jumlah_tim_real);
                            entrydata.jumlah_mahasiswa = Convert.ToInt32(detail.data.jumlah_mahasiswa);
                            entrydata.nama_kelas_kuliah =detail.data.nama_kelas_kuliah;
                            entrydata.nama_jenis_evaluasi = detail.data.nama_jenis_evaluasi;
                            entrydata.nama_substansi = detail.data.nama_substansi;
                            
                            entrydata.NPP = HttpContext.Session.GetString("NPP");

                            entrydata.nama_mata_kuliah = item.nama_mata_kuliah; 
                            compareList.Add(entrydata);

                        }

                        List<TrPengajaran_Data_SISTER> toBeAdded = new List<TrPengajaran_Data_SISTER>();
                        List<TrPengajaran_Data_SISTER> toBeDeleted = new List<TrPengajaran_Data_SISTER>();
                        List<TrPengajaran_Data_SISTER> toBeUpdated = new List<TrPengajaran_Data_SISTER>();

                        toBeAdded = compareList.Where(a => !masterList.Any(b => a.id_pembelajaran == b.id_pembelajaran)).ToList();
                        toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id_pembelajaran == b.id_pembelajaran)).ToList();
                        toBeUpdated = masterList.Where(a => compareList.Any(b => a.id_pembelajaran == b.id_pembelajaran)).ToList();

                        _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.AddRange(toBeAdded);
                        _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.RemoveRange(toBeDeleted);
                        foreach (var item in toBeUpdated)
                        {
                            var itemToUpdate = _DATA_SISTERcontext.TrPengajaran_DATA_SISTER.Find(item.id_pembelajaran);
                            itemToUpdate = item;
                        }

                        await _DATA_SISTERcontext.SaveChangesAsync();

                        ////return Json(new { success = true, message = "Edit data success." });


                        return Json(new { success = true, message = "Sinkronisasi Pengajaran sukses." });
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

        public async Task<IActionResult> SinkronDataPengabdianSISTER()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");

            List<TrPengabdian_DATA_SISTER> masterList = new List<TrPengabdian_DATA_SISTER>();
            masterList = _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Where(a => a.NPP == npp).ToList();
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
                        var ajar = (Penelitian)JsonConvert.DeserializeObject(apiResponse, typeof(Penelitian));


                        //yang diatas buat dapetin list dari Penelitian dulu

                        // PERULANGAN GET DETAIL PENELITIAN BUAT DIMASUKKIN compareList

                        Penelitian_detail_req request_detail = new Penelitian_detail_req(); // Request dan Response yang diberikan API Pengabdian dan
                                                                                            // Penelitian sama sehingga saya menggunakan kelas yang sama
                        foreach (Penelitians item in ajar.data)
                        {

                            request_detail.id_token = TokenSister.data.id_token;
                            request_detail.id_dosen = idDosen;
                            request_detail.id_penelitian_pengabdian = item.id_penelitian_pengabdian;
                            json = JsonConvert.SerializeObject(request_detail);
                            data = new StringContent(json, Encoding.UTF8, "application/json");
                            url = "https://sister.uajy.ac.id/api.php/0.1/Pengabdian/detail";
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            response = await httpClient.PostAsync(url, data);
                            apiResponse = await response.Content.ReadAsStringAsync();
                            var detail = (Penelitian_Detail)JsonConvert.DeserializeObject(apiResponse, typeof(Penelitian_Detail));

                            TrPengabdian_DATA_SISTER entrydata = new TrPengabdian_DATA_SISTER();
                            entrydata.id_penelitian_pengabdian = detail.data.id_penelitian_pengabdian;
                            entrydata.judul_penelitian_pengabdian = detail.data.judul_penelitian_pengabdian;
                            entrydata.durasi_kegiatan = detail.data.durasi_kegiatan;
                            entrydata.tahun_pelaksanaan_ke = detail.data.tahun_pelaksanaan_ke;
                            entrydata.dana_dari_dikti = Convert.ToDecimal(detail.data.dana_dari_dikti);
                            entrydata.dana_dari_PT = Convert.ToDecimal(detail.data.dana_dari_PT);
                            entrydata.dana_dari_instansi_lain = Convert.ToDecimal(detail.data.dana_dari_instansi_lain);
                            entrydata.in_kind = detail.data.in_kind;
                            entrydata.no_sk_tugas = detail.data.no_sk_tugas;
                            entrydata.tanggal_sk_penugasan = Convert.ToDateTime(detail.data.tanggal_sk_penugasan).Date;
                            entrydata.tempat_kegiatan = detail.data.tempat_kegiatan;
                            entrydata.nama_tahun_anggaran = detail.data.nama_tahun_anggaran;
                            entrydata.nama_skim = detail.data.nama_skim;
                            entrydata.parent_judul_litabmas = detail.data.parent_judul_litabmas;
                            entrydata.nama_lembaga = detail.data.nama_lembaga;
                            entrydata.nama_kelompok_bidang = detail.data.nama_kelompok_bidang;
                            entrydata.NPP = HttpContext.Session.GetString("NPP");
                            entrydata.nama_tahun_ajaran = item.nama_tahun_ajaran;

                            compareList.Add(entrydata);

                        }

                        List<TrPengabdian_DATA_SISTER> toBeAdded = new List<TrPengabdian_DATA_SISTER>();
                        List<TrPengabdian_DATA_SISTER> toBeDeleted = new List<TrPengabdian_DATA_SISTER>();
                        List<TrPengabdian_DATA_SISTER> toBeUpdated = new List<TrPengabdian_DATA_SISTER>();

                        toBeAdded = compareList.Where(a => !masterList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                        toBeDeleted = masterList.Where(a => !compareList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();
                        toBeUpdated = masterList.Where(a => compareList.Any(b => a.id_penelitian_pengabdian == b.id_penelitian_pengabdian)).ToList();

                        _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.AddRange(toBeAdded);
                        _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.RemoveRange(toBeDeleted);
                        foreach (var item in toBeUpdated)
                        {
                            var itemToUpdate = _DATA_SISTERcontext.TrPengabdian_DATA_SISTER.Find(item.id_penelitian_pengabdian);
                            itemToUpdate = item;
                        }

                        await _DATA_SISTERcontext.SaveChangesAsync();

                        ////return Json(new { success = true, message = "Edit data success." });


                        return Json(new { success = true, message = "Sinkronisasi Pengabdian sukses." });
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

        public async Task<IActionResult> SinkronDataPublikasiSISTER()
        {
            string idDosen = null;
            string npp = HttpContext.Session.GetString("NPP");

            List<TrPublikasi_DATA_SISTER> masterListPublikasi = new List<TrPublikasi_DATA_SISTER>();
            masterListPublikasi = _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Where(a => a.NPP == npp).ToList();
            List<TrPublikasi_DATA_SISTER> compareListPublikasi = new List<TrPublikasi_DATA_SISTER>();

            List<TblPenulis_DATA_SISTER> masterListPenulis = new List<TblPenulis_DATA_SISTER>();
            List<TblPenulis_DATA_SISTER> compareListPenulis = new List<TblPenulis_DATA_SISTER>();

            List<TblDokumen_DATA_SISTER> masterListDokumen = new List<TblDokumen_DATA_SISTER>();
            List<TblDokumen_DATA_SISTER> compareListDokumen = new List<TblDokumen_DATA_SISTER>();

            List<TblPenulis_DATA_SISTER> toBeAddedPenulis = new List<TblPenulis_DATA_SISTER>();
            List<TblPenulis_DATA_SISTER> toBeDeletedPenulis = new List<TblPenulis_DATA_SISTER>();
            List<TblPenulis_DATA_SISTER> toBeUpdatedPenulis = new List<TblPenulis_DATA_SISTER>();

            List<TblDokumen_DATA_SISTER> toBeAddedDokumen = new List<TblDokumen_DATA_SISTER>();
            List<TblDokumen_DATA_SISTER> toBeDeletedDokumen = new List<TblDokumen_DATA_SISTER>();
            List<TblDokumen_DATA_SISTER> toBeUpdatedDokumen = new List<TblDokumen_DATA_SISTER>();

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
                        url = "https://sister.uajy.ac.id/api.php/0.1/Publikasi";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();
                        var ajar = (Publikasi)JsonConvert.DeserializeObject(apiResponse, typeof(Publikasi));


                        //yang diatas buat dapetin list dari Penelitian dulu

                        // PERULANGAN GET DETAIL PENELITIAN BUAT DIMASUKKIN compareList

                        Publikasi_detail_req request_detail = new Publikasi_detail_req(); // Request dan Response yang diberikan API Pengabdian dan
                                                                                            // Penelitian sama sehingga saya menggunakan kelas yang sama
                        foreach (Publikasis item in ajar.data)
                        {

                            request_detail.id_token = TokenSister.data.id_token;
                            request_detail.id_dosen = idDosen;
                            request_detail.id_riwayat_publikasi_paten = item.id_riwayat_publikasi_paten;
                            json = JsonConvert.SerializeObject(request_detail);
                            data = new StringContent(json, Encoding.UTF8, "application/json");
                            url = "https://sister.uajy.ac.id/api.php/0.1/Publikasi/detail";
                            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            response = await httpClient.PostAsync(url, data);
                            apiResponse = await response.Content.ReadAsStringAsync();
                            var detail = (Publikasi_detail)JsonConvert.DeserializeObject(apiResponse, typeof(Publikasi_detail));

                            TrPublikasi_DATA_SISTER entrydata = new TrPublikasi_DATA_SISTER();
                            entrydata.id_riwayat_publikasi_paten = detail.data.id_riwayat_publikasi_paten;
                            entrydata.judul_publikasi_paten = Convert.ToString(detail.data.judul_publikasi_paten);
                            entrydata.judul_asli_tulisan = Convert.ToString(detail.data.judul_asli_tulisan);
                            entrydata.tautan_laman_jurnal = Convert.ToString(detail.data.tautan_laman_jurnal);
                            entrydata.tanggal_terbit = Convert.ToDateTime(detail.data.tanggal_terbit).Date;
                            entrydata.volume = Convert.ToInt32(detail.data.volume);
                            entrydata.nomor_hasil_publikasi = Convert.ToInt32(detail.data.nomor_hasil_publikasi);
                            entrydata.halaman = detail.data.halaman;
                            entrydata.jumlah_halaman = Convert.ToInt32(detail.data.jumlah_halaman);
                            entrydata.nama_penerbit = detail.data.nama_penerbit;
                            entrydata.DOI_publikasi = detail.data.DOI_publikasi;
                            entrydata.ISBN_bahan_ajar = detail.data.ISBN_bahan_ajar;
                            entrydata.ISSN_publikasi = detail.data.ISSN_publikasi;
                            entrydata.tautan = detail.data.tautan;
                            entrydata.keterangan = detail.data.keterangan;
                            entrydata.pengguna_produk_jasa = detail.data.pengguna_produk_jasa;
                            entrydata.a_komersialisasi = Int32.Parse(detail.data.a_komersialisasi);
                            entrydata.stat_impor_sinta = detail.data.stat_impor_sinta;
                            entrydata.tgl_create = Convert.ToDateTime(detail.data.tgl_create).Date;
                            entrydata.quartile = detail.data.quartile;
                            entrydata.nama_kategori_kegiatan = detail.data.nama_kategori_kegiatan;
                            entrydata.nama_jenis_publikasi = detail.data.nama_jenis_publikasi;
                            entrydata.nama_kategori_pencapaian = detail.data.nama_kategori_pencapaian;
                            entrydata.judul_penelitian_pengabdian = Convert.ToString(detail.data.judul_publikasi_paten);
                            entrydata.NPP = HttpContext.Session.GetString("NPP");

                            masterListPenulis = _DATA_SISTERcontext.TblPenulis_DATA_SISTER.Where(a => a.id_riwayat_publikasi_paten == detail.data.id_riwayat_publikasi_paten).ToList();
                            masterListDokumen = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Where(a => a.id_riwayat_publikasi_paten == detail.data.id_riwayat_publikasi_paten).ToList();

                            foreach (Data_Penulis penulis in detail.data.data_penulis)
                            {
                                TblPenulis_DATA_SISTER entryPenulis = new TblPenulis_DATA_SISTER();
                                entryPenulis.id_riwayat_publikasi_paten = detail.data.id_riwayat_publikasi_paten;
                                entryPenulis.nama = penulis.nama;
                                entryPenulis.no_urut = penulis.no_urut;
                                entryPenulis.afiliasi_penulis = penulis.afiliasi_penulis;
                                entryPenulis.peran_dalam_kegiatan = penulis.peran_dalam_kegiatan;
                                entryPenulis.jenis_peranan = penulis.jenis_peranan;
                                entryPenulis.apakah_corresponding_author = penulis.apakah_corresponding_author;
                                entryPenulis.id_dosen = penulis.id_dosen;
                                entryPenulis.id_mahasiswa_anggota_penelitian_pengabdian = penulis.id_mahasiswa_anggota_penelitian_pengabdian;
                                entryPenulis.id_kolaborator_eksternal = penulis.id_kolaborator_eksternal;

                                compareListPenulis.Add(entryPenulis);
                            }

                            foreach (File_Publikasi file in detail.data.files)
                            {
                                TblDokumen_DATA_SISTER entryDokumen = new TblDokumen_DATA_SISTER();
                                entryDokumen.id_riwayat_publikasi_paten = detail.data.id_riwayat_publikasi_paten;
                                entryDokumen.id_dokumen = file.id_dokumen;
                                entryDokumen.nama_dokumen = file.nama_dokumen;
                                entryDokumen.nama_file = file.nama_file;
                                entryDokumen.jenis_file = file.jenis_file;
                                entryDokumen.tanggal_upload = Convert.ToDateTime(file.tanggal_upload).Date;
                                entryDokumen.tautan = file.tautan;
                                entryDokumen.keterangan_dokumen = file.keterangan_dokumen;

                                compareListDokumen.Add(entryDokumen);

                            }

                            

                            toBeAddedPenulis = compareListPenulis.Where(a => !masterListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();
                            toBeDeletedPenulis = masterListPenulis.Where(a => !compareListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();
                            toBeUpdatedPenulis = masterListPenulis.Where(a => compareListPenulis.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();

                            _DATA_SISTERcontext.TblPenulis_DATA_SISTER.AddRange(toBeAddedPenulis);
                            _DATA_SISTERcontext.TblPenulis_DATA_SISTER.RemoveRange(toBeDeletedPenulis);
                            foreach (var penulis in toBeUpdatedPenulis)
                            {
                                var itemToUpdate = _DATA_SISTERcontext.TblPenulis_DATA_SISTER.Find(item.id_riwayat_publikasi_paten);
                                itemToUpdate = penulis;
                            }

                           

                            toBeAddedDokumen = compareListDokumen.Where(a => !masterListDokumen.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();
                            toBeDeletedDokumen = masterListDokumen.Where(a => !compareListDokumen.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();
                            toBeUpdatedDokumen = masterListDokumen.Where(a => compareListDokumen.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();

                            _DATA_SISTERcontext.TblDokumen_DATA_SISTER.AddRange(toBeAddedDokumen);
                            _DATA_SISTERcontext.TblDokumen_DATA_SISTER.RemoveRange(toBeDeletedDokumen);
                            foreach (var dokumen in toBeUpdatedDokumen)
                            {
                                var itemToUpdate = _DATA_SISTERcontext.TblDokumen_DATA_SISTER.Find(item.id_riwayat_publikasi_paten);
                                itemToUpdate = dokumen;
                            }


                            compareListPublikasi.Add(entrydata);

                        }

                        List<TrPublikasi_DATA_SISTER> toBeAddedPublikasi = new List<TrPublikasi_DATA_SISTER>();
                        List<TrPublikasi_DATA_SISTER> toBeDeletedPublikasi = new List<TrPublikasi_DATA_SISTER>();
                        List<TrPublikasi_DATA_SISTER> toBeUpdatedPublikasi = new List<TrPublikasi_DATA_SISTER>();

                        toBeAddedPublikasi = compareListPublikasi.Where(a => !masterListPublikasi.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();
                        toBeDeletedPublikasi = masterListPublikasi.Where(a => !compareListPublikasi.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();
                        toBeUpdatedPublikasi = masterListPublikasi.Where(a => compareListPublikasi.Any(b => a.id_riwayat_publikasi_paten == b.id_riwayat_publikasi_paten)).ToList();

                        _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.AddRange(toBeAddedPublikasi);
                        _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.RemoveRange(toBeDeletedPublikasi);
                        foreach (var item in toBeUpdatedPublikasi)
                        {
                            var itemToUpdate = _DATA_SISTERcontext.TrPublikasi_DATA_SISTER.Find(item.id_riwayat_publikasi_paten);
                            itemToUpdate = item;
                        }

                        await _DATA_SISTERcontext.SaveChangesAsync();

                        ////return Json(new { success = true, message = "Edit data success." });


                        return Json(new { success = true, message = "Sinkronisasi Publikasi sukses." });
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

    }

}


