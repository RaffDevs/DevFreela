# Fase base: SDK do .NET para build e publicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DevFreela.API/DevFreela.API.csproj", "DevFreela.API/"]
RUN dotnet restore "DevFreela.API/DevFreela.API.csproj"
COPY . .
WORKDIR "/src/DevFreela.API"
RUN dotnet build "DevFreela.API.csproj" -c Release -o /app/build

# Fase de publicação
FROM build AS publish
RUN dotnet publish "DevFreela.API.csproj" -c Release -o /app/publish

# Fase final: SDK do .NET para executar ferramentas e aplicar migrações
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Instalação da ferramenta dotnet-ef
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
COPY [".", "/app/DevFreela"]

WORKDIR /app/DevFreela/DevFreela.API

# Variáveis de ambiente para conexão com o banco de dados
ENV DB_SERVER=mysql
ENV DB_DATABASE=devfreela
ENV DB_USER=dev
ENV DB_PASSWORD=yma2578k

# Execução das migrações do Entity Framework Core
RUN dotnet ef database update --connection "Server=$DB_SERVER;Database=$DB_DATABASE;User=$DB_USER;Password=$DB_PASSWORD;"
WORKDIR /app

ENTRYPOINT ["dotnet", "DevFreela.API.dll"]
