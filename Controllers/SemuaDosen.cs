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


namespace APIControllers.Controllers
{

    public class SemuaDosenController: Controller
    {
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("role") == "admin")
            {


                Console.WriteLine(HttpContext.Session.GetString("name"));
                return await Task.FromResult(RedirectToAction("SemuaDosen"));
            }
            else
                return RedirectToAction("Index", "Home");
        }
            public async Task<IActionResult> Semuadosen(string sortOrder, string searchString)
            {
            if (HttpContext.Session.GetString("role") == "admin")
            {

                ViewData["Nama"] = HttpContext.Session.GetString("name");
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

                }
                return await Task.FromResult(View(dosen));
            }
            else
                return RedirectToAction("Index", "Home");

        }




        [HttpPost]
        public async Task<IActionResult> DetailDosen(string idDosen)
        {
            if (HttpContext.Session.GetString("role") == "admin")
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
        } else
                return RedirectToAction("Index", "Home");
    }

        public async Task<IActionResult> MailSender()
        {

            return await Task.FromResult(View("MailSender")); 

        }

        public async Task<IActionResult> login()
        {

            return await Task.FromResult(View("Home"));

        }
        public async Task<IActionResult> dosen()
        {
          return await Task.FromResult(View("semuadosen"));

        }
        public async Task<IActionResult> karyawan()
        {

            return await Task.FromResult(View("karyawan"));

        }

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
}