#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./services/PP.Treino.API/PP.Treino.API.csproj", "services/PP.Treino.API/"]
COPY ["./building blocks/PP.Core/PP.Core.csproj", "building blocks/PP.Core/"]

RUN dotnet restore "services/PP.Treino.API/PP.Treino.API.csproj"
COPY . .
WORKDIR "services/PP.Treino.API"
RUN dotnet build "PP.Treino.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PP.Treino.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PP.Treino.API.dll"]