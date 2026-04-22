Role of the Controller:
The Controller helps to handle incoming HTTP requests, process them, and return appropriate HTTP responses.
It acts as an intermediary between the Model (data) and the View (presentation).
In the context of a Web API, the Controller is responsible for defining the endpoints that clients can interact with,
processing the requests, and returning data in a format such as JSON or XML.

Role of the Service:
The Service layer contains the business logic of the application. 
It is responsible for processing data, performing operations, and enforcing business rules.
The Service layer is typically called by the Controller to perform specific tasks, such as retrieving data from a database,
validating input, or performing calculations.

Discuss C# Resource Cleanup Conceptually:
If Ticket Data were stored in a file, the C# Resourece Cleanup would involve ensuring that the file stream
is properly closed after reading or writing to the file.

In C#, resource cleanup is typically handled through the use of the `IDisposable` interface and the `using` statement. 
When a class implements `IDisposable`, it provides a `Dispose` method that can be called to release unmanaged resources, 
such as file handles, database connections, or network connections.
The `using` statement ensures that the `Dispose` method is called automatically when the object goes out of scope,
even if an exception occurs.