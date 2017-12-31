FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY *.sln ./
COPY Hurriyet.HurriyetDb.WebApi/Hurriyet.HurriyetDb.WebApi.csproj Hurriyet.HurriyetDb.WebApi/
COPY Hurriyet.HurriyetDb.Business/Hurriyet.HurriyetDb.Business.csproj Hurriyet.HurriyetDb.Business/
COPY HurriyetDemo.Core/HurriyetDemo.Core.csproj HurriyetDemo.Core/
COPY HurriyetDemo.HurriyetDb.Entities/HurriyetDemo.HurriyetDb.Entities.csproj HurriyetDemo.HurriyetDb.Entities/
COPY Hurriyet.HurriyetDb.DataAccess/Hurriyet.HurriyetDb.DataAccess.csproj Hurriyet.HurriyetDb.DataAccess/
RUN dotnet restore
COPY . .
WORKDIR /src/Hurriyet.HurriyetDb.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Hurriyet.HurriyetDb.WebApi.dll"]
