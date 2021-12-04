FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiExampleBackEnd/ApiExampleBackEnd.csproj", "ApiExampleBackEnd/"]
RUN dotnet restore "ApiExampleBackEnd/ApiExampleBackEnd.csproj"
COPY . .
WORKDIR "/src/ApiExampleBackEnd"
RUN dotnet build "ApiExampleBackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiExampleBackEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiExampleBackEnd.dll"]
