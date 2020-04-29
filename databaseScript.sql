create table app_users (
	id serial PRIMARY KEY,  
	created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
	token varchar(100) unique,
	password varchar(30),
	username varchar (30) unique,
	email varchar(30),
	is_super_user boolean,
	is_email_verified boolean
);


create table rooms (
	out_of_order boolean,
	id serial PRIMARY KEY,
	created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
	amount_of_beds integer,
	img text
);


create table reservations (
	id serial PRIMARY KEY,  
	user_id integer,
	checkIndate TIMESTAMP,
	roomno integer,
	created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (roomno) REFERENCES rooms(id) ON UPDATE CASCADE,
	FOREIGN KEY (user_id) REFERENCES app_users(id) ON UPDATE CASCADE,
	time_from TIMESTAMP WITH TIME ZONE,
	time_till TIMESTAMP WITH TIME ZONE,
	price decimal(12,2),
	accepted_by_super_user boolean
);




create table contact_information_owner(
	house_nickname varchar(30) not null CHECK (house_nickname <> ''),
	place varchar(30) not null  CHECK (place <> ''),
	address varchar(50) not null  CHECK (address <> ''),
	postal_code varchar(30) not null  CHECK (postal_code <> ''),
	
	family_name varchar(30) not null  CHECK (family_name <> ''),
	telephone varchar(30) not null  CHECK (telephone <> ''),
	mail varchar(30) not null  CHECK (mail <> ''),
	
	id serial PRIMARY KEY, 
	created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

insert into contact_information_owner(house_nickname, place, address, postal_code , family_name, telephone, mail) values(
	'Le Chantemerle',
	'Alphen Aan den Rijn',
	'Burgemeester Visserpark 16',
	'2405 CP',
	'Scheeres',
	'0172 6056 24',
	'info@chantemerle.nl'
		
);

insert into app_users (is_super_user, username, password) values(
	TRUE,
	'admin',
	'the best password in the world'

);



 
