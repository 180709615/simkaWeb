using System;
using System.Collections.Generic;
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
    public class SimkaKaryawanController : Controller
    {
        private readonly SIATMAX_SISTERContext _context;

        public SimkaKaryawanController(SIATMAX_SISTERContext context)
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


        public IActionResult Restitusi()
        {
            return RedirectToAction("Restitusi", "Administrasi");

        }


        public async Task<IActionResult> Simkaprofile()
        {
            string npp = HttpContext.Session.GetString("NPP");
            if (HttpContext.Session.GetString("NPP") != null && HttpContext.Session.GetString("role") == "karyawan")
            //cek apakah login & sesuai dengan role
            {
                // simka part
                var balikan = new SimkaDosenPenelitian();

                balikan.Akademik = _context.MstUnitAkademik.FirstOrDefault(a => a.IdUnit == _context.MstKaryawan.FirstOrDefault(a => a.Npp == HttpContext.Session.GetString("NPP")).IdUnitAkademik);
                balikan.Penelitian = _context.TblPenelitian.Where(a => a.Npp == npp).ToList();
                balikan.Pengabdian = _context.TblPengabdian.Where(a => a.Npp == npp).ToList();
                balikan.Pengembangan = _context.TrPengembangan.Where(a => a.Npp == npp).ToList();
                // !!!!tambah riwayat pendidikan
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
                Console.WriteLine("ID DOSEN" + idDosen);
                if (balikan.Karyawan.ID_DOSEN_SISTER !=null)
                    // memastikan id dosen tidak null /kosong 
                    //sebelum mengakses api dikti
                {


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


                        url = "https://sister.uajy.ac.id/api.php/0.1/Pembicara";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();
                        balikan.Sister.bicara = (Pembicara)JsonConvert.DeserializeObject(apiResponse, typeof(Pembicara));


                        url = "https://sister.uajy.ac.id/api.php/0.1/JabatanStruktural";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();


                        url = "https://sister.uajy.ac.id/api.php/0.1/JabatanStruktural/detail";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();



                        url = "https://sister.uajy.ac.id/api.php/0.1/Publikasi";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(apiResponse);
                        balikan.Sister.publi = (Publikasi)JsonConvert.DeserializeObject(apiResponse, typeof(Publikasi));
                        //  dospen.bicara = (Pembicara)JsonConvert.DeserializeObject(apiResponse, typeof(Pembicara));

                        url = "https://sister.uajy.ac.id/api.php/0.1/Paten";
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        response = await httpClient.PostAsync(url, data);
                        apiResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(apiResponse);



                    }
                }
                return await Task.FromResult(View(balikan));
            }
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }


        }

        public async Task<IActionResult> KelolaPengembangan()
        {
          
                return RedirectToAction("KelolaPengembangan", "SimkaDosen");
           
        }

    }
    }
