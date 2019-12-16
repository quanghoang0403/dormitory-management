CREATE DATABASE QuanLyKTX
go

USE QuanLyKTX
go


CREATE TABLE ACCOUNT
(
	id_user INT IDENTITY PRIMARY KEY,
	name_user NVARCHAR(100) NOT NULL,
	USERNAME NVARCHAR(100) NOT NULL,
	PASS NVARCHAR(1000) NOT NULL,
)
GO



CREATE TABLE tbl_permision
(
	id_per INT IDENTITY PRIMARY KEY,
	name_per NVARCHAR(100) NOT NULL,
	descriptionn NVARCHAR(100) NOT NULL,
)
GO

CREATE TABLE tbl_permision_detail
(
	id_pd INT IDENTITY PRIMARY KEY,
	name_action NVARCHAR(100) NOT NULL,
	code_action VARCHAR(50) NOT NULL,
	id_per INT NOT NULL,

	
	FOREIGN KEY (id_per) REFERENCES DBO.tbl_permision(id_per),
)
GO

CREATE TABLE tbl_per_relationship
(
	id_rel INT IDENTITY PRIMARY KEY,
	id_user_rel INT NOT NULL,
	id_per_rel INT NOT NULL,
	suspended BIT NOT NULL,

	FOREIGN KEY (id_user_rel) REFERENCES dbo.ACCOUNT (id_user),

	FOREIGN KEY (id_per_rel ) REFERENCES dbo.tbl_permision (id_per),
)
GO

CREATE TABLE NHANVIEN
(
	MANV INT IDENTITY PRIMARY KEY,
	TENNV NVARCHAR(100) NOT NULL,
	GIOITINH NVARCHAR(100) NOT NULL,
	NGAYSINH DATE NOT NULL,
	SDTNV NVARCHAR(100) NOT NULL,
	QUEQUAN NVARCHAR(100) NOT NULL,
	NGAYVAOLAM DATE NOT NULL,
	CHUCVU NVARCHAR(100) NOT NULL,
	SLPHONGQL INT NOT NULL,
)
GO






CREATE TABLE PHONG
(
	MAPHG INT IDENTITY PRIMARY KEY,
	LOAIPHG NVARCHAR(100) NOT NULL,
	SLMAX INT NOT NULL,
	TONGSV INT NOT NULL,
	TINHTRANG NVARCHAR(100) NOT NULL,
	TOA NVARCHAR(10) NOT NULL,
	MANV INT NOT NULL,

	FOREIGN KEY (MANV) REFERENCES DBO.NHANVIEN(MANV)

)
GO

CREATE TABLE SINHVIEN
(
	MASV INT IDENTITY PRIMARY KEY,
	TENSV NVARCHAR(100) NOT NULL,
	GIOITINH NVARCHAR(10) NOT NULL,
	NGAYSINH DATE NOT NULL,
	SDTSV NVARCHAR(100) NOT NULL,
	QUEQUAN NVARCHAR(100) NOT NULL,
	TRUONG NVARCHAR(100) NOT NULL,
	MAPHG INT NOT NULL,

	FOREIGN KEY (MAPHG) REFERENCES DBO.PHONG(MAPHG)
)
GO


CREATE TABLE HOADON
(
	MAHD INT IDENTITY PRIMARY KEY,
	CHISONUOC INT NOT NULL,
	CHISODIEN INT NOT NULL,
	THANG INT NOT NULL,
	NAM INT NOT NULL,
	TONGTIEN  MONEY,
	MAPHG INT NOT NULL,
	TINHTRANGHD NVARCHAR(100) NOT NULL,
	GIANUOC INT NOT NULL,
	GIADIEN INT NOT NULL,

	FOREIGN KEY (MAPHG) REFERENCES DBO.PHONG(MAPHG) 
)

ALTER TABLE NHANVIEN ADD
CONSTRAINT NV_NGVL_CH CHECK (NGAYVAOLAM>NGAYSINH)

