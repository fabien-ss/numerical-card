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

--
-- Name: postgis; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS postgis WITH SCHEMA public;


--
-- Name: EXTENSION postgis; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION postgis IS 'PostGIS geometry and geography spatial types and functions';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: champs_de_terre; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.champs_de_terre (
    id_territory character varying(50),
    geom public.geometry(Polygon,4326)
);


ALTER TABLE public.champs_de_terre OWNER TO postgres;

--
-- Name: courdechange; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.courdechange (
    id_devise integer,
    montant double precision,
    date_change timestamp without time zone,
    tauxvente double precision
);


ALTER TABLE public.courdechange OWNER TO postgres;

--
-- Name: devise; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.devise (
    id_devise integer NOT NULL,
    nom character varying(500),
    symbole character varying(2)
);


ALTER TABLE public.devise OWNER TO postgres;

--
-- Name: devise_id_devise_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.devise_id_devise_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.devise_id_devise_seq OWNER TO postgres;

--
-- Name: devise_id_devise_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.devise_id_devise_seq OWNED BY public.devise.id_devise;


--
-- Name: territory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.territory (
    cin character varying(12) NOT NULL,
    adress_local character varying(255) NOT NULL,
    longueur integer,
    largeur integer,
    description character varying(255),
    titre character varying(255) NOT NULL,
    id_territory character varying(50) NOT NULL,
    surface double precision,
    perimetre double precision
);


ALTER TABLE public.territory OWNER TO postgres;

--
-- Name: territory_id_territory_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.territory_id_territory_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.territory_id_territory_seq OWNER TO postgres;

--
-- Name: territory_id_territory_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.territory_id_territory_seq OWNED BY public.territory.id_territory;


--
-- Name: devise id_devise; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.devise ALTER COLUMN id_devise SET DEFAULT nextval('public.devise_id_devise_seq'::regclass);


--
-- Name: territory id_territory; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.territory ALTER COLUMN id_territory SET DEFAULT nextval('public.territory_id_territory_seq'::regclass);


--
-- Data for Name: champs_de_terre; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.champs_de_terre (id_territory, geom) FROM stdin;
T000049	0103000020E61000000100000005000000010040187DD647400DBFE271A09F33C00100C0E8A4D64740039D85B7A99F33C00200C083A0D6474019319777CF9F33C00100C0AA79D64740A11FF10AC49F33C0010040187DD647400DBFE271A09F33C0
T000050	0103000020E6100000010000000400000000002400D03F474045666A7246F631C001002400A0E846402D8160E21ED132C00100240080DA4740418B25E1B65032C000002400D03F474045666A7246F631C0
T000051	0103000020E61000000100000004000000000000004CF84540CCE1CF560F8A31C001000000A4F946401A1886DBE7FF31C001000000D4D74740D08EAA1CC46232C0000000004CF84540CCE1CF560F8A31C0
T000052	0103000020E610000001000000050000000000806E8CD64740F93A2DB7909F33C001008047B3D6474043D57F47A09F33C001008026A7D64740C753EBE5D99F33C00100803F7FD64740E993211FB89F33C00000806E8CD64740F93A2DB7909F33C0
T000053	0103000020E6100000010000001200000001000000986D484013CEFB6A018A33C000000000883248406C5FA728B08335C000000000389247408A834E0AB90B39C001000000D8B646405CDA34045FAE39C00100000008004640C71F8556A00639C00100000018B44540224EE90154BC36C000000000B8E645405C3727CCA11535C001000000183B464013CEFB6A018A33C001000000F8F1454047A07C28DE6931C00100000088434640B299E9D9582130C00100000078164740E8FE9AD61AB62FC001000000B8D54740C879F74EFB762DC00100000008EF474013684989F1292BC00100000068704840B104268AC0902AC001000000C897484038A954C017C727C001000000D8FF48402894A8AD31FE2AC000000000884049400B18966FA6862EC001000000986D484013CEFB6A018A33C0
T000054	0103000020E61000000100000004000000010040478AD64740039D85B7A99F33C00200408498D64740B531AEA49B9F33C00100C02C9DD647402785B3A6B39F33C0010040478AD64740039D85B7A99F33C0
T000057	0103000020E6100000010000000700000084471B47ACC547409C6D6E4C4FF832C0992A1895D4C54740FFEC478AC8F832C02E73BA2C26C64740B97020240BF832C02E73BA2C26C64740392861A6EDF732C08369183E22C6474056BC9179E4F732C0E04A766C04C6474047E6913F18F832C084471B47ACC547409C6D6E4C4FF832C0
T000058	0103000020E610000001000000070000000100407F81C547409C4DE33AB9F832C0010040F6A0C54740D71EFF14B2F832C00100C0A9A9C54740ED5C351CE7F832C00100C0D67CC547408CE78794F2F832C00100C05783C54740E6AB8D29D3F832C0010040857BC547402C2A8EB8BCF832C00100407F81C547409C4DE33AB9F832C0
\.


--
-- Data for Name: courdechange; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.courdechange (id_devise, montant, date_change, tauxvente) FROM stdin;
2	1	2023-10-16 06:47:39.628856	2500
1	5000	2023-10-16 06:47:39.628856	2500
1	6000	2023-10-17 02:34:31.47168	2500
1	3000	2023-10-17 02:35:41.025359	2500
1	4930	2023-10-17 07:38:17.134211	4450
2	5150	2023-10-17 07:38:17.134211	4890
\.


--
-- Data for Name: devise; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.devise (id_devise, nom, symbole) FROM stdin;
1	USD	$
2	euro	Ar
\.


--
-- Data for Name: spatial_ref_sys; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.spatial_ref_sys (srid, auth_name, auth_srid, srtext, proj4text) FROM stdin;
\.


--
-- Data for Name: territory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.territory (cin, adress_local, longueur, largeur, description, titre, id_territory, surface, perimetre) FROM stdin;
000000000001	perimetre	10	10	lkhl	lkjlk	T000049	0.00801820531688258	459669.5829306228
000000000001	largeyr	10	10	larg	q	T000051	86.90803374249268	815477.7091888291
000000000001	jhf²	10	10	bjk	f	T000053	603518.5318592303	3704871.008391285
000000000001	Elgeco	10	10	Elgeco	Elgeco	T000057	0.05347164476025477	1153.6440867218748
000000000001	Test	10	10	TEst	TEst	T000050	7472.235365841644	459669.5829306228
000000000001	TEst	10	10	te	TEs	T000052	0.012016800150573253	450.5958634663386
000000000001	sd	10	10	ds	s	T000054	0.0011013979052752257	157.3863261763117
000000000001	TEst	10	10	Tz	DQS	T000058	0.011352334618858992	463.6306688662339
\.


--
-- Name: devise_id_devise_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.devise_id_devise_seq', 2, true);


--
-- Name: territory_id_territory_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.territory_id_territory_seq', 58, true);


--
-- Name: devise devise_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.devise
    ADD CONSTRAINT devise_pkey PRIMARY KEY (id_devise);


--
-- Name: territory territory_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.territory
    ADD CONSTRAINT territory_pkey PRIMARY KEY (id_territory);


--
-- Name: champs_de_terre champs_de_terre_id_territory_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.champs_de_terre
    ADD CONSTRAINT champs_de_terre_id_territory_fkey FOREIGN KEY (id_territory) REFERENCES public.territory(id_territory);


--
-- Name: courdechange courdechange_id_devise_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.courdechange
    ADD CONSTRAINT courdechange_id_devise_fkey FOREIGN KEY (id_devise) REFERENCES public.devise(id_devise);


--
-- PostgreSQL database dump complete
--

