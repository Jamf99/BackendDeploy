# Usa .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia archivos de solución y proyectos
COPY EvaluacionDesempenoSolution.sln ./
COPY EvaluacionDesempenoSolution/EvaluacionDesempeno.Application/EvaluacionDesempeno.Application.csproj EvaluacionDesempenoSolution/EvaluacionDesempeno.Application/
COPY EvaluacionDesempenoSolution/EvaluacionDesempeno.Domain/EvaluacionDesempeno.Domain.csproj EvaluacionDesempenoSolution/EvaluacionDesempeno.Domain/
COPY EvaluacionDesempenoSolution/EvaluacionDesempeno.Infrastructure/EvaluacionDesempeno.Infrastructure.csproj EvaluacionDesempenoSolution/EvaluacionDesempeno.Infrastructure/
COPY EvaluacionDesempenoSolution/EvaluacionDesempeno.WebAPI/EvaluacionDesempeno.WebAPI.csproj EvaluacionDesempenoSolution/EvaluacionDesempeno.WebAPI/

# Restaura
RUN dotnet restore EvaluacionDesempenoSolution.sln

# Copia el resto del código
COPY EvaluacionDesempenoSolution/. ./EvaluacionDesempenoSolution/

# Build
RUN dotnet publish EvaluacionDesempenoSolution/EvaluacionDesempeno.WebAPI/EvaluacionDesempeno.WebAPI.csproj -c Release -o /out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "EvaluacionDesempeno.WebAPI.dll"]
