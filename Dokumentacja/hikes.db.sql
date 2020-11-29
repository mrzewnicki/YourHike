BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
CREATE TABLE IF NOT EXISTS "Hikes" (
	"Id"	INTEGER NOT NULL,
	"Title"	TEXT,
	"StartDate"	TEXT NOT NULL,
	"EndDate"	TEXT,
	"StartPlace"	TEXT,
	"EndPlace"	TEXT,
	"Distance"	REAL,
	CONSTRAINT "PK_Hikes" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "HikesHistory" (
	"Id"	INTEGER NOT NULL,
	"HikeId"	INTEGER NOT NULL,
	"OldValue"	TEXT,
	"NewValue"	TEXT,
	"Description"	TEXT,
	"ModifyTime"	TEXT NOT NULL,
	CONSTRAINT "FK_HikesHistory_HikesHistory_HikeId" FOREIGN KEY("HikeId") REFERENCES "HikesHistory"("Id") ON DELETE CASCADE,
	CONSTRAINT "PK_HikesHistory" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Files" (
	"Id"	INTEGER NOT NULL,
	"DisplayName"	TEXT,
	"FileType"	TEXT,
	"FileName"	TEXT,
	"UploadTime"	TEXT NOT NULL,
	"HikeId"	INTEGER NOT NULL,
	CONSTRAINT "FK_Files_Hikes_HikeId" FOREIGN KEY("HikeId") REFERENCES "Hikes"("Id") ON DELETE CASCADE,
	CONSTRAINT "PK_Files" PRIMARY KEY("Id" AUTOINCREMENT)
);
INSERT INTO "__EFMigrationsHistory" ("MigrationId","ProductVersion") VALUES ('20201129113219_InitialCreate','5.0.0-rc.2.20475.6');
INSERT INTO "Hikes" ("Id","Title","StartDate","EndDate","StartPlace","EndPlace","Distance") VALUES (1,'Las Kabacki','2020-11-29 12:32:18.9798797','2020-11-30 12:32:18.9844982','Dom','Las Kabacki',5.4);
INSERT INTO "Hikes" ("Id","Title","StartDate","EndDate","StartPlace","EndPlace","Distance") VALUES (2,'Chojnowski Park Krajobrazowy','2020-12-04 12:32:18.9847853','2020-12-04 12:32:18.9847892','Dom','Chojnowski Park Krajobrazowy',9.2);
INSERT INTO "HikesHistory" ("Id","HikeId","OldValue","NewValue","Description","ModifyTime") VALUES (1,1,'Chojnowski','Chojnowski Park Krajobrazowy','Zmiana tytułu','2020-11-29 12:32:18.9870432');
INSERT INTO "Files" ("Id","DisplayName","FileType","FileName","UploadTime","HikeId") VALUES (1,'Zdjęcie pierwsze','png','pierwsze_zdjecie.png','2020-11-29 12:32:18.986711',1);
INSERT INTO "Files" ("Id","DisplayName","FileType","FileName","UploadTime","HikeId") VALUES (2,'Zdjęcie drugie','png','drugie_zdjecie.png','2020-11-29 12:32:18.9868043',1);
INSERT INTO "Files" ("Id","DisplayName","FileType","FileName","UploadTime","HikeId") VALUES (3,'Zdjęcie trzecie','png','trzecie_zdjecie.png','2020-11-29 12:32:18.9868079',2);
CREATE INDEX IF NOT EXISTS "IX_Files_HikeId" ON "Files" (
	"HikeId"
);
CREATE INDEX IF NOT EXISTS "IX_HikesHistory_HikeId" ON "HikesHistory" (
	"HikeId"
);
COMMIT;
