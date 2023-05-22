# How to launch the proyect
## User secrets
To launch this API in local you should initiate dotnet User Secrets using the command:
```console
dotnet user-secrets init
```
And then executing:
```console
dotnet user-secrets set "EncryptionKey" "your-encryption-key"
```
Replacing the  **your-encryption-key** with your desired encryption key

----------
## Docker
You should install **Docker** on your pc to launch the database in a local instance

> Docker Desktop is a one-click-install application for your Mac, Linux, or Windows environment that enables you to build and share containerized applications and microservices. [Install here](https://www.docker.com/products/docker-desktop/)

Once you have installed it succesfully  enter a console inside the API older and execute the following command:
```console
docker-compose up -d
```
This command will create a new container width the required database to launch

----------
## Launching the APi
Execute one of the following commands:
```console
dotnet build
```
or
```console
dotnet watch
```