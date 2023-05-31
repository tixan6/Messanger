PGDMP     .                     {            alpgore    10.23    15.2 (    (           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            )           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            *           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            +           1262    49179    alpgore    DATABASE     |   CREATE DATABASE alpgore WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Belarus.1251';
    DROP DATABASE alpgore;
                postgres    false                        2615    2200    public    SCHEMA     2   -- *not* creating schema, since initdb creates it
 2   -- *not* dropping schema, since initdb creates it
                postgres    false            ,           0    0    SCHEMA public    ACL     Q   REVOKE USAGE ON SCHEMA public FROM PUBLIC;
GRANT ALL ON SCHEMA public TO PUBLIC;
                   postgres    false    6            �            1259    49182 	   Equipment    TABLE     }  CREATE TABLE public."Equipment" (
    id integer NOT NULL,
    name character varying(250) NOT NULL,
    descriptions text NOT NULL,
    photo text NOT NULL,
    made character varying(250) NOT NULL,
    material character varying(250) NOT NULL,
    weigth character varying(100) NOT NULL,
    instock boolean NOT NULL,
    type character varying(250) NOT NULL,
    price money
);
    DROP TABLE public."Equipment";
       public            postgres    false    6            -           0    0    TABLE "Equipment"    COMMENT     Z   COMMENT ON TABLE public."Equipment" IS 'Альпинистское снаряжение';
          public          postgres    false    197            �            1259    49180    Equipment_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Equipment_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public."Equipment_id_seq";
       public          postgres    false    6    197            .           0    0    Equipment_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Equipment_id_seq" OWNED BY public."Equipment".id;
          public          postgres    false    196            �            1259    49192    Bags    TABLE     �  CREATE TABLE public."Bags" (
    id integer DEFAULT nextval('public."Equipment_id_seq"'::regclass) NOT NULL,
    name character varying(250) NOT NULL,
    descriptions text NOT NULL,
    photo text NOT NULL,
    made character varying(250) NOT NULL,
    material character varying(250) NOT NULL,
    weigth character varying(250) NOT NULL,
    instock boolean NOT NULL,
    type character varying(250) NOT NULL,
    price money NOT NULL
);
    DROP TABLE public."Bags";
       public            postgres    false    196    6            /           0    0    TABLE "Bags"    COMMENT     4   COMMENT ON TABLE public."Bags" IS 'Рюкзаки';
          public          postgres    false    198            �            1259    49344    Order    TABLE     E  CREATE TABLE public."Order" (
    id integer DEFAULT nextval('public."Equipment_id_seq"'::regclass) NOT NULL,
    name character varying(250) NOT NULL,
    surname character varying(250) NOT NULL,
    phone character varying(250) NOT NULL,
    photo text NOT NULL,
    name_product text NOT NULL,
    price money NOT NULL
);
    DROP TABLE public."Order";
       public            postgres    false    196    6            �            1259    49208    Tents    TABLE     �  CREATE TABLE public."Tents" (
    id integer DEFAULT nextval('public."Equipment_id_seq"'::regclass) NOT NULL,
    name character varying(250) NOT NULL,
    descriptions text NOT NULL,
    photo text NOT NULL,
    made character varying NOT NULL,
    material character varying NOT NULL,
    weigth character varying NOT NULL,
    instock boolean NOT NULL,
    type character varying NOT NULL,
    price money NOT NULL
);
    DROP TABLE public."Tents";
       public            postgres    false    196    6            �            1259    49241 	   discount     TABLE     �   CREATE TABLE public."discount " (
    id integer DEFAULT nextval('public."Equipment_id_seq"'::regclass) NOT NULL,
    "id-b" integer,
    "id-e" integer,
    "id-t" integer,
    "id-l" integer,
    new_price money NOT NULL
);
    DROP TABLE public."discount ";
       public            postgres    false    196    6            0           0    0    TABLE "discount "    COMMENT     :   COMMENT ON TABLE public."discount " IS 'скидки!!!';
          public          postgres    false    201            �            1259    49217    light    TABLE     �  CREATE TABLE public.light (
    id integer DEFAULT nextval('public."Equipment_id_seq"'::regclass) NOT NULL,
    name character varying(250) NOT NULL,
    descriptions text NOT NULL,
    photo text NOT NULL,
    made character varying(250) NOT NULL,
    material character varying(250) NOT NULL,
    weigth character varying(250) NOT NULL,
    instock boolean NOT NULL,
    type character varying(250) NOT NULL,
    price money NOT NULL
);
    DROP TABLE public.light;
       public            postgres    false    196    6            1           0    0    TABLE light    COMMENT     D   COMMENT ON TABLE public.light IS 'Налобные светило';
          public          postgres    false    200            �            1259    49269    users    TABLE       CREATE TABLE public.users (
    id integer DEFAULT nextval('public."Equipment_id_seq"'::regclass) NOT NULL,
    name character varying(250) NOT NULL,
    surname character varying(250) NOT NULL,
    phone character varying(250) NOT NULL,
    password character varying(250) NOT NULL
);
    DROP TABLE public.users;
       public            postgres    false    196    6            2           0    0    TABLE users    COMMENT     =   COMMENT ON TABLE public.users IS 'Пользователи';
          public          postgres    false    202            �
           2604    49185    Equipment id    DEFAULT     p   ALTER TABLE ONLY public."Equipment" ALTER COLUMN id SET DEFAULT nextval('public."Equipment_id_seq"'::regclass);
 =   ALTER TABLE public."Equipment" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    197    196    197                       0    49192    Bags 
   TABLE DATA           m   COPY public."Bags" (id, name, descriptions, photo, made, material, weigth, instock, type, price) FROM stdin;
    public          postgres    false    198   �/                 0    49182 	   Equipment 
   TABLE DATA           r   COPY public."Equipment" (id, name, descriptions, photo, made, material, weigth, instock, type, price) FROM stdin;
    public          postgres    false    197   9       %          0    49344    Order 
   TABLE DATA           W   COPY public."Order" (id, name, surname, phone, photo, name_product, price) FROM stdin;
    public          postgres    false    203   �I       !          0    49208    Tents 
   TABLE DATA           n   COPY public."Tents" (id, name, descriptions, photo, made, material, weigth, instock, type, price) FROM stdin;
    public          postgres    false    199   �I       #          0    49241 	   discount  
   TABLE DATA           T   COPY public."discount " (id, "id-b", "id-e", "id-t", "id-l", new_price) FROM stdin;
    public          postgres    false    201   R       "          0    49217    light 
   TABLE DATA           l   COPY public.light (id, name, descriptions, photo, made, material, weigth, instock, type, price) FROM stdin;
    public          postgres    false    200   PR       $          0    49269    users 
   TABLE DATA           C   COPY public.users (id, name, surname, phone, password) FROM stdin;
    public          postgres    false    202   �[       3           0    0    Equipment_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."Equipment_id_seq"', 118, true);
          public          postgres    false    196            �
           2606    49199    Bags Bags_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public."Bags"
    ADD CONSTRAINT "Bags_pkey" PRIMARY KEY (id);
 <   ALTER TABLE ONLY public."Bags" DROP CONSTRAINT "Bags_pkey";
       public            postgres    false    198            �
           2606    49190    Equipment Equipment_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Equipment"
    ADD CONSTRAINT "Equipment_pkey" PRIMARY KEY (id);
 F   ALTER TABLE ONLY public."Equipment" DROP CONSTRAINT "Equipment_pkey";
       public            postgres    false    197            �
           2606    49352    Order Order_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "Order_pkey" PRIMARY KEY (id);
 >   ALTER TABLE ONLY public."Order" DROP CONSTRAINT "Order_pkey";
       public            postgres    false    203            �
           2606    49215    Tents Tents_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Tents"
    ADD CONSTRAINT "Tents_pkey" PRIMARY KEY (id);
 >   ALTER TABLE ONLY public."Tents" DROP CONSTRAINT "Tents_pkey";
       public            postgres    false    199            �
           2606    49248    discount  discount _pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."discount "
    ADD CONSTRAINT "discount _pkey" PRIMARY KEY (id);
 F   ALTER TABLE ONLY public."discount " DROP CONSTRAINT "discount _pkey";
       public            postgres    false    201            �
           2606    49224    light light_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.light
    ADD CONSTRAINT light_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.light DROP CONSTRAINT light_pkey;
       public            postgres    false    200            �
           2606    49276    users users_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    202            �
           2606    49249    discount  fk-b    FK CONSTRAINT     {   ALTER TABLE ONLY public."discount "
    ADD CONSTRAINT "fk-b" FOREIGN KEY ("id-b") REFERENCES public."Bags"(id) NOT VALID;
 <   ALTER TABLE ONLY public."discount " DROP CONSTRAINT "fk-b";
       public          postgres    false    2710    201    198            �
           2606    49254    discount  fk-e    FK CONSTRAINT     �   ALTER TABLE ONLY public."discount "
    ADD CONSTRAINT "fk-e" FOREIGN KEY ("id-e") REFERENCES public."Equipment"(id) NOT VALID;
 <   ALTER TABLE ONLY public."discount " DROP CONSTRAINT "fk-e";
       public          postgres    false    201    2708    197            �
           2606    49264    discount  fk-l    FK CONSTRAINT     z   ALTER TABLE ONLY public."discount "
    ADD CONSTRAINT "fk-l" FOREIGN KEY ("id-l") REFERENCES public.light(id) NOT VALID;
 <   ALTER TABLE ONLY public."discount " DROP CONSTRAINT "fk-l";
       public          postgres    false    2714    200    201            �
           2606    49259    discount  fk-t    FK CONSTRAINT     |   ALTER TABLE ONLY public."discount "
    ADD CONSTRAINT "fk-t" FOREIGN KEY ("id-t") REFERENCES public."Tents"(id) NOT VALID;
 <   ALTER TABLE ONLY public."discount " DROP CONSTRAINT "fk-t";
       public          postgres    false    199    201    2712                9	  x��XMo��]3��-=���C��eϴ8�[e:-sdղ����te��&i&QgZtQfE�i!KV"��@��_�/��x�(Y�eЅ�|���{�=����7�k9��e[��Ê'�;M��pE�-���G�)!�b�2uK��b�m����[;�h�	!��D^��o+x!��J�K9Z|�+/����c��	<w!'���,!�S���9^ʑ�ӊ�4x.��IЂ�G�>k{r?c������)l�~��a���À1"xl2��H�C���<=���ʉx�s������+o���l\B g��V�VC�f���mL^�[�1���+9�t1oCO"ڷ��}z���B��t+�R��sK~����j����4�fM�b�܂�?�ܯ  �H�fu�9Ç�kɌ��u�k<��Ed��X����vHu2c�����N��+��_���B ��:P{-�?������Q�A��od�lw
W���L1��hC0#��[��ae�VҡS���ނ�\�_��~O���W� ;��k���l��N΂���=�U+��bs+�O�ig[����\��+�r��,�3x���l�h��>i���Y��Vn�0l��nL�����.�e��k�'����"`;���R`>�1ӑ��ٴ���_�-�U���_R}�LQk���0���x?��X��p���
3����JP_� �	��E(dsʶ��;~�wޮ�J&��u��9��N���<�P���mk�l�B:,?$�'j*�^���=�]��V}TX�|#$ Z��GBޗ�Y���~/����t灒�s%�J��1v;�����2 w�Ê��x�F�ܨՊ{�'O�F�Z�;nɱ2N���r\��&\O��!h-��* 5���T�	i/���A*�ߦ
�f2�	����K`-J��#h������(+�j����F�&/Y+�fZ2��%���^y���o���t���·�\�PU��z4��L5?ܾ���ء��{5L+Sh�f,F��Y�a��!����i�|������/�R��Me��b�\D�H�YQ�%m�_uq��c���cްL�M&���t���mN��3�ϼZΫ4?u|p
��F�Z�6��r��[0�ɰ���"��7��g���	"���i܈�d~�]~RnT|���}�Z�-�@��Z�y7RfV<�󼦻���j�*nЏ���̮Iqp0a+��@G��CȵIB&�?>h��_��"�`��{҅������R�-�Np�Q�`+�ȅ([�I��7��l�ɭA+��d������>A@@�1�N	AwB����)��%�5`��z4����f��74�g�m��7*X���ځW��ǿ �M��P�J�7�&0* �;@���f(?_�_��u���1K��s��|�M�TIF! �3R�OX�hB�P�>��,x��e��g��V���C�βN�~CțV�9&<���7��X`W4e��D,�w��\��\�(���G�����eg��*�/��:�|TZ���?'	�q�',~	6�y��`�T�tP������P$W�M��]t�;L<� �!A����T�C��uI�p��~���I[8o��h2^/U.�؆R8,W��p�U��ǵ�'�JEX�U������i7�����2�Zס�uN�6����,&�}��Ț~��
�d�I�^nzG�N	�܁��9z���w����c�)���@Z����D��T�s� A� ��X3��\1�ȕ��^j�L�4���H�P�͆�6��H���ۚ��-5'������-\��I�dYpjã��y�c�'�?���B��Ǿ��J w=&�K���!4}�W�G�5hQ9�@]���I8خ9��k,�	��B���t�٘y���:��SA�o�B�Z�c�:|V��4�lrB����I!�#�N
���>%�mA�#!�X�4�Iy��!U>�	�/�S����I�v,rP��Wn��lu��gdC��͜q��t�٠�(���ʌ��DΐĔ�o���]�լ�L��{@M4��XPߠ��<�#v�s��t�~����*?�J}'�H��#.��E���Ԫ�+��.������I��%m�>ם���ʥ���F2��2��[��->T���Fq<���k��ӣ=0��6��:=wJ�I��Hb�q!"�8�!�}�2�>F�V�G^�w+U�G�r6�g�[@�W�ʆ��^���ţ�|8ᾅ�*3���6�5S���^ 6��ϕx��y��}�!|�Etx�1��.�Of\��������5~@:w=�HG^��sP���v/V,kV�!+���t�_�            x��[Yo�~���@n�P�6�:@\q�'��DI,7���IKd��k�A�I�H��M�2E��_0�z�w�/��E�6�e�����,�9WI+�~�6�w�v�7n�{n��n�m�=�I_>͕���Z�H����_����K�ׇޡۧ�����p/ܡ�����xhЯ>?֧����@�j�����'�!�˫�n��3�Ǽ�؇%g+��z۩;�����o����h���t��{��s�����Cvy�v��o��KE��/�
K;存l��=���;��ǂ�зX�J�����f6nܪ^I&�H�S�1>��
7���N�`|`|\��ˆw`�3��s�f�{�=3�4D<[�K����s@R�g���F�uX��Ƀi)�}I�@�M��s��$ۥ���s���P�t�%}��#,�Cz�E_��f9���4�cw��2Q���{�H�	c�i�;�y��1Z��m(�.�\�i�Q��o�v*���J��يA��ܯ��~�^��xlsR��q3%zM�ܯYX��k��@yo�R����*녘��Ff	�]����2�y[=z�DB��>g1�pX�	_��c{OLC��5�XM�?��70�}y��0�8m]����	x��y� <S����+&;Sx,�A6K�����:I����v�f���6���M`��������� ��%v��h�������Ɨ~Z8����n�	�c_M���v�m/Y)����$bJ����~|�ң��0a�	a��!�t�!���.{ ��r;�w�sC����z`�b�<8.O�^��{Gdu�`*���=Ȱ�s\Q�ك@.Ԭpi'�+�h�!������C�}�k��Us�Ǯ՝z~};W�W�*;U2�2�իNa���߰��]*Q��K��������#Pqp���B`/wD[~J��wIl��RcV�=���c)u�Q'���ܗ���4�+�Ar�����Y
e?@�-�����|Io""�J�y�@��+nu ]��pyL�Ϣɗ5 ��)��b�ڣh�	Ⱦ1���F�y|p���X�s�!�/
�!�w\=d3�۲���� �z�ғ+P:��Ѓ�:=?���V	���C�1����^���H �����o)^x�3Sb�9-B�W�E�F$��u�������r�C8V(���Xa���8P��@��f��%-���C�^ ��S j�?�{��!9����0���4�2p�4�tf��C9]�.�+[��F�P��+e�X�۳wX��0�ۊ�z��?BX�3`�J�������V���+Y3#.!5�q�m��OsU��S�x��9�؈[q�$/��6��6��(�ΚJNc�1E�#�7�=���4G�TJ�y������c�+���>�<N�.#. �jܪ66ʕ=�o�]�V���f�iyD 㰉�$��`����,�	�o"� �(Z����aܱ����02��3��#n�W\SL-B�~�Ѕ��\��-a�CK�Fax��E�Up��Z^����v*�ʖS��#_�!����v�әR��&Rfz��������Z�nA��$FH�}{�,|OQ�L:0.��S�4o߼{o�q��t�M�Q�}����H~�
�^�=��/��!����WQ&���tv����'A]�р�(��afst����PB$��:�B�H(6�⒤'��G�Y�J�+���� 	Rr�NI��R:���0��iL��	 KS9�(�%�u$tM܃xy�%]������{2�=m��(��;R�(D(�%FD/0�f�'Ɔ첹`�a1�_q �FV2�r�4�Lo֋NM ��#�y~\��JwG�*=҇Z~I^��д'[m�:�qR���BnJZ��ETMB	�Gк$=����F��#3������P,Q�h�z�
�4���u��:,Ha�5��جS4��]Y���錙��C<�I�MDv��������u~��(��b�H��aF���RrrX5CIi�t�o%�a�5w�Z�m��/�욬��� �GZ�h'��6��a`#��ќ������Y��H�w�/E��Bx��;������O�aN|�7
��(��M���oIQ���CI��Z�-���:�6>bk������Y��J쥘@�[�t�yF��,	��x�2�}:���P���.v7ʁ�KX4���E�jlw�K�EU���%{9�5���I�\����aW�[حJ�1~wϸ�^�}~�����3����*�@��p���w(e$աJ�5��|�I��8n��w�EV��X:��-�iK�)H�GI�
7q��	?���M�go��5�bf�������L�LK�dF)�,�e�p��?����[�.T�nR�/X����U #�K���$����y�r4�)!S��0X����fT<�+����x`��B�4k������;#+��PU,�P�A���yZ/�5�$� ���?+�ԬE�[�[��¿y�$�״U�f�y,"�h�_>��F��Q��o/Y	��\Cy��}n��g��_o�	?�Aaz3p�L=��D����a%�K�av�X���Ua��zʚ�LM}���Yf*#�����O:������zre#eekV:�������NKA�U��p����X:����IϰL<}����)���ԝ|ٸS��a'��L<a��m����.����CE.�R:v�>��������!�&c+���k4�*�����0H � FC�N�8�68���r��W���$��K댆��T^^W%��ӑ{}����^��>S�����ӑ��wb��xZa^D3�����9���5-?	vo fpd}��J�^?��B,��LR��T|�Й������q�7�I�?���vq�)�5��J�n�+*ڰ�D�dW�sN����"�R]&1Su+�]��T]|�꾝W�؆��U�`1���H��+]r�E$���C���>͖/s*��	9C�*�;��_����8�Q��H�@�t}����p�N�l��Z� O�{��&�U&�P%
W{��}�BZ~���w��ץic�\aɜ�{y�J�֊E�lPP�s�����%���3���^��;1��6В֚�B���ꍻ�|Lc�x���`�̚�YɅ`�"l$*����	�"9�:��<���f��A��~�Dq��/"R<|�F�{�Ⱥ(A;N���������f���P7�H�{�cG'o��՛�\ٹ�E�6��'Lq����� j,�f�mL�=��&Op��[4�z~���Ħ)����	�	UtO�N�����}32�Ә�dw����"9�$���w�퍺��A~#W��F��Sܱ��j��ދ�%= 4�W���X�*�uOә%i�Jd�'}G{k�V�乣e�RPx2�pV_�$C)�p�a�AB�t"S�u�(W����!�h�E��DӚ������CD>}l�d,�W��R��=Z�	�h *�SO�U\%�6��A���4n�i<i&Q�O��i��	u��T4KC���ٜ����sN"��^�\[K/[�d&��%�����L<����f\�/���5>�omׯ��d%B:Ѿ׺��ޖ�����䘅ͼ�/.����y����%W�����	�LX�z[pd���y�[t� ��_^}�q�����G�����a�g��B�����5����"F,WU�q)�cP�D��2����,��b[v�Y���천������LL��fO���{猙�i����|�k���r1���(�d����MI�1 �*�|���%mt�f{����"đN�q1���0����LpP�3��ǻ(�����a9Y���y W��3�k�� ���x��[��������m�!׊]�i�
�%g7�Fe�V߭�wPXh�{:%�B�_A/����gC�L�����׍�D�ת�b����.@�q�~tO�������,h�HOc�=���:pzA������g��S߇��0*	�6������
:<��5pJ�;�����)M�G��Oo�D���ῡ��U�������3��To^,ph2\r\r�g;#�nf���H�o��Q��_��*�Z�A�O:i|���Q�}�* �   �MctF�R6��LZ�ִ�K�Q.����i�;)�. ��vq�e;w����k�s�X��m/��?���d�iN��S��)�q�'K����b ��G�CG�B#�����IwB���9z�O�O�]��i���GO�7�e�A8�r�K�L�o�.]�r����|      %      x������ � �      !   ,  x��Y�NW}6_q�P	$C�j���$RU��"B�K��J�M�D��:$%)���7���O����6H���_�t�}��cl�	���y��u_�Yk��������J��7���:���č�Ҳ0�$z�A����������̯�A�-��~s�E�lbh�o�,&����Ճ��_�|�M�U���P�,7��rv��N_��K����\a��M:m$��|�1�5+�i�3��S�i	G������bL�=���ث����a�KV�n���k��d����	���"i_����9q����l\�{;��7�n|=����Qt�-�iѦbR��x�{�bxmj��U,�-�IK����;���
��m;*U�aN�E#�a��曆�w�򐷮��%�'O��6>��xl�	{���`I#<Z1x	j\N,Z���=]9ѝ�4-f��c�4>�F�!s��1#��k���>�tF`�{�%F�s��yP�?�h,���>����t_�)DcT+A���0�oΌ�|�L��[��뙢�'��>���ۇ��R��Y�U\];���"���zvmuI8q���L\��x�4M=�f�46���5qh�[X���Ҙ�s�Z�A�F�s��	jU�A�&�����09�*>{hw96�0i��!���be`X0���ܢ���	6�.'��0�.-��X�e���� Y�pR�S���TH���+5�#�G.Jd8'I�?M�����=�s�Dh*qw[�_����u��{RZ��0�ccɶ8E���vQ6i�>���0 �=��2v�0��F� ���қ���Dg�]h�i
C�&p^�/OI�~=Q�i���vsJ�qO��!�n҈}i/�(�c���4>�N��¼]�셬��Zv6�-���M�n��\v�侔��x0ZZ{t���A������i��#	�.������\±�����m`p���ER�o�|�ːO�����"P���#�����F^C�E�v��8��&�-�ޑ�,��j_Չ�K�����w��Wb�2�@b3�M|*�)��e��;�r����t��.8)#��,+�N2��9N��9�.�Is>�A|�g�xw��N�'�FX:�p�]�ݥ����	���$�e��������6�E��z��2�����`wq�b��:a��r�Y���P��>YRiW�P,i�+�ب�jP��=}Ei`�d�[�[WQb�b�]yޤ��j��M��a�ǫה%�%�D$���{�;Y[KE��B(��J���P��
�J��!�`[T�U�0�jW�V��笕%r��|*z��8�',���bH��<4�^�#y�H��,�n��wV2���"�%���}���S�DO?�<�$`K���%d��������J>�\T���C9#�t��
u#�X��/��s��%f�`j��X@�z�������6�S�\C����c�1+!/��ZTN�}��itb8G�,d/�Q�.G�q=�"�Ua�<_��9L�Sƣh)˧w�9n��@��PՇ��1��#V��á�q��\P��J(��=]�ӊq��	�(,懕�nX�KA���Uu�
k�6G�rZ����E�*�_ˣ!9���E;���!&S�G~�!����%�>�j���d�5@*c��nZ�x��)��M�E��J-Y�1cfJ�Fs��8!7%�s�%u�׋�����ӟtoE���F�Ƚ�K��w~h�6�ݽ�y~$Kc��5�B�[�]�x�qU�h��Q�W@L�a�JE^�k~M�1��=^4Ô{�]��e6U�"��+��-v�X�y�����?Y�!�T)�5`�cףoTt�3Bo`#��Tj�:	��G�ћT���"�����u!�2y��_3f�S�'���D�l��Ujؕ�zn{�! ��V�6�\�y�C�ړϺ\��Pp'��J��ڃL����G�
�s���$��2M�e��>�6��A�g��5w�����a1�^J:����i���4�&W��Y�zt����vha�z���I%��<���	�
J*>�$ڏ�Łd�6YF�;�J��.�u�i�����:�����a����y���B�rPzfbb�i��o      #   !   x�340�43��"�"�=... `1�      "   /	  x��Y[oZ�~&�bk�&�s�\�h;�k��D��i+�#l��EHތ/qg���i����N��u�c̉1׿��_�/��}8��&T�1޷��Z߷.;�FH�[d_��{!���������V�����#�����{&6��XY[{&�dM��-�N/��
��݆¦.Ⱥ��=0�Ȇ�ݓm��	�8���`%�!"�4ٗm�2,h̑-�ߠ�0�^���o@�װx �I�N��3����X:�iq�=�	L�e�}G�B�q4[���\�AU:p�tOa���D\�mT���E�����6�s�|6����J�B6[*j{���J9W���b�*��ٳJ{V�0�|�R�v��|��Bh�/���t��a�t��m����Ӑi$B���ǘ���R<3�j����̴!־\���Vc����E� �wA�3��
��Cv��
�O��/���1�^�6�*�ٽ��^2�,ʁ�h��my��v݆'�N;W��3�g��%L۬��9=�w�|}��w:�BWdk ��ϰ��I��x9=6u�@������;�P�V�3γTT�Ǝ�M��t ͨh#��Ί9�Rq*�3�=�h�O��!\���r�>�e�Vng�U��.e��c3N3�c���%2��9`�K?���˭ϼ(�1:|�&ܨ�j�K)�h�0f�Z�D�>o1Bs2H81�U�����W�@v�z�4�P0�ijx���@x%A{J GZ��M:�#����ȔCЃ��")�āa�[�o  ��$��4��=f��;J����>gl->��{�a��7�{��Wc��&H	<b����ע+����vSa�!���H�_���#��Q�?��=yb� �Z;������W��W|�49�Q�RܥR $��ASoi�m{Z����� ?�zj��h|9�-9#����?����� �BYL HL[z;?m@G�>c�G,u|�o�\�`@V$�ܨĢ%����[��{�&3�Z��D�d�N�<�L���aCa�:�eҰ�`����M�A�M.��3eP�DDQ�K��ΈPW����j�b�Ѣ�TV]�B1��EQ�Z�I�`&��3i��LE�3'���J ȟ�%��LƗP�WFY�!&���'�=а3��7_�r|�����t���e)�-����^�`���?�B_���7 �G���I[Q�:W����!r�2�v5�0��&LL�w�(+��z-�B��xpP_=���";�3�`�P�`S���!>��X6s]�������@�C#�Qk2����.��󘖨2D����υ�7���t`�?�}d��-U�ɟH�%3]	�X�q,��s���lHq�Nu���v�pl����aU9�߽��6��Ǖ���]�{{>�-2��g��PC��p���8�L�`ZDL�f�M̋8ۖ��p�{�Q��C3ꘈ.�7¤O#�<���r2aƖ�u0�ӱ���N����lk��@�m-�9��9G�KC���/�*cTkN�Z�H��V��/\<�t��5gMF�V�#~Tö���R�}T��{菃�%+yō�
��k�6e=�;TzY�~�ZL�^2��
��FU a�Gk�YtkB���L,�F�%��gOWþ��+��4����{p��) C<����TB��-L��"�]2� ��b�)����R}?_���j�j}�&g3��E��yw*����V	h���3m�b�&hj��OJ��b��/ַ6�V5��"i�I����Vׇ��� /֞d2⷏�� ?��A�%�֍w5S�Z�*S�P���+5o��$rtꊄ5� ���ջ��G;���L��	�mE?��1r:,���U��=f���y��[Y�)D�o�J�.<��m� �$x6�ݨx���r�}�P+Y5�͜�ܸoC�I��{��z<KhD���+���O\�{����C�����}D2��<��F�0} �@�����a�=V�S(~�*�;B�	}�q�.�t2a|�'6���9�k����7�@��΄9czcC(��!�l&}�{�x�>�>�M$!�k��Z�:^%���]��<��i��pŉ	j<p�n�fA���?���'p:�{mb-��g�Njr����`�%���Ǐ�-_I���D�kbA�B��C!UAX�+���ݕ
[H!�d��}<^��֮2ǜ �q9 B�A�M�H������w��ź�����^�<�|br�'���Fء� S ��'��p�P���ߛ�Uz$J�+(�@��7����z��*�i��F],\�K~�S�I��r}6��������      $   �   x�34��0�¦�/l���;9/̾��bǅ}@�. ��S������ML�8
|r=�=r���|���B��J,�J��*��sB�KR2+�BJ���K�=�S���\����3*3mm�b���� *�1�     