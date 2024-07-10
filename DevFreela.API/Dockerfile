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

# Copiando o script de inicialização para o container
COPY ["DevFreela.API/entrypoint.sh", "/app/entrypoint.sh"]
RUN chmod +x /app/entrypoint.sh

# Copiando o código da aplicação para a estrutura correta

# Definindo variáveis de ambiente
ENV DB_SERVER=172.31.0.2
ENV DB_DATABASE=devfreela
ENV DB_USER=dev
ENV DB_PASSWORD=yma2578k
ENV DB_PORT=5432

# Definindo o ponto de entrada do container
ENTRYPOINT ["dotnet", "DevFreela.API.dll"]
#ENTRYPOINT ["/app/entrypoint.sh"]

