CREATE TABLE "Band" (
  "Id" SERIAL PRIMARY KEY,
"Name" TEXT,
"CountryOfOrigin" TEXT,
"NumberOfMembers" INT,
"Website" TEXT,
"Style" TEXT,
"IsSigned" BOOL,
"ContactName" TEXT,
"ContactPhoneNumber" TEXT
  );

INSERT INTO "Band" (
  "Name","CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('Daft Punk', 'France', '2', 'www.daftpunk.com', 'electronic', TRUE, 'Marcel', '777-777-7777' ),
('Radiohead', 'UK', '6', 'www.radiohead.com', 'alternative', TRUE, 'Thom', '07759-852314'), ( 'Sigur Ros',
'Iceland', '6','sigurros.com', 'Post Rock', TRUE, 'Jonsi', '555-555-5555'), ('Jinger', 'Ukraine', 4, 'Jinger.net', 'metal', FALSE, 'Louie', 789-854-5321), ('Ernie and the rubber ducks', 'Bathtub', 5, 'ernie.com', 'Hardcore Punk', TRUE, 'Ernie', '666-666-6666');
  
SELECT * FROM "Band"

create table "Album"(
"Id" SERIAL PRIMARY KEY,
"Title" TEXT,
"IsExplicit" TEXT,
"ReleaseDate" Date
);

ALTER TABLE "Album" ADD "BandId" INTEGER REFERENCES "Band" ("Id");

INSERT INTO "Album" ("Title", "IsExplicit", "ReleaseDate", "BandId" )
VALUES ('OK Computer', TRUE, '1997-05-21', 2);

CREATE TABLE "Song" (
	"Id" SERIAL PRIMARY KEY,
	"TrackNumber" INT,
	"Title" TEXT,
	"Duration" INT,
	"Album" INT
);

ALTER TABLE "Song" ADD COLUMN "AlbumId" REFERENCE;

INSERT INTO "Song" ("TrackNumber", "Title", "Duration", "Album")
VALUES (1, 'Airbag', '4:44', 1)

SELECT * FROM "Song"

UPDATE "Band" SET "IsSigned" = 'FALSE' 
WHERE "Name" = 'Sigur Ross'

UPDATE "Band" SET "IsSigned" = 'TRUE' 
WHERE "Name" = 'Jinger'

SELECT * FROM "Album" WHERE "BandId" = 2

ALTER TABLE "Song" ADD "AlbumId" INTEGER REFERENCES "Album" ("Id")

SELECT * FROM "Album"
JOIN "Song" ON "Album"."Id" = "Song"."AlbumId"
ORDER BY "ReleaseDate"

SELECT * FROM "Band" WHERE "IsSigned" = TRUE

SELECT * FROM "Band" WHERE "IsSigned" = FALSE