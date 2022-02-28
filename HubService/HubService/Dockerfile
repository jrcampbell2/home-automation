#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HubService/HubService.csproj", "HubService/"]
COPY ["HubService.Tests/HubService.Tests.csproj", "HubService.Tests/"]
COPY ["HubService.sln", ".."]
RUN dotnet restore "HubService/HubService.csproj"
RUN dotnet restore "HubService.Tests/HubService.Tests.csproj"

COPY . .
WORKDIR "/src/HubService"
RUN dotnet build "HubService.csproj" -c Release -o /app/build
RUN dotnet test ..

FROM build AS publish
RUN dotnet publish "HubService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HubService.dll"]