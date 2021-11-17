using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIConsume.Models
{
    public partial class MstKaryawan
    {
        public MstKaryawan()
        {
            MstAsuransi = new HashSet<MstAsuransi>();
            MstKeluarga = new HashSet<MstKeluarga>();
            MstRekening = new HashSet<MstRekening>();
            MstUnit = new HashSet<MstUnit>();
            TblAppraisal = new HashSet<TblAppraisal>();
            TblDokumen = new HashSet<TblDokumen>();
            TblStudiLanjut = new HashSet<TblStudiLanjut>();
            TblUsulanDiterima = new HashSet<TblUsulanDiterima>();
            TrCuti = new HashSet<TrCuti>();
            TrDp3 = new HashSet<TrDp3>();
            TrHonor = new HashSet<TrHonor>();
            TrHutangP = new HashSet<TrHutangP>();
            TrKegiatan = new HashSet<TrKegiatan>();
            TrKenaikanPangkat = new HashSet<TrKenaikanPangkat>();
            TrKgb = new HashSet<TrKgb>();
            TrMember = new HashSet<TrMember>();
            TrMutasi = new HashSet<TrMutasi>();
            TrPayroll = new HashSet<TrPayroll>();
            TrPensiun = new HashSet<TrPensiun>();
            TrRiwayatPendidikan = new HashSet<TrRiwayatPendidikan>();
            TblSkKaryawan = new HashSet<TblSkKaryawan>();
            TrRestitusi = new HashSet<TrRestitusi>();
            TrKarirFungsional = new HashSet<TrKarirFungsional>();
            TrKarirStruktural = new HashSet<TrKarirStruktural>();
            TrKarirGolongan = new HashSet<TrKarirGolongan>();

        }
        [Key]
        [Required]
        public string Npp { get; set; }
        public string Nama { get; set; }
        public string NamaLengkapGelar { get; set; }
        public string Nickname { get; set; }
        public string Inisial { get; set; }
        public string TempatLahir { get; set; }
        [DataType(DataType.Date)]
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
        public string? StatusIkatanKerja { get; set; }
        public string StatusAktifitas { get; set; }

        public string StatusFungsional { get; set; }

        //public string CurrentStatus { get; set; }
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
        public string AlamatDomisili { get; set; }
        public byte[] Password1 { get; set; }
        public byte[] FileFoto { get; set; }
        public byte[] FileKtp { get; set; }
        public byte[] FileNpwp { get; set; }
        public byte[] FileTtd { get; set; }
        public byte[] FileKartuPegawai { get; set; }
        public byte[] FileSertifikasiPendidik { get; set; }
        public byte[] FileAsuransi { get; set; }
        public string ID_DOSEN_SISTER { get; set; }
        public string PASSWORD_RIPEM { get; set; }

        public string UUID_LUPA_PWD { get; set; }



        public int? MASA_KERJA_GOLONGAN { get; set; }
        public DateTime? TMT_GOLONGAN { get; set; }
        public Boolean? STATUS_YADAPEN { get; set; }
        public int? ID_UNIT_ENTRYPASS { get; set; }
        public string? NIDK { get; set; }





        public RefFungsional IdRefFungsionalNavigation { get; set; }
        public RefGolongan IdRefGolonganNavigation { get; set; }
        public RefJabatanAkademik IdRefJbtnAkademikNavigation { get; set; }
        public RefTunjanganKhusus IdRefTunjanganKhususNavigation { get; set; }

        public MstUnitAkademik MstIdUnitAkademikNavigation { get; set; }
        public MstUnit IdUnitNavigation { get; set; }

        public MstUnit MstIdUnitNavigation { get; set; }
        public TrSertifikasi TrSertifikasi { get; set; }
        public ICollection<MstAsuransi> MstAsuransi { get; set; }
        public ICollection<MstKeluarga> MstKeluarga { get; set; }
        public ICollection<MstRekening> MstRekening { get; set; }
        public ICollection<MstUnit> MstUnit { get; set; }
        public ICollection<TblAppraisal> TblAppraisal { get; set; }
        public ICollection<TblDokumen> TblDokumen { get; set; }
        public ICollection<TblStudiLanjut> TblStudiLanjut { get; set; }
        public ICollection<TblUsulanDiterima> TblUsulanDiterima { get; set; }
        public ICollection<TrCuti> TrCuti { get; set; }
        public ICollection<TrDp3> TrDp3 { get; set; }
        public ICollection<TrHonor> TrHonor { get; set; }
        public ICollection<TrHutangP> TrHutangP { get; set; }
        public ICollection<TrKegiatan> TrKegiatan { get; set; }
        public ICollection<TrKenaikanPangkat> TrKenaikanPangkat { get; set; }
        public ICollection<TrKgb> TrKgb { get; set; }
        public ICollection<TrMember> TrMember { get; set; }
        public ICollection<TrMutasi> TrMutasi { get; set; }
        public ICollection<TrPayroll> TrPayroll { get; set; }
        public ICollection<TrPensiun> TrPensiun { get; set; }
        public ICollection<TrRiwayatPendidikan> TrRiwayatPendidikan { get; set; }
        public ICollection<TblSkKaryawan> TblSkKaryawan { get; set; }
        public ICollection<TrRestitusi> TrRestitusi { get; set; }
        public ICollection<TrKarirFungsional> TrKarirFungsional { get; set; }
        public ICollection<TrKarirStruktural> TrKarirStruktural { get; set; }
        public ICollection<TrKarirGolongan> TrKarirGolongan { get; set; }
    }
}
