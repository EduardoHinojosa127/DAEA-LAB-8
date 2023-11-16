# Utiliza la imagen de ASP.NET Core como base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Utiliza la imagen de SDK de .NET Core como base para compilar
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia todo el contenido del proyecto
COPY . .

# Publica y compila la aplicación en un solo paso
RUN dotnet publish -c Release -o /app/publish

# Configura el contenedor de producción
FROM base AS final
WORKDIR /app

# Copia los archivos publicados de la etapa "publish" al contenedor
COPY --from=build /app/publish .

# Define el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "Backend.dll"]