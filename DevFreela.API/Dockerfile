# Fase base: SDK do .NET para build e publicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas o arquivo de projeto para otimizar o cache do Docker
COPY ["DevFreela.API/DevFreela.API.csproj", "DevFreela.API/"]
RUN dotnet restore "DevFreela.API/DevFreela.API.csproj"

# Copia todos os arquivos do projeto
COPY . .

# Muda o diretório de trabalho para o projeto e realiza o build
WORKDIR "/src/DevFreela.API"
RUN dotnet build "DevFreela.API.csproj" -c Release -o /app/build

# Instalação do dotnet-ef globalmente


# Fase de publicação
FROM build AS publish
RUN dotnet publish "DevFreela.API.csproj" -c Release -o /app/publish

# Fase final: imagem ASP.NET para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia os arquivos publicados da fase de publicação
COPY --from=publish /app/publish .

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Copia a pasta MEUTESTE para dentro do contêiner
COPY ["DevFreela.API/", "/app/API"]

# Instalação do dotnet-ef e aplicação de migrações
ARG DB_SERVER=mysql
ARG DB_DATABASE=devfreela
ARG DB_USER=dev
ARG DB_PASSWORD=yma2578k

# Exemplo de aplicação de migrações (descomente esta linha se desejar aplicar as migrações durante a construção da imagem)
# RUN dotnet ef database update --connection "Server=$DB_SERVER;Database=$DB_DATABASE;User=$DB_USER;Password=$DB_PASSWORD;"

# Comando de entrada para iniciar a aplicação
ENTRYPOINT ["dotnet", "DevFreela.API.dll"]
