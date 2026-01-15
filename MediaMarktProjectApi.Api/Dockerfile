# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

# Copiar archivos de proyecto y restaurar dependencias
COPY ["MediaMarktProjectApi.Api/MediaMarktProjectApi.Api.csproj", "MediaMarktProjectApi.Api/"]
COPY ["MediaMarktProjectApi.Application/MediaMarktProjectApi.Application.csproj", "MediaMarktProjectApi.Application/"]
COPY ["MediaMarktProjectApi.Infrastructure/MediaMarktProjectApi.Infrastructure.csproj", "MediaMarktProjectApi.Infrastructure/"]
COPY ["MediaMarktProjectApi.Domain/MediaMarktProjectApi.Domain.csproj", "MediaMarktProjectApi.Domain/"]

RUN dotnet restore "MediaMarktProjectApi.Api/MediaMarktProjectApi.Api.csproj"

COPY . .
WORKDIR "/src/MediaMarktProjectApi.Api"
RUN dotnet publish "MediaMarktProjectApi.Api.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER app

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 8080

ENTRYPOINT ["dotnet", "MediaMarktProjectApi.Api.dll"]