-- Check and create the 'userinfo' table if it does not exist
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM information_schema.tables 
        WHERE table_name = 'userinfo'
    ) THEN
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
    END IF;
END $$;

-- Check and create the 'userroles' table if it does not exist
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM information_schema.tables 
        WHERE table_name = 'userroles'
    ) THEN
        CREATE TABLE public.userroles (
            roleid serial4 NOT NULL,
            rolename varchar(100) NOT NULL,
            eventtypeid int4 NULL,
            description text NULL,
            CONSTRAINT userroles_pkey PRIMARY KEY (roleid)
        );
    END IF;
END $$;

-- Insert roles into 'userroles' if not already present
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM public.userroles 
        WHERE rolename = 'Race Organizer' AND eventtypeid = 1
    ) THEN
        INSERT INTO public.userroles (RoleName, EventTypeID, Description)
        VALUES
            ('Race Organizer', 1, 'Responsible for organizing 2W racing events.'),
            ('Race Marshal', 1, 'Ensures safety and compliance during the race.'),
            ('Scrutiny', 1, 'Checks vehicles for compliance with regulations.'),
            ('Timekeeper', 1, 'Manages timing and scoring for the race.'),
            ('Rider', 1, 'Participant in the 2W racing event.');
    END IF;

    IF NOT EXISTS (
        SELECT 1 
        FROM public.userroles 
        WHERE rolename = 'Race Organizer' AND eventtypeid = 2
    ) THEN
        INSERT INTO public.userroles (RoleName, EventTypeID, Description)
        VALUES
            ('Race Organizer', 2, 'Responsible for organizing 4W racing events.'),
            ('Race Marshal', 2, 'Ensures safety and compliance during the race.'),
            ('Scrutiny', 2, 'Checks vehicles for compliance with regulations.'),
            ('Timekeeper', 2, 'Manages timing and scoring for the race.'),
            ('Driver', 2, 'Participant in the 4W racing event.');
    END IF;
END $$;

-- Check and create the 'eventtypes' table if it does not exist
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM information_schema.tables 
        WHERE table_name = 'eventtypes'
    ) THEN
        CREATE TABLE public.eventtypes (
            EventTypeID SERIAL PRIMARY KEY, 
            EventTypeName VARCHAR(255) NOT NULL
        );
    END IF;
END $$;

-- Insert event types into 'eventtypes' if not already present
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM public.eventtypes 
        WHERE EventTypeName = '2W Prescriptions/Regulations'
    ) THEN
        INSERT INTO public.eventtypes (EventTypeName)
        VALUES
            ('2W Prescriptions/Regulations'),
            ('4W Prescriptions/Regulations'),
            ('Karting'),
            ('Grass Roots'),
            ('ESPORTS'),
            ('Leisure & Tourism'),
            ('Recommended Reading'),
            ('Environmental Policy & Sustainability Guidelines'),
            ('Anti Harassment');
    END IF;
END $$;

-- Check and create the 'category' table if it does not exist
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM information_schema.tables 
        WHERE table_name = 'category'
    ) THEN
        CREATE TABLE public.category (
            CategoryID SERIAL PRIMARY KEY, 
            EventTypeID INT NOT NULL, 
            CategoryName VARCHAR(255) NOT NULL, 
            FOREIGN KEY (EventTypeID) REFERENCES EventTypes (EventTypeID)
        );
    END IF;
END $$;

-- Insert categories into 'category' if not already present
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM public.category 
        WHERE CategoryName = '2W Racing' AND EventTypeID = 1
    ) THEN
        INSERT INTO public.category (EventTypeID, CategoryName)
        VALUES
            (1, '2W Racing'),
            (1, '2W Stage Rally'),
            (1, '2W Sprint Rally'),
            (1, '2W Supercross / Motocross / Dirt Track'),
            (1, '2W Drag Racing'),
            (1, '2W Hill Climb'),
            (1, '2W TSD Rally');
    END IF;

    IF NOT EXISTS (
        SELECT 1 
        FROM public.category 
        WHERE CategoryName = '4W Racing' AND EventTypeID = 2
    ) THEN
        INSERT INTO public.category (EventTypeID, CategoryName)
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
    END IF;
END $$;
