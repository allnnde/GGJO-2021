# Arquitectura
Arquitectura en capas, inspirada un poco en **clean architecture**
## Capas
### Presentation
Entrada de la aplicacion, aca se verán todo los MonoBehaviour que conectan la interfaz de usuario y la lógica, su principal función es pasar la información necesaria a la capa de aplicaciones, tanto por métodos como eventos.

### Application
Lógica de la aplicacion, se comunica con eventos con presentación para correr las lógicas necesarios.

### Domain
Se encuentra todo lo que refleje puramente datos, interfaces y enumeraciones del sistema.

### Infrastructure
Capa que se encarga de servicios cross a todas las capas y de aquellos servicios que sean externos al juego como helpers, services locator, mappers, conexiones a db, ets
