# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiamos los archivos del proyecto
COPY *.sln .
COPY EvaluacionDesempenoSolution/EvaluacionDesempeno.*/*.csproj ./EvaluacionDesempenoSolution/EvaluacionDesempeno.*/
COPY EvaluacionDesempenoSolution/EvaluacionDesempeno.*/ ./EvaluacionDesempenoSolution/EvaluacionDesempeno.*/

# Restauramos dependencias
RUN dotnet restore EvaluacionDesempenoSolution.sln

# Copiamos el resto y compilamos
COPY . .
RUN dotnet publish EvaluacionDesempenoSolution/EvaluacionDesempeno.WebAPI/EvaluacionDesempeno.WebAPI.csproj -c Release -o /out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./

# Exponemos el puerto estándar
EXPOSE 8080

# Comando de arranque
ENTRYPOINT ["dotnet", "EvaluacionDesempeno.WebAPI.dll"]