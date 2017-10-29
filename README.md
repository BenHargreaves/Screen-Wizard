# Screen-Wizard
A "No-Code" solution allowing users to create template List and Edit screens to visualize their data. Drawn heavily from experience in the CRM sector.

## Software Requirements
<ul>
<li>Microsoft Visual Studio 2017 (Will likely work on earlier versions, but havent tested!)</li>
<li>MongoDB 3.4</li>
</ul>

## NuGet Project Dependencies (Built into solution file)
<ul>
<li>AngularJS Core 1.6.4</li>
<li>AngularJS Route 1.6.4</li>
<li>AngularJS Messages 1.6.4</li>
<li>jQuery v3.1.1</li>
<li>Bootstrap v4</li>
<li>MongoDB .NET Driver 2.4.4</li>
</ul>


## Setup and Installation
<ul>
<li>Fork & Clone</li>
<li>Build project in Visual Studio to fetch NuGet dependencies</li>
<li>Set Project "ScreenWizard" as Startup Project</li>
<li>Set 'Index.Html' as Startup Page</li>
<li>Start MongoDB server - mongod.exe</li>
<li>Open MongoDB Shell - mongo.exe</li>
<li>Run Mongo Seed Commands (See "Mongo Seed Commands" below)</li>
</ul>

## Mongo Seed Commands
Use the following commands in the MongoShell to seed the MongoDB instance with the correct data before running the project for the first time.

Creating the DB
```js
use ScreenWizard
```

Defining Collection Names
```js
db.createCollection("Customer")
db.createCollection("Activity")
db.createCollection("Invoice")
```

Defining the Field MetaData - used internally for display purposes
```js
db.FieldMetadata.insertMany ([
  {Table : "Customer", Name : "CustomerId", Type : "Int", DisplayType : "number", IsRequired : true},
  {Table : "Customer", Name : "Name", Type : "String", DisplayType : "text", IsRequired : true},
  {Table : "Customer", Name : "Email", Type : "Email", DisplayType : "email", IsRequired : false},
  {Table : "Customer", Name : "ContactNumber", Type : "Phone", DisplayType : "tel", IsRequired : false},
  {Table : "Customer", Name : "DateCreated", Type : "Date", DisplayType : "datetime-local", IsRequired : false},
  {Table : "Customer", Name : "Website", Type : "String", DisplayType : "text", IsRequired : false},
  {Table : "Customer", Name : "Notes", Type : "String", DisplayType : "text", IsRequired : false},
  {Table : "Invoice", Name : "CustomerName", Type : "String", DisplayType : "text", IsRequired : true},
  {Table : "Invoice", Name : "CustomerID", Type : "Int", DisplayType : "text", IsRequired : false},
  {Table : "Invoice", Name : "InvoiceNumber", Type : "Int", DisplayType : "number", IsRequired : false},
  {Table : "Invoice", Name : "AddressLine1", Type : "String", DisplayType : "text", IsRequired : false},
  {Table : "Invoice", Name : "AddressLine2", Type : "String", DisplayType : "text", IsRequired : false},
  {Table : "Invoice", Name : "City", Type : "String", DisplayType : "text", IsRequired : false},
  {Table : "Invoice", Name : "PostCode", Type : "String", DisplayType : "text", IsRequired : false},
  {Table : "Invoice", Name : "DueDate", Type : "Date", DisplayType : "datetime-local", IsRequired : false},
  {Table : "Invoice", Name : "Balance", Type : "Currency", DisplayType : "number", IsRequired : false},
  {Table : "Invoice", Name : "InvoiceItems", Type : "List", DisplayType : "list", IsRequired : false, ItemDetails: 
    [{Name:"Name"}, {Name:"Price"}, {Name:"Quantity"}, {Name:"Discount"}, {Name:"Subtotal"}]},
  {Table : "Invoice", Name : "Total", Type : "Currency", DisplayType : "number", IsRequired : false},
  {Table: "Activity", Name: "Title", Type: "String", DisplayType:"text", IsRequired: false},
  {Table: "Activity", Name: "Description", Type: "String", DisplayType:"text", IsRequired: false},
  {Table: "Activity", Name: "StartDate", Type: "Date", DisplayType:"datetime-local", IsRequired: false},
  {Table: "Activity", Name: "EndDate", Type: "Date", DisplayType:"datetime-local", IsRequired: false}
]);
```


