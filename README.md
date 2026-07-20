# HTTP QUERY method with ASP.NET Core

Ejemplo pequeño de una API ASP.NET Core que compara tres maneras de trabajar
con usuarios generados con [Bogus](https://github.com/bchavez/Bogus):

- `GET` recibe filtros en la URL con `[FromQuery]`.
- `POST` recibe filtros en un body JSON.
- `QUERY` recibe filtros complejos en un body JSON con `[FromBody]`.

Los usuarios son falsos y se generan al iniciar la aplicación. Los tres
endpoints aplican exactamente los mismos filtros sobre esa lista.

## Ejecutar

```bash
dotnet run --launch-profile http
```

La API queda disponible en `http://localhost:5281`. También se puede ejecutar
cada solicitud del archivo [http-query-rfc.http](http-query-rfc.http) desde
VS Code o Rider.

## Endpoints

### GET: filtros en query string

`GET /api/v1/users?minAge=30&maxAge=50`

Este endpoint usa `[FromQuery] UserQueryDto`. Los filtros disponibles son
`name`, `lastName`, `email`, `minAge` y `maxAge`; todos son opcionales.

```bash
curl 'http://localhost:5281/api/v1/users?name=ana&minAge=25'
```

### POST: filtros en body JSON

`POST /api/v1/users`

```bash
curl -X POST http://localhost:5281/api/v1/users \
  -H 'Content-Type: application/json' \
  -d '{"minAge":30,"maxAge":50}'
```

Este endpoint usa `[FromBody] UserQueryDto` y responde con los usuarios que
coinciden. Se incluye únicamente para comparar una consulta expresada con
`POST` frente a `GET` y `QUERY`.

### QUERY: filtros en body JSON

`QUERY /api/v1/users`

```bash
curl -X QUERY http://localhost:5281/api/v1/users \
  -H 'Content-Type: application/json' \
  -d '{"minAge":30,"maxAge":50}'
```

`QUERY` no es un método HTTP ampliamente soportado por navegadores, proxies o
herramientas. Para una prueba controlada funciona con `curl`, pero para APIs
de producción suele ser más interoperable usar `GET` para filtros simples o
`POST` para búsquedas con body.
