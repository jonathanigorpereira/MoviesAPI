# MoviesAPI
This is a simple api developed in Alura's course on .NET 6 technology.
</br>
This api is intended for the study of .NET 6 technology, in order to reinforce the concepts and later study and apply concepts of design Patterns,
asynchronism, performance and EntityFramework.
</br>
</br>
Date: 2023-02-12 18:48:00
</br>
</br>
Until now I learn about REST Patterns and more about API development using .NET 6, where I created a fake datas within Lists and searching this datas using Linq.
</br>
I learned to do exceptions notification natives and parameters to do datas required and I used interfaces actions to do rest returns.
</br>
</br>
Date: 2023-02-13 00:23:00
</br>
</br>
During the development of this project so far, one can learn both in theory and in practice how to efficiently use EntityFramework to create and send data through the use of programmed code. In addition, I have also learned that we must separate the data that will be transmitted from the data that serves as persistence for the creation of tables.
</br></br>
For this the layers were divided into two and they are the `Model` where all the structures related to the tables that will be created in the project will be stored and the `Dtos` inside the Dates folder where the database contexts are, these DTOS (Data Transfer Objects) serve for the manipulation of data between Client and Application.
</br></br>
I also learned how to use the AutoMapper lib to manage the data from the Dtos to the Models automatically and saving the need to create this relationship in the arm, for this besides configuring the AutoMapper in the Program.cs file to map the entire application, it was necessary to create a profile to relate the DTO with the Model.
</br></br>
Date 2023-02-13 16:39:00
</br></br>
Para a conclusão da primeira parte do curso sobre o desenvolvimento de API's, foram apresentados os metodos de `UPDATE`, `PATCH` e `DELETE`, sendo esses para:
</br></br>
  -><strong>UPDATE:</strong> Updates the entire `object` regardless of the level of change in the code.
</br></br>
-><strong>PATCH:</strong> Updates only the desired part of an object.
</br></br>
-><strong>DELETE:</strong> Removes the selected object from the ID.
</br></br>
I also learned about the swagger tool, its configuration within the `Program.cs` file, and how to convert the `summary` to be represented in the swagger documentation.
</br></br>
NOTE:.All implementations were done using EntityFramework and Linq notations.

