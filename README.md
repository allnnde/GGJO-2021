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

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Architecture
Layered architecture, a bit inspired by **clean architecture**.
## Layers
### Presentation
Application input, here you will see all the MonoBehaviour that connect the user interface and the logic, its main function is to pass the necessary information to the application layer, both by methods and events.

### Application
Logic of the application, it communicates with events with presentation to run the necessary logics.

### Domain
It is everything that reflects purely data, interfaces and system enumerations.

### Infrastructure
Layer that is in charge of cross services to all the layers and of those services that are external to the game as helpers, services locator, mappers, connections to db, ets.

Translated with www.DeepL.com/Translator (free version)
