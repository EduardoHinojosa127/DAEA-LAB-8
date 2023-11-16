FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 3000

# Utiliza la imagen de SDK de .NET Core 7.0 como base para compilar
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia todo el contenido del proyecto
COPY . .

# Define la versión de .NET que deseas utilizar
ENV DOTNET_ROOT=/usr/share/dotnet
ENV PATH=$PATH:/usr/share/dotnet

# Publica y compila la aplicación en un solo paso
RUN dotnet publish -c Release -o /app/publish

# Configura el contenedor de producción
FROM base AS final
WORKDIR /app

# Copia los archivos publicados de la etapa "publish" al contenedor
COPY --from=build /app/publish .

# Define el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "Prueba.dll"]