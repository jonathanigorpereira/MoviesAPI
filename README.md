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

