#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./api gateways/PP.Bff.Identidades/PP.Bff.Identidades.csproj", "api gateways/PP.Bff.Identidades/"]
COPY ["./building blocks/PP.Core/PP.Core.csproj", "building blocks/PP.Core/"]
COPY ["./building blocks/PP.MessageBus/PP.MessageBus.csproj", "building blocks/PP.MessageBus/"]

RUN dotnet restore "api gateways/PP.Bff.Identidades/PP.Bff.Identidades.csproj"
COPY . .
WORKDIR "api gateways/PP.Bff.Identidades"
RUN dotnet build "PP.Bff.Identidades.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PP.Bff.Identidades.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PP.Bff.Identidades.dll"]