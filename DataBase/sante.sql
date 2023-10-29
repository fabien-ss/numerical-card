--
-- PostgreSQL database dump
--

-- Dumped from database version 12.11
-- Dumped by pg_dump version 12.11

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: civil; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.civil (
    cin character varying(20) NOT NULL,
    nom character varying(255) NOT NULL,
    first_name character varying(255),
    date_of_birth timestamp without time zone NOT NULL,
    place_of_birth character varying(255),
    address_local character varying(255),
    father character varying(255),
    mother character varying(255),
    date_delivery timestamp without time zone NOT NULL
);


ALTER TABLE public.civil OWNER TO postgres;

--
-- Name: disease; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.disease (
    id integer NOT NULL,
    nom character varying(255) NOT NULL
);


ALTER TABLE public.disease OWNER TO postgres;

--
-- Name: disease_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.disease_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.disease_id_seq OWNER TO postgres;

--
-- Name: disease_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.disease_id_seq OWNED BY public.disease.id;


--
-- Name: hospital; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hospital (
    id integer NOT NULL,
    nom character varying(200)
);


ALTER TABLE public.hospital OWNER TO postgres;

--
-- Name: hospital_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hospital_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hospital_id_seq OWNER TO postgres;

--
-- Name: hospital_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hospital_id_seq OWNED BY public.hospital.id;


--
-- Name: person_desease; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.person_desease (
    cin character varying(255),
    id_desease integer,
    date_start timestamp without time zone,
    date_end timestamp without time zone,
    idhopital integer
);


ALTER TABLE public.person_desease OWNER TO postgres;

--
-- Name: table_name; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.table_name (
);


ALTER TABLE public.table_name OWNER TO postgres;

--
-- Name: disease id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.disease ALTER COLUMN id SET DEFAULT nextval('public.disease_id_seq'::regclass);


--
-- Name: hospital id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hospital ALTER COLUMN id SET DEFAULT nextval('public.hospital_id_seq'::regclass);


--
-- Data for Name: civil; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.civil (cin, nom, first_name, date_of_birth, place_of_birth, address_local, father, mother, date_delivery) FROM stdin;
000000000002	RAKETA	Sylvie	1975-09-30 09:46:18	Tsiroanomandidy	Ambohidratrimo	\N	\N	2020-09-23 09:46:55
000000000001	RAKOTO	Jean	1980-12-12 00:00:00	Mantasoa	Ivato K1	\N	\N	2018-01-01 12:12:00
000000000003	RASOA	Maria	2003-12-24 09:47:38	Ambohidratrimo	LA USA	000000000001	000000000002	2021-06-09 09:49:31
\.


--
-- Data for Name: disease; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.disease (id, nom) FROM stdin;
1	Tuberculose
2	Sida
3	VIH
\.


--
-- Data for Name: hospital; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hospital (id, nom) FROM stdin;
1	Popota
2	TaTata
3	Kakaka
4	CSBII Ankazomanga
\.


--
-- Data for Name: person_desease; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.person_desease (cin, id_desease, date_start, date_end, idhopital) FROM stdin;
000000000001	1	2014-11-01 00:00:00	2014-12-03 00:00:00	1
\.


--
-- Data for Name: table_name; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.table_name  FROM stdin;
\.


--
-- Name: disease_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.disease_id_seq', 3, true);


--
-- Name: hospital_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hospital_id_seq', 4, true);


--
-- Name: civil civil_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.civil
    ADD CONSTRAINT civil_pkey PRIMARY KEY (cin);


--
-- Name: disease disease_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.disease
    ADD CONSTRAINT disease_pkey PRIMARY KEY (id);


--
-- Name: hospital hospital_nom_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hospital
    ADD CONSTRAINT hospital_nom_key UNIQUE (nom);


--
-- Name: hospital hospital_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hospital
    ADD CONSTRAINT hospital_pkey PRIMARY KEY (id);


--
-- Name: person_desease person_desease_cin_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.person_desease
    ADD CONSTRAINT person_desease_cin_fkey FOREIGN KEY (cin) REFERENCES public.civil(cin);


--
-- Name: person_desease person_desease_id_desease_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.person_desease
    ADD CONSTRAINT person_desease_id_desease_fkey FOREIGN KEY (id_desease) REFERENCES public.disease(id);


--
-- Name: person_desease person_desease_idhopital_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.person_desease
    ADD CONSTRAINT person_desease_idhopital_fkey FOREIGN KEY (idhopital) REFERENCES public.hospital(id);


--
-- PostgreSQL database dump complete
--

