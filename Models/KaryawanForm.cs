using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIConsume.Models
{
    public class KaryawanForm
    {
        public string? NIDK { get; set; }

        [Required]
        public string Npp { get; set; }
        [Required]
        public string Nama { get; set; }
        [Required]
        public string NamaLengkapGelar { get; set; }
        public string Nickname { get; set; }
        public string Inisial { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TglLahir { get; set; }
        public DateTime? TglMasuk { get; set; }
        public string GolDarah { get; set; }
        public string JnsKel { get; set; }
        public string Agama { get; set; }
        public int? Ptkp { get; set; }
        public string Email { get; set; }
        public string EmailInstitusi { get; set; }
        public int? IdRefFungsional { get; set; }
        public int? IdUnit { get; set; }
        public int? MstIdUnit { get; set; }    
        public int? IdUnitAkademik { get; set; }
        public int? IdUnitAkademikEpsbed { get; set; }
        public string IdRefGolongan { get; set; }
        public string IdRefGolonganLokal { get; set; }
        public int? IdRefJbtnAkademik { get; set; }
        public int? IdRefJbtnAkademikLokal { get; set; }
        public decimal? TmtAkhir { get; set; }
        public decimal? TmtAkhirLokal { get; set; }
        public string NoTelponRumah { get; set; }
        public string NoTelponHp { get; set; }
        public string Warganegara { get; set; }
        public string NoKtp { get; set; }
        public DateTime? TglAkhirBerlakuKtp { get; set; }
        public string Npwp { get; set; }
        public string NipPns { get; set; }
        public string Nidn { get; set; }
        public string AlamatKota { get; set; }
        public string Alamat { get; set; }
        public string AlamatProvinsi { get; set; }
        public string AlamatKodepos { get; set; }
        public string PendidikanTerakhir { get; set; }
        public string PendidikanDiakui { get; set; }
        public string StatusSipil { get; set; }
        public string StatusKepegawaian { get; set; }
        public string StatusFungsional { get; set; }
        public string StatusIkatanKerja { get; set; }
        public string CurrentStatus { get; set; }
        public string StatusRestitusi { get; set; }
        public string NoSertifikatPendidik { get; set; }
        public string Nik { get; set; }
        public string NoPaspor { get; set; }
        public DateTime? TglAkhirPaspor { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BiografiSingkat { get; set; }
        public string Nupn { get; set; }
        public string NppManager { get; set; }
        public int? IdRefJob { get; set; }
        public string StatusPtkp { get; set; }
        public int? IdRefTunjanganKhusus { get; set; }
        public DateTime? TglAkhirKtp { get; set; }
        public string NamaSingkat { get; set; }
        public string GelarDepan { get; set; }
        public string GelarBelakang { get; set; }
        public string NoBpjs { get; set; }
        public DateTime? TmtPurnakarya { get; set; }
        public string StatusAktifitas { get; set; }
        public string AlamatDomisili { get; set; }
        public IFormFile FileFoto { get; set; }
        public IFormFile FileKtp { get; set; }
        public IFormFile FileNpwp { get; set; }
        public IFormFile FileTtd { get; set; }
        public IFormFile FileKartuPegawai { get; set; }
        public IFormFile FileSertifikasiPendidik { get; set; }
        public IFormFile FileAsuransi { get; set; }
        public byte[] FileFotom { get; set; }
        public byte[] FileKtpm { get; set; }
        public byte[] FileNpwpm { get; set; }
        public byte[] FileTtdm { get; set; }
        public byte[] FileKartuPegawaim { get; set; }
        public byte[] FileSertifikasiPendidikm { get; set; }
        public byte[] FileAsuransim { get; set; }
        public string ID_DOSEN_SISTER { get; set; }
        public int? MASA_KERJA_GOLONGAN { get; set; }
        public int? IdUnitEPSBED { get; set; }


        public DateTime? TMT_GOLONGAN { get; set; }
        public Boolean? STATUS_YADAPEN { get; set; }
        public int? ID_UNIT_ENTRYPASS { get; set; }


        public List<MstRekening> rekening { get; set; }
        public List<RefGolongan> golongan { get; set; }
        public List<RefJabatanAkademik> akademik { get; set; }
        public List<RefJabatanStruktural> struktural { get; set; }
        public List<RefFungsional> fungsional { get; set; }
        public List<MstUnit> unit { get; set; }
        public List<MstUnit> subunit { get; set; }
        public List<RefStatusKepegawaian> statusKepegawaian { get; set; }
        public List<RefStatusKepegawaian> statusAktifitas { get; set; }
        public List<RefStatusIkatanKerja> statusIkatanKerja { get; set; }

        public List<MstUnit> listIdUnitEntrypass { get; set; }

        public List<MstUnit> unitEPSBED { get; set; }

        public List<RefKeluarga> refkeluarga { get; set; }
        public List<MstUnitAkademik> prodi { get; set; }
        public List<MstAsuransi> asuransi { get; set; }
    }
}
