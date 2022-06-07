# ChatPlatformAPI
A Rest API Chat Platform

### Application
- Swagger UI
- Azure Sql Database

### Packages
- Entity Framework core
- Mapster
- Swagger

### Documentation
The API include two functionalities:
- Send Message: It is a POST function that allows users to send a message. It also stores the chat in the user's cookie.

```
curl -X 'POST' \
  'https://chatplatform.azurewebsites.net/api/Chat' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "username": "Adeola",
  "message": "Hello, Goodmorning"
}'
```

- Get Chat History : It is a GET function that gets chat history. 

```
curl -X 'GET' \
  'https://chatplatform.azurewebsites.net/api/Chat' \
  -H 'accept: */*'
```

##### [Swagger Documentation](https://chatplatform.azurewebsites.net/index.html)
