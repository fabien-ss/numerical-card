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
-- Name: banque; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.banque (
    id_banque integer NOT NULL,
    banque_name character varying(255) NOT NULL
);


ALTER TABLE public.banque OWNER TO postgres;

--
-- Name: banque_id_banque_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.banque_id_banque_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.banque_id_banque_seq OWNER TO postgres;

--
-- Name: banque_id_banque_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.banque_id_banque_seq OWNED BY public.banque.id_banque;


--
-- Name: input_money; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.input_money (
    cin character varying(12) NOT NULL,
    money_value double precision NOT NULL,
    date_input timestamp without time zone DEFAULT now(),
    id_banque integer
);


ALTER TABLE public.input_money OWNER TO postgres;

--
-- Name: output_money; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.output_money (
    cin character varying(12) NOT NULL,
    money_value double precision NOT NULL,
    date_output timestamp without time zone DEFAULT now(),
    id_banque integer
);


ALTER TABLE public.output_money OWNER TO postgres;

--
-- Name: seq_banque; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.seq_banque
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.seq_banque OWNER TO postgres;

--
-- Name: user_total_input; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.user_total_input AS
 SELECT sum(input_money.money_value) AS money_value,
    input_money.cin,
    input_money.id_banque
   FROM public.input_money
  GROUP BY input_money.cin, input_money.id_banque;


ALTER TABLE public.user_total_input OWNER TO postgres;

--
-- Name: user_total_output; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.user_total_output AS
 SELECT sum(output_money.money_value) AS money_value,
    output_money.cin,
    output_money.id_banque
   FROM public.output_money
  GROUP BY output_money.cin, output_money.id_banque;


ALTER TABLE public.user_total_output OWNER TO postgres;

--
-- Name: userbanque; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.userbanque (
    id_banque integer,
    cin character varying(255)
);


ALTER TABLE public.userbanque OWNER TO postgres;

--
-- Name: v_money; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_money AS
 SELECT (i.money_value - o.money_value) AS money_total,
    i.id_banque,
    b.banque_name,
    i.cin
   FROM ((public.user_total_input i
     JOIN public.user_total_output o ON (((i.cin)::text = (o.cin)::text)))
     JOIN public.banque b ON ((i.id_banque = b.id_banque)))
  GROUP BY i.id_banque, i.money_value, o.money_value, i.cin, b.banque_name;


ALTER TABLE public.v_money OWNER TO postgres;

--
-- Name: v_transaction; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_transaction AS
 SELECT input_money.cin,
    input_money.money_value,
    input_money.date_input,
    input_money.id_banque
   FROM public.input_money
UNION
 SELECT output_money.cin,
    output_money.money_value,
    output_money.date_output AS date_input,
    output_money.id_banque
   FROM public.output_money;


ALTER TABLE public.v_transaction OWNER TO postgres;

--
-- Name: v_user_banque; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_user_banque AS
 SELECT ub.cin,
    b.banque_name,
    b.id_banque
   FROM (public.banque b
     JOIN public.userbanque ub ON ((b.id_banque = ub.id_banque)));


ALTER TABLE public.v_user_banque OWNER TO postgres;

--
-- Name: banque id_banque; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.banque ALTER COLUMN id_banque SET DEFAULT nextval('public.banque_id_banque_seq'::regclass);


--
-- Data for Name: banque; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.banque (id_banque, banque_name) FROM stdin;
2	BOI
3	AOC
\.


--
-- Data for Name: input_money; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.input_money (cin, money_value, date_input, id_banque) FROM stdin;
000000000001	90000	2023-10-17 07:47:50.715583	2
000000000002	0	2023-10-17 07:47:50.724914	2
000000000002	80100	2023-10-17 07:48:26.598229	2
000000000001	0	2023-10-17 07:48:26.700616	2
000000000001	48900	2023-10-17 08:31:07.451371	2
000000000002	0	2023-10-17 08:31:07.673596	2
000000000001	22250	2023-10-22 17:43:25.545454	2
000000000002	0	2023-10-22 17:43:25.658945	2
000000000002	22250	2023-10-22 18:24:58.716854	2
000000000001	0	2023-10-22 18:24:58.937901	2
000000000001	4450	2023-10-22 18:28:05.482743	2
000000000002	0	2023-10-22 18:28:05.712671	2
\.


--
-- Data for Name: output_money; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.output_money (cin, money_value, date_output, id_banque) FROM stdin;
000000000001	0	2023-10-17 07:47:50.722181	2
000000000002	0	2023-10-17 07:47:51.169711	2
000000000002	0	2023-10-17 07:48:26.63254	2
000000000001	88740	2023-10-17 07:48:26.666677	2
000000000001	0	2023-10-17 08:31:07.536204	2
000000000002	51500	2023-10-17 08:31:07.605143	2
000000000001	0	2023-10-22 17:43:25.589574	2
000000000002	24650	2023-10-22 17:43:25.624886	2
000000000002	0	2023-10-22 18:24:58.801305	2
000000000001	24650	2023-10-22 18:24:58.874572	2
000000000001	0	2023-10-22 18:28:05.563505	2
000000000002	4930	2023-10-22 18:28:05.635802	2
\.


--
-- Data for Name: userbanque; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.userbanque (id_banque, cin) FROM stdin;
2	000000000002
2	000000000001
3	000000000002
3	000000000001
2	000000000003
3	000000000003
\.


--
-- Name: banque_id_banque_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.banque_id_banque_seq', 3, true);


--
-- Name: seq_banque; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.seq_banque', 1, true);


--
-- Name: banque banque_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.banque
    ADD CONSTRAINT banque_pkey PRIMARY KEY (id_banque);


--
-- Name: input_money input_money_id_banque_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.input_money
    ADD CONSTRAINT input_money_id_banque_fkey FOREIGN KEY (id_banque) REFERENCES public.banque(id_banque);


--
-- Name: output_money output_money_id_banque_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.output_money
    ADD CONSTRAINT output_money_id_banque_fkey FOREIGN KEY (id_banque) REFERENCES public.banque(id_banque);


--
-- PostgreSQL database dump complete
--

