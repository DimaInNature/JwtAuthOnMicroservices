#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["JwtExample.Gateway.Desktop/JwtExample.Gateway.Desktop.csproj", "JwtExample.Gateway.Desktop/"]
RUN dotnet restore "JwtExample.Gateway.Desktop/JwtExample.Gateway.Desktop.csproj"
COPY . .
WORKDIR "/src/JwtExample.Gateway.Desktop"
RUN dotnet build "JwtExample.Gateway.Desktop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JwtExample.Gateway.Desktop.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JwtExample.Gateway.Desktop.dll"]