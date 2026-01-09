# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de proyecto y restaurar dependencias
COPY ["MediaMarktProjectApi.Api/MediaMarktProjectApi.Api.csproj", "MediaMarktProjectApi.Api/"]
COPY ["MediaMarktProjectApi.Application/MediaMarktProjectApi.Application.csproj", "MediaMarktProjectApi.Application/"]
COPY ["MediaMarktProjectApi.Infrastructure/MediaMarktProjectApi.Infrastructure.csproj", "MediaMarktProjectApi.Infrastructure/"]
COPY ["MediaMarktProjectApi.Domain/MediaMarktProjectApi.Domain.csproj", "MediaMarktProjectApi.Domain/"]

RUN dotnet restore "MediaMarktProjectApi.Api/MediaMarktProjectApi.Api.csproj"

# Copiar el resto del código y compilar
COPY . .
WORKDIR "/src/MediaMarktProjectApi.Api"
RUN dotnet build "MediaMarktProjectApi.Api.csproj" -c Release -o /app/build

# Publicar
FROM build AS publish
RUN dotnet publish "MediaMarktProjectApi.Api.csproj" -c Release -o /app/publish

# Etapa final (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Forzar HTTP y entorno de desarrollo (útil en local/desarrollo)
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
ENTRYPOINT ["dotnet", "MediaMarktProjectApi.Api.dll"]