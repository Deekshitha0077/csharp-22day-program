--Assignment-1
--1st question
SELECT 
    p.FullName,
    d.Name,
    COUNT(e.EncounterId) AS TotalEncounterTaken,
	RANK() 
	OVER (ORDER BY COUNT(e.EncounterId) desc) as Volrank
FROM Provider p 
LEFT JOIN Encounter e 
    ON e.ProviderId=p.ProviderId
LEFT JOIN Department d
    ON p.DepartmentId = d.DepartmentId
GROUP BY p.FullName,d.Name;

--2nd question

--add columns validFrom and validTo
use CareBridgeDB
GO
ALTER TABLE Insurance
ADD
    ValidFrom DATETIME2
        GENERATED ALWAYS AS ROW START HIDDEN
        CONSTRAINT DF_Insurance_From
        DEFAULT SYSUTCDATETIME(),

    ValidTo DATETIME2
        GENERATED ALWAYS AS ROW END HIDDEN
        CONSTRAINT DF_Insurance_To
        DEFAULT '9999-12-31 23:59:59.9999999',

    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo);

--add versioning

ALTER TABLE Insurance
SET (
    SYSTEM_VERSIONING = ON
    (
        HISTORY_TABLE = dbo.Insurance_History
    )
);

select * from Insurance where InsuranceId=1;--before payer was Max Bupa

--change payer to HDFC ERGO

UPDATE Insurance SET Payer='HDFC ERGO' where InsuranceId=1;

SELECT
    InsuranceId,
    [Payer],
	[PolicyNumber],
    ValidFrom,
    ValidTo
FROM Insurance
FOR SYSTEM_TIME ALL
WHERE InsuranceId = 1
ORDER BY ValidFrom;

--3rd Question
CREATE OR ALTER VIEW BillingView AS
SELECT 
    ClaimId,
    Status,
    BilledAmount,
    ReimbursedAmt,
    (BilledAmount - ReimbursedAmt) AS Outstanding
FROM Claim;
CREATE OR ALTER PROCEDURE sp_MonthlyBillingReport
AS
BEGIN
    SELECT 
        Status,
        COUNT(ClaimId) AS TotalClaims,
        SUM(BilledAmount) AS TotalBilledAmount,
        SUM(ReimbursedAmt) AS TotalReimbursedAmt,
        SUM(BilledAmount) - SUM(ReimbursedAmt) AS Outstanding,
        RANK() OVER (
            ORDER BY (SUM(BilledAmount) - SUM(ReimbursedAmt)) DESC
        ) AS LossRank
    FROM BillingView
    GROUP BY Status;
END;


EXEC sp_MonthlyBillingReport;


--4th question
CREATE OR ALTER PROCEDURE sp_BoardMeetingDashborad
AS
BEGIN

SELECT COUNT(IsActive)AS TotalActivePatients
FROM Patient where IsActive=1;

SELECT TOP 5 D.Name AS DepartmentName,
COUNT(E.EncounterId) AS TotalEncounters
FROM Department D JOIN Encounter E
ON D.DepartmentId=E.DepartmentId
GROUP BY D.Name ORDER BY (TotalEncounters) DESC;

SELECT 
    AVG(DATEDIFF(DAY, AdmitDate, DischargeDate)) AS AverageStay
FROM Encounter
WHERE DischargeDate IS NOT NULL;

END;
EXEC sp_BoardMeetingDashborad;

--5th question
--add stored procudures for High-risk Patients and Provider workload Report

CREATE OR ALTER PROCEDURE sp_HighRiskPatients
AS
BEGIN

SELECT 
    P.PatientId,
    P.FullName
FROM Patient P
JOIN Encounter E 
    ON P.PatientId = E.PatientId
JOIN [dbo].[Procedure] D 
    ON E.EncounterId = D.EncounterId
WHERE D.Description LIKE '%Critical care%'
GROUP BY P.PatientId,P.FullName;


END;
EXEC sp_HighRiskPatients;

--ading sp_ProviderWorkload

CREATE OR ALTER Procedure sp_ProviderWorkload
AS
SELECT 
    p.FullName,
    d.Name,
    COUNT(e.EncounterId) AS TotalEncounterTaken,
	RANK() 
	OVER (ORDER BY COUNT(e.EncounterId) desc) as Volrank
FROM Provider p 
LEFT JOIN Encounter e 
    ON e.ProviderId=p.ProviderId
LEFT JOIN Department d
    ON p.DepartmentId = d.DepartmentId
GROUP BY p.FullName,d.Name;

exec sp_ProviderWorkload;

--6th question

--creating a view for analytics;
 
CREATE OR ALTER VIEW vw_Analytics
AS
SELECT
    e.EncounterId,
    CASE
        WHEN DATEDIFF(YEAR, pt.DateOfBirth, GETDATE()) < 18 THEN '0-17'
        WHEN DATEDIFF(YEAR, pt.DateOfBirth, GETDATE()) < 65 THEN '18-64'
        ELSE '65+'
    END AS AgeBand,
    pt.Gender,
    e.EncounterType,
    e.DepartmentId
FROM Patient pt
JOIN Encounter e
    ON e.PatientId = pt.PatientId;