ALTER TABLE NHANVIEN ADD 
CONSTRAINT NV_GIOITINH_CH CHECK (GIOITINH='Nam' OR GIOITINH = 'Nu')

ALTER TABLE SINHVIEN ADD 
CONSTRAINT SV_GIOITINH_CH CHECK (GIOITINH='Nam' OR GIOITINH = 'Nu')

ALTER TABLE PHONG ADD 
CONSTRAINT PHG_TONGSV_CH CHECK (TONGSV<=SLMAX)

ALTER TABLE PHONG ADD 
CONSTRAINT PHG_LOAIPHG_CH CHECK (LOAIPHG='VIP' OR LOAIPHG='THUONG')

ALTER TABLE PHONG ADD 
CONSTRAINT PHG_TINHTRANG_CH CHECK (TINHTRANG='Dang su dung' OR TINHTRANG='Trong' OR TINHTRANG='Dang sua chua')

--tongsv
CREATE TRIGGER SV_TONGSV_THEM
ON SINHVIEN AFTER INSERT AS 
BEGIN
	UPDATE PHONG
	SET TONGSV = TONGSV +1
	FROM PHONG
	JOIN inserted ON PHONG.MAPHG = inserted.MAPHG
END
ENABLE TRIGGER SV_TONGSV_THEM ON SINHVIEN

CREATE TRIGGER SV_TONGSV_XOA
ON SINHVIEN AFTER DELETE AS 
BEGIN
	UPDATE PHONG
	SET TONGSV = TONGSV - 1
	FROM PHONG
	JOIN deleted ON PHONG.MAPHG = deleted.MAPHG
END

ENABLE TRIGGER SV_TONGSV_XOA ON SINHVIEN

CREATE TRIGGER SV_TONGGSV_SUA
ON SINHVIEN AFTER UPDATE AS
BEGIN
	DECLARE @MAPHGC AS CHAR(4), @MAPHGM AS CHAR(4)
	SELECT @MAPHGM=inserted.MAPHG, @MAPHGC=deleted.MAPHG
	FROM inserted,deleted
	UPDATE PHONG
	SET TONGSV=TONGSV+1
	WHERE PHONG.MAPHG=@MAPHGM
	UPDATE PHONG
	SET TONGSV=TONGSV-1
	WHERE PHONG.MAPHG=@MAPHGC
END
ENABLE TRIGGER SV_TONGGSV_SUA ON SINHVIEN

CREATE TRIGGER PHG_SLPHONGQL_THEM
ON PHONG AFTER INSERT AS 
BEGIN
	UPDATE NHANVIEN
	SET SLPHONGQL = SLPHONGQL + 1
	FROM NHANVIEN
	JOIN inserted ON NHANVIEN.MANV = inserted.MANV
END

ENABLE TRIGGER PHG_SLPHONGQL_THEM ON PHONG

CREATE TRIGGER PHG_SLPHONGQL_XOA
ON PHONG AFTER DELETE AS 
BEGIN
	UPDATE NHANVIEN
	SET SLPHONGQL = SLPHONGQL - 1
	FROM NHANVIEN
	JOIN deleted ON NHANVIEN.MANV = deleted.MANV
END
ENABLE TRIGGER PHG_SLPHONGQL_XOA ON PHONG

CREATE TRIGGER PHG_TONGGSV_SUA
ON PHONG AFTER UPDATE AS
BEGIN
	DECLARE @MANVC AS CHAR(4), @MANVM AS CHAR(4)
	SELECT @MANVM=inserted.MANV, @MANVC=deleted.MANV
	FROM inserted,deleted
	UPDATE NHANVIEN
	SET SLPHONGQL=SLPHONGQL+1
	WHERE NHANVIEN.MANV=@MANVM
	UPDATE NHANVIEN
	SET SLPHONGQL=SLPHONGQL-1
	WHERE NHANVIEN.MANV=@MANVC
END
ENABLE TRIGGER PHG_TONGGSV_SUA ON PHONG

