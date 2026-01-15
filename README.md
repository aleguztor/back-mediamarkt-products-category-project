# Proyecto Mediamarkt "Productos"

Esta es la api para la gestión de productos de MediaMarkt.

### Requisitos

- .Net8
- Docker
- Visual studio
- SQL Server Express

### Cómo iniciar el proyecto

- Tener abierto Docker

- En visual studio elegimos el perfil docker-compose y ejecutamos. Esto creará: API, bbdd y aplica las migraciones correspondientes.

- Después de esto podremos acceder a la API con la url [http://localhost:5186](http://localhost:5186/)

### Acceder a la BBDD

    Server: localhost
    Auth de SQL Sever
    User: sa
    Password: lb#rI1lL/kO6Raqe1=w@
    Nombre de bbdd: mediamarkt_db
    Cifrar: Obligatorio
    Marcar Certificado de servidor de confianza

### Más datos

El backend tiene unas migraciones para añadir datos a la bbdd, pero puedes añadir datos extras con el EXTRAS.sql que encontrarás clicando [aquí](./EXTRAS.sql).
