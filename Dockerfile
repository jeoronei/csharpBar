FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/WebApp/", "src/WebApp/"]
COPY ["src/Domain/", "src/Domain/"]
COPY ["src/Infra/", "src/Infra/"]
COPY ["src/Service/", "src/Application/"]
RUN dotnet restore "src/WebApp/WebApp.csproj"
COPY . .
WORKDIR "/src/src/WebApp"
RUN dotnet build "WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApp.csproj" -c Release -o /app/publish

#RUN chmod +x ./entrypoint.sh

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp.dll"]
