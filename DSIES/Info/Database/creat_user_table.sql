CREATE TABLE regular (
	telephone    TEXT NOT NULL UNIQUE,
	name		TEXT NOT NULL,
	password	TEXT NOT NULL,
	--regDate		TIMESTAMP NOT NULL DEFAULT (datetime('now','localtime')),
	--lastDate	TIMESTAMP NOT NULL DEFAULT (datetime('now','localtime')),
	gender		TEXT NOT NULL,
	age			TEXT NOT NULL,
	driAge		TEXT NOT NULL,
	career		TEXT NOT NULL,
	accident_times  TEXT NOT NULL,
	sight_left     TEXT NOT NULL,
	sight_right 	TEXT NOT NULL,
	deep_sight_left   TEXT NOT NULL,
	deep_sight_right   TEXT NOT NULL,
	reagency     TEXT NOT NULL,
	grade        TEXT  NULL,
	grade1       TEXT   NULL, 
	grade2       TEXT   NULL,
	totalscore_frist    TEXT  NULL,
	totalscore_final   TEXT  NULL,
	credit       TEXT  NULL,
	time		TEXT	NULL,
	PRIMARY KEY(telephone)
);


