using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIConsume.Models
{
    public partial class SIATMAX_SISTERContext : DbContext
    {

        public SIATMAX_SISTERContext(DbContextOptions<SIATMAX_SISTERContext> options)
    : base(options)
        { }
        public virtual DbSet<DtlBiayaSlInternal> DtlBiayaSlInternal { get; set; }
        public virtual DbSet<DtlRabPenelitian> DtlRabPenelitian { get; set; }
        public virtual DbSet<DtlRabPengabdian> DtlRabPengabdian { get; set; }
        public virtual DbSet<HstSk> HstSk { get; set; }
        public virtual DbSet<KabKodya> KabKodya { get; set; }
        public virtual DbSet<MstAsuransi> MstAsuransi { get; set; }
        public virtual DbSet<MstDosenLuar> MstDosenLuar { get; set; }
        public virtual DbSet<MstKaryawan> MstKaryawan { get; set; }
        public virtual DbSet<MstKeluarga> MstKeluarga { get; set; }
        public virtual DbSet<MstRekanan> MstRekanan { get; set; }
        public virtual DbSet<MstRekening> MstRekening { get; set; }
        public virtual DbSet<MstTarifPayroll> MstTarifPayroll { get; set; }
        public virtual DbSet<MstUnit> MstUnit { get; set; }
        public virtual DbSet<MstUnitAkademik> MstUnitAkademik { get; set; }
        public virtual DbSet<Propinsi> Propinsi { get; set; }
        public virtual DbSet<RefButirAppraisal> RefButirAppraisal { get; set; }
        public virtual DbSet<RefCuti> RefCuti { get; set; }
        public virtual DbSet<RefDp3> RefDp3 { get; set; }
        public virtual DbSet<RefFungsional> RefFungsional { get; set; }
        public virtual DbSet<RefGolongan> RefGolongan { get; set; }
        public virtual DbSet<RefJabatanAkademik> RefJabatanAkademik { get; set; }
        public virtual DbSet<RefJabatanStruktural> RefJabatanStruktural { get; set; }
        public virtual DbSet<RefJenisAppraisal> RefJenisAppraisal { get; set; }
        public virtual DbSet<RefJenisDokumen> RefJenisDokumen { get; set; }
        public virtual DbSet<RefJenisKelas> RefJenisKelas { get; set; }
        public virtual DbSet<RefJenisSemester> RefJenisSemester { get; set; }
        public virtual DbSet<RefJenisSk> RefJenisSk { get; set; }
        public virtual DbSet<RefJenisTest> RefJenisTest { get; set; }
        public virtual DbSet<RefJenisTestDetail> RefJenisTestDetail { get; set; }
        public virtual DbSet<RefJenjang> RefJenjang { get; set; }
        public virtual DbSet<RefKabKodya> RefKabKodya { get; set; }
        public virtual DbSet<RefKategori> RefKategori { get; set; }
        public virtual DbSet<RefKecamatan> RefKecamatan { get; set; }
        public virtual DbSet<RefKegiatan> RefKegiatan { get; set; }
        public virtual DbSet<RefKeluarga> RefKeluarga { get; set; }
        public virtual DbSet<RefKelurahan> RefKelurahan { get; set; }
        public virtual DbSet<RefKompetensi> RefKompetensi { get; set; }
        public virtual DbSet<RefNegara> RefNegara { get; set; }
        public virtual DbSet<RefPembiayaan> RefPembiayaan { get; set; }
        public virtual DbSet<RefPengeluaranRab> RefPengeluaranRab { get; set; }
        public virtual DbSet<RefPengembangan> RefPengembangan { get; set; }
        public virtual DbSet<RefPiutang> RefPiutang { get; set; }
        public virtual DbSet<RefPosisi> RefPosisi { get; set; }
        public virtual DbSet<RefPotonganP> RefPotonganP { get; set; }
        public virtual DbSet<RefPropinsi> RefPropinsi { get; set; }
        public virtual DbSet<RefRestitusi> RefRestitusi { get; set; }
        public virtual DbSet<RefRoadMapPenelitian> RefRoadMapPenelitian { get; set; }
        public virtual DbSet<RefRoadMapPengabdian> RefRoadMapPengabdian { get; set; }
        public virtual DbSet<RefRole> RefRole { get; set; }
        public virtual DbSet<RefSchedule> RefSchedule { get; set; }
        public virtual DbSet<RefSettingRestitusi> RefSettingRestitusi { get; set; }
        public virtual DbSet<RefSkim> RefSkim { get; set; }
        public virtual DbSet<RefSmuSmk> RefSmuSmk { get; set; }
        public virtual DbSet<RefStatusHutang> RefStatusHutang { get; set; }
        public virtual DbSet<RefStatusKepegawaian> RefStatusKepegawaian { get; set; }
        public virtual DbSet<RefStatusIkatanKerja> RefStatusIkatanKerja { get; set; }
        public virtual DbSet<RefStatusPenelitianPengabdian> RefStatusPenelitianPengabdian { get; set; }
        public virtual DbSet<RefStatusStudi> RefStatusStudi { get; set; }
        public virtual DbSet<RefSumberBiaya> RefSumberBiaya { get; set; }
        public virtual DbSet<RefTemaUniversitas> RefTemaUniversitas { get; set; }
        public virtual DbSet<RefTrAkademik> RefTrAkademik { get; set; }
        public virtual DbSet<RefTunjanganKhusus> RefTunjanganKhusus { get; set; }
        public virtual DbSet<RefTunjanganMengajarPasca> RefTunjanganMengajarPasca { get; set; }
        public virtual DbSet<RefTunjanganTaKp> RefTunjanganTaKp { get; set; }
        public virtual DbSet<RefUniversitas> RefUniversitas { get; set; }
        public virtual DbSet<TblAppraisal> TblAppraisal { get; set; }
        public virtual DbSet<TblBiayaSlEksternal> TblBiayaSlEksternal { get; set; }
        public virtual DbSet<TblBiayaSlInternal> TblBiayaSlInternal { get; set; }
        public virtual DbSet<TblCalonKaryawan> TblCalonKaryawan { get; set; }
        public virtual DbSet<TblDetailDp3> TblDetailDp3 { get; set; }
        public virtual DbSet<TblDetailHonor> TblDetailHonor { get; set; }
        public virtual DbSet<TblDetailHutang> TblDetailHutang { get; set; }
        public virtual DbSet<TblDetailPayrollPiutang> TblDetailPayrollPiutang { get; set; }
        public virtual DbSet<TblDetailPayrollPotongan> TblDetailPayrollPotongan { get; set; }
        public virtual DbSet<TblDetailPayrollTerima> TblDetailPayrollTerima { get; set; }
        public virtual DbSet<TblDokumen> TblDokumen { get; set; }
        public virtual DbSet<TblFeedbackPenelitian> TblFeedbackPenelitian { get; set; }
        public virtual DbSet<TblFeedbackPengabdian> TblFeedbackPengabdian { get; set; }
        public virtual DbSet<TblLapMonevPenelitian> TblLapMonevPenelitian { get; set; }
        public virtual DbSet<TblLapMonevPengabdian> TblLapMonevPengabdian { get; set; }
        public virtual DbSet<TblMappingPenelitian> TblMappingPenelitian { get; set; }
        public virtual DbSet<TblMappingPengabdian> TblMappingPengabdian { get; set; }
        public virtual DbSet<TblNilaiReviewPenelitian> TblNilaiReviewPenelitian { get; set; }
        public virtual DbSet<TblNilaiReviewPengabdian> TblNilaiReviewPengabdian { get; set; }
        public virtual DbSet<TblPelaporanStudiLanjut> TblPelaporanStudiLanjut { get; set; }
        public virtual DbSet<TblPenelitian> TblPenelitian { get; set; }
        public virtual DbSet<TblPenelitianLolos> TblPenelitianLolos { get; set; }
        public virtual DbSet<TblPengabdian> TblPengabdian { get; set; }
        public virtual DbSet<TblPengabdianLolos> TblPengabdianLolos { get; set; }
        public virtual DbSet<TblPerpanjanganPenelitian> TblPerpanjanganPenelitian { get; set; }
        public virtual DbSet<TblPerpanjanganPengabdian> TblPerpanjanganPengabdian { get; set; }
        public virtual DbSet<TblPerpanjanganStudiLanjut> TblPerpanjanganStudiLanjut { get; set; }
        public virtual DbSet<TblPersonilPenelitian> TblPersonilPenelitian { get; set; }
        public virtual DbSet<TblPersonilPengabdian> TblPersonilPengabdian { get; set; }
        public virtual DbSet<TblPesertaTest> TblPesertaTest { get; set; }
        public virtual DbSet<TblRabPenelitian> TblRabPenelitian { get; set; }
        public virtual DbSet<TblRabPengabdian> TblRabPengabdian { get; set; }
        public virtual DbSet<TblRoleSubmenu> TblRoleSubmenu { get; set; }
        public virtual DbSet<TblSemesterAkademik> TblSemesterAkademik { get; set; }
        public virtual DbSet<TblSiMenu> TblSiMenu { get; set; }
       // public virtual DbSet<TblUserRole> TblUserRole { get; set; }
        public virtual DbSet<TblSistemInformasi> TblSistemInformasi { get; set; }
        public virtual DbSet<TblSiSubmenu> TblSiSubmenu { get; set; }
        public virtual DbSet<TblStudiLanjut> TblStudiLanjut { get; set; }
        public virtual DbSet<TblSumberBiayaSl> TblSumberBiayaSl { get; set; }
        public virtual DbSet<TblTahunAkademik> TblTahunAkademik { get; set; }
        public virtual DbSet<TblTahunAnggaran> TblTahunAnggaran { get; set; }
        public virtual DbSet<TblUsulanDiterima> TblUsulanDiterima { get; set; }
        public virtual DbSet<TblUsulanRekrutmen> TblUsulanRekrutmen { get; set; }
        public virtual DbSet<TrCuti> TrCuti { get; set; }
        public virtual DbSet<TrDp3> TrDp3 { get; set; }
        public virtual DbSet<TrHonor> TrHonor { get; set; }
        public virtual DbSet<TrHutangP> TrHutangP { get; set; }
        public virtual DbSet<TrKarirFungsional> TrKarirFungsional { get; set; }
       public virtual DbSet<TrKarirStruktural> TrKarirStruktural { get; set; }
        public virtual DbSet<TrKarirGolongan> TrKarirGolongan { get; set; }
        public virtual DbSet<TrKegiatan> TrKegiatan { get; set; }
        public virtual DbSet<TrKenaikanPangkat> TrKenaikanPangkat { get; set; }
        public virtual DbSet<TrKgb> TrKgb { get; set; }
        public virtual DbSet<TrMember> TrMember { get; set; }
        public virtual DbSet<TrMutasi> TrMutasi { get; set; }
        public virtual DbSet<TrPayroll> TrPayroll { get; set; }
        public virtual DbSet<TrPengembangan> TrPengembangan { get; set; }
        public virtual DbSet<TrPensiun> TrPensiun { get; set; }
        public virtual DbSet<TrRestitusi> TrRestitusi { get; set; }
        public virtual DbSet<TrRiwayatPendidikan> TrRiwayatPendidikan { get; set; }
        public virtual DbSet<TrRiwayatPendidikanDokumen> TrRiwayatPendidikanDokumen { get; set; }
        public virtual DbSet<TrSertifikasi> TrSertifikasi { get; set; }
        public virtual DbSet<TblSkKaryawan> TblSkKaryawan { get; set; }

        // Unable to generate entity type for table 'simka.TR_KARIR_SRUKTURAL'. Please see the warning messages.
        // Unable to generate entity type for table 'simka.TBL_SK_KARYAWAN'. Please see the warning messages.
        // Unable to generate entity type for table 'simka.TBL_DETAIL_APPRAISAL'. Please see the warning messages.
        // Unable to generate entity type for table 'simka.MST_TARIF_PAYROLL_DETAIL'. Please see the warning messages.
        // Unable to generate entity type for table 'simka.TBL_NILAI_DETAIL'. Please see the warning messages.
        // Unable to generate entity type for table 'siatmax.TR_PENGAKUAN'. Please see the warning messages.
        // Unable to generate entity type for table 'simka.TR_AKADEMIK'. Please see the warning messages.
        // Unable to generate entity type for table 'simka.TBL_SERTIFIKASI'. Please see the warning messages.
        // Unable to generate entity type for table 'simka.TBL_KOMPETENSI_PEGAWAI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DAILY_DATA_GROWTH_SIKEU'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DAILY_DATA_GROWTH_SIMKA'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DAILY_DATA_GROWTH_SISPRAS'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DAILY_DATA_VALIDATION'. Please see the warning messages.
        // Unable to generate entity type for table 'siatmax.TBL_USER_ROLE'. Please see the warning messages.
        // Unable to generate entity type for table 'simka.REF_JOB'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DtlBiayaSlInternal>(entity =>
            {
                entity.HasKey(e => e.IdDtlBiayaSlInt);

                entity.ToTable("DTL_BIAYA_SL_INTERNAL", "simka");

                entity.Property(e => e.IdDtlBiayaSlInt).HasColumnName("ID_DTL_BIAYA_SL_INT");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdBiayaSlInt).HasColumnName("ID_BIAYA_SL_INT");

                entity.Property(e => e.Jumlah)
                    .HasColumnName("JUMLAH")
                    .HasColumnType("money");

                entity.Property(e => e.JumlahRupiah)
                    .HasColumnName("JUMLAH_RUPIAH")
                    .HasColumnType("money");

                entity.Property(e => e.Kurs)
                    .HasColumnName("KURS")
                    .HasColumnType("money");

                entity.Property(e => e.MataUang)
                    .HasColumnName("MATA_UANG")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBiayaSlIntNavigation)
                    .WithMany(p => p.DtlBiayaSlInternal)
                    .HasForeignKey(d => d.IdBiayaSlInt)
                    .HasConstraintName("FK_DTL_BIAYA_SL_INTERNAL_TBL_BIAYA_SL_INTERNAL");
            });

            modelBuilder.Entity<DtlRabPenelitian>(entity =>
            {
                entity.HasKey(e => e.IdDtlRabPenelitian);

                entity.ToTable("DTL_RAB_PENELITIAN", "silppm");

                entity.Property(e => e.IdDtlRabPenelitian).HasColumnName("ID_DTL_RAB_PENELITIAN");

                entity.Property(e => e.HargaSatuan)
                    .HasColumnName("HARGA_SATUAN")
                    .HasColumnType("money");

                entity.Property(e => e.IdRabPenelitian).HasColumnName("ID_RAB_PENELITIAN");

                entity.Property(e => e.Jumlah).HasColumnName("JUMLAH");

                entity.Property(e => e.JumlahDana)
                    .HasColumnName("JUMLAH_DANA")
                    .HasColumnType("money");

                entity.Property(e => e.Keterangan)
                    .HasColumnName("KETERANGAN")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Satuan)
                    .HasColumnName("SATUAN")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRabPenelitianNavigation)
                    .WithMany(p => p.DtlRabPenelitian)
                    .HasForeignKey(d => d.IdRabPenelitian)
                    .HasConstraintName("FK_DTL_RAB_PENELITIAN_REF");
            });

            modelBuilder.Entity<DtlRabPengabdian>(entity =>
            {
                entity.HasKey(e => e.IdDtlRabPengabdian);

                entity.ToTable("DTL_RAB_PENGABDIAN", "silppm");

                entity.Property(e => e.IdDtlRabPengabdian).HasColumnName("ID_DTL_RAB_PENGABDIAN");

                entity.Property(e => e.HargaSatuan)
                    .HasColumnName("HARGA_SATUAN")
                    .HasColumnType("money");

                entity.Property(e => e.IdRabPengabdian).HasColumnName("ID_RAB_PENGABDIAN");

                entity.Property(e => e.Jumlah).HasColumnName("JUMLAH");

                entity.Property(e => e.JumlahDana)
                    .HasColumnName("JUMLAH_DANA")
                    .HasColumnType("money");

                entity.Property(e => e.Keterangan)
                    .HasColumnName("KETERANGAN")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Satuan)
                    .HasColumnName("SATUAN")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRabPengabdianNavigation)
                    .WithMany(p => p.DtlRabPengabdian)
                    .HasForeignKey(d => d.IdRabPengabdian)
                    .HasConstraintName("FK_DTL_RAB_PENGABDIAN_REF");
            });

            modelBuilder.Entity<HstSk>(entity =>
            {
                entity.HasKey(e => e.NoSk);

                entity.ToTable("HST_SK", "simka");

                entity.HasIndex(e => new { e.NoSemester, e.IdTahunAkademik })
                    .HasName("RELATION_238_FK");

                entity.Property(e => e.NoSk)
                    .HasColumnName("NO_SK")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateInserted)
                    .HasColumnName("DATE_INSERTED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeskripsiSk)
                    .HasColumnName("DESKRIPSI_SK")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FileSk)
                    .HasColumnName("FILE_SK")
                    .HasColumnType("image");

                entity.Property(e => e.IdRefJenisSk).HasColumnName("ID_REF_JENIS_SK");

                entity.Property(e => e.IdTahunAkademik).HasColumnName("ID_TAHUN_AKADEMIK");

                entity.Property(e => e.LevelSk)
                    .HasColumnName("LEVEL_SK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoSemester).HasColumnName("NO_SEMESTER");

                entity.Property(e => e.TglAkhir)
                    .HasColumnName("TGL_AKHIR")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglAwal)
                    .HasColumnName("TGL_AWAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglSk)
                    .HasColumnName("TGL_SK")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdRefJenisSkNavigation)
                    .WithMany(p => p.HstSk)
                    .HasForeignKey(d => d.IdRefJenisSk)
                    .HasConstraintName("FK_HST_SK_REF_JENIS_SK");
            });

            modelBuilder.Entity<KabKodya>(entity =>
            {
                entity.HasKey(e => e.IdKabKodya);

                entity.ToTable("KAB_KODYA", "siatmax");

                entity.Property(e => e.IdKabKodya)
                    .HasColumnName("ID_KAB_KODYA")
                    .HasColumnType("decimal(4, 0)");

                entity.Property(e => e.IdPropinsi)
                    .HasColumnName("ID_PROPINSI")
                    .HasColumnType("decimal(4, 0)");

                entity.Property(e => e.NamaKabKodya)
                    .HasColumnName("NAMA_KAB_KODYA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPropinsiNavigation)
                    .WithMany(p => p.KabKodya)
                    .HasForeignKey(d => d.IdPropinsi)
                    .HasConstraintName("FK_KAB_KODYA_PROPINSI");
            });

            modelBuilder.Entity<MstAsuransi>(entity =>
            {
                entity.HasKey(e => e.NoAsuransi);

                entity.ToTable("MST_ASURANSI", "simka");

                entity.Property(e => e.NoAsuransi)
                    .HasColumnName("NO_ASURANSI")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaInstitusi)
                    .HasColumnName("NAMA_INSTITUSI")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasColumnType("char(10)");

                entity.Property(e => e.TglBergabung)
                    .HasColumnName("TGL_BERGABUNG")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.MstAsuransi)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATION_991");
            });

            modelBuilder.Entity<MstDosenLuar>(entity =>
            {
                entity.HasKey(e => e.Npp);

                entity.ToTable("MST_DOSEN_LUAR", "simka");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.CurrentStatus)
                    .HasColumnName("CURRENT_STATUS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FileFoto)
                    .HasColumnName("FILE_FOTO")
                    .HasColumnType("image");

                entity.Property(e => e.IdFakultas).HasColumnName("ID_FAKULTAS");

                entity.Property(e => e.IdProdi)
                    .HasColumnName("ID_PRODI")
                    .HasMaxLength(2);

                entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT");

                entity.Property(e => e.IsCurrent).HasColumnName("IS_CURRENT");

                entity.Property(e => e.Nama)
                    .HasColumnName("NAMA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NamaLengkapGelar)
                    .HasColumnName("NAMA_LENGKAP_GELAR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nidn)
                    .HasColumnName("NIDN")
                    .HasColumnType("char(15)");

                entity.Property(e => e.Nik)
                    .HasColumnName("NIK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NipPns)
                    .HasColumnName("NIP_PNS")
                    .HasColumnType("char(15)");

                entity.Property(e => e.NoKtp)
                    .HasColumnName("NO_KTP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Npwp)
                    .HasColumnName("NPWP")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password1)
                    .HasColumnName("PASSWORD1")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Warganegara)
                    .HasColumnName("WARGANEGARA")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstKaryawan>(entity =>
            {
                entity.HasKey(e => e.Npp);

                entity.ToTable("MST_KARYAWAN", "simka");

                entity.HasIndex(e => e.IdRefFungsional)
                    .HasName("RELATION_104_FK");

                entity.HasIndex(e => e.IdRefGolongan)
                    .HasName("RELATION_616_FK");

                entity.HasIndex(e => e.IdRefJbtnAkademik)
                    .HasName("RELATION_617_FK");

                entity.HasIndex(e => e.IdUnit)
                    .HasName("RELATION_127_FK");

                entity.HasIndex(e => e.MstIdUnit)
                    .HasName("RELATION_128_FK");
                entity.HasIndex(e => e.IdUnitAkademik)
                 .HasName("RELATION_245_FK");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Agama)
                    .HasColumnName("AGAMA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Alamat)
                    .HasColumnName("ALAMAT")
                    .IsUnicode(false);

                entity.Property(e => e.AlamatDomisili)
                    .HasColumnName("ALAMAT_DOMISILI")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.AlamatKodepos)
                    .HasColumnName("ALAMAT_KODEPOS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AlamatKota)
                    .HasColumnName("ALAMAT_KOTA")
                    .IsUnicode(false);

                entity.Property(e => e.AlamatProvinsi)
                    .HasColumnName("ALAMAT_PROVINSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BiografiSingkat)
                    .HasColumnName("BIOGRAFI_SINGKAT")
                    .HasColumnType("text");

                //entity.Property(e => e.CurrentStatus)
                //    .HasColumnName("CURRENT_STATUS")
                //    .HasMaxLength(20)
                //    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailInstitusi)
                    .HasColumnName("EMAIL_INSTITUSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

              
                entity.Property(e => e.GelarBelakang)
                    .HasColumnName("GELAR_BELAKANG")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.GelarDepan)
                    .HasColumnName("GELAR_DEPAN")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.GolDarah)
                    .HasColumnName("GOL_DARAH")
                    .HasColumnType("char(3)");
                entity.Property(e => e.Password1)
                   .HasColumnName("PASSWORD1")
                   .HasMaxLength(50);

                entity.Property(e => e.FileAsuransi)
                                  .HasColumnName("FILE_ASURANSI")
                                  .HasColumnType("image");

                entity.Property(e => e.FileFoto)
                    .HasColumnName("FILE_FOTO")
                    .HasColumnType("image");

                entity.Property(e => e.FileKartuPegawai)
                    .HasColumnName("FILE_KARTU_PEGAWAI")
                    .HasColumnType("image");

                entity.Property(e => e.FileKtp)
                    .HasColumnName("FILE_KTP")
                    .HasColumnType("image");

                entity.Property(e => e.FileNpwp)
                    .HasColumnName("FILE_NPWP")
                    .HasColumnType("image");

                entity.Property(e => e.FileSertifikasiPendidik)
                    .HasColumnName("FILE_SERTIFIKASI_PENDIDIK")
                    .HasColumnType("image");

                entity.Property(e => e.FileTtd)
                    .HasColumnName("FILE_TTD")
                    .HasColumnType("image");

                entity.Property(e => e.IdRefFungsional).HasColumnName("ID_REF_FUNGSIONAL");

                entity.Property(e => e.IdRefGolongan)
                    .HasColumnName("ID_REF_GOLONGAN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefGolonganLokal)
                    .HasColumnName("ID_REF_GOLONGAN_LOKAL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefJbtnAkademik).HasColumnName("ID_REF_JBTN_AKADEMIK");

                entity.Property(e => e.IdRefJbtnAkademikLokal).HasColumnName("ID_REF_JBTN_AKADEMIK_LOKAL");

                entity.Property(e => e.IdRefJob).HasColumnName("ID_REF_JOB");

                entity.Property(e => e.IdRefTunjanganKhusus).HasColumnName("ID_REF_TUNJANGAN_KHUSUS");

                entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT");

                entity.Property(e => e.IdUnitAkademik).HasColumnName("ID_UNIT_AKADEMIK");

                entity.Property(e => e.IdUnitAkademikEpsbed).HasColumnName("ID_UNIT_AKADEMIK_EPSBED");

                entity.Property(e => e.Inisial)
                    .HasColumnName("INISIAL")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.JnsKel)
                    .HasColumnName("JNS_KEL")
                    .HasColumnType("char(1)");

                entity.Property(e => e.MstIdUnit).HasColumnName("MST_ID_UNIT");

                entity.Property(e => e.Nama)
                    .HasColumnName("NAMA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NamaLengkapGelar)
                    .HasColumnName("NAMA_LENGKAP_GELAR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NamaSingkat)
                    .HasColumnName("NAMA_SINGKAT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasColumnName("NICKNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nidn)
                    .HasColumnName("NIDN")
                    .HasColumnType("char(15)");

                entity.Property(e => e.Nik)
                    .HasColumnName("NIK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NipPns)
                    .HasColumnName("NIP_PNS")
                    .HasColumnType("char(15)");

                entity.Property(e => e.NoBpjs)
                    .HasColumnName("no_bpjs")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoKtp)
                    .HasColumnName("NO_KTP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoPaspor)
                    .HasColumnName("NO_PASPOR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoSertifikatPendidik)
                    .HasColumnName("NO_SERTIFIKAT_PENDIDIK")
                    .HasColumnType("char(25)");

                entity.Property(e => e.NoTelponHp)
                    .HasColumnName("NO_TELPON_HP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelponRumah)
                    .HasColumnName("NO_TELPON_RUMAH")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NppManager)
                    .HasColumnName("NPP_MANAGER")
                    .HasMaxLength(10);

                entity.Property(e => e.Npwp)
                    .HasColumnName("NPWP")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nupn)
                    .HasColumnName("NUPN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            

                entity.Property(e => e.PendidikanDiakui)
                    .HasColumnName("PENDIDIKAN_DIAKUI")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PendidikanTerakhir)
                    .HasColumnName("PENDIDIKAN_TERAKHIR")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Ptkp).HasColumnName("PTKP");

                entity.Property(e => e.StatusFungsional)
                    .HasColumnName("STATUS_FUNGSIONAL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusAktifitas)
                   .HasColumnName("CURRENT_STATUS")
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.StatusKepegawaian)
                    .HasColumnName("STATUS_AKTIFITAS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusIkatanKerja)
                    .HasColumnName("STATUS_KEPEGAWAIAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusPtkp)
                    .HasColumnName("STATUS_PTKP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRestitusi)
                    .HasColumnName("STATUS_RESTITUSI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusSipil)
                    .HasColumnName("STATUS_SIPIL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TempatLahir)
                    .HasColumnName("TEMPAT_LAHIR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TglAkhirBerlakuKtp)
                    .HasColumnName("TGL_AKHIR_BERLAKU_KTP")
                    .HasColumnType("date");

                entity.Property(e => e.TglAkhirKtp)
                    .HasColumnName("TGL_AKHIR_KTP")
                    .HasColumnType("date");

                entity.Property(e => e.TglAkhirPaspor)
                    .HasColumnName("TGL_AKHIR_PASPOR")
                    .HasColumnType("date");

                entity.Property(e => e.TglLahir)
                    .HasColumnName("TGL_LAHIR")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglMasuk)
                    .HasColumnName("TGL_MASUK")
                    .HasColumnType("datetime");

                entity.Property(e => e.TmtAkhir)
                    .HasColumnName("TMT_AKHIR")
                    .HasColumnType("numeric(6, 2)");

                entity.Property(e => e.TmtAkhirLokal)
                    .HasColumnName("TMT_AKHIR_LOKAL")
                    .HasColumnType("numeric(6, 2)");

                entity.Property(e => e.TmtPurnakarya)
                    .HasColumnName("TMT_PURNAKARYA")
                    .HasColumnType("date");

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Warganegara)
                    .HasColumnName("WARGANEGARA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRefFungsionalNavigation)
                    .WithMany(p => p.MstKaryawan)
                    .HasForeignKey(d => d.IdRefFungsional)
                    .HasConstraintName("FK_RELATION_104");

                entity.HasOne(d => d.IdRefGolonganNavigation)
                    .WithMany(p => p.MstKaryawan)
                    .HasForeignKey(d => d.IdRefGolongan)
                    .HasConstraintName("FK_RELATION_616");

                entity.HasOne(d => d.IdRefJbtnAkademikNavigation)
                    .WithMany(p => p.MstKaryawan)
                    .HasForeignKey(d => d.IdRefJbtnAkademik)
                    .HasConstraintName("FK_RELATION_617");

                entity.HasOne(d => d.IdRefTunjanganKhususNavigation)
                    .WithMany(p => p.MstKaryawan)
                    .HasForeignKey(d => d.IdRefTunjanganKhusus)
                    .HasConstraintName("FK_MST_KARYAWAN_REF_TUNJANGAN_KHUSUS");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.MstKaryawanIdUnitNavigation)
                    .HasForeignKey(d => d.IdUnit)
                    .HasConstraintName("FK_RELATION_127");

                entity.HasOne(d => d.MstIdUnitNavigation)
                    .WithMany(p => p.MstKaryawanMstIdUnitNavigation)
                    .HasForeignKey(d => d.MstIdUnit)
                    .HasConstraintName("FK_RELATION_128");

                entity.HasOne(d => d.MstIdUnitAkademikNavigation)
                    .WithMany(p => p.MstKaryawanMstIdUnitAkademikNavigation)
                    .HasForeignKey(d => d.IdUnitAkademik)
                    .HasConstraintName("FK_RELATION_129");

                entity.Property(e => e.PASSWORD_RIPEM)
                    .HasColumnName("PASSWORD_RIPEM")
                    .HasMaxLength(50);

                entity.Property(e => e.UUID_LUPA_PWD)
                     .HasColumnName("UUID_LUPA_PWD")
                     .HasMaxLength(100);
                entity.Property(e => e.MASA_KERJA_GOLONGAN)
                     .HasColumnName("MASA_KERJA_GOLONGAN")
                     .HasColumnType("int");

                entity.Property(e => e.TMT_GOLONGAN)
                     .HasColumnName("TMT_GOLONGAN")
                     .HasColumnType("date");

                entity.Property(e => e.STATUS_YADAPEN)
                     .HasColumnName("STATUS_YADAPEN")
                     .HasColumnType("bool");

                entity.Property(e => e.ID_UNIT_ENTRYPASS)
                     .HasColumnName("ID_UNIT_ENTRYPASS")
                     .HasColumnType("int");

                entity.Property(e => e.NIDK)
                     .HasColumnName("NIDK")
                     .HasMaxLength(15);
            });

            modelBuilder.Entity<MstKeluarga>(entity =>
            {
                entity.HasKey(e => e.IdKeluarga);

                entity.ToTable("MST_KELUARGA", "simka");

                entity.HasIndex(e => e.IdRefKeluarga)
                    .HasName("RELATION_82_FK");

                entity.HasIndex(e => e.Npp)
                    .HasName("RELATION_81_FK");

                entity.Property(e => e.IdKeluarga).HasColumnName("ID_KELUARGA");

                entity.Property(e => e.FileFoto)
                    .HasColumnName("FILE_FOTO")
                    .HasColumnType("image");

                entity.Property(e => e.FileSurat)
                    .HasColumnName("FILE_SURAT")
                    .HasColumnType("image");

                entity.Property(e => e.GolDarah)
                    .HasColumnName("GOL_DARAH")
                    .HasColumnType("char(3)");

                entity.Property(e => e.IdRefKeluarga).HasColumnName("ID_REF_KELUARGA");

                entity.Property(e => e.IsTanggung).HasColumnName("IS_TANGGUNG");

                entity.Property(e => e.IsTanggungYadapen).HasColumnName("IS_TANGGUNG_YADAPEN");

                entity.Property(e => e.JnsKel)
                    .HasColumnName("JNS_KEL")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Nama)
                    .HasColumnName("NAMA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.StatusSipil)
                    .HasColumnName("STATUS_SIPIL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TempatLahir)
                    .HasColumnName("TEMPAT_LAHIR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TglLahir)
                    .HasColumnName("TGL_LAHIR")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdRefKeluargaNavigation)
                    .WithMany(p => p.MstKeluarga)
                    .HasForeignKey(d => d.IdRefKeluarga)
                    .HasConstraintName("FK_RELATION_82");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.MstKeluarga)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATION_81");
            });

            modelBuilder.Entity<MstRekanan>(entity =>
            {
                entity.HasKey(e => e.IdMstRekanan);

                entity.ToTable("MST_REKANAN", "simka");

                entity.Property(e => e.IdMstRekanan)
                    .HasColumnName("ID_MST_REKANAN")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasColumnName("ALAMAT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAktif).HasColumnName("IS_AKTIF");

                entity.Property(e => e.Jenis)
                    .HasColumnName("JENIS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Kodepos)
                    .HasColumnName("KODEPOS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KontakPerson)
                    .HasColumnName("KONTAK_PERSON")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kota)
                    .HasColumnName("KOTA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaRekanan)
                    .HasColumnName("NAMA_REKANAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("NO_HP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelp)
                    .HasColumnName("NO_TELP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Npwp)
                    .HasColumnName("NPWP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMstRekananNavigation)
                    .WithOne(p => p.InverseIdMstRekananNavigation)
                    .HasForeignKey<MstRekanan>(d => d.IdMstRekanan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MST_REKANAN_MST_REKANAN1");
            });

            modelBuilder.Entity<MstRekening>(entity =>
            {
                entity.HasKey(e => e.NoRekening);

                entity.ToTable("MST_REKENING", "simka");

                entity.HasIndex(e => e.Npp)
                    .HasName("RELATION_99_FK");

                entity.Property(e => e.NoRekening)
                    .HasColumnName("NO_REKENING")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaBank)
                    .HasColumnName("NAMA_BANK")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasColumnType("char(10)");

                entity.Property(e => e.StatusRekening)
                    .HasColumnName("STATUS_REKENING")
                    .HasColumnType("char(10)");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.MstRekening)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATION_99");
            });

            modelBuilder.Entity<MstTarifPayroll>(entity =>
            {
                entity.HasKey(e => e.IdMstTarifPayroll);

                entity.ToTable("MST_TARIF_PAYROLL", "simka");

                entity.HasIndex(e => e.IdRefFungsional)
                    .HasName("RELATION_4045_FK");

                entity.HasIndex(e => e.IdRefGolongan)
                    .HasName("RELATION_4044_FK");

                entity.HasIndex(e => e.IdRefJbtnAkademik)
                    .HasName("RELATION_4043_FK");

                entity.HasIndex(e => e.IdRefJenjang)
                    .HasName("RELATION_4046_FK");

                entity.Property(e => e.IdMstTarifPayroll).HasColumnName("ID_MST_TARIF_PAYROLL");

                entity.Property(e => e.IdRefFungsional).HasColumnName("ID_REF_FUNGSIONAL");

                entity.Property(e => e.IdRefGolongan)
                    .HasColumnName("ID_REF_GOLONGAN")
                    .HasColumnType("char(10)");

                entity.Property(e => e.IdRefJbtnAkademik).HasColumnName("ID_REF_JBTN_AKADEMIK");

                entity.Property(e => e.IdRefJenjang).HasColumnName("ID_REF_JENJANG");

                entity.Property(e => e.IdRefStruktural).HasColumnName("ID_REF_STRUKTURAL");

                entity.Property(e => e.IdRefTunjanganKhusus).HasColumnName("ID_REF_TUNJANGAN_KHUSUS");

                entity.Property(e => e.IdRefTunjanganPasca).HasColumnName("ID_REF_TUNJANGAN_PASCA");

                entity.Property(e => e.IdRefTunjanganTaKp).HasColumnName("ID_REF_TUNJANGAN_TA_KP");

                entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");

                entity.Property(e => e.Jenis)
                    .HasColumnName("JENIS")
                    .HasColumnType("char(30)");

                entity.Property(e => e.JenjangKelas)
                    .HasColumnName("JENJANG_KELAS")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Ket1)
                    .HasColumnName("ket1")
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Masakerja)
                    .HasColumnName("MASAKERJA")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.NamaTarifPayroll)
                    .HasColumnName("NAMA_TARIF_PAYROLL")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Nominal)
                    .HasColumnName("NOMINAL")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdRefTunjanganKhususNavigation)
                    .WithMany(p => p.MstTarifPayroll)
                    .HasForeignKey(d => d.IdRefTunjanganKhusus)
                    .HasConstraintName("FK_MST_TARIF_PAYROLL_REF_TUNJANGAN_KHUSUS");

                entity.HasOne(d => d.IdRefTunjanganPascaNavigation)
                    .WithMany(p => p.MstTarifPayroll)
                    .HasForeignKey(d => d.IdRefTunjanganPasca)
                    .HasConstraintName("FK_MST_TARIF_PAYROLL_REF_TUNJANGAN_MENGAJAR_PASCA");

                entity.HasOne(d => d.IdRefTunjanganTaKpNavigation)
                    .WithMany(p => p.MstTarifPayroll)
                    .HasForeignKey(d => d.IdRefTunjanganTaKp)
                    .HasConstraintName("FK_MST_TARIF_PAYROLL_REF_TUNJANGAN_TA_KP");

                entity.HasOne(d => d.IdRefJabatanAkademikNavigation)
                      .WithMany(p => p.MstTarifPayrolls)
                      .HasForeignKey(d => d.IdRefJbtnAkademik)
                      .HasConstraintName("FK_MST_TARIF_PAYROLL_REF_JBTNAKADEMIIK");

                entity.HasOne(d => d.IdRefJabatanStrukturalNavigation)
                     .WithMany(p => p.MstPayrolls)
                     .HasForeignKey(d => d.IdRefStruktural)
                     .HasConstraintName("FK_MST_TARIF_PAYROLL_REF_Struktural");

                entity.HasOne(d => d.IdRefFungsionalNavigation)
                    .WithMany(p => p.MstPayrolls)
                    .HasForeignKey(d => d.IdRefFungsional)
                    .HasConstraintName("FK_MST_TARIF_PAYROLL_REF_FUNGSIONAL");

                entity.HasOne(d => d.IdRefGolonganNavigation)
                    .WithMany(p => p.MstTarifPayrolls)
                    .HasForeignKey(d => d.IdRefGolongan)
                    .HasConstraintName("FK_MST_TARIF_PAYROLL_REF_Golongan");

                entity.HasOne(d => d.idRefJenjangNavigation)
                    .WithMany(p => p.MstTarifPayrolls)
                    .HasForeignKey(d => d.IdRefJenjang)
                    .HasConstraintName("FK_MST_TARIF_PAYROLL_REF_Jenjang");




            });

            modelBuilder.Entity<MstUnit>(entity =>
            {
                entity.HasKey(e => e.IdUnit);

                entity.ToTable("MST_UNIT", "siatmax");

                entity.HasIndex(e => e.MstIdUnit)
                    .HasName("RELATION_125_FK");

                entity.HasIndex(e => e.Npp)
                    .HasName("RELATION_202_FK");

                entity.Property(e => e.IdUnit)
                    .HasColumnName("ID_UNIT")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmiSpko).HasColumnName("EMI_SPKO");

                entity.Property(e => e.EmiUnit).HasColumnName("EMI_UNIT");

                entity.Property(e => e.HirarkiBiKeu).HasColumnName("HIRARKI_BI_KEU");

                entity.Property(e => e.IdCoaKas)
                    .HasColumnName("ID_COA_KAS")
                    .HasColumnType("char(15)");

                entity.Property(e => e.IdFakultas).HasColumnName("ID_FAKULTAS");

                entity.Property(e => e.IdRefStruktural).HasColumnName("ID_REF_STRUKTURAL");

                entity.Property(e => e.ImgTtdPejabat)
                    .HasColumnName("IMG_TTD_PEJABAT")
                    .HasColumnType("image");

                entity.Property(e => e.IsDeleted).HasColumnName("IS_DELETED");

                entity.Property(e => e.IsInternasional).HasColumnName("IS_INTERNASIONAL");

                entity.Property(e => e.IsPalsu).HasColumnName("IS_PALSU");

                entity.Property(e => e.KodeSatuanKerja)
                    .HasColumnName("KODE_SATUAN_KERJA")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.KodeUnit)
                    .HasColumnName("KODE_UNIT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Level).HasColumnName("LEVEL");

                entity.Property(e => e.MstIdUnit).HasColumnName("MST_ID_UNIT");

                entity.Property(e => e.NamaUnit)
                    .IsRequired()
                    .HasColumnName("NAMA_UNIT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NamaUnitEn)
                    .HasColumnName("NAMA_UNIT_EN")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.PenanggungJwbSikeu).HasColumnName("PENANGGUNG_JWB_SIKEU");

                entity.Property(e => e.PersenPj)
                    .HasColumnName("PERSEN_PJ")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdRefStrukturalNavigation)
                    .WithMany(p => p.MstUnit)
                    .HasForeignKey(d => d.IdRefStruktural)
                    .HasConstraintName("FK_MST_UNIT_REF_JABATAN_STRUKTURAL");

                entity.HasOne(d => d.MstIdUnitNavigation)
                    .WithMany(p => p.InverseMstIdUnitNavigation)
                    .HasForeignKey(d => d.MstIdUnit)
                    .HasConstraintName("FK_RELATION_125");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.MstUnit)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATION_202");
            });

            modelBuilder.Entity<MstUnitAkademik>(entity =>
            {
                entity.HasKey(e => e.IdUnit);

                entity.ToTable("MST_UNIT_AKADEMIK", "siatma");

                entity.Property(e => e.IdUnit)
                    .HasColumnName("ID_UNIT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasColumnName("ALAMAT")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Gelar)
                    .HasColumnName("GELAR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JenisUnitAkademik)
                    .HasColumnName("JENIS_UNIT_AKADEMIK")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Jenjang)
                    .HasColumnName("JENJANG")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KodeUaDikti)
                    .HasColumnName("KODE_UA_DIKTI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KodeUnitAkademik)
                    .HasColumnName("KODE_UNIT_AKADEMIK")
                    .HasColumnType("char(5)");

                entity.Property(e => e.MstIdUnit).HasColumnName("MST_ID_UNIT");

                entity.Property(e => e.NamaUnitAkademik)
                    .IsRequired()
                    .HasColumnName("NAMA_UNIT_AKADEMIK")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NoFax)
                    .HasColumnName("NO_FAX")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelp)
                    .HasColumnName("NO_TELP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SingkatanGelar)
                    .HasColumnName("SINGKATAN_GELAR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithOne(p => p.MstUnitAkademik)
                    .HasForeignKey<MstUnitAkademik>(d => d.IdUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MST_UNIT_AKADEMIK_MST_UNIT");
            });

            modelBuilder.Entity<Propinsi>(entity =>
            {
                entity.HasKey(e => e.IdPropinsi);

                entity.ToTable("PROPINSI", "siatmax");

                entity.Property(e => e.IdPropinsi)
                    .HasColumnName("ID_PROPINSI")
                    .HasColumnType("decimal(4, 0)");

                entity.Property(e => e.NamaPropinsi)
                    .HasColumnName("NAMA_PROPINSI")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefButirAppraisal>(entity =>
            {
                entity.HasKey(e => e.IdRefAppraisal);

                entity.ToTable("REF_BUTIR_APPRAISAL", "simka");

                entity.HasIndex(e => e.IdRefFungsional)
                    .HasName("RELATION_154_FK");

                entity.HasIndex(e => e.IdRefJnsAppraisal)
                    .HasName("RELATION_147_FK");

                entity.Property(e => e.IdRefAppraisal).HasColumnName("ID_REF_APPRAISAL");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefFungsional).HasColumnName("ID_REF_FUNGSIONAL");

                entity.Property(e => e.IdRefJnsAppraisal).HasColumnName("ID_REF_JNS_APPRAISAL");

                entity.HasOne(d => d.IdRefFungsionalNavigation)
                    .WithMany(p => p.RefButirAppraisal)
                    .HasForeignKey(d => d.IdRefFungsional)
                    .HasConstraintName("FK_RELATION_154");

                entity.HasOne(d => d.IdRefJnsAppraisalNavigation)
                    .WithMany(p => p.RefButirAppraisal)
                    .HasForeignKey(d => d.IdRefJnsAppraisal)
                    .HasConstraintName("FK_RELATION_147");
            });

            modelBuilder.Entity<RefCuti>(entity =>
            {
                entity.HasKey(e => e.IdRefCuti);

                entity.ToTable("REF_CUTI", "simka");

                entity.Property(e => e.IdRefCuti).HasColumnName("ID_REF_CUTI");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefDp3>(entity =>
            {
                entity.HasKey(e => e.IdRefDp3);

                entity.ToTable("REF_DP3", "simka");

                entity.Property(e => e.IdRefDp3).HasColumnName("ID_REF_DP3");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefFungsional>(entity =>
            {
                entity.HasKey(e => e.IdRefFungsional);

                entity.ToTable("REF_FUNGSIONAL", "simka");

                entity.Property(e => e.IdRefFungsional).HasColumnName("ID_REF_FUNGSIONAL");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsiaPensiun).HasColumnName("USIA_PENSIUN");
            });

            modelBuilder.Entity<RefGolongan>(entity =>
            {
                entity.HasKey(e => e.IdRefGolongan);

                entity.ToTable("REF_GOLONGAN", "simka");

                entity.Property(e => e.IdRefGolongan)
                    .HasColumnName("ID_REF_GOLONGAN")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefJabatanAkademik>(entity =>
            {
                entity.HasKey(e => e.IdRefJbtnAkademik);

                entity.ToTable("REF_JABATAN_AKADEMIK", "simka");

                entity.Property(e => e.IdRefJbtnAkademik).HasColumnName("ID_REF_JBTN_AKADEMIK");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefFungsional).HasColumnName("ID_REF_FUNGSIONAL");

                entity.Property(e => e.UsiaPensiun).HasColumnName("USIA_PENSIUN");

                entity.HasOne(d => d.IdRefFungsionalNavigation)
                    .WithMany(p => p.RefJabatanAkademik)
                    .HasForeignKey(d => d.IdRefFungsional)
                    .HasConstraintName("FK_REF_JABATAN_AKADEMIK_REF_FUNGSIONAL");
            });

            modelBuilder.Entity<RefJabatanStruktural>(entity =>
            {
                entity.HasKey(e => e.IdRefStruktural);

                entity.ToTable("REF_JABATAN_STRUKTURAL", "simka");

                entity.Property(e => e.IdRefStruktural).HasColumnName("ID_REF_STRUKTURAL");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KelasAsuransi).HasColumnName("KELAS_ASURANSI");

                entity.Property(e => e.SetaraSks).HasColumnName("SETARA_SKS");
            });

            modelBuilder.Entity<RefJenisAppraisal>(entity =>
            {
                entity.HasKey(e => e.IdRefJnsAppraisal);

                entity.ToTable("REF_JENIS_APPRAISAL", "simka");

                entity.Property(e => e.IdRefJnsAppraisal).HasColumnName("ID_REF_JNS_APPRAISAL");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefJenisDokumen>(entity =>
            {
                entity.HasKey(e => e.IdJenisDokumen);

                entity.ToTable("REF_JENIS_DOKUMEN", "simka");

                entity.Property(e => e.IdJenisDokumen).HasColumnName("ID_JENIS_DOKUMEN");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsStudiLanjut).HasColumnName("IS_STUDI_LANJUT");
            });

            modelBuilder.Entity<RefJenisKelas>(entity =>
            {
                entity.HasKey(e => e.IdRefJenisKelas);

                entity.ToTable("REF_JENIS_KELAS", "simka");

                entity.Property(e => e.IdRefJenisKelas).HasColumnName("ID_REF_JENIS_KELAS");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefJenisSemester>(entity =>
            {
                entity.HasKey(e => e.IdRefJenisSemester);

                entity.ToTable("REF_JENIS_SEMESTER", "simka");

                entity.Property(e => e.IdRefJenisSemester).HasColumnName("ID_REF_JENIS_SEMESTER");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefJenisSk>(entity =>
            {
                entity.HasKey(e => e.IdRefJenisSk);

                entity.ToTable("REF_JENIS_SK", "simka");

                entity.Property(e => e.IdRefJenisSk).HasColumnName("ID_REF_JENIS_SK");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefJenisTest>(entity =>
            {
                entity.HasKey(e => e.IdRefJenisTest);

                entity.ToTable("REF_JENIS_TEST", "simka");

                entity.Property(e => e.IdRefJenisTest).HasColumnName("ID_REF_JENIS_TEST");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefStatusIkatanKerja>(entity =>
            {
                entity.HasKey(e => e.ID_REF_STATUS_IKATAN_KRJ);

                entity.ToTable("REF_STATUS_IKATAN_KRJ", "simka");

                entity.Property(e => e.ID_REF_STATUS_IKATAN_KRJ).HasColumnName("ID_REF_STATUS_IKATAN_KRJ");

                entity.Property(e => e.STATUS_IKATAN_KRJ)
                    .HasColumnName("STATUS_IKATAN_KRJ")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefJenisTestDetail>(entity =>
            {
                entity.HasKey(e => e.IdRefJenisTestDetail);

                entity.ToTable("REF_JENIS_TEST_DETAIL", "simka");

                entity.HasIndex(e => e.IdRefJenisTest)
                    .HasName("RELATION_312_FK");

                entity.Property(e => e.IdRefJenisTestDetail).HasColumnName("ID_REF_JENIS_TEST_DETAIL");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefJenisTest).HasColumnName("ID_REF_JENIS_TEST");

                entity.HasOne(d => d.IdRefJenisTestNavigation)
                    .WithMany(p => p.RefJenisTestDetail)
                    .HasForeignKey(d => d.IdRefJenisTest)
                    .HasConstraintName("FK_RELATION_312");
            });

            modelBuilder.Entity<RefJenjang>(entity =>
            {
                entity.HasKey(e => e.IdRefJenjang);

                entity.ToTable("REF_JENJANG", "simka");

                entity.Property(e => e.IdRefJenjang).HasColumnName("ID_REF_JENJANG");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefKabKodya>(entity =>
            {
                entity.HasKey(e => e.IdRefKabKodya);

                entity.ToTable("REF_KAB_KODYA", "siatmax");

                entity.Property(e => e.IdRefKabKodya).HasColumnName("ID_REF_KAB_KODYA");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(255);

                entity.Property(e => e.IdRefPropinsi).HasColumnName("ID_REF_PROPINSI");

                entity.HasOne(d => d.IdRefPropinsiNavigation)
                    .WithMany(p => p.RefKabKodya)
                    .HasForeignKey(d => d.IdRefPropinsi)
                    .HasConstraintName("FK_RELATION_1156");
            });

            modelBuilder.Entity<RefKategori>(entity =>
            {
                entity.HasKey(e => e.IdKategori);

                entity.ToTable("REF_KATEGORI", "silppm");

                entity.Property(e => e.IdKategori)
                    .HasColumnName("ID_KATEGORI")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DetailBebanSks)
                    .HasColumnName("DETAIL_BEBAN_SKS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DetailPelaku)
                    .HasColumnName("DETAIL_PELAKU")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsCurrent).HasColumnName("IS_CURRENT");

                entity.Property(e => e.Kategori)
                    .HasColumnName("KATEGORI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefKecamatan>(entity =>
            {
                entity.HasKey(e => e.IdRefKecamatan);

                entity.ToTable("REF_KECAMATAN", "siatmax");

                entity.Property(e => e.IdRefKecamatan).HasColumnName("ID_REF_KECAMATAN");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(150);

                entity.Property(e => e.IdRefKabKodya).HasColumnName("ID_REF_KAB_KODYA");

                entity.HasOne(d => d.IdRefKabKodyaNavigation)
                    .WithMany(p => p.RefKecamatan)
                    .HasForeignKey(d => d.IdRefKabKodya)
                    .HasConstraintName("FK_RELATION_1965");
            });

            modelBuilder.Entity<RefKegiatan>(entity =>
            {
                entity.HasKey(e => e.IdRefKegiatan);

                entity.ToTable("REF_KEGIATAN", "simka");

                entity.Property(e => e.IdRefKegiatan).HasColumnName("ID_REF_KEGIATAN");

                entity.Property(e => e.Deskripsi).HasColumnName("DESKRIPSI");
            });

            modelBuilder.Entity<RefKeluarga>(entity =>
            {
                entity.HasKey(e => e.IdRefKeluarga);

                entity.ToTable("REF_KELUARGA", "simka");

                entity.Property(e => e.IdRefKeluarga).HasColumnName("ID_REF_KELUARGA");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefKelurahan>(entity =>
            {
                entity.HasKey(e => e.IdRefKelurahan);

                entity.ToTable("REF_KELURAHAN", "siatmax");

                entity.Property(e => e.IdRefKelurahan).HasColumnName("ID_REF_KELURAHAN");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefKecamatan).HasColumnName("ID_REF_KECAMATAN");

                entity.HasOne(d => d.IdRefKecamatanNavigation)
                    .WithMany(p => p.RefKelurahan)
                    .HasForeignKey(d => d.IdRefKecamatan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATION_1986");
            });

            modelBuilder.Entity<RefKompetensi>(entity =>
            {
                entity.HasKey(e => e.IdRefKompetensi);

                entity.ToTable("REF_KOMPETENSI", "simka");

                entity.Property(e => e.IdRefKompetensi).HasColumnName("ID_REF_KOMPETENSI");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefNegara>(entity =>
            {
                entity.HasKey(e => e.IdRefNegara);

                entity.ToTable("REF_NEGARA", "siatmax");

                entity.Property(e => e.IdRefNegara).HasColumnName("ID_REF_NEGARA");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.KodeIso2)
                    .HasColumnName("KODE_ISO_2")
                    .HasColumnType("char(5)");

                entity.Property(e => e.KodeIso3)
                    .HasColumnName("KODE_ISO_3")
                    .HasColumnType("char(5)");

                entity.Property(e => e.KodeNegara)
                    .HasColumnName("KODE_NEGARA")
                    .HasColumnType("char(5)");
            });

            modelBuilder.Entity<RefPembiayaan>(entity =>
            {
                entity.HasKey(e => e.IdRefPembiayaan);

                entity.ToTable("REF_PEMBIAYAAN", "simka");

                entity.Property(e => e.IdRefPembiayaan)
                    .HasColumnName("ID_REF_PEMBIAYAAN")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefPengeluaranRab>(entity =>
            {
                entity.HasKey(e => e.IdPengeluaranRab);

                entity.ToTable("REF_PENGELUARAN_RAB", "silppm");

                entity.Property(e => e.IdPengeluaranRab).HasColumnName("ID_PENGELUARAN_RAB");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Kategori)
                    .HasColumnName("KATEGORI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaxPct)
                    .HasColumnName("MAX_PCT")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.MinPct)
                    .HasColumnName("MIN_PCT")
                    .HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<RefPengembangan>(entity =>
            {
                entity.HasKey(e => e.IdRefPengembangan);

                entity.ToTable("REF_PENGEMBANGAN", "simka");

                entity.Property(e => e.IdRefPengembangan).HasColumnName("ID_REF_PENGEMBANGAN");

                entity.Property(e => e.Deskripsi).HasColumnName("DESKRIPSI");

                entity.Property(e => e.IdRefJnsAppraisal).HasColumnName("ID_REF_JNS_APPRAISAL");
                entity.HasOne(d => d.IdRefJnsAppraisaliNavigation)
                  .WithMany(p => p.RefPengembangan)
                  .HasForeignKey(d => d.IdRefJnsAppraisal)
                  .HasConstraintName("FK_PENGEMBANGAN_JNS_APPRAISAL");
            });

            modelBuilder.Entity<RefPiutang>(entity =>
            {
                entity.HasKey(e => e.IdRefPiutang);

                entity.ToTable("REF_PIUTANG", "simka");

                entity.Property(e => e.IdRefPiutang)
                    .HasColumnName("ID_REF_PIUTANG")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefPosisi>(entity =>
            {
                entity.HasKey(e => e.IdRefPosisi);

                entity.ToTable("REF_POSISI", "simka");

                entity.Property(e => e.IdRefPosisi).HasColumnName("ID_REF_POSISI");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefPotonganP>(entity =>
            {
                entity.HasKey(e => e.IdRefPotongan);

                entity.ToTable("REF_POTONGAN_P", "simka");

                entity.Property(e => e.IdRefPotongan)
                    .HasColumnName("ID_REF_POTONGAN")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsTetap).HasColumnName("is_tetap");

                entity.Property(e => e.NamaPotongan)
                    .HasColumnName("NAMA_POTONGAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nominal)
                    .HasColumnName("NOMINAL")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<RefPropinsi>(entity =>
            {
                entity.HasKey(e => e.IdRefPropinsi);

                entity.ToTable("REF_PROPINSI", "siatmax");

                entity.Property(e => e.IdRefPropinsi).HasColumnName("ID_REF_PROPINSI");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(150);

                entity.Property(e => e.IdRefNegara).HasColumnName("ID_REF_NEGARA");
            });

            modelBuilder.Entity<RefRestitusi>(entity =>
            {
                entity.HasKey(e => e.IdRefRestitusi);

                entity.ToTable("REF_RESTITUSI", "simka");

                entity.Property(e => e.IdRefRestitusi).HasColumnName("ID_REF_RESTITUSI");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.JangkaWaktu).HasColumnName("JANGKA_WAKTU");

                entity.Property(e => e.Nominal)
                    .HasColumnName("NOMINAL")
                    .HasColumnType("money");
                    

                entity.Property(e => e.TypeRestitusi)
                    .HasColumnName("TYPE_RESTITUSI")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefRoadMapPenelitian>(entity =>
            {
                entity.HasKey(e => new { e.IdRoadMapPenelitian, e.IdUnitAkademik });

                entity.ToTable("REF_ROAD_MAP_PENELITIAN", "silppm");

                entity.Property(e => e.IdRoadMapPenelitian).HasColumnName("ID_ROAD_MAP_PENELITIAN");

                entity.Property(e => e.IdUnitAkademik).HasColumnName("ID_UNIT_AKADEMIK");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("IS_DELETED");
            });

            modelBuilder.Entity<RefRoadMapPengabdian>(entity =>
            {
                entity.HasKey(e => new { e.IdRoadMapPengabdian, e.IdUnitAkademik });

                entity.ToTable("REF_ROAD_MAP_PENGABDIAN", "silppm");

                entity.Property(e => e.IdRoadMapPengabdian).HasColumnName("ID_ROAD_MAP_PENGABDIAN");

                entity.Property(e => e.IdUnitAkademik).HasColumnName("ID_UNIT_AKADEMIK");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("IS_DELETED");
            });

            modelBuilder.Entity<RefRole>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("REF_ROLE", "siatmax");

                entity.Property(e => e.IdRole)
                    .HasColumnName("ID_ROLE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdSistemInformasi).HasColumnName("ID_SISTEM_INFORMASI");
            });

            modelBuilder.Entity<RefSchedule>(entity =>
            {
                entity.HasKey(e => e.IdSchedule);

                entity.ToTable("REF_SCHEDULE", "silppm");

                entity.Property(e => e.IdSchedule)
                    .HasColumnName("ID_SCHEDULE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Akhir)
                    .HasColumnName("AKHIR")
                    .HasColumnType("datetime");

                entity.Property(e => e.Awal)
                    .HasColumnName("AWAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdTahunAnggaran).HasColumnName("ID_TAHUN_ANGGARAN");

                entity.Property(e => e.IsLocked).HasColumnName("IS_LOCKED");
            });

            modelBuilder.Entity<RefSettingRestitusi>(entity =>
            {
                entity.HasKey(e => e.IdRefSettingRestitusi);

                entity.ToTable("REF_SETTING_RESTITUSI", "simka");

                entity.Property(e => e.IdRefSettingRestitusi).HasColumnName("ID_REF_SETTING_RESTITUSI");

                entity.Property(e => e.IdRefRestitusi).HasColumnName("ID_REF_RESTITUSI");

                entity.Property(e => e.IdRka).HasColumnName("ID_RKA");

                entity.Property(e => e.IdTahunAnggaran).HasColumnName("ID_TAHUN_ANGGARAN");
            });

            modelBuilder.Entity<RefSkim>(entity =>
            {
                entity.HasKey(e => e.IdSkim);

                entity.ToTable("REF_SKIM", "silppm");

                entity.Property(e => e.IdSkim).HasColumnName("ID_SKIM");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Kategori)
                    .HasColumnName("KATEGORI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaxPagu)
                    .HasColumnName("MAX_PAGU")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<RefSmuSmk>(entity =>
            {
                entity.HasKey(e => e.IdRefSmu);

                entity.ToTable("REF_SMU_SMK", "siatma");

                entity.Property(e => e.IdRefSmu).HasColumnName("ID_REF_SMU");

                entity.Property(e => e.Alamat)
                    .HasColumnName("ALAMAT")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("CONTACT_PERSON")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefKabKodya).HasColumnName("ID_REF_KAB_KODYA");

                entity.Property(e => e.IdRefPropinsi).HasColumnName("ID_REF_PROPINSI");

                entity.Property(e => e.JenisYayasan)
                    .HasColumnName("JENIS_YAYASAN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Kecamatan)
                    .HasColumnName("KECAMATAN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Kelurahan)
                    .HasColumnName("KELURAHAN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Kodepos)
                    .HasColumnName("KODEPOS")
                    .HasColumnType("char(10)");

                entity.Property(e => e.NamaSmu)
                    .HasColumnName("NAMA_SMU")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Negara)
                    .HasColumnName("NEGARA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoFax)
                    .HasColumnName("NO_FAX")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelp)
                    .HasColumnName("NO_TELP")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelponCp)
                    .HasColumnName("NO_TELPON_CP")
                    .HasColumnType("char(15)");

                entity.HasOne(d => d.IdRefKabKodyaNavigation)
                    .WithMany(p => p.RefSmuSmk)
                    .HasForeignKey(d => d.IdRefKabKodya)
                    .HasConstraintName("FK_REF_SMU_SMK_REF_KAB_KODYA");

                entity.HasOne(d => d.IdRefPropinsiNavigation)
                    .WithMany(p => p.RefSmuSmk)
                    .HasForeignKey(d => d.IdRefPropinsi)
                    .HasConstraintName("FK_REF_SMU_SMK_REF_PROPINSI");
            });

            modelBuilder.Entity<RefStatusHutang>(entity =>
            {
                entity.HasKey(e => e.IdRefStatusHutang);

                entity.ToTable("REF_STATUS_HUTANG", "simka");

                entity.Property(e => e.IdRefStatusHutang).HasColumnName("ID_REF_STATUS_HUTANG");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefStatusKepegawaian>(entity =>
            {
                entity.HasKey(e => e.IdRefStatusKepegawaian);

                entity.ToTable("REF_STATUS_KEPEGAWAIAN", "simka");

                entity.Property(e => e.IdRefStatusKepegawaian).HasColumnName("ID_REF_STATUS_KEPEGAWAIAN");

                entity.Property(e => e.StatusAktifitas)
                    .HasColumnName("STATUS_AKTIFITAS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusKepegawaian)
                    .HasColumnName("STATUS_KEPEGAWAIAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefStatusPenelitianPengabdian>(entity =>
            {
                entity.HasKey(e => e.IdStatusPenelitian);

                entity.ToTable("REF_STATUS_PENELITIAN_PENGABDIAN", "silppm");

                entity.Property(e => e.IdStatusPenelitian)
                    .HasColumnName("ID_STATUS_PENELITIAN")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefStatusStudi>(entity =>
            {
                entity.HasKey(e => e.IdRefSs);

                entity.ToTable("REF_STATUS_STUDI", "simka");

                entity.Property(e => e.IdRefSs).HasColumnName("ID_REF_SS");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefSumberBiaya>(entity =>
            {
                entity.HasKey(e => e.IdSumberBiaya);

                entity.ToTable("REF_SUMBER_BIAYA", "simka");

                entity.Property(e => e.IdSumberBiaya).HasColumnName("ID_SUMBER_BIAYA");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefTemaUniversitas>(entity =>
            {
                entity.HasKey(e => e.IdTemaUniversitas);

                entity.ToTable("REF_TEMA_UNIVERSITAS", "silppm");

                entity.Property(e => e.IdTemaUniversitas)
                    .HasColumnName("ID_TEMA_UNIVERSITAS")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IsCurrent).HasColumnName("IS_CURRENT");

                entity.Property(e => e.Kategori)
                    .HasColumnName("KATEGORI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefTrAkademik>(entity =>
            {
                entity.HasKey(e => e.IdRefTrAkademik);

                entity.ToTable("REF_TR_AKADEMIK", "simka");

                entity.Property(e => e.IdRefTrAkademik).HasColumnName("ID_REF_TR_AKADEMIK");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefTunjanganKhusus>(entity =>
            {
                entity.HasKey(e => e.IdRefTunjanganKhusus);

                entity.ToTable("REF_TUNJANGAN_KHUSUS", "simka");

                entity.Property(e => e.IdRefTunjanganKhusus).HasColumnName("ID_REF_TUNJANGAN_KHUSUS");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefTunjanganMengajarPasca>(entity =>
            {
                entity.HasKey(e => e.IdRefTunjanganPasca);

                entity.ToTable("REF_TUNJANGAN_MENGAJAR_PASCA", "simka");

                entity.Property(e => e.IdRefTunjanganPasca).HasColumnName("ID_REF_TUNJANGAN_PASCA");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prodi)
                    .HasColumnName("PRODI")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefTunjanganTaKp>(entity =>
            {
                entity.HasKey(e => e.IdRefTunjanganTaKp);

                entity.ToTable("REF_TUNJANGAN_TA_KP", "simka");

                entity.Property(e => e.IdRefTunjanganTaKp).HasColumnName("ID_REF_TUNJANGAN_TA_KP");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsInternasional).HasColumnName("IS_INTERNASIONAL");
            });

            modelBuilder.Entity<RefUniversitas>(entity =>
            {
                entity.HasKey(e => e.IdUniversitas);

                entity.ToTable("REF_UNIVERSITAS", "siatma");

                entity.Property(e => e.IdUniversitas).HasColumnName("ID_UNIVERSITAS");

                entity.Property(e => e.Alamat)
                    .HasColumnName("ALAMAT")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("CONTACT_PERSON")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefKabKodya).HasColumnName("ID_REF_KAB_KODYA");

                entity.Property(e => e.IdRefPropinsi).HasColumnName("ID_REF_PROPINSI");

                entity.Property(e => e.Kecamatan)
                    .HasColumnName("KECAMATAN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Kelurahan)
                    .HasColumnName("KELURAHAN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Kodepos)
                    .HasColumnName("KODEPOS")
                    .HasColumnType("char(10)");

                entity.Property(e => e.NamaUniversitas)
                    .HasColumnName("NAMA_UNIVERSITAS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Negara)
                    .HasColumnName("NEGARA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoFax)
                    .HasColumnName("NO_FAX")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelp)
                    .HasColumnName("NO_TELP")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelponCp)
                    .HasColumnName("NO_TELPON_CP")
                    .HasColumnType("char(15)");

                entity.HasOne(d => d.IdRefKabKodyaNavigation)
                    .WithMany(p => p.RefUniversitas)
                    .HasForeignKey(d => d.IdRefKabKodya)
                    .HasConstraintName("FK_REF_UNIV_KAB_KODYA");

                entity.HasOne(d => d.IdRefPropinsiNavigation)
                    .WithMany(p => p.RefUniversitas)
                    .HasForeignKey(d => d.IdRefPropinsi)
                    .HasConstraintName("FK_REF_UNIV_PROPINSI");
            });

            modelBuilder.Entity<TblAppraisal>(entity =>
            {
                entity.HasKey(e => e.IdAppraisal);

                entity.ToTable("TBL_APPRAISAL", "simka");

                entity.HasIndex(e => e.IdRefJnsAppraisal)
                    .HasName("RELATION_547_FK");

                entity.HasIndex(e => e.Npp)
                    .HasName("RELATION_546_FK");

                entity.Property(e => e.IdAppraisal)
                    .HasColumnName("ID_APPRAISAL")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdRefJnsAppraisal).HasColumnName("ID_REF_JNS_APPRAISAL");

                entity.Property(e => e.NilaiTotal).HasColumnName("NILAI_TOTAL");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.TglAppraisal)
                    .HasColumnName("TGL_APPRAISAL")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdRefJnsAppraisalNavigation)
                    .WithMany(p => p.TblAppraisal)
                    .HasForeignKey(d => d.IdRefJnsAppraisal)
                    .HasConstraintName("FK_RELATION_547");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TblAppraisal)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATION_546");
            });

            modelBuilder.Entity<TblBiayaSlEksternal>(entity =>
            {
                entity.HasKey(e => e.IdBiayaSlEks);

                entity.ToTable("TBL_BIAYA_SL_EKSTERNAL", "simka");

                entity.Property(e => e.IdBiayaSlEks).HasColumnName("ID_BIAYA_SL_EKS");

                entity.Property(e => e.BuktiTransfer).HasColumnName("BUKTI_TRANSFER");

                entity.Property(e => e.IdSumberBiayaSl).HasColumnName("ID_SUMBER_BIAYA_SL");

                entity.Property(e => e.Nominal)
                    .HasColumnName("NOMINAL")
                    .HasColumnType("money");

                entity.Property(e => e.TglTransfer)
                    .HasColumnName("TGL_TRANSFER")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdSumberBiayaSlNavigation)
                    .WithMany(p => p.TblBiayaSlEksternal)
                    .HasForeignKey(d => d.IdSumberBiayaSl)
                    .HasConstraintName("FK_TBL_BIAYA_SL_EKSTERNAL_TBL_SUMBER_BIAYA_SL");
            });

            modelBuilder.Entity<TblBiayaSlInternal>(entity =>
            {
                entity.HasKey(e => e.IdBiayaSlInt);

                entity.ToTable("TBL_BIAYA_SL_INTERNAL", "simka");

                entity.Property(e => e.IdBiayaSlInt).HasColumnName("ID_BIAYA_SL_INT");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdSumberBiayaSl).HasColumnName("ID_SUMBER_BIAYA_SL");

                entity.Property(e => e.IsPermanent).HasColumnName("IS_PERMANENT");

                entity.Property(e => e.JumlahDicairkan)
                    .HasColumnName("JUMLAH_DICAIRKAN")
                    .HasColumnType("money");

                entity.Property(e => e.JumlahPengajuan)
                    .HasColumnName("JUMLAH_PENGAJUAN")
                    .HasColumnType("money");

                entity.Property(e => e.Semester)
                    .HasColumnName("SEMESTER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tahun)
                    .HasColumnName("TAHUN")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TglApprovalFakultas)
                    .HasColumnName("TGL_APPROVAL_FAKULTAS")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglCair)
                    .HasColumnName("TGL_CAIR")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglPengajuan)
                    .HasColumnName("TGL_PENGAJUAN")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglTransfer)
                    .HasColumnName("TGL_TRANSFER")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdSumberBiayaSlNavigation)
                    .WithMany(p => p.TblBiayaSlInternal)
                    .HasForeignKey(d => d.IdSumberBiayaSl)
                    .HasConstraintName("FK_TBL_BIAYA_STUDI_LANJUT_TBL_STUDI_LANJUT");
            });

            modelBuilder.Entity<TblCalonKaryawan>(entity =>
            {
                entity.HasKey(e => e.IdCalonKaryawan);

                entity.ToTable("TBL_CALON_KARYAWAN", "simka");

                entity.HasIndex(e => e.IdMstUr)
                    .HasName("RELATION_275_FK");

                entity.Property(e => e.IdCalonKaryawan)
                    .HasColumnName("ID_CALON_KARYAWAN")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlamatJalan)
                    .HasColumnName("ALAMAT_JALAN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AlamatKodepos)
                    .HasColumnName("ALAMAT_KODEPOS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AlamatProvinsi)
                    .HasColumnName("ALAMAT_PROVINSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FileCv)
                    .HasColumnName("FILE_CV")
                    .HasColumnType("char(10)");

                entity.Property(e => e.IdMstUr).HasColumnName("ID_MST_UR");

                entity.Property(e => e.Ipk).HasColumnName("IPK");

                entity.Property(e => e.Kota)
                    .HasColumnName("KOTA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasColumnName("NAMA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomorTelponHp)
                    .HasColumnName("NOMOR_TELPON_HP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NomorTelponRumah)
                    .HasColumnName("NOMOR_TELPON_RUMAH")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PendidikanTerakhir)
                    .HasColumnName("PENDIDIKAN_TERAKHIR")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasColumnType("char(10)");

                entity.Property(e => e.TempatLahir)
                    .HasColumnName("TEMPAT_LAHIR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TglLahir)
                    .HasColumnName("TGL_LAHIR")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdMstUrNavigation)
                    .WithMany(p => p.TblCalonKaryawan)
                    .HasForeignKey(d => d.IdMstUr)
                    .HasConstraintName("FK_RELATION_275");
            });

            modelBuilder.Entity<TblDetailDp3>(entity =>
            {
                entity.HasKey(e => e.IdDetailDp3);

                entity.ToTable("TBL_DETAIL_DP3", "simka");

                entity.Property(e => e.IdDetailDp3).HasColumnName("ID_DETAIL_DP3");

                entity.Property(e => e.IdRefDp3).HasColumnName("ID_REF_DP3");

                entity.Property(e => e.Nilai)
                    .HasColumnName("NILAI")
                    .HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.IdRefDp3Navigation)
                    .WithMany(p => p.TblDetailDp3)
                    .HasForeignKey(d => d.IdRefDp3)
                    .HasConstraintName("FK_TBL_DETAIL_DP3_REF_DP3");
            });

            modelBuilder.Entity<TblDetailHonor>(entity =>
            {
                entity.HasKey(e => e.IdTblDetailHonor);

                entity.ToTable("TBL_DETAIL_HONOR", "simka");

                entity.HasIndex(e => e.IdMstTarifPayroll)
                    .HasName("RELATION_4139_FK");

                entity.Property(e => e.IdTblDetailHonor)
                    .HasColumnName("ID_TBL_DETAIL_HONOR")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdMstTarifPayroll).HasColumnName("ID_MST_TARIF_PAYROLL");

                entity.Property(e => e.IdTrHonor).HasColumnName("ID_TR_HONOR");

                entity.Property(e => e.Kuantitas)
                    .HasColumnName("KUANTITAS")
                    .HasColumnType("numeric(5, 1)");

                entity.Property(e => e.Nominal)
                    .HasColumnName("NOMINAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdMstTarifPayrollNavigation)
                    .WithMany(p => p.TblDetailHonor)
                    .HasForeignKey(d => d.IdMstTarifPayroll)
                    .HasConstraintName("FK_RELATION_4139");

                entity.HasOne(d => d.IdTrHonorNavigation)
                    .WithMany(p => p.TblDetailHonor)
                    .HasForeignKey(d => d.IdTrHonor)
                    .HasConstraintName("FK_RELATION_4138");
            });

            modelBuilder.Entity<TblDetailHutang>(entity =>
            {
                entity.HasKey(e => e.IdTblDetailHutang);

                entity.ToTable("TBL_DETAIL_HUTANG", "simka");

                entity.HasIndex(e => e.IdTrHutang)
                    .HasName("RELATION_4114_FK");

                entity.Property(e => e.IdTblDetailHutang).HasColumnName("ID_TBL_DETAIL_HUTANG");

                entity.Property(e => e.Approval).HasColumnName("APPROVAL");

                entity.Property(e => e.CicilanKe).HasColumnName("CICILAN_KE");

                entity.Property(e => e.IdRefStatusHutang).HasColumnName("ID_REF_STATUS_HUTANG");

                entity.Property(e => e.IdTrHutang).HasColumnName("ID_TR_HUTANG");

                entity.Property(e => e.IsDp).HasColumnName("IS_DP");

                entity.Property(e => e.Nominal)
                    .HasColumnName("NOMINAL")
                    .HasColumnType("money");

                entity.Property(e => e.TglApproval)
                    .HasColumnName("TGL_APPROVAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglBayar)
                    .HasColumnName("TGL_BAYAR")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglInput)
                    .HasColumnName("TGL_INPUT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdRefStatusHutangNavigation)
                    .WithMany(p => p.TblDetailHutang)
                    .HasForeignKey(d => d.IdRefStatusHutang)
                    .HasConstraintName("FK_TBL_DETAIL_HUTANG_REF_STATUS_HUTANG");

                entity.HasOne(d => d.IdTrHutangNavigation)
                    .WithMany(p => p.TblDetailHutang)
                    .HasForeignKey(d => d.IdTrHutang)
                    .HasConstraintName("FK_RELATION_4114");
            });

            modelBuilder.Entity<TblDetailPayrollPiutang>(entity =>
            {
                entity.HasKey(e => e.IdTblDetailPayrollPiutang);

                entity.ToTable("TBL_DETAIL_PAYROLL_PIUTANG", "simka");

                entity.HasIndex(e => e.IdRefPiutang)
                    .HasName("RELATION_4123_FK");

                entity.HasIndex(e => e.IdTrPayroll)
                    .HasName("RELATION_4082_FK");

                entity.Property(e => e.IdTblDetailPayrollPiutang)
                    .HasColumnName("ID_TBL_DETAIL_PAYROLL_PIUTANG")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdRefPiutang).HasColumnName("ID_REF_PIUTANG");

                entity.Property(e => e.IdTrPayroll).HasColumnName("ID_TR_PAYROLL");

                entity.Property(e => e.Kuantitas)
                    .HasColumnName("KUANTITAS")
                    .HasColumnType("numeric(5, 1)");

                entity.Property(e => e.Nominal)
                    .HasColumnName("NOMINAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdRefPiutangNavigation)
                    .WithMany(p => p.TblDetailPayrollPiutang)
                    .HasForeignKey(d => d.IdRefPiutang)
                    .HasConstraintName("FK_RELATION_4123");

                entity.HasOne(d => d.IdTrPayrollNavigation)
                    .WithMany(p => p.TblDetailPayrollPiutang)
                    .HasForeignKey(d => d.IdTrPayroll)
                    .HasConstraintName("FK_TBL_DETAIL_PAYROLL_PIUTANG_TR_PAYROLL");
            });

            modelBuilder.Entity<TblDetailPayrollPotongan>(entity =>
            {
                entity.HasKey(e => e.IdPayrollPotongan);

                entity.ToTable("TBL_DETAIL_PAYROLL_POTONGAN", "simka");

                entity.HasIndex(e => e.IdRefPotongan)
                    .HasName("RELATION_4092_FK");

                entity.HasIndex(e => e.IdTrPayroll)
                    .HasName("RELATION_4076_FK");

                entity.Property(e => e.IdPayrollPotongan)
                    .HasColumnName("ID_PAYROLL_POTONGAN")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdRefPotongan).HasColumnName("ID_REF_POTONGAN");

                entity.Property(e => e.IdTrPayroll).HasColumnName("ID_TR_PAYROLL");

                entity.Property(e => e.Kuantitas)
                    .HasColumnName("KUANTITAS")
                    .HasColumnType("numeric(5, 1)");

                entity.Property(e => e.Nominal)
                    .HasColumnName("NOMINAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdRefPotonganNavigation)
                    .WithMany(p => p.TblDetailPayrollPotongan)
                    .HasForeignKey(d => d.IdRefPotongan)
                    .HasConstraintName("FK_RELATION_4092");

                entity.HasOne(d => d.IdTrPayrollNavigation)
                    .WithMany(p => p.TblDetailPayrollPotongan)
                    .HasForeignKey(d => d.IdTrPayroll)
                    .HasConstraintName("FK_RELATION_4076");
            });

            modelBuilder.Entity<TblDetailPayrollTerima>(entity =>
            {
                entity.HasKey(e => e.IdTblDetailPayrollTerima);

                entity.ToTable("TBL_DETAIL_PAYROLL_TERIMA", "simka");

                entity.HasIndex(e => e.IdTrPayroll)
                    .HasName("RELATION_4070_FK");

                entity.Property(e => e.IdTblDetailPayrollTerima).HasColumnName("ID_TBL_DETAIL_PAYROLL_TERIMA");

                entity.Property(e => e.IdMstTarifPayroll).HasColumnName("ID_MST_TARIF_PAYROLL");

                entity.Property(e => e.IdTrPayroll).HasColumnName("ID_TR_PAYROLL");

                entity.Property(e => e.Kuantitas)
                    .HasColumnName("KUANTITAS")
                    .HasColumnType("numeric(5, 1)");

                entity.Property(e => e.Nominal)
                    .HasColumnName("NOMINAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdTrPayrollNavigation)
                    .WithMany(p => p.TblDetailPayrollTerima)
                    .HasForeignKey(d => d.IdTrPayroll)
                    .HasConstraintName("FK_RELATION_4070");
            });

            modelBuilder.Entity<TblDokumen>(entity =>
            {
                entity.HasKey(e => e.IdTblDokumen);

                entity.ToTable("TBL_DOKUMEN", "simka");

                entity.Property(e => e.IdTblDokumen).HasColumnName("ID_TBL_DOKUMEN");

                entity.Property(e => e.FileDokumen).HasColumnName("FILE_DOKUMEN");

                entity.Property(e => e.IdJenisDokumen).HasColumnName("ID_JENIS_DOKUMEN");

                entity.Property(e => e.NomorDokumen)
                    .HasColumnName("NOMOR_DOKUMEN")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdJenisDokumenNavigation)
                    .WithMany(p => p.TblDokumen)
                    .HasForeignKey(d => d.IdJenisDokumen)
                    .HasConstraintName("FK_TBL_DOKUMEN_REF_JENIS_DOKUMEN");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TblDokumen)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_TBL_DOKUMEN_MST_KARYAWAN");
            });

            modelBuilder.Entity<TblFeedbackPenelitian>(entity =>
            {
                entity.HasKey(e => e.IdFeedback);

                entity.ToTable("TBL_FEEDBACK_PENELITIAN", "silppm");

                entity.Property(e => e.IdFeedback).HasColumnName("ID_FEEDBACK");

                entity.Property(e => e.Feedback)
                    .HasColumnName("FEEDBACK")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tanggal)
                    .HasColumnName("TANGGAL")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblFeedbackPengabdian>(entity =>
            {
                entity.HasKey(e => e.IdFeedback);

                entity.ToTable("TBL_FEEDBACK_PENGABDIAN", "silppm");

                entity.Property(e => e.IdFeedback).HasColumnName("ID_FEEDBACK");

                entity.Property(e => e.Feedback)
                    .HasColumnName("FEEDBACK")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tanggal)
                    .HasColumnName("TANGGAL")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblLapMonevPenelitian>(entity =>
            {
                entity.HasKey(e => e.IdMonev);

                entity.ToTable("TBL_LAP_MONEV_PENELITIAN", "silppm");

                entity.Property(e => e.IdMonev).HasColumnName("ID_MONEV");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.Keterangan).HasColumnName("KETERANGAN");

                entity.Property(e => e.NoUpdate).HasColumnName("NO_UPDATE");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.TanggalUpload)
                    .HasColumnName("TANGGAL_UPLOAD")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblLapMonevPengabdian>(entity =>
            {
                entity.HasKey(e => e.IdMonev);

                entity.ToTable("TBL_LAP_MONEV_PENGABDIAN", "silppm");

                entity.Property(e => e.IdMonev).HasColumnName("ID_MONEV");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.Keterangan).HasColumnName("KETERANGAN");

                entity.Property(e => e.NoUpdate).HasColumnName("NO_UPDATE");

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.TanggalUpload)
                    .HasColumnName("TANGGAL_UPLOAD")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMappingPenelitian>(entity =>
            {
                entity.HasKey(e => new { e.IdProposal, e.Npp });

                entity.ToTable("TBL_MAPPING_PENELITIAN", "silppm");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TblMappingPengabdian>(entity =>
            {
                entity.HasKey(e => new { e.IdProposal, e.Npp });

                entity.ToTable("TBL_MAPPING_PENGABDIAN", "silppm");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TblNilaiReviewPenelitian>(entity =>
            {
                entity.HasKey(e => e.IdNilaiReview);

                entity.ToTable("TBL_NILAI_REVIEW_PENELITIAN", "silppm");

                entity.Property(e => e.IdNilaiReview).HasColumnName("ID_NILAI_REVIEW");

                entity.Property(e => e.CountRevisi).HasColumnName("COUNT_REVISI");

                entity.Property(e => e.DanaRekomendasi).HasColumnName("DANA_REKOMENDASI");

                entity.Property(e => e.DanaSetuju).HasColumnName("DANA_SETUJU");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.IdReviewer)
                    .IsRequired()
                    .HasColumnName("ID_REVIEWER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.N1Field1).HasColumnName("N1_FIELD1");

                entity.Property(e => e.N1Field2).HasColumnName("N1_FIELD2");

                entity.Property(e => e.N1Field3).HasColumnName("N1_FIELD3");

                entity.Property(e => e.N1Field4).HasColumnName("N1_FIELD4");

                entity.Property(e => e.N1Field5).HasColumnName("N1_FIELD5");

                entity.Property(e => e.N1Field6).HasColumnName("N1_FIELD6");

                entity.Property(e => e.N1Field7).HasColumnName("N1_FIELD7");

                entity.Property(e => e.N1Justifikasi1)
                    .HasColumnName("N1_JUSTIFIKASI1")
                    .IsUnicode(false);

                entity.Property(e => e.N1Justifikasi2)
                    .HasColumnName("N1_JUSTIFIKASI2")
                    .IsUnicode(false);

                entity.Property(e => e.N1Justifikasi3)
                    .HasColumnName("N1_JUSTIFIKASI3")
                    .IsUnicode(false);

                entity.Property(e => e.N1Justifikasi4)
                    .HasColumnName("N1_JUSTIFIKASI4")
                    .IsUnicode(false);

                entity.Property(e => e.N1Justifikasi5)
                    .HasColumnName("N1_JUSTIFIKASI5")
                    .IsUnicode(false);

                entity.Property(e => e.N1Justifikasi6)
                    .HasColumnName("N1_JUSTIFIKASI6")
                    .IsUnicode(false);

                entity.Property(e => e.N1Justifikasi7)
                    .HasColumnName("N1_JUSTIFIKASI7")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblNilaiReviewPengabdian>(entity =>
            {
                entity.HasKey(e => e.IdNilaiReview);

                entity.ToTable("TBL_NILAI_REVIEW_PENGABDIAN", "silppm");

                entity.Property(e => e.IdNilaiReview).HasColumnName("ID_NILAI_REVIEW");

                entity.Property(e => e.Anggaran).HasColumnName("ANGGARAN");

                entity.Property(e => e.AnggaranHuruf)
                    .HasColumnName("ANGGARAN_HURUF")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Catatan1)
                    .HasColumnName("CATATAN1")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Catatan2)
                    .HasColumnName("CATATAN2")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Catatan3)
                    .HasColumnName("CATATAN3")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Catatan4)
                    .HasColumnName("CATATAN4")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Catatan5)
                    .HasColumnName("CATATAN5")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CountRevisi).HasColumnName("COUNT_REVISI");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.IdReviewer)
                    .IsRequired()
                    .HasColumnName("ID_REVIEWER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Justifikasi1)
                    .HasColumnName("JUSTIFIKASI1")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Justifikasi2)
                    .HasColumnName("JUSTIFIKASI2")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Justifikasi3)
                    .HasColumnName("JUSTIFIKASI3")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Justifikasi4)
                    .HasColumnName("JUSTIFIKASI4")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Justifikasi5)
                    .HasColumnName("JUSTIFIKASI5")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Justifikasi6)
                    .HasColumnName("JUSTIFIKASI6")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Kesimpulan)
                    .HasColumnName("KESIMPULAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Keunikan)
                    .HasColumnName("KEUNIKAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Skor1).HasColumnName("SKOR1");

                entity.Property(e => e.Skor2).HasColumnName("SKOR2");

                entity.Property(e => e.Skor3).HasColumnName("SKOR3");

                entity.Property(e => e.Skor4).HasColumnName("SKOR4");

                entity.Property(e => e.Skor5).HasColumnName("SKOR5");

                entity.Property(e => e.Skor6).HasColumnName("SKOR6");
            });

            modelBuilder.Entity<TblPelaporanStudiLanjut>(entity =>
            {
                entity.HasKey(e => e.IdPelaporanStudiLanjut);

                entity.ToTable("TBL_PELAPORAN_STUDI_LANJUT", "simka");

                entity.Property(e => e.IdPelaporanStudiLanjut).HasColumnName("ID_PELAPORAN_STUDI_LANJUT");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Dokumen).HasColumnName("DOKUMEN");

                entity.Property(e => e.IdStudiLanjut).HasColumnName("ID_STUDI_LANJUT");

                entity.Property(e => e.Semester)
                    .HasColumnName("SEMESTER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tahun)
                    .HasColumnName("TAHUN")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStudiLanjutNavigation)
                    .WithMany(p => p.TblPelaporanStudiLanjut)
                    .HasForeignKey(d => d.IdStudiLanjut)
                    .HasConstraintName("FK_TBL_PELAPORAN_STUDI_LANJUT_TBL_STUDI_LANJUT");
            });

            modelBuilder.Entity<TblPenelitian>(entity =>
            {
                entity.HasKey(e => e.IdProposal);

                entity.ToTable("TBL_PENELITIAN", "silppm");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.Akhir)
                    .HasColumnName("AKHIR")
                    .HasColumnType("date");

                entity.Property(e => e.Awal)
                    .HasColumnName("AWAL")
                    .HasColumnType("date");

                entity.Property(e => e.BebanSks).HasColumnName("BEBAN_SKS");

                entity.Property(e => e.BebanSksAnggota).HasColumnName("BEBAN_SKS_ANGGOTA");

                entity.Property(e => e.DanaEksternal)
                    .HasColumnName("DANA_EKSTERNAL")
                    .HasColumnType("money");

                entity.Property(e => e.DanaKerjasama)
                    .HasColumnName("DANA_KERJASAMA")
                    .HasColumnType("money");

                entity.Property(e => e.DanaPribadi)
                    .HasColumnName("DANA_PRIBADI")
                    .HasColumnType("money");

                entity.Property(e => e.DanaSetuju)
                    .HasColumnName("DANA_SETUJU")
                    .HasColumnType("money");

                entity.Property(e => e.DanaUajy)
                    .HasColumnName("DANA_UAJY")
                    .HasColumnType("money");

                entity.Property(e => e.DanaUsul)
                    .HasColumnName("DANA_USUL")
                    .HasColumnType("money");

                entity.Property(e => e.Dokumen).HasColumnName("DOKUMEN");

                entity.Property(e => e.IdKategori).HasColumnName("ID_KATEGORI");

                entity.Property(e => e.IdRoadMapPenelitian).HasColumnName("ID_ROAD_MAP_PENELITIAN");

                entity.Property(e => e.IdSkim).HasColumnName("ID_SKIM");

                entity.Property(e => e.IdStatusPenelitian).HasColumnName("ID_STATUS_PENELITIAN");

                entity.Property(e => e.IdTahunAnggaran).HasColumnName("ID_TAHUN_ANGGARAN");

                entity.Property(e => e.IdTemaUniversitas).HasColumnName("ID_TEMA_UNIVERSITAS");

                entity.Property(e => e.InsertDate)
                    .HasColumnName("INSERT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsChecked).HasColumnName("IS_CHECKED");

                entity.Property(e => e.IsDropped).HasColumnName("IS_DROPPED");

                entity.Property(e => e.IsLock).HasColumnName("IS_LOCK");

                entity.Property(e => e.IsSetujuDekan).HasColumnName("IS_SETUJU_DEKAN");

                entity.Property(e => e.IsSetujuLppm).HasColumnName("IS_SETUJU_LPPM");

                entity.Property(e => e.IsSetujuProdi).HasColumnName("IS_SETUJU_PRODI");

                entity.Property(e => e.JarakKampusJam).HasColumnName("JARAK_KAMPUS_JAM");

                entity.Property(e => e.JarakKampusKm).HasColumnName("JARAK_KAMPUS_KM");

                entity.Property(e => e.Jenis)
                    .HasColumnName("JENIS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Judul)
                    .HasColumnName("JUDUL")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.KeteranganDanaEksternal)
                    .HasColumnName("KETERANGAN_DANA_EKSTERNAL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword)
                    .HasColumnName("KEYWORD")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasColumnName("LATITUDE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LembarPengesahan).HasColumnName("LEMBAR_PENGESAHAN");

                entity.Property(e => e.Lokasi)
                    .HasColumnName("LOKASI")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasColumnName("LONGITUDE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoSemester).HasColumnName("NO_SEMESTER");

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Npp1)
                    .HasColumnName("NPP1")
                    .HasMaxLength(10);

                entity.Property(e => e.Npp2)
                    .HasColumnName("NPP2")
                    .HasMaxLength(10);

                entity.Property(e => e.NppReviewer)
                    .HasColumnName("NPP_REVIEWER")
                    .HasMaxLength(10);

                entity.Property(e => e.Outcome)
                    .HasColumnName("OUTCOME")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Reviewer1)
                    .HasColumnName("REVIEWER1")
                    .HasMaxLength(10);

                entity.Property(e => e.Reviewer2)
                    .HasColumnName("REVIEWER2")
                    .HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPenelitianLolos>(entity =>
            {
                entity.HasKey(e => e.IdProposal);

                entity.ToTable("TBL_PENELITIAN_LOLOS", "silppm");

                entity.Property(e => e.IdProposal)
                    .HasColumnName("ID_PROPOSAL")
                    .ValueGeneratedNever();

                entity.Property(e => e.Akhir)
                    .HasColumnName("AKHIR")
                    .HasColumnType("date");

                entity.Property(e => e.Awal)
                    .HasColumnName("AWAL")
                    .HasColumnType("date");

                entity.Property(e => e.BebanSks).HasColumnName("BEBAN_SKS");

                entity.Property(e => e.BebanSksAnggota).HasColumnName("BEBAN_SKS_ANGGOTA");

                entity.Property(e => e.DanaPribadi)
                    .HasColumnName("DANA_PRIBADI")
                    .HasColumnType("money");

                entity.Property(e => e.DanaRekomen)
                    .HasColumnName("DANA_REKOMEN")
                    .HasColumnType("money");

                entity.Property(e => e.DanaSetuju)
                    .HasColumnName("DANA_SETUJU")
                    .HasColumnType("money");

                entity.Property(e => e.DanaUsul)
                    .HasColumnName("DANA_USUL")
                    .HasColumnType("money");

                entity.Property(e => e.Dokumen).HasColumnName("DOKUMEN");

                entity.Property(e => e.FileOutcome).HasColumnName("FILE_OUTCOME");

                entity.Property(e => e.IdKategori).HasColumnName("ID_KATEGORI");

                entity.Property(e => e.IdRoadMapPenelitian).HasColumnName("ID_ROAD_MAP_PENELITIAN");

                entity.Property(e => e.IdStatusPenelitian).HasColumnName("ID_STATUS_PENELITIAN");

                entity.Property(e => e.IdTahunAnggaran).HasColumnName("ID_TAHUN_ANGGARAN");

                entity.Property(e => e.InsertDate)
                    .HasColumnName("INSERT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsChecked).HasColumnName("IS_CHECKED");

                entity.Property(e => e.IsDropped).HasColumnName("IS_DROPPED");

                entity.Property(e => e.IsSelesai).HasColumnName("IS_SELESAI");

                entity.Property(e => e.IsSetujuDekan).HasColumnName("IS_SETUJU_DEKAN");

                entity.Property(e => e.IsSetujuLppm).HasColumnName("IS_SETUJU_LPPM");

                entity.Property(e => e.IsSetujuProdi).HasColumnName("IS_SETUJU_PRODI");

                entity.Property(e => e.IsSetujuPustakawan).HasColumnName("IS_SETUJU_PUSTAKAWAN");

                entity.Property(e => e.JarakKampusJam).HasColumnName("JARAK_KAMPUS_JAM");

                entity.Property(e => e.JarakKampusKm).HasColumnName("JARAK_KAMPUS_KM");

                entity.Property(e => e.Jenis)
                    .HasColumnName("JENIS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Judul)
                    .HasColumnName("JUDUL")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword)
                    .HasColumnName("KEYWORD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Laporan).HasColumnName("LAPORAN");

                entity.Property(e => e.Laporan1).HasColumnName("LAPORAN1");

                entity.Property(e => e.Latitude)
                    .HasColumnName("LATITUDE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lokasi)
                    .HasColumnName("LOKASI")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasColumnName("LONGITUDE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Npp1)
                    .HasColumnName("NPP1")
                    .HasMaxLength(10);

                entity.Property(e => e.Npp2)
                    .HasColumnName("NPP2")
                    .HasMaxLength(10);

                entity.Property(e => e.NppReviewer)
                    .HasColumnName("NPP_REVIEWER")
                    .HasMaxLength(10);

                entity.Property(e => e.Outcome)
                    .HasColumnName("OUTCOME")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Pajak).HasColumnName("PAJAK");

                entity.Property(e => e.Reviewer1)
                    .HasColumnName("REVIEWER1")
                    .HasMaxLength(10);

                entity.Property(e => e.Reviewer2)
                    .HasColumnName("REVIEWER2")
                    .HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPengabdian>(entity =>
            {
                entity.HasKey(e => e.IdProposal);

                entity.ToTable("TBL_PENGABDIAN", "silppm");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.Akhir)
                    .HasColumnName("AKHIR")
                    .HasColumnType("date");

                entity.Property(e => e.Anggota1)
                    .HasColumnName("ANGGOTA1")
                    .HasMaxLength(10);

                entity.Property(e => e.Anggota1Keahlian)
                    .HasColumnName("ANGGOTA1_KEAHLIAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Anggota2)
                    .HasColumnName("ANGGOTA2")
                    .HasMaxLength(10);

                entity.Property(e => e.Anggota2Keahlian)
                    .HasColumnName("ANGGOTA2_KEAHLIAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Awal)
                    .HasColumnName("AWAL")
                    .HasColumnType("date");

                entity.Property(e => e.DanaEksternal)
                    .HasColumnName("DANA_EKSTERNAL")
                    .HasColumnType("money");

                entity.Property(e => e.DanaKerjasama)
                    .HasColumnName("DANA_KERJASAMA")
                    .HasColumnType("money");

                entity.Property(e => e.DanaPribadi)
                    .HasColumnName("DANA_PRIBADI")
                    .HasColumnType("money");

                entity.Property(e => e.DanaSetuju)
                    .HasColumnName("DANA_SETUJU")
                    .HasColumnType("money");

                entity.Property(e => e.DanaUajy)
                    .HasColumnName("DANA_UAJY")
                    .HasColumnType("money");

                entity.Property(e => e.Dokumen).HasColumnName("DOKUMEN");

                entity.Property(e => e.IdRoadMap).HasColumnName("ID_ROAD_MAP");

                entity.Property(e => e.IdSkim).HasColumnName("ID_SKIM");

                entity.Property(e => e.IdStatus).HasColumnName("ID_STATUS");

                entity.Property(e => e.IdSumber).HasColumnName("ID_SUMBER");

                entity.Property(e => e.IdTahunAnggaran).HasColumnName("ID_TAHUN_ANGGARAN");

                entity.Property(e => e.IdTemaUniversitas).HasColumnName("ID_TEMA_UNIVERSITAS");

                entity.Property(e => e.InsertDate)
                    .HasColumnName("INSERT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsChecked).HasColumnName("IS_CHECKED");

                entity.Property(e => e.IsDropped).HasColumnName("IS_DROPPED");

                entity.Property(e => e.IsSetujuDekan).HasColumnName("IS_SETUJU_DEKAN");

                entity.Property(e => e.IsSetujuLppm).HasColumnName("IS_SETUJU_LPPM");

                entity.Property(e => e.IsSetujuProdi).HasColumnName("IS_SETUJU_PRODI");

                entity.Property(e => e.JarakPtLokasi).HasColumnName("JARAK_PT_LOKASI");

                entity.Property(e => e.JenisPengabdian)
                    .HasColumnName("JENIS_PENGABDIAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JudulKegiatan)
                    .HasColumnName("JUDUL_KEGIATAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LandasanPenelitian)
                    .HasColumnName("LANDASAN_PENELITIAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Lokasi)
                    .HasColumnName("LOKASI")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Mitra)
                    .HasColumnName("MITRA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MitraKeahlian)
                    .HasColumnName("MITRA_KEAHLIAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NoSemester).HasColumnName("NO_SEMESTER");

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.NppReviewer)
                    .HasColumnName("NPP_REVIEWER")
                    .HasMaxLength(10);

                entity.Property(e => e.Outcome)
                    .HasColumnName("OUTCOME")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Output)
                    .HasColumnName("OUTPUT")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Reviewer1)
                    .IsRequired()
                    .HasColumnName("REVIEWER1")
                    .HasMaxLength(10);

                entity.Property(e => e.Reviewer2)
                    .IsRequired()
                    .HasColumnName("REVIEWER2")
                    .HasMaxLength(10);

                entity.Property(e => e.Sasaran)
                    .HasColumnName("SASARAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SksAnggota).HasColumnName("SKS_ANGGOTA");

                entity.Property(e => e.SksKetua).HasColumnName("SKS_KETUA");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPengabdianLolos>(entity =>
            {
                entity.HasKey(e => e.IdProposal);

                entity.ToTable("TBL_PENGABDIAN_LOLOS", "silppm");

                entity.Property(e => e.IdProposal)
                    .HasColumnName("ID_PROPOSAL")
                    .ValueGeneratedNever();

                entity.Property(e => e.Akhir)
                    .HasColumnName("AKHIR")
                    .HasColumnType("date");

                entity.Property(e => e.Anggota1)
                    .HasColumnName("ANGGOTA1")
                    .HasMaxLength(10);

                entity.Property(e => e.Anggota1Keahlian)
                    .HasColumnName("ANGGOTA1_KEAHLIAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Anggota2)
                    .HasColumnName("ANGGOTA2")
                    .HasMaxLength(10);

                entity.Property(e => e.Anggota2Keahlian)
                    .HasColumnName("ANGGOTA2_KEAHLIAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Awal)
                    .HasColumnName("AWAL")
                    .HasColumnType("date");

                entity.Property(e => e.DanaPribadi).HasColumnName("DANA_PRIBADI");

                entity.Property(e => e.DanaRekomen)
                    .HasColumnName("DANA_REKOMEN")
                    .HasColumnType("money");

                entity.Property(e => e.DanaSetuju)
                    .HasColumnName("DANA_SETUJU")
                    .HasColumnType("money");

                entity.Property(e => e.DanaUajy).HasColumnName("DANA_UAJY");

                entity.Property(e => e.Dokumen).HasColumnName("DOKUMEN");

                entity.Property(e => e.IdRoadMap).HasColumnName("ID_ROAD_MAP");

                entity.Property(e => e.IdStatus).HasColumnName("ID_STATUS");

                entity.Property(e => e.IdSumber).HasColumnName("ID_SUMBER");

                entity.Property(e => e.IdTahunAnggaran).HasColumnName("ID_TAHUN_ANGGARAN");

                entity.Property(e => e.InsertDate)
                    .HasColumnName("INSERT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsChecked).HasColumnName("IS_CHECKED");

                entity.Property(e => e.IsDropped).HasColumnName("IS_DROPPED");

                entity.Property(e => e.IsSetujuDekan).HasColumnName("IS_SETUJU_DEKAN");

                entity.Property(e => e.IsSetujuLppm).HasColumnName("IS_SETUJU_LPPM");

                entity.Property(e => e.IsSetujuProdi).HasColumnName("IS_SETUJU_PRODI");

                entity.Property(e => e.IsSetujuPustakawan).HasColumnName("IS_SETUJU_PUSTAKAWAN");

                entity.Property(e => e.JarakPtLokasi).HasColumnName("JARAK_PT_LOKASI");

                entity.Property(e => e.JenisPengabdian)
                    .HasColumnName("JENIS_PENGABDIAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JudulKegiatan)
                    .HasColumnName("JUDUL_KEGIATAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LandasanPenelitian)
                    .HasColumnName("LANDASAN_PENELITIAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Laporan).HasColumnName("LAPORAN");

                entity.Property(e => e.Laporan1).HasColumnName("LAPORAN1");

                entity.Property(e => e.Lokasi)
                    .HasColumnName("LOKASI")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Mitra)
                    .HasColumnName("MITRA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MitraKeahlian)
                    .HasColumnName("MITRA_KEAHLIAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.NppReviewer)
                    .HasColumnName("NPP_REVIEWER")
                    .HasMaxLength(10);

                entity.Property(e => e.Outcome)
                    .HasColumnName("OUTCOME")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Output)
                    .HasColumnName("OUTPUT")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Reviewer1)
                    .IsRequired()
                    .HasColumnName("REVIEWER1")
                    .HasMaxLength(10);

                entity.Property(e => e.Reviewer2)
                    .IsRequired()
                    .HasColumnName("REVIEWER2")
                    .HasMaxLength(10);

                entity.Property(e => e.Sasaran)
                    .HasColumnName("SASARAN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SksAnggota).HasColumnName("SKS_ANGGOTA");

                entity.Property(e => e.SksKetua).HasColumnName("SKS_KETUA");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPerpanjanganPenelitian>(entity =>
            {
                entity.HasKey(e => e.IdPerpanjangan);

                entity.ToTable("TBL_PERPANJANGAN_PENELITIAN", "silppm");

                entity.Property(e => e.IdPerpanjangan).HasColumnName("ID_PERPANJANGAN");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.InsertDate)
                    .HasColumnName("INSERT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ke).HasColumnName("KE");

                entity.Property(e => e.TglMulaiPerpanjang)
                    .HasColumnName("TGL_MULAI_PERPANJANG")
                    .HasColumnType("date");

                entity.Property(e => e.TglSelesaiPerpanjang)
                    .HasColumnName("TGL_SELESAI_PERPANJANG")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPerpanjanganPengabdian>(entity =>
            {
                entity.HasKey(e => e.IdPerpanjangan);

                entity.ToTable("TBL_PERPANJANGAN_PENGABDIAN", "silppm");

                entity.Property(e => e.IdPerpanjangan).HasColumnName("ID_PERPANJANGAN");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.InsertDate)
                    .HasColumnName("INSERT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ke).HasColumnName("KE");

                entity.Property(e => e.TglMulaiPerpanjang)
                    .HasColumnName("TGL_MULAI_PERPANJANG")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglSelesaiPerpanjang)
                    .HasColumnName("TGL_SELESAI_PERPANJANG")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPerpanjanganStudiLanjut>(entity =>
            {
                entity.HasKey(e => e.IdPerpanjanganStudiLanjut);

                entity.ToTable("TBL_PERPANJANGAN_STUDI_LANJUT", "simka");

                entity.Property(e => e.IdPerpanjanganStudiLanjut).HasColumnName("ID_PERPANJANGAN_STUDI_LANJUT");

                entity.Property(e => e.IdStudiLanjut).HasColumnName("ID_STUDI_LANJUT");

                entity.Property(e => e.IsApproved).HasColumnName("IS_APPROVED");

                entity.Property(e => e.PerpanjanganKe).HasColumnName("PERPANJANGAN_KE");

                entity.Property(e => e.SkPerpanjangan).HasColumnName("SK_PERPANJANGAN");

                entity.Property(e => e.TglPerpanjangan)
                    .HasColumnName("TGL_PERPANJANGAN")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdStudiLanjutNavigation)
                    .WithMany(p => p.TblPerpanjanganStudiLanjut)
                    .HasForeignKey(d => d.IdStudiLanjut)
                    .HasConstraintName("FK_TBL_PERPANJANGAN_STUDI_LANJUT_TBL_STUDI_LANJUT");
            });

            modelBuilder.Entity<TblPersonilPenelitian>(entity =>
            {
                entity.HasKey(e => e.IdPersonilPenelitian);

                entity.ToTable("TBL_PERSONIL_PENELITIAN", "silppm");

                entity.Property(e => e.IdPersonilPenelitian).HasColumnName("ID_PERSONIL_PENELITIAN");

                entity.Property(e => e.Alamat)
                    .HasColumnName("ALAMAT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AlamatKodepos)
                    .HasColumnName("ALAMAT_KODEPOS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AlamatKota)
                    .HasColumnName("ALAMAT_KOTA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AlamatProvinsi)
                    .HasColumnName("ALAMAT_PROVINSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BidangKeahlianPenelitian)
                    .HasColumnName("BIDANG_KEAHLIAN_PENELITIAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.IdRefFungsional).HasColumnName("ID_REF_FUNGSIONAL");

                entity.Property(e => e.IdRefGolongan)
                    .HasColumnName("ID_REF_GOLONGAN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefJbtnAkademik).HasColumnName("ID_REF_JBTN_AKADEMIK");

                entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT");

                entity.Property(e => e.IdUnitAkademik).HasColumnName("ID_UNIT_AKADEMIK");

                entity.Property(e => e.InstitusiAsal)
                    .HasColumnName("INSTITUSI_ASAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JnsKel)
                    .HasColumnName("JNS_KEL")
                    .HasColumnType("char(1)");

                entity.Property(e => e.NamaLengkapGelar)
                    .HasColumnName("NAMA_LENGKAP_GELAR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nidn)
                    .HasColumnName("NIDN")
                    .HasColumnType("char(15)");

                entity.Property(e => e.NipPns)
                    .HasColumnName("NIP_PNS")
                    .HasColumnType("char(15)");

                entity.Property(e => e.NoTelponHp)
                    .HasColumnName("NO_TELPON_HP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelponRumah)
                    .HasColumnName("NO_TELPON_RUMAH")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Npwp)
                    .HasColumnName("NPWP")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TempatLahir)
                    .HasColumnName("TEMPAT_LAHIR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TglLahir)
                    .HasColumnName("TGL_LAHIR")
                    .HasColumnType("datetime");

                entity.Property(e => e.Warganegara)
                    .HasColumnName("WARGANEGARA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRefFungsionalNavigation)
                    .WithMany(p => p.TblPersonilPenelitian)
                    .HasForeignKey(d => d.IdRefFungsional)
                    .HasConstraintName("FK_PERSONIL_PENELITIAN_F");

                entity.HasOne(d => d.IdRefGolonganNavigation)
                    .WithMany(p => p.TblPersonilPenelitian)
                    .HasForeignKey(d => d.IdRefGolongan)
                    .HasConstraintName("FK_PERSONIL_PENELITIAN_GOLONGAN");

                entity.HasOne(d => d.IdRefJbtnAkademikNavigation)
                    .WithMany(p => p.TblPersonilPenelitian)
                    .HasForeignKey(d => d.IdRefJbtnAkademik)
                    .HasConstraintName("FK_PERSONIL_PENELITIAN_JA");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.TblPersonilPenelitian)
                    .HasForeignKey(d => d.IdUnit)
                    .HasConstraintName("FK_PERSONIL_PENELITIAN_UNIT");
            });

            modelBuilder.Entity<TblPersonilPengabdian>(entity =>
            {
                entity.HasKey(e => e.IdPersonilPengabdian);

                entity.ToTable("TBL_PERSONIL_PENGABDIAN", "silppm");

                entity.Property(e => e.IdPersonilPengabdian).HasColumnName("ID_PERSONIL_PENGABDIAN");

                entity.Property(e => e.Alamat)
                    .HasColumnName("ALAMAT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AlamatKodepos)
                    .HasColumnName("ALAMAT_KODEPOS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AlamatKota)
                    .HasColumnName("ALAMAT_KOTA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AlamatProvinsi)
                    .HasColumnName("ALAMAT_PROVINSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BidangKeahlianPengabdian)
                    .HasColumnName("BIDANG_KEAHLIAN_PENGABDIAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.IdRefFungsional).HasColumnName("ID_REF_FUNGSIONAL");

                entity.Property(e => e.IdRefGolongan)
                    .HasColumnName("ID_REF_GOLONGAN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefJbtnAkademik).HasColumnName("ID_REF_JBTN_AKADEMIK");

                entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT");

                entity.Property(e => e.IdUnitAkademik).HasColumnName("ID_UNIT_AKADEMIK");

                entity.Property(e => e.InstitusiAsal)
                    .HasColumnName("INSTITUSI_ASAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JnsKel)
                    .HasColumnName("JNS_KEL")
                    .HasColumnType("char(1)");

                entity.Property(e => e.NamaLengkapGelar)
                    .HasColumnName("NAMA_LENGKAP_GELAR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nidn)
                    .HasColumnName("NIDN")
                    .HasColumnType("char(15)");

                entity.Property(e => e.NipPns)
                    .HasColumnName("NIP_PNS")
                    .HasColumnType("char(15)");

                entity.Property(e => e.NoTelponHp)
                    .HasColumnName("NO_TELPON_HP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelponRumah)
                    .HasColumnName("NO_TELPON_RUMAH")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Npwp)
                    .HasColumnName("NPWP")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TempatLahir)
                    .HasColumnName("TEMPAT_LAHIR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TglLahir)
                    .HasColumnName("TGL_LAHIR")
                    .HasColumnType("datetime");

                entity.Property(e => e.Warganegara)
                    .HasColumnName("WARGANEGARA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRefFungsionalNavigation)
                    .WithMany(p => p.TblPersonilPengabdian)
                    .HasForeignKey(d => d.IdRefFungsional)
                    .HasConstraintName("FK_PERSONIL_PENGABDIAN_F");

                entity.HasOne(d => d.IdRefGolonganNavigation)
                    .WithMany(p => p.TblPersonilPengabdian)
                    .HasForeignKey(d => d.IdRefGolongan)
                    .HasConstraintName("FK_PERSONIL_PENGABDIAN_GOLONGAN");

                entity.HasOne(d => d.IdRefJbtnAkademikNavigation)
                    .WithMany(p => p.TblPersonilPengabdian)
                    .HasForeignKey(d => d.IdRefJbtnAkademik)
                    .HasConstraintName("FK_PERSONIL_PENGABDIAN_JA");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.TblPersonilPengabdian)
                    .HasForeignKey(d => d.IdUnit)
                    .HasConstraintName("FK_PERSONIL_PENGABDIAN_UNIT");
            });

            modelBuilder.Entity<TblPesertaTest>(entity =>
            {
                entity.HasKey(e => e.IdCalonKaryawan);

                entity.ToTable("TBL_PESERTA_TEST", "simka");

                entity.HasIndex(e => e.IdJenisTest)
                    .HasName("RELATION_309_FK");

                entity.Property(e => e.IdCalonKaryawan)
                    .HasColumnName("ID_CALON_KARYAWAN")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdJenisTest).HasColumnName("ID_JENIS_TEST");

                entity.Property(e => e.TglTest)
                    .HasColumnName("TGL_TEST")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalNilai)
                    .HasColumnName("TOTAL_NILAI")
                    .HasColumnType("char(10)");

                entity.HasOne(d => d.IdCalonKaryawanNavigation)
                    .WithOne(p => p.TblPesertaTest)
                    .HasForeignKey<TblPesertaTest>(d => d.IdCalonKaryawan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATION_299");

                entity.HasOne(d => d.IdJenisTestNavigation)
                    .WithMany(p => p.TblPesertaTest)
                    .HasForeignKey(d => d.IdJenisTest)
                    .HasConstraintName("FK_RELATION_309");
            });

            modelBuilder.Entity<TblRabPenelitian>(entity =>
            {
                entity.HasKey(e => e.IdRabPenelitian);

                entity.ToTable("TBL_RAB_PENELITIAN", "silppm");

                entity.Property(e => e.IdRabPenelitian).HasColumnName("ID_RAB_PENELITIAN");

                entity.Property(e => e.IdPengeluaranRab).HasColumnName("ID_PENGELUARAN_RAB");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.JumlahDana)
                    .HasColumnName("JUMLAH_DANA")
                    .HasColumnType("money");

                entity.Property(e => e.Persentase)
                    .HasColumnName("PERSENTASE")
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.IdPengeluaranRabNavigation)
                    .WithMany(p => p.TblRabPenelitian)
                    .HasForeignKey(d => d.IdPengeluaranRab)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RAB_PENELITIAN_REF");
            });

            modelBuilder.Entity<TblRabPengabdian>(entity =>
            {
                entity.HasKey(e => e.IdRabPengabdian);

                entity.ToTable("TBL_RAB_PENGABDIAN", "silppm");

                entity.Property(e => e.IdRabPengabdian).HasColumnName("ID_RAB_PENGABDIAN");

                entity.Property(e => e.IdPengeluaranRab).HasColumnName("ID_PENGELUARAN_RAB");

                entity.Property(e => e.IdProposal).HasColumnName("ID_PROPOSAL");

                entity.Property(e => e.JumlahDana)
                    .HasColumnName("JUMLAH_DANA")
                    .HasColumnType("money");

                entity.Property(e => e.Persentase)
                    .HasColumnName("PERSENTASE")
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.IdPengeluaranRabNavigation)
                    .WithMany(p => p.TblRabPengabdian)
                    .HasForeignKey(d => d.IdPengeluaranRab)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RAB_PENGABDIAN_REF");
            });

            modelBuilder.Entity<TblRoleSubmenu>(entity =>
            {
                entity.HasKey(e => new { e.IdSiSubmenu, e.IdRole });

                entity.ToTable("TBL_ROLE_SUBMENU", "siatmax");

                entity.Property(e => e.IdSiSubmenu).HasColumnName("ID_SI_SUBMENU");

                entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.TblRoleSubmenu)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ROLE_SUBMENU");

                entity.HasOne(d => d.IdSiSubmenuNavigation)
                    .WithMany(p => p.TblRoleSubmenu)
                    .HasForeignKey(d => d.IdSiSubmenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ROLE_SUBMENU2");
            });

            modelBuilder.Entity<TblSemesterAkademik>(entity =>
            {
                entity.HasKey(e => new { e.NoSemester, e.IdTahunAkademik });

                entity.ToTable("TBL_SEMESTER_AKADEMIK", "siatmax");

                entity.Property(e => e.NoSemester).HasColumnName("NO_SEMESTER");

                entity.Property(e => e.IdTahunAkademik).HasColumnName("ID_TAHUN_AKADEMIK");

                entity.Property(e => e.Iscurrent)
                    .HasColumnName("ISCURRENT")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SemesterAkademik)
                    .HasColumnName("SEMESTER_AKADEMIK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterAkademikEng)
                    .HasColumnName("SEMESTER_AKADEMIK_ENG")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTahunAkademikNavigation)
                    .WithMany(p => p.TblSemesterAkademik)
                    .HasForeignKey(d => d.IdTahunAkademik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATION_200");
            });

            modelBuilder.Entity<TblSiMenu>(entity =>
            {
                entity.HasKey(e => e.IdSiMenu);

                entity.ToTable("TBL_SI_MENU", "siatmax");

                entity.HasIndex(e => e.IdSistemInformasi)
                    .HasName("RELATION_85_FK");

                entity.Property(e => e.IdSiMenu).HasColumnName("ID_SI_MENU");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdSistemInformasi).HasColumnName("ID_SISTEM_INFORMASI");

                entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");

                entity.Property(e => e.Link)
                    .HasColumnName("LINK")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoUrut).HasColumnName("NO_URUT");

                entity.HasOne(d => d.IdSistemInformasiNavigation)
                    .WithMany(p => p.TblSiMenu)
                    .HasForeignKey(d => d.IdSistemInformasi)
                    .HasConstraintName("FK_RELATION_85");
            });

            modelBuilder.Entity<TblSistemInformasi>(entity =>
            {
                entity.HasKey(e => e.IdSistemInformasi);

                entity.ToTable("TBL_SISTEM_INFORMASI", "siatmax");

                entity.Property(e => e.IdSistemInformasi)
                    .HasColumnName("ID_SISTEM_INFORMASI")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaSi)
                    .HasColumnName("NAMA_SI")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Server)
                    .HasColumnName("SERVER")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSiSubmenu>(entity =>
            {
                entity.HasKey(e => e.IdSiSubmenu);

                entity.ToTable("TBL_SI_SUBMENU", "siatmax");

                entity.HasIndex(e => e.IdSiMenu)
                    .HasName("RELATION_90_FK");

                entity.Property(e => e.IdSiSubmenu).HasColumnName("ID_SI_SUBMENU");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdSiMenu).HasColumnName("ID_SI_MENU");

                entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");

                entity.Property(e => e.Link)
                    .HasColumnName("LINK")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSiMenuNavigation)
                    .WithMany(p => p.TblSiSubmenu)
                    .HasForeignKey(d => d.IdSiMenu)
                    .HasConstraintName("FK_RELATION_90");
            });

            modelBuilder.Entity<TblStudiLanjut>(entity =>
            {
                entity.HasKey(e => e.IdStudiLanjut);

                entity.ToTable("TBL_STUDI_LANJUT", "simka");

                entity.Property(e => e.IdStudiLanjut).HasColumnName("ID_STUDI_LANJUT");

                entity.Property(e => e.DlmNegriLuarNegri)
                    .HasColumnName("DLM_NEGRI_LUAR_NEGRI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fakultas)
                    .HasColumnName("FAKULTAS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefJenjang).HasColumnName("ID_REF_JENJANG");

                entity.Property(e => e.IdRefSs).HasColumnName("ID_REF_SS");

                entity.Property(e => e.KotaSekolah)
                    .HasColumnName("KOTA_SEKOLAH")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaSekolah)
                    .HasColumnName("NAMA_SEKOLAH")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NegaraSekolah)
                    .HasColumnName("NEGARA_SEKOLAH")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoSkTugasBljr)
                    .HasColumnName("NO_SK_TUGAS_BLJR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Prodi)
                    .HasColumnName("PRODI")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sk).HasColumnName("SK");

                entity.Property(e => e.SkPenempatanKmbl).HasColumnName("SK_PENEMPATAN_KMBL");

                entity.Property(e => e.TargetLulus).HasColumnName("TARGET_LULUS");

                entity.Property(e => e.TglLulus)
                    .HasColumnName("TGL_LULUS")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglMulai)
                    .HasColumnName("TGL_MULAI")
                    .HasColumnType("datetime");

                entity.Property(e => e.TglPenempatanKmbli)
                    .HasColumnName("TGL_PENEMPATAN_KMBLI")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdRefJenjangNavigation)
                    .WithMany(p => p.TblStudiLanjut)
                    .HasForeignKey(d => d.IdRefJenjang)
                    .HasConstraintName("FK_TBL_STUDI_LANJUT_REF_JENJANG");

                entity.HasOne(d => d.IdRefSsNavigation)
                    .WithMany(p => p.TblStudiLanjut)
                    .HasForeignKey(d => d.IdRefSs)
                    .HasConstraintName("FK_TBL_STUDI_LANJUT_REF_STATUS_STUDI");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TblStudiLanjut)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_TBL_STUDI_LANJUT_MST_KARYAWAN");
            });

            modelBuilder.Entity<TblSumberBiayaSl>(entity =>
            {
                entity.HasKey(e => e.IdSumberBiayaSl);

                entity.ToTable("TBL_SUMBER_BIAYA_SL", "simka");

                entity.Property(e => e.IdSumberBiayaSl).HasColumnName("ID_SUMBER_BIAYA_SL");

                entity.Property(e => e.IdStudiLanjut).HasColumnName("ID_STUDI_LANJUT");

                entity.Property(e => e.IdSumberBiaya).HasColumnName("ID_SUMBER_BIAYA");

                entity.Property(e => e.SumberBiayaKe).HasColumnName("SUMBER_BIAYA_KE");

                entity.HasOne(d => d.IdStudiLanjutNavigation)
                    .WithMany(p => p.TblSumberBiayaSl)
                    .HasForeignKey(d => d.IdStudiLanjut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_SUMBER_BIAYA_SL_TBL_STUDI_LANJUT");

                entity.HasOne(d => d.IdSumberBiayaNavigation)
                    .WithMany(p => p.TblSumberBiayaSl)
                    .HasForeignKey(d => d.IdSumberBiaya)
                    .HasConstraintName("FK_TBL_SUMBER_BIAYA_SL_REF_SUMBER_BIAYA");
            });

            modelBuilder.Entity<TblTahunAkademik>(entity =>
            {
                entity.HasKey(e => e.IdTahunAkademik);

                entity.ToTable("TBL_TAHUN_AKADEMIK", "siatmax");

                entity.Property(e => e.IdTahunAkademik)
                    .HasColumnName("ID_TAHUN_AKADEMIK")
                    .ValueGeneratedNever();

                entity.Property(e => e.Iscurrent).HasColumnName("ISCURRENT");

                entity.Property(e => e.Tahun).HasColumnName("TAHUN");

                entity.Property(e => e.TahunAkademik)
                    .HasColumnName("TAHUN_AKADEMIK")
                    .HasColumnType("char(10)");
            });

            modelBuilder.Entity<TblTahunAnggaran>(entity =>
            {
                entity.HasKey(e => e.IdTahunAnggaran);

                entity.ToTable("TBL_TAHUN_ANGGARAN", "sikeu");

                entity.Property(e => e.IdTahunAnggaran)
                    .HasColumnName("ID_TAHUN_ANGGARAN")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsCurrent).HasColumnName("IS_CURRENT");

                entity.Property(e => e.TahunAnggaran)
                    .HasColumnName("TAHUN_ANGGARAN")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsulanDiterima>(entity =>
            {
                entity.HasKey(e => e.IdMstUr);

                entity.ToTable("TBL_USULAN_DITERIMA", "simka");

                entity.HasIndex(e => e.Npp)
                    .HasName("RELATION_273_FK");

                entity.Property(e => e.IdMstUr)
                    .HasColumnName("ID_MST_UR")
                    .ValueGeneratedNever();

                entity.Property(e => e.Jumlah).HasColumnName("JUMLAH");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.TglDisetujui)
                    .HasColumnName("TGL_DISETUJUI")
                    .HasColumnType("char(10)");

                entity.HasOne(d => d.IdMstUrNavigation)
                    .WithOne(p => p.TblUsulanDiterima)
                    .HasForeignKey<TblUsulanDiterima>(d => d.IdMstUr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATION_272");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TblUsulanDiterima)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATION_273");
            });

            modelBuilder.Entity<TblUsulanRekrutmen>(entity =>
            {
                entity.HasKey(e => e.IdMstUr);

                entity.ToTable("TBL_USULAN_REKRUTMEN", "simka");

                entity.HasIndex(e => e.IdUnit)
                    .HasName("RELATION_266_FK");

                entity.HasIndex(e => new { e.IdTahunAkademik, e.NoSemester })
                    .HasName("RELATION_3679_FK");

                entity.Property(e => e.IdMstUr)
                    .HasColumnName("ID_MST_UR")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTahunAkademik).HasColumnName("ID_TAHUN_AKADEMIK");

                entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT");

                entity.Property(e => e.Ipk).HasColumnName("IPK");

                entity.Property(e => e.Jumlah).HasColumnName("JUMLAH");

                entity.Property(e => e.NoSemester).HasColumnName("NO_SEMESTER");

                entity.Property(e => e.PendidikanTerakhir)
                    .HasColumnName("PENDIDIKAN_TERAKHIR")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.SpesifikasiKetrampilan)
                    .HasColumnName("SPESIFIKASI_KETRAMPILAN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpesikasiAkademik)
                    .HasColumnName("SPESIKASI_AKADEMIK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TglUsulan)
                    .HasColumnName("TGL_USULAN")
                    .HasColumnType("datetime");

                entity.Property(e => e.UmurMax).HasColumnName("UMUR_MAX");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.TblUsulanRekrutmen)
                    .HasForeignKey(d => d.IdUnit)
                    .HasConstraintName("FK_RELATION_266");
            });

            modelBuilder.Entity<TrCuti>(entity =>
            {
                entity.HasKey(e => e.IdCuti);

                entity.ToTable("TR_CUTI", "simka");

                entity.Property(e => e.IdCuti).HasColumnName("ID_CUTI");

                entity.Property(e => e.Deskripsi)
                    .HasColumnName("DESKRIPSI")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.File)
                    .HasColumnName("FILE")
                    .HasColumnType("image");

                entity.Property(e => e.IsConfirmed).HasColumnName("IS_CONFIRMED");

                entity.Property(e => e.JenisCuti)
                    .HasColumnName("JENIS_CUTI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.TahunTakwim).HasColumnName("TAHUN_TAKWIM");

                entity.Property(e => e.TglCutiAkhir)
                    .HasColumnName("TGL_CUTI_AKHIR")
                    .HasColumnType("date");

                entity.Property(e => e.TglCutiAwal)
                    .HasColumnName("TGL_CUTI_AWAL")
                    .HasColumnType("date");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TrCuti)
                    .HasForeignKey(d => d.Npp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TR_CUTI_MST_KARYAWAN");
            });

            modelBuilder.Entity<TrDp3>(entity =>
            {
                entity.HasKey(e => e.IdTrDp3);

                entity.ToTable("TR_DP3", "simka");

                entity.Property(e => e.IdTrDp3).HasColumnName("ID_TR_DP3");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Rerata)
                    .HasColumnName("RERATA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Tahun)
                    .HasColumnName("TAHUN")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.TglPenilaian)
                    .HasColumnName("TGL_PENILAIAN")
                    .HasColumnType("date");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TrDp3)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_TR_DP3_MST_KARYAWAN");
            });

            modelBuilder.Entity<TrHonor>(entity =>
            {
                entity.HasKey(e => e.IdTrHonor);

                entity.ToTable("TR_HONOR", "simka");

                entity.HasIndex(e => e.Npp)
                    .HasName("RELATION_4126_FK");

                entity.Property(e => e.IdTrHonor)
                    .HasColumnName("ID_TR_HONOR")
                    .ValueGeneratedNever();

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.Pajak)
                    .HasColumnName("PAJAK")
                    .HasColumnType("money");

                entity.Property(e => e.TotalHonor)
                    .HasColumnName("TOTAL_HONOR")
                    .HasColumnType("money");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TrHonor)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATION_4126");
            });

            modelBuilder.Entity<TrHutangP>(entity =>
            {
                entity.HasKey(e => e.IdTrHutang);

                entity.ToTable("TR_HUTANG_P", "simka");

                entity.HasIndex(e => e.IdRefPotongan)
                    .HasName("RELATION_4117_FK");

                entity.HasIndex(e => e.Npp)
                    .HasName("RELATION_4094_FK");

                entity.Property(e => e.IdTrHutang).HasColumnName("ID_TR_HUTANG");

                entity.Property(e => e.BesarCicilan)
                    .HasColumnName("BESAR_CICILAN")
                    .HasColumnType("money");

                entity.Property(e => e.BulanMulaiBayar)
                    .HasColumnName("BULAN_MULAI_BAYAR")
                    .HasColumnType("datetime");

                entity.Property(e => e.Bunga).HasColumnName("BUNGA");

                entity.Property(e => e.Cicilan).HasColumnName("CICILAN");

                entity.Property(e => e.CicilanDp).HasColumnName("CICILAN_DP");

                entity.Property(e => e.IdRefPotongan).HasColumnName("ID_REF_POTONGAN");

                entity.Property(e => e.IdTrRestitusi).HasColumnName("ID_TR_RESTITUSI");

                entity.Property(e => e.Nominal)
                    .HasColumnName("NOMINAL")
                    .HasColumnType("money");

                entity.Property(e => e.NominalDp)
                    .HasColumnName("NOMINAL_DP")
                    .HasColumnType("money");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.SisaNominal)
                    .HasColumnName("SISA_NOMINAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdRefPotonganNavigation)
                    .WithMany(p => p.TrHutangP)
                    .HasForeignKey(d => d.IdRefPotongan)
                    .HasConstraintName("FK_RELATION_4117");

                entity.HasOne(d => d.IdTrRestitusiNavigation)
                    .WithMany(p => p.TrHutangP)
                    .HasForeignKey(d => d.IdTrRestitusi)
                    .HasConstraintName("FK_TR_HUTANG_P_TR_RESTITUSI");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TrHutangP)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATION_4094");
            });

            modelBuilder.Entity<TrKarirFungsional>(entity =>
            {
                entity.HasKey(e => e.IdKarir);

                entity.ToTable("TR_KARIR_FUNGSIONAL", "simka");

                entity.HasIndex(e => e.NoSk)
                    .HasName("RELATION_233_FK");

                entity.HasIndex(e => e.Npp)
                    .HasName("RELATION_89_FK");

                entity.Property(e => e.IdKarir).HasColumnName("ID_KARIR");

                entity.Property(e => e.BidangIlmu)
                    .HasColumnName("BIDANG_ILMU")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BidangIlmu2)
                    .HasColumnName("BIDANG_ILMU_2")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BidangIlmu3)
                    .HasColumnName("BIDANG_ILMU_3")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefJbtnAkademik).HasColumnName("ID_REF_JBTN_AKADEMIK");

                entity.Property(e => e.IdRefJbtnAkademikSblm).HasColumnName("ID_REF_JBTN_AKADEMIK_SBLM");

                entity.Property(e => e.IsLast).HasColumnName("IS_LAST");

                entity.Property(e => e.JenisLokalNas)
                    .HasColumnName("JENIS_LOKAL_NAS")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NilaiA).HasColumnName("NILAI_A");

                entity.Property(e => e.NilaiB).HasColumnName("NILAI_B");

                entity.Property(e => e.NilaiC).HasColumnName("NILAI_C");

                entity.Property(e => e.NilaiD).HasColumnName("NILAI_D");

                entity.Property(e => e.NilaiTotal).HasColumnName("NILAI_TOTAL");

                entity.Property(e => e.NoSk)
                    .IsRequired()
                    .HasColumnName("NO_SK")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.TglBerikut)
                    .HasColumnName("TGL_BERIKUT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tmt)
                    .HasColumnName("TMT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdRefJbtnAkademikNavigation)
                    .WithMany(p => p.TrKarirFungsionalIdRefJbtnAkademikNavigation)
                    .HasForeignKey(d => d.IdRefJbtnAkademik)
                    .HasConstraintName("FK_TR_KARIR_FUNGSIONAL_REF_JABATAN_AKADEMIK");

                entity.HasOne(d => d.IdRefJbtnAkademikSblmNavigation)
                    .WithMany(p => p.TrKarirFungsionalIdRefJbtnAkademikSblmNavigation)
                    .HasForeignKey(d => d.IdRefJbtnAkademikSblm)
                    .HasConstraintName("FK_TR_KARIR_FUNGSIONAL_REF_JABATAN_AKADEMIK1");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TrKarirFungsional)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATION_1964");
            });

           modelBuilder.Entity<TrKarirGolongan>(entity =>
            {
                entity.HasKey(e => e.IdTrKarirGolongan);

                entity.ToTable("TR_KARIR_GOLONGAN", "simka");

                entity.HasIndex(e => e.IdRefGolonganBaru)
                    .HasName("RELATION_2690_FK");

                entity.HasIndex(e => e.IdRefGolonganLama)
                    .HasName("RELATION_2687_FK");

                entity.HasIndex(e => e.NoSk)
                    .HasName("RELATION_1608_FK");

                entity.HasIndex(e => e.Npp)
                    .HasName("RELATION_1607_FK");

                entity.Property(e => e.IdTrKarirGolongan).HasColumnName("ID_TR_KARIR_GOLONGAN");

                entity.Property(e => e.DateInserted)
                    .HasColumnName("DATE_INSERTED")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdRefGolonganBaru)
                    .HasColumnName("ID_REF_GOLONGAN_BARU")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefGolonganLama)
                    .HasColumnName("ID_REF_GOLONGAN_LAMA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsLast).HasColumnName("IS_LAST");

                entity.Property(e => e.JenisLokalNas)
                    .HasColumnName("JENIS_LOKAL_NAS")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MasaKerjaGol).HasColumnName("MASA_KERJA_GOL");

                entity.Property(e => e.Nilai).HasColumnName("NILAI");

                entity.Property(e => e.NilaiA).HasColumnName("NILAI_A");

                entity.Property(e => e.NilaiB).HasColumnName("NILAI_B");

                entity.Property(e => e.NilaiC).HasColumnName("NILAI_C");

                entity.Property(e => e.NilaiD).HasColumnName("NILAI_D");

                entity.Property(e => e.NoSk)
                    .IsRequired()
                    .HasColumnName("NO_SK")
                    .HasMaxLength(20);

                entity.Property(e => e.Npp)
                    .IsRequired()
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.TglBerikut)
                    .HasColumnName("TGL_BERIKUT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tmt)
                    .HasColumnName("TMT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TrKarirGolongan)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATsON_192as64");

            });

             modelBuilder.Entity<TrKarirStruktural>(entity =>
             {
                 entity.HasKey(e => new
                 {
                     e.Npp,
                     e.NoSk
                 }
                 );


                 entity.ToTable("TR_KARIR_SRUKTURAL", "simka");

                 entity.HasIndex(e => e.NoSk)
                     .HasName("RELATION_2323_FK");

                 entity.HasIndex(e => e.Npp)
                     .HasName("RELATION_839a_FK");



                 entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT"); 
                 entity.Property(e => e.IdRefStruktural).HasColumnName("ID_REF_STRUKTURAL");

                 entity.Property(e => e.MstIdUnit).HasColumnName("MST_ID_UNIT");

                 entity.Property(e => e.IsLast).HasColumnName("IS_LAST");



                 entity.Property(e => e.TglAwal).HasColumnName("TGL_AWAL");

                 entity.Property(e => e.TglAkhir).HasColumnName("TGL_AKHIR");

                 entity.Property(e => e.Status).HasColumnName("STATUS");


                 entity.Property(e => e.NoSk)
                     .IsRequired()
                     .HasColumnName("NO_SK")
                     .HasMaxLength(150)
                     .IsUnicode(false);

                 entity.Property(e => e.Npp)
                     .IsRequired()
                     .HasColumnName("NPP")
                     .HasMaxLength(10);               

                 entity.HasOne(d => d.IdUnitNavigation)
                     .WithMany(p => p.TrKarirStrukturalIdUnitNavigation)
                     .HasForeignKey(d => d.IdUnit)
                     .HasConstraintName("FK_TR_KARIR_FUNGSIONAL_REF_JABATAN_2AKADEMIK");


                 entity.HasOne(d => d.NppNavigation)
                     .WithMany(p => p.TrKarirStruktural)
                     .HasForeignKey(d => d.Npp)
                     .HasConstraintName("FK_RELATsON_19264");
                 entity.HasOne(d => d.IdRefStrukturalNavigation)
                     .WithMany(p => p.RefJabatanStrukturals)
                     .HasForeignKey(d => d.IdRefStruktural )
                     .HasConstraintName("FK_RELATsON_1926ss4");
             });
              
            modelBuilder.Entity<TrKegiatan>(entity =>
                 {
                     entity.HasKey(e => e.IdTrKegiatan);

                     entity.ToTable("TR_KEGIATAN", "simka");

                     entity.Property(e => e.IdTrKegiatan).HasColumnName("ID_TR_KEGIATAN");

                     entity.Property(e => e.FileKegiatan)
                         .HasColumnName("FILE_KEGIATAN")
                         .HasColumnType("image");

                     entity.Property(e => e.IdRefKegiatan).HasColumnName("ID_REF_KEGIATAN");

                     entity.Property(e => e.NamaKegiatan).HasColumnName("NAMA_KEGIATAN");

                     entity.Property(e => e.Npp)
                         .HasColumnName("NPP")
                         .HasMaxLength(10);

                     entity.Property(e => e.Peran)
                         .HasColumnName("PERAN")
                         .HasMaxLength(50);

                     entity.Property(e => e.Tempat)
                         .HasColumnName("TEMPAT")
                         .HasMaxLength(50)
                         .IsUnicode(false);

                     entity.Property(e => e.TglMulai)
                         .HasColumnName("TGL_MULAI")
                         .HasColumnType("datetime");

                     entity.Property(e => e.TglSelesai)
                         .HasColumnName("TGL_SELESAI")
                         .HasColumnType("datetime");

                     entity.Property(e => e.Tingkat)
                         .HasColumnName("TINGKAT")
                         .HasMaxLength(50)
                         .IsUnicode(false);

                     entity.HasOne(d => d.IdRefKegiatanNavigation)
                         .WithMany(p => p.TrKegiatan)
                         .HasForeignKey(d => d.IdRefKegiatan)
                         .HasConstraintName("FK_TR_KEGIATAN_REF_KEGIATAN");

                     entity.HasOne(d => d.NppNavigation)
                         .WithMany(p => p.TrKegiatan)
                         .HasForeignKey(d => d.Npp)
                         .HasConstraintName("FK_TR_KEGIATAN_MST_KARYAWAN");
                 });

                 modelBuilder.Entity<TrKenaikanPangkat>(entity =>
                 {
                     entity.HasKey(e => e.IdTrKenaikanPangkat);

                     entity.ToTable("TR_KENAIKAN_PANGKAT", "simka");

                     entity.Property(e => e.IdTrKenaikanPangkat).HasColumnName("ID_TR_KENAIKAN_PANGKAT");

                     entity.Property(e => e.GajiAwal)
                         .HasColumnName("GAJI_AWAL")
                         .HasColumnType("money");

                     entity.Property(e => e.GajiBerikutnya)
                         .HasColumnName("GAJI_BERIKUTNYA")
                         .HasColumnType("money");

                     entity.Property(e => e.GolAwal)
                         .HasColumnName("GOL_AWAL")
                         .HasMaxLength(10)
                         .IsUnicode(false);

                     entity.Property(e => e.GolBerikutnya)
                         .HasColumnName("GOL_BERIKUTNYA")
                         .HasMaxLength(10)
                         .IsUnicode(false);

                     entity.Property(e => e.NoSk)
                         .HasColumnName("NO_SK")
                         .HasMaxLength(100)
                         .IsUnicode(false);

                     entity.Property(e => e.Npp)
                         .HasColumnName("NPP")
                         .HasMaxLength(10);

                     entity.Property(e => e.TglKenaikan)
                         .HasColumnName("TGL_KENAIKAN")
                         .HasColumnType("date");

                     entity.Property(e => e.TglKenaikanBerikutnya)
                         .HasColumnName("TGL_KENAIKAN_BERIKUTNYA")
                         .HasColumnType("date");

                     entity.HasOne(d => d.NoSkNavigation)
                         .WithMany(p => p.TrKenaikanPangkat)
                         .HasForeignKey(d => d.NoSk)
                         .HasConstraintName("FK_TR_KENAIKAN_PANGKAT_HST_SK");

                     entity.HasOne(d => d.NppNavigation)
                         .WithMany(p => p.TrKenaikanPangkat)
                         .HasForeignKey(d => d.Npp)
                         .HasConstraintName("FK_TR_KENAIKAN_PANGKAT_MST_KARYAWAN");
                 });

                 modelBuilder.Entity<TrKgb>(entity =>
                 {
                     entity.HasKey(e => e.IdTrKgb);

                     entity.ToTable("TR_KGB", "simka");

                     entity.Property(e => e.IdTrKgb).HasColumnName("ID_TR_KGB");

                     entity.Property(e => e.GajiAwal)
                         .HasColumnName("GAJI_AWAL")
                         .HasColumnType("money");

                     entity.Property(e => e.GajiBerikutnya)
                         .HasColumnName("GAJI_BERIKUTNYA")
                         .HasColumnType("money");

                     entity.Property(e => e.NoSk)
                         .HasColumnName("NO_SK")
                         .HasMaxLength(100)
                         .IsUnicode(false);

                     entity.Property(e => e.Npp)
                         .HasColumnName("NPP")
                         .HasMaxLength(10);

                     entity.Property(e => e.TglKenaikan)
                         .HasColumnName("TGL_KENAIKAN")
                         .HasColumnType("date");

                     entity.Property(e => e.TglKenaikanBerikutnya)
                         .HasColumnName("TGL_KENAIKAN_BERIKUTNYA")
                         .HasColumnType("date");

                     entity.HasOne(d => d.NoSkNavigation)
                         .WithMany(p => p.TrKgb)
                         .HasForeignKey(d => d.NoSk)
                         .HasConstraintName("FK_TR_KGB_HST_SK");

                     entity.HasOne(d => d.NppNavigation)
                         .WithMany(p => p.TrKgb)
                         .HasForeignKey(d => d.Npp)
                         .HasConstraintName("FK_TR_KGB_MST_KARYAWAN");
                 });

                 modelBuilder.Entity<TrMember>(entity =>
                 {
                     entity.HasKey(e => new { e.Npp, e.IdTrPengembangan });

                     entity.ToTable("TR_MEMBER", "simka");

                     entity.Property(e => e.Npp)
                         .HasColumnName("NPP")
                         .HasMaxLength(10);

                     entity.Property(e => e.IdTrPengembangan).HasColumnName("ID_TR_PENGEMBANGAN");

                     entity.Property(e => e.Peran)
                         .HasColumnName("PERAN")
                         .HasMaxLength(50);

                     entity.HasOne(d => d.IdTrPengembanganNavigation)
                         .WithMany(p => p.TrMember)
                         .HasForeignKey(d => d.IdTrPengembangan)
                         .OnDelete(DeleteBehavior.ClientSetNull)
                         .HasConstraintName("FK_RELATION_2005");

                     entity.HasOne(d => d.NppNavigation)
                         .WithMany(p => p.TrMember)
                         .HasForeignKey(d => d.Npp)
                         .OnDelete(DeleteBehavior.ClientSetNull)
                         .HasConstraintName("FK_RELATION_1999");
                 });

                 modelBuilder.Entity<TrMutasi>(entity =>
                 {
                     entity.HasKey(e => e.IdTrMutasi);

                     entity.ToTable("TR_MUTASI", "simka");

                     entity.HasIndex(e => e.IdUnit)
                         .HasName("RELATION_1968_FK");

                     entity.HasIndex(e => e.MstIdUnit)
                         .HasName("RELATION_1970_FK");

                     entity.HasIndex(e => e.NoSk)
                         .HasName("RELATION_1969_FK");

                     entity.HasIndex(e => e.Npp)
                         .HasName("RELATION_1964_FK");

                     entity.Property(e => e.IdTrMutasi).HasColumnName("ID_TR_MUTASI");

                     entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT");

                     entity.Property(e => e.MstIdUnit).HasColumnName("MST_ID_UNIT");

                     entity.Property(e => e.NoSk)
                         .HasColumnName("NO_SK")
                         .HasMaxLength(20);

                     entity.Property(e => e.Npp)
                         .HasColumnName("NPP")
                         .HasMaxLength(10);

                     entity.HasOne(d => d.IdUnitNavigation)
                         .WithMany(p => p.TrMutasiIdUnitNavigation)
                         .HasForeignKey(d => d.IdUnit)
                         .HasConstraintName("FK_RELATION_1968");

                     entity.HasOne(d => d.MstIdUnitNavigation)
                         .WithMany(p => p.TrMutasiMstIdUnitNavigation)
                         .HasForeignKey(d => d.MstIdUnit)
                         .HasConstraintName("FK_RELATION_1970");

                     entity.HasOne(d => d.NppNavigation)
                         .WithMany(p => p.TrMutasi)
                         .HasForeignKey(d => d.Npp)
                         .HasConstraintName("FK_RELATION_1964");
                 });

                 modelBuilder.Entity<TrPayroll>(entity =>
                 {
                     entity.HasKey(e => e.IdTrPayroll);

                     entity.ToTable("TR_PAYROLL", "simka");

                     entity.HasIndex(e => e.NoSemester)
                         .HasName("RELATION_4068_FK");

                     entity.HasIndex(e => e.Npp)
                         .HasName("RELATION_4083_FK");

                     entity.Property(e => e.IdTrPayroll).HasColumnName("ID_TR_PAYROLL");

                     entity.Property(e => e.Bulan)
                         .HasColumnName("BULAN")
                         .HasColumnType("datetime");

                     entity.Property(e => e.NoSemester).HasColumnName("NO_SEMESTER");

                     entity.Property(e => e.Npp)
                         .HasColumnName("NPP")
                         .HasMaxLength(10);

                     entity.Property(e => e.Pajak)
                         .HasColumnName("PAJAK")
                         .HasColumnType("money");

                     entity.Property(e => e.TotalBersih)
                         .HasColumnName("TOTAL_BERSIH")
                         .HasColumnType("money");

                     entity.Property(e => e.TotalPiutang)
                         .HasColumnName("TOTAL_PIUTANG")
                         .HasColumnType("money");

                     entity.Property(e => e.TotalPotongan)
                         .HasColumnName("TOTAL_POTONGAN")
                         .HasColumnType("money");

                     entity.Property(e => e.TotalTerima)
                         .HasColumnName("TOTAL_TERIMA")
                         .HasColumnType("money");

                     entity.HasOne(d => d.NppNavigation)
                         .WithMany(p => p.TrPayroll)
                         .HasForeignKey(d => d.Npp)
                         .HasConstraintName("FK_RELATION_4083");
                 });

                 modelBuilder.Entity<TrPengembangan>(entity =>
                 {
                     entity.HasKey(e => e.IdTrPengembangan);

                     entity.ToTable("TR_PENGEMBANGAN", "simka");

                     entity.HasIndex(e => e.IdRefAppraisal)
                         .HasName("RELATION_177_FK");

                     entity.HasIndex(e => e.IdRefPengembangan)
                         .HasName("RELATION_519_FK");

                     entity.HasIndex(e => e.Npp)
                         .HasName("RELATION_172_FK");

                     entity.Property(e => e.IdTrPengembangan)
                         .HasColumnName("ID_TR_PENGEMBANGAN")
                         .ValueGeneratedNever();

                     entity.Property(e => e.BukuMonograf).HasColumnName("BUKU_MONOGRAF");

                     entity.Property(e => e.BukuReferensi).HasColumnName("BUKU_REFERENSI");

                     entity.Property(e => e.DanaEksternal).HasColumnName("DANA_EKSTERNAL");

                     entity.Property(e => e.DanaLokal).HasColumnName("DANA_LOKAL");

                     entity.Property(e => e.DateInserted)
                         .HasColumnName("DATE_INSERTED")
                         .HasColumnType("datetime");

                     entity.Property(e => e.Doi)
                         .HasColumnName("DOI")
                         .HasMaxLength(200)
                         .IsUnicode(false);

                     entity.Property(e => e.Edisi)
                         .HasColumnName("EDISI")
                         .HasMaxLength(200)
                         .IsUnicode(false);

                     entity.Property(e => e.FileArtikel)
                         .HasColumnName("FILE_ARTIKEL")
                         .HasColumnType("image");

                     entity.Property(e => e.FileDokumen)
                         .HasColumnName("FILE_DOKUMEN")
                         .HasColumnType("image");

                     entity.Property(e => e.FilePengembangan)
                         .HasColumnName("FILE_PENGEMBANGAN")
                         .HasColumnType("image");

                     entity.Property(e => e.IdRefAppraisal).HasColumnName("ID_REF_APPRAISAL");

                     entity.Property(e => e.IdRefPengembangan).HasColumnName("ID_REF_PENGEMBANGAN");

                     entity.Property(e => e.InstitusiDana)
                         .HasColumnName("INSTITUSI_DANA")
                         .IsUnicode(false);

                     entity.Property(e => e.IssnIsbn)
                         .HasColumnName("ISSN_ISBN")
                         .IsUnicode(false);

                     entity.Property(e => e.Judul).HasColumnName("JUDUL");

                     entity.Property(e => e.JumlahHalaman).HasColumnName("JUMLAH_HALAMAN");

                     entity.Property(e => e.Nilai).HasColumnName("NILAI");

                     entity.Property(e => e.NilaiAsesor)
                         .HasColumnName("NILAI_ASESOR")
                         .HasColumnType("image");

                     entity.Property(e => e.Npp)
                         .HasColumnName("NPP")
                         .HasMaxLength(10);

                     entity.Property(e => e.Penerbit)
                         .HasColumnName("PENERBIT")
                         .IsUnicode(false);

                     entity.Property(e => e.Peran)
                         .HasColumnName("PERAN")
                         .IsUnicode(false);

                     entity.Property(e => e.Similarity)
                         .HasColumnName("SIMILARITY")
                         .HasColumnType("image");

                     entity.Property(e => e.SumberDana)
                         .HasColumnName("SUMBER_DANA")
                         .HasMaxLength(50)
                         .IsUnicode(false);

                     entity.Property(e => e.Tempat)
                         .HasColumnName("TEMPAT")
                         .IsUnicode(false);

                     entity.Property(e => e.Terindeks)
                         .HasColumnName("TERINDEKS")
                         .HasMaxLength(50)
                         .IsUnicode(false);

                     entity.Property(e => e.TglMulai)
                         .HasColumnName("TGL_MULAI")
                         .HasColumnType("datetime");

                     entity.Property(e => e.TglSelesai)
                         .HasColumnName("TGL_SELESAI")
                         .HasColumnType("datetime");

                     entity.Property(e => e.TingkatPeran)
                         .IsRequired()
                         .HasColumnName("TINGKAT_PERAN")
                         .IsUnicode(false);

                     entity.Property(e => e.UrlWebJurnal)
                         .HasColumnName("URL_WEB_JURNAL")
                         .HasMaxLength(500)
                         .IsUnicode(false);

                     entity.HasOne(d => d.IdRefPengembanganNavigation)
                    .WithMany(p => p.TrPengembangan)
                    .HasForeignKey(d => d.IdRefPengembangan)
                    .HasConstraintName("FK_PENGEMBANGAN_JNS_APPRAISAL");

                     entity.HasOne(d => d.IdRefJnsAppraisaliNavigation)
                    .WithMany(p => p.TrPengembangan)
                    .HasForeignKey(d => d.IdRefAppraisal)
                    .HasConstraintName("FK_PENGEMBANGAN_JNS_APPRAISAsL");
                 });

                 modelBuilder.Entity<TrPensiun>(entity =>
                 {
                     entity.HasKey(e => e.IdTrPensiun);

                     entity.ToTable("TR_PENSIUN", "simka");

                     entity.Property(e => e.IdTrPensiun).HasColumnName("ID_TR_PENSIUN");

                     entity.Property(e => e.GajiAkhirPensiun)
                         .HasColumnName("GAJI_AKHIR_PENSIUN")
                         .HasColumnType("money");

                     entity.Property(e => e.GolTerakhir)
                         .HasColumnName("GOL_TERAKHIR")
                         .HasMaxLength(10)
                         .IsUnicode(false);

                     entity.Property(e => e.NoSk)
                         .HasColumnName("NO_SK")
                         .HasMaxLength(100)
                         .IsUnicode(false);

                     entity.Property(e => e.Npp)
                         .HasColumnName("NPP")
                         .HasMaxLength(10);

                     entity.Property(e => e.TanggalPensiun)
                         .HasColumnName("TANGGAL_PENSIUN")
                         .HasColumnType("datetime");

                     entity.HasOne(d => d.NoSkNavigation)
                         .WithMany(p => p.TrPensiun)
                         .HasForeignKey(d => d.NoSk)
                         .HasConstraintName("FK_TR_PENSIUN_HST_SK");

                     entity.HasOne(d => d.NppNavigation)
                         .WithMany(p => p.TrPensiun)
                         .HasForeignKey(d => d.Npp)
                         .HasConstraintName("FK_TR_PENSIUN_MST_KARYAWAN");
                 });

                 modelBuilder.Entity<TrRestitusi>(entity =>
                 {
                     entity.HasKey(e => e.IdTrRestitusi);

                     entity.ToTable("TR_RESTITUSI", "simka");

                     entity.HasIndex(e => e.IdRefRestitusi)
                         .HasName("RELATION_648_FK");

                     entity.HasIndex(e => e.Npp)
                         .HasName("RELATION_639_FK");

                     entity.HasIndex(e => new { e.IdTrRestitusi, e.NominalHutang })
                         .HasName("IDX_SIMKA_1");

                     entity.Property(e => e.IdTrRestitusi)
                         .HasColumnName("ID_TR_RESTITUSI")
                         .ValueGeneratedOnAdd();

                     entity.Property(e => e.BulanDepan)
                         .HasColumnName("BULAN_DEPAN")
                         .HasColumnType("money");

                     entity.Property(e => e.BulanIni)
                         .HasColumnName("BULAN_INI")
                         .HasColumnType("money");

                     entity.Property(e => e.CaraBayar)
                         .HasColumnName("cara_bayar")
                         .HasMaxLength(50)
                         .IsUnicode(false);

                     entity.Property(e => e.IdKeluarga)
                         .HasColumnName("ID_KELUARGA")
                         .HasMaxLength(10)
                         .IsUnicode(false);

                     entity.Property(e => e.IdMstRekanan).HasColumnName("ID_MST_REKANAN");

                     entity.Property(e => e.IdRefRestitusi).HasColumnName("ID_REF_RESTITUSI");

                     entity.Property(e => e.IdTrRestitusiGabung)
                         .HasColumnName("ID_TR_RESTITUSI_GABUNG")
                         .HasMaxLength(250)
                         .IsUnicode(false);

                     entity.Property(e => e.IsGabung).HasColumnName("IS_GABUNG");

                     entity.Property(e => e.IsSubsidi).HasColumnName("IS_SUBSIDI");

                     entity.Property(e => e.JmlAngsuran)
                         .HasColumnName("jml_angsuran")
                         .HasColumnType("money");

                     entity.Property(e => e.Keterangan)
                         .HasColumnName("KETERANGAN")
                         .HasMaxLength(150)
                         .IsUnicode(false);

                     entity.Property(e => e.MulaiAngsur)
                         .HasColumnName("mulai_angsur")
                         .HasColumnType("datetime");

                     entity.Property(e => e.NoSurat)
                         .HasColumnName("no_surat")
                         .HasMaxLength(50)
                         .IsUnicode(false);

                     entity.Property(e => e.Nominal)
                         .HasColumnName("NOMINAL")
                         .HasColumnType("money");

                     entity.Property(e => e.NominalGabungHutang)
                         .HasColumnName("NOMINAL_GABUNG_HUTANG")
                         .HasColumnType("money");

                     entity.Property(e => e.NominalHutang)
                         .HasColumnName("NOMINAL_HUTANG")
                         .HasColumnType("money");

                     entity.Property(e => e.NominalKuitansi)
                         .HasColumnName("NOMINAL_KUITANSI")
                         .HasColumnType("money");

                     entity.Property(e => e.NominalSubsidi)
                         .HasColumnName("NOMINAL_SUBSIDI")
                         .HasColumnType("money");

                     entity.Property(e => e.NomorFpd)
                         .HasColumnName("NOMOR_FPD")
                         .HasMaxLength(100)
                         .IsUnicode(false);

                     entity.Property(e => e.Npp)
                         .HasColumnName("NPP")
                         .HasMaxLength(10);

                     entity.Property(e => e.SaldoBulanDepan)
                         .HasColumnName("SALDO_BULAN_DEPAN")
                         .HasColumnType("money");

                     entity.Property(e => e.SaldoBulanIni)
                         .HasColumnName("SALDO_BULAN_INI")
                         .HasColumnType("money");

                     entity.Property(e => e.Status).HasColumnName("STATUS");

                     entity.Property(e => e.SudahAngsur).HasColumnName("sudah_angsur");

                     entity.Property(e => e.TglAmbil)
                         .HasColumnName("TGL_AMBIL")
                         .HasColumnType("datetime");

                     entity.Property(e => e.TglCair)
                         .HasColumnName("TGL_CAIR")
                         .HasColumnType("datetime");

                     entity.Property(e => e.TglInput)
                         .HasColumnName("TGL_INPUT")
                         .HasColumnType("datetime");

                     entity.Property(e => e.TglKuitansi)
                         .HasColumnName("TGL_KUITANSI")
                         .HasColumnType("datetime");

                     entity.Property(e => e.TglLunas)
                         .HasColumnName("tgl_lunas")
                         .HasColumnType("datetime");

                     entity.Property(e => e.XAngsur).HasColumnName("x_angsur");

                     /* entity.HasOne(d => d.IdTrRestitusiNavigation)
                          .WithOne(p => p.InverseIdTrRestitusiNavigation)
                          .HasForeignKey<TrRestitusi>(d => d.IdTrRestitusi)
                          .OnDelete(DeleteBehavior.ClientSetNull)
                          .HasConstraintName("FK_TR_RESTITUSI_TR_RESTITUSI");*/

                entity.HasOne(d => d.idRekanantNavigation)
                  .WithMany(p => p.TrRestitusi)
                  .HasForeignKey(d => d.IdMstRekanan)
                  .HasConstraintName("FK_RELATION_202");

                entity.HasOne(d => d.NppNavigation)
                  .WithMany(p => p.TrRestitusi)
                  .HasForeignKey(d => d.Npp)
                  .HasConstraintName("FK_RELATION_2202");


                  
                 });

            modelBuilder.Entity<TrRiwayatPendidikan>(entity =>
            {
                entity.HasKey(e => e.IdTrRp);

                entity.ToTable("TR_RIWAYAT_PENDIDIKAN", "simka");

                entity.HasIndex(e => e.IdRefJenjang)
                    .HasName("RELATION_66_FK");

                entity.HasIndex(e => e.IdRefSs)
                    .HasName("RELATION_2342_FK");

                entity.HasIndex(e => e.Npp)
                    .HasName("RELATION_67_FK");

                entity.Property(e => e.IdTrRp).HasColumnName("ID_TR_RP");

                entity.Property(e => e.AsalBeasiswa)
                    .HasColumnName("ASAL_BEASISWA")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnName("DATE_INSERTED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fakultas)
                    .HasColumnName("FAKULTAS")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Gelar)
                    .HasColumnName("GELAR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdRefJenjang).HasColumnName("ID_REF_JENJANG");

                entity.Property(e => e.IdRefSs).HasColumnName("ID_REF_SS");

                entity.Property(e => e.Ipk).HasColumnName("IPK");

                entity.Property(e => e.IsLast).HasColumnName("IS_LAST");

                entity.Property(e => e.IsVerifiedKsdm).HasColumnName("IS_VERIFIED_KSDM");

                entity.Property(e => e.JenisFileIjazah)
                    .HasColumnName("JENIS_FILE_IJAZAH")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.JenisFileTranskrip)
                    .HasColumnName("JENIS_FILE_TRANSKRIP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Jurusan)
                    .HasColumnName("JURUSAN")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Keterangan)
                    .HasColumnName("KETERANGAN")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamaSekolah)
                    .HasColumnName("NAMA_SEKOLAH")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NoIjazah)
                    .HasColumnName("NO_IJAZAH")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10);

                entity.Property(e => e.ProgramStudi)
                    .HasColumnName("PROGRAM_STUDI")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ScanIjazah).HasColumnName("SCAN_IJAZAH");

                entity.Property(e => e.ScanTranskrip).HasColumnName("SCAN_TRANSKRIP");

                entity.Property(e => e.TahunLulus).HasColumnName("TAHUN_LULUS");

                entity.Property(e => e.TahunMasuk).HasColumnName("TAHUN_MASUK");

                entity.Property(e => e.TglIjazah)
                    .HasColumnName("TGL_IJAZAH")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdRefJenjangNavigation)
                    .WithMany(p => p.TrRiwayatPendidikan)
                    .HasForeignKey(d => d.IdRefJenjang)
                    .HasConstraintName("FK_RELATION_66");

                entity.HasOne(d => d.IdRefSsNavigation)
                    .WithMany(p => p.TrRiwayatPendidikan)
                    .HasForeignKey(d => d.IdRefSs)
                    .HasConstraintName("FK_RELATION_2342");

                entity.HasOne(d => d.NppNavigation)
                    .WithMany(p => p.TrRiwayatPendidikan)
                    .HasForeignKey(d => d.Npp)
                    .HasConstraintName("FK_RELATION_67");
            });

            modelBuilder.Entity<TrRiwayatPendidikanDokumen>(entity =>
            {
                entity.HasKey(e => e.IdTrRpDokumen);

                entity.ToTable("TR_RIWAYAT_PENDIDIKAN_DOKUMEN", "simka");

                entity.Property(e => e.IdTrRpDokumen).HasColumnName("ID_TR_RP_DOKUMEN");

                entity.Property(e => e.Dokumen).HasColumnName("DOKUMEN");

                entity.Property(e => e.IdJenisDokumen).HasColumnName("ID_JENIS_DOKUMEN");

                entity.Property(e => e.IdTrRp).HasColumnName("ID_TR_RP");

                entity.Property(e => e.Keterangan)
                    .HasColumnName("KETERANGAN")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NamaDokumen)
                    .HasColumnName("NAMA_DOKUMEN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TautanDokumen)
                    .HasColumnName("TAUTAN_DOKUMEN")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdJenisDokumenNavigation)
                    .WithMany(p => p.TrRiwayatPendidikanDokumen)
                    .HasForeignKey(d => d.IdJenisDokumen)
                    .HasConstraintName("FK_TR_RIWAYAT_PENDIDIKAN_DOKUMEN_REF_JENIS_DOKUMEN");

                entity.HasOne(d => d.IdTrRpNavigation)
                    .WithMany(p => p.TrRiwayatPendidikanDokumen)
                    .HasForeignKey(d => d.IdTrRp)
                    .HasConstraintName("FK_TR_RIWAYAT_PENDIDIKAN_DOKUMEN_TR_RIWAYAT_PENDIDIKAN");
            });

            modelBuilder.Entity<TrSertifikasi>(entity =>
            {
                entity.HasKey(e => e.Npp);

                entity.ToTable("TR_SERTIFIKASI", "simka");

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.BidangIlmu)
                    .HasColumnName("BIDANG_ILMU")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FileSertifikat)
                    .HasColumnName("FILE_SERTIFIKAT")
                    .HasColumnType("image");

                entity.Property(e => e.NoPeserta)
                    .HasColumnName("NO_PESERTA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoRegistrasi)
                    .HasColumnName("NO_REGISTRASI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoSertifikasi)
                    .HasColumnName("NO_SERTIFIKASI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PtPenyelenggara)
                    .HasColumnName("PT_PENYELENGGARA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TahunSertifikasi).HasColumnName("TAHUN_SERTIFIKASI");

                entity.HasOne(d => d.NppNavigation)
                    .WithOne(p => p.TrSertifikasi)
                    .HasForeignKey<TrSertifikasi>(d => d.Npp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RELATION_2926");
            });
            modelBuilder.Entity<TblSkKaryawan>(entity =>
            {
                entity.HasKey(e => e.NoSk);

                entity.ToTable("TBL_SK_KARYAWAN", "simka");

                entity.Property(e => e.NoSk)
                  .HasColumnName("NO_SK")
                  .HasMaxLength(100)
                  .ValueGeneratedNever();

                entity.Property(e => e.Npp)
                    .HasColumnName("NPP")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Peran)
                    .HasColumnName("Peran")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdUnit)
                    .HasColumnName("ID_UNIT")
                    .HasColumnType("int");

                entity.Property(e => e.IdJabatan)
                    .HasColumnName("ID_JABATAN")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TglAwal)
                    .HasColumnName("TGL_AWAL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TglAkhir)
                    .HasColumnName("TGL_AKHIR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.NppNavigation)
                   .WithMany(p => p.TblSkKaryawan)
                   .HasForeignKey(d => d.Npp)
                   .HasConstraintName("FK_RELATION_202");

            });
        }
    }
}
