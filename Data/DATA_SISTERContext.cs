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

                entity.ToTable("PENELITIAN");

                entity.Property(e => e.id_penelitian_pengabdian).HasColumnName("id_penelitian_pengabdian")
                .HasMaxLength(50);


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
                    .HasMaxLength(50);

                entity.Property(e => e.status_aktif)
                    .HasColumnName("status_aktif")
                    .HasMaxLength(100);

                entity.Property(e => e.no_sk_tugas)
                    .HasColumnName("no_sk_tugas")
                    .HasMaxLength(100);

                entity.Property(e => e.tanggal_sk_penugasan)
                    .HasColumnName("tanggal_sk_penugasan")
                    .HasColumnType("date");

                entity.Property(e => e.tempat_kegiatan)
                    .HasColumnName("tempat_kegiatan")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_tahun_anggaran)
                    .HasColumnName("nama_tahun_anggaran")
                    .HasMaxLength(50);

                entity.Property(e => e.nama_skim)
                    .HasColumnName("nama_skim")
                    .HasMaxLength(100);

                entity.Property(e => e.parent_judul_litabmas)
                    .HasColumnName("parent_judul_litabmas")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_lembaga)
                    .HasColumnName("nama_lembaga")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_lembaga)
                    .HasColumnName("nama_lembaga")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_kelompok_bidang)
                    .HasColumnName("nama_kelompok_bidang")
                    .HasMaxLength(100);

                entity.Property(e => e.NPP)
                    .HasColumnName("NPP")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_tahun_ajaran)
                    .HasColumnName("nama_tahun_ajaran")
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<TrPengabdian_DATA_SISTER>(entity =>
            {
                entity.HasKey(e => e.id_penelitian_pengabdian);

                entity.ToTable("PENGABDIAN");

                entity.Property(e => e.id_penelitian_pengabdian).HasColumnName("id_penelitian_pengabdian")
                .HasMaxLength(50);


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
                    .HasMaxLength(50);

                entity.Property(e => e.status_aktif)
                    .HasColumnName("status_aktif")
                    .HasMaxLength(100);

                entity.Property(e => e.no_sk_tugas)
                    .HasColumnName("no_sk_tugas")
                    .HasMaxLength(100);

                entity.Property(e => e.tanggal_sk_penugasan)
                    .HasColumnName("tanggal_sk_penugasan")
                    .HasColumnType("date");

                entity.Property(e => e.tempat_kegiatan)
                    .HasColumnName("tempat_kegiatan")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_tahun_anggaran)
                    .HasColumnName("nama_tahun_anggaran")
                    .HasMaxLength(50);

                entity.Property(e => e.nama_skim)
                    .HasColumnName("nama_skim")
                    .HasMaxLength(100);

                entity.Property(e => e.parent_judul_litabmas)
                    .HasColumnName("parent_judul_litabmas")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_lembaga)
                    .HasColumnName("nama_lembaga")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_lembaga)
                    .HasColumnName("nama_lembaga")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_kelompok_bidang)
                    .HasColumnName("nama_kelompok_bidang")
                    .HasMaxLength(100);

                entity.Property(e => e.NPP)
                    .HasColumnName("NPP")
                    .HasMaxLength(100);

                entity.Property(e => e.nama_tahun_ajaran)
                    .HasColumnName("nama_tahun_ajaran")
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<TrPengajaran_Data_SISTER>(entity =>
            {
                entity.HasKey(e => e.id_pembelajaran);

                entity.ToTable("PENGAJARAN");

                entity.Property(e => e.id_pembelajaran)
                .HasColumnName("id_pembelajaran")
                .HasMaxLength(50);


                entity.Property(e => e.sks_total_persubstansi)
                .HasColumnName("sks_total_persubstansi")
                .HasColumnType("numeric");

                entity.Property(e => e.sks_tatap_muka_persubstansi)
                    .HasColumnName("sks_tatap_muka_persubstansi")
                    .HasColumnType("numeric");


                entity.Property(e => e.sks_praktek_persubstansi)
                .HasColumnName("sks_praktek_persubstansi")
                .HasColumnType("numeric");

                entity.Property(e => e.sks_praktek_lapangan_persubstansi)
                    .HasColumnName("sks_praktek_lapangan_persubstansi")
                    .HasColumnType("numeric");

                entity.Property(e => e.sks_simulasi_persubstansi)
                    .HasColumnName("sks_simulasi_persubstansi")
                    .HasColumnType("numeric");

                entity.Property(e => e.jumlah_tim_rencana)
                    .HasColumnName("jumlah_tim_rencana")
                    .HasColumnType("int");

                entity.Property(e => e.jumlah_tim_real)
                    .HasColumnName("jumlah_tim_real")
                    .HasColumnType("int");

                entity.Property(e => e.jumlah_mahasiswa)
                    .HasColumnName("jumlah_mahasiswa")
                    .HasColumnType("int");

                entity.Property(e => e.nama_kelas_kuliah)
                    .HasColumnName("nama_kelas_kuliah")
                    .HasMaxLength(150);

                entity.Property(e => e.nama_jenis_evaluasi)
                    .HasColumnName("nama_jenis_evaluasi")
                    .HasMaxLength(150);

                entity.Property(e => e.nama_substansi)
                    .HasColumnName("nama_substansi")
                    .HasMaxLength(150);

                entity.Property(e => e.NPP)
                    .HasColumnName("NPP")
                    .HasMaxLength(100);

                
            });

            modelBuilder.Entity<TrPublikasi_DATA_SISTER>(entity =>
            {
                entity.HasKey(e => e.id_riwayat_publikasi_paten);

                entity.ToTable("PUBLIKASI");

                entity.Property(e => e.id_riwayat_publikasi_paten)
                .HasColumnName("id_riwayat_publikasi_paten")
                .HasMaxLength(150);


                entity.Property(e => e.judul_publikasi_paten)
                .HasColumnName("judul_publikasi_paten")
                .HasMaxLength(500);

                entity.Property(e => e.judul_asli_tulisan)
                    .HasColumnName("judul_asli_tulisan")
                    .HasMaxLength(500);


                entity.Property(e => e.tautan_laman_jurnal)
                .HasColumnName("tautan_laman_jurnal")
                .HasMaxLength(200);

                entity.Property(e => e.tanggal_terbit)
                    .HasColumnName("tanggal_terbit")
                    .HasColumnType("date");

                entity.Property(e => e.volume)
                    .HasColumnName("volume")
                    .HasColumnType("int");

                entity.Property(e => e.nomor_hasil_publikasi)
                    .HasColumnName("nomor_hasil_publikasi")
                    .HasColumnType("int");

                entity.Property(e => e.halaman)
                    .HasColumnName("halaman")
                    .HasMaxLength(50);

                entity.Property(e => e.jumlah_halaman)
                    .HasColumnName("jumlah_halaman")
                    .HasMaxLength(50);

                entity.Property(e => e.nama_penerbit)
                    .HasColumnName("nama_penerbit")
                    .HasMaxLength(100); ;

                entity.Property(e => e.DOI_publikasi)
                    .HasColumnName("DOI_publikasi")
                    .HasMaxLength(100);

                entity.Property(e => e.ISBN_bahan_ajar)
                    .HasColumnName("ISBN_bahan_ajar")
                    .HasMaxLength(100);

                entity.Property(e => e.ISSN_publikasi)
                    .HasColumnName("ISSN_publikasi")
                    .HasMaxLength(100);

                entity.Property(e => e.tautan)
                    .HasColumnName("tautan")
                    .HasMaxLength(100);

                entity.Property(e => e.keterangan)
                    .HasColumnName("keterangan")
                    .HasMaxLength(100);

                entity.Property(e => e.pengguna_produk_jasa)
                    .HasColumnName("pengguna_produk_jasa")
                    .HasMaxLength(100);
                entity.Property(e => e.a_komersialisasi)
                    .HasColumnName("a_komersialisasi")
                    .HasColumnType("int");

                entity.Property(e => e.stat_impor_sinta)
                    .HasColumnName("stat_impor_sinta")
                    .HasMaxLength(100);

                entity.Property(e => e.tgl_create)
                    .HasColumnName("tgl_create")
                    .HasColumnType("date");

                entity.Property(e => e.quartile)
                    .HasColumnName("quartile")
                    .HasMaxLength(200);

                entity.Property(e => e.nama_kategori_kegiatan)
                    .HasColumnName("nama_kategori_kegiatan")
                    .HasMaxLength(200);

                entity.Property(e => e.nama_jenis_publikasi)
                    .HasColumnName("nama_jenis_publikasi")
                    .HasMaxLength(200);

                entity.Property(e => e.nama_kategori_pencapaian)
                    .HasColumnName("nama_kategori_pencapaian")
                    .HasMaxLength(200);

                entity.Property(e => e.judul_penelitian_pengabdian)
                    .HasColumnName("judul_penelitian_pengabdian")
                    .HasMaxLength(500);

                entity.Property(e => e.NPP)
                    .HasColumnName("NPP")
                    .HasMaxLength(100);

            });

            modelBuilder.Entity<TblDokumen_DATA_SISTER>(entity =>
            {
                entity.HasKey(e => e.id_dokumen);

                entity.ToTable("DOKUMEN");

                entity.Property(e => e.id_dokumen)
                .HasColumnName("id_dokumen")
                .HasMaxLength(150);


                entity.Property(e => e.id_riwayat_publikasi_paten)
                .HasColumnName("id_riwayat_publikasi_paten")
                .HasMaxLength(150);

                entity.Property(e => e.nama_dokumen)
                    .HasColumnName("nama_dokumen")
                    .HasMaxLength(150);


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
                entity.HasKey(e => e.id_dosen);

                entity.ToTable("PENULIS");

                entity.Property(e => e.nama)
                .HasColumnName("nama")
                .HasMaxLength(150);


                entity.Property(e => e.no_urut)
                .HasColumnName("no_urut")
                .HasMaxLength(150);

                entity.Property(e => e.afiliasi_penulis)
                    .HasColumnName("afiliasi_penulis")
                    .HasMaxLength(150);


                entity.Property(e => e.peran_dalam_kegiatan)
                .HasColumnName("peran_dalam_kegiatan")
                .HasMaxLength(150);

                entity.Property(e => e.jenis_peranan)
                    .HasColumnName("jenis_peranan")
                    .HasMaxLength(150);

                entity.Property(e => e.apakah_corresponding_author)
                    .HasColumnName("apakah_corresponding_author")
                    .HasMaxLength(150);

                entity.Property(e => e.id_dosen)
                    .HasColumnName("id_dosen")
                    .HasMaxLength(150);

                entity.Property(e => e.id_mahasiswa_anggota_penelitian_pengabdian)
                    .HasColumnName("id_mahasiswa_anggota_penelitian_pengabdian")
                    .HasMaxLength(150);

                entity.Property(e => e.id_kolaborator_eksternal)
                    .HasColumnName("id_kolaborator_eksternal")
                    .HasMaxLength(150);

                entity.Property(e => e.nim)
                    .HasColumnName("nim")
                    .HasMaxLength(150);

            });


        }
    }
}
