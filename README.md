 # .NET Menu CRUD and Billing Project
 This project demonstrates CRUD(Create, Read,  Update, Delete) operations for managing items in a Menu. Also has abiliy to generate bill form item present in the menu.

 ## Setup Instructions

 ### 1. Configure Cnnection String
 1. Locate the `appsettings.json` file in project directory.
 2. Open `appsettings.json` and find the  `ConnectionStrings` section.
   
   ```json
    {
         "ConnectionStrings": {
            "MenuItems": "Data Source=<your_server>;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Database=Menu"
     }
    }
   ```
   Only makes changes on `Data Source = <your_server>`

### 2. Update Database
Migration is already created in the project directory so you just need to run it.
- Assuming you are using Visual Studio to run the project, got to **Tools>NuGet Package Manager>Package Manager Console**
- Write the command then press **Enter Key**

```
PM> Update-Database
```

### 3. Run the project