BEGIN TRANSACTION;
ALTER TABLE "AspNetUsers" ADD "Nik" TEXT NULL;

ALTER TABLE "AspNetUsers" ADD "Npwp" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20260819044749_AddNikNpwpColumn', '10.0.11');

COMMIT;

