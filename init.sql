CREATE TABLE public.userinfo (
    id int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
    username varchar(25) NOT NULL,
    "password" varchar(255) NOT NULL,
    usertype int4 NOT NULL,
    compid int4 NOT NULL,
    CONSTRAINT userinfo_pkey PRIMARY KEY (id)
);
