FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/LojaEmbalagem.Api/LojaEmbalagem.Api.csproj", "src/LojaEmbalagem.Api/"]
RUN dotnet restore "src/LojaEmbalagem.Api/LojaEmbalagem.Api.csproj"
COPY . .
WORKDIR "/src/src/LojaEmbalagem.Api"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaEmbalagem.Api.dll"]
