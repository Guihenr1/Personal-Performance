#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/services/PP.Identidade.API/PP.Identidade.API.csproj", "src/services/PP.Identidade.API/"]
RUN dotnet restore "src/services/PP.Identidade.API/PP.Identidade.API.csproj"
COPY . .
WORKDIR "/src/src/services/PP.Identidade.API"
RUN dotnet build "PP.Identidade.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PP.Identidade.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PP.Identidade.API.dll"]