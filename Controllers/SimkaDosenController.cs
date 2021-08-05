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



namespace APIConsume.Controllers
{
    public class SimkaDosenController : Controller
    {
        private readonly SIATMAX_SISTERContext _context;

        public SimkaDosenController(SIATMAX_SISTERContext context)
        {
            _context = context;
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
            if (HttpContext.Session.GetString("NPP") != null )
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
                    IdTrPengembangan=pengembangan.IdTrPengembangan,
                    FilePengembangan=pengembangan.FilePengembangan,
                    Judul=pengembangan.Judul,
                    IssnIsbn=pengembangan.IssnIsbn,
                    Nilai=pengembangan.Nilai,
                    IdRefPengembangan=pengembangan.IdRefPengembangan,
                    IdRefAppraisal=pengembangan.IdRefAppraisal,
                    DanaLokal=pengembangan.DanaLokal,
                    TglMulai=pengembangan.TglMulai,
                    TglSelesai=pengembangan.TglSelesai,
                    Penerbit=pengembangan.Penerbit,
                    TingkatPeran=pengembangan.TingkatPeran,
                    Tempat=pengembangan.Tempat,
                    Peran=pengembangan.Peran,
                    SumberDana = pengembangan.SumberDana,
                    InstitusiDana=pengembangan.InstitusiDana,
                    
                };

                return View(balikan);
            }

        }
        public async Task<IActionResult> PostPengembangan(TrPengembanganForm pengembangan)
        {
            // mengecek apakah karyawan ada
            var karyawanada = await _context.TrPengembangan.AsNoTracking().AnyAsync(x => x.IdTrPengembangan == pengembangan.IdTrPengembangan);

            var Npp = HttpContext.Session.GetString("NPP");
            if (!ModelState.IsValid)
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
                SumberDana=pengembangan.SumberDana,



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
              
                if (balikan.Karyawan.ID_DOSEN_SISTER !=null)
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
        [Route("/SimkaDosen/LoadDataPublikasi")]
        public async Task<IActionResult> LoadDataPublikasi()
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");
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
        [Route("/SimkaDosen/LoadDataPengabdian")]
        public async Task<IActionResult> LoadDataPengabdian()
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");
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
        [Route("/SimkaDosen/LoadDataPenelitian")]
        public async Task<IActionResult> LoadDataPenelitian()
        {
            string idDosen = null;

            if (HttpContext.Session.GetString("NPP") != null)
            {
                string npp = HttpContext.Session.GetString("NPP");
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

        public IActionResult LoadDataRiwayatPendidikan()
        {
            string npp = HttpContext.Session.GetString("NPP");
            try
            {
                var customerData = _context.TrRiwayatPendidikan.Where(x => x.Npp.Equals(npp))
                    .Select(x => new {
                       
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
