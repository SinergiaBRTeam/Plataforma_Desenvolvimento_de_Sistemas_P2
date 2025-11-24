FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY UniThesisApi.sln ./
COPY UniThesis.Application/UniThesis.Application.csproj UniThesis.Application/
COPY UniThesis.Domain/UniThesis.Domain.csproj UniThesis.Domain/
COPY UniThesis.Infrastructure/UniThesis.Infrastructure.csproj UniThesis.Infrastructure/
COPY UniThesis.WebApi/UniThesis.WebApi.csproj UniThesis.WebApi/

RUN dotnet restore UniThesisApi.sln

COPY . .

RUN dotnet publish UniThesis.WebApi/UniThesis.WebApi.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "UniThesis.WebApi.dll"]
