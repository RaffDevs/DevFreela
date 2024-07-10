echo "Aplicando as migrações do Entity Framework Core..."
echo $DB_SERVER
echo $DB_DATABASE
cd /app/DevFreela/DevFreela.API
dotnet ef database update --connection "Host=$DB_SERVER;Port=$DB_PORT;Pooling=true;Database=$DB_DATABASE;User Id=$DB_USER;Password=$DB_PASSWORD;"

#echo "Iniciando o serviço da API..."
#cd /app
#dotnet DevFreela.API.dll
