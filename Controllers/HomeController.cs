using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using APIConsume.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
//using System.Net.Mail;
using MimeKit;
using Microsoft.EntityFrameworkCore;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Security.Cryptography;
using APIConsume.DAO;
using MailKit.Net.Smtp;
using MimeKit.Text;
using MailKit.Security;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace APIControllers.Controllers
{

    public class HomeController : Controller
    {
        private readonly SIATMAX_SISTERContext _context;
        private IHttpContextAccessor _accessor;

        public HomeController(IHttpContextAccessor accessor, SIATMAX_SISTERContext context)
        {
            _accessor = accessor;
            _context = context;
        }

     
    

        public async Task<string> SendWa()
        {
            var accountSid = "AC0ba9ff0b818feb5f8fd74535f0c3a2a9";
            var authToken = "e8eb3dd5bd088ad8c02ce5b2a71c1dc3";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("whatsapp:+6283862290039"));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = "Bapak/ Ibu telah login pada SIMKA UAJY";

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
            return await Task.FromResult("Email Sent Successfully!");
        }
        public async Task<string> SendEmail(string Name, string Email, string Message) 
        {

            //try
            //{
            //    // Credentials  
            //    //  var credentials = new NetworkCredential("sskkpuajy@gmail.com", "bersamasskkp");
            //    //var credentials = new NetworkCredential("testMhs@uajy.ac.id", "MhsCoba868");
            //    var credentials = new NetworkCredential("180709615@students.uajy.ac.id", "Deemust130600");

            //    // Mail message


            //    var mail = new MailMessage()
            //    {
            //        From = new MailAddress("180709615@students.uajy.ac.id"),
            //        Subject = "Informasi Login",
            //        Body = Message
            //    };
            //    mail.IsBodyHtml = true;
            //    mail.To.Add(new MailAddress("dimasprayoga2@gmail.com"));
            //    // Smtp client
            //    var client = new SmtpClient()
            //    {
            //        Port = 587,
            //        DeliveryMethod = SmtpDeliveryMethod.Network,
            //        UseDefaultCredentials = false,
            //        Host = "SMTP.Office365.com",
            //        EnableSsl = true,
            //        Credentials = credentials
            //    };
            //    client.Send(mail);
            //    return await Task.FromResult("Email Sent Successfully!");
            //}
            //catch (System.Exception e)
            //{
            //    Console.WriteLine("aaaaa");
            //    Console.WriteLine(e.Message);
            //    return e.Message;
            //}
            return ("emailsender");

        }
        public async Task<IActionResult> Index(string username, string password, int fungsional)
        {

            if (HttpContext.Session.GetString("role") == "admin")
                return await Task.FromResult(RedirectToAction("SimkaAdmin"));
            else
            if (HttpContext.Session.GetString("role") == "dosen")
                return await Task.FromResult(RedirectToAction("Simkadosen"));
            else

            if (HttpContext.Session.GetString("role") == "karyawan")
                return await Task.FromResult(RedirectToAction("SimkaKaryawan"));
            else
            {
                var balikan = new FungsionalLogin();
                balikan.fungsional = _context.RefFungsional.ToList();
                string[] npp_admin = new String[5];// daftar anggota role ksdm
                npp_admin[0] = "00.00.001";
                npp_admin[1] = "03.96.582";

                if (username != null && password != null)
                {
                    var mstKaryawan = _context.MstKaryawan.FirstOrDefault(a => a.Npp == username);
                    if (mstKaryawan != null)// npp cocok
                    {
                        if (mstKaryawan.PASSWORD_RIPEM == getHash(password))//password sesusai dengan npp
                        {
                            var informasilogin = "  <br><br><br> TESTING SIMKA 2 DEV <br> Berikut informasi login Bapak Ibu <br><br>" +
                            "Waktu Dan Tanggal:  " + DateTime.Now + "<br> IP Adress: "
                            + HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString() + "<br>" +
                            "Apabila Bapak/ Ibu tidak mengenali aktivitas ini agar segera menghubungi KSI melalui " +
                            "<a href='http://ksi.uajy.ac.id/helpdesk/open.php' target='_blank'> http://ksi.uajy.ac.id/helpdesk</a>" +
                            "<br>Terimakasih ";
                            //kirim email notifikasi login
                            var emails = mstKaryawan.Email; // ambil email 
                            if (emails != null || emails != "") //memastikan email tidak null
                            {

                                _ = await (SendEmail("test", emails, informasilogin));
                            }
                            else
                            if (emails == null || emails == "") // bila email ternyata null /kosong
                            {
                                emails = mstKaryawan.EmailInstitusi;
                                if (emails != null || emails != "")
                                {

                                    _ = await SendEmail("test", emails, informasilogin);
                                }
                            }



                            //akhir kirim email notifikasi login
                            //SendWa();
                            HttpContext.Session.SetString("NPP", username);
                            HttpContext.Session.SetString("Nama", mstKaryawan.NamaLengkapGelar);
                            if (fungsional == 1 && mstKaryawan.IdRefFungsional == 1)// user merupakan dosen dan memilih sebagai dosen
                            {
                                HttpContext.Session.SetString("role", "dosen");
                                return await Task.FromResult(RedirectToAction("Simkadosen"));
                            }
                            else if (fungsional == 1 && mstKaryawan.IdRefFungsional != 1)// user bukan dosen (karyawan)
                            {
                                HttpContext.Session.SetString("role", "karyawan");
                                return await Task.FromResult(RedirectToAction("SimkaKaryawan"));
                            }
                            else if (fungsional == 7)//cek role ksdm
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    if (npp_admin[i] == mstKaryawan.Npp)
                                    {
                                        HttpContext.Session.SetString("role", "admin");
                                        return await Task.FromResult(RedirectToAction("SimkaAdmin"));

                                    }
                                }
                                if (mstKaryawan.IdRefFungsional == 1) //dosen mencoba akses role ksdm tapi gagal
                                {
                                    HttpContext.Session.SetString("role", "dosen");
                                    return await Task.FromResult(RedirectToAction("Simkadosen"));
                                }
                                else
                                {
                                    HttpContext.Session.SetString("role", "karyawan"); //karyawan mencoba akses role ksdm tapi gagal
                                    return await Task.FromResult(RedirectToAction("SimkaKaryawan"));
                                }

                            }
                            else
                            {
                                HttpContext.Session.SetString("role", "karyawan");
                                return await Task.FromResult(RedirectToAction("SimkaKaryawan"));
                            }

                        }
                        else
                        {
                            TempData["Message"] = "password salah.";

                            return await Task.FromResult(View(balikan));
                        }
                    }
                    else
                    {
                        TempData["Message"] = "User Id Tidak Ditemukan.";
                        return await Task.FromResult(View(balikan));
                    }

                }
                else
                {

                    TempData["Message"] = "";
                    return await Task.FromResult(View(balikan));

                }
            }
            //return RedirectToAction("Index","MenuDynamic");
            
        }
        public IActionResult Simkadosen()
        {

            if (HttpContext.Session.GetString("NPP") != null)
                return RedirectToAction("Index", "SimkaDosen");
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult SimkaKaryawan()
        {

            if (HttpContext.Session.GetString("NPP") != null)
                return RedirectToAction("Index", "SimkaKaryawan");
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }



        public IActionResult SimkaAdmin()
        {


            if (HttpContext.Session.GetString("NPP") != null)
                return RedirectToAction("Index", "SimkaAdmin");
            else
            {
                TempData["Message"] = "Sesi Berakhir.";
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult SimkaPengembangan()
        {
            return View();
        }
        public JsonResult FindKegiatan(int tridharma_id)
        {
            //Use EF core to get all colors of this Code
            var Kegiatan = _context.RefPengembangan
                  .Where(p => p.IdRefJnsAppraisal == tridharma_id)
              .Select(p => new { p.IdRefPengembangan, p.Deskripsi });

            //return SelectList with your text and value
            var kegiatan = Kegiatan.ToList();
            Console.WriteLine(kegiatan);
            return new JsonResult(kegiatan);


        }
        public async Task<IActionResult> semuadosen(string sortOrder, string searchString)
        {

            Sister_Dosen dosen = new Sister_Dosen();
            Sister_Dosen dosjadi = new Sister_Dosen();
            Sister_Token reservation = new Sister_Token();
            using (var httpClient = new HttpClient())
            {
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

                var auten = new Sister_auth();
                auten.id_pengguna = "bd5df696-05d3-4db1-9e32-7c6be4e5ad36";
                auten.id_token = reservation.data.id_token;
                json = JsonConvert.SerializeObject(auten);
                data = new StringContent(json, Encoding.UTF8, "application/json");
                url = "https://sister.uajy.ac.id/api.php/0.1/Referensi/doseninternal";

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.PostAsync(url, data);
                apiResponse = await response.Content.ReadAsStringAsync();


                dosen = JsonConvert.DeserializeObject<Sister_Dosen>(apiResponse);

                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["FakultasSortParm"] = sortOrder == "Fakultas" ? "fakultas_desc" : "Fakultas";
                ViewData["ProgramStudiSortParam"] = sortOrder == "ProgramStudi" ? "ProgramStudi_desc" : "ProgramStudi";

                if (!String.IsNullOrEmpty(searchString))
                {
                    dosen.data = dosen.data.Where(s => s.nama_dosen.ToLower().Contains(searchString.ToLower())).ToArray();
                    return View(dosen);
                }

                switch (sortOrder)
                {
                    case "name_desc":

                        dosen.data = dosen.data.OrderByDescending(x => x.nama_dosen).ToArray();

                        dosen.data = dosen.data.Where(x => x.fakultas.Equals("TEKNIK", StringComparison.OrdinalIgnoreCase)).ToArray();


                        break;

                    case "fakultas_desc":

                        dosen.data = dosen.data.OrderByDescending(x => x.fakultas).ToArray();



                        break;
                    case "Fakultas":

                        dosen.data = dosen.data.OrderBy(x => x.fakultas).ToArray();



                        break;
                    case "ProgramStudi":

                        dosen.data = dosen.data.OrderBy(x => x.nama_program_studi).ToArray();


                        break;

                    case "ProgramStudi_desc":

                        dosen.data = dosen.data.OrderByDescending(x => x.nama_program_studi).ToArray();


                        break;

                    case "ft":
                        dosen.data = dosen.data.Where(x => x.fakultas.Equals("TEKNIK", StringComparison.OrdinalIgnoreCase)).ToArray();

                        break;
                    default:

                        dosen = JsonConvert.DeserializeObject<Sister_Dosen>(apiResponse);
                        dosen.data = dosen.data.OrderBy(x => x.nama_dosen).ToArray();


                        break;



                }
                return View(dosen);
            }


        }

        public ViewResult GetReservation() => View();

        [HttpPost]
        public async Task<IActionResult> GetReservation(int id)
        {
            Reservation reservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:8888/api/Reservation/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }
            return View(reservation);
        }
        [HttpPost]
        public async Task<IActionResult> DetailDosen(string idDosen)
        {

            using (var httpClient = new HttpClient())
            {
                Sister_DosenPenelitian dospen = new Sister_DosenPenelitian();
                Sister_Token reservation = new Sister_Token();
                PenelitianReq request = new PenelitianReq();
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

                dospen.dos = (Sister_DosenDetail)JsonConvert.DeserializeObject(apiResponse, typeof(Sister_DosenDetail));


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

                dospen.pen = (Penelitian)JsonConvert.DeserializeObject(apiResponse, typeof(Penelitian));

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
                dospen.abdi = (Pengabdian)JsonConvert.DeserializeObject(apiResponse, typeof(Pengabdian));


                url = "https://sister.uajy.ac.id/api.php/0.1/Pembicara";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.PostAsync(url, data);
                apiResponse = await response.Content.ReadAsStringAsync();
                dospen.bicara = (Pembicara)JsonConvert.DeserializeObject(apiResponse, typeof(Pembicara));


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
                dospen.publi = (Publikasi)JsonConvert.DeserializeObject(apiResponse, typeof(Publikasi));
                //  dospen.bicara = (Pembicara)JsonConvert.DeserializeObject(apiResponse, typeof(Pembicara));

                url = "https://sister.uajy.ac.id/api.php/0.1/Paten";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.PostAsync(url, data);
                apiResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(apiResponse);

                url = "https://sister.uajy.ac.id/api.php/0.1/Pengajaran";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await httpClient.PostAsync(url, data);
                apiResponse = await response.Content.ReadAsStringAsync();
                dospen.ajar = (Pengajaran)JsonConvert.DeserializeObject(apiResponse, typeof(Pengajaran));


                return await Task.FromResult(View(dospen));
            }
        }
        public async Task<IActionResult> pt()
        {
            string idDosen = null;

         

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
                    SisterReq request = new SisterReq();
                   // idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                    request.id_token = TokenSister.data.id_token;
                    request.id_pengguna = "bd5df696-05d3-4db1-9e32-7c6be4e5ad36";
                    json = JsonConvert.SerializeObject(request);
                    data = new StringContent(json, Encoding.UTF8, "application/json");
                    url = "https://sister.uajy.ac.id/api.php/0.1/Referensi/pt";

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    response = await httpClient.PostAsync(url, data);
                    apiResponse = await response.Content.ReadAsStringAsync();



                    return Json(new
                    {
                        apiResponse
                    });
                }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            
            
        }
        public async Task<IActionResult> mhs()
        {
            string idDosen = null;



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
                    SisterReqMhs request = new SisterReqMhs();
                    // idDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp).ID_DOSEN_SISTER;
                    request.id_token = TokenSister.data.id_token;
                    request.id_pengguna = "bd5df696-05d3-4db1-9e32-7c6be4e5ad36";
                    request.id_universitas = "b590f88f-2e3f-4cce-9c59-ccd7c3399b07";
                    request.id_program_studi = "";
                    request.keyword = "";
                    json = JsonConvert.SerializeObject(request);
                    data = new StringContent(json, Encoding.UTF8, "application/json");
                    url = "https://sister.uajy.ac.id/api.php/0.1//Mahasiswa";

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    response = await httpClient.PostAsync(url, data);
                    apiResponse = await response.Content.ReadAsStringAsync();



                    return Json(new
                    {
                        apiResponse
                    });
                }
                catch (Exception)
                {
                    throw;
                }
            }


        }
        public static string getHash(string password)
        {

            Encoding enc = Encoding.GetEncoding(1252);
            RIPEMD160 ripemdHasher = RIPEMD160.Create();
            byte[] data = ripemdHasher.ComputeHash(Encoding.Default.GetBytes(password));
            string str = enc.GetString(data);

            return str;
        }
        public async Task<string> SendEmailLupaPassword(string Email, string Message)
        {

            try
            {
                // Credentials  
                //  var credentials = new NetworkCredential("sskkpuajy@gmail.com", "bersamasskkp");
                //var credentials = new NetworkCredential("testMhs@uajy.ac.id", "MhsCoba868");
                var credentials = new NetworkCredential("180709615@students.uajy.ac.id", "Deemust130600");

                // Mail message


                //var mail = new MailMessage()
                //{
                //    From = new MailAddress("180709615@students.uajy.ac.id"),
                //    Subject = "Informasi Login",
                //    Body = Message
                //};
                //mail.IsBodyHtml = true;
                //mail.To.Add(new MailAddress("dimasprayoga2@gmail.com"));
                //// Smtp client
                //var client = new SmtpClient()
                //{
                //    Port = 587,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = false,
                //    Host = "SMTP.Office365.com",
                //    EnableSsl = true,
                //    Credentials = credentials
                //};
                // create email message
                
                // create email message

                return await Task.FromResult("Email Sent Successfully!");
            }
            catch (System.Exception e)
            {
                Console.WriteLine("aaaaa");
                Console.WriteLine(e.Message);
                return e.Message;
            }
            return ("emailsender");

        }

        public async Task<IActionResult> ResetPasswordView (string uuid)
        {
            if(uuid != null)
            {
                var dataDosen = _context.MstKaryawan.FirstOrDefault(a => a.UUID_LUPA_PWD == uuid);

                if (dataDosen != null)
                {
                    TempData["isLinkValid"] = true;
                    HttpContext.Session.SetString("NPPResetPassword", dataDosen.Npp);
                    return View();
                }
                else
                {
                    TempData["isLinkValid"] = false;
                    TempData["Message"] = "Link tidak valid";
                    TempData["alert"] = "<script>alert('Link tidak valid');window.location.replace('/Home')</script>";

                    return View();

                    //return RedirectToAction("Index", "Home");
                }


            }
            else
            {
                TempData["isLinkValid"] = false;
                TempData["Message"] = "Link tidak valid.";
                TempData["alert"] = "<script>alert('Link tidak valid');location.href='/Home'</script>";
                return View();
                //return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> ResetPassword (string passwordBaru)
        {
            
            var npp = HttpContext.Session.GetString("NPPResetPassword");
            var data = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp);
            if(data != null)
            {
                try
                {
                    var result = (new MstKaryawanDAO()).UbahPassword(npp, passwordBaru, getHash(passwordBaru));
                    var update = (new MstKaryawanDAO()).UbahUUID_Reset_Pswd(npp, null);

                    return Json(new
                    {
                        success = true,
                        message = "Password berhasil diperbarui"
                    });
                }
                catch(Exception ex)
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
                    success=false,
                    message = "Data dosen tidak ditemukan"
                });
            }

        }

        public async Task<IActionResult> LupaPassword(string npp)
        {
            if (npp != null)
            {
                var dataDosen = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp);

                if (dataDosen != null)
                {
                    var uuid = Guid.NewGuid().ToString();
                    var informasilogin = "  <br><br><br> TESTING SIMKA 2 DEV <br><br>" +
                                    "Waktu Dan Tanggal:  " + DateTime.Now +
                                    
                                    "<br> Silahkan klik link di bawah ini untuk memperbarui password Anda " +
                                     "<br><a href='https://localhost:44393/Home/ResetPasswordForm?uuid="+uuid+"' class='btn btn-info' target='_blank'>https://localhost:44393/Home/ResetPasswordForm?uuid="+uuid+" </a>" +
                                    "<br>Apabila Bapak/ Ibu tidak mengenali aktivitas ini agar segera menghubungi KSI melalui " +
                                    "<a href='http://ksi.uajy.ac.id/helpdesk/open.php' target='_blank'> http://ksi.uajy.ac.id/helpdesk</a>" +
                                    "<br>Terimakasih ";

                    try
                    {
                        //Update uuid npp tersebut biar nanti bisa di get data npp nya

                        var result = (new MstKaryawanDAO()).UbahUUID_Reset_Pswd(npp, uuid);
                        // Credentials  
                        //  var credentials = new NetworkCredential("sskkpuajy@gmail.com", "bersamasskkp");
                        //var credentials = new NetworkCredential("testMhs@uajy.ac.id", "MhsCoba868");
                        var credentials = new NetworkCredential("180709615@students.uajy.ac.id", "Deemust130600");

                        // Mail message


                        var email = new MimeMessage();
                        email.From.Add(MailboxAddress.Parse("180709615@students.uajy.ac.id"));
                        //email.To.Add(MailboxAddress.Parse("180709615@students.uajy.ac.id"));
                        email.To.Add(MailboxAddress.Parse("dimasprayoga2@gmail.com"));

                        email.Subject = "Lupa password";

                        var bodyBuilder = new BodyBuilder();
                        bodyBuilder.HtmlBody = informasilogin;
                        email.Body = bodyBuilder.ToMessageBody();

                        // send email
                        using var smtp = new SmtpClient();
                        smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        smtp.Connect("SMTP.Office365.com", 587, SecureSocketOptions.StartTls);
                        smtp.Authenticate("180709615@students.uajy.ac.id", "Deemust130600");
                        smtp.Send(email);
                        smtp.Disconnect(true);

                        string emailDosen = dataDosen.Email;                       
                        string pattern = @"(?<=[\w]{2})[\w-\._\+%]*(?=[\w]{1}@)";
                        string hideEmail = Regex.Replace(emailDosen, pattern, m => new string('*', m.Length));

                        TempData["Message"] = "Silahkan cek email Anda ";
                        TempData["success"] = true;
                        TempData["alertLupaPassword"] = "<script>alert('Silahkan cek email Anda " + hideEmail + "');window.location.replace('/Home')</script>";

                        return await Task.FromResult(View());
                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine("aaaaa");
                        Console.WriteLine(e.Message);

                        TempData["Message"] = e.Message;
                        TempData["success"] = false;
                        return await Task.FromResult(View());
                    }


                }
                else
                {
                    TempData["success"] = false;
                    TempData["Message"] = "Data tidak ditemukan";

                    return await Task.FromResult(View());
                }
            }
            else
            {
                TempData["Message"] = "";
                return await Task.FromResult(View());
            }
            
        }

        public IActionResult ResetPasswordForm(string uuid)
        {
            if (uuid != null)
            {
                var dataDosen = _context.MstKaryawan.FirstOrDefault(a => a.UUID_LUPA_PWD == uuid);

                if (dataDosen != null)
                {
                    TempData["isLinkValid"] = true;

                    HttpContext.Session.SetString("NPPResetPassword", dataDosen.Npp);
                    var model = new ResetPasswordForm();
                    return View(model);

                }
                else
                {
                    TempData["isLinkValid"] = false;
                    TempData["Message"] = "Data karyawan tidak ditemukan";
                    TempData["alert"] = "<script>alert('Data Karyawan tidak ditemukan');window.location.replace('/Home')</script>";

                    return View();

                    //return RedirectToAction("Index", "Home");
                }


            }
            else
            {
                TempData["isLinkValid"] = false;
                TempData["Message"] = "Link tidak valid.";
                TempData["alert"] = "<script>alert('Link tidak valid');location.href='/Home'</script>";
                return View();
                //return RedirectToAction("Index", "Home");
            }
            //var model = new ResetPasswordForm();
            //return View(model);


        }

        [HttpPost]
        public IActionResult ResetPasswordForm(ResetPasswordForm model)
        {
            TempData["isLinkValid"] = true; // Kasih tau kalau uuid udah valid jadi NPP yang mau reset password udah masuk di session

            if (ModelState.IsValid)
            {

                var npp = HttpContext.Session.GetString("NPPResetPassword");
                var data = _context.MstKaryawan.FirstOrDefault(a => a.Npp == npp);
                if (data != null)
                {
                    try
                    {
                        var result =  (new MstKaryawanDAO()).UbahPassword(npp, model.passwordBaru, getHash(model.passwordBaru));
                        var update = (new MstKaryawanDAO()).UbahUUID_Reset_Pswd(npp, null);

                        TempData["isLinkValid"] = true;

                        TempData["SuccessMessage"] = "Berhasil";
                        TempData["alert"] = "<script>alert('Reset Password Berhasil');window.location.replace('/Home')</script>";
                        return View();

                    }
                    catch (Exception ex)
                    {
                        TempData["alert"] = "<script>alert('"+ex.Message+"');</script>";
                        return View();
                    }
                }

            }
            //var a = model;
            return View();
        }

        public JsonResult getSidebarMenu()
        {
            var menu = "";
            DBOutput data = (new SidebarMenuDAO()).getSidebarMenu("");
            List<SidebarMenu> listMenu = new List<SidebarMenu>();
            //foreach (SidebarMenu row in data.data)
            //{
            //    if(row.parentid == 0)
            //    menu += $"<li class='nav-item'><a href = '#' class='nav-link'><i class='nav-icon fas fa-circle'></i><p>{row.menuname}<i class='fas fa-angle-left right'></i></p></a><ul class='nav nav-treeview'>";


            //    foreach (SidebarMenu submenu in data.data)
            //    {
            //        if(submenu.parentid == row.menuid)
            //        menu += $"<li class='nav-item'><a href='{submenu.menulocation}' class='nav-link'><i class='far fa-circle nav-icon'></i><p>{submenu.menuname}</p></a></li>";
            //        //menu += $"<li><a href='{submenu.LINK}'><i class='fa fa-circle-o'></i> {submenu.DESKRIPSI}</a></li>";
            //    }

            //    menu += "</ul></li> ";
            //}

            List<SidebarMenu> menuTree = GetMenuTree(data.data, 0);
            var append = "";
            foreach(var menus in menuTree)
            {
                if(menus.parentid == 0)
                {
                    append += "<li class='nav-item'><a href = '#' class='nav-link'><i class='nav-icon fas fa-circle'></i><p>" + menus.menuname + "<i class='fas fa-angle-left right'></i></p></a><ul class='nav nav-treeview'>";

                     if(menus.ListMenu != null && menus.ListMenu.Count > 0)
                    {
                        foreach(var submenu in menus.ListMenu)
                        {
                            append += "<li class='nav-item'><a href=# class='nav-link'><i class='far fa-circle nav-icon'></i><p>" + submenu.menuname + "</p></a></li>";
                        }
                    }
                    append += "</ul></li>";
                }
                

            }
            return Json(append);

        }

        private List<SidebarMenu> GetMenuTree(List<SidebarMenu> list, int? parent)
        {
            return list.Where(x => x.parentid == parent).Select(x => new SidebarMenu
            {
                urut = x.urut,
                NO_URUT = x.NO_URUT,
                menuid = x.menuid,
                menuname = x.menuname,
                menulocation = x.menulocation,
                ListMenu = GetMenuTree(list,x.menuid)

            }).ToList();
        }

        public IActionResult _LayoutSidebar()
        {
            return View();
        }
    }



}

       

      
       

       /* 
        public ViewResult AddReservation() => View();

        [HttpPost]
        public async Task<IActionResult> AddReservation(Reservation reservation)
        {
            Reservation receivedReservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Key", "Secret@123");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:8888/api/Reservation", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                    }
                    catch (Exception)
                    {
                        ViewBag.Result = apiResponse;
                        return View();
                    }
                }
            }
            return View(receivedReservation);
        }

        public async Task<IActionResult> UpdateReservation(int id)
        {
            Reservation reservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:8888/api/Reservation/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(Reservation reservation)
        {
            Reservation receivedReservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(reservation.Id.ToString()), "Id");
                content.Add(new StringContent(reservation.Name), "Name");
                content.Add(new StringContent(reservation.StartLocation), "StartLocation");
                content.Add(new StringContent(reservation.EndLocation), "EndLocation");

                using (var response = await httpClient.PutAsync("http://localhost:8888/api/Reservation", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }
            return View(receivedReservation);
        }

        public async Task<IActionResult> UpdateReservationPatch(int id)
        {
            Reservation reservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:8888/api/Reservation/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservationPatch(int id, Reservation reservation)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:8888/api/Reservation/" + id),
                    Method = new HttpMethod("Patch"),
                    Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"Name\", \"value\": \"" + reservation.Name + "\"},{ \"op\": \"replace\", \"path\": \"StartLocation\", \"value\": \"" + reservation.StartLocation + "\"}]", Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReservation(int ReservationId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:8888/api/Reservation/" + ReservationId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddFile() => View();

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            string apiResponse = "";
            using (var httpClient = new HttpClient())
            {
                using (var fileStream = file.OpenReadStream())
                {
                    var form = new MultipartFormDataContent();
                    form.Add(new StreamContent(fileStream), "file", file.FileName);

                    using (var response = await httpClient.PostAsync("http://localhost:8888/api/Reservation/UploadFile", form))
                    {
                        response.EnsureSuccessStatusCode();
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            return View((object)apiResponse);
        }
    }
}*/