INSERT INTO dbo.ACCOUNT VALUES ('Tran Phuong Duy','admin','33354741122871651676713774147412831195')
INSERT INTO dbo.ACCOUNT VALUES ('Chung Thai Dung','nhanvien','4247164254471675524141239451812313427126')
INSERT INTO dbo.ACCOUNT VALUES ('Dinh Quang Hoang','laocong','161521619193107152151209437815512424974217')

INSERT INTO dbo.tbl_permision VALUES ('Quan tri', 'Quyen con nhat')
INSERT INTO dbo.tbl_permision VALUES ('Nhan vien', 'Quyen gioi han')
INSERT INTO dbo.tbl_permision VALUES ('Vi tri khac', 'Quyen chi duoc coi')

INSERT INTO dbo.tbl_per_relationship VALUES ('1', '1' , 'False')
INSERT INTO dbo.tbl_per_relationship VALUES ('2', '2' , 'False')
INSERT INTO dbo.tbl_per_relationship VALUES ('3', '3' , 'False')

INSERT INTO dbo.tbl_permision_detail VALUES ('THEM', 'ADD' , '1')
INSERT INTO dbo.tbl_permision_detail VALUES ('SUA', 'EDIT' , '1')
INSERT INTO dbo.tbl_permision_detail VALUES ('XOA', 'DELETE' , '1')
INSERT INTO dbo.tbl_permision_detail VALUES ('THEM', 'ADD' , '2')
INSERT INTO dbo.tbl_permision_detail VALUES ('SUA', 'EDIT' , '2')
INSERT INTO dbo.tbl_permision_detail VALUES ('XOA', 'DELETE' , '2')
INSERT INTO dbo.tbl_permision_detail VALUES ('them', 'AD' , '1')
INSERT INTO dbo.tbl_permision_detail VALUES ('sua', 'EDI' , '1')
INSERT INTO dbo.tbl_permision_detail VALUES ('xoa', 'DELET' , '1')



INSERT INTO dbo.NHANVIEN VALUES ( 'Nguyen Nhu Nhut','nam','2001-07-22','048823451','BienHoa','2019-7-24','Van phong','0')
INSERT INTO dbo.NHANVIEN VALUES ( 'Le Thi Phi Yen', 'nu','1999-07-30','098256478','DakLak','2018-07-30','Quan ly','0')
INSERT INTO dbo.NHANVIEN VALUES ( 'Nguyen Van B', 'nu','2002-05-08','0938776266', 'HCM','2019-11-24','Bao ve','0')
INSERT INTO dbo.NHANVIEN VALUES ( 'Ngo Thanh Tuan', 'nam','2000-10-28','082476108','Hanoi','2019-5-24','Lao cong','0')
INSERT INTO dbo.NHANVIEN VALUES ( 'Nguyen Thi Truc Thanh','nu','1999-11-24','086731738','BienHoa','2019-6-24','Lao cong','0')

INSERT INTO dbo.PHONG VALUES ( 'VIP','4', '0', 'Dang su dung' , 'A' , '1')
INSERT INTO dbo.PHONG VALUES ( 'VIP','2', '0', 'Dang su dung' , 'A' , '1')
INSERT INTO dbo.PHONG VALUES ( 'VIP','6', '0', 'Trong' , 'A' , '2')
INSERT INTO dbo.PHONG VALUES ( 'VIP','2', '0', 'Dang su dung' , 'B' , '2')
INSERT INTO dbo.PHONG VALUES ( 'VIP','4', '0', 'Trong' , 'B' , '2')
INSERT INTO dbo.PHONG VALUES ( 'VIP','6', '0', 'Dang su dung' , 'B' , '2')
INSERT INTO dbo.PHONG VALUES ( 'THUONG','2', '0', 'Dang su dung' , 'C' , '3')
INSERT INTO dbo.PHONG VALUES ( 'THUONG','4', '0', 'Dang sua chua' , 'C' , '3')
INSERT INTO dbo.PHONG VALUES ( 'THUONG','4', '0', 'Dang su dung' , 'C' , '3')
INSERT INTO dbo.PHONG VALUES ( 'THUONG','4', '0', 'Dang su dung' , 'D' , '4')
INSERT INTO dbo.PHONG VALUES ( 'THUONG','6', '0', 'Dang sua chua' , 'D' , '5')
INSERT INTO dbo.PHONG VALUES ( 'THUONG','6', '0', 'Dang su dung' , 'D' , '5')
INSERT INTO dbo.PHONG VALUES ( 'THUONG','6', '0', 'Trong' , 'E' , '5')
INSERT INTO dbo.PHONG VALUES ( 'THUONG','8', '0', 'Dang su dung' , 'E' , '5')
INSERT INTO dbo.PHONG VALUES ( 'THUONG','8', '0', 'Trong' , 'E' , '5')

