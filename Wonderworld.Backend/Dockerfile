FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Wonderworld.API/Wonderworld.API.csproj", "Wonderworld.API/"]
COPY ["Wonderworld.Infrastructure/Wonderworld.Infrastructure.csproj", "Wonderworld.Infrastructure/"]
COPY ["Wonderworld.Domain/Wonderworld.Domain.csproj", "Wonderworld.Domain/"]
COPY ["Wonderworld.Application/Wonderworld.Application.csproj", "Wonderworld.Application/"]
COPY ["Wonderworld.Persistence/Wonderworld.Persistence.csproj", "Wonderworld.Persistence/"]
COPY ["C:\Users\User\AppData\Roaming\Microsoft\UserSecrets\6fb9c320-3c07-40aa-addd-015d26282428\secrets.json", "secrets.json"]
COPY . .
WORKDIR "/src/Wonderworld.API"
RUN dotnet build "Wonderworld.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wonderworld.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wonderworld.API.dll"]
