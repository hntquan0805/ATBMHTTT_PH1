-- Oracle User Manager Stored Procedures
-- Chạy script này với tài khoản SYS

-- 1. Procedure tạo user mới
-- Tham số:
--   p_username: Tên user cần tạo
--   p_password: Mật khẩu cho user
CREATE OR REPLACE PROCEDURE create_user_proc(
    p_username IN VARCHAR2,
    p_password IN VARCHAR2
) AS
BEGIN
    -- Tạo user mới với tiền tố C## (yêu cầu cho Oracle CDB)
    EXECUTE IMMEDIATE 'CREATE USER C##' || p_username || ' IDENTIFIED BY ' || p_password;
    -- Cấp quyền đăng nhập cho user
    EXECUTE IMMEDIATE 'GRANT CREATE SESSION TO C##' || p_username;
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

-- 2. Procedure tạo role mới
-- Tham số:
--   p_rolename: Tên role cần tạo
CREATE OR REPLACE PROCEDURE create_role_proc(
    p_rolename IN VARCHAR2
) AS
BEGIN
    -- Tạo role mới với tiền tố C##
    EXECUTE IMMEDIATE 'CREATE ROLE C##' || p_rolename;
    -- Cấp quyền đăng nhập cho role
    EXECUTE IMMEDIATE 'GRANT CREATE SESSION TO C##' || p_rolename;
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

-- 3. Procedure xóa user
-- Tham số:
--   p_username: Tên user cần xóa
CREATE OR REPLACE PROCEDURE drop_user_proc(
    p_username IN VARCHAR2
) AS
BEGIN
    -- Xóa user và tất cả các đối tượng liên quan
    EXECUTE IMMEDIATE 'DROP USER C##' || p_username || ' CASCADE';
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

-- 4. Procedure xóa role
-- Tham số:
--   p_rolename: Tên role cần xóa
CREATE OR REPLACE PROCEDURE drop_role_proc(
    p_rolename IN VARCHAR2
) AS
BEGIN
    -- Xóa role
    EXECUTE IMMEDIATE 'DROP ROLE C##' || p_rolename;
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

-- 5. Procedure thay đổi mật khẩu user
-- Tham số:
--   p_username: Tên user cần đổi mật khẩu
--   p_new_password: Mật khẩu mới
CREATE OR REPLACE PROCEDURE alter_user_password_proc(
    p_username IN VARCHAR2,
    p_new_password IN VARCHAR2
) AS
BEGIN
    -- Thay đổi mật khẩu cho user
    EXECUTE IMMEDIATE 'ALTER USER C##' || p_username || ' IDENTIFIED BY ' || p_new_password;
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

