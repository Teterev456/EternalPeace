using Microsoft.EntityFrameworkCore;
using EternalPeace.Models;

namespace EternalPeace.Data
{
    public class EternalPeaceDbContext : DbContext
    {
        public EternalPeaceDbContext(DbContextOptions<EternalPeaceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedHistory> MedHistories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .Property(p => p.BirthDate)
                .HasColumnType("date");

            modelBuilder.Entity<Patient>()
                .Property(p => p.InsuranceExpDate)
                .HasColumnType("date");

            modelBuilder.Entity<Doctor>()
                .Property(p => p.BirthDate)
                .HasColumnType("date");

            modelBuilder.Entity<MedHistory>()
                .Property(p => p.RecordDate)
                .HasColumnType("date");

            modelBuilder.Entity<MedHistory>()
                .Property(p => p.DischargeDate)
                .HasColumnType("date");

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Иванов Пётр Васильевич", Address = "102А, Люблинская улица", Sex = "Мужчина", BirthDate = new DateOnly(1990, 5, 1), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 2, Name = "Денисова Амина Данииловна", Address = "24, Новозаводская улица", Sex = "Женщина", BirthDate = new DateOnly(1997, 9, 14), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 3, Name = "Лаврентьев Даниил Кириллович", Address = "47, Деревня Чепелево", Sex = "Мужчина", BirthDate = new DateOnly(2001, 1, 3), InsuranceType = "ДМС", InsuranceExpDate = new DateOnly(2027, 12, 31) },
                new Patient { Id = 4, Name = "Жуков Алексей Матвеевич", Address = "47, 2, Автозаводская улица", Sex = "Мужчина", BirthDate = new DateOnly(1976, 8, 15), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 5, Name = "Токарева София Тимофеевна", Address = "21А, проспект 50 лет Октября", Sex = "Женщина", BirthDate = new DateOnly(1988, 2, 28), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 6, Name = "Денисова Амина Данииловна", Address = "40Ж, Проезжая улица", Sex = "Женщина", BirthDate = new DateOnly(1993, 6, 11), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 7, Name = "Морозов Карим Даниилович", Address = "18, улица 1 Мая", Sex = "Мужчина", BirthDate = new DateOnly(2002, 6, 6), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 8, Name = "Суслова Полина Дмитриевна", Address = "8А, улица Руставели", Sex = "Женщина", BirthDate = new DateOnly(1996, 9, 8), InsuranceType = "ДМС", InsuranceExpDate = new DateOnly(2025, 12, 31) },
                new Patient { Id = 9, Name = "Крюков Никита Романович", Address = "28, Пенягинская улица", Sex = "Мужчина", BirthDate = new DateOnly(2005, 1, 18), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 10, Name = "Гусев Михаил Богданович", Address = "22, Олимпийский проспект", Sex = "Мужчина", BirthDate = new DateOnly(1977, 8, 29), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 11, Name = "Макаров Марк Макарович", Address = "9, Рябиновая улица", Sex = "Мужчина", BirthDate = new DateOnly(1999, 3, 22), InsuranceType = "-", InsuranceExpDate = null },
                new Patient { Id = 12, Name = "Новиков Алексей Артёмович", Address = "34, проспект 50 лет Октября", Sex = "Мужчина", BirthDate = new DateOnly(1965, 4, 7), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 13, Name = "Дроздов Степан Александрович", Address = "13, Гончарная улица", Sex = "Мужчина", BirthDate = new DateOnly(1988, 5, 12), InsuranceType = "ДМС", InsuranceExpDate = new DateOnly(2025, 3, 12) },
                new Patient { Id = 14, Name = "Кожевникова Виктория Семёновна", Address = "11, Коммунистическая улица", Sex = "Женщина", BirthDate = new DateOnly(2001, 1, 22), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 15, Name = "Никонова Лидия Марковна", Address = "9, Рябиновая улица", Sex = "Женщина", BirthDate = new DateOnly(1958, 10, 23), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 16, Name = "Никонов Павел Витальевич", Address = "9, Рябиновая улица", Sex = "Мужчина", BirthDate = new DateOnly(1959, 7, 1), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 17, Name = "Иванов Федот Павлович", Address = "47, Пенягинская улица", Sex = "Мужчина", BirthDate = new DateOnly(1973, 11, 15), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 18, Name = "Гусева Мария Богдановна", Address = "87, Новозаводская улица", Sex = "Женщина", BirthDate = new DateOnly(1998, 11, 11), InsuranceType = "ДМС", InsuranceExpDate = new DateOnly(2027, 2, 25) },
                new Patient { Id = 19, Name = "Петрова Мария Алексеевна", Address = "13, 3-й Железнодорожный тупик", Sex = "Женщина", BirthDate = new DateOnly(1988, 4, 27), InsuranceType = "Полис ОМС", InsuranceExpDate = null },
                new Patient { Id = 20, Name = "Орлов Ян Викторович", Address = "32, Деревня Чепелево", Sex = "Мужчина", BirthDate = new DateOnly(2000, 2, 2), InsuranceType = "-", InsuranceExpDate = null }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Терехов Александр Александрович", Sex = "Мужчина", BirthDate = new DateOnly(1986, 7, 3), Speciallity = "Кардиолог", WorkExperience = 12 },
                new Doctor { Id = 2, Name = "Киселева Валерия Ивановна", Sex = "Женщина", BirthDate = new DateOnly(1992, 5, 8), Speciallity = "Гастроэнтеролог", WorkExperience = 6 },
                new Doctor { Id = 3, Name = "Титова Арина Денисовна", Sex = "Женщина", BirthDate = new DateOnly(1993, 1, 14), Speciallity = "Нефролог", WorkExperience = 5 },
                new Doctor { Id = 4, Name = "Маслов Ян Глебович", Sex = "Мужчина", BirthDate = new DateOnly(1981, 11, 27), Speciallity = "Гепатолог", WorkExperience = 15 },
                new Doctor { Id = 5, Name = "Назарова София Юрьевна", Sex = "Женщина", BirthDate = new DateOnly(1988, 3, 25), Speciallity = "Кардиолог", WorkExperience = 9 },
                new Doctor { Id = 6, Name = "Смирнов Максим Максимович", Sex = "Мужчина", BirthDate = new DateOnly(1977, 3, 25), Speciallity = "Нефролог", WorkExperience = 20 },
                new Doctor { Id = 7, Name = "Осипова Дарья Ивановна", Sex = "Женщина", BirthDate = new DateOnly(1989, 11, 3), Speciallity = "Гастроэнтеролог", WorkExperience = 4 },
                new Doctor { Id = 8, Name = "Быкова Вероника Дамировна", Sex = "Женщина", BirthDate = new DateOnly(1970, 7, 7), Speciallity = "Гепатолог", WorkExperience = 4 }
            );

