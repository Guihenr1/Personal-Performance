#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./services/PP.Usuario.API/PP.Usuario.API.csproj", "services/PP.Usuario.API/"]
COPY ["./building blocks/PP.Core/PP.Core.csproj", "building blocks/PP.Core/"]
COPY ["./building blocks/PP.MessageBus/PP.MessageBus.csproj", "building blocks/PP.MessageBus/"]

RUN dotnet restore "services/PP.Usuario.API/PP.Usuario.API.csproj"
COPY . .
WORKDIR "services/PP.Usuario.API"
RUN dotnet build "PP.Usuario.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PP.Usuario.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PP.Usuario.API.dll"]
