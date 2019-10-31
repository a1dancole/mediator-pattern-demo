FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["mediator-pattern-demo/mediator-pattern-demo.csproj", "mediator-pattern-demo/"]
COPY ["Demo.Core.Database/Demo.Core.Database.csproj", "Demo.Core.Database/"]
COPY ["Demo.Core.Domain/Demo.Core.Domain.csproj", "Demo.Core.Domain/"]
COPY ["Demo.Modules.ApplicationModule/Demo.Modules.ApplicationModule.csproj", "Demo.Modules.ApplicationModule/"]
RUN dotnet restore "mediator-pattern-demo/mediator-pattern-demo.csproj"
COPY . .
WORKDIR "/src/mediator-pattern-demo"
RUN dotnet build "mediator-pattern-demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mediator-pattern-demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mediator-pattern-demo.dll"]