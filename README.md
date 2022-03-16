# Overview
Performance test for Dapper vs NHibernate is done using BenchmarkDotNet.

BenchmarkDotNet allows you to turn your methods into benchmarks, track their performance, and share reproducible measurement experiments. It is a lightweight, open-source .NET library.

## References to learn using BenchmarkDotNet
  1. https://www.infoworld.com/article/3573782/how-to-benchmark-csharp-code-using-benchmarkdotnet.html
  2. https://www.c-sharpcorner.com/blogs/benchmark-using-benchmarkdotnet

# In Our Project -
## Technologies used:
  1. MySQL 5.7
  2. HeidiSQL - HeidiSQL is a free and open-source administration tool for MySQL and its forks, as well as Microsoft SQL Server, PostgreSQL and SQLite.
  3. .Net Core 3.1
  4. Visual Studio

## Following steps should be followed to run the project.

  1. Firstly, we will need to create a database. <br />
     a. For this, we need to setup MySQL connection on HeidiSql <br />
      ![image](https://user-images.githubusercontent.com/101630934/158521700-8784e8cb-2876-446f-b208-2d27b33bb15a.png) <br /><br />
     b. Then, navigate to File - Run SQL File and select the sql file present on Database Folder of the project. <br />
      ![image](https://user-images.githubusercontent.com/101630934/158522220-9ea4368f-20e3-4aa7-8e2b-d6f4a38c9bed.png) <br /><br />
     c. Lastly, click on Open button and the database will be created. <br />
     
  2. Secondly, Open the project on visual studio <br />
  3. Change the connection string on app.config file <br />
    ![image](https://user-images.githubusercontent.com/101630934/158523938-83855433-7655-45d1-86f2-633f61d1ce19.png) <br /><br />
   
  4. Right click on the solution and build the project <br />
  5. Then go to the terminal and run following command <br />
     ![image](https://user-images.githubusercontent.com/101630934/158523036-6d3c1e47-73f3-42dc-bef6-4e6430ba5b97.png) <br /><br />
  6. Finally, You will see the result on the terminal. <br />
    ![image](https://user-images.githubusercontent.com/101630934/158559269-835fd9ed-976e-4895-8644-19b8e14f2e29.png) <br /><br />

 

