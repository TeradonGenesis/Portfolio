/* DROP the tables if they already exist */
drop table Student cascade constraints;
drop table Instructor cascade constraints;
drop table Class cascade constraints;
drop table Took cascade constraints;
/* Create the schema for our tables */
create table Student(
studID varchar2(6) primary key, 
name varchar2(10), 
major varchar2(20)
);
create table Instructor(
instID varchar2(6) primary key, 
dept varchar2(20)
);
create table Class(
classID varchar2(6) primary key, 
univ varchar2(30), 
region varchar2(10), 
country varchar2(10)
);
create table Took(
Tnumber number primary key,
studID varchar2(6) , 
instID varchar2(6) , 
classID varchar2(6) , 
score number,
foreign key (studID)references Student,
foreign key (instID)references Instructor,
foreign key (classID)references Class

);

/* Populate the tables with our data */
insert into Student values ('stud1', 'Amy', 'CS');
insert into Student values ('stud2', 'Brian', 'CS');
insert into Student values ('stud3', 'Carol', 'CS');
insert into Student values ('stud4', 'David', 'CS');
insert into Student values ('stud5', 'Emily', 'EE');
insert into Student values ('stud6', 'Frank', 'EE');

insert into Instructor values ('inst1', 'CS');
insert into Instructor values ('inst2', 'EE');
insert into Instructor values ('inst3', 'CS');
insert into Instructor values ('inst4', 'EE');
insert into Instructor values ('inst5', 'EE');

insert into Class values ('class1', 'Stanford', 'CA', 'USA');
insert into Class values ('class2', 'Stanford', 'CA', 'USA');
insert into Class values ('class3', 'Berkeley', 'CA', 'USA');
insert into Class values ('class4', 'MIT', 'MA', 'USA');
insert into Class values ('class5', 'MIT', 'MA', 'USA');
insert into Class values ('class6', 'McGill', 'Quebec', 'Canada');
insert into Class values ('class7', 'McGill', 'Quebec', 'Canada');
insert into Class values ('class8', 'Toronto', 'Ontario', 'Canada');
insert into Class values ('class9', 'Waterloo', 'Ontario', 'Canada');

drop sequence enrolnum;
create sequence enrolnum
minvalue 0
start with 0
increment by 1;

