CREATE TABLE public.userinfo (
    id int4 GENERATED ALWAYS AS IDENTITY (
        INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE
    ) NOT NULL,
    username varchar(25) NOT NULL,
    "password" varchar(255) NOT NULL,
    usertype int4 NOT NULL,
    compid int4 NOT NULL,
    CONSTRAINT userinfo_pkey PRIMARY KEY (id)
);

CREATE TABLE public.userroles (
    roleid serial4 NOT NULL,
    rolename varchar(100) NOT NULL,
    eventtypeid int4 NULL,
    description text NULL,
    CONSTRAINT userroles_pkey PRIMARY KEY (roleid)
);

INSERT INTO
    public.userroles (RoleName, EventTypeID, Description)
VALUES
    -- 2W Racing Roles
    (
        'Race Organizer',
        1,
        'Responsible for organizing 2W racing events.'
    ),
    (
        'Race Marshal',
        1,
        'Ensures safety and compliance during the race.'
    ),
    (
        'Scrutiny',
        1,
        'Checks vehicles for compliance with regulations.'
    ),
    (
        'Timekeeper',
        1,
        'Manages timing and scoring for the race.'
    ),
    ('Rider', 1, 'Participant in the 2W racing event.'),
    -- 4W Racing Roles
    (
        'Race Organizer',
        2,
        'Responsible for organizing 4W racing events.'
    ),
    (
        'Race Marshal',
        2,
        'Ensures safety and compliance during the race.'
    ),
    (
        'Scrutiny',
        2,
        'Checks vehicles for compliance with regulations.'
    ),
    (
        'Timekeeper',
        2,
        'Manages timing and scoring for the race.'
    ),
    (
        'Driver',
        2,
        'Participant in the 4W racing event.'
    );

CREATE TABLE public.eventtypes (
    EventTypeID SERIAL PRIMARY KEY, -- Auto-incremented ID for each type
    EventTypeName VARCHAR(255) NOT NULL -- Name of the event type
);

INSERT INTO
    public.eventtypes (EventTypeName)
VALUES
    ('2W Prescriptions/Regulations'),
    ('4W Prescriptions/Regulations'),
    ('Karting'),
    ('Grass Roots'),
    ('ESPORTS'),
    ('Leisure & Tourism'),
    ('Recommended Reading'),
    (
        'Environmental Policy & Sustainability Guidelines'
    ),
    ('Anti Harassment');

CREATE TABLE public.category (
    CategoryID SERIAL PRIMARY KEY, -- Unique identifier for each category
    EventTypeID INT NOT NULL, -- Foreign key to the EventTypes table
    CategoryName VARCHAR(255) NOT NULL, -- Name of the category
    FOREIGN KEY (EventTypeID) REFERENCES EventTypes (EventTypeID) -- Ensures valid EventTypeID
);

INSERT INTO
    public.category (EventTypeID, CategoryName)
VALUES
    (1, '2W Racing'),
    (1, '2W Stage Rally'),
    (1, '2W Sprint Rally'),
    (1, '2W Supercross / Motocross / Dirt Track'),
    (1, '2W Drag Racing'),
    (1, '2W Hill Climb'),
    (1, '2W TSD Rally');

INSERT INTO
    public.category (EventTypeID, CategoryName)
VALUES
    (2, '4W Racing'),
    (2, '4W Rally'),
    (2, '4W TSD Rally'),
    (2, '4W Rally Sprint'),
    (2, '4W Cross Country Rally'),
    (2, '4W Drag Racing'),
    (2, '4W Hill Climb Racing'),
    (2, '4W Auto Cross'),
    (2, '4W Time Attack'),
    (2, '4W Autokhana'),
    (2, 'Cross Cars');

INSERT INTO
    public.category (EventTypeID, CategoryName)
VALUES
    (4, '4W OpenKhana'),
    (4, '4W Drivedash'),
    (4, 'Karting Slalom'),
    (4, 'Karting Speedster'),
    (4, '2W Ride Rush'),
    (4, 'Grassrooots TSD'),
    (4, 'Karting Slalom');
