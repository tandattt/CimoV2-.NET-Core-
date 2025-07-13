using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Cimo.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicLevel> AcademicLevels { get; set; }

    public virtual DbSet<AcademicYear> AcademicYears { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<ClassroomSubjectTeacher> ClassroomSubjectTeachers { get; set; }

    public virtual DbSet<ClassroomTeacherRole> ClassroomTeacherRoles { get; set; }

    public virtual DbSet<FeatureSetting> FeatureSettings { get; set; }

    public virtual DbSet<FeatureUserAccess> FeatureUserAccesses { get; set; }

    public virtual DbSet<GradeLevel> GradeLevels { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<ParentDetail> ParentDetails { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostComment> PostComments { get; set; }

    public virtual DbSet<PostImage> PostImages { get; set; }

    public virtual DbSet<PostLike> PostLikes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

    public virtual DbSet<StudentClassroom> StudentClassrooms { get; set; }

    public virtual DbSet<StudentOff> StudentOffs { get; set; }

    public virtual DbSet<StudentParent> StudentParents { get; set; }

    public virtual DbSet<StudentScore> StudentScores { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectGroup> SubjectGroups { get; set; }

    public virtual DbSet<TeacherDetail> TeacherDetails { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AcademicLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("academic_level");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
        });

        modelBuilder.Entity<AcademicYear>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("academic_year");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("classroom");

            entity.HasIndex(e => e.GradeLevelId, "FKkoixvdplr7y7ild17y6hu6lrk");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.GradeLevelId).HasColumnName("grade_level_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");

            entity.HasOne(d => d.GradeLevel).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.GradeLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKkoixvdplr7y7ild17y6hu6lrk");
        });

        modelBuilder.Entity<ClassroomSubjectTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("classroom_subject_teacher");

            entity.HasIndex(e => e.SubjectId, "FKbk6cnrgcf47ya5qc6qdudks4i");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("subject_id");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");

            entity.HasOne(d => d.Subject).WithMany(p => p.ClassroomSubjectTeachers)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKbk6cnrgcf47ya5qc6qdudks4i");
        });

        modelBuilder.Entity<ClassroomTeacherRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("classroom_teacher_role");

            entity.HasIndex(e => e.AcademicYear, "fk_academic_year");

            entity.HasIndex(e => e.ClassroomId, "fk_classroom");

            entity.HasIndex(e => e.RoleId, "fk_role");

            entity.HasIndex(e => e.TeacherDetail, "fk_teacher_detail");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.AcademicYear)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("academic_year");
            entity.Property(e => e.ClassroomId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("classroom_id");
            entity.Property(e => e.RoleId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("role_id");
            entity.Property(e => e.TeacherDetail)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("teacher_detail_id");

            entity.HasOne(d => d.AcademicYearNavigation).WithMany(p => p.ClassroomTeacherRoles)
                .HasForeignKey(d => d.AcademicYear)
                .HasConstraintName("fk_academic_year");

            entity.HasOne(d => d.Classroom).WithMany(p => p.ClassroomTeacherRoles)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("fk_classroom");

            entity.HasOne(d => d.Role).WithMany(p => p.ClassroomTeacherRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_role");

            entity.HasOne(d => d.TeacherDetailNavigation).WithMany(p => p.ClassroomTeacherRoles)
                .HasForeignKey(d => d.TeacherDetail)
                .HasConstraintName("fk_teacher_detail");
        });

        modelBuilder.Entity<FeatureSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("feature_setting")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<FeatureUserAccess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("feature_user_access")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.RoleId, "fk_feature_user_access_role");

            entity.HasIndex(e => e.FeatureSettingId, "fk_feature_user_access_setting");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FeatureSettingId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("feature_setting_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("is_active");
            entity.Property(e => e.RoleId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("role_id");

            entity.HasOne(d => d.FeatureSetting).WithMany(p => p.FeatureUserAccesses)
                .HasForeignKey(d => d.FeatureSettingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_feature_user_access_setting");

            entity.HasOne(d => d.Role).WithMany(p => p.FeatureUserAccesses)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_feature_user_access_role");
        });

        modelBuilder.Entity<GradeLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("grade_level");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notification");

            entity.HasIndex(e => e.UserId, "FKb0yvoep4h4k92ipon31wmdf7e");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead)
                .HasColumnType("bit(1)")
                .HasColumnName("is_read");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.ReadAt)
                .HasMaxLength(6)
                .HasColumnName("read_at");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasColumnType("enum('score','attendance','leave')")
                .HasColumnName("type");
            entity.Property(e => e.UserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKb0yvoep4h4k92ipon31wmdf7e");
        });

        modelBuilder.Entity<ParentDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("parent_detail");

            entity.Property(e => e.UserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("user_id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.Pin)
                .HasMaxLength(100)
                .HasColumnName("pin");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");

            entity.HasOne(d => d.User).WithOne(p => p.ParentDetail)
                .HasForeignKey<ParentDetail>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKcbicq36w7k80di14w5y2o4x5x");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("post");

            entity.HasIndex(e => e.UserId, "FK72mt33dhhs48hf9gcqrq4fxte");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.ToClass)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("to_class");
            entity.Property(e => e.TotalComment).HasColumnName("total_comment");
            entity.Property(e => e.TotalLike).HasColumnName("total_like");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
            entity.Property(e => e.UserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("user_id");
            entity.Property(e => e.Visibility)
                .HasColumnType("enum('PUBLIC','CLASS')")
                .HasColumnName("visibility");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK72mt33dhhs48hf9gcqrq4fxte");
        });

        modelBuilder.Entity<PostComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("post_comment");

            entity.HasIndex(e => e.PostId, "FKna4y825fdc5hw8aow65ijexm0");

            entity.HasIndex(e => e.UserId, "FKtc1fl97yq74q7j8i08ds731s1");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.ParentCommentId).HasColumnName("parent_comment_id");
            entity.Property(e => e.PostId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("post_id");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
            entity.Property(e => e.UserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKna4y825fdc5hw8aow65ijexm0");

            entity.HasOne(d => d.User).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKtc1fl97yq74q7j8i08ds731s1");
        });

        modelBuilder.Entity<PostImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("post_image");

            entity.HasIndex(e => e.PostId, "FKsip7qv57jw2fw50g97t16nrjr");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImageIndex).HasColumnName("image_index");
            entity.Property(e => e.PostId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("post_id");

            entity.HasOne(d => d.Post).WithMany(p => p.PostImages)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKsip7qv57jw2fw50g97t16nrjr");
        });

        modelBuilder.Entity<PostLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("post_like");

            entity.HasIndex(e => e.UserId, "FKhuh7nn7libqf645su27ytx21m");

            entity.HasIndex(e => e.PostId, "FKj7iy0k7n3d0vkh8o7ibjna884");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.PostId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("post_id");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
            entity.Property(e => e.UserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.PostLikes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKj7iy0k7n3d0vkh8o7ibjna884");

            entity.HasOne(d => d.User).WithMany(p => p.PostLikes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKhuh7nn7libqf645su27ytx21m");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("role");

            entity.HasIndex(e => e.Name, "UK_8sewwnpamngi6b1dwaa88askk").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("semester");

            entity.HasIndex(e => e.AcademicYearsId, "FKpfslqpot36u218l1g5n92u1i8");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.AcademicYearsId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("academic_years_id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");

            entity.HasOne(d => d.AcademicYears).WithMany(p => p.Semesters)
                .HasForeignKey(d => d.AcademicYearsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKpfslqpot36u218l1g5n92u1i8");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(200)
                .HasColumnName("avatar_url");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("first_name");
            entity.Property(e => e.FullName)
                .HasMaxLength(45)
                .HasColumnName("full_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("last_name");
            entity.Property(e => e.Gender)
               .HasColumnType("enum('MALE','FEMALE')")
               .HasColumnName("gender");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
        });

        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student_attendance");

            entity.HasIndex(e => e.StudentId, "FKrxjgxdiwf7l4gn2ynshg4o46y");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CheckType)
                .HasColumnType("enum('in','out')")
                .HasColumnName("check_type");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.Session)
                .HasColumnType("enum('morning','afternoon')")
                .HasColumnName("session");
            entity.Property(e => e.StudentId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("student_id");
            entity.Property(e => e.TeacherDetailUserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("teacher_detail_user_id");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAttendances)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKrxjgxdiwf7l4gn2ynshg4o46y");
        });

        modelBuilder.Entity<StudentClassroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student_classroom");

            entity.HasIndex(e => e.StudentId, "FK4gqo6scoya0b2xkxaot9g843c");

            entity.HasIndex(e => e.ClassroomId, "FKqgpokgp94ohrr15iso5bbdxii");

            entity.HasIndex(e => e.AcademicYearsId, "FKqrteymlkcg6xjd04wicdri2ll");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.AcademicYearsId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("academic_years_id");
            entity.Property(e => e.ClassroomId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("classroom_id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.IsCurrent)
                .HasColumnType("bit(1)")
                .HasColumnName("is_current");
            entity.Property(e => e.StudentId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("student_id");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");

            entity.HasOne(d => d.AcademicYears).WithMany(p => p.StudentClassrooms)
                .HasForeignKey(d => d.AcademicYearsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKqrteymlkcg6xjd04wicdri2ll");

            entity.HasOne(d => d.Classroom).WithMany(p => p.StudentClassrooms)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKqgpokgp94ohrr15iso5bbdxii");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentClassrooms)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK4gqo6scoya0b2xkxaot9g843c");
        });

        modelBuilder.Entity<StudentOff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student_off");

            entity.HasIndex(e => e.ParentDetailUserId, "FK1ny4hf5be4vt71f0iuprc0gxc");

            entity.HasIndex(e => e.StudentId, "FKgrer3y2ljhx3fybxqkrujnlba");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.ParentDetailUserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("parent_detail_user_id");
            entity.Property(e => e.Reason)
                .HasColumnType("text")
                .HasColumnName("reason");
            entity.Property(e => e.ReasonRejected)
                .HasColumnType("text")
                .HasColumnName("reason_rejected");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasColumnType("enum('pending','approved','rejected','cancel')")
                .HasColumnName("status");
            entity.Property(e => e.StudentId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("student_id");
            entity.Property(e => e.TeacherDetailUserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("teacher_detail_user_id");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");

            entity.HasOne(d => d.ParentDetailUser).WithMany(p => p.StudentOffs)
                .HasForeignKey(d => d.ParentDetailUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1ny4hf5be4vt71f0iuprc0gxc");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentOffs)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKgrer3y2ljhx3fybxqkrujnlba");
        });

        modelBuilder.Entity<StudentParent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student_parent");

            entity.HasIndex(e => e.StudentId, "FK3nulmrwg4cubngtp7nq5lud86");

            entity.HasIndex(e => e.ParentDetailUserId, "FKfk85x902uxc93pydkipmtvuj3");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.IsConfirmed)
                .HasMaxLength(6)
                .HasColumnName("is_confirmed");
            entity.Property(e => e.IsParentConfirmed)
                .HasColumnType("bit(1)")
                .HasColumnName("is_parent_confirmed");
            entity.Property(e => e.ParentDetailUserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("parent_detail_user_id");
            entity.Property(e => e.StudentId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("student_id");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");

            entity.HasOne(d => d.ParentDetailUser).WithMany(p => p.StudentParents)
                .HasForeignKey(d => d.ParentDetailUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKfk85x902uxc93pydkipmtvuj3");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentParents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK3nulmrwg4cubngtp7nq5lud86");
        });

        modelBuilder.Entity<StudentScore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student_score");

            entity.HasIndex(e => e.SemesterId, "FKbbljn3rxvgs2sqf7ej65qt1dh");

            entity.HasIndex(e => e.SubjectId, "FKiu440kx4harwcp19nc1jw50xf");

            entity.HasIndex(e => e.StudentId, "FKkufxavwp2so1i1t5uhkaeutjg");

            entity.HasIndex(e => e.AcademicYearsId, "FKnsvx57gthl3rjuenvbnskh1xo");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.AcademicYearsId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("academic_years_id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.ScoreIndex).HasColumnName("score_index");
            entity.Property(e => e.ScoreType)
                .HasColumnType("enum('Regular','Midterm','Final')")
                .HasColumnName("score_type");
            entity.Property(e => e.ScoreTypeId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("score_type_id");
            entity.Property(e => e.SemesterId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("semester_id");
            entity.Property(e => e.StudentId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("student_id");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("subject_id");
            entity.Property(e => e.TeacherDetailUserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("teacher_detail_user_id");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");

            entity.HasOne(d => d.AcademicYears).WithMany(p => p.StudentScores)
                .HasForeignKey(d => d.AcademicYearsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKnsvx57gthl3rjuenvbnskh1xo");

            entity.HasOne(d => d.Semester).WithMany(p => p.StudentScores)
                .HasForeignKey(d => d.SemesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKbbljn3rxvgs2sqf7ej65qt1dh");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentScores)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKkufxavwp2so1i1t5uhkaeutjg");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudentScores)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKiu440kx4harwcp19nc1jw50xf");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subject");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
        });

        modelBuilder.Entity<SubjectGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subject_group");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
        });

        modelBuilder.Entity<TeacherDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("teacher_detail");

            entity.HasIndex(e => e.AcademicLevelId, "FK2w8yxnn85cjwat1u9lhk3fh10");

            entity.HasIndex(e => e.SubjectGroupId, "FKbiqow4xvx0we0nixxc4bbmohh");

            entity.Property(e => e.UserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("user_id");
            entity.Property(e => e.AcademicLevelId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("academic_level_id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.SubjectGroupId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("subject_group_id");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");

            entity.HasOne(d => d.AcademicLevel).WithMany(p => p.TeacherDetails)
                .HasForeignKey(d => d.AcademicLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK2w8yxnn85cjwat1u9lhk3fh10");

            entity.HasOne(d => d.SubjectGroup).WithMany(p => p.TeacherDetails)
                .HasForeignKey(d => d.SubjectGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKbiqow4xvx0we0nixxc4bbmohh");

            entity.HasOne(d => d.User).WithOne(p => p.TeacherDetail)
                .HasForeignKey<TeacherDetail>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKhiopbvdir05ely69bvwbx8sx");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("timetable");

            entity.HasIndex(e => e.SemesterId, "FKmkvrn4nnpjhpjxgqvd4dhfdbl");

            entity.HasIndex(e => e.ClassroomId, "FKpka4rw7areqvljrvbwf6py7vw");

            entity.HasIndex(e => e.SubjectId, "FKrh8c0l2hwidfd0hbp7ovnjpck");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.ClassroomId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("classroom_id");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.SemesterId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("semester_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("subject_id");
            entity.Property(e => e.SubjectSlot).HasColumnName("subject_slot");
            entity.Property(e => e.TeacherDetailUserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("teacher_detail_user_id");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
            entity.Property(e => e.Weekday)
                .HasColumnType("enum('Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday')")
                .HasColumnName("weekday");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKpka4rw7areqvljrvbwf6py7vw");

            entity.HasOne(d => d.Semester).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.SemesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKmkvrn4nnpjhpjxgqvd4dhfdbl");

            entity.HasOne(d => d.Subject).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKrh8c0l2hwidfd0hbp7ovnjpck");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(100)
                .HasColumnName("avatar_url");
            entity.Property(e => e.CreateAt)
                .HasMaxLength(6)
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("create_by");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("first_name");
            entity.Property(e => e.FullName)
                .HasMaxLength(45)
                .HasColumnName("full_name");
            entity.Property(e => e.IsDeleted)
                .HasColumnType("bit(1)")
                .HasColumnName("is_deleted");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(45)
                .HasColumnName("phone_number");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdateAt)
                .HasMaxLength(6)
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("update_by");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_role");

            entity.HasIndex(e => e.UserId, "FK859n2jvi8ivhui0rl0esws6o");

            entity.HasIndex(e => e.RoleId, "FKa68196081fvovjhkek5m97n3y");

            entity.Property(e => e.Id)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.RoleId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("role_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKa68196081fvovjhkek5m97n3y");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK859n2jvi8ivhui0rl0esws6o");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}