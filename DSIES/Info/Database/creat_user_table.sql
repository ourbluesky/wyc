CREATE TABLE admin (
	telphone        TEXT NOT NULL UNIQUE,
	name			TEXT NOT NULL, 
	password		TEXT NOT NULL,
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
	left_sight      TEXT NOT NULL,
	right_sight		TEXT NOT NULL,
	left_deep_sight   TEXT NOT NULL,
	right_deep_sight   TEXT NOT NULL,
	reagency     TEXT NOT NULL,
	score        INTEGER NOT NULL,
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


