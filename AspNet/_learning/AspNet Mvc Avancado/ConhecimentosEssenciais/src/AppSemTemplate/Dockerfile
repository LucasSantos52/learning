# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AppSemTemplate.csproj", "AppSemTemplate/"]
RUN dotnet restore "AppSemTemplate/AppSemTemplate.csproj"
WORKDIR "AppSemTemplate"
COPY . .
# Certificado gerado via linha de comando e colocado na pasta https na raiz do projeto
# dotnet dev-certs https -ep ./https/aspnetapp.pfx -p Teste@123 --trust
COPY ./https/aspnetapp.pfx /root/.aspnet/https/
RUN dotnet build "AppSemTemplate.csproj" -c Release -o /app/build

FROM build AS publish
COPY --from=build /root/.aspnet/https/aspnetapp.pfx /root/.aspnet/https/
RUN dotnet publish "AppSemTemplate.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /root/.aspnet/https/aspnetapp.pfx /root/.aspnet/https/
VOLUME /var/data_protection_keys

# instalação do curl para testes
RUN apt-get update && apt-get install -y curl

ENV ASPNETCORE_ENVIRONMENT="Docker"
ENV ASPNETCORE_URLS="http://+:80;https://+:443;"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="Teste@123"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/root/.aspnet/https/aspnetapp.pfx
ENTRYPOINT ["dotnet", "AppSemTemplate.dll"] 