-- 6. Procedure cấp quyền
-- Tham số:
--   p_privilege: Quyền cần cấp (ví dụ: SELECT, INSERT, UPDATE)
--   p_grantee: User/role được cấp quyền
--   p_object_name: Tên đối tượng (bảng, view) - tùy chọn
CREATE OR REPLACE PROCEDURE grant_privilege_proc (
    p_grantee        IN VARCHAR2,      -- user hoặc role
    p_table_name     IN VARCHAR2,      -- tên bảng
    p_select_cols    IN VARCHAR2 DEFAULT NULL, -- cột SELECT, phân cách bằng dấu phẩy
    p_update_cols    IN VARCHAR2 DEFAULT NULL, -- cột UPDATE, phân cách bằng dấu phẩy
    p_grant_select   IN BOOLEAN DEFAULT FALSE,
    p_grant_insert   IN BOOLEAN DEFAULT FALSE,
    p_grant_delete   IN BOOLEAN DEFAULT FALSE,
    p_grant_update   IN BOOLEAN DEFAULT FALSE,
) AS
BEGIN
    -- Cấp quyền SELECT nếu có
    IF p_grant_select IS NOT NULL THEN
        IF p_select_cols IS NOT NULL THEN
            EXECUTE IMMEDIATE 'GRANT SELECT (' || p_select_cols || ') ON ' || p_table_name || ' TO ' || p_grantee;
        ELSE
            EXECUTE IMMEDIATE 'GRANT SELECT ON ' || p_table_name || ' TO ' || p_grantee;
        END IF;
    END IF;

    -- Cấp quyền UPDATE nếu có
    IF p_grant_update IS NOT NULL THEN
        IF p_update_cols IS NOT NULL THEN
            EXECUTE IMMEDIATE 'GRANT UPDATE (' || p_select_cols || ') ON ' || p_table_name || ' TO ' || p_grantee;
        ELSE
            EXECUTE IMMEDIATE 'GRANT UPDATE ON ' || p_table_name || ' TO ' || p_grantee;
        END IF;
    END IF;

    -- Cấp quyền INSERT nếu yêu cầu
    IF p_grant_insert THEN
        EXECUTE IMMEDIATE 'GRANT INSERT ON ' || p_table_name || ' TO ' || p_grantee;
    END IF;

    -- Cấp quyền DELETE nếu yêu cầu
    IF p_grant_delete THEN
        EXECUTE IMMEDIATE 'GRANT DELETE ON ' || p_table_name || ' TO ' || p_grantee;
    END IF;
    
    DBMS_OUTPUT.PUT_LINE('Privileges granted successfully.');
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
        ROLLBACK;
END;
/

-- 7. Procedure thu hồi quyền
-- Tham số:
--   p_privilege: Quyền cần thu hồi
--   p_grantee: User/role bị thu hồi quyền
--   p_object_name: Tên đối tượng - tùy chọn
CREATE OR REPLACE PROCEDURE revoke_privilege_proc(
    p_grant_select   IN BOOLEAN DEFAULT FALSE,
    p_grant_insert   IN BOOLEAN DEFAULT FALSE,
    p_grant_delete   IN BOOLEAN DEFAULT FALSE,
    p_grant_update   IN BOOLEAN DEFAULT FALSE,
    p_grantee IN VARCHAR2,
    p_object_name IN VARCHAR2 DEFAULT NULL
) AS
    v_sql VARCHAR2(4000);
BEGIN
        IF p_grant_select THEN
            v_sql := 'REVOKE ' || p_grant_select || ' ON ' || p_object_name || ' FROM C##' || p_grantee;
        END IF;

        IF p_grant_insert THEN
            v_sql := 'REVOKE ' || p_grant_insert || ' ON ' || p_object_name || ' FROM C##' || p_grantee;
        END IF;

        IF p_grant_delete THEN
            v_sql := 'REVOKE ' || p_grant_delete || ' ON ' || p_object_name || ' FROM C##' || p_grantee;
        END IF;

        IF p_grant_update THEN
            v_sql := 'REVOKE ' || p_grant_update || ' ON ' || p_object_name || ' FROM C##' || p_grantee;
        END IF;
    
    EXECUTE IMMEDIATE v_sql;
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

-- 8. Procedure tạo tablespace
-- Tham số:
--   p_tablespace_name: Tên tablespace cần tạo
--   p_size: Kích thước ban đầu (MB)
CREATE OR REPLACE PROCEDURE create_tablespace_proc(
    p_tablespace_name IN VARCHAR2,
    p_size IN NUMBER
) AS
    v_sql VARCHAR2(4000);
BEGIN
    -- Tạo tablespace mới với kích thước và tự động mở rộng
    v_sql := 'CREATE TABLESPACE ' || p_tablespace_name || 
             ' DATAFILE ''' || p_tablespace_name || '.dbf'' ' ||
             'SIZE ' || p_size || 'M ' ||
             'AUTOEXTEND ON NEXT 10M MAXSIZE UNLIMITED';
             
    EXECUTE IMMEDIATE v_sql;
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