set IDENTITY_INSERT SINHVIEN off
insert into SINHVIEN  values('Cao Van Minh','nam','2001-07-22','048823451','BienHoa','UEL','1')
insert into SINHVIEN  values('Tran Ngoc Hien','nu','1999-07-30','098256478','AnGiang','UIT','1')
insert into SINHVIEN  values('Dinh Ngoc Linh','nu','2002-05-08','0938776266', 'PhanThiet','UEL','2')
insert into SINHVIEN  values('Tran Minh Khai','nu','2001-02-10','0917325476','Daklak','USSH','2')
insert into SINHVIEN  values('Le Nhat Minh','nam','2000-10-28','082476108','HCM','UIT','3')
insert into SINHVIEN  values('Dinh Hoai Trang','nu','1999-11-24','086731738','DongNai','UEL','3')
insert into SINHVIEN  values('Nguyen Van Tan','nam','1998-12-01','0916783565','VungTau','UIT','4')
insert into SINHVIEN  values('Mai Thi Thanh','nu','2000-12-13','0938435756','VungTau','USSH','5')
insert into SINHVIEN  values('Le Ha Vinh','nam','1998-01-14','086754763','TienGiang','UIT','5')
insert into SINHVIEN  values('Ha Duy Kien','nam','2001-01-16','087687904','HauGiang','UIT','5')
insert into SINHVIEN  values('Nguyen Van Troi','nam','2001-07-22','0488234515','LamDong','UIT','5')
insert into SINHVIEN  values('Dinh Ngoc Han','nu','1999-07-30','0982564781','KhanhHoa','USSH','8')
insert into SINHVIEN  values('Tran Ngoc Linh','nu','1998-05-08','0938776266', 'BMT','UIT','8')
insert into SINHVIEN  values('Mai Minh Long','nu','2001-02-10','0917325476','Daklak','USSH','9')
insert into SINHVIEN  values('Dinh Nhat Minh','nam','2000-10-28','082461087','HCM','UEL','9')
insert into SINHVIEN  values('Le Hoai Thuong','nu','2000-11-24','086317738','NinhBinh','UIT','10')
insert into SINHVIEN  values('Dinh Van Tam','nam','1999-12-01','0916783565','VungTau','USSH','10')
insert into SINHVIEN  values('Phan Thi Thanh','nu','1998-12-13','0938435756','HCM','UIT','10')
insert into SINHVIEN  values('Cao Ha Vinh','nam','1998-01-14','086547634','DaLat','UIT','11')
insert into SINHVIEN  values('Ha Duy Hai','nam','2001-01-16','087689047','DongThap','USSH','11')
insert into SINHVIEN  values('Nguyen Van Lam','nam','2001-07-22','048823451','Hanoi','UEL','11')
insert into SINHVIEN  values('Mai Ngoc Han','nu','2000-07-30','0982564784','QuangTri','UIT','11')
insert into SINHVIEN  values('Cao Ngoc Linh','nu','1999-05-08','0938776266', 'PhanThiet','USSH','12')
insert into SINHVIEN  values('Tran Minh Long','nu','2001-02-10','0917325476','Daklak','UIT','12')
insert into SINHVIEN  values('Le Nhat Minh','nam','2000-10-28','082461084','HCM','UIT','13')
insert into SINHVIEN  values('Le Hoai Thuong','nu','2000-11-24','086317384','QuangBinh','USSH','13')
insert into SINHVIEN  values('Dinh Van Tam','nam','2000-12-01','0916783565','VungTau','UIT','15')
insert into SINHVIEN  values('Phan Thi Thanh','nu','1999-12-13','09384357564','QuangNgai','UIT','15')
insert into SINHVIEN  values('Le Ha Vinh','nam','2000-01-14','086547634','DakNong','USSH','15')
insert into SINHVIEN  values('Ha Duy Lap','nam','1998-01-16','087689404','HauGiang','UIT','15')
insert into SINHVIEN  values('Mai Nhat Nam','nam','2000-10-28','082461078','HCM','UIT','15')
insert into SINHVIEN  values('Le Hoai Thu','nu','1998-11-24','086731738','GiaLai','USSH','15')
insert into SINHVIEN  values('Nguyen Van Tam','nam','1999-12-01','0916783565','VungTau','UEL','15')


