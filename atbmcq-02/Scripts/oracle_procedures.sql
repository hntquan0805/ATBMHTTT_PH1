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
    -- Tạo user mới trong PDB
    EXECUTE IMMEDIATE 'CREATE USER ' || p_username || ' IDENTIFIED BY ' || p_password;
    -- Cấp quyền đăng nhập cho user
    EXECUTE IMMEDIATE 'GRANT CREATE SESSION TO ' || p_username;
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
    -- Tạo role mới trong PDB
    EXECUTE IMMEDIATE 'CREATE ROLE ' || p_rolename;
    -- Cấp quyền đăng nhập cho role
    EXECUTE IMMEDIATE 'GRANT CREATE SESSION TO ' || p_rolename;
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
    EXECUTE IMMEDIATE 'DROP USER ' || p_username || ' CASCADE';
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
    EXECUTE IMMEDIATE 'DROP ROLE ' || p_rolename;
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
    EXECUTE IMMEDIATE 'ALTER USER ' || p_username || ' IDENTIFIED BY ' || p_new_password;
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
            WHERE oracle_maintained = 'N' -- Chỉ hiển thị user do người dùng tạo, không hiển thị user hệ thống
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
            WHERE oracle_maintained = 'N' -- Chỉ hiển thị role do người dùng tạo, không hiển thị role hệ thống
            ORDER BY role;
    ELSE
        OPEN p_cursor FOR
            SELECT username as name, created, 
                   CASE WHEN account_status IS NULL THEN 'OPEN' ELSE account_status END as status,
                   'USER' as type 
            FROM dba_users 
            WHERE oracle_maintained = 'N'
            UNION ALL 
            SELECT role as name,
                   NULL as created,
                   CASE 
                       WHEN authentication_type = 'PASSWORD' THEN 'SECURE ROLE'
                       ELSE 'NORMAL ROLE'
                   END as status,
                   'ROLE' as type 
            FROM dba_roles
            WHERE oracle_maintained = 'N'
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



-- Cấp quyền thực thi cho tất cả các procedure
GRANT EXECUTE ON create_user_proc TO PUBLIC;
GRANT EXECUTE ON create_role_proc TO PUBLIC;
GRANT EXECUTE ON drop_user_proc TO PUBLIC;
GRANT EXECUTE ON drop_role_proc TO PUBLIC;
GRANT EXECUTE ON alter_user_password_proc TO PUBLIC;
GRANT EXECUTE ON grant_privilege_proc TO PUBLIC;
GRANT EXECUTE ON revoke_privilege_proc TO PUBLIC;
GRANT EXECUTE ON get_users_roles_list TO PUBLIC;
GRANT EXECUTE ON get_privileges_list TO PUBLIC;
