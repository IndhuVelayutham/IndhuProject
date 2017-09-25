--use HospitaManagement;
--create schema HospitalManagementSystem;
/*1*/

create table HospitalManagementSystem.RoleTable
( roleId int primary Key,
roleName varchar(30));

/*2*/

create table HospitalManagementSystem.UserTable
(
userId int identity(100, 1) primary Key,
firstName varchar(30),
lastName varchar(30),
userName varchar(30) not null,
password varchar(30) not null,
departmentId int references HospitalManagementSystem.DepartmentTable(departmentId),
roleId int references HospitalManagementSystem.RoleTable(roleId),
creationDate datetime,
gender char (1) check(gender in('F', 'M')));

--drop table HospitalManagementSystem.UserTable;

/*3*/

create table HospitalManagementSystem.PatientTable
(
patientId int identity(1000, 1) primary Key,
patientName varchar(30),
patientAge int,
patientGender char (1) check(patientGender in('F', 'M')),
patientModeId int references HospitalManagementSystem.PatientModeTable(modeId),
patientAddress varchar(50),
patientContactNumber varchar(12));


--drop table HospitalManagementSystem.PatientTable;

/*4*/

create table HospitalManagementSystem.PatientModeTable
(
modeId int primary Key,
modeName varchar(30) not null);

--drop table HospitalManagementSystem.PatientMode;

/*5*/

create table HospitalManagementSystem.DepartmentTable
(
departmentId int primary Key,
departmentName varchar(30));

--drop table HospitalManagementSystem.Department;

/*6*/

create table HospitalManagementSystem.AppointmentTable
(
appointmentId int identity(500, 1) primary key,
userId int references HospitalManagementSystem.UserTable(userId),
patientId int references HospitalManagementSystem.PatientTable(patientId),
appointmentDate dateTime not null);

--drop table HospitalManagementSystem.Appointment;

/*7*/

create table HospitalManagementSystem.TestTable
(
testId varchar(40) primary key,
testName varchar(30),
testCost float);

--drop table HospitalManagementSystem.TestTableTestResultTable;

/*8*/

create table HospitalManagementSystem.TestResultTable
(
testId varchar(40) references HospitalManagementSystem.TestTable(testId),
patientId int references HospitalManagementSystem.PatientTable(patientId),
userId int references HospitalManagementSystem.UserTable(userId),
testResult varchar(40));

/*9*/

create table HospitalManagementSystem.BillingTable
(
billId int identity(5000, 1) primary Key,
patientId int references HospitalManagementSystem.PatientTable(patientId),
itemsName varchar(40),
itemsPrice float,
billDate dateTime);
--drop table HospitalManagementSystem.BillingTable
/*10*/

create table HospitalManagementSystem.ResourcesTable
(
resourceId int identity(100,1) primary key,
resourceName varchar(30),
resourcePrice float);


/*11*/

create table HospitalManagementSystem.ConsultationFeeTable
(
departmentId int references HospitalManagementSystem.DepartmentTable(departmentId),
consultationFee float);