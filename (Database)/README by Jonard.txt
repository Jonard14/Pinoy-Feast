For DBClass.cs file:
For request, call this variable IP_DB then change IP_DB to your IP address of your current network via cmd (ipconfig command)
e.g. (HttpWebRequest)WebRequest.Create(IP_DB + "update.php?name=" + name + "&status=" + status)

=================================
Use XAMPP for local DB
-Run Apache & MySQL

Database name: foodinfo

To create table, I have provided the SQL files in this folder.
After creating database, select your database (foodinfo), then go to SQL tab.
Once your're there, select the sql file (e.g. fooddata.sql), open as notepad or programming editor like Notepad++.
Copy everything, then paste it to your SQL (phpMyAdmin), and click Go.
There you go you have created the table and its existing data I have.

If you want to backup/get the SQL statements of the table from phpMyAdmin you can export it.
Select table (e.g. useracount), click Export tab, and then click Export.
This will generate a SQL file and save in your computer and if you want to execute it, follow steps above.
*(This is also the same case if you select the database then export which will generate a single SQL file containing all of your tables in your database)


For htdocs, i made a folder named "IT123P-MPGrp7-Food". Place it to your htdocs folder.
*I have modified the codes in php files. You can check it out.


