# Imagen base para build (usa .NET 8 SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiamos los archivos de la solución
COPY . ./

# Restauramos paquetes
RUN dotnet restore EvaluacionDesempenoSolution.sln

# Build en modo release
RUN dotnet build EvaluacionDesempenoSolution.sln -c Release --no-restore

# Publicamos la app
RUN dotnet publish EvaluacionDesempenoSolution.sln -c Release -o /app/publish --no-build

# Imagen final, runtime (usa runtime ligero)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Puerto que expones (ajústalo según lo que use tu app)
EXPOSE 8080

# Comando para correr la WebAPI
ENTRYPOINT ["dotnet", "EvaluacionDesempeno.WebAPI.dll"]