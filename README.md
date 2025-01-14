The application is an ASP.NET Web Application using .NET Framework 4.7.2 My version of Visual Studio 22 is 17.5.5

NB* My passwords for Farmer have been hashed in the database. I have provided their username and passwords if you wish to access their data Below. 
--------------------------------------------------The Farmer Login Details------------------------------------------------------- 
An Employee can add a new farmer

---------------------------------------------------The Employee Login Details----------------------------------------------------
As per Instruction from Task 2. Now new employees can be added
Username: alex.liam.hillary@gmail.com
Password: Alex1522


-----------------------------------------------------Default/Home page----------------------------------------------------------
The application starts on the Default page where the user is expected to login as employee or farmer. There is two corresponding buttons which will redirect the user to their chosen login option.

----------------------------------------------------About Page-------------------------------------------------------------------
Just display information about Farm Central to the User

-------------------------------------------------------Contact Page--------------------------------------------------------------
Just displays dummy data relating to address, email and phone number for Farm Central

-------------------------------------------------------Login Pages for Employee and Farmer--------------------------------------- 
On those login pages for either farmer or employee, the user will be expected to enter their username and password. If the user has entered the correct username and password they will be redirected to the either the employee or farmer dashboard. 

-------------------------------------------------------Farmer Dashboard----------------------------------------------------------
In the Farmer dashboard, the user will be able to add products to their profile. When entering the product barcode, The user may only enter a int and not strings for ProductBarcode. (*NB The ProductBarcode is a primary key in my FarmerProductsTable so the user must not add duplicate ProductBarcode's).  Once the user has entered all their relevant products details in the textboxes and click the button called ADD products where the data will be stored at in the database. 

-------------------------------------------------------Employee Dashboard--------------------------------------------------------
The Employee Dashboard will allow the employee to click the Add farmer where they will be redirected to add a new farmer to the database. If the employee wishes to see all the asociated products for a specific farmer, they must select the farmer username from the drop down list and click the View Products button to display their prducts. If the employee wishes to filter, they can select the second drop down list to filter by product where they can either select 'Vegetables', 'Dairy', 'Grains' and click filter to diplay the filtered prducts.

-------------------------------------------------------Database Class------------------------------------------------------------
In My Databaser class is where i have all the necessary queries in various methods to execute certain actions such as inserting into Database Table as well as retrieving d certain Data. This class is called throughout the project.

------------------------------------------------------Password Encryption Class--------------------------------------------------
This class has one method which hashes a password.This class is called in various other .cs files.

-----------------------------------------------------------Database--------------------------------------------------------------
Within my Database i have 6 Tables called FarmerTable, EmployeeTable, FarmerProductsTable, VegetableTable, DairyTable and GrainsTable. The FarmerProductsTable has two foreign keys. 1 for FarmerUsername and the other for EmployeeUsername. I also have The ProductsBarcode (PK in FarmerProductsTable) as a foreign key in VegetaableTable, DairyTable and GrainsTable. 



