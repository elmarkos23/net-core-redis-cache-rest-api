# Net Core con Redis Cache en Rest API

Requisitos 
Cuenta de Azure
Configurar una redis cache
![image](https://github.com/elmarkos23/net-core-redis-cache-rest-api/assets/5819030/162101dd-a69e-4393-8b75-fd5e92a45827)

Despues debes copiar la ruta que del redis generada
![image](https://github.com/elmarkos23/net-core-redis-cache-rest-api/assets/5819030/69a0ca1b-5552-430d-8d13-45bdaa379dc2)

En este proyecto se utiliza para tener acceso a cache de redis mediante una rest api

Abrir el prouecto y reemplazar la ruta copiada con la que se genera en su propio azure

´´´csharp
 // Initialize
    public const string stringConnection = "<NameYourRedisCache>.redis.cache.windows.net,abortConnect=false,ssl=true,allowAdmin=true,password=wDAQoCHTvHdhQf2AhrmmICJuCek1JRM7TAzCaEDIOfU=";
´´´
Aqui un ejemplo como se conecto y retorna los valores mediante swagger
![image](https://github.com/elmarkos23/net-core-redis-cache-rest-api/assets/5819030/f94bfd3b-71d4-443f-876e-2488cfbae3a8)

Validando el estatus de Redis si esta disponible con la cadena de conexion. aqui internamnete se envia un PING y el resultado debe ser PONG
![image](https://github.com/elmarkos23/net-core-redis-cache-rest-api/assets/5819030/aefc3f87-d197-4742-b245-be0c4c99f086)

Aqui enviamos un key y value para que almacenamos
![image](https://github.com/elmarkos23/net-core-redis-cache-rest-api/assets/5819030/9e5b1f3f-8cb4-4693-99b4-c281c73a8ace)

Aqui obtener el value de un key almacenado
![image](https://github.com/elmarkos23/net-core-redis-cache-rest-api/assets/5819030/3da5579f-45fc-4dd6-86ac-1354bbe07b9e)