insert into Took values (enrolnum.nextval,'stud1', 'inst1', 'class1', 70);
insert into Took values (enrolnum.nextval,'stud1', 'inst1', 'class2', 75);
insert into Took values (enrolnum.nextval,'stud1', 'inst1', 'class3', 80);
insert into Took values (enrolnum.nextval,'stud1', 'inst1', 'class5', 85);
insert into Took values (enrolnum.nextval,'stud1', 'inst2', 'class1', 90);
insert into Took values (enrolnum.nextval,'stud1', 'inst2', 'class8', 95);
insert into Took values (enrolnum.nextval,'stud1', 'inst2', 'class3', 90);
insert into Took values (enrolnum.nextval,'stud1', 'inst2', 'class2', 85);
insert into Took values (enrolnum.nextval,'stud1', 'inst3', 'class7', 80);
insert into Took values (enrolnum.nextval,'stud1', 'inst3', 'class9', 75);
insert into Took values (enrolnum.nextval,'stud2', 'inst3', 'class8', 60);
insert into Took values (enrolnum.nextval,'stud2', 'inst1', 'class9', 65);
insert into Took values (enrolnum.nextval,'stud2', 'inst2', 'class5', 70);
insert into Took values (enrolnum.nextval,'stud2', 'inst2', 'class3', 75);
insert into Took values (enrolnum.nextval,'stud2', 'inst2', 'class6', 80);
insert into Took values (enrolnum.nextval,'stud2', 'inst2', 'class4', 85);
insert into Took values (enrolnum.nextval,'stud2', 'inst2', 'class7', 90);
insert into Took values (enrolnum.nextval,'stud2', 'inst2', 'class1', 95);
insert into Took values (enrolnum.nextval,'stud2', 'inst2', 'class7', 95);
insert into Took values (enrolnum.nextval,'stud2', 'inst2', 'class8', 90);
insert into Took values (enrolnum.nextval,'stud3', 'inst2', 'class2', 85);
insert into Took values (enrolnum.nextval,'stud3', 'inst2', 'class8', 80);
insert into Took values (enrolnum.nextval,'stud3', 'inst2', 'class5', 75);
insert into Took values (enrolnum.nextval,'stud3', 'inst2', 'class3', 70);
insert into Took values (enrolnum.nextval,'stud3', 'inst3', 'class5', 65);
insert into Took values (enrolnum.nextval,'stud3', 'inst3', 'class2', 60);
insert into Took values (enrolnum.nextval,'stud3', 'inst3', 'class8', 75);
insert into Took values (enrolnum.nextval,'stud3', 'inst3', 'class9', 80);
insert into Took values (enrolnum.nextval,'stud3', 'inst3', 'class3', 85);
insert into Took values (enrolnum.nextval,'stud3', 'inst3', 'class5', 90);
insert into Took values (enrolnum.nextval,'stud4', 'inst3', 'class1', 95);
insert into Took values (enrolnum.nextval,'stud4', 'inst3', 'class7', 90);
insert into Took values (enrolnum.nextval,'stud4', 'inst3', 'class8', 85);
insert into Took values (enrolnum.nextval,'stud4', 'inst3', 'class2', 80);
insert into Took values (enrolnum.nextval,'stud4', 'inst3', 'class8', 75);
insert into Took values (enrolnum.nextval,'stud4', 'inst3', 'class2', 70);
insert into Took values (enrolnum.nextval,'stud4', 'inst4', 'class3', 75);
insert into Took values (enrolnum.nextval,'stud4', 'inst4', 'class5', 80);
insert into Took values (enrolnum.nextval,'stud4', 'inst4', 'class3', 85);
insert into Took values (enrolnum.nextval,'stud4', 'inst4', 'class5', 90);
insert into Took values (enrolnum.nextval,'stud5', 'inst4', 'class6', 95);
insert into Took values (enrolnum.nextval,'stud5', 'inst4', 'class4', 90);
insert into Took values (enrolnum.nextval,'stud5', 'inst4', 'class6', 85);
insert into Took values (enrolnum.nextval,'stud5', 'inst4', 'class4', 80);
insert into Took values (enrolnum.nextval,'stud5', 'inst4', 'class9', 75);
insert into Took values (enrolnum.nextval,'stud5', 'inst4', 'class7', 60);
insert into Took values (enrolnum.nextval,'stud5', 'inst4', 'class1', 65);
insert into Took values (enrolnum.nextval,'stud5', 'inst4', 'class8', 70);
insert into Took values (enrolnum.nextval,'stud5', 'inst5', 'class9', 75);
insert into Took values (enrolnum.nextval,'stud5', 'inst5', 'class8', 80);
insert into Took values (enrolnum.nextval,'stud6', 'inst5', 'class3', 85);
insert into Took values (enrolnum.nextval,'stud6', 'inst5', 'class5', 90);
insert into Took values (enrolnum.nextval,'stud6', 'inst2', 'class3', 95);
insert into Took values (enrolnum.nextval,'stud6', 'inst2', 'class6', 90);
insert into Took values (enrolnum.nextval,'stud6', 'inst3', 'class4', 85);
insert into Took values (enrolnum.nextval,'stud6', 'inst3', 'class6', 80);
insert into Took values (enrolnum.nextval,'stud6', 'inst4', 'class4', 75);
insert into Took values (enrolnum.nextval,'stud6', 'inst4', 'class6', 70);
insert into Took values (enrolnum.nextval,'stud6', 'inst5', 'class4', 65);
insert into Took values (enrolnum.nextval,'stud6', 'inst5', 'class6', 60);

-- Display tables

SELECT * FROM STUDENT;
SELECT * FROM INSTRUCTOR;
SELECT * FROM CLASS;
SELECT * FROM TOOK;

--Find all students who took a class in California from an instructor not in the student's major department and got a score over 80. Return the student name, university, and score.

SELECT NAME, UNIV, SCORE 
FROM STUDENT 
JOIN TOOK 
ON STUDENT.STUDID = took.studid
INNER JOIN INSTRUCTOR
ON INSTRUCTOR.INSTID = took.INSTID
INNER JOIN CLASS
on class.classid = took.classid
where CLASS.REGION = 'CA' AND STUDENT.MAJOR != INSTRUCTOR.DEPT AND TOOK.SCORE >80;

--Find average scores grouped by student and instructor for courses taught in Quebec. Use two decimal points.

SELECT T.STUDID, T.INSTID, ROUND(AVG(T.SCORE),2) AS AVGSCORE
FROM TOOK T
JOIN STUDENT S
ON T.studid = S.STUDID
INNER JOIN INSTRUCTOR I
ON T.INSTID = I.INSTID
INNER JOIN CLASS C
on T.classid = C.classid
where C.REGION = 'Quebec'
GROUP BY (T.STUDID, T.INSTID)
ORDER BY T.STUDID;

--"Roll up" your result from problem 2 so it's grouping by instructor only.

