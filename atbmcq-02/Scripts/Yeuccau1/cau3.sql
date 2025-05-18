-- Sinh viên
CREATE USER SV0001 IDENTIFIED BY sv0001;
GRANT CONNECT TO SV0001;

-- Nhân viên CTSV
CREATE USER PCTSV01 IDENTIFIED BY pctsv01;
GRANT CONNECT TO PCTSV01;

-- Nhân viên PĐT
CREATE USER PDT01 IDENTIFIED BY pdt01;
GRANT CONNECT TO PDT01;

-- Giảng viên
CREATE USER NV020 IDENTIFIED BY 123;
GRANT CONNECT TO NV020;

-- Gán quyền SELECT, UPDATE tùy trường:
GRANT SELECT, UPDATE ON C##ADMIN.SINHVIEN TO SV0001;
GRANT SELECT, INSERT, UPDATE, DELETE ON C##ADMIN.SINHVIEN TO PCTSV01;
GRANT UPDATE (TINHTRANG) ON C##ADMIN.SINHVIEN TO PDT01;
GRANT SELECT ON C##ADMIN.SINHVIEN TO NV020;

CREATE OR REPLACE FUNCTION POLICY_SINHVIEN (
    schema_name IN VARCHAR2,
    table_name  IN VARCHAR2
)
RETURN VARCHAR2
AS
    user_role VARCHAR2(20);
    user_id   VARCHAR2(20);
BEGIN
    user_role := SYS_CONTEXT('USERENV', 'SESSION_USER');

    -- Nếu là sinh viên -> chỉ xem/sửa bản ghi chính mình
    IF user_role LIKE 'SV%' THEN
        RETURN 'MASV = ''' || user_role || '''';

    -- Nếu là giảng viên -> xem sinh viên thuộc cùng khoa
    ELSIF user_role LIKE 'GV%' THEN
        RETURN 'KHOA = (SELECT MADV FROM NHANVIEN WHERE MANLD = ''' || user_role || ''')';

    -- Nếu là nhân viên phòng CTSV -> toàn quyền
    ELSIF user_role LIKE 'PCTSV%' THEN
        RETURN '1=1';

    -- Nếu là nhân viên PĐT -> có thể cập nhật TINHTRANG
    ELSIF user_role LIKE 'PDT%' THEN
        RETURN '1=0'; -- không thấy dữ liệu, chỉ UPDATE được
    END IF;

    RETURN '1=0'; -- mặc định chặn
END;

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'C##ADMIN',
        object_name     => 'SINHVIEN',
        policy_name     => 'VPD_POLICY_SINHVIEN',
        function_schema => 'C##ADMIN',
        policy_function => 'POLICY_SINHVIEN',
        statement_types => 'SELECT, INSERT, UPDATE, DELETE',
        update_check    => TRUE
    );
END;

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'C##ADMIN',
        object_name   => 'SINHVIEN',
        policy_name   => 'VPD_POLICY_SINHVIEN'
    );
END;
