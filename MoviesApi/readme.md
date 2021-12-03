# Movies API

* The backend consists of a .net core 3.1 REST API communicating to an SQL Server Instance 
via Entity Framework Core. The db may be deployed after adding your connection string in the
 app.config file and running the ......  command (which also seeds it with a couple of movies) . 
Data retrieval is encapsulated within the ISqlMovieData interface, which is injected into the 
controller's constructor and its concrete implementation is in the same folder. 
To facilitate data update, a DTO class is used. The API exposes the following methods: 


*Verb: GET

Route: api/movies

Description: get all movies

*Verb: GET

Route api/movies/{movieId}

Description: get specific movie

*Verb: PATCH

Route api/movies/{movieId}

Description: Edit a specific Movie(if a property of a movie is not given the existing one will remain unchanged )
For this i also created an EditModel class which has the same movie properties but the title is not required

*Verb: POST

Route api/movies/

Description: create a movie

*Verb: DELETE

Route api/movies/{movieId}

Description: deletes a specific movie