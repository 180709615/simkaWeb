using APIConsume.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public partial class DATA_SISTERContext : DbContext
    {
        public DATA_SISTERContext(DbContextOptions<DATA_SISTERContext> options)
    : base(options)
        { }

        public virtual DbSet<TrPenelitian_DATA_SISTER> TrPenelitian_DATA_SISTER { get; set; }
        public virtual DbSet<TrPengabdian_DATA_SISTER> TrPengabdian_DATA_SISTER { get; set; }
        public virtual DbSet<TrPengajaran_Data_SISTER> TrPengajaran_DATA_SISTER { get; set; }
        public virtual DbSet<TrPublikasi_DATA_SISTER> TrPublikasi_DATA_SISTER { get; set; }
        public virtual DbSet<TblPenulis_DATA_SISTER> TblPenulis_DATA_SISTER { get; set; }
        public virtual DbSet<TblDokumen_DATA_SISTER> TblDokumen_DATA_SISTER { get; set; }
        public virtual DbSet<TblAnggota_DATA_SISTER> TblAnggota_DATA_SISTER { get; set; }
        public virtual DbSet<TblMitra_Litabmas_DATA_SISTER> TblMitra_Litabmas_DATA_SISTER { get; set; }
        public virtual DbSet<ViewPerbandinganPengajaran_SPKP> ViewPerbandinganPengajaran_SPKP { get; set; }
        public virtual DbSet<RefSemesterSister> RefSemesterSister { get; set; }
        public virtual DbSet<RefPerguruanTinggiSister> RefPerguruanTinggiSister { get; set; }
        public virtual DbSet<RefKategoriCapaianLuaranSister> RefKategoriCapaianLuaranSister { get; set; }
        public virtual DbSet<RefJenisPublikasiSister> RefJenisPublikasiSister { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrPenelitian_DATA_SISTER>(entity =>
            {
                entity.HasKey(e => e.id_penelitian_pengabdian);
                //entity.HasNoKey();
                entity.ToTable("PENELITIAN");

                entity.Property(e => e.id_penelitian_pengabdian).HasColumnName("id_penelitian_pengabdian")
                .HasMaxLength(50);

                entity.Property(e => e.id_kategori_kegiatan).HasColumnName("id_kategori_kegiatan")
                .HasColumnType("int");


                entity.Property(e => e.judul_penelitian_pengabdian).HasColumnName("judul_penelitian_pengabdian")
                .HasMaxLength(500);

                entity.Property(e => e.durasi_kegiatan)
                    .HasColumnName("durasi_kegiatan")
                    .HasColumnType("int");


                entity.Property(e => e.tahun_pelaksanaan_ke)
                .HasColumnName("tahun_pelaksanaan_ke")
                .HasColumnType("int");

                entity.Property(e => e.dana_dari_dikti)
                    .HasColumnName("dana_dari_dikti")
                    .HasColumnType("money");

                entity.Property(e => e.dana_dari_PT)
                    .HasColumnName("dana_dari_PT")
                    .HasColumnType("money");

                entity.Property(e => e.dana_dari_instansi_lain)
                    .HasColumnName("dana_dari_instansi_lain")
                    .HasColumnType("money");

                entity.Property(e => e.in_kind)
                    .HasColumnName("in_kind")
                    .HasMaxLength(200);

                entity.Property(e => e.status_aktif)
                    .HasColumnName("status_aktif")
                    .HasMaxLength(200);

                entity.Property(e => e.no_sk_tugas)
                    .HasColumnName("no_sk_tugas")
                    .HasMaxLength(200);

                entity.Property(e => e.tanggal_sk_penugasan)
                    .HasColumnName("tanggal_sk_penugasan")
                    .HasColumnType("date");

                entity.Property(e => e.tempat_kegiatan)
                    .HasColumnName("tempat_kegiatan")
                    .HasMaxLength(500);                

                entity.Property(e => e.id_jenis_skim)
                    .HasColumnName("id_jenis_skim")
                    .HasMaxLength(100);

                entity.Property(e => e.jenis_skim)
                    .HasColumnName("jenis_skim")
                    .HasMaxLength(200);

                entity.Property(e => e.nama_lembaga)
                    .HasColumnName("nama_lembaga")
                    .HasMaxLength(200);

                entity.Property(e => e.tahun_usulan)
                    .HasColumnName("tahun_usulan")
                    .HasColumnType("int");

                entity.Property(e => e.tahun_kegiatan)
                    .HasColumnName("tahun_kegiatan")
                    .HasColumnType("int");

                entity.Property(e => e.tahun_pelaksanaan)
                    .HasColumnName("tahun_pelaksanaan")
                    .HasColumnType("int");

                entity.Property(e => e.id_litabmas_sebelumnya)
                    .HasColumnName("id_litabmas_sebelumnya")
                    .HasMaxLength(50);

                entity.Property(e => e.litabmas_sebelumnya)
                    .HasColumnName("litabmas_sebelumnya")
                    .HasMaxLength(500);

                entity.Property(e => e.id_afiliasi)
                    .HasColumnName("id_afiliasi")
                    .HasMaxLength(100);

                entity.Property(e => e.afiliasi)
                    .HasColumnName("afiliasi")
                    .HasMaxLength(200);

                entity.Property(e => e.id_kelompok_bidang)
                    .HasColumnName("id_kelompok_bidang")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_kelompok_bidang)
                    .HasColumnName("nama_kelompok_bidang")
                    .HasMaxLength(200);

               

            });

            modelBuilder.Entity<TrPengabdian_DATA_SISTER>(entity =>
            {
                entity.HasKey(e => e.id_penelitian_pengabdian);
                //entity.HasNoKey();
                entity.ToTable("PENGABDIAN");

                entity.Property(e => e.id_penelitian_pengabdian).HasColumnName("id_penelitian_pengabdian")
                .HasMaxLength(50);

                entity.Property(e => e.id_kategori_kegiatan).HasColumnName("id_kategori_kegiatan")
                .HasColumnType("int");


                entity.Property(e => e.judul_penelitian_pengabdian).HasColumnName("judul_penelitian_pengabdian")
                .HasMaxLength(500);

                entity.Property(e => e.durasi_kegiatan)
                    .HasColumnName("durasi_kegiatan")
                    .HasColumnType("int");


                entity.Property(e => e.tahun_pelaksanaan_ke)
                .HasColumnName("tahun_pelaksanaan_ke")
                .HasColumnType("int");

                entity.Property(e => e.dana_dari_dikti)
                    .HasColumnName("dana_dari_dikti")
                    .HasColumnType("money");

                entity.Property(e => e.dana_dari_PT)
                    .HasColumnName("dana_dari_PT")
                    .HasColumnType("money");

                entity.Property(e => e.dana_dari_instansi_lain)
                    .HasColumnName("dana_dari_instansi_lain")
                    .HasColumnType("money");

                entity.Property(e => e.in_kind)
                    .HasColumnName("in_kind")
                    .HasMaxLength(200);

                entity.Property(e => e.status_aktif)
                    .HasColumnName("status_aktif")
                    .HasMaxLength(200);

                entity.Property(e => e.no_sk_tugas)
                    .HasColumnName("no_sk_tugas")
                    .HasMaxLength(200);

                entity.Property(e => e.tanggal_sk_penugasan)
                    .HasColumnName("tanggal_sk_penugasan")
                    .HasColumnType("date");

                entity.Property(e => e.tempat_kegiatan)
                    .HasColumnName("tempat_kegiatan")
                    .HasMaxLength(500);

                entity.Property(e => e.id_jenis_skim)
                    .HasColumnName("id_jenis_skim")
                    .HasMaxLength(100);

                entity.Property(e => e.jenis_skim)
                    .HasColumnName("jenis_skim")
                    .HasMaxLength(200);

                entity.Property(e => e.nama_lembaga)
                    .HasColumnName("nama_lembaga")
                    .HasMaxLength(200);

                entity.Property(e => e.tahun_usulan)
                    .HasColumnName("tahun_usulan")
                    .HasColumnType("int");

                entity.Property(e => e.tahun_kegiatan)
                    .HasColumnName("tahun_kegiatan")
                    .HasColumnType("int");

                entity.Property(e => e.tahun_pelaksanaan)
                    .HasColumnName("tahun_pelaksanaan")
                    .HasColumnType("int");

                entity.Property(e => e.id_litabmas_sebelumnya)
                    .HasColumnName("id_litabmas_sebelumnya")
                    .HasMaxLength(50);

                entity.Property(e => e.litabmas_sebelumnya)
                    .HasColumnName("litabmas_sebelumnya")
                    .HasMaxLength(500);

                entity.Property(e => e.id_afiliasi)
                    .HasColumnName("id_afiliasi")
                    .HasMaxLength(100);

                entity.Property(e => e.afiliasi)
                    .HasColumnName("afiliasi")
                    .HasMaxLength(200);

                entity.Property(e => e.id_kelompok_bidang)
                    .HasColumnName("id_kelompok_bidang")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_kelompok_bidang)
                    .HasColumnName("nama_kelompok_bidang")
                    .HasMaxLength(200);

                entity.Property(e => e.NPP1)
                    .HasColumnName("NPP1")
                    .HasMaxLength(100);

                entity.Property(e => e.NPP2)
                    .HasColumnName("NPP2")
                    .HasMaxLength(100);

                entity.Property(e => e.NPP3)
                    .HasColumnName("NPP3")
                    .HasMaxLength(100);

                entity.Property(e => e.NPP4)
                    .HasColumnName("NPP4")
                    .HasMaxLength(100);

                entity.Property(e => e.NPP5)
                    .HasColumnName("NPP5")
                    .HasMaxLength(100);

                entity.Property(e => e.NPP6)
                    .HasColumnName("NPP6")
                    .HasMaxLength(100);

            });

            modelBuilder.Entity<TrPengajaran_Data_SISTER>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("PENGAJARAN");

                entity.Property(e => e.id)
                .HasColumnName("id_pengajaran")
                .HasMaxLength(50);

                entity.Property(e => e.semester)
                .HasColumnName("semester")
                .HasMaxLength(50);

                entity.Property(e => e.mata_kuliah)
                .HasColumnName("mata_kuliah")
                .HasMaxLength(200);

                entity.Property(e => e.kelas)
                .HasColumnName("kelas")
                .HasMaxLength(50);

                entity.Property(e => e.sks)
                .HasColumnName("sks")
                .HasColumnType("numeric");

                entity.Property(e => e.id_semester)
                .HasColumnName("id_semester")
                .HasMaxLength(50);

                entity.Property(e => e.sks_tatap_muka)
                .HasColumnName("sks_tatap_muka")
                .HasColumnType("numeric");

                entity.Property(e => e.sks_praktik)
                    .HasColumnName("sks_praktik")
                    .HasColumnType("numeric");


                entity.Property(e => e.sks_praktik_lapangan)
                .HasColumnName("sks_praktik_lapangan")
                .HasColumnType("numeric");

                entity.Property(e => e.sks_simulasi)
                    .HasColumnName("sks_simulasi")
                    .HasColumnType("numeric");
                
                entity.Property(e => e.tatap_muka_rencana)
                    .HasColumnName("tatap_muka_rencana")
                    .HasColumnType("int");

                entity.Property(e => e.tatap_muka_realisasi)
                    .HasColumnName("tatap_muka_realisasi")
                    .HasColumnType("int");

                entity.Property(e => e.jumlah_mahasiswa)
                    .HasColumnName("jumlah_mahasiswa")
                    .HasColumnType("int");

                entity.Property(e => e.jenis_evaluasi)
                    .HasColumnName("jenis_evaluasi")
                    .HasMaxLength(150);               

                entity.Property(e => e.nama_substansi)
                    .HasColumnName("nama_substansi")
                    .HasMaxLength(150);

                entity.Property(e => e.NPP)
                    .HasColumnName("NPP")
                    .HasMaxLength(50);

                
            });

            modelBuilder.Entity<TrPublikasi_DATA_SISTER>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("PUBLIKASI");

                entity.Property(e => e.id)
                .HasColumnName("id_riwayat_publikasi_paten")
                .HasMaxLength(150);


                entity.Property(e => e.kategori_kegiatan)
                .HasColumnName("kategori_kegiatan")
                .HasMaxLength(500);

                entity.Property(e => e.judul)
                    .HasColumnName("judul")
                    .HasMaxLength(500);

                entity.Property(e => e.quartile)
                    .HasColumnName("quartile")
                    .HasColumnType("int");

                

                entity.Property(e => e.tanggal)
                    .HasColumnName("tanggal")
                    .HasColumnType("date");

                entity.Property(e => e.id_kategori_kegiatan)
                .HasColumnName("id_kategori_kegiatan")
                .HasColumnType("int");

                entity.Property(e => e.id_jenis_publikasi)
                .HasColumnName("id_jenis_publikasi")
                .HasColumnType("int");

                entity.Property(e => e.kategori_capaian_luaran)
                .HasColumnName("kategori_capaian_luaran")
                .HasMaxLength(500);

                entity.Property(e => e.id_kategori_capaian_luaran)
                .HasColumnName("id_kategori_capaian_luaran")
                .HasColumnType("int");

                entity.Property(e => e.judul_litabmas)
                .HasColumnName("judul_litabmas")
                .HasMaxLength(500);

                entity.Property(e => e.id_litabmas)
                .HasColumnName("id_litabmas")
                .HasMaxLength(500);

                entity.Property(e => e.nomor_paten)
                .HasColumnName("nomor_paten")
                .HasMaxLength(500);

                entity.Property(e => e.pemberi_paten)
                .HasColumnName("pemberi_paten")
                .HasMaxLength(500);

                entity.Property(e => e.penerbit)
                .HasColumnName("penerbit")
                .HasMaxLength(500);

                entity.Property(e => e.isbn)
                .HasColumnName("isbn")
                .HasMaxLength(500);

                entity.Property(e => e.jumlah_halaman)
                .HasColumnName("jumlah_halaman")
                .HasColumnType("int");

                entity.Property(e => e.tautan)
                .HasColumnName("tautan")
                .HasMaxLength(1000); ;
               

                entity.Property(e => e.keterangan)
                .HasColumnName("keterangan")
                .HasMaxLength(500);

                entity.Property(e => e.judul_artikel)
                .HasColumnName("judul_artikel")
                .HasMaxLength(500);

                entity.Property(e => e.judul_asli)
                .HasColumnName("judul_asli")
                .HasMaxLength(500);

                entity.Property(e => e.nama_jurnal)
                .HasColumnName("nama_jurnal")
                .HasMaxLength(500);

                entity.Property(e => e.halaman)
                .HasColumnName("halaman")
                .HasMaxLength(500);

                entity.Property(e => e.edisi)
                .HasColumnName("edisi")
                .HasMaxLength(500);

                entity.Property(e => e.nomor)
                .HasColumnName("nomor")
                .HasColumnType("int");

                entity.Property(e => e.doi)
                .HasColumnName("doi")
                .HasMaxLength(500);

                entity.Property(e => e.issn)
                .HasColumnName("issn")
                .HasMaxLength(500);

                entity.Property(e => e.e_issn)
                .HasColumnName("e_issn")
                .HasMaxLength(500);

                entity.Property(e => e.seminar)
                .HasColumnName("seminar")
                .HasColumnType("int");

                entity.Property(e => e.prosiding)
                .HasColumnName("prosiding")
                .HasColumnType("int");

                entity.Property(e => e.asal_data)
                .HasColumnName("asal_data")
                .HasMaxLength(500);

                entity.Property(e => e.FILE_PROSIDING_ARTIKEL).HasColumnName("FILE_PROSIDING_ARTIKEL");
                entity.Property(e => e.FILE_CEK_SIMILARITAS).HasColumnName("FILE_CEK_SIMILARITAS");
                entity.Property(e => e.FILE_PEER_REVIEW_PAK).HasColumnName("FILE_PEER_REVIEW_PAK");
                entity.Property(e => e.FILE_PEER_KORESPONDENSI_REVIEWER).HasColumnName("FILE_PEER_KORESPONDENSI_REVIEWER");






            });

            modelBuilder.Entity<TblDokumen_DATA_SISTER>(entity =>
            {
                entity.HasKey(e => e.no);

                entity.ToTable("DOKUMEN");

                entity.Property(e => e.no)
                .HasColumnName("no");

                entity.Property(e => e.id_dokumen)
                .HasColumnName("id_dokumen")
                .HasMaxLength(150);


                entity.Property(e => e.id_publikasi_atau_penelitian)
                .HasColumnName("id_publikasi_atau_penelitian")
                .HasMaxLength(150);

                entity.Property(e => e.nama_dokumen)
                    .HasColumnName("nama_dokumen")
                    .HasMaxLength(250);


                entity.Property(e => e.nama_file)
                .HasColumnName("nama_file")
                .HasMaxLength(150);

                entity.Property(e => e.jenis_file)
                    .HasColumnName("jenis_file")
                    .HasMaxLength(150);

                entity.Property(e => e.tanggal_upload)
                    .HasColumnName("tanggal_upload")
                    .HasColumnType("datetime");

                entity.Property(e => e.nama_jenis_dokumen)
                    .HasColumnName("nama_jenis_dokumen")
                    .HasMaxLength(500);

                entity.Property(e => e.tautan)
                    .HasColumnName("tautan")
                    .HasMaxLength(500);

                entity.Property(e => e.keterangan_dokumen)
                    .HasColumnName("keterangan_dokumen")
                    .HasMaxLength(500);


            });

            modelBuilder.Entity<TblPenulis_DATA_SISTER>(entity =>
            {
                entity.HasKey(e => e.no);
                //entity.HasNoKey();

                entity.ToTable("PENULIS");

                entity.Property(e => e.no)
                .HasColumnName("no")
                .HasColumnType("int");


                entity.Property(e => e.id_riwayat_publikasi_paten)
                .HasColumnName("id_riwayat_publikasi_paten")
                .HasMaxLength(150);

                entity.Property(e => e.nama)
                .HasColumnName("nama")
                .HasMaxLength(150);


                entity.Property(e => e.id_sdm)
                .HasColumnName("id_sdm")
                .HasMaxLength(150);

                entity.Property(e => e.id_peserta_didik)
                    .HasColumnName("id_peserta_didik")
                    .HasMaxLength(150);


                entity.Property(e => e.nomor_induk_peserta_didik)
                .HasColumnName("nomor_induk_peserta_didik")
                .HasMaxLength(150);

                entity.Property(e => e.id_orang)
                    .HasColumnName("id_orang")
                    .HasMaxLength(150);

                entity.Property(e => e.urutan)
                    .HasColumnName("urutan")
                    .HasColumnType("int");

                entity.Property(e => e.afiliasi)
                    .HasColumnName("afiliasi")
                    .HasMaxLength(150);

                entity.Property(e => e.corresponding_author)
                    .HasColumnName("apakah_corresponding_author")
                    .HasColumnType("int");

                entity.Property(e => e.peran)
                    .HasColumnName("peran")
                    .HasMaxLength(150);


            });

            modelBuilder.Entity<TblAnggota_DATA_SISTER>(entity =>
            {
                entity.HasKey(e => e.no);

                entity.ToTable("ANGGOTA");

                entity.Property(e => e.no)               
                .HasColumnName("no")
                .HasColumnType("int");

                entity.Property(e => e.jenis)
                .HasColumnName("jenis")
                .HasMaxLength(200);

                entity.Property(e => e.nama)
                .HasColumnName("nama")
                .HasMaxLength(200);

                entity.Property(e => e.nipd)
                .HasColumnName("nipd")
                .HasMaxLength(200);

                entity.Property(e => e.id_sdm)
                .HasColumnName("id_sdm")
                .HasMaxLength(200);

                entity.Property(e => e.id_orang)
                .HasColumnName("id_orang")
                .HasMaxLength(200);

                entity.Property(e => e.id_pd)
                .HasColumnName("id_pd")
                .HasMaxLength(200);

                entity.Property(e => e.stat_aktif)
                .HasColumnName("stat_aktif")
                .HasColumnType("int");

                entity.Property(e => e.id_penelitian_pengabdian)
                .HasColumnName("id_penelitian_pengabdian")
                .HasMaxLength(200);


            });

            modelBuilder.Entity<TblMitra_Litabmas_DATA_SISTER>(entity =>
            {
                entity.HasKey(e => e.no);

                entity.ToTable("MITRA_LITABMAS");

                entity.Property(e => e.no)
                .HasColumnName("no")
                .HasColumnType("int");

                entity.Property(e => e.id)
                .HasColumnName("id")
                .HasMaxLength(200);

                entity.Property(e => e.nama)
                .HasColumnName("nama")
                .HasMaxLength(200);

                entity.Property(e => e.id_penelitian_pengabdian)
                .HasColumnName("id_penelitian_pengabdian")
                .HasMaxLength(200);




            });

            modelBuilder.Entity<ViewPerbandinganPengajaran_SPKP>(entity =>
            {
                entity.ToTable("perbandingan_pengajaran_spkp");
                entity.HasNoKey();

                entity.Property(e => e.id_pengajaran)
                .HasColumnName("id_pengajaran")
                .HasMaxLength(50);

                entity.Property(e => e.semester)
                .HasColumnName("semester")
                .HasMaxLength(50);

                entity.Property(e => e.mata_kuliah)
                .HasColumnName("mata_kuliah")
                .HasMaxLength(200);

                entity.Property(e => e.kelas)
                .HasColumnName("kelas")
                .HasMaxLength(50);

                entity.Property(e => e.sks)
                .HasColumnName("sks")
                .HasColumnType("numeric");

                entity.Property(e => e.id_semester)
                .HasColumnName("id_semester")
                .HasMaxLength(50);

                entity.Property(e => e.sks_tatap_muka)
                .HasColumnName("sks_tatap_muka")
                .HasColumnType("numeric");

                entity.Property(e => e.sks_praktik)
                    .HasColumnName("sks_praktik")
                    .HasColumnType("numeric");


                entity.Property(e => e.sks_praktik_lapangan)
                .HasColumnName("sks_praktik_lapangan")
                .HasColumnType("numeric");

                entity.Property(e => e.sks_simulasi)
                    .HasColumnName("sks_simulasi")
                    .HasColumnType("numeric");

                entity.Property(e => e.tatap_muka_rencana)
                    .HasColumnName("tatap_muka_rencana")
                    .HasColumnType("int");

                entity.Property(e => e.tatap_muka_realisasi)
                    .HasColumnName("tatap_muka_realisasi")
                    .HasColumnType("int");

                entity.Property(e => e.jumlah_mahasiswa)
                    .HasColumnName("jumlah_mahasiswa")
                    .HasColumnType("int");

                entity.Property(e => e.jenis_evaluasi)
                    .HasColumnName("jenis_evaluasi")
                    .HasMaxLength(150);

                entity.Property(e => e.nama_substansi)
                    .HasColumnName("nama_substansi")
                    .HasMaxLength(150);

                entity.Property(e => e.NPP)
                    .HasColumnName("NPP")
                    .HasMaxLength(50);

                entity.Property(e => e.NAMA_MK_SPKP)
                    .HasColumnName("NAMA_MK_SPKP")
                    .HasMaxLength(50);

                entity.Property(e => e.KODE_MK_SPKP)
                    .HasColumnName("KODE_MK_SPKP")
                    .HasMaxLength(50);

                entity.Property(e => e.KELAS_SPKP)
                    .HasColumnName("KELAS_SPKP")
                    .HasMaxLength(50);

                entity.Property(e => e.SKS_SPKP)
                    .HasColumnName("SKS_SPKP")
                    .HasColumnType("int");
            });

            modelBuilder.Entity<RefSemesterSister>(entity =>
            {
                entity.ToTable("REF_SEMESTER");
                entity.HasKey(e=> e.id);

                entity.Property(e => e.id)
               .HasColumnName("id_semester")
               .HasColumnType("int");

                entity.Property(e => e.nama)
                .HasColumnName("nama_semester")
                .HasMaxLength(50);


            });

            modelBuilder.Entity<RefPerguruanTinggiSister>(entity =>
            {
                entity.ToTable("REF_PERGURUAN_TINGGI");
                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
               .HasColumnName("id_perguruan_tinggi")
               .HasMaxLength(500);

                entity.Property(e => e.nama)
                .HasColumnName("nama_perguruan_tinggi")
                .HasMaxLength(500);


            });

            modelBuilder.Entity<RefKategoriCapaianLuaranSister>(entity =>
            {
                entity.ToTable("REF_KATEGORI_CAPAIAN_LUARAN");
                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
               .HasColumnName("id_kategori_capaian_luaran")
               .HasColumnType("int");

                entity.Property(e => e.nama)
                .HasColumnName("nama_kategori_capaian_luaran")
                .HasMaxLength(50);


            });

            modelBuilder.Entity<RefJenisPublikasiSister>(entity =>
            {
                entity.ToTable("REF_JENIS_PUBLIKASI");
                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
               .HasColumnName("id_jenis_publikasi")
               .HasColumnType("int");

                entity.Property(e => e.nama)
                .HasColumnName("nama_jenis_publikasi")
                .HasMaxLength(50);


            });

        }
    }
}