            modelBuilder.Entity<Ward>().HasData(
                new Ward { Id = 1, NumBeds = 4, WardType = "Общая палата" },
                new Ward { Id = 2, NumBeds = 4, WardType = "Общая палата" },
                new Ward { Id = 3, NumBeds = 2, WardType = "Двуместная палата" },
                new Ward { Id = 4, NumBeds = 2, WardType = "Двуместная палата" },
                new Ward { Id = 5, NumBeds = 1, WardType = "Одноместная палата" },
                new Ward { Id = 6, NumBeds = 1, WardType = "Одноместная палата" }
            );

            modelBuilder.Entity<MedHistory>().HasData(
                new MedHistory { Id = 1, PatientId = 1, Diseases = "Гастрит", Status = "Выписан", DoctorId = 2, WardId = 1, TreatmentCost = 17500, RecordDate = new DateOnly(2025, 1, 5), DischargeDate = new DateOnly(2025, 1, 10) },
                new MedHistory { Id = 2, PatientId = 2, Diseases = "Вирусный Гепатит", Status = "Выписан", DoctorId = 4, WardId = 4, TreatmentCost = 35000, RecordDate = new DateOnly(2025, 1, 6), DischargeDate = new DateOnly(2025, 1, 14) },
                new MedHistory { Id = 3, PatientId = 3, Diseases = "Синдром раздражённого кишечника", Status = "Выписан", DoctorId = 2, WardId = 3, TreatmentCost = 12000, RecordDate = new DateOnly(2025, 1, 6), DischargeDate = new DateOnly(2025, 1, 11) },
                new MedHistory { Id = 4, PatientId = 4, Diseases = "Камни в желчном пузыре", Status = "Выписан", DoctorId = 2, WardId = 1, TreatmentCost = 25000, RecordDate = new DateOnly(2025, 1, 6), DischargeDate = new DateOnly(2025, 1, 16) },
                new MedHistory { Id = 5, PatientId = 5, Diseases = "Жёлтуха", Status = "Выписан", DoctorId = 8, WardId = 2, TreatmentCost = 18500, RecordDate = new DateOnly(2025, 1, 7), DischargeDate = new DateOnly(2025, 1, 13) },
                new MedHistory { Id = 6, PatientId = 6, Diseases = "Колит", Status = "Выписан", DoctorId = 7, WardId = 2, TreatmentCost = 22000, RecordDate = new DateOnly(2025, 1, 9), DischargeDate = new DateOnly(2025, 1, 16) },
                new MedHistory { Id = 7, PatientId = 7, Diseases = "Инфекционное заболевание почек", Status = "Выписан", DoctorId = 6, WardId = 1, TreatmentCost = 20000, RecordDate = new DateOnly(2025, 1, 9), DischargeDate = new DateOnly(2025, 1, 14) },
                new MedHistory { Id = 8, PatientId = 8, Diseases = "Порок сердца", Status = "Выписан", DoctorId = 1, WardId = 4, TreatmentCost = 58000, RecordDate = new DateOnly(2025, 1, 10), DischargeDate = new DateOnly(2025, 1, 18) },
                new MedHistory { Id = 9, PatientId = 9, Diseases = "Стеатоз", Status = "Выписан", DoctorId = 4, WardId = 1, TreatmentCost = 20000, RecordDate = new DateOnly(2025, 1, 10), DischargeDate = new DateOnly(2025, 1, 15) },
                new MedHistory { Id = 10, PatientId = 10, Diseases = "Гипертония", Status = "Выписан", DoctorId = 1, WardId = 1, TreatmentCost = 19500, RecordDate = new DateOnly(2025, 1, 11), DischargeDate = new DateOnly(2025, 1, 16) },
                new MedHistory { Id = 11, PatientId = 11, Diseases = "Ишемическая болезнь сердца", Status = "Выписан", DoctorId = 1, WardId = 3, TreatmentCost = 43500, RecordDate = new DateOnly(2025, 1, 13), DischargeDate = new DateOnly(2025, 1, 20) },
                new MedHistory { Id = 12, PatientId = 12, Diseases = "Инфаркт миокарда", Status = "Выписан", DoctorId = 1, WardId = 5, TreatmentCost = 120000, RecordDate = new DateOnly(2025, 1, 13), DischargeDate = new DateOnly(2025, 1, 23) },
                new MedHistory { Id = 13, PatientId = 13, Diseases = "Гломерулонефрит", Status = "Выписан", DoctorId = 1, WardId = 3, TreatmentCost = 30000, RecordDate = new DateOnly(2025, 1, 14), DischargeDate = new DateOnly(2025, 1, 24) },
                new MedHistory { Id = 14, PatientId = 14, Diseases = "Гастрит", Status = "Выписан", DoctorId = 7, WardId = 2, TreatmentCost = 11500, RecordDate = new DateOnly(2025, 1, 15), DischargeDate = new DateOnly(2025, 1, 20) },
                new MedHistory { Id = 15, PatientId = 15, Diseases = "Сердечная недостаточность", Status = "В плате", DoctorId = 5, WardId = 6, TreatmentCost = 83000, RecordDate = new DateOnly(2025, 1, 16), DischargeDate = new DateOnly(2025, 1, 26) },
                new MedHistory { Id = 16, PatientId = 16, Diseases = "Нефролитиаз", Status = "Выписан", DoctorId = 6, WardId = 1, TreatmentCost = 25000, RecordDate = new DateOnly(2025, 1, 18), DischargeDate = new DateOnly(2025, 1, 23) },
                new MedHistory { Id = 17, PatientId = 17, Diseases = "Пиелонефрит", Status = "В плате", DoctorId = 5, WardId = 1, TreatmentCost = 28500, RecordDate = new DateOnly(2025, 1, 19), DischargeDate = new DateOnly(2025, 1, 26) },
                new MedHistory { Id = 18, PatientId = 2, Diseases = "Гастрит", Status = "В плате", DoctorId = 7, WardId = 2, TreatmentCost = 10000, RecordDate = new DateOnly(2025, 1, 19), DischargeDate = new DateOnly(2025, 1, 24) },
                new MedHistory { Id = 19, PatientId = 18, Diseases = "Холестаз", Status = "В плате", DoctorId = 8, WardId = 4, TreatmentCost = 35000, RecordDate = new DateOnly(2025, 1, 20), DischargeDate = new DateOnly(2025, 1, 30) },
                new MedHistory { Id = 20, PatientId = 19, Diseases = "Гипертония", Status = "В плате", DoctorId = 5, WardId = 2, TreatmentCost = 18000, RecordDate = new DateOnly(2025, 1, 21), DischargeDate = new DateOnly(2025, 1, 28) },
                new MedHistory { Id = 21, PatientId = 8, Diseases = "Камни в желчном пузыре", Status = "В плате", DoctorId = 7, WardId = 2, TreatmentCost = 45000, RecordDate = new DateOnly(2025, 1, 21), DischargeDate = new DateOnly(2025, 1, 30) },
                new MedHistory { Id = 22, PatientId = 20, Diseases = "Поликистоз почек", Status = "В плате", DoctorId = 6, WardId = 3, TreatmentCost = 32500, RecordDate = new DateOnly(2025, 1, 22), DischargeDate = new DateOnly(2025, 1, 29) },
                new MedHistory { Id = 23, PatientId = 5, Diseases = "Инфекционные заболевания почек", Status = "В плате", DoctorId = 3, WardId = 2, TreatmentCost = 18500, RecordDate = new DateOnly(2025, 1, 22), DischargeDate = new DateOnly(2025, 1, 27) },
                new MedHistory { Id = 24, PatientId = 6, Diseases = "Язвенная болезнь желудка", Status = "В плате", DoctorId = 7, WardId = 2, TreatmentCost = 22500, RecordDate = new DateOnly(2025, 1, 23), DischargeDate = new DateOnly(2025, 1, 30) },
                new MedHistory { Id = 25, PatientId = 6, Diseases = "Гипертония", Status = "В плате", DoctorId = 1, WardId = 2, TreatmentCost = 16500, RecordDate = new DateOnly(2025, 1, 23), DischargeDate = new DateOnly(2025, 1, 30) }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "Admin", PasswordHash = "O2Esdae1BIpDX7bsgeUv+S1teVqLWpwXBw9qY8l6U7I=" }, //password - Admin123
                new User { Id = 2, UserName = "User", PasswordHash = "phqK32ADh5Kiy4jmcLIFQKnWwsogSrdU/HaJUOeefTY=" }, //password - User123
                new User { Id = 3, UserName = "User2", PasswordHash = "xdfiUTEW4g6lVU5g39FwuyDFDTg6oI/Xe789IXQTncw=" } //password - User2123
            );
        }
    }
}
