CREATE PROCEDURE InsertEmployee
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Salary DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Employee (FirstName, LastName, Salary)
    VALUES (@FirstName, @LastName, @Salary);
END;


CREATE PROCEDURE UpdateEmployee
    @EmployeeID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Salary DECIMAL(18, 2)
AS
BEGIN
    UPDATE Employee
    SET FirstName = @FirstName, LastName = @LastName, Salary = @Salary
    WHERE EmployeeID = @EmployeeID;
END;


CREATE PROCEDURE DeleteEmployee
    @EmployeeID INT
AS
BEGIN
    DELETE FROM Employee
    WHERE EmployeeID = @EmployeeID;
END;


CREATE PROCEDURE GetAllEmployees
AS
BEGIN
    SELECT * FROM Employee;
END;
