# Biblioteca Web Api
Simple web api to manage a library users, books and loans.
## Users
Users, on every endpoint may be fetched using standard RESTful api routes.
### Profesores
Professors may be created on the /profesor endpoint.
Professors may have 5 book loans tops.
### Estudiantes
Students may be created on the /estudiante endpoint.
Students may have 3 book loans tops.

## Books
Books follow standard RESTful api routes.

## Library
Library is managed through the /biblioteca endpoint.

One may lend books through the /biblioteca/lend endpoint.

One may return books through the /biblioteca/return endpoint.

History can be checked through the /biblioteca/history endpoint.

History can be checked by user or book through /biblioteca/user/{id} or /biblioteca/book/{id}
## Excel
This web api is made to use an excel file as a database:
[BibliotecaBaseDatos.xlsx](https://github.com/user-attachments/files/17808106/BibliotecaBaseDatos.xlsx)