SELECT I.INSTID, ROUND(AVG(T.SCORE),2) AS AVGSCORE
FROM TOOK T
--JOIN STUDENT S
--ON T.studid = S.STUDID
INNER JOIN INSTRUCTOR I
ON T.INSTID = I.INSTID
INNER JOIN CLASS C
on T.classid = C.classid
where C.REGION = 'Quebec'
GROUP BY  (I.INSTID)
ORDER BY T.INSTID;

--Find average scores grouped by student major.

SELECT S.MAJOR, ROUND(AVG(T.SCORE),3) AS AVGSCORE
FROM STUDENT S
INNER JOIN TOOK T
ON S.STUDID = T.STUDID
GROUP BY S.MAJOR
ORDER BY S.MAJOR;

-- "Drill down" on your result from problem 4 so it's grouping by instructor's department as well as student's major.

SELECT S.MAJOR, I.DEPT, ROUND(AVG(T.SCORE),3) AS AVGSCORE
FROM TOOK T
INNER JOIN STUDENT S
ON T.STUDID = S.STUDID
INNER JOIN INSTRUCTOR I
ON T.INSTID = I.INSTID
GROUP BY (I.DEPT,S.MAJOR)
ORDER BY S.MAJOR;

-- Use "ROLLUP" on attributes of table Class to get average scores for allgeographical granularities: by country, region, and university, as well asthe overall average.
SELECT C.COUNTRY, C.REGION, C.UNIV, ROUND(AVG(T.SCORE), 2) AS AVGSCORE
FROM CLASS C
INNER JOIN TOOK T
ON C.CLASSID = T.CLASSID
GROUP BY ROLLUP (COUNTRY, REGION, UNIV)
ORDER BY COUNTRY, REGION;

-- Modify question 6, this time use cube and note the difference.
SELECT C.COUNTRY, C.REGION, C.UNIV, ROUND(AVG(DISTINCT T.SCORE), 2) AS AVGSCORE
FROM CLASS C
INNER JOIN TOOK T
ON C.CLASSID = T.CLASSID
GROUP BY CUBE (COUNTRY, REGION, UNIV)
ORDER BY COUNTRY, REGION;

-- Create a view (STUDENTSCORE) containing the result of your query from problem 6. Then use the view to determine by how much students from USA outperform students from Canada in their average score.
CREATE VIEW STUDENTSCORE AS
SELECT C.COUNTRY, C.REGION, C.UNIV, ROUND(AVG(T.SCORE), 2) AS AVGSCORE
FROM CLASS C
INNER JOIN TOOK T
ON C.CLASSID = T.CLASSID
GROUP BY ROLLUP (COUNTRY, REGION, UNIV)
ORDER BY COUNTRY, REGION;

SELECT * FROM STUDENTSCORE;

SELECT AVGSCORE - (SELECT AVGSCORE FROM STUDENTSCORE WHERE COUNTRY = 'Canada' AND REGION IS NULL AND UNIV IS NULL) AS Difference
FROM STUDENTSCORE
WHERE COUNTRY = 'USA' AND REGION IS NULL AND UNIV IS NULL;

--Use “CUBE” to get the average scores for all students by instructors andclasses.
SELECT I.INSTID, C.CLASSID, S.STUDID, ROUND(AVG(DISTINCT T.SCORE), 2) AS AVGSCORE
FROM TOOK T
INNER JOIN INSTRUCTOR I
ON T.INSTID = I.INSTID
INNER JOIN CLASS C
ON T.CLASSID = C.CLASSID
INNER JOIN STUDENT S
ON T.STUDID = S.STUDID
GROUP BY CUBE (I.INSTID, C.CLASSID, S.STUDID)
ORDER BY I.INSTID;

--Create a view based on the query in question 9. Call it SCORECUBE.
CREATE VIEW SCORECUBE AS
SELECT I.INSTID, C.CLASSID, S.STUDID, ROUND(AVG(DISTINCT T.SCORE), 2) AS AVGSCORE
FROM TOOK T
INNER JOIN INSTRUCTOR I
ON T.INSTID = I.INSTID
INNER JOIN CLASS C
ON T.CLASSID = C.CLASSID
INNER JOIN STUDENT S
ON T.STUDID = S.STUDID
GROUP BY CUBE (I.INSTID, C.CLASSID, S.STUDID)
ORDER BY I.INSTID;


SELECT ROUND(AVG (A.AVGSCORE)) AS STUAVERAGE
FROM SCORECUBE A
JOIN STUDENT S
ON A.STUDID = S.STUDID
INNER JOIN CLASS C
ON A.CLASSID = C.CLASSID
WHERE S.MAJOR ='CS' AND C.UNIV ='MIT';