INSERT INTO HOADON VALUES ( '25','4', '5', '2019', 0 , '1','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','8', '6', '2019', 0 , '1','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '25','0', '7', '2019', 0 , '1','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '34','3', '8', '2019', 0 , '1','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '27','2', '9', '2019', 0 , '1','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '27','2', '10', '2019', 0 , '1','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','2', '5', '2019', 0 , '2','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '28','2', '6', '2019', 0 , '2','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','3', '7', '2019', 0 , '2','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '24','3', '8', '2019', 0 , '2','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '34','3', '9', '2019', 0 , '2','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','3', '10', '2019', 0 , '2','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '25','2', '5', '2019', 0 , '4','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '25','2', '6', '2019', 0 , '4','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','3', '7', '2019', 0 , '4','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '24','2', '8', '2019', 0 , '4','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '34','3', '9', '2019', 0 , '4','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '35','2', '10', '2019', 0 , '4','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '25','2', '5', '2019', 0 , '6','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '28','3', '6', '2019', 0 , '6','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '27','2', '7', '2019', 0 , '6','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','2', '8', '2019', 0 , '6','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '33','3', '9', '2019', 0 , '6','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '27','3', '10', '2019', 0 , '6','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','3', '5', '2019', 0 , '7','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '28','3', '6', '2019', 0 , '7','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','3', '7', '2019', 0 , '7','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','3', '8', '2019', 0 , '7','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '24','2', '9', '2019', 0 , '7','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '36','2', '10', '2019', 0 , '7','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '25','2', '5', '2019', 0 , '9','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '27','2', '6', '2019', 0 , '9','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '34','3', '7', '2019', 0 , '9','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '25','3', '8', '2019', 0 , '9','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '25','3', '9', '2019', 0 , '9','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','3', '10', '2019', 0 , '9','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '27','3', '5', '2019', 0 , '10','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '32','2', '6', '2019', 0 , '10','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '33','2', '7', '2019', 0 , '10','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '36','2', '8', '2019', 0 , '10','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '27','2', '9', '2019', 0 , '10','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '32','2', '10', '2019', 0 , '10','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','3', '5', '2019', 0 , '12','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '29','3', '6', '2019', 0 , '12','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '33','3', '7', '2019', 0 , '12','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '34','3', '8', '2019', 0 , '12','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '32','2', '9', '2019', 0 , '12','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','3', '10', '2019', 0 , '12','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '33','3', '5', '2019', 0 , '14','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '24','3', '6', '2019', 0 , '14','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '26','2', '7', '2019', 0 , '14','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '27','3', '8', '2019', 0 , '14','Dang thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '29','2', '9', '2019', 0 , '14','Chua thanh toan', 2000, 3000)
INSERT INTO HOADON VALUES ( '30','3', '10', '2019', 0 , '14','Dang thanh toan', 2000, 3000)

UPDATE HOADON
SET TONGTIEN = CHISONUOC * GIANUOC + CHISODIEN * GIADIEN
WHERE TONGTIEN >= 0

CREATE PROC USP_PhongList
AS SELECT * FROM dbo.PHONG