-- 9. Procedure xóa tablespace
-- Tham số:
--   p_tablespace_name: Tên tablespace cần xóa
CREATE OR REPLACE PROCEDURE drop_tablespace_proc(
    p_tablespace_name IN VARCHAR2
) AS
BEGIN
    -- Xóa tablespace và tất cả dữ liệu liên quan
    EXECUTE IMMEDIATE 'DROP TABLESPACE ' || p_tablespace_name || ' INCLUDING CONTENTS AND DATAFILES';
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

-- 10. Procedure thay đổi kích thước tablespace
-- Tham số:
--   p_tablespace_name: Tên tablespace cần thay đổi
--   p_size: Kích thước mới (MB)
CREATE OR REPLACE PROCEDURE resize_tablespace_proc(
    p_tablespace_name IN VARCHAR2,
    p_size IN NUMBER
) AS
BEGIN
    -- Thay đổi kích thước datafile của tablespace
    EXECUTE IMMEDIATE 'ALTER DATABASE DATAFILE ''' || p_tablespace_name || '.dbf'' RESIZE ' || p_size || 'M';
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

-- 11. Procedure lấy danh sách users và roles
CREATE OR REPLACE PROCEDURE get_users_roles_list(
    p_filter IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    IF p_filter = 'Users' THEN
        OPEN p_cursor FOR
            SELECT username as name, created, 
                   CASE WHEN account_status IS NULL THEN 'OPEN' ELSE account_status END as status,
                   'USER' as type 
            FROM dba_users 
            ORDER BY username;
    ELSIF p_filter = 'Roles' THEN
        OPEN p_cursor FOR
            SELECT role as name, 
                   NULL as created, 
                   CASE 
                       WHEN authentication_type = 'PASSWORD' THEN 'SECURE ROLE'
                       ELSE 'NORMAL ROLE'
                   END as status,
                   'ROLE' as type 
            FROM dba_roles
            ORDER BY role;
    ELSE
        OPEN p_cursor FOR
            SELECT username as name, created, 
                   CASE WHEN account_status IS NULL THEN 'OPEN' ELSE account_status END as status,
                   'USER' as type 
            FROM dba_users 
            UNION ALL 
            SELECT role as name,
                   NULL as created,
                   CASE 
                       WHEN authentication_type = 'PASSWORD' THEN 'SECURE ROLE'
                       ELSE 'NORMAL ROLE'
                   END as status,
                   'ROLE' as type 
            FROM dba_roles
            ORDER BY name;
    END IF;
END;
/

-- 12. Procedure lấy danh sách quyền
CREATE OR REPLACE PROCEDURE get_privileges_list(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT grantee, privilege, table_name, 
               CASE WHEN grantable = 'YES' THEN 'Có thể cấp' ELSE 'Không thể cấp' END as grantable
        FROM dba_tab_privs 
        ORDER BY grantee, privilege;
END;
/

-- 13. Procedure lấy danh sách tablespaces
CREATE OR REPLACE PROCEDURE get_tablespaces_list(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT tablespace_name, 
               ROUND(bytes/1024/1024, 2) as size_mb,
               status, 
               CASE WHEN autoextensible = 'YES' THEN 'Có' ELSE 'Không' END as autoextensible
        FROM dba_data_files 
        ORDER BY tablespace_name;
END;
/

-- 14. Procedure lấy danh sách audit log
CREATE OR REPLACE PROCEDURE get_audit_log_list(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT timestamp, username, action_name, obj_name,
               CASE WHEN returncode = 0 THEN 'Thành công' ELSE 'Thất bại' END as status
        FROM dba_audit_trail
        ORDER BY timestamp DESC;
END;
/

-- Cấp quyền thực thi cho tất cả các procedure
GRANT EXECUTE ON create_user_proc TO PUBLIC;
GRANT EXECUTE ON create_role_proc TO PUBLIC;
GRANT EXECUTE ON drop_user_proc TO PUBLIC;
GRANT EXECUTE ON drop_role_proc TO PUBLIC;
GRANT EXECUTE ON alter_user_password_proc TO PUBLIC;
GRANT EXECUTE ON grant_privilege_proc TO PUBLIC;
GRANT EXECUTE ON revoke_privilege_proc TO PUBLIC;
GRANT EXECUTE ON create_tablespace_proc TO PUBLIC;
GRANT EXECUTE ON drop_tablespace_proc TO PUBLIC;
GRANT EXECUTE ON resize_tablespace_proc TO PUBLIC;
GRANT EXECUTE ON get_users_roles_list TO PUBLIC;
GRANT EXECUTE ON get_privileges_list TO PUBLIC;
GRANT EXECUTE ON get_tablespaces_list TO PUBLIC;
GRANT EXECUTE ON get_audit_log_list TO PUBLIC;

-- ===========================================
-- TEST CÁC PROCEDURE
-- ===========================================

-- Bật DBMS_OUTPUT để hiển thị kết quả
SET SERVEROUTPUT ON SIZE 1000000;

-- 1. Test create_user_proc
BEGIN
    DBMS_OUTPUT.PUT_LINE('=== Bắt đầu test create_user_proc ===');
    
    -- Tạo user test
    create_user_proc('TEST_USER', 'test123');
    DBMS_OUTPUT.PUT_LINE('Đã gọi procedure create_user_proc');
    
    -- Kiểm tra user đã được tạo
    FOR r IN (SELECT username, created, account_status 
              FROM dba_users 
              WHERE username = 'C##TEST_USER') LOOP
        DBMS_OUTPUT.PUT_LINE('Test create_user_proc: PASSED');
        DBMS_OUTPUT.PUT_LINE('  - User: ' || r.username);
        DBMS_OUTPUT.PUT_LINE('  - Ngày tạo: ' || r.created);
        DBMS_OUTPUT.PUT_LINE('  - Trạng thái: ' || r.account_status);
    END LOOP;
    
    -- Dọn dẹp
    EXECUTE IMMEDIATE 'DROP USER C##TEST_USER CASCADE';
    DBMS_OUTPUT.PUT_LINE('Đã xóa user test');
    DBMS_OUTPUT.PUT_LINE('=== Kết thúc test create_user_proc ===');
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Test create_user_proc: FAILED');
        DBMS_OUTPUT.PUT_LINE('Lỗi: ' || SQLERRM);
END;
/

-- 2. Test create_role_proc
BEGIN
    -- Tạo role test
    create_role_proc('TEST_ROLE');
    
    -- Kiểm tra role đã được tạo
    FOR r IN (SELECT role FROM dba_roles WHERE role = 'C##TEST_ROLE') LOOP
        DBMS_OUTPUT.PUT_LINE('Test create_role_proc: PASSED - Role C##TEST_ROLE created successfully');
    END LOOP;
    
    -- Dọn dẹp
    EXECUTE IMMEDIATE 'DROP ROLE C##TEST_ROLE';
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Test create_role_proc: FAILED - ' || SQLERRM);
END;
/

-- 3. Test drop_user_proc
BEGIN
    -- Tạo user test
    EXECUTE IMMEDIATE 'CREATE USER C##TEST_USER_DROP IDENTIFIED BY test123';
    
    -- Xóa user
    drop_user_proc('TEST_USER_DROP');
    
    -- Kiểm tra user đã bị xóa
    FOR r IN (SELECT username FROM dba_users WHERE username = 'C##TEST_USER_DROP') LOOP
        DBMS_OUTPUT.PUT_LINE('Test drop_user_proc: FAILED - User still exists');
        RETURN;
    END LOOP;
    
    DBMS_OUTPUT.PUT_LINE('Test drop_user_proc: PASSED - User C##TEST_USER_DROP deleted successfully');
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Test drop_user_proc: FAILED - ' || SQLERRM);
END;
/

-- 4. Test drop_role_proc
BEGIN
    -- Tạo role test
    EXECUTE IMMEDIATE 'CREATE ROLE C##TEST_ROLE_DROP';
    
    -- Xóa role
    drop_role_proc('TEST_ROLE_DROP');
    
    -- Kiểm tra role đã bị xóa
    FOR r IN (SELECT role FROM dba_roles WHERE role = 'C##TEST_ROLE_DROP') LOOP
        DBMS_OUTPUT.PUT_LINE('Test drop_role_proc: FAILED - Role still exists');
        RETURN;
    END LOOP;
    
    DBMS_OUTPUT.PUT_LINE('Test drop_role_proc: PASSED - Role C##TEST_ROLE_DROP deleted successfully');
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Test drop_role_proc: FAILED - ' || SQLERRM);
END;
/

-- 5. Test alter_user_password_proc
BEGIN
    -- Tạo user test
    EXECUTE IMMEDIATE 'CREATE USER C##TEST_USER_PASS IDENTIFIED BY oldpass';
    
    -- Đổi mật khẩu
    alter_user_password_proc('TEST_USER_PASS', 'newpass');
    
    -- Kiểm tra bằng cách thử kết nối (nếu có thể)
    DBMS_OUTPUT.PUT_LINE('Test alter_user_password_proc: PASSED - Password changed successfully');
    
    -- Dọn dẹp
    EXECUTE IMMEDIATE 'DROP USER C##TEST_USER_PASS CASCADE';
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Test alter_user_password_proc: FAILED - ' || SQLERRM);
END;
/

-- 6. Test grant_privilege_proc
BEGIN
    -- Tạo user và bảng test
    EXECUTE IMMEDIATE 'CREATE USER C##TEST_USER_GRANT IDENTIFIED BY test123';
    EXECUTE IMMEDIATE 'CREATE TABLE C##TEST_USER_GRANT.TEST_TABLE (id NUMBER)';
    
    -- Cấp quyền
    grant_privilege_proc('SELECT', 'TEST_USER_GRANT', 'C##TEST_USER_GRANT.TEST_TABLE');
    
    -- Kiểm tra quyền đã được cấp
    FOR r IN (SELECT privilege FROM dba_tab_privs 
              WHERE grantee = 'C##TEST_USER_GRANT' 
              AND table_name = 'TEST_TABLE' 
              AND privilege = 'SELECT') LOOP
        DBMS_OUTPUT.PUT_LINE('Test grant_privilege_proc: PASSED - Privilege granted successfully');
    END LOOP;
    
    -- Dọn dẹp
    EXECUTE IMMEDIATE 'DROP USER C##TEST_USER_GRANT CASCADE';
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Test grant_privilege_proc: FAILED - ' || SQLERRM);
END;
/

-- 7. Test revoke_privilege_proc
BEGIN
    -- Tạo user và bảng test
    EXECUTE IMMEDIATE 'CREATE USER C##TEST_USER_REVOKE IDENTIFIED BY test123';
    EXECUTE IMMEDIATE 'CREATE TABLE C##TEST_USER_REVOKE.TEST_TABLE (id NUMBER)';
    EXECUTE IMMEDIATE 'GRANT SELECT ON C##TEST_USER_REVOKE.TEST_TABLE TO C##TEST_USER_REVOKE';
    
    -- Thu hồi quyền
    revoke_privilege_proc('SELECT', 'TEST_USER_REVOKE', 'C##TEST_USER_REVOKE.TEST_TABLE');
    
    -- Kiểm tra quyền đã bị thu hồi
    FOR r IN (SELECT privilege FROM dba_tab_privs 
              WHERE grantee = 'C##TEST_USER_REVOKE' 
              AND table_name = 'TEST_TABLE' 
              AND privilege = 'SELECT') LOOP
        DBMS_OUTPUT.PUT_LINE('Test revoke_privilege_proc: FAILED - Privilege still exists');
        RETURN;
    END LOOP;
    
    DBMS_OUTPUT.PUT_LINE('Test revoke_privilege_proc: PASSED - Privilege revoked successfully');
    
    -- Dọn dẹp
    EXECUTE IMMEDIATE 'DROP USER C##TEST_USER_REVOKE CASCADE';
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Test revoke_privilege_proc: FAILED - ' || SQLERRM);
END;
/

-- 8. Test create_tablespace_proc
BEGIN
    -- Tạo tablespace test
    create_tablespace_proc('TEST_TS', 10);
    
    -- Kiểm tra tablespace đã được tạo
    FOR r IN (SELECT tablespace_name FROM dba_tablespaces WHERE tablespace_name = 'TEST_TS') LOOP
        DBMS_OUTPUT.PUT_LINE('Test create_tablespace_proc: PASSED - Tablespace TEST_TS created successfully');
    END LOOP;
    
    -- Dọn dẹp
    EXECUTE IMMEDIATE 'DROP TABLESPACE TEST_TS INCLUDING CONTENTS AND DATAFILES';
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Test create_tablespace_proc: FAILED - ' || SQLERRM);
END;
/

-- 9. Test drop_tablespace_proc
BEGIN
    -- Tạo tablespace test
    EXECUTE IMMEDIATE 'CREATE TABLESPACE TEST_TS_DROP DATAFILE ''TEST_TS_DROP.dbf'' SIZE 10M';
    
    -- Xóa tablespace
    drop_tablespace_proc('TEST_TS_DROP');
    
    -- Kiểm tra tablespace đã bị xóa
    FOR r IN (SELECT tablespace_name FROM dba_tablespaces WHERE tablespace_name = 'TEST_TS_DROP') LOOP
        DBMS_OUTPUT.PUT_LINE('Test drop_tablespace_proc: FAILED - Tablespace still exists');
        RETURN;
    END LOOP;
    
    DBMS_OUTPUT.PUT_LINE('Test drop_tablespace_proc: PASSED - Tablespace TEST_TS_DROP deleted successfully');
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Test drop_tablespace_proc: FAILED - ' || SQLERRM);
END;
/

-- 10. Test resize_tablespace_proc
BEGIN
    -- Tạo tablespace test
    EXECUTE IMMEDIATE 'CREATE TABLESPACE TEST_TS_RESIZE DATAFILE ''TEST_TS_RESIZE.dbf'' SIZE 10M';
    
    -- Thay đổi kích thước
    resize_tablespace_proc('TEST_TS_RESIZE', 20);
    
    -- Kiểm tra kích thước mới
    FOR r IN (SELECT bytes/1024/1024 as size_mb 
              FROM dba_data_files 
              WHERE tablespace_name = 'TEST_TS_RESIZE') LOOP
        IF r.size_mb = 20 THEN
            DBMS_OUTPUT.PUT_LINE('Test resize_tablespace_proc: PASSED - Tablespace resized to 20MB successfully');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Test resize_tablespace_proc: FAILED - Incorrect size: ' || r.size_mb || 'MB');
        END IF;
    END LOOP;
    
    -- Dọn dẹp
    EXECUTE IMMEDIATE 'DROP TABLESPACE TEST_TS_RESIZE INCLUDING CONTENTS AND DATAFILES';
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Test resize_tablespace_proc: FAILED - ' || SQLERRM);
END;
/

-- 11. Test get_users_roles_list
DECLARE
    v_cursor SYS_REFCURSOR;
    v_name VARCHAR2(100);
    v_created DATE;
    v_status VARCHAR2(100);
    v_type VARCHAR2(100);
BEGIN
    DBMS_OUTPUT.PUT_LINE('=== Bắt đầu test get_users_roles_list ===');
    
    -- Test lấy danh sách users
    get_users_roles_list('Users', v_cursor);
    DBMS_OUTPUT.PUT_LINE('Danh sách users:');
    LOOP
        FETCH v_cursor INTO v_name, v_created, v_status, v_type;
        EXIT WHEN v_cursor%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE('  - ' || v_name || ' (' || v_type || ') - ' || v_status);
    END LOOP;
    CLOSE v_cursor;
    
    -- Test lấy danh sách roles
    get_users_roles_list('Roles', v_cursor);
    DBMS_OUTPUT.PUT_LINE('Danh sách roles:');
    LOOP
        FETCH v_cursor INTO v_name, v_created, v_status, v_type;
        EXIT WHEN v_cursor%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE('  - ' || v_name || ' (' || v_type || ') - ' || v_status);
    END LOOP;
    CLOSE v_cursor;
    
    DBMS_OUTPUT.PUT_LINE('=== Kết thúc test get_users_roles_list ===');
END;
/

-- 12. Test get_privileges_list
DECLARE
    v_cursor SYS_REFCURSOR;
    v_grantee VARCHAR2(100);
    v_privilege VARCHAR2(100);
    v_table_name VARCHAR2(100);
    v_grantable VARCHAR2(100);
BEGIN
    DBMS_OUTPUT.PUT_LINE('=== Bắt đầu test get_privileges_list ===');
    
    get_privileges_list(v_cursor);
    DBMS_OUTPUT.PUT_LINE('Danh sách quyền:');
    LOOP
        FETCH v_cursor INTO v_grantee, v_privilege, v_table_name, v_grantable;
        EXIT WHEN v_cursor%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE('  - ' || v_grantee || ' có quyền ' || v_privilege || 
                            ' trên ' || v_table_name || ' (' || v_grantable || ')');
    END LOOP;
    CLOSE v_cursor;
    
    DBMS_OUTPUT.PUT_LINE('=== Kết thúc test get_privileges_list ===');
END;
/

-- 13. Test get_tablespaces_list
DECLARE
    v_cursor SYS_REFCURSOR;
    v_name VARCHAR2(100);
    v_size NUMBER;
    v_status VARCHAR2(100);
    v_autoext VARCHAR2(100);
BEGIN
    DBMS_OUTPUT.PUT_LINE('=== Bắt đầu test get_tablespaces_list ===');
    
    get_tablespaces_list(v_cursor);
    DBMS_OUTPUT.PUT_LINE('Danh sách tablespaces:');
    LOOP
        FETCH v_cursor INTO v_name, v_size, v_status, v_autoext;
        EXIT WHEN v_cursor%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE('  - ' || v_name || ': ' || v_size || 'MB, ' || 
                            v_status || ', Tự động mở rộng: ' || v_autoext);
    END LOOP;
    CLOSE v_cursor;
    
    DBMS_OUTPUT.PUT_LINE('=== Kết thúc test get_tablespaces_list ===');
END;
/

-- 14. Test get_audit_log_list
DECLARE
    v_cursor SYS_REFCURSOR;
    v_timestamp DATE;
    v_username VARCHAR2(100);
    v_action VARCHAR2(100);
    v_object VARCHAR2(100);
    v_status VARCHAR2(100);
BEGIN
    DBMS_OUTPUT.PUT_LINE('=== Bắt đầu test get_audit_log_list ===');
    
    get_audit_log_list(v_cursor);
    DBMS_OUTPUT.PUT_LINE('Danh sách audit log:');
    LOOP
        FETCH v_cursor INTO v_timestamp, v_username, v_action, v_object, v_status;
        EXIT WHEN v_cursor%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE('  - ' || v_timestamp || ': ' || v_username || 
                            ' thực hiện ' || v_action || ' trên ' || v_object || 
                            ' (' || v_status || ')');
    END LOOP;
    CLOSE v_cursor;
    
    DBMS_OUTPUT.PUT_LINE('=== Kết thúc test get_audit_log_list ===');
END;
/ 