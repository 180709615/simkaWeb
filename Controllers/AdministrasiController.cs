using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using APIConsume.DAO;
using APIConsume.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimkaUAJY.Controllers
{
    public class AdministrasiController : Controller
    {

        private readonly SIATMAX_SISTERContext _context;

        public AdministrasiController(SIATMAX_SISTERContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("NPP") != null && HttpContext.Session.GetString("role") == "dosen")
                return RedirectToAction("Index", "SimkaDosen");
            else
                return RedirectToAction("Index", "SimkaKaryawan");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            //bersihan sessionn
            return RedirectToAction("Index", "Home");
        }
        public IActionResult GantiPassword()
        {
            var npp = HttpContext.Session.GetString("NPP");
            if (npp != null)
            {
                return View();
            }
            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult EditBiografi()
        {
            var npp = HttpContext.Session.GetString("NPP");

            if (npp != null)
            {
                var karyawandb = _context.MstKaryawan.AsNoTracking().FirstOrDefault(x => x.Npp == npp);
                var balikan = new biografi()
                {
                    BiografiSingkat = karyawandb.BiografiSingkat,
                };
                return View(balikan);
            }
            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }

        }
        public async Task<IActionResult> PostGantiPassword([FromBody] Password pass)
        {

            try
            {
                var Npp = HttpContext.Session.GetString("NPP");


                var karyawandb = _context.MstKaryawan.AsNoTracking().FirstOrDefault(x => x.Npp == Npp);
                if (karyawandb.Password == pass.PasswordSekarang)
                // memeriksa password
                {
                    karyawandb.Password = pass.PasswordBaru;
                    _context.Update(karyawandb);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Edit data success." });
                }
                else
                {
                    TempData["Message"] = "Password Sekarang Salah";
                    return Json(new { sucesss = false, message = "Password Sekarang Salah." });
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500; //Write your own error code
                Response.WriteAsync(ex.Message);
                return null;
            }


        }

        public IActionResult UbahPassword()
        {
            var npp = HttpContext.Session.GetString("NPP");
            if (npp != null)
            {
                var model = new UbahPasswordForm();
                return View(model);
            }
            else
            {
                ViewData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
            


        }

        [HttpPost]
        public IActionResult UbahPassword(UbahPasswordForm model)
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
                            TempData["SuccessMessage"] = "Ubah Password Berhasil";                            

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

        public static string getHash(string password)
        {

            Encoding enc = Encoding.GetEncoding(1252);
            RIPEMD160 ripemdHasher = RIPEMD160.Create();
            byte[] data = ripemdHasher.ComputeHash(Encoding.Default.GetBytes(password));
            string str = enc.GetString(data);

            return str;
        }
        public async Task<IActionResult> PostEditBiografi([FromBody]biografi biografi)
        {

            try
            {
                var Npp = HttpContext.Session.GetString("NPP");


                var karyawandb = _context.MstKaryawan.AsNoTracking().FirstOrDefault(x => x.Npp == Npp);

                karyawandb.BiografiSingkat = biografi.BiografiSingkat;
                _context.Update(karyawandb);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Edit data success." });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500; //Write your own error code
                Response.WriteAsync(ex.Message);
                return null;
            }


        }
        public IActionResult Restitusi()
        {
            var npp = HttpContext.Session.GetString("NPP");
            var balikan = new TampilRestitusi();
            balikan.Npp = npp;
            balikan.SaldoBulanDepan = _context.TrRestitusi.Where(a => a.Npp == npp)
                .OrderByDescending(p => p.TglKuitansi).Select(p => p.SaldoBulanDepan).FirstOrDefault();
            balikan.SaldoBulanIni = _context.TrRestitusi.Where(a => a.Npp == npp)
                .OrderByDescending(p => p.TglKuitansi).Select(p => p.SaldoBulanIni).FirstOrDefault();
            balikan.NominalHutang = _context.TrRestitusi.Where(a => a.Npp == npp)
                .OrderByDescending(p => p.TglKuitansi).Select(p => p.NominalHutang).FirstOrDefault();

           
          
            return View(balikan);

        }
        public IActionResult LoadRestitusi(int tgl)
        {
            Console.WriteLine("test");
            Console.WriteLine(tgl);
            var Npp = HttpContext.Session.GetString("NPP");
            var restitusi = _context.TrRestitusi

                .Where(p => p.Npp == Npp && p.TglKuitansi.Value.Year == tgl && p.IsGabung==true)
                 .Select(p => new
                 {
                     p.IdTrRestitusi,
                     p.TglKuitansi,
                     p.idRekanantNavigation.NamaRekanan,
                     p.NominalKuitansi,
                     p.JmlAngsuran,
                     p.NominalHutang,
                     p.NominalGabungHutang,
                 })
                .ToList();

            return Json(new { data = restitusi });

        }
        public IActionResult LoadRestitusiObat(int tgl)
        {
            
            var Npp = HttpContext.Session.GetString("NPP");
            var restitusi = _context.TrRestitusi

                .Where(p => p.Npp == Npp && p.TglKuitansi.Value.Year == tgl  && p.IdRefRestitusi == 1)
                 .Select(p => new
                 {
                   
                     p.TglKuitansi,
                    
                     p.NominalKuitansi,
                     p.TglAmbil,
                     p.Keterangan
                 
                 })
                .ToList();

            return Json(new { data = restitusi });

        }
        public IActionResult LoadRestitusiBuku(int tgl)
        {

            var Npp = HttpContext.Session.GetString("NPP");
            var restitusi = _context.TrRestitusi

                .Where(p => p.Npp == Npp && p.TglKuitansi.Value.Year == tgl && p.IdRefRestitusi == 4)
                 .Select(p => new
                 {

                     p.TglKuitansi,

                     p.NominalKuitansi,
                     p.TglAmbil,
                     p.Keterangan

                 })
                .ToList();

            return Json(new { data = restitusi });

        }
        public IActionResult LoadRestitusiKacamata(int tgl)
        {

            var Npp = HttpContext.Session.GetString("NPP");
            var restitusi = _context.TrRestitusi

                .Where(p => p.Npp == Npp && p.TglKuitansi.Value.Year == tgl  && p.IdRefRestitusi == 3)
                 .Select(p => new
                 {

                     p.TglKuitansi,

                     p.NominalKuitansi,
                     p.Nominal,
                     p.TglAmbil,
                     p.Keterangan

                 })
                .ToList();

            return Json(new { data = restitusi });

        }
        public IActionResult LoadRestitusiRawatInap(int tgl)
        {

            var Npp = HttpContext.Session.GetString("NPP");
            var restitusi = _context.TrRestitusi

                .Where(p => p.Npp == Npp && p.TglKuitansi.Value.Year == tgl && p.IdRefRestitusi == 5)
                 .Select(p => new
                 {

                     p.TglKuitansi,

                     p.NominalKuitansi,
                     p.Nominal,
                     p.TglAmbil,
                     p.Keterangan

                 })
                .ToList();

            return Json(new { data = restitusi });

        }
        public IActionResult LoadDetailRestitusi(int idres)
        {
            int idres2 = idres + 1;
            int idres3 = idres + 2;
           
            var Npp = HttpContext.Session.GetString("NPP");
            var restitusi = _context.TrRestitusi

                .Where(p => p.IdTrRestitusiGabung.Contains (idres.ToString()) || p.IdTrRestitusiGabung.Contains(idres2.ToString()) || p.IdTrRestitusiGabung.Contains(idres3.ToString()))
                 .Select(p => new
                 {
                     p.IdTrRestitusi,
                     p.TglKuitansi,
                     p.idRekanantNavigation.NamaRekanan,
                     p.MulaiAngsur,
                     p.XAngsur,
                     p.JmlAngsuran,
                     p.IsGabung,
                     p.NominalGabungHutang
                 })
                .ToList();

            return Json(new { data = restitusi });

        }


        public async Task<IActionResult> Simkaprofile()
        {
            if(HttpContext.Session.GetString("role") == "dosen")
            return RedirectToAction("Simkaprofile", "SimkaDosen");
            else
                return RedirectToAction("Simkaprofile", "SimkaKaryawan");
        }
        public async Task<IActionResult> KelolaPengembangan()
        {
         
                return RedirectToAction("KelolaPengembangan", "SimkaDosen");
          
        }
    }
}