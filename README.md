# SimpleCRUD

Sample implementation of CRUD functioanltiy with Repository Pattern defined in Patterns of Enterprise Application Architecture and/or onion architecture.

# Basic ideas are

A Repository mediates between the data. model abd project mapping layers
Mapping code is encapsulated behind the Repository.
Clean separation and on-way dependency between the domain and data mapping layers.
Implementation Details

# Entity
In this sample the following two types of entities are used.

Product - Represents the items or any product.
Order - Represents the order for specific products.
Both of entities inherit from abstract class called FullAuditedEntity.

FullAuditedEntity - base class used for most of the entities and which regulates entities identifier, logs, dates etc.

# Repository
The repository represents the collection of entities.

ProductRepository - Collection of product entity.
OrderRepository - Collection of order entity.
Repository Strategy
There are three types of repository strategies are implemented.

# Model, Dto and Automap profiler

In this project, I have used Dto to pass data to client side. Model to Dto level conversion will be handled by AutoMapperProfile

# Migrations and Seeders 

As project follows code first technique, it also contains migrations. right now it has one single migration whilh will create a database and all the entities at given configuration string.
I have also added seeders so that at initialization level of project, we have some data to work with.

# Testing of controller end points with xUnit and moq tools

Solution file also contains a project for testing of API end points. here I have used currently best practise that we have around the glob using moq and xUnit.
follow ProductControllerTests class.

# Swagger UI

Swagger UI is a collection of HTML, Javascript, and CSS assets that dynamically generate beautiful documentation from a Swagger-compliant API. http://swagger.io
I have added  this in project to review all the end points and test it from browser it self.
