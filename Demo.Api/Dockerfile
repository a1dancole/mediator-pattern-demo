FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Demo.Api/Demo.Api.csproj", "Demo.Api/"]
COPY ["Demo.Core.Database/Demo.Core.Database.csproj", "Demo.Core.Database/"]
COPY ["Demo.Core.Domain/Demo.Core.Domain.csproj", "Demo.Core.Domain/"]
COPY ["Demo.Core.Infrastructure/Demo.Core.Infrastructure.csproj", "Demo.Core.Infrastructure/"]
COPY ["Demo.Modules.ApplicationModule/Demo.Modules.ApplicationModule.csproj", "Demo.Modules.ApplicationModule/"]
COPY ["Demo.Modules.RolesModule/Demo.Modules.RolesModule.csproj", "Demo.Modules.RolesModule/"]
RUN dotnet restore "Demo.Api/Demo.Api.csproj"
COPY . .
WORKDIR "/src/Demo.Api"
RUN dotnet build "Demo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.dll"]
