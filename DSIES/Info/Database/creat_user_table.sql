CREATE TABLE admin (
	telphone        TEXT NOT NULL UNIQUE,
	name			TEXT NOT NULL, 
	password		TEXT NOT NULL,
	grantUserName   TEXT NOT NULL,
	regDate			TIMESTAMP NOT NULL DEFAULT (datetime('now','localtime')),
	lastDate		TIMESTAMP NOT NULL DEFAULT (datetime('now','localtime')),
	PRIMARY KEY(telphone)
);

CREATE TABLE regular (
	telphone    TEXT NOT NULL UNIQUE,
	name		TEXT NOT NULL ,
	password	TEXT,
	regDate		TIMESTAMP NOT NULL DEFAULT (datetime('now','localtime')),
	lastDate	TIMESTAMP NOT NULL DEFAULT (datetime('now','localtime')),
	gender		TEXT NOT NULL,
	age			INTEGER NOT NULL,
	driAge		INTEGER NOT NULL,
	career		TEXT NOT NULL,
	accident_times  TEXT NOT NULL,
	sight_left     TEXT NOT NULL,
	sight_right 	TEXT NOT NULL,
	deep_sight_left   TEXT NOT NULL,
	deep_sight_right   TEXT NOT NULL,
	reagency     TEXT NOT NULL,
	grade        TEXT NOT NULL,
	score1       INTEGER NOT NULL,
	grade1       TEXT NOT NULL,
	score2       INTEGER NOT NULL,  
	grade2       TEXT NOT NULL,
	totalscore_frist    INTEGER NOT NULL,
	totalscore_final   INTEGER NOT NULL,
	credit       TEXT NOT NULL,
	PRIMARY KEY(telphone)
);


