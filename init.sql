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

-- Check and create the 'authenticationroles' table if it does not exist
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM information_schema.tables 
        WHERE table_name = 'authenticationroles'
    ) THEN
        CREATE TABLE public.authenticationroles (
            roleid INT PRIMARY KEY, -- Enum ID as Primary Key
            rolename VARCHAR(50) NOT NULL -- Enum Name
        );
    END IF;
END $$;

-- Insert the enum values into 'authenticationroles' table if they do not already exist
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM public.authenticationroles WHERE roleid = 1
    ) THEN
        INSERT INTO public.authenticationroles (roleid, rolename) 
        VALUES 
            (1, 'SuperAdmin'),
            (2, 'Admin'),
            (3, 'Register'),
            (4, 'Account'),
            (5, 'Scrutiny');
    END IF;
END $$;


DO $$
BEGIN
CREATE TABLE public.eventregistration (
	eventid int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	eventtype text NOT NULL,
	eventname varchar(255) NOT NULL,
	startdate timestamptz NOT NULL,
	enddate timestamptz NOT NULL,
	isactive text NOT NULL,
	"Banner" text NOT NULL,
	showdashboard text NOT NULL,
	eventstatus int4 NULL,
	bankname varchar(100) NOT NULL,
	ifsccode varchar(20) NOT NULL,
	accountname varchar(100) NOT NULL,
	"QRpath" varchar(1000) NOT NULL,
	CONSTRAINT eventregistration_pkey PRIMARY KEY (eventid)
);
END $$;

DO $$
BEGIN
CREATE TABLE public.eventcategory (
	evt_cat_id serial4 NOT NULL,
	evt_category text NULL,
	"noOfVeh" int4 NULL,
	status varchar(100) NULL,
	nooflaps int4 NOT NULL,
	entryprice int4 NULL,
	wheelertype int4 NULL,
	event_id int4 NULL,
	CONSTRAINT eventcategory_pkey PRIMARY KEY (evt_cat_id)
);


-- public.eventcategory foreign keys

ALTER TABLE public.eventcategory ADD CONSTRAINT eventcategory_eventregistration_fk FOREIGN KEY (event_id) REFERENCES public.eventregistration(eventid);
END $$;

DO $$
BEGIN
CREATE TABLE public.scrutinyrules (
	scrutiny_id int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	scrutiny_description varchar NOT NULL
);
END $$;

DO $$
BEGIN
INSERT INTO public.scrutinyrules (scrutiny_description) VALUES
-- Technical Inspection
('Engine must comply with the displacement limits set by the competition.'),
('No unauthorized engine modifications allowed.'),
('Exhaust systems must meet noise and emission regulations.'),
('Turbochargers or superchargers must be within the permitted specifications.'),
('Fuel injectors and carburetors must follow event regulations.'),
('Transmission system must be in good working condition.'),
('Drivetrain components must be securely installed.'),
('Battery must be properly secured with an insulated cover.'),
('Alternator must be functioning properly to ensure continuous power supply.'),
('Starter motor must operate efficiently.'),

-- Safety Inspection
('Driver must wear a certified racing helmet.'),
('Fire-resistant racing suits are mandatory.'),
('Gloves, shoes, and other protective gear must meet FIA standards.'),
('Seat belts and harnesses must be properly fastened.'),
('Roll cages must be FIA-approved and securely installed.'),
('No loose objects allowed inside the car.'),
('All fluid lines must be securely fastened to prevent leaks.'),
('Fire extinguishers must be installed within driver’s reach.'),
('All safety equipment must be checked before every race.'),
('Emergency kill switch must be operational.'),

-- Performance and Handling
('Steering components must be free of excessive play.'),
('Suspension must meet event regulations.'),
('Brakes must be fully functional with no leaks.'),
('Brake pads must have sufficient thickness.'),
('Handbrake must be functional.'),
('Wheel bearings must be in good condition.'),
('Shock absorbers must be functioning properly.'),
('Wheels and tires must meet event specifications.'),
('Tire tread depth must comply with event rules.'),
('Wheel lug nuts must be properly torqued.'),

-- Compliance and Regulations
('All vehicles must have a visible race number.'),
('Sponsor decals must be placed according to guidelines.'),
('Only approved fuel is permitted.'),
('Fuel tanks must be securely mounted.'),
('No leaking fluids are allowed.'),
('No external modifications that alter the car’s aerodynamic properties are allowed.'),
('Weight distribution must comply with race regulations.'),
('Drivers must be registered with the race organization.'),
('Pit crew members must wear proper safety gear.'),
('Only designated personnel are allowed in the pit area.'),

