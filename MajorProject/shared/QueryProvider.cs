namespace MajorProject.shared
{
    public class QueryProvider
    {
       static string q = "";
        public static string queryselectorhod(string s)
        {
            if (s == "student")
                q = "select g.username as Username,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name,r.name as reason,g.outtime,g.intime ,d.name as department,cl.sem as sem from student s join gatepass g on s.studentid=g.username join reason r on g.reasonid=r.reasonid join classes cl on s.classid=cl.classid join department d on cl.departmentid=d.departmentid where s.classid in (select classid from classes where departmentid in (select departmentid from headofdepartment where headofdepartmentid=@id) ) ";
            else if (s == "approvepassstudent")
                q = "select * from student s join requestedpass r on s.studentid=r.username join reason re on r.reasonid=re.reasonid where s.classid in (select classid from classcounsellor where onleave=1 and classid in (select classid from classes where departmentid in(select departmentid from headofdepartment where headofdepartmentid=@id))) and DATE_FORMAT(createdtime, '%d/%m/%Y')=DATE_FORMAT(current_timestamp, '%d/%m/%Y') ";
            else if (s == "approvepassprofessor")
                q = "select r.requestedpassid as id,p.professorid,concat(first_name,' ',middle_name,' ',surname) as name,createdtime,re.name,d.name from professor p join login l on p.professorid=l.username join department d on p.departmentid=d.departmentid join requestedpass r on p.professorid=r.username join reason re on r.reasonid=re.reasonid where  l.accesstype in ('c','p') and p.departmentid in (select departmentid from headofdepartment where headofdepartmentid=@id) and DATE_FORMAT(createdtime, '%d/%m/%Y')=DATE_FORMAT(current_timestamp, '%d/%m/%Y') ";
            else if (s == "professor")
                q = "select p.professorid,concat(first_name,' ',middle_name,' ',surname) as name,re.name as reason,outtime,intime from professor p join login l on p.professorid=l.username join department d on p.departmentid=d.departmentid join gatepass r on p.professorid=r.username join reason re on r.reasonid=re.reasonid where  l.accesstype in ('c','p') and p.departmentid in (select departmentid from headofdepartment where headofdepartmentid=@id)";
            else
                q = "";
           return q;
        }
         public static string updateQuerySelector(string s)
         {
            if (s == "studentccg")
                q = "select s.studentid Username,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name from student s join classes cl on s.classid=cl.classid join department d on cl.departmentid=d.departmentid where s.classid in (select classid from classes where departmentid in (select departmentid from headofdepartment where headofdepartmentid=@id)) ";
            else if (s == "professorccg")
                q = "select s.professorid as Username,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name,d.name as Department from professor s join department d on s.departmentid=d.departmentid where s.departmentid in (select departmentid from headofdepartment where headofdepartmentid=@id) and s.professorid not in (@id);";
            else if (s == "classccg")
                q = "SELECT d.name,c.sem,c.division from classes c join department d on c.departmentid=d.departmentid where c.departmentid in (SELECT departmentid from headofdepartment where headofdepartmentid=@id) ORDER by c.sem,c.division";
            else if (s == "departmentccg")
                q = "SELECT name from department where departmentid in (SELECT departmentid from headofdepartment where headofdepartmentid=@id)";
            else if (s == "updatecctop")
                q = "select s.professorid as Username,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name from professor s join department d on s.departmentid=d.departmentid join login l on s.professorid=l.username where l.accesstype='c' and s.departmentid in (select departmentid from headofdepartment where headofdepartmentid=@id);";
            else if (s == "updateptocc")
                q = "select s.professorid as Username,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name from professor s join department d on s.departmentid=d.departmentid join login l on s.professorid=l.username where l.accesstype='p' and s.departmentid in (select departmentid from headofdepartment where headofdepartmentid=@id);\r\n";
            return q;
         }  
         
        public static string queryselectorcc(string s)
        {
            if (s == "student")
                q = "select g.username as username,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name,r.name reason,g.outtime,g.intime ,cl.sem,cl.division from student s join gatepass g on s.studentid=g.username join reason r on g.reasonid=r.reasonid join classes cl on s.classid=cl.classid where cl.classid in (select classid from classcounsellor where classcounsellorid=@id) and Date_FORMAT(createdtime, 'dd-MM-yyyy')=Date_FORMAT(current_timestamp, 'dd-MM-yyyy')";
            else if (s == "approvepassstudent")
                q = "select requestedpassid as id, r.username as Username,concat(s.first_name,' ',s.middle_name,' ',s.surname)as Name,createdtime,re.name as reason,cl.sem,division from student s join requestedpass r on s.studentid=r.username join reason re on r.reasonid=re.reasonid join classes cl on s.classid=cl.classid where s.classid in (select classid from classcounsellor where classcounsellorid=@id) and DATE_FORMAT(createdtime, '%d/%m/%Y')=DATE_FORMAT(current_timestamp, '%d/%m/%Y')";
            else
                q = "";
            return q;
        }
        public static string gaurdSelectQuery(string s)
        {
            if (s == "updatedeparturestudent")
            {
                q = "select g.gatepassid as id,s.studentid as PRN,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name,r.name as Reason ,c.name as College,d.name as Department,cl.sem as Sem from student s  join gatepass g on s.studentid=g.username join reason r on g.reasonid=r.reasonid join classes cl on s.classid=cl.classid join department d on cl.departmentid=d.departmentid join college c on d.collegeid=c.collegeid where s.studentid in (select username from gatepass g ) and g.outtime is null and DATE_FORMAT(createdtime, '%d/%m/%Y')=DATE_FORMAT(current_timestamp, '%d/%m/%Y') ";
            }
            else if (s == "updatearrivalstudent")
            {
                q = "select g.gatepassid as id,s.studentid as PRN,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name,r.name as Reason ,c.name as College,d.name as Department,cl.sem as Sem from student s  join gatepass g on s.studentid=g.username join reason r on g.reasonid=r.reasonid join classes cl on s.classid=cl.classid join department d on cl.departmentid=d.departmentid join college c on d.collegeid=c.collegeid where s.studentid in (select username from gatepass g) and g.reasonid in(2,3,5) and g.outtime is not null and g.intime is NULL and DATE_FORMAT(createdtime, '%d/%m/%Y')=DATE_FORMAT(current_timestamp, '%d/%m/%Y')";
            }
            else if (s == "updatedepartureprofessor")
            {
                q = "select g.gatepassid as id,s.professorid ,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name,r.name as Reason ,c.name as College,d.name as Department from professor s  join gatepass g on s.professorid=g.username join reason r on g.reasonid=r.reasonid join department d on s.departmentid=d.departmentid join college c on d.collegeid=c.collegeid where s.professorid in (select username from gatepass g ) and g.outtime is null and DATE_FORMAT(createdtime, '%d/%m/%Y')=DATE_FORMAT(current_timestamp, '%d/%m/%Y')";
            }
            else if (s == "updatearrivalprofessor")
            {
                q = "select g.gatepassid as id,s.professorid,concat(s.first_name,' ',s.middle_name,' ',s.surname)  as Name,r.name as Reason ,c.name as College,d.name as Department from professor s  join gatepass g on s.professorid=g.username join reason r on g.reasonid=r.reasonid join department d on s.departmentid=d.departmentid join college c on d.collegeid=c.collegeid where s.professorid in (select username from gatepass g ) and DATE_FORMAT(createdtime, '%d/%m/%Y')=DATE_FORMAT(current_timestamp, '%d/%m/%Y') and g.reasonid in(2,3,5) and g.outtime is not null and g.intime is NULL";
            }
            else
            {
                q = "";
            }
            return q;
        }
        public static string gaurdQuery(string s)
        {
            if (s.Contains("departure"))
                q = "update gatepass set outtime=current_timestamp where gatepassid=@p1";
            else if (s.Contains("arrival"))
                q = "update gatepass set intime=current_timestamp where gatepassid=@p1";
            else
                q = "";

            return q;
        }
    }
}