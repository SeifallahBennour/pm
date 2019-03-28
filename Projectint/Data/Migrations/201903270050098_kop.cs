namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cin = c.Int(nullable: false),
                        firstName = c.String(),
                        lastName = c.String(),
                        gender = c.String(),
                        Address = c.String(),
                        imagePath = c.String(),
                        RoleUser = c.String(),
                        age = c.Int(nullable: false),
                        password2 = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        SpecialityId = c.Int(),
                        matricule = c.String(),
                        Role = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId)
                .Index(t => t.SpecialityId);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        postId = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.commentId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Posts", t => t.postId)
                .Index(t => t.postId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        postId = c.Int(nullable: false, identity: true),
                        posttitre = c.String(),
                        content = c.String(),
                        catgoriepostId = c.Int(),
                        cat_categorypostId = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.postId)
                .ForeignKey("dbo.CategoryPosts", t => t.cat_categorypostId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.cat_categorypostId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CategoryPosts",
                c => new
                    {
                        categorypostId = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.categorypostId)
                .ForeignKey("dbo.Users", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        projectId = c.Int(nullable: false, identity: true),
                        projectname = c.String(),
                        description = c.String(),
                        plan = c.String(),
                        goals = c.String(),
                        state = c.Int(nullable: false),
                        team_leaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.projectId)
                .ForeignKey("dbo.Users", t => t.team_leaderId, cascadeDelete: true)
                .Index(t => t.team_leaderId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        tasksId = c.Int(nullable: false, identity: true),
                        duration = c.Int(nullable: false),
                        projectId = c.Int(nullable: false),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.tasksId)
                .ForeignKey("dbo.Projects", t => t.projectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Member_Id)
                .Index(t => t.projectId)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.CustomLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CustomRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.CustomRole_Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        appointmentId = c.Int(nullable: false, identity: true),
                        dateAppointmentJEE = c.String(),
                        datePriseRDV = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        reason = c.String(),
                        state = c.String(),
                        message = c.String(),
                        HourAppointment = c.Int(nullable: false),
                        price = c.Single(nullable: false),
                        note = c.Int(nullable: false),
                        IdPatient = c.Int(),
                        Iddoctor = c.Int(),
                        path_pathId = c.Int(),
                    })
                .PrimaryKey(t => t.appointmentId)
                .ForeignKey("dbo.Users", t => t.Iddoctor)
                .ForeignKey("dbo.Paths", t => t.path_pathId)
                .ForeignKey("dbo.Users", t => t.IdPatient)
                .Index(t => t.IdPatient)
                .Index(t => t.Iddoctor)
                .Index(t => t.path_pathId);
            
            CreateTable(
                "dbo.Paths",
                c => new
                    {
                        pathId = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.pathId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sender = c.String(nullable: false),
                        receiver = c.String(nullable: false),
                        objectC = c.String(nullable: false),
                        Doctor_Id = c.Int(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Doctor_Id)
                .ForeignKey("dbo.Users", t => t.Patient_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Raitings",
                c => new
                    {
                        id = c.Int(nullable: false),
                        rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Appointments", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateDisponobilite = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        idU = c.Int(nullable: false),
                        dateAvailable = c.String(),
                        IsfullDay = c.Boolean(nullable: false),
                        startHour = c.Int(nullable: false),
                        endHour = c.Int(nullable: false),
                        startDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        endDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Etat = c.String(),
                        Description = c.String(),
                        Subject = c.String(),
                        ThemeColor = c.String(),
                        Day = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DoctorId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        SpecialityId = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                    })
                .PrimaryKey(t => t.SpecialityId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        fileId = c.Int(nullable: false, identity: true),
                        filetitre = c.String(),
                        content = c.String(),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.fileId)
                .ForeignKey("dbo.Users", t => t.Member_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        historyId = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        team_leader_Id = c.Int(),
                        team_member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.historyId)
                .ForeignKey("dbo.Users", t => t.team_leader_Id)
                .ForeignKey("dbo.Users", t => t.team_member_Id)
                .Index(t => t.team_leader_Id)
                .Index(t => t.team_member_Id);
            
            CreateTable(
                "dbo.emails",
                c => new
                    {
                        emailId = c.Int(nullable: false, identity: true),
                        user1id = c.Int(),
                        user2Id = c.Int(),
                        Sujet = c.String(),
                        Corps = c.String(),
                        TeamLeader_Id = c.Int(),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.emailId)
                .ForeignKey("dbo.Users", t => t.user1id)
                .ForeignKey("dbo.Users", t => t.user2Id)
                .ForeignKey("dbo.Users", t => t.TeamLeader_Id)
                .ForeignKey("dbo.Users", t => t.Member_Id)
                .Index(t => t.user1id)
                .Index(t => t.user2Id)
                .Index(t => t.TeamLeader_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Interventions",
                c => new
                    {
                        interventionId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        DoctorId = c.Int(),
                        idU = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.interventionId)
                .ForeignKey("dbo.Users", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Interventions", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.Comments", "postId", "dbo.Posts");
            DropForeignKey("dbo.CategoryPosts", "ManagerId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "Member_Id", "dbo.Users");
            DropForeignKey("dbo.emails", "Member_Id", "dbo.Users");
            DropForeignKey("dbo.Histories", "team_member_Id", "dbo.Users");
            DropForeignKey("dbo.emails", "TeamLeader_Id", "dbo.Users");
            DropForeignKey("dbo.emails", "user2Id", "dbo.Users");
            DropForeignKey("dbo.emails", "user1id", "dbo.Users");
            DropForeignKey("dbo.Histories", "team_leader_Id", "dbo.Users");
            DropForeignKey("dbo.Files", "Member_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Availabilities", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.Raitings", "id", "dbo.Appointments");
            DropForeignKey("dbo.Chats", "Patient_Id", "dbo.Users");
            DropForeignKey("dbo.Chats", "Doctor_Id", "dbo.Users");
            DropForeignKey("dbo.Appointments", "IdPatient", "dbo.Users");
            DropForeignKey("dbo.Appointments", "path_pathId", "dbo.Paths");
            DropForeignKey("dbo.Appointments", "Iddoctor", "dbo.Users");
            DropForeignKey("dbo.CustomUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Projects", "team_leaderId", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "projectId", "dbo.Projects");
            DropForeignKey("dbo.Posts", "cat_categorypostId", "dbo.CategoryPosts");
            DropIndex("dbo.Interventions", new[] { "DoctorId" });
            DropIndex("dbo.emails", new[] { "Member_Id" });
            DropIndex("dbo.emails", new[] { "TeamLeader_Id" });
            DropIndex("dbo.emails", new[] { "user2Id" });
            DropIndex("dbo.emails", new[] { "user1id" });
            DropIndex("dbo.Histories", new[] { "team_member_Id" });
            DropIndex("dbo.Histories", new[] { "team_leader_Id" });
            DropIndex("dbo.Files", new[] { "Member_Id" });
            DropIndex("dbo.Availabilities", new[] { "DoctorId" });
            DropIndex("dbo.Raitings", new[] { "id" });
            DropIndex("dbo.Chats", new[] { "Patient_Id" });
            DropIndex("dbo.Chats", new[] { "Doctor_Id" });
            DropIndex("dbo.Appointments", new[] { "path_pathId" });
            DropIndex("dbo.Appointments", new[] { "Iddoctor" });
            DropIndex("dbo.Appointments", new[] { "IdPatient" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "UserId" });
            DropIndex("dbo.CustomLogins", new[] { "UserId" });
            DropIndex("dbo.Tasks", new[] { "Member_Id" });
            DropIndex("dbo.Tasks", new[] { "projectId" });
            DropIndex("dbo.Projects", new[] { "team_leaderId" });
            DropIndex("dbo.CategoryPosts", new[] { "ManagerId" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "cat_categorypostId" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "postId" });
            DropIndex("dbo.CustomUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "SpecialityId" });
            DropTable("dbo.CustomRoles");
            DropTable("dbo.Interventions");
            DropTable("dbo.emails");
            DropTable("dbo.Histories");
            DropTable("dbo.Files");
            DropTable("dbo.Specialities");
            DropTable("dbo.Availabilities");
            DropTable("dbo.Raitings");
            DropTable("dbo.Chats");
            DropTable("dbo.Paths");
            DropTable("dbo.Appointments");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomLogins");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
            DropTable("dbo.CategoryPosts");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Users");
        }
    }
}