-- Race Conduct and Ethics
('No illegal blocking or intentional contact is allowed.'),
('Overtaking must be done in a safe manner.'),
('Blue flag means a driver must allow faster cars to pass.'),
('No dangerous weaving or erratic driving.'),
('No shortcuts or cutting corners.'),
('Yellow flag indicates a caution period; no overtaking allowed.'),
('Red flag means the race is stopped; drivers must return to the pit lane.'),
('Drivers must obey all race marshals’ instructions.'),
('Failure to adhere to track limits will result in penalties.'),
('Ignoring black flag warnings can lead to disqualification.'),

-- Additional Technical Rules
('Rearview mirrors must provide adequate visibility.'),
('Headlights, if required, must be functional.'),
('Brake lights must be operational.'),
('Horn, if required, must be working.'),
('No excessive fluid leaks from the vehicle.'),
('Radiator must be securely mounted and not leaking.'),
('Fuel lines must be properly routed and secured.'),
('Throttle return springs must be functioning properly.'),
('Battery terminals must be properly insulated.'),
('Wiring must be properly routed to prevent fire hazards.'),

-- Additional Safety Rules
('HANS (Head and Neck Support) devices are mandatory.'),
('Windows must be securely closed or have proper window nets.'),
('Side impact protection must be in place.'),
('Helmet straps must be fastened at all times.'),
('In-car cameras must be securely mounted.'),
('Driver’s seat must be securely bolted to the chassis.'),
('No loose wires or dangling components inside the cockpit.'),
('Fire-resistant underwear is recommended.'),
('Gloves must be free from excessive wear or damage.'),
('Windshield must be free from cracks that could obstruct vision.'),

-- Additional Compliance Rules
('Each team must attend the pre-race driver’s briefing.'),
('Only approved modifications are allowed for specific racing classes.'),
('Pit lane speed limits must be followed at all times.'),
('Refueling procedures must follow event regulations.'),
('Noise levels must not exceed event limits.'),
('Drivers must adhere to weight requirements.'),
('All cars must undergo a post-race inspection.'),
('Teams must declare tire compounds before the race.'),
('Car numbers must be displayed on both sides of the vehicle.'),
('No additional ballast weights are allowed unless specified.'),

-- Additional Race Conduct Rules
('Intentional collisions will result in immediate disqualification.'),
('No unsportsmanlike behavior towards other drivers.'),
('Failure to respect track boundaries will lead to time penalties.'),
('Ignoring safety car procedures will result in penalties.'),
('Pit stops must be conducted within the designated area.'),
('Drivers must maintain a safe distance from competitors.'),
('Overtaking under caution is strictly prohibited.'),
('Jump starts will result in penalties.'),
('Intentional stalling or delaying tactics will not be tolerated.'),
('Failure to attend post-race interviews when required may result in fines.');
END $$;



ALTER TABLE public.registration ALTER COLUMN reference_no DROP NOT NULL;


ALTER TABLE scrutinyrules RENAME COLUMN scrutiny_id TO scrutinyrules_id;


ALTER TABLE scrutinyrules
ADD CONSTRAINT scrutinyrules_id UNIQUE (scrutinyrules_id);


ALTER TABLE registration 
ADD COLUMN scrutiny CHAR(1) CHECK (scrutiny IN ('Y', 'N')),
ADD COLUMN scrutiny_updated_date DATE,
ADD COLUMN scrutineer_id INT,
ADD COLUMN status varchar ; -- 0: pending, 1: passed, 2: failed

CREATE TABLE scrutineer (
    scrutineer_id INT PRIMARY KEY,
    scrutineer_name VARCHAR(255) NOT NULL
);



CREATE TABLE scrutineydetails (
    scrutineydetails_id INT PRIMARY KEY ,
    scrutineyrule_id INT,
    status varchar,  -- 0: pending, 1: passed, 2: failed, 3: n/a
    comment TEXT,
    reg_id INT,
    FOREIGN KEY (scrutineyrule_id) REFERENCES scrutinyrules(scrutinyrules_id),
    FOREIGN KEY (reg_id) REFERENCES registration(reg_id)
);


ALTER TABLE company RENAME TO companydetails;


