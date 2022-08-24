# Prueba-Tecnica-Politecnico

Yo utilize Entity framework con el motor de Sql Server, asi que para correr la base de datos, 
se necesitan instalar los paquete de Entity framework design y entity framework sql server.

una vez instalados los paquetes, para crear la base de datos de forma automatica, se corren los siguientes comandos en la terminal del proyecto.

Dotnet ef migrations add cualquiernombre
dotnet ef database update

De esa forma se creara la base de datos, de manera automatica.

Yo hice el sistema con .net 6. Asi que para probar la api, .net 6 tiene de forma predeterminada a swagger para probarla.

