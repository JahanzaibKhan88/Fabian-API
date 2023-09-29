#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Fabian.API/Fabian.API.csproj", "Fabian.API/"]
COPY ["Fabian.Application/Fabian.Application.csproj", "Fabian.Application/"]
COPY ["Fabian.Domain/Fabian.Domain.csproj", "Fabian.Domain/"]
COPY ["Fabian.Infrastructure/Fabian.Infrastructure.csproj", "Fabian.Infrastructure/"]
RUN dotnet restore "Fabian.API/Fabian.API.csproj"
COPY . .
WORKDIR "/src/Fabian.API"
RUN dotnet build "Fabian.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fabian.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fabian.API.dll"]