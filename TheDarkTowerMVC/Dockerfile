#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TheDarkTowerMVC/TheDarkTowerMVC.csproj", "TheDarkTowerMVC/"]
RUN dotnet restore "TheDarkTowerMVC/TheDarkTowerMVC.csproj"
COPY . .
WORKDIR "/src/TheDarkTowerMVC"
RUN dotnet build "TheDarkTowerMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheDarkTowerMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheDarkTowerMVC.dll"]